using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class PlayerPackageController : MonoBehaviour
    {
        [SerializeField] private List<PackageContainer> _packageContainers;
        [SerializeField] private List<Package> _packages;
        private PackageContainer _currentPackageContainer;
        public float collectPackageRange = 10;

        private void Awake()
        {
            _currentPackageContainer = GetPackageContainer(_packages.Count);
            _currentPackageContainer.gameObject.SetActive(true);
        }

        private void Update()
        {
            CheckPackages();
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, collectPackageRange);
        }

        private void AddPackage(Package package)
        {
            if (_packages.Contains(package))
            {
                Debug.LogWarning("You are trying to add package that already added!");
                return;
            }
            
            _packages.Add(package);
            package.SetPackageState(PackageState.Picked);
            
            PackageContainer packageContainer = GetPackageContainer(_packages.Count);
            if (packageContainer != _currentPackageContainer)
            {
                _currentPackageContainer.gameObject.SetActive(false);
                packageContainer.gameObject.SetActive(true);
                _currentPackageContainer = packageContainer;
            }
            
            packageContainer.ArrangePackages(_packages);
        }

        private PackageContainer GetPackageContainer(int packageCount)
        {
            PackageContainer defaultContainer = _packageContainers[0];
            PackageContainer tempContainer = null;
            switch (packageCount)
            {
                case 1:
                    tempContainer = _packageContainers.Find((x) =>
                        x.GetPackageContainerType() == PackageContainerType.OnePackage);
                    if (tempContainer != null)
                    {
                        return tempContainer;
                    }
                    break;
                case 2:
                    tempContainer = _packageContainers.Find((x) =>
                        x.GetPackageContainerType() == PackageContainerType.TwoPackage);
                    if (tempContainer != null)
                    {
                        return tempContainer;
                    }
                    break;
                default:
                    tempContainer = _packageContainers.Find((x) =>
                        x.GetPackageContainerType() == PackageContainerType.ManyPackage);
                    if (tempContainer != null)
                    {
                        return tempContainer;
                    }
                    break;
            }

            return defaultContainer;
        }

        private void CheckPackages()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, collectPackageRange,
                LayerConstants.PackageLayerMask);
            if (colliders == null || colliders.Length == 0)
            {
                return;
            }

            foreach (var col in colliders)
            {
                Package package = col.GetComponent<Package>();
                if (package == null)
                {
                    Debug.LogWarning($"Package not found! {GetComponent<Collider>().gameObject.name}");
                    return;
                }

                if (package.GetPackageState() == PackageState.Free)
                {
                    AddPackage(package);
                }
            }
        }
    }
}