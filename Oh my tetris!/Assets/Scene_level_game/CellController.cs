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
        }
    }
}
