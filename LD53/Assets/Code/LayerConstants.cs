using UnityEngine;

namespace Code
{
    public static class LayerConstants
    {
        public static readonly int PackageLayerMask;

        static LayerConstants()
        {
            PackageLayerMask = LayerMask.GetMask("Package");
        }
    }
}