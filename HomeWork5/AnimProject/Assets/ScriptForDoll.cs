using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForDoll : MonoBehaviour
{
    [SerializeField] private float waitTime = 30;

    private void Start()
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        GetComponent<Rigidbody>().isKinematic = false;

        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        GetComponent<Collider>().enabled = true;

        StartCoroutine(Doll(waitTime));
    }

    private IEnumerator Doll(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        GetComponent<Animator>().enabled = false;
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        GetComponent<Rigidbody>().isKinematic = true;

        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
        GetComponent<Collider>().enabled = false;
    }
}
