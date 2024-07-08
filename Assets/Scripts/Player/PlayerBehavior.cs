using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float jumpForce = 5;

    private Rigidbody2D rigidbody;
    private IsGroundedChecker isGroundedChecker;

    private void Awake()
    {        
        rigidbody = GetComponent<Rigidbody2D>();
        isGroundedChecker = GetComponent<IsGroundedChecker>();
    }

    private void Start()
    {
        GameManager.Instance.InputManager.OnJump += HandleJump;
    }

    private void Update()
    {
        float moveDirection = GameManager.Instance.InputManager.Movement 
        * Time.deltaTime * moveSpeed;
        transform.Translate(moveDirection, 0, 0);
    }

    private void HandleJump()
    {
        if (isGroundedChecker.IsGrounded() == false) return;
        rigidbody.velocity += Vector2.up * jumpForce;
    }

}
