using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace CarpoolApp.Core.ModelValidation
{
    public interface IModelDictionary:IEnumerable<KeyValuePair<string,string>>
    {
        void add(string key, string value);        
    }
}
