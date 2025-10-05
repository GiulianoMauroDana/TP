using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody))]

public class playerMovment : MonoBehaviour
{
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask climbWall;
    private Rigidbody _rigibody;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int _score = 0;
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
        if (Physics.CheckSphere(transform.position,groundCheckRadius,climbWall)||Physics.Raycast(transform.position,Vector3.down,groundCheckRadius + 0.1f, groundLayer))
        {
            return true;
            
        }
        else { return false; }
    }

    private void HamdelJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) 
        {
            _rigibody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);   
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, groundCheckRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectible"))
        {
            _score += 1;
            UpdateUI();
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Enemy"))
        {            
            Destroy(gameObject);
        }
    }
    private void UpdateUI()
    {
        scoreText.text = _score.ToString();
    }
}
