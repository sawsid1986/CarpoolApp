using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CarpoolApp.Web.Helpers
{
    public class CarpoolDateTimeFormatConverter: DateTimeConverterBase
    {
        string[] CUSTOM_DATE_FORMATS = new string[]
                {
                    @"dd/MM/yyyy HH:mm"
                };

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return ParseDateTime(reader.Value.ToString());
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.WriteValue(ConvertToString((DateTime)value));
        }

        public string ConvertToString(DateTime date,
            string format = null)
        {
            if (format == null)
            {
                format = CUSTOM_DATE_FORMATS[0];
            }

            return date.ToString(format);
        }

        public DateTime? ParseDateTime(
            string dateToParse,
            string[] formats = null,
            IFormatProvider provider = null,
            DateTimeStyles styles = DateTimeStyles.None)
        {
            if (formats == null)
            {
                formats = CUSTOM_DATE_FORMATS;
            }

            if (provider == null)
            {
                provider = CultureInfo.InvariantCulture;
            }

            DateTime validDate;

            foreach (var format in formats)
            {
                if (DateTime.TryParseExact(dateToParse, format,
                         provider, styles, out validDate))
                {
                    return validDate;
                }
            }

            return null;
        }
    }
}