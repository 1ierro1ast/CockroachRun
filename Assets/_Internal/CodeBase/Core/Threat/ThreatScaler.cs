using System;
using _Internal.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace _Internal.CodeBase.Core.Threat
{
    public class ThreatScaler : MonoBehaviour
    {
        [SerializeField] private float _radius;
        private Transform _view;
        public float Radius => _radius;
        
        private IInputService _inputService;

        private void Awake()
        {
            _view = transform.GetChild(0);
        }

        public void SetInputService(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.MouseWheelScrolledUp += InputServiceOnMouseWheelScrolledUp;
            _inputService.MouseWheelScrolledDown += InputServiceOnMouseWheelScrolledDown;
        }

        private void OnDestroy()
        {
            _inputService.MouseWheelScrolledUp -= InputServiceOnMouseWheelScrolledUp;
            _inputService.MouseWheelScrolledDown -= InputServiceOnMouseWheelScrolledDown;
        }

        private void InputServiceOnMouseWheelScrolledDown()
        {
            _radius -= 0.1f;
            UpdateViewSize();
        }

        private void InputServiceOnMouseWheelScrolledUp()
        {
            _radius += 0.1f;
            UpdateViewSize();
        }

        private void UpdateViewSize()
        {
            _view.localScale = new Vector3(_radius, _radius, _radius);
        }
    }
}