using UnityEngine;
using UnityEngine.UI;

namespace _Internal.CodeBase.Core.Ui
{
    public class FinishPopup : Popup
    {
        [SerializeField] private Button _tryAgainButton;
        
        public Button TryAgainButton => _tryAgainButton;
    }
}