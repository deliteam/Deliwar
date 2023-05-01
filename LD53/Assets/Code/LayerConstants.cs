using UnityEngine;

namespace Code
{
    public static class LayerConstants
    {
        public static readonly int PackageLayerMask;
        public static readonly int GroundLayerMask;
        public static readonly int EnemyLayerMask;
        public static readonly int PlayerLayerMask;

        static LayerConstants()
        {
            PackageLayerMask = LayerMask.GetMask("Package");
            GroundLayerMask = LayerMask.GetMask("Ground");
            EnemyLayerMask = LayerMask.GetMask("Enemy");
            PlayerLayerMask = LayerMask.GetMask("Player");
        }
    }
}