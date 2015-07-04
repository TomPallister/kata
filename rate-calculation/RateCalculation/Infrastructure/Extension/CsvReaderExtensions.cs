using System;
using CsvHelper;

namespace RateCalculation.Infrastructure.Extension
{
    public static class CsvReaderExtensions
    {
        public static T GetSafeValue<T>(this CsvReader csvReader, int index, T defaultValue)
        {
            try
            {
                var field = csvReader.GetField<T>(index);
                return field;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}
