using Zenject;
using Assets.Utils;

namespace Assets.Installers
{
    public class UtilsInstaller : MonoInstaller<UtilsInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInstance(
                FindObjectOfType<SceneLoaderBehaviour>()).AsSingle();

            Container.BindInstance(
                FindObjectOfType<AnimationsLoaderBehaviour>()).AsSingle();
        }
    }
}