using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessLayer.Entities.Validations.Document
{
    public class CpfValidation
    {
        public const int Size = 11;

        public static bool Validate(string cpf)
        {
            var cpfNumbers = Utils.OnlyDigits(cpf);

            if (!ValidLength(cpfNumbers)) return false;
            return !RepeatedDigits(cpfNumbers) && DigitsValidation(cpfNumbers);
        }

        private static bool ValidLength(string values)
        {
            return values.Length == Size;
        }

        private static bool RepeatedDigits(string values)
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };
            return invalidNumbers.Contains(values);
        }

        private static bool DigitsValidation(string values)
        {
            var number = values[..(Size - 2)];
            var digitValidation = new DigitValidation(number)
                .MultiplyCount(2, 11)
                .Overridding("0", 10, 11);
            var firstDigit = digitValidation.CalcDigit();
            digitValidation.AddDigitValidator(firstDigit);
            var secondDigit = digitValidation.CalcDigit();

            return string.Concat(firstDigit, secondDigit) == values.Substring(Size - 2, 2);
        }
    }

    public class CnpjValidation
    {
        public const int Size = 14;

        public static bool Validate(string cpnj)
        {
            var cnpjNumbers = Utils.OnlyDigits(cpnj);

            if (!ValidLength(cnpjNumbers)) return false;
            return !RepeatedDigits(cnpjNumbers) && DigitsValidation(cnpjNumbers);
        }

        private static bool ValidLength(string values)
        {
            return values.Length == Size;
        }

        private static bool RepeatedDigits(string values)
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
            return invalidNumbers.Contains(values);
        }

        private static bool DigitsValidation(string values)
        {
            var number = values[..(Size - 2)];

            var digitValidation = new DigitValidation(number)
                .MultiplyCount(2, 9)
                .Overridding("0", 10, 11);
            var firstDigit = digitValidation.CalcDigit();
            digitValidation.AddDigitValidator(firstDigit);
            var secondDigit = digitValidation.CalcDigit();

            return string.Concat(firstDigit, secondDigit) == values.Substring(Size - 2, 2);
        }
    }

    public class DigitValidation
    {
        private string _number;
        private const int Module = 11;
        private readonly List<int> _multipliers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _substitutions = new Dictionary<int, string>();
        private bool _moduleComplements = true;

        public DigitValidation(string numero)
        {
            _number = numero;
        }

        public DigitValidation MultiplyCount(int primeiroMultiplicador, int ultimoMultiplicador)
        {
            _multipliers.Clear();
            for (var i = primeiroMultiplicador; i <= ultimoMultiplicador; i++)
                _multipliers.Add(i);

            return this;
        }

        public DigitValidation Overridding(string substituto, params int[] digitos)
        {
            foreach (var i in digitos)
            {
                _substitutions[i] = substituto;
            }
            return this;
        }

        public void AddDigitValidator(string digito)
        {
            _number = string.Concat(_number, digito);
        }

        public string CalcDigit()
        {
            return !(_number.Length > 0) ? "" : GetDigitSum();
        }

        private string GetDigitSum()
        {
            var soma = 0;
            for (int i = _number.Length - 1, m = 0; i >= 0; i--)
            {
                var produto = (int)char.GetNumericValue(_number[i]) * _multipliers[m];
                soma += produto;

                if (++m >= _multipliers.Count) m = 0;
            }

            var mod = (soma % Module);
            var resultado = _moduleComplements ? Module - mod : mod;

            return _substitutions.ContainsKey(resultado) ? _substitutions[resultado] : resultado.ToString();
        }
    }

    public class Utils
    {
        public static string OnlyDigits(string values)
        {
            var onlyNumber = "";
            foreach (var s in values)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}