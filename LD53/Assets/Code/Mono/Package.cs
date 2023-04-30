using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Code
{
    public class Package : MonoBehaviour
    {
        [SerializeField] private PackageState _packageState;
        [SerializeField] private Rigidbody2D _rb;
        public bool shouldAddForce;

        public PackageState GetPackageState()
        {
            return _packageState;
        }

        public void SetPackageState(PackageState state)
        {
            _packageState = state;
            if (state == PackageState.Free)
            {
                if (_rb == null)
                {
                    _rb = gameObject.AddComponent<Rigidbody2D>();
                }
            }
            else
            {
                if (_rb != null)
                {
                    Destroy(_rb);
                }
            }
        }

        public void SetForce(Vector2 force)
        {
            _rb.AddForce(force, ForceMode2D.Impulse);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && shouldAddForce)
            {
                _rb.AddForce(
                    new Vector2(
                        UnityEngine.Random.Range(0f, 10f),
                        UnityEngine.Random.Range(0f, 10f)
                    )
                    , ForceMode2D.Impulse);
            }
        }
    }

    public enum PackageState
    {
        Free,
        Picked,
    }
}