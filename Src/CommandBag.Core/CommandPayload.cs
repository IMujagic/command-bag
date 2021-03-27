using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandBag.Core
{
    public class CommandPayload
    {
        private IDictionary<string, string> _parsedArgs;

        public void ReadArgs(string[] args) 
        {
            _parsedArgs = new Dictionary<string, string>();
            _parsedArgs.Add("n", "Hello");
            _parsedArgs.Add("d", "true");
        }

        public T ToDomainModel<T>() where T : IDomainModel
        {
            if (_parsedArgs == null || !_parsedArgs.Any())
                throw new Exception("Parsed arguments dictionary is empty");

            var instance = Activator.CreateInstance<T>();
            instance.MapArgsToProperties(_parsedArgs);

            return instance;
        }
    }
}
