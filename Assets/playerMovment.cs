using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class playerMovment : MonoBehaviour
{
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody _rigibody;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 forceDireccion = new Vector3(moveHorizontal, 0f, moveVertical);
        _rigibody.AddForce(forceDireccion * moveForce);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckRadius + 0.1f, groundLayer);
    }

    private void HamdelJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded()) 
        {
            _rigibody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);   
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * (groundCheckRadius + 0.1f));
    }
}
