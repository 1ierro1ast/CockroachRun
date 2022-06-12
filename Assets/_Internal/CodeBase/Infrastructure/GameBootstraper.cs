using _Internal.CodeBase.Core.Ui;
using _Internal.CodeBase.Infrastructure.Services;
using _Internal.CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;

namespace _Internal.CodeBase.Infrastructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, _loadingCurtain, AllServices.Container);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}