using UnityEngine;
using UnityEngine.InputSystem;

public class PriestWalk : MonoBehaviour
{
    public InputActionAsset Input;

    private InputAction move;

    private Vector2 move_horizontal;
    private Vector2 move_vertical;
    private Rigidbody2D rigidBody;

    [SerializeField] private float moveSpeed = 5;

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
        move = InputSystem.actions.FindAction("Move");

        rigidBody = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move_horizontal = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Walking();
    }

    private void Walking()
    {
        rigidBody.MovePosition(rigidBody.position + move_horizontal * moveSpeed * Time.deltaTime);
    }
}
