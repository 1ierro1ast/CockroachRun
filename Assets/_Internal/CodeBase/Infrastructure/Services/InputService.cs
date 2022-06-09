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
                Debug.Log(Input.mouseScrollDelta*10);
                if (Input.mouseScrollDelta.y > 0)
                {
                    Debug.Log(1);
                    MouseWheelScrolledUp?.Invoke();
                }
                if (Input.mouseScrollDelta.y < 0)
                {
                    MouseWheelScrolledDown?.Invoke();
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }
}