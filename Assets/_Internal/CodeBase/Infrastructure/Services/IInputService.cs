using System;
using UnityEngine;

namespace _Internal.CodeBase.Infrastructure.Services
{
    public interface IInputService : IService
    {
        public event Action MouseWheelScrolledDown;
        public event Action MouseWheelScrolledUp;
        public Vector2 MousePosition { get; }
    }
}