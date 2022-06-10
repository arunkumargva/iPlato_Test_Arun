using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using iPlato_Test.CommonObjects;

namespace iPlato_Test.Utils
{
    public class ClassDataTemplateSelector : DataTemplateSelector
    {

        [DefaultValue(ViewTypeId.Simple)]
        public ViewTypeId ViewTypeId { get; set; }

        [DefaultValue(ViewTypeId.Simple)]
        public ViewTypeId FallbackViewTypeId { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate dt = null;
            DataTemplate template;
            // try get the data template for the item

            if (item is null) return null;
            string typeName = item.GetType().Name;
            var dataTemplateName = string.Format("{0}:{1}", item.GetType().Name, this.ViewTypeId);
            return this.GetDataTemplate(typeName, dataTemplateName, out template) ? template : null;

        }
        public DataTemplate ContainerViewTemplate { get; set; }


        private static readonly Dictionary<string, Uri> _classUrIs = new Dictionary<string, Uri>(1000)
        {
         {
             "Person", new Uri("/iPlato_Test;component/Views/DataTemplates/Person.xaml", UriKind.Relative)
         },
         {
             "PeopleViewModel", new Uri("/iPlato_Test;component/Views/DataTemplates/PeopleViewModel.xaml", UriKind.Relative)
         },
        
        };
        private bool GetDataTemplate(string typeName, string dataTemplateName, out DataTemplate dataTemplate)
        {
            dataTemplate = null;
            if (_classUrIs.ContainsKey(typeName))
            {
                Uri classUri;
                if (_classUrIs.TryGetValue(typeName, out classUri))
                {
                    {
                        var resourceDictionary = (ResourceDictionary)Application.LoadComponent(classUri);
                        if (resourceDictionary.Contains(dataTemplateName))
                        {
                            dataTemplate = resourceDictionary[dataTemplateName] as DataTemplate;
                            {
                                return true;
                            }
                        }
                    }
                }

            }
            return false;
        }
    }
}
