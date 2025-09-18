using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private WeaponSystem shootingSystem;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private PlayerItemController itemController;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private WeaponSystem weaponSystem;

    void Update()
    {
        itemController.CheckItemUseRay();

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (itemController.GetAimingItem() != null)
                inventory.TryGetItem(itemController.GetAimingItem());
            else
                inventory.TryGetItem(null);
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            weaponSystem.ChangeWeaponInList();
        }

        movement.Movement();
        movement.Rotate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.InputJump();
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            movement.InputNosedive();
        }

        if(Input.GetMouseButtonDown(0))
        {
            shootingSystem.WeaponShoot();
            //UIManager.UpdateBulletText(shootingSystem.GetAmmoText());
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            shootingSystem.WeaponReload();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            movement.InputDash();
        }
    }
}
