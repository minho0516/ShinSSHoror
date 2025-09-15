using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> slotList;

    private void Awake()
    {
        if(slotList != null)
        {
            slotList.Clear();
        }

        foreach(Transform child in transform)
        {
            InventorySlot slot = child.GetComponent<InventorySlot>();

            if (slot != null)
            {
                slotList.Add(slot);
            }
        }
    }

    public void TryGetItem(Item item)
    {
        if(item == null)
        {
            Debug.Log("No item to pick up");
            return;
        }

        Debug.Log(item.name);
        CheckNullItemSlot(item);
        Destroy(item.gameObject);
    }

    private void CheckNullItemSlot(Item item)
    {
        int idx = 0;

        foreach(InventorySlot slot in slotList)
        {
            idx++;
            if (slot.CheckPushItem(item) == true)
            {
                break;
            }
        }
    }
}
