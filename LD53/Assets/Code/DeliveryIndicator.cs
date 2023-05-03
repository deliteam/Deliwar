using System;
using UnityEngine;

namespace Code
{
    public class DeliveryIndicator : MonoBehaviour
    {
        public static int GlobalDeliveryCount = 0;
        [SerializeField] private Camera _camera;
        [SerializeField] private RectTransform _canvas;
        [SerializeField] private Transform _deliveryPoint;
        [SerializeField] private RectTransform _indicator;

        private int deliveryCount = 0;

        private void Awake()
        {
            GlobalDeliveryCount = 0;
        }

        private void Update()
        {
            if (deliveryCount == 4)
            {
                _indicator.gameObject.SetActive(false);
                return;
            }
            float width = _canvas.GetComponent<RectTransform>().sizeDelta.x;
            Vector2 _screenPoint = _camera.WorldToScreenPoint(_deliveryPoint.transform.position);
            float deliveryPoint = Mathf.Clamp(_screenPoint.x, 0, Screen.width);
            _indicator.anchoredPosition = new Vector2(deliveryPoint / Screen.width * width - width /2f, 0);
        }

        public void IncreaseDeliveryCount()
        {
            deliveryCount++;
            GlobalDeliveryCount++;
        }
    }
}