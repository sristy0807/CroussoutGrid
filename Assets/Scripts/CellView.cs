using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CellView
{
    public Sprite lockedImage;
    public Sprite UnlockedImage;

    public Text CellText;
    public Image CellImage;

    private Cell ThisCell;

    public void AssignCell(Cell cell)
    {
        ThisCell = cell;
        UpdateCellView();
        UpdateCellText();
    }

    public void UpdateCellView()
    {
        UpdateCellImage();
    }

    private void UpdateCellText()
    {
        CellText.text = ThisCell.CarriedValue.ToString();
    }

    private void UpdateCellImage()
    {
        switch (ThisCell.activeCellState)
        {
            case CellState.unlocked:
                CellImage.sprite = UnlockedImage;
                break;
            case CellState.locked:
                CellImage.sprite = lockedImage;
                break;
        }
    }
}
