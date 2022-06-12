using UnityEngine;

namespace _Internal.CodeBase.Core
{
    public class Level : MonoBehaviour
    {
        [field: SerializeField] public Transform StartPoint { get; private set; }
        [field: SerializeField] public Finish Finish { get; private set; }
    }
}