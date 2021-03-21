using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace ModelValidation
{
    class BaseModel
    {
        private List<string> getErrors<T>() where T : Attribute, IValidationAttribute
        {

            List<string> errors = new List<string>();
            IEnumerable<PropertyInfo> stringValidatorProperties = this.GetType()
                .GetProperties()
                .Where(p => p.GetCustomAttributes(true)
                       .Any(attr => attr.GetType() == typeof(T)));

            foreach (PropertyInfo stringProp in stringValidatorProperties)
            {
                T strValAttr = stringProp
                    .GetCustomAttributes(true)
                    .First(a => a.GetType() == typeof(T)) as T;

                //string propValue = (string)stringProp.GetValue(this);
                object propValue = stringProp.GetValue(this);
                errors.AddRange(strValAttr.GetValidationErrors(propValue));
            }
            return errors;

        }

        public IReadOnlyCollection<string> GetValidationErrors()
        {
            List<string> errors = getErrors<StringValidatorAttribute>();
            errors.AddRange(getErrors<IntegerValidatorAttibute>());
            return errors;

        }
    }
}
