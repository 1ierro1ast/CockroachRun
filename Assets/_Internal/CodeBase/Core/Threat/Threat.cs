using _Internal.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace _Internal.CodeBase.Core.Threat
{
    [RequireComponent(typeof(ThreatMover))]
    [RequireComponent(typeof(ThreatScaler))]
    public class Threat : MonoBehaviour
    {
        private IInputService _inputService;
        private ThreatMover _threatMover;

        public ThreatScaler ThreatScaler { get; private set; }

        public void Initialize(IInputService inputService)
        {
            _inputService = inputService;
            _threatMover = GetComponent<ThreatMover>();
            ThreatScaler = GetComponent<ThreatScaler>();

            _threatMover.SetInputService(_inputService);
            ThreatScaler.SetInputService(inputService);
        }
    }
}