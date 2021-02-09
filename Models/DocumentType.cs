using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models
{
    /// <summary>
    /// Паспортные данные
    /// </summary>
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }

        [Required(ErrorMessage = "Не указан тип документа")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип документа")]
        public string Name { get; set; }
        public virtual ICollection<Anketa> Anketas { get; set; }
    }
}