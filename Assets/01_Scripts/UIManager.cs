using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

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
            isPanelOpen = !isPanelOpen;
            TogglePanel(SettingPanel, isPanelOpen);
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            isOpenInventoryPanel = !isOpenInventoryPanel;
            TogglePanel(inventoryPanel, isOpenInventoryPanel);
        }

        PlayerCamera.fieldOfView = MinFovValue + (calcuratedValue * FovSlider.value);
    }

    public bool IsPanelOpen() => isPanelOpen || isOpenInventoryPanel;

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
}
