using UnityEngine;

namespace _Internal.CodeBase.Core.Ui
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private RadiusView _radiusView;

        public RadiusView RadiusView => _radiusView;
    }
}
