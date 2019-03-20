using UnityEngine;
using Assets.Gameplay;
using Zenject;

public class PlayingFieldPreviewController : MonoBehaviour
{
    private PlayingFieldGenerator _playingFieldGenerator;

    [Inject]
    private void ZenjectInit(PlayingFieldGenerator playingFieldGenerator)
    {
        _playingFieldGenerator = playingFieldGenerator;
    }

    [ContextMenu("Generate")]
    public void Generate()
    {
        var newPlayingField = _playingFieldGenerator.Generate(5, 5);
        newPlayingField.transform.SetParent(transform);
    }
}
