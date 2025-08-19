using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontal;
    private float vertical;

    [SerializeField]private float moveSpeed = 5f;
    [SerializeField] private Vector2 input;
    [SerializeField] private Rigidbody2D rb;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        input = new Vector2(horizontal, vertical);
        input.Normalize();
        rb.linearVelocity = new Vector2(input.x * moveSpeed, input.y * moveSpeed);
    }
}

