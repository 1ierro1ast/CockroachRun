using _Internal.CodeBase.Core;
using _Internal.CodeBase.Core.Ui;
using _Internal.CodeBase.Infrastructure.Services;
using _Internal.CodeBase.Infrastructure.Services.Factories;

namespace _Internal.CodeBase.Infrastructure.StateMachine.States
{
    public class LoadGameState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameBuilder _gameBuilder;
        private readonly ILevelFactory _levelFactory;
        private readonly IGameComponentsFactory _gameComponentsFactory;
        private readonly IInputService _inputService;
        private readonly IUiFactory _uiFactory;

        public LoadGameState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,
            LoadingCurtain loadingCurtain, ILevelFactory levelFactory, IGameBuilder gameBuilder,
            IGameComponentsFactory gameComponentsFactory, IInputService inputService, IUiFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _levelFactory = levelFactory;
            _gameBuilder = gameBuilder;
            _gameComponentsFactory = gameComponentsFactory;
            _inputService = inputService;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.LoadScene(sceneName, false, OnLoaded);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        private void OnLoaded()
        {
            var level = _gameBuilder.Build(_levelFactory, _gameComponentsFactory, _inputService, _uiFactory);
            _gameStateMachine.Enter<GameplayState, Level>(level);
        }
    }
}