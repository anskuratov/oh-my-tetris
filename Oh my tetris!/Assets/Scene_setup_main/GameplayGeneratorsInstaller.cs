using Zenject;
using Assets.Gameplay;

public class GameplayGeneratorsInstaller : MonoInstaller<GameplayGeneratorsInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInstance(
            FindObjectOfType<PlayingFieldGenerator>()).AsSingle();
    }
}