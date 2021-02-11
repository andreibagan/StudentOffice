using StudentOffice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.ViewModels
{
    public class AnketaViewModel
    {
        ///// <summary>
        ///// Основные сведения
        ///// </summary>
        //public int AnketaId { get; set; }

        //[Required(ErrorMessage = "Не указана фамилия")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Фамилия")]
        //public string Surname { get; set; }

        //[Required(ErrorMessage = "Не указано имя")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Имя")]
        //public string Name { get; set; }

        //[Required(ErrorMessage = "Не указано отчество")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Отчество")]
        //public string Middlename { get; set; }

        //[Required(ErrorMessage = "Не указана фамилия в родительном")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Фамилия в родительном")]
        //public string SurnameR { get; set; }

        //[Required(ErrorMessage = "Не указано имя в родительном")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Имя в родительном")]
        //public string NameR { get; set; }

        //[Required(ErrorMessage = "Не указано отчество в родительном")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Отчество в родительном")]
        //public string MiddlenameR { get; set; }

        //[Required(ErrorMessage = "Не указана дата рождения")]
        //[DataType(DataType.Date)]
        //[Display(Name = "Дата рождения")]
        //public DateTime Birthday { get; set; }

        //[Required(ErrorMessage = "Не указан пол")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Пол")]
        //public Sex Sex { get; set; }

        ///// <summary>
        ///// Паспортные данные
        ///// </summary>
        //public int PassportId { get; set; }
        //public virtual Passport Passport { get; set; }
        ///// <summary>
        ///// Сведения о месте проживания
        ///// </summary>
        //public int AccommodationId { get; set; }
        //public virtual Accommodation Accommodation { get; set; }

        ///// <summary>
        ///// Сведения об образовании
        ///// </summary>
        //public int EducationId { get; set; }
        //public virtual Education Education { get; set; }
        ///// <summary>
        ///// Специальность
        ///// </summary>
        //public int SpecialtyId { get; set; }
        //public virtual Specialty Specialty { get; set; }
        ///// <summary>
        ///// Сведения о трудовой деятельности
        /////(заполняется только учащимися заочного отделения)
        ///// </summary>
        //public int? EmploymentInformationId { get; set; }
        //public virtual EmploymentInformation EmploymentInformation { get; set; }
        ///// <summary>
        ///// Сведения о отце
        ///// </summary>
        //public int? FatherId { get; set; }
        //public virtual Father Father { get; set; }
        ///// <summary>
        ///// Сведения о матери
        ///// </summary>
        //public int? MotherId { get; set; }
        //public virtual Mother Mother { get; set; }
















        public Anketa Anketa { get; set; }

        public IEnumerable<DocumentType> DocumentTypes { get; set; }
        public IEnumerable<Specialty> Specialties { get; set; }
        //TODO: ?
    }
}
