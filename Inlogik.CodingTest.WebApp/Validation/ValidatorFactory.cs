using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Inlogik.CodingTest.WebApp.Validation
{
    public class ValidatorFactory : IValidatorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IValidator<T> GetValidator<T>()
        {
            return (IValidator<T>)GetValidator(typeof(T));
        }

        public IValidator GetValidator(Type type)
        {
            var genericType = typeof(IValidator<>).MakeGenericType(type);
            return _serviceProvider.GetService(genericType) as IValidator;
        }
    }
}
