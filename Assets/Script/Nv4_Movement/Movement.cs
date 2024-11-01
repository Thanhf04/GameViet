using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool Run;
    private Animator animator;
    private Rigidbody2D r2d;
    private float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // run
        animator.SetBool("RunLeft", false);
        animator.SetBool("RunRight", false);
        animator.SetBool("RunTop", false);
        animator.SetBool("RunDown", false);
        Vector2 scale = transform.localScale;
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            animator.SetBool("RunRight", true);
            scale.x = 1;
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            animator.SetBool("RunLeft", true);
            scale.x = 1;
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            animator.SetBool("RunDown", true);
            scale.y = 1;
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            animator.SetBool("RunTop", true);
            scale.y = 1;
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        transform.localScale = scale;

    }
}
