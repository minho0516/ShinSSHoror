using UnityEngine;

public class PlayerItemController : MonoBehaviour
{
    [SerializeField] private LayerMask itemLayer;
    private Item currentAimingItem = null;
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 3f);
    }
    public void CheckItemUseRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3f, itemLayer))
        {
            currentAimingItem = hit.transform.GetComponent<Item>();
        }
        else
        {
            currentAimingItem = null;
        }
    }

    public Item GetAimingItem()
    {
        return currentAimingItem;
    }
}
