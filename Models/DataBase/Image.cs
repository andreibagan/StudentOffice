using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentOffice.Models.DataBase
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Имя файла")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Загрузить файл")]
        public IFormFile ImageFile { get; set; }
    }
}
