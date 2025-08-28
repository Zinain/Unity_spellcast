using UnityEngine;
using UnityEngine.InputSystem;

public class SpellUIManager : MonoBehaviour
{
    [SerializeField] private GameObject spellPanel;
    private bool isOpen = false;
    public InputActionAsset Input;

    private InputAction uiToggle;

    private void OnEnable()
    {
        Input.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        Input.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        uiToggle = Input.FindAction("SpellUI");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spellPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (uiToggle.WasPressedThisFrame())
        {
            UIToggle();
        }
    }

    private void UIToggle()
    {
        isOpen = !isOpen;
        spellPanel.SetActive(isOpen);

        Time.timeScale = isOpen ? 0f : 1f; // pause/unpause game
    }

    public void CloseUI()
    {
        isOpen = false;
        spellPanel.SetActive(false);
    }
}
