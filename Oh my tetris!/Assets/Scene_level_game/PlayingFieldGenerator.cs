using UnityEngine;

namespace Assets.Gameplay
{
    public class PlayingFieldGenerator : MonoBehaviour
    {
        public GameObject Generate(
            int xDimension,
            int yDimension,
            GameObject playingFieldPrefab,
            GameObject cellPrefab)
        {
            var playingFieldModel = new PlayingFieldModel(xDimension, yDimension);

            var newPlayingField = Instantiate(playingFieldPrefab);

            foreach (var cell in playingFieldModel.CellsArray)
            {
                var newCell = Instantiate(cellPrefab, newPlayingField.transform);
                newCell.GetComponent<CellController>().InitializeModel(cell);
            }

            return newPlayingField;
        }
    }
}