using System.Collections.Generic;
using UnityEngine;

public class CraftingBox : MonoBehaviour
{
    [SerializeField] private List<BlueprintSO> blueprintList;

    public ItemDataSO TryGetMergeItem(ItemDataSO firstItem, ItemDataSO secondItem)
    {
        foreach (var blueprint in blueprintList)
        {
            if ((blueprint.firstItem == firstItem && blueprint.secondItem == secondItem) ||
                (blueprint.firstItem == secondItem && blueprint.secondItem == firstItem))
            {
                return blueprint.mergeItem;
            }
        }
        return null;
    }
}
