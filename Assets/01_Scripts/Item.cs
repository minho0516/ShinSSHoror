using UnityEngine;

public class Item : MonoBehaviour, IItem
{
    [SerializeField] private ItemDataSO itemData;
    public ItemDataSO GetItemSO()
    {
        return itemData;
    }
}
