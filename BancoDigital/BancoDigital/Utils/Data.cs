using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class Data
    {
        public static int CalcularIdade(DateTime dataNascimento)
        {
            var today = DateTime.Today;
            var age = today.Year - dataNascimento.Year;
            if (dataNascimento.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
