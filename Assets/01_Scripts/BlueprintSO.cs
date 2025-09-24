using UnityEngine;

[CreateAssetMenu(fileName = "bpData", menuName = "SO/BlueprintSO")]
public class BlueprintSO : ScriptableObject
{
    public ItemDataSO firstItem;
    public ItemDataSO secondItem;
    public ItemDataSO mergeItem;
}
