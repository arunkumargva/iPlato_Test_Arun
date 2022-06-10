using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPlato_Test.Commands
{
    public interface ICommandParameter
    {
        object Input { get; set; }

        bool IsSuccessful { get; }

        object Output { get; set; }

        bool? Result { get; set; }
    }

    public class CommandParameter : ICommandParameter
    {
        public object Input { get; set; }

        public bool IsSuccessful
        {
            get
            {
                return this.Result.HasValue && this.Result.Value;
            }
        }

        public object Output { get; set; }

        public bool? Result { get; set; }

        //public static void VerifyInput<TInputType>(object inputData)
        //{
        //    if (inputData == null) return;
        //    var type = typeof(TInputType);
        //    if (type.IsInstanceOfType(inputData)) return;
        //    throw new Exception(string.Format("Expecting a {0} as input but {1} is sent.[{2}].", type, inputData.GetType(), inputData));
        //}
    }
}
