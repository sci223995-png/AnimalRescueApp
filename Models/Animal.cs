using System.ComponentModel.DataAnnotations;

namespace AnimalRescueApp.Models
{
    public class Animal
    {
        [Key]
        public int AnimalID { get; set; }

        [Required(ErrorMessage = "الرجاء إدخال اسم الحيوان")]
        public string Name { get; set; }

        [Required(ErrorMessage = "الرجاء تحديد النوع")]
        public string Species { get; set; } // مثل: كلب، قطة

        public int Age { get; set; }

        public string HealthStatus { get; set; }

        public string ImageURL { get; set; } // مسار الصورة في السيرفر
    }
}