using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class GridBoard : MonoBehaviour,IGridBoard,ITemporaryCellContainer
{
    public static event Action OnAllCellDead;
    
    public int numberOfCells { get; set; }
    public List<CellBehavior> Cells;

    public ScoreManager scoreManager;

    [SerializeField] private List<CellBehavior> temporaryCells;

    [SerializeField] private int minValue;
    [SerializeField] private int maxValue;

    // Start is called before the first frame update
    void Start()
    {
        if(scoreManager == null)
        {
            scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        }

        InitializeGridBoard(minValue,maxValue);

        temporaryCells = new List<CellBehavior>();

        
    }

    private void OnEnable()
    {
        CellController.OnAddingCellValueTemporary += AddCellToTemporaryList;
        CellController.OnRemovingCellValue += RemoveCellFromTemporaryList;
        CellController.OnAddValueToScore += ClearListWhenDone;
    }

    private void OnDisable()
    {
        CellController.OnAddingCellValueTemporary -= AddCellToTemporaryList;
        CellController.OnRemovingCellValue -= RemoveCellFromTemporaryList;
        CellController.OnAddValueToScore -= ClearListWhenDone;
    }

    public static void OnGameOver()
    {
        OnAllCellDead?.Invoke();
    }

    public void InitializeGridBoard(int minValue, int maxValue)
    {
        foreach (CellBehavior cell in Cells)
        {
            int randomNumber = Random.Range(minValue, maxValue + 1);
            cell.InitializeCell(randomNumber);
        }
    }

    public bool AllCellDead()
    {
        foreach(CellBehavior cell in Cells)
        {
            if (!cell.isDead)
            {
                return false;
            }
        }

        return true;
    }

    public void AddCellToTemporaryList(CellBehavior cell)
    {
        temporaryCells.Add(cell);
        scoreManager.AddTemporaryScoreAndCheckForAddingWithScore(cell.cell.CarriedValue);

        CheckGameOver();
        //Debug.Log("added cell " + cell.gameObject.name);
    }

    private void CheckGameOver()
    {
        if (Cells.Count - temporaryCells.Count == 0)
        {
            
            OnGameOver();
        }
    }

    public void ClearTemporaryList(List<CellBehavior> temporaryCells)
    {
        if(temporaryCells != null)
        {
            foreach(CellBehavior cell in temporaryCells)
            {
                cell.DisableCell();
                Cells.Remove(cell);
                //Debug.Log(cell.gameObject.name);
            }

           
        }


        temporaryCells.Clear();

    }

    public void RemoveCellFromTemporaryList(CellBehavior cell)
    {
        scoreManager.RemoveTemporaryScore(cell.cell.CarriedValue);
        temporaryCells.Remove(cell);
    }

    public void ClearListWhenDone()
    {
        ClearTemporaryList(temporaryCells);
    }
}
