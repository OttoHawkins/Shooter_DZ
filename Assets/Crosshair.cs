using UnityEngine;
using UnityEngine.UI;
public class Crosshair : MonoBehaviour
{
    [SerializeField] private Image crosshairImage;
    [SerializeField] private Camera playerCamera;

    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            crosshairImage.transform.position = Camera.main.WorldToScreenPoint(hit.point);
        }
    }
}