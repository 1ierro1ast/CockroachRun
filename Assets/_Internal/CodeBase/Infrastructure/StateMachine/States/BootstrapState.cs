using _Internal.CodeBase.Infrastructure.Services;
using _Internal.CodeBase.Infrastructure.Services.AssetManagement;
using _Internal.CodeBase.Infrastructure.Services.Factories;

namespace _Internal.CodeBase.Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private const string BootSceneName = "BootScene";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;
        private readonly ICoroutineRunner _coroutineRunner;
        
        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices allServices,
            ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = allServices;
            _coroutineRunner = coroutineRunner;
            
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(BootSceneName, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>("GameScene");
        }

        private void RegisterServices()
        {
            RegisterInputService();
            RegisterAssetProvider();

            RegisterGameFactory();
            RegisterLevelFactory();
            RegisterPopupFactory();
        }

        private void RegisterInputService()
        {
            _services.RegisterSingle<IInputService>(new InputService());
        }

        private void RegisterAssetProvider()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
        }

        private void RegisterGameFactory()
        {
            _services.RegisterSingle<IGameFactory>(
                new GameFactory(_services.Single<IAssetProvider>()));
        }

        private void RegisterLevelFactory()
        {
            _services.RegisterSingle<ILevelFactory>(
                new LevelFactory(_services.Single<IAssetProvider>()));
        }

        private void RegisterPopupFactory()
        {
            _services.RegisterSingle<IPopupFactory>(
                new PopupFactory(_services.Single<IAssetProvider>()));
        }
    }
}