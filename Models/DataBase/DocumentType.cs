using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    /// <summary>
    /// Паспортные данные
    /// </summary>
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }

        [Required(ErrorMessage = "Не указан вид документа")]
        [DataType(DataType.Text)]
        [Display(Name = "Вид документа")]
        public string Name { get; set; }
        public virtual ICollection<Anketa> Anketas { get; set; }
    }
}