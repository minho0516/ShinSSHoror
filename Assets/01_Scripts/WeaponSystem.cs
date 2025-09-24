using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public static WeaponSystem Instance;

    [SerializeField] private Weapon CurrentWeapon;
    public List<Weapon> WeaponList;
    [SerializeField] private Transform slotParentTrm;
    private List<WeaponSlot> weaponSlotList;
    [SerializeField] private Transform weaponParentTrm;

    private int currentWeaponIndex = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if(weaponSlotList != null)
        {
            weaponSlotList.Clear();

            foreach (Transform child in slotParentTrm)
            {
                WeaponSlot slot = child.GetComponent<WeaponSlot>();
                if (slot != null)
                {
                    weaponSlotList.Add(slot);
                }
            }
        }
    }

    public void PushWeaponToList(Weapon weapon)
    {
        WeaponList.Add(weapon);

        if(CurrentWeapon == null)
        {
            CurrentWeapon = weapon;
            CurrentWeapon.transform.SetParent(weaponParentTrm);
            CurrentWeapon.transform.localPosition = weapon.posOffset;
            CurrentWeapon.transform.localEulerAngles = weapon.rotOffset;
        }
    }

    public void ChangeWeaponInList()
    {
        if(WeaponList.Count <= 1) return;

        currentWeaponIndex++;
        if (currentWeaponIndex >= WeaponList.Count) currentWeaponIndex = 0;

        Debug.Log(currentWeaponIndex);
    }

    public void WeaponShoot()
    {
        if (CurrentWeapon == null) return;
        CurrentWeapon.Shoot();
    }
    public void WeaponAiming()
    {
        if (CurrentWeapon == null) return;
        CurrentWeapon.Aiming(); //아직 키 바인딩 안해놓음.
    }
    public void WeaponReload()
    {
        if (CurrentWeapon == null) return;
        CurrentWeapon.Reload();
    }
}
