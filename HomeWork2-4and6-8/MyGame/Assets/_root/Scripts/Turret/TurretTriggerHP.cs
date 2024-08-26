using Bullet;
using MineItem;
using UnityEngine;

namespace Turret
{
    public class TurretTriggerHP : MonoBehaviour, IBulletDamage, IMineExplosion
    {
        private Turret _turret;


        private void Start()
        {
            _turret = GetComponentInParent<Turret>();
        }


        public void Hit(int damage)
        {
            _turret.Hp = _turret.Hp - damage;
            Debug.Log($"{_turret.name} HP: {_turret.Hp}");
            DieTurret(_turret.Hp);
        }

        public void MineHit(int damage, float force, Vector3 position)
        {
            _turret.Hp = _turret.Hp - damage;
            Debug.Log($"{_turret.name} HP: {_turret.Hp}");
            DieTurret(_turret.Hp);
        }

        private void DieTurret(int hp)
        {
            if (hp <= 0)
                Destroy(gameObject);
        }
    }
}