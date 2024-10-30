using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiChuyenBo : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private Animator animator;

    public GameObject panelStartGame;
    public GameObject panelKetThuc;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Hiển thị panel start game trong 3 giây khi bắt đầu
        StartCoroutine(ShowPanel(panelStartGame, 3f));
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        animator.SetBool("isRunning", moveInput != 0);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NenDat"))
        {
            animator.SetBool("isJump", false);
        }

        if (collision.gameObject.CompareTag("Deadzone"))
        {
            ReloadGame();
        }

        if (collision.gameObject.CompareTag("KetThuc"))
        {
            StartCoroutine(ShowPanel(panelKetThuc, 3f, "Man1"));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void ReloadGame()
    {
        SceneManager.LoadScene("ManDuaBo");
    }

    private IEnumerator ShowPanel(GameObject panel, float duration, string sceneToLoad = "")
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(duration);
        panel.SetActive(false);

        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
