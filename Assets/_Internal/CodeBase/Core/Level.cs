using UnityEngine;

namespace _Internal.CodeBase.Core
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Finish _finish;
        public Transform StartPoint => _startPoint;
        public Finish Finish => _finish;
    }
}