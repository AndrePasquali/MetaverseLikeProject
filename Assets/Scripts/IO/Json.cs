using System.IO;
using Newtonsoft.Json;

namespace IO
{
    public static class Json<T>
    {
        public static void Save(T toJson, string filePath)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using StreamWriter sw = new StreamWriter(filePath);
            using JsonWriter writer = new JsonTextWriter(sw);
            
            serializer.Serialize(writer, toJson);
        }
        
        public static T Load(string filePath)
        {
            var deserializedObject = JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));

            return deserializedObject;
        }
    }
}