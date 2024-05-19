using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private float _hp = 50f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    /*private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<ForseHeal>();
        if (obj != null)
            obj.hpUp(_hp);
        Destroy(gameObject);
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            var obj = collision.collider.GetComponent<ForseHeal>();
            if (obj != null)
                obj.hpUp(_hp);
        }
        Destroy(gameObject);
    }
}
