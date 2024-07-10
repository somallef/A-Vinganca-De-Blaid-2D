using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;
    private IsGroundedChecker groundedChecker;
    private Health playerHealth;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        groundedChecker = GetComponent<IsGroundedChecker>();
        playerHealth = GetComponent<Health>();

        playerHealth.OnHurt += PlayHurtAnim;
        playerHealth.OnDead += PlayDeadAnim;

        GameManager.Instance.InputManager.OnAttack += PlayAttackAnim;
    }

    private void PlayHurtAnim()
    {
        animator.SetTrigger("hurt");
    }

    private void PlayAttackAnim()
    {
        animator.SetTrigger("attack");
    }

    private void PlayDeadAnim()
    {
        animator.SetTrigger("dead");
    }

    void Update()
    {
        bool isMoving = GameManager.Instance.InputManager.Movement != 0;
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isJumping", !groundedChecker.IsGrounded());
    }
}
