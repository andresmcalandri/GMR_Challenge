using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    public GameObject gridPopupPrefab;

    
    void Start()
    {
        //This should be done in a popup factory
        GameObject gridPopup = GameObject.Instantiate(gridPopupPrefab, canvas.transform);
        GridPopupModel gridPopupModel = new GridPopupModel();
        GridPopupPresenter gridPopupPresenter = new GridPopupPresenter(gridPopupModel, gridPopup.GetComponent<GridPopupView>());
    }

    private void OnDestroy()
    {
        
    }
}
