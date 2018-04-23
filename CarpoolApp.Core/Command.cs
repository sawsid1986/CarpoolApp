using CarpoolApp.Core.ModelValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace CarpoolApp.Core
{
    public class Command
    {
        public bool IsFound { get; private set; }
        public bool IsDuplicate { get; private set; }
        public Exception Ex { get; private set; }
        public IModelDictionary ModelState { get; private set; }

        public bool IsValid {
            get
            {
                return IsFound && !IsDuplicate && Ex == null && ModelState == null;
            }
        }

        public Command(bool IsFound=true,bool IsDuplicate=false,Exception Ex=null, IModelDictionary _modelState=null)
        {
            this.IsFound = IsFound;
            this.IsDuplicate = IsDuplicate;
            ModelState = _modelState;
            this.Ex = Ex;
        }
    }
}
