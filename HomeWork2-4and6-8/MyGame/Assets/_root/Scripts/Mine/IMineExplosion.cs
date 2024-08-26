using UnityEngine;

namespace MineItem
{
    public interface IMineExplosion
    {
        public void MineHit(int damage, float force, Vector3 position);
    }
}