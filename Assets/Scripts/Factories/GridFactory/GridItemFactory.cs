using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridItemFactory
{
    Dictionary<string, GameObject> templatesById;

    protected virtual string DataPath
    {
        get
        {
            return "GridItemFactoryData";
        }
    }

    public GridItemFactory()
    {
        GridItemFactoryDataSO factoryData = Resources.Load<GridItemFactoryDataSO>(DataPath);
        templatesById = new Dictionary<string, GameObject>();
        for (int i = 0; i < factoryData.templates.Count; i++)
        {
            try
            {
                templatesById.Add(factoryData.templates[i].Id, factoryData.templates[i].Prefab);
            }
            catch
            {
                Debug.LogWarningFormat("{0} - The template {1} is duplicated in {2}", this.GetType(), factoryData.templates[i].Id, DataPath);
            }
        }
    }

    public GameObject Get(string key, object data)
    {
        if (templatesById.ContainsKey(key))
        {
            GameObject newObject = GameObject.Instantiate(templatesById[key]);
            IGridItem item = newObject.GetComponent<IGridItem>();
            item.Setup(data);
            return newObject;
        }
        else
        {
            Debug.LogErrorFormat("{0} - The template {1} does not exist in {2}", this.GetType(), key, DataPath);
        }

        return null;
    }
}
