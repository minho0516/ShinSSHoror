using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler

{
    [SerializeField] private Item currentItem;
    private int currentItemCount = 0;

    private TMP_Text itemCountTXT;
    private Image slotEnvImage;

    private void Awake()
    {
        currentItem = null;
        slotEnvImage = GetComponent<Image>();
        itemCountTXT = GetComponentInChildren<TMP_Text>();
    }

    private void PushItem(Item item)
    {
        currentItem = item;
        GetItemToSetSlot();
        RefreshItemCountText();
    }
    private void RefreshItemCountText()
    {
        currentItemCount++;
        itemCountTXT.text = currentItemCount.ToString();
    }

    public bool CheckPushItem(Item item)
    {
        if(currentItem == null)
        {
            PushItem(item);
            return true;
        }
        else
        {
            if(currentItem.GetItemSO().type == item.GetItemSO().type)
            {
                Debug.Log("Same type item in this slot");
                PushItem(item);
                return true;
            }
            else
            {
                Debug.Log("Different type item in this slot");
                return false;
            }
        }
    }

    public Item PullItem()
    {
        if(currentItem == null)
        {
            Debug.Log("No item in this slot");
            return null;
        }
        else
        {
            return currentItem;
        }
    }

    public bool CheckCurrentItemIsNull()
    {
        return currentItem == null;
    }

    private void GetItemToSetSlot()
    {
        slotEnvImage.sprite = currentItem.GetItemSO().itemIcon;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
