﻿using StudentOffice.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    /// <summary>
    /// Специальность
    /// </summary>
    public class Specialty
    {
        public int SpecialtyId { get; set; }

        [Required(ErrorMessage = "Не указана специальность")]
        [DataType(DataType.Text)]
        [Display(Name = "Специальность")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан уровень образования")]
        [DataType(DataType.Text)]
        [Display(Name = "Уровень образования*")]
        public EducationType EducationType { get; set; }

        [Required(ErrorMessage = "Не указано отделение")]
        [DataType(DataType.Text)]
        [Display(Name = "Отделение")]
        public Branch Branch { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Anketa> Anketas { get; set; }
        public virtual ICollection<MainPlan> MainPlans { get; set; }
        public virtual ICollection<Specialization> Specializations { get; set; }


        public string GetSpecialtyNameBranch
        {
            get
            {
                return $"{Name} ({EnumHelper<Branch>.GetDisplayValue(Branch)})";
            }
        }

        //[Display(Name = "Программное обеспечение информационных технологий")]
        //InformationTechnologySoftware = 1,
        //[Display(Name = "Правоведение")]
        //Jurisprudence,
        //[Display(Name = "Операционная деятельность в логистике")]
        //OperationsInLogistics,
        //[Display(Name = "Бухгалтерский учёт, анализ и контроль")]
        //AccountingAnalysisControl
    }
}
