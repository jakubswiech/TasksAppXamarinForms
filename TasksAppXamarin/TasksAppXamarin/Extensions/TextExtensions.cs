using System;
using System.Collections.Generic;
using System.Text;

namespace TasksAppXamarin.Extensions
{
    public static class TextExtensions
    {
        public static string FormatMinutes(this int minutes)
        {
            var hours = minutes / 60;
            return $"{hours}h {minutes % 60}m";
        }
    }
}
