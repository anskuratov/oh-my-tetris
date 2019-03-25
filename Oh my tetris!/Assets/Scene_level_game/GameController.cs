using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private Transform _playingFieldParent;

        [SerializeField]
        private GameObject _playingFieldPrefab;

        [SerializeField]
        private GameObject _cellPrefab;

        private PlayingFieldController _playingFieldController;
        private GameModel _gameModel;

        private PlayingFieldGenerator _playingFieldGenerator;

        [Inject]
        private void ZenjectInit(PlayingFieldGenerator playingFieldGenerator)
        {
            _playingFieldGenerator = playingFieldGenerator;
        }

        private void Awake()
        {
            _gameModel = new GameModel();
        }

        private void Start()
        {
            GenerateGameObjects();

            StartCoroutine(GameTickCoroutine());
        }

        private IEnumerator GameTickCoroutine()
        {
            yield return new WaitForSeconds(_gameModel.SecondsBetweenTicks);
        }

        private void GenerateGameObjects()
        {
            var playingField = _playingFieldGenerator.Generate(
                _gameModel.PlayingFieldWidth,
                _gameModel.PlayingFieldHeight,
                _playingFieldPrefab,
                _cellPrefab);
        }
    }
}