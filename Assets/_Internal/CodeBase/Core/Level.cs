using UnityEngine;

namespace _Internal.CodeBase.Core
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        public Transform StartPoint => _startPoint;
    }
}