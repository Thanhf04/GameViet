// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Windows;
// public class PlayerMove : MonoBehaviour
// {
//     public float moveSpeed = 5f;
//     public Rigidbody2D rb;
//     public Animator ain;
//     // Lưu lại hướng di chuyển
//     public Vector3 movement;
//     private float x;
//     private float y;
//     private bool moving;
//     void Start()
//     {
//     rb = GetComponent<Rigidbody2D>();
//     }
//     void Update()
//     {
//         movement.x = Input.GetAxis("Horizontal");
//         movement.y = Input.GetAxis("Vertical"); 
//         transform.position += movement * moveSpeed * Time.deltaTime;

//         if(movement.x != 0){
//             if(movement.x > 0){
//                 transform.localScale = new Vector3(1,1,0);
//             }else{
//                 transform.localScale = new Vector3(-1,1,0);
//             }
//         }

//         // Animate();
//     }
//     // private void Animate(){
//     //     if(Input.magnitude > 0.1f || Input.magnitude < -0.1f){
//     //         moving = true;
//     //     }else{
//     //         moving = false;
//     //     }
//     //     if(moving){
//     //         ain.SetFloat("x",x);
//     //         ain.SetFloat("y",y);
//     //     }

//     //     ain.SetBool("Moving",moving);
//     // }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator ain;
    // Lưu lại hướng di chuyển
    public Vector3 movement;
    private float x;
    private float y;
    private bool moving;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ain = GetComponent<Animator>();
    }
    
    void Update()
    {
        movement.x = UnityEngine.Input.GetAxis("Horizontal");
        movement.y = UnityEngine.Input.GetAxis("Vertical"); 
        transform.position += movement * moveSpeed * Time.deltaTime;

        if(movement.x != 0){
            if(movement.x > 0){
                transform.localScale = new Vector3(1,1,0);
            }else{
                transform.localScale = new Vector3(-1,1,0);
            }
        }

        Animate();
    }
    
   private void Animate()
{
    if (movement.magnitude > 0.1f)
    {
        moving = true;
    }
    else
    {
        moving = false;
    }

    if (moving)
    {
        ain.SetFloat("x", movement.x);
        ain.SetFloat("y", movement.y);
    }

    ain.SetBool("Moving", moving);
}

}
