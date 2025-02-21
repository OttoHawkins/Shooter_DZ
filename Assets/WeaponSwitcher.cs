using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private Gun[] weapons;
     private int currentWeaponIndex = 0;

    private void Start()
    {
        SwitchWeapon(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchWeapon(2);
    }

    private void SwitchWeapon(int index)
    {
        if (index >= weapons.Length) return;
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == index);
        }
        currentWeaponIndex = index;
    }
}
