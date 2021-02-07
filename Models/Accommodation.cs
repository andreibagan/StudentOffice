using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    /// <summary>
    /// Сведения о месте проживания
    /// </summary>
    public class Accommodation
    {
        public int AccommodationId { get; set; }

        [Required(ErrorMessage = "Не указан домашний телефон")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Домашний телефон")]
        public string HomePhone { get; set; }

        [Required(ErrorMessage = "Ошибка валидации")]
        [DataType(DataType.Text)]
        [Display(Name = "Нуждаюсь в общежитии на время учебы")]
        public bool SocialBehavior { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Anketa> Anketas { get; set; }
    }
}
