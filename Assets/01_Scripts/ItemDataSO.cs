using UnityEngine;

public enum ItemType
{
    Battery,
    IronOrb
}
[CreateAssetMenu(fileName = "New Item Data", menuName = "SO/Item Data")]
public class ItemDataSO : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;

    public ItemType type;
}
