using DG.Tweening;
using UnityEngine;

namespace Code
{
    public class DeliveryPoint : MonoBehaviour
    {
        public DeliveryIndicator DeliveryIndicator;
        public Transform deliveryPoint;
        private Package deliveredPackage;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (deliveredPackage != null)
            {
                return;
            }
            var packageController = col.GetComponent<PlayerPackageController>();
            if (packageController)
            {
                var package =  packageController.RemovePackage();
                package.SetPackageState(PackageState.Delivered);
                package.transform.DOMove(deliveryPoint.position, 0.5f);
                deliveredPackage = package;
                DeliveryIndicator.IncreaseDeliveryCount();
            }
        }
    }
}