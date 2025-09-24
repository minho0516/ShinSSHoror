using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image SettingPanel;
    public Image inventoryPanel;
    public Image CraftingPanel;

    public Slider FovSlider;
    public Camera PlayerCamera;

    private bool isOpenInventoryPanel = false;

    public float MinFovValue = 60f;
    public float MaxFovValue = 120f;

    private float calcuratedValue = 0;

    [SerializeField] private TMP_Text bulletText;
    [SerializeField] private TMP_Text interactiveE;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        calcuratedValue = MaxFovValue - MinFovValue;

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsAllPanelIsClosed() == false)
            {
                TogglePanel(SettingPanel, true);
                Debug.Log("AllPanelIsClosed");
            }
            else
            {
                Debug.Log("Else");
                TryTurnOffPanel();
            }
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            isOpenInventoryPanel = !isOpenInventoryPanel;
            TogglePanel(inventoryPanel, isOpenInventoryPanel);
        }

        PlayerCamera.fieldOfView = MinFovValue + (calcuratedValue * FovSlider.value);
    }

    public bool IsPanelOpen() => SettingPanel.gameObject.activeSelf || isOpenInventoryPanel;

    private void TogglePanel(Image panel, bool isPanel)
    {
        panel.gameObject.SetActive(isPanel);

        if (isPanel)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void UpdateBulletText(string txt)
    {
        bulletText.text = txt;
    }

    public void SetInterac(bool isActive)
    {
        interactiveE.gameObject.SetActive(isActive);
    }

    public void CallSetCraftingPanel(bool isActive)
    {
        CraftingPanel.gameObject.SetActive(isActive);
    }

    public void TryTurnOffPanel()
    {
        if(SettingPanel.gameObject.activeSelf)
        {
            SettingPanel.gameObject.SetActive(false);
            return;
        }
        else if (inventoryPanel.gameObject.activeSelf)
        {
            inventoryPanel.gameObject.SetActive(false);
            return;
        }
        else if (CraftingPanel.gameObject.activeSelf)
        {
            CraftingPanel.gameObject.SetActive(false);
            return;
        }
    }

    private bool IsAllPanelIsClosed() => SettingPanel.gameObject.activeSelf || inventoryPanel.gameObject.activeSelf || CraftingPanel.gameObject.activeSelf;
}
