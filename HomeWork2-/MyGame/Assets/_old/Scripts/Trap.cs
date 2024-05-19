using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float damage = 5;

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<TrapDamage>();
        if (obj != null)
            obj.TrapHit(damage);
    }
}
