using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace XYZInc.Api.Tests.Integration
{
    public static class SerializationHelper
    {
        public static StringContent ToSerializedStringContent(this object value)
        {
            var serializedOrder = JsonSerializer.Serialize(value);

            return new StringContent(serializedOrder, Encoding.UTF8, "application/json");
        }
    }
}
