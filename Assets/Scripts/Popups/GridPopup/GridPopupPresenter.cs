using UnityEngine;

public class GridPopupPresenter
{
    GridPopupModel model;
    GridPopupView view;

    public GridPopupPresenter(GridPopupModel model, GridPopupView view)
    {
        this.model = model;
        this.view = view;

        SetView();
    }

    protected void SetView()
    {
        view.SetTitle(model.TitleType, model.Title);
        view.SetGrid(model.ColumnHeaderType, model.GetColumnHeaders(), model.GetRowsData());
    }
}
