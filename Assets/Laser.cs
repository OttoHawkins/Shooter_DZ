using UnityEngine;

public class Laser : Gun
{
   [SerializeField] private LineRenderer laserLine;
    [SerializeField] private float laserDuration = 0.1f;

    protected override void Shoot()
    {
        if (Physics.Raycast(shootPoint.position, playerCamera.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log("Laser hit: " + hit.collider.name);
            SpawnHitEffect(hit.point, Quaternion.LookRotation(hit.normal));
            StartCoroutine(ShowLaserBeam(hit.point));
        }
    }

    private System.Collections.IEnumerator ShowLaserBeam(Vector3 hitPoint)
    {
        laserLine.SetPosition(0, shootPoint.position);
        laserLine.SetPosition(1, hitPoint);
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
