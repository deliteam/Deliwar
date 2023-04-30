using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Code
{
    public class PackageContainer : MonoBehaviour
    {
        [SerializeField] private PackageContainerType _containerType;
        [SerializeField] private List<Transform> _referencePoints;

        public void ArrangePackages(List<Package> packages)
        {
            int referencePointCount = _referencePoints.Count; 
            for (var i = 0; i < referencePointCount; i++)
            {
                Transform referencePoint = _referencePoints[i];
                if (packages.Count <= i)
                {
                    Debug.LogWarning("Given package count exceeds!");
                    return;
                }
                packages[i].transform.SetParent(referencePoint);
                if (packages[i].transform.localPosition.magnitude > 0.1f)
                {
                    packages[i].transform.DOKill();
                    packages[i].transform.DOLocalMove(Vector3.zero, 0.5f);
                }
            }
        }
        
        public PackageContainerType GetPackageContainerType()
        {
            return _containerType;
        }
    }

    public enum PackageContainerType
    {
        OnePackage,
        TwoPackage,
        ThreeAndNinePackage,
        TenAndFourteenPackage,
        ManyPackage
    }
}