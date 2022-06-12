using UnityEngine;

namespace _Internal.CodeBase.Core.Ui
{
    public class Popup : MonoBehaviour
    {
        private Animator _body;
        private static readonly int OpenAnimation = Animator.StringToHash("Open");
        private static readonly int CloseAnimation = Animator.StringToHash("Close");

        private void Awake()
        {
            _body = transform.GetComponentInChildren<Animator>();
        }

        public void Open()
        {
            _body.SetTrigger(OpenAnimation);
        }

        public void Close()
        { 
            _body.SetTrigger(CloseAnimation);
        }
    }
}