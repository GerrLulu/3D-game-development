using UnityEngine;

public class GranadSpawn : MonoBehaviour
{
    private bool isThrowGrenade;
    [SerializeField] GameObject grenadePrefub;
    private GameObject grenade;

    private void Awake()
    {
        isThrowGrenade = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
            isThrowGrenade = true;
    }

    private void LateUpdate()
    {
        if (isThrowGrenade == true)
            SpawnBullet();
    }

    private void SpawnBullet()
    {
        grenade = Instantiate(grenadePrefub, transform.position, transform.rotation);
        isThrowGrenade = false;
    }
}
