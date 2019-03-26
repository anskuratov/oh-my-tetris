using UnityEngine;

namespace Assets.Gameplay
{
    public class PlayingFieldGenerator : MonoBehaviour
    {
        public GameObject Generate(
            int xDimension,
            int yDimension,
            GameObject playingFieldPrefab,
            GameObject cellPrefab,
            GameObject borderPrefab)
        {
            var playingFieldModel = new PlayingFieldModel(xDimension, yDimension);

            var newPlayingField = Instantiate(playingFieldPrefab);

            GeneratePlayingField(playingFieldModel, cellPrefab, newPlayingField);

            GeneratePlayingFieldBorder(xDimension, yDimension, borderPrefab, newPlayingField);

            return newPlayingField;
        }

        private void GeneratePlayingField(
            PlayingFieldModel playingFieldModel,
            GameObject cellPrefab,
            GameObject playingFieldParent)
        {
            foreach (var cell in playingFieldModel.CellsArray)
            {
                var newCell = Instantiate(cellPrefab, playingFieldParent.transform);
                newCell.GetComponent<CellController>().InitializeModel(cell);
            }
        }

        private void GeneratePlayingFieldBorder(
            int xDimension,
            int yDimension,
            GameObject borderPrefab, 
            GameObject playingFieldParent)
        {
            for (int i = 0; i < xDimension + 2; ++i)
            {
                var newBorderCell = Instantiate(borderPrefab, playingFieldParent.transform);
                newBorderCell.transform.localPosition = new Vector2(i, 0);
            }

            for (int j = 1; j < yDimension + 1; ++j)
            {
                var newBorderCell = Instantiate(borderPrefab, playingFieldParent.transform);
                newBorderCell.transform.localPosition = new Vector2(0, j);

                newBorderCell = Instantiate(borderPrefab, playingFieldParent.transform);
                newBorderCell.transform.localPosition = new Vector2(xDimension + 1, j);
            }
        }
    }
}