using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    // Lưu lại hướng di chuyển
    private Vector2 movement;
 
    private GameObject controls;
    private float valueX;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }
    void Update(){
        rb.velocity = movement * moveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context){
        movement = context.ReadValue<Vector2>();

        animator.SetBool("isWalking", true);

        if(context.canceled){
            animator.SetBool("isWalking", false);
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
        }
        movement = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", movement.x);
        animator.SetFloat("InputY", movement.y);
    }

    public void EnableControls(){
       GetComponent<PlayerInput>().enabled = true;
    }
    public void DisableControls(){
        GetComponent<PlayerInput>().enabled = false;
        valueX = 0;
    }
}
