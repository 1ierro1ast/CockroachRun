using System;
using _Internal.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace _Internal.CodeBase.Core.Threat
{
    public class ThreatScaler : MonoBehaviour
    {
        [field: SerializeField] public float Radius { get; private set; }
        private Transform _view;
        public event Action<float> ThreatScaleUpdate;
        
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
            Radius -= 0.1f;
            Radius = ValidateRadius();
            UpdateViewSize();
        }

        private void InputServiceOnMouseWheelScrolledUp()
        {
            Radius += 0.1f;
            Radius = ValidateRadius();
            UpdateViewSize();
        }
        
        private void UpdateViewSize()
        {
            _view.localScale = new Vector3(Radius, Radius, Radius);
            ThreatScaleUpdate?.Invoke(Radius);
        }

        private float ValidateRadius()
        {
            return Mathf.Clamp(Radius, 0.5f, 10f);
        }
    }
}