using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Business.Filtros
{
    public class ModelCarAttribute : ValidationAttribute
    {
        public int Anio { get; }
        public ModelCarAttribute(int year)
        {
            Anio = year;
        }
        public string GetErrorMessage() => $"Los autos no puede ser mas viejo que {Anio}.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var añoFabricacion = (int)value!;
            if (añoFabricacion < Anio)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}
