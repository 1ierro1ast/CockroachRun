using System;
using UnityEngine;

namespace _Internal.CodeBase.Infrastructure.Services
{
    public class InputService : IInputService
    {
        public event Action MouseWheelScrolledDown;
        public event Action MouseWheelScrolledUp;
        public Vector2 MousePosition => Input.mousePosition;
    }
}