using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private int pellets = 6;
    [SerializeField] private float spreadAngle = 10f;

    protected override void Shoot()
    {
        for (int i = 0; i < pellets; i++)
        {
            Vector3 direction = playerCamera.transform.forward;
            direction = Quaternion.Euler(Random.Range(-spreadAngle, spreadAngle), Random.Range(-spreadAngle, spreadAngle), 0) * direction;
            if (Physics.Raycast(shootPoint.position, direction, out RaycastHit hit, range))
            {
                Debug.Log("Shotgun hit: " + hit.collider.name);
                SpawnHitEffect(hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }
}