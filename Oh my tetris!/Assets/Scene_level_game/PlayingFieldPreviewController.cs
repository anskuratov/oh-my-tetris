using UnityEngine;
using Assets.Gameplay;
using Zenject;

public class PlayingFieldPreviewController : MonoBehaviour
{
    [SerializeField]
    private GameObject _playingFieldPreviewPrefab;

    [SerializeField]
    private GameObject _cellPreviewPrefab;

    private PlayingFieldGenerator _playingFieldGenerator;

    [Inject]
    private void ZenjectInit(PlayingFieldGenerator playingFieldGenerator)
    {
        _playingFieldGenerator = playingFieldGenerator;
    }

    [ContextMenu("Generate")]
    public void Generate()
    {
        var newPlayingField = _playingFieldGenerator.Generate(
            5, 
            5, 
            _playingFieldPreviewPrefab, 
            _cellPreviewPrefab);

        newPlayingField.transform.SetParent(transform);
    }
}
