using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private InputAction inputActionMove;
    private Vector2 movementVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputActionMove = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVector = inputActionMove.ReadValue<Vector2>();

    }

    void FixedUpdate()
    {
        rb.linearVelocity = movementVector * speed;
    }
}