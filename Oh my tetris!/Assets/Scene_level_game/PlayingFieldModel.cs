using UnityEngine;

namespace Assets.Gameplay
{
    public class PlayingFieldModel
    {
        public CellModel[,] CellsArray { get; private set; }

        public PlayingFieldModel()
        {
            CellsArray = new CellModel[7, 7];
        }

        public PlayingFieldModel(int xDimenstion, int yDimension)
        {
            CellsArray = new CellModel[xDimenstion, yDimension];

            for (int i = 0; i < CellsArray.GetLength(0); ++i)
                for (int j = 0; j < CellsArray.GetLength(1); ++j)
                {
                    CellsArray[i, j] = new CellModel(new Vector2(i + 1, j + 1));
                }
        }
    }
}
