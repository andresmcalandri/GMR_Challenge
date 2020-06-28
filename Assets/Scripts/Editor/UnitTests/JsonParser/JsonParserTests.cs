using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Tests
{
    public class JsonParserTests
    {
        string testFilePath = "";
        [SetUp]
        public void SetUp()
        {
            testFilePath = Path.Combine(Application.dataPath, "Scripts", "Editor", "UnitTests", "JsonParser", "testJson.json");
        }

        [Test]
        public void GetStringFromJson()
        {
            string jsonString = JsonParserUtility.GetStringFromJsonFile(testFilePath);
            Assert.IsTrue(!string.IsNullOrEmpty(jsonString));
        }

        [Test]
        public void GetDictionaryFromJson()
        {
            string jsonString = JsonParserUtility.GetStringFromJsonFile(testFilePath);
            var jsonDictionary = JsonParserUtility.GetDictionaryFromJson<string, object>(jsonString);
            Assert.IsTrue(jsonDictionary != null && jsonDictionary is Dictionary<string, object>);
        }
    }
}