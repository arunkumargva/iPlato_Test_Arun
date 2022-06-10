using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using iPlato_Test.CommonUserControls;
using iPlato_Test.Models;
using iPlato_Test.ViewModels;
namespace iPlato_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new PeopleViewModel();
            //var viewModel = new Person();

            //DataContext = viewModel;
            var dataContext = new ContentPlaceHolder();
            //dataContext.Model= viewModel;
            dataContext.DataContext= viewModel;
            this.Content = dataContext;
        }
    }
}
