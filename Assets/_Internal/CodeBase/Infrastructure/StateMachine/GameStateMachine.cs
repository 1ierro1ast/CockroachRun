﻿using System;
using System.Collections.Generic;
using _Internal.CodeBase.Core.Ui;
using _Internal.CodeBase.Infrastructure.Services;
using _Internal.CodeBase.Infrastructure.Services.Factories;
using _Internal.CodeBase.Infrastructure.StateMachine.States;

namespace _Internal.CodeBase.Infrastructure.StateMachine
{
    public class GameStateMachine : BaseStateMachine
    {
        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain loadingCurtain, AllServices services,
            ICoroutineRunner coroutineRunner)
        {
            States = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services, coroutineRunner),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadingCurtain, 
                    services.Single<ILevelFactory>()),
                [typeof(GameplayState)] = new GameplayState(this, services.Single<IPopupFactory>()),
                [typeof(FinishState)] = new FinishState(this, services.Single<IPopupFactory>()),
            };
        }
    }
}