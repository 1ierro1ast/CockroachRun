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
            _stateMachine.Enter<LoadGameState, string>("GameScene");
        }

        private void RegisterServices()
        {
            RegisterInputService();
            RegisterAssetProvider();

            RegisterLevelFactory();
            RegisterGameComponentsFactory();
            RegisterGameBuilder();
            RegisterPopupFactory();
        }

        private void RegisterGameComponentsFactory()
        {
            _services.RegisterSingle<IGameComponentsFactory>(
                new GameComponentsFactory(_services.Single<IAssetProvider>()));
        }

        private void RegisterInputService()
        {
            _services.RegisterSingle<IInputService>(new InputService());
        }

        private void RegisterAssetProvider()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
        }

        private void RegisterGameBuilder()
        {
            _services.RegisterSingle<IGameBuilder>(
                new GameBuilder());
        }

        private void RegisterLevelFactory()
        {
            _services.RegisterSingle<ILevelFactory>(
                new LevelFactory(_services.Single<IAssetProvider>()));
        }

        private void RegisterPopupFactory()
        {
            _services.RegisterSingle<IUiFactory>(
                new UiFactory(_services.Single<IAssetProvider>()));
        }
    }
}