using System;
using _Internal.CodeBase.Core.Threat;
using TMPro;
using UnityEngine;

namespace _Internal.CodeBase.Core.Ui
{
    public class RadiusView : MonoBehaviour
    {
        private TMP_Text _text;
        private ThreatScaler _threatScaler;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        public void Initialize(ThreatScaler threatThreatScaler)
        {
            _threatScaler = threatThreatScaler;
            
            _threatScaler.ThreatScaleUpdate += ThreatScalerOnThreatScaleUpdate;
            ThreatScalerOnThreatScaleUpdate(_threatScaler.Radius);
        }

        private void ThreatScalerOnThreatScaleUpdate(float scale)
        {
            _text.text = scale.ToString("0.0");
        }

        private void OnDestroy()
        {
            _threatScaler.ThreatScaleUpdate -= ThreatScalerOnThreatScaleUpdate;
        }
    }
}
