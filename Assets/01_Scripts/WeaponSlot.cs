using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour
{
    private Outline outline;
    private Image image;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        image = GetComponent<Image>();
    }

    public void SetOutline(bool isActive)
    {
        outline.enabled = isActive;
    }

    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
