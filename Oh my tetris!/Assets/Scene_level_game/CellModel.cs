using UnityEngine;

namespace Assets.Gameplay
{
    public class CellModel
    {
        public Vector2 Position { get; private set; }
        public CellState CellState { get; private set; }

        public CellModel(Vector2 position, CellState cellState = CellState.Empty)
        {
            Position = position;
            CellState = cellState;
        }

        public void EmptyCell()
            => CellState = CellState.Empty;

        public void FillCell()
            => CellState = CellState.Filled;
    }
}
