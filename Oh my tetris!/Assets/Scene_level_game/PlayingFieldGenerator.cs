using UnityEngine;

namespace Assets.Gameplay
{
    public class PlayingFieldGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _cellPrefab;

        [SerializeField]
        private GameObject _playingFieldPrefab;

        public GameObject Generate(
            int xDimension,
            int yDimension)
        {
            var playingFieldModel = new PlayingFieldModel(xDimension, yDimension);

            var newPlayingField = Instantiate(_playingFieldPrefab);

            foreach (var cell in playingFieldModel.CellsArray)
            {
                var newCell = Instantiate(_cellPrefab, newPlayingField.transform);
                newCell.GetComponent<CellController>().InitializeModel(cell);
            }

            return newPlayingField;
        }
    }
}