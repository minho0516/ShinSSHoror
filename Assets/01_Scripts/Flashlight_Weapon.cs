using UnityEngine;

public class Flashlight_Weapon : Weapon
{
    [SerializeField] private GameObject flashLightObj;
    private bool isFlashOn = false;
    public override void Shoot()
    {
        isFlashOn = !isFlashOn;
        flashLightObj.SetActive(isFlashOn);

        Debug.Log("ÇÃ·¡½Ãµþ°¢");
    }
}
