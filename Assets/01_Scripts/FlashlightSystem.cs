using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    public int CurrentAmmo;

    [SerializeField] private Transform lightTrm;

    private void Awake()
    {
        //CurrentAmmo = maxAmmo;
    }

    public string GetAmmoText()
    {
        return $"{CurrentAmmo.ToString()} / {522}";
    }

    public void InputShoot()
    {
        if(CurrentAmmo > 0)
        {
            CurrentAmmo--;
            Shoot();
        }
    }

    private void Shoot()
    {
        //Instantiate(BulletParticle, transform.position, transform.rotation);
    }

    public void InputReload()
    {
        //CurrentAmmo = maxAmmo;
    }
}
