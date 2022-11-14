using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController 
{
    public static event Action<CellBehavior> OnAddingCellValueTemporary;
    public static event Action<CellBehavior> OnRemovingCellValue;
    public static event Action OnAddValueToScore;

    public static void AddCellValue(CellBehavior cellBehavior)
    {
        OnAddingCellValueTemporary?.Invoke(cellBehavior);
    }


    public static void RemoveCellValue(CellBehavior cellBehavior)
    {
        OnRemovingCellValue?.Invoke(cellBehavior);
    }

    public static void AddValueToScore()
    {
        OnAddValueToScore?.Invoke();
    }


}
