using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image SettingPanel;
    public Image inventoryPanel;
    public Slider FovSlider;
    public Camera PlayerCamera;

    private bool isPanelOpen = false;
    private bool isOpenInventoryPanel = false;

    public float MinFovValue = 60f;
    public float MaxFovValue = 120f;

    private float calcuratedValue = 0;

    [SerializeField] private TMP_Text bulletText;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        calcuratedValue = MaxFovValue - MinFovValue;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettingPanel();
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventoryPanel();
        }

        PlayerCamera.fieldOfView = MinFovValue + (calcuratedValue * FovSlider.value);
    }

    private void ToggleInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(isOpenInventoryPanel);
        isOpenInventoryPanel = !isOpenInventoryPanel;
    }
private void ToggleSettingPanel()
    {
        isPanelOpen = !isPanelOpen;
        SettingPanel.gameObject.SetActive(isPanelOpen);

        if(isPanelOpen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void UpdateBulletText(string txt)
    {
        bulletText.text = txt;
    }

    
}
