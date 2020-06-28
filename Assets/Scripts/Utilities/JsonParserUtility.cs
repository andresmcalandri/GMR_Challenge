using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public static class JsonParserUtility
{
    public static string GetStringFromJsonFile(string jsonFilePath)
    {
        StreamReader streamReader = new StreamReader(jsonFilePath);
        string jsonString = streamReader.ReadToEnd();
        streamReader.Close();
        streamReader.Dispose();
        return jsonString;
    }

    public static Dictionary<T, J> GetDictionaryFromJson<T, J>(string json)
    {
        Dictionary<T, J> jsonDictionary = JsonConvert.DeserializeObject<Dictionary<T, J>>(json);
        return jsonDictionary;
    }

    public static List<T> GetListFromJson<T>(string json)
    {
        List<T> jsonDictionary = JsonConvert.DeserializeObject<List<T>>(json);
        return jsonDictionary;
    }
}
