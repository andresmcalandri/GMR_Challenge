using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextGridItem : MonoBehaviour, IGridItem
{
    public void Setup(object text)
    {
        this.GetComponent<Text>().text = text != null ? text.ToString() : "";
    }
}