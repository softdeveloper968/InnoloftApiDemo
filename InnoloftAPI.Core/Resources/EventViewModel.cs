using System;
using System.ComponentModel.DataAnnotations;

namespace InnoloftAPI.Core.Resources
{
    public class EventViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "OwnerId is required.")]
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "StartDate is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required.")]
        [DateGreaterThan("StartDate", ErrorMessage = "EndDate must be greater than StartDate.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "UpdateEventDate is required.")]
        public DateTime UpdateEventDate { get; set; }

        [Required(ErrorMessage = "CreateEventDate is required.")]
        public DateTime CreateEventDate { get; set; }

        [Required(ErrorMessage = "Timezone is required.")]
        public string Timezone { get; set; }

        [Required(ErrorMessage = "EventTitle is required.")]
        public string EventTitle { get; set; }

        [Required(ErrorMessage = "EventDescription is required.")]
        public string EventDescription { get; set; }
    }

    // Custom validation attribute for comparing dates
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (propertyInfo == null)
            {
                return new ValidationResult($"Property {_comparisonProperty} not found.");
            }

            var comparisonValue = propertyInfo.GetValue(validationContext.ObjectInstance) as DateTime?;

            if (comparisonValue == null)
            {
                return new ValidationResult($"Property {_comparisonProperty} is not a DateTime.");
            }

            if ((DateTime)value <= comparisonValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
