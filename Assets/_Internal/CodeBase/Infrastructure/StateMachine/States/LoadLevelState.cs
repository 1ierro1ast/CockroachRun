using _Internal.CodeBase.Core;
using _Internal.CodeBase.Core.Ui;
using _Internal.CodeBase.Infrastructure.Services.Factories;

namespace _Internal.CodeBase.Infrastructure.StateMachine.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly ILevelFactory _levelFactory;
        
        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, 
            LoadingCurtain loadingCurtain, ILevelFactory levelFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _levelFactory = levelFactory;
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
            var level = _levelFactory.CreateLevel(1);
            
            _gameStateMachine.Enter<GameplayState, Level>(level);
        }
    }
}