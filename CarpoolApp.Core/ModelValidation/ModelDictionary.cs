using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Core.ModelValidation
{
    public class ModelDictionary : IModelDictionary
    {
        private Dictionary<string, string> _modelState;
        public ModelDictionary()
        {
            _modelState = new Dictionary<string, string>();
        }

        public void add(string key,string value)
        {
            if(!_modelState.Keys.Contains(key))
            {
                _modelState.Add(key, value);
            }
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _modelState.GetEnumerator();
        }

        public bool IsValid()
        {
            return _modelState.Count() == 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _modelState.GetEnumerator();
        }
    }
}
