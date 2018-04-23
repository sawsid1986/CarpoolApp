using CarpoolApp.Core.ModelValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Core
{
    public class Query<T>:Command where T:class
    {
        public T Result { get; private set; }

        public Query(T Result=null, bool IsFound = true, bool IsDuplicate = false, Exception Ex = null, IModelDictionary _modelState = null)
            :base(IsFound,IsDuplicate,Ex, _modelState)
        {
            this.Result = Result;
        }
    }
}
