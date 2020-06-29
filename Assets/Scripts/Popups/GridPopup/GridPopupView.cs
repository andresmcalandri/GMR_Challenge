using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridPopupView : MonoBehaviour
{
    protected GridItemFactory factory;

    [SerializeField]
    ScrollRect scrollViewPrefab = null;
    [SerializeField]
    GameObject gridRowPrefab = null;

    GameObject titleObj;
    ScrollRect scrollRect;

    void Awake()
    {
        InitializeFactory();
    }

    protected virtual void InitializeFactory()
    {
        factory = new GridItemFactory();
    }

    public void SetTitle(string titleType, string title)
    {
        if (titleObj == null)
        {
            titleObj = factory.Get(titleType, title);
            if (titleObj != null)
            {
                titleObj.transform.SetParent(this.transform, false);
                titleObj.transform.SetAsFirstSibling();
            }
        }
        else
        {
            titleObj.GetComponent<IGridItem>().Setup(title);
        }
    }

    public void SetGrid(string headerType, List<string> columnHeaderValues, List<Dictionary<string, string>> rowsData)
    {
        if (scrollRect == null)
        {
            scrollRect = Instantiate(scrollViewPrefab, this.transform);
        }
        else
        {
            while (scrollRect.content.childCount > 0)
            {
                Destroy(scrollRect.content.GetChild(0));
            }
        }
        
        GameObject gridRow = Instantiate(gridRowPrefab, scrollRect.content);
        foreach (var headerValue in columnHeaderValues)
        {
            GameObject header = factory.Get(headerType, headerValue);
            if (header != null)
            {
                header.transform.SetParent(gridRow.transform, false);
            }
        }

        foreach (var row in rowsData)
        {
            gridRow = Instantiate(gridRowPrefab, scrollRect.content);
            foreach (var header in columnHeaderValues)
            {
                GameObject rowItem;
                if (row.ContainsKey(header))
                {
                    rowItem = factory.Get(header, row[header]);
                }
                else
                {
                    rowItem = factory.Get(header, null);
                }

                if (rowItem != null)
                {
                    rowItem.transform.SetParent(gridRow.transform, false);
                }
            }
        }
    }
}
