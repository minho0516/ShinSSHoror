using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler

{
    [SerializeField] private ItemDataSO currentItemDataSO;

    [SerializeField] private Image itemDescriptionPanel;
    [SerializeField] private TMP_Text itemDescripTXT;
    private int currentItemCount = 0;

    private TMP_Text itemCountTXT;
    private Image slotEnvImage;

    private void Awake()
    {
        currentItemDataSO = null;
        slotEnvImage = GetComponent<Image>();
        itemCountTXT = GetComponentInChildren<TMP_Text>();
    }

    private void PushItem(Item item)
    {

        Debug.Log(item);
        currentItemDataSO = item.GetItemSO();
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
        if(currentItemDataSO == null)
        {
            PushItem(item);
            return true;
        }
        else
        {
            if(currentItemDataSO.itemType == item.GetItemSO().itemType)
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

    public ItemDataSO PullItem()
    {
        if(currentItemDataSO == null)
        {
            Debug.Log("No item in this slot");
            return null;
        }
        else
        {
            return currentItemDataSO;
        }
    }

    public bool CheckCurrentItemIsNull()
    {
        return currentItemDataSO == null;
    }

    private void GetItemToSetSlot()
    {
        slotEnvImage.sprite = currentItemDataSO.itemIcon;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        string txt = null;
        if (currentItemDataSO == null)
        {
            txt = "비어있음 like 내마음";
        }
        else
        {
            txt = currentItemDataSO.itemDescription;
        }

        PlayerInventory.Instance.SetDescriptionPanel(txt);

        PlayerInventory.Instance.SetActiveDescPanel(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PlayerInventory.Instance.SetActiveDescPanel(false);
    }
}
