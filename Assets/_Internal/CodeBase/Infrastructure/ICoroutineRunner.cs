using System.Collections;
using UnityEngine;

namespace _Internal.CodeBase.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine logicLoop);
    }
}