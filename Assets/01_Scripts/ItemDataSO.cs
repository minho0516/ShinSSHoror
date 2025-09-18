using UnityEngine;

public enum ItemType
{
    Weapon,
    Battery,
    IronOrb
}

[CreateAssetMenu(fileName = "New Item Data", menuName = "SO/Item Data")]
public class ItemDataSO : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;

    public ItemType itemType;

    public Weapon weaponObj;

    public string itemDescription;
}
