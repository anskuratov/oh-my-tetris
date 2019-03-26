using UnityEngine;

namespace Assets.Gameplay
{
    public class CellController : MonoBehaviour
    {
        private CellModel _cellModel;

        public void InitializeModel(CellModel cellModel)
        {
            _cellModel = cellModel;
            transform.localPosition = _cellModel.Position;
            ShowHideModel();
        }

        public void EmptyCell()
        {
            _cellModel.EmptyCell();
            ShowHideModel();
        }

        public void FillCell()
        {
            _cellModel.FillCell();
            ShowHideModel();
        }

        private void ShowHideModel()
        {
            transform.GetChild(0).gameObject.SetActive(_cellModel.CellState == CellState.Filled);
        }
    }
}
