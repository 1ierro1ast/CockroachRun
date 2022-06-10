using System;
using System.Collections;
using UnityEngine;

namespace _Internal.CodeBase.Infrastructure.Services
{
    public class InputService : IInputService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        public event Action MouseWheelScrolledDown;
        public event Action MouseWheelScrolledUp;
        public Vector2 MousePosition => Input.mousePosition;

        public InputService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _coroutineRunner.StartCoroutine(HandleMouseWheelScrolling());
        }

        private IEnumerator HandleMouseWheelScrolling()
        {
            while (true)
            {
                if (GetMouseScrollUp())
                {
                    MouseWheelScrolledUp?.Invoke();
                }
                if (GetMouseScrollDown())
                {
                    MouseWheelScrolledDown?.Invoke();
                }
                yield return null;
            }
        }

        private bool GetMouseScrollDown()
        {
            return Input.mouseScrollDelta.y < 0;
        }

        private bool GetMouseScrollUp()
        {
            return Input.mouseScrollDelta.y > 0;
        }
    }
}