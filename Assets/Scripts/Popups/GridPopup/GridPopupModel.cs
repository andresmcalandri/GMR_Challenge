using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GridPopupModel
{
    const string COLUMN_HEADERS = "ColumnHeaders";
    const string TITLE = "Title";

    protected virtual string FilePath
    {
        get
        {
            return Path.Combine(Application.streamingAssetsPath, "Configs", "JsonChallenge.json");
        }
    }

    Dictionary<string, object> json;
    public GridPopupModel()
    {
        LoadJsonFile();
    }

    public void LoadJsonFile()
    {
        string jsonString = JsonParserUtility.GetStringFromJsonFile(FilePath);
        json = JsonParserUtility.GetDictionaryFromJson<string, object>(jsonString);
    }
        

    public string Title
    {
        get
        {
            return json.ContainsKey(TITLE) ? json[TITLE].ToString() : "";
        }
    }

    public string TitleType
    {
        get
        {
            return TITLE;
        }
    }

    public string ColumnHeaderType
    {
        get
        {
            return COLUMN_HEADERS;
        }
    }

    public List<string> GetColumnHeaders()
    {
        List<string> headers = null;
        if (json.ContainsKey(COLUMN_HEADERS))
        {
            string headersString = json[COLUMN_HEADERS].ToString();
            headers = JsonParserUtility.GetListFromJson<string>(headersString);
        }

        return headers;
    }

    public List<Dictionary<string, string>> GetRowsData()
    {
        List<Dictionary<string, string>> headers = null;

        if (json.ContainsKey(COLUMN_HEADERS))
        {
            string headersString = json["Data"].ToString();
            headers = JsonParserUtility.GetListFromJson<Dictionary<string, string>>(headersString);
        }

        return headers;
    }

}
