using Bullet;
using MineItem;
using Player;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class Enemy : MonoBehaviour, IMineExplosion, IBulletDamage/*, TrapDamage*/
    {
        [SerializeField] private int _hp = 100;
        [SerializeField] private int _damage = 5;
        [SerializeField] private float _huntingDistance = 5f;
        [SerializeField] private float _atackDistance = 0.3f;
        [SerializeField] private float _speedWalk = 1;
        [SerializeField] private float _speedRun = 2;
        [SerializeField] private Transform[] _wayPoints;
        [SerializeField] private Transform _eyePosition;
        [SerializeField] private Protagonist _protagonist;

        private int m_CurrentWaypointIndex;
        private Ray _rayToPlayer;
        private Rigidbody _rb;
        private NavMeshAgent _agent;
        private Animator _animator;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _agent.SetDestination(_wayPoints[0].position);
        }

        private void FixedUpdate()
        {
            _animator.SetFloat("Speed", _agent.speed);

            RaycastHit hit;

            Vector3 direction = _protagonist.transform.position - _eyePosition.position;
            direction = new Vector3(direction.x, direction.y + 1.7f, direction.z);
            _rayToPlayer = new Ray(_eyePosition.position, direction);
            Physics.Raycast(_rayToPlayer, out hit);

            if (hit.collider != null)
            {
                if (_atackDistance <= hit.distance && hit.distance <= _huntingDistance)
                {
                    _agent.speed = _speedRun;
                    _agent.SetDestination(_protagonist.transform.position);
                    Debug.DrawRay(_eyePosition.position, direction, Color.red);
                }
                else if (0 < hit.distance && hit.distance < _atackDistance)
                {
                    _animator.SetTrigger("Attack");
                }
                else
                {
                    Patrol();
                    Debug.DrawRay(_eyePosition.position, direction, Color.green);
                }
            }
        }


        private void Patrol()
        {
            if (_agent.remainingDistance < _agent.stoppingDistance)
            {
                _agent.speed = _speedWalk;
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % _wayPoints.Length;
                _agent.SetDestination(_wayPoints[m_CurrentWaypointIndex].position);
            }
        }

        public void Hit(int damage)
        {
            _hp = _hp - damage;
            Debug.Log($"{gameObject.name} HP: {_hp}");
            DieEnemy(_hp);
        }

        public void MineHit(int damage, float force, Vector3 positionMine)
        {
            _hp = _hp - damage;
            Debug.Log($"{gameObject.name} HP: {_hp}");

            var positionImpulse = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            Vector3 direction = positionImpulse - positionMine;
            _rb.AddForce(direction.normalized * force, ForceMode.Impulse);

            DieEnemy(_hp);
        }

        private void Attack()
        {
            _protagonist.Hp -= _damage;
        }

        private void DieEnemy(int hp)
        {
            if (hp <= 0)
            {
                _animator.SetTrigger("Die");
                _agent.speed = 0;
                //Destroy(gameObject);
            }
        }

        //public void TrapHit(float damage)
        //{
        //    _hp = _hp - damage;
        //    if (_hp <= 0)
        //        gameObject.SetActive(false);
        //}
    }
}