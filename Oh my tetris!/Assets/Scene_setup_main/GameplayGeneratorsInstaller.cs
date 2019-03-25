using Zenject;
using Assets.Gameplay;

namespace Assets.Installers
{
    public class GameplayGeneratorsInstaller : MonoInstaller<GameplayGeneratorsInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInstance(
                FindObjectOfType<PlayingFieldGenerator>()).AsSingle();
        }
    }
}