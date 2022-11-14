using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITemporaryCellContainer
{
 
    void AddCellToTemporaryList(CellBehavior cell);
    void RemoveCellFromTemporaryList(CellBehavior cell);
    void ClearTemporaryList(List<CellBehavior> temporaryCells);
}
