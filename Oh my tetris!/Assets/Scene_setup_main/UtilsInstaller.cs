using Zenject;

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