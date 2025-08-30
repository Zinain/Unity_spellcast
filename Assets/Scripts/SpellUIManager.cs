using UnityEngine;
using UnityEngine.InputSystem;

public class SpellUIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spellPanels;
    private int currentPanel = 0;
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
        HideAllPanels();
    }

    public void HideAllPanels()
    {
        foreach (var p in spellPanels)
        {
            p.SetActive(false);
        }
    }

    public void ShowPanel(int index)
    {
        HideAllPanels();
        spellPanels[index].SetActive(true);
        currentPanel = index;
    }

    public void NextPanel()
    {
        int next = currentPanel+1;
        if(next < spellPanels.Length)
        {
            ShowPanel(next);
        }
    }

    public void ResetUI()
    {
        HideAllPanels();
        currentPanel = 0;
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
        if (!isOpen)
        {
            isOpen = true;
            ShowPanel(0);
            Time.timeScale = isOpen ? 0f : 1f; // pause/unpause game
        }
        else
        {
            isOpen = false;
            ResetUI();
            Time.timeScale = isOpen ? 0f : 1f; // pause/unpause game
        }
    }

}
