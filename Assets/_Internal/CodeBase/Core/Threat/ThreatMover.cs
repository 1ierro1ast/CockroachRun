using _Internal.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace _Internal.CodeBase.Core.Threat
{
    public class ThreatMover : MonoBehaviour
    {
        private IInputService _inputService;
        private Camera _camera;

        public void SetInputService(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_inputService == null) return;
            
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            transform.position = GetNewPosition();
        }

        private Vector3 GetNewPosition()
        {
            Vector3 newPosition = _camera.ScreenToWorldPoint(_inputService.MousePosition);
            newPosition.y = 0;
            return newPosition;
        }
    }
}