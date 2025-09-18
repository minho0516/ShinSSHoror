using UnityEngine;

public class Item : MonoBehaviour, IItem
{
    [SerializeField] private ItemDataSO itemData;

    private void OnEnable()
    {
        if(itemData.itemType == ItemType.Weapon)
        {
            Weapon weapon = Instantiate(itemData.weaponObj, transform);
            weapon.transform.localPosition = new Vector3(0, 0.1f, 0);
        }
    }
    public ItemDataSO GetItemSO()
    {
        return itemData;
    }
}
