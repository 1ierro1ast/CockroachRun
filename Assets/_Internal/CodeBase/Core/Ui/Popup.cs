using UnityEngine;

namespace _Internal.CodeBase.Core.Ui
{
    public class Popup : MonoBehaviour
    {
        private GameObject _body;

        private void Awake()
        {
            _body = transform.GetChild(0).gameObject;
        }

        public void Open()
        {
            _body.SetActive(true);
        }

        public void Close()
        { 
            _body.SetActive(false);
        }
    }
}