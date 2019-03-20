using UnityEngine;

namespace Assets.Gameplay
{
    public class PlayingFieldController : MonoBehaviour
    {
        private PlayingFieldModel _playingFieldModel;

        public void InitializeModel(PlayingFieldModel playingFieldModel)
        {
            _playingFieldModel = playingFieldModel;
        }
    }
}
