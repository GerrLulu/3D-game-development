using UnityEngine;

namespace Item
{
    public class Potion : MonoBehaviour
    {
        [SerializeField] private int _hp = 50;

        private Rigidbody _rb;


        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            IHeal obj;

            if (other.TryGetComponent<IHeal>(out obj))
            {
                if (obj != null)
                {
                    obj.Heal(_hp);
                    Destroy(gameObject);
                }
            }
        }
    }
}