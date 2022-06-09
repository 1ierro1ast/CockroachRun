using _Internal.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace _Internal.CodeBase.Core.Threat
{
    [RequireComponent(typeof(ThreatMover))]
    public class Threat : MonoBehaviour
    {
        private IInputService _inputService;
        private ThreatMover _threatMover;

        public void Initialize(IInputService inputService)
        {
            _inputService = inputService;
            _threatMover = GetComponent<ThreatMover>();

            _threatMover.SetInputService(_inputService);
        }
    }
}