﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Utilities
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetEnumValues<T>(this T input) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException();

            return Enum.GetValues(input.GetType()).Cast<T>();
        }

        public static IEnumerable<SelectListItem> GetAllEnumSelectListItem<TBaseType>(bool showDefault = false, string selectedValue = null) where TBaseType : Enum, new()
        {
            if (showDefault)
            {
                yield return new SelectListItem()
                {
                    Value = null,
                    Text = "لطفا انتخاب کنید"
                };
            }
            foreach (TBaseType item in (TBaseType[])Enum.GetValues(typeof(TBaseType)))
            {
                yield return new SelectListItem() { Value = item.ToString(), Text = item.ToDisplay(), Selected = item.ToString().Equals(selectedValue)};
            }
        }

        public static IEnumerable<SelectListItem> GetAllEnumSelectListItemValueInt<TBaseType>() where TBaseType : Enum, new()
        {
            foreach (TBaseType item in Enum.GetValues(typeof(TBaseType)))
            {
                yield return new SelectListItem() { Value = (Convert.ToInt32(item)).ToString(), Text = item.ToDisplay() };
            }
        }
        public static SelectList GetAllEnumSelectList<TBaseType>(bool showDefault = true) where TBaseType : Enum, new()
        {
            var result = new List<SelectListItem>();
            if(showDefault)
                result.Add(new SelectListItem { Value = null, Text = "لطفا انتخاب کنید" });

            result.AddRange(GetAllEnumSelectListItemValueInt<TBaseType>());

            return new SelectList(result, "Value", "Text");
        }

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }



        public static IEnumerable<T> GetEnumFlags<T>(this T input) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException();

            foreach (var value in Enum.GetValues(input.GetType()))
                if ((input as Enum).HasFlag(value as Enum))
                    yield return (T)value;
        }

        public static string ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name)
        {
            try
            {
                var attribute = value?.GetType().GetField(value.ToString())
                    .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

                if (attribute == null)
                    return value?.ToString();

                var propValue = attribute?.GetType().GetProperty(property.ToString()).GetValue(attribute, null);
                return propValue?.ToString();
            }
            catch (Exception e)
            {
                return "-";
            }
          
        }

        public static Dictionary<int, string> ToDictionary(this Enum value)
        {
            return Enum.GetValues(value.GetType()).Cast<Enum>().ToDictionary(p => Convert.ToInt32(p), q => ToDisplay(q));
        }

        public static int ToValue<T>(this T input) where T : struct
        {
            return Convert.ToInt32(input);
        }
        public static string GetEnumDisplayName<T>(T value) where T : Enum
        {
            var fieldName = Enum.GetName(typeof(T), value);
            var displayAttr = typeof(T)
                .GetField(fieldName)
                .GetCustomAttribute<DisplayAttribute>();
            return displayAttr?.Name ?? fieldName;
        }
    }

    public enum DisplayProperty
    {
        Description,
        GroupName,
        Name,
        Prompt,
        ShortName,
        Order
    }
}
