using System.Globalization;

namespace API.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToCurrency(this decimal value) =>
            string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", value);
    }
}
