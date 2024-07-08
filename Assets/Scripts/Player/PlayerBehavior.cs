using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;    

    private void Update()
    {
        float moveDirection = GameManager.Instance.InputManager.Movement 
        * Time.deltaTime * moveSpeed;
        transform.Translate(moveDirection, 0, 0);
    }
}
