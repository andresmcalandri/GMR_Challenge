using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridPopupView : MonoBehaviour
{
    protected GridItemFactory factory;

    [SerializeField]
    Transform gridContainer = null;
    [SerializeField]
    ScrollRect scrollViewPrefab = null;
    [SerializeField]
    GameObject gridRowPrefab = null;
    [SerializeField]
    Button reloadButton = null;

    GameObject titleObj;
    ScrollRect scrollRect;

    public Action OnReloadClicked;

    void Awake()
    {
        InitializeFactory();
        reloadButton.onClick.AddListener(OnReloadButtonClicked);
    }

    protected virtual void InitializeFactory()
    {
        factory = new GridItemFactory();
    }

    protected void OnReloadButtonClicked()
    {
        if (OnReloadClicked != null)
        {
            OnReloadClicked.Invoke();
        }
    }

    public void SetTitle(string titleType, string title)
    {
        if (titleObj == null)
        {
            titleObj = factory.Get(titleType, title);
            if (titleObj != null)
            {
                titleObj.transform.SetParent(gridContainer, false);
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
        //Not ideal but since the data set is small, this should be an issue. If we were to be handling a big data set, i would instead have 
        //created a logic robust enough to detect which were the changes and delete and update what was needed instead. Destroying and re creating
        //the whole list could be a direct hit to performance if handling bigger data sets.
        if (scrollRect != null)
        {
            Destroy(scrollRect.gameObject);
        }

        scrollRect = Instantiate(scrollViewPrefab, gridContainer);

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

    private void OnDestroy()
    {
        reloadButton.onClick.RemoveListener(OnReloadButtonClicked);
    }
}
