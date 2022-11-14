using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cell
{
    public CellState activeCellState { get; private set; }
    public int CarriedValue;

    public Cell(CellState cellState, int valueToCarry)
    {
        activeCellState = cellState;
        CarriedValue = valueToCarry;
    }

    public void AlterState()
    {
        if (activeCellState != CellState.locked)
        {
            activeCellState = CellState.locked;
        }
        else
        {
            activeCellState = CellState.unlocked;
        }
    }

}


public enum CellState
{
    unlocked,
    locked
}