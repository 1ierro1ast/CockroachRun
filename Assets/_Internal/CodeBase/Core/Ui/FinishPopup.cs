using UnityEngine;
using UnityEngine.UI;

namespace _Internal.CodeBase.Core.Ui
{
    public class FinishPopup : Popup
    {
        [field: SerializeField] public Button TryAgainButton { get; private set; }
    }
}