using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    [SerializeField] private List<InventorySlot> slotList;

    [SerializeField] private TMP_Text descriptionTXT;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        //

        if (slotList != null)
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

        gameObject.SetActive(false);
    }

    public void TryGetItem(Item item)
    {
        if(item == null)
        {
            Debug.Log("No item to pick up");
            return;
        }

        ItemType itemType = item.GetItemSO().itemType;

        if (itemType == ItemType.Weapon)
        {
            Weapon weapon = Instantiate(item.GetItemSO().weaponObj);

            if(weapon != null) WeaponSystem.Instance.PushWeaponToList(weapon);
        }
        else
        {
            CheckNullItemSlot(item);
        }

        Debug.Log(item.name);
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

    public void SetDescriptionPanel(string txt)
    {
        descriptionTXT.text = txt;
    }

    public void SetActiveDescPanel(bool isActive)
    {
        descriptionTXT.gameObject.SetActive(isActive);
    }
}
