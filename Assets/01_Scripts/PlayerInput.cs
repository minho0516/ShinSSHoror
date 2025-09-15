using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private FlashlightSystem shootingSystem;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private PlayerItemController itemController;
    [SerializeField] private PlayerInventory inventory;

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
            shootingSystem.InputShoot();
            UIManager.UpdateBulletText(shootingSystem.GetAmmoText());
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            shootingSystem.InputReload();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            movement.InputDash();
        }
    }
}
