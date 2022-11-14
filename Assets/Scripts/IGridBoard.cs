using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGridBoard 
{
    int numberOfCells { get; set; }
    void InitializeGridBoard(int minValue, int maxValue);
    bool AllCellDead();
}
