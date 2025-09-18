using TMPro;
using UnityEngine;

public class PlayerItemController : MonoBehaviour
{
    [SerializeField] private LayerMask itemLayer;
    [SerializeField] private TMP_Text interactiveText;

    private bool isAimingItem = false;

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

            if (isAimingItem == false)
            {
                isAimingItem = true;
                interactiveText.gameObject.SetActive(true);
            }
        }
        else
        {
            currentAimingItem = null;

            if (isAimingItem == true)
            {
                isAimingItem = false;
                interactiveText.gameObject.SetActive(false);
            }
        }
    }

    public Item GetAimingItem()
    {
        return currentAimingItem;
    }
}
