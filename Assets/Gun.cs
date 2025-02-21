using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 100f;
    public int maxAmmo = 10;
    protected int currentAmmo;
    public Camera playerCamera;
    public GameObject hitEffect;
    public Transform shootPoint;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0)
        {
            Shoot();
            currentAmmo--;
        }
    }

    protected virtual void Shoot()
    {
        if (Physics.Raycast(shootPoint.position, playerCamera.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log("Hit: " + hit.collider.name);
            SpawnHitEffect(hit.point, Quaternion.LookRotation(hit.normal));
        }
    }

    protected void SpawnHitEffect(Vector3 position, Quaternion rotation)
    {
        if (hitEffect != null)
        {
            GameObject effect = Instantiate(hitEffect, position, rotation);
            Destroy(effect, 5f);
        }
    }
}