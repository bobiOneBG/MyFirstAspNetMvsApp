namespace MyFirstMvsApp.Models.CarAd
{
    using Microsoft.AspNetCore.Mvc;
    using MyFirstMvsApp.ModelBinders;
    using MyFirstMvsApp.ValidationAttributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarBrandAndModel : IValidatableObject
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Model == "Opel" && !this.Brand.StartsWith("V") && this.Brand.StartsWith("A") &&
                this.Brand.StartsWith("C"))
            {
                yield return new ValidationResult("Invalid Opel model");
            }
        }
    }
    public class CreateInputModel
    {
        public CarBrandAndModel Car { get; set; }

        public CarType Type { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        //1900 - afteryear
        [BeforeCurrentYear(1900)]
        public DateTime ReleaseDate { get; set; }
        //Custom model binding extract year(int) from datetime form
        [DataType(DataType.Date)]
        // [ModelBinder(typeof(DateTimeToYearModelBinder))]
        [BeforeCurrentYear(1900)]
        public int Year { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public byte[] Image { get; set; }
    }

    public enum CarType
    {
        Sedan = 1,
        SUV = 2,
        Cabrio = 3,
        Wagon = 4
    }
}
