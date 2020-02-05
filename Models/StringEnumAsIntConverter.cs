// Copyright Cooling Technology Institute 2019-2020


namespace Models
{
    /// <summary>
    /// JSON string enum as integer converter to override the global string enum converter.
    /// Serializes/deserializes the enumerated type in number form as a JSON string.
    /// </summary>
    public class StringEnumAsIntConverter : Newtonsoft.Json.JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The JsonWriter to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// void.
        /// </returns>
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            try
            {
                writer.WriteValue(System.Convert.ToInt32(value).ToString());
            }
            catch (System.Exception exception)
            {
                throw new Newtonsoft.Json.JsonException(
                    string.Format("Json enum serialization error"),
                    exception
                    );
            }
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The JsonReader to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            try
            {
                return System.Enum.Parse(objectType, reader.Value.ToString());
            }
            catch (System.Exception exception)
            {
                throw new Newtonsoft.Json.JsonException(
                    string.Format("Json enum deserialization error"),
                    exception
                    );
            }
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// true if this instance can convert the specified object type; otherwise, false.
        /// </returns>
        public override bool CanConvert(System.Type objectType)
        {
            return (objectType == typeof(string));
        }
    }
}
