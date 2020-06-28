using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridItemFactoryData", menuName = "ScriptableObjects/GridItemFactoryDataSO")]
public class GridItemFactoryDataSO : ScriptableObject
{
    public List<GridItemFactoryDataSOItem> templates = new List<GridItemFactoryDataSOItem>();
}

[Serializable]
public class GridItemFactoryDataSOItem
{
    [SerializeField]
    string id = "";

    [SerializeField]
    GameObject prefab = null;

    public string Id
    {
        get { return id; }
    }

    public GameObject Prefab
    {
        get { return prefab; }
    }
}