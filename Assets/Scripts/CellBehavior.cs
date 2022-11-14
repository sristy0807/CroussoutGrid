using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CellBehavior : MonoBehaviour
{

   
   
    public Cell cell;
    public CellView cellView;


    [SerializeField] public bool isDead { get; private set; }
    [SerializeField] private Button thisButton;

    private void Start()
    {
        
    }

    private void UpdateCellState()
    {
        cell.AlterState();
        cellView.UpdateCellView();
    }

    private void OnScoreAdding()
    {
        Debug.Log("adding value : " + cell.CarriedValue);
    }

    private void OnScoreRemoving()
    {
        Debug.Log("removing value : " + cell.CarriedValue);
    }

    public void InitializeCell(int cellValue)
    {
        if (GetComponent<Button>() != null)
        {
            thisButton = GetComponent<Button>();
        }
        else
        {
            thisButton = this.gameObject.AddComponent<Button>();
        }

        if (thisButton.onClick == null)
        {
            thisButton.onClick.AddListener(OnClickGridButton);
        }

        
        cell = new Cell(CellState.unlocked, cellValue);
        cellView.AssignCell(cell);
    }

    public void DisableCell()
    {
        isDead = true;
        thisButton.interactable = false;
    }

    public void OnClickGridButton()
    {
        if (!isDead)
        {
            UpdateCellState();

            switch (cell.activeCellState)
            {
                case CellState.locked:
                    CellController.AddCellValue(this);
                    break;
                case CellState.unlocked:
                    CellController.RemoveCellValue(this);
                    break;
            }
        }

    }

   

  



}
