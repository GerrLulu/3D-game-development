using UnityEngine;

public class Granade : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float forseThrow = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(transform.forward * forseThrow, ForceMode.Impulse);
    }
}
