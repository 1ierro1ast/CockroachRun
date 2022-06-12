using System;
using UnityEngine;

namespace _Internal.CodeBase.Core.Cockroach
{
    [RequireComponent(typeof(SphereCollider))]
    public class CockroachSensor : MonoBehaviour
    {
        public event Action<Threat.Threat> ThreatDetected;
        public event Action ReachedTheFinish;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.parent.TryGetComponent(out Threat.Threat threat))
            {
                ThreatDetected?.Invoke(threat);
            }

            if (other.TryGetComponent(out Finish finish))
            {
                ReachedTheFinish?.Invoke();
            }
        }
    }
}