using System;
using UnityEngine;

namespace _Internal.CodeBase.Core
{
    public class Finish : MonoBehaviour
    {
        public event Action EndGameEvent;

        public void BroadcastFinish() => EndGameEvent?.Invoke();
    }
}