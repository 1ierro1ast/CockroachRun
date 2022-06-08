using _Internal.CodeBase.Core.Ui;
using _Internal.CodeBase.Infrastructure.Services;
using _Internal.CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;

namespace _Internal.CodeBase.Infrastructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain LoadingCurtain;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, LoadingCurtain, AllServices.Container);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
