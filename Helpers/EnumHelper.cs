using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using StudentOffice.Models.DataBase;

namespace StudentOffice.Helpers
{
    public static class EnumHelper<T>
    {
        public static IList<T> GetValues(Enum value)
        {
            var enumValues = new List<T>();

            foreach (FieldInfo fi in value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add((T)Enum.Parse(value.GetType(), fi.Name, false));
            }
            return enumValues;
        }

        public static T Parse(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static IList<string> GetNames(Enum value)
        {
            return value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        }

        public static IList<string> GetDisplayValues(Enum value)
        {
            return GetNames(value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
        }

        private static string lookupResource(Type resourceManagerProvider, string resourceKey)
        {
            foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }

            return resourceKey; // Fallback with the key name
        }

        public static string GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes[0].ResourceType != null)
                return lookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }

        public static string GetReduction(T value)
        {
            string ReductionValue = string.Empty;
            string CurrentValue = GetDisplayValue(value);

            if (CurrentValue == "Агрогородок")
            {
                return "аг.";
            }

            string[] CurrentValueArray = CurrentValue.ToLower().Split(' ');

            foreach (var word in CurrentValueArray)
            {
                ReductionValue += (word[0] + '.');
            }

            return ReductionValue;
        }

        public static string GetReductionRegion(T value)
        {
            string ReductionValue = string.Empty;
            string CurrentValue = GetDisplayValue(value);

            string[] CurrentValueArray = CurrentValue.ToLower().Split(' ');

            return ReductionValue = CurrentValue[0] + " обл.";
        }

        public static string GetReductionStreet(StreetType value)
        {
            string ReductionValue = string.Empty;
            string CurrentValue = EnumHelper<StreetType>.GetDisplayValue(value);


            if (CurrentValue == "Аллея")
            {
                return "ал.";
            }

            if (CurrentValue == "Площадь")
            {
                return "пл.";
            }

            if (CurrentValue == "Бульвар")
            {
                return "б-р";
            }

            if (CurrentValue == "Въезд")
            {
                return "взд.";
            }

            if (CurrentValue == "Набережная")
            {
                return "наб.";
            }

            if (CurrentValue == "Шоссе")
            {
                return "ш.";
            }

            if (CurrentValue == "Квартал")
            {
                return "кв-л";
            }

            if (CurrentValue == "Микрорайон")
            {
                return "мкр.";
            }

            if (CurrentValue == "Переулок")
            {
                return "пер.";
            }

            if (CurrentValue == "Проезд")
            {
                return "пр-д";
            }
            if (CurrentValue == "Проспект")
            {
                return "пр-кт";
            }
            if (CurrentValue == "Станция")
            {
                return "ст.";
            }
            if (CurrentValue == "Территория")
            {
                return "тер.";
            }
            if (CurrentValue == "Тракт")
            {
                return "тракт";
            }
            if (CurrentValue == "Тупик")
            {
                return "туп.";
            }
            if (CurrentValue == "Улица")
            {
                return "ул.";
            }

            return CurrentValue.ToLower();
        }
    }
}
