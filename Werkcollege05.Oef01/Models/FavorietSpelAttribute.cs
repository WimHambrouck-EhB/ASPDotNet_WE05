using Microsoft.AspNetCore.Mvc.DataAnnotations.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace Werkcollege05.Oef01.Models
{
    internal class FavorietSpelAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return true;
        }
    }
}