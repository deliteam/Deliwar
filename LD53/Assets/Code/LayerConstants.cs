using UnityEngine;

namespace Code
{
    public static class LayerConstants
    {
        public static readonly int PackageLayerMask;
        public static readonly int GroundLayerMask;

        static LayerConstants()
        {
            PackageLayerMask = LayerMask.GetMask("Package");
            GroundLayerMask = LayerMask.GetMask("Ground");
        }
    }
}