using UnityEngine;

public class AutoMovingNPC : MonoBehaviour
{
    public float speed = 2f;                // Tốc độ di chuyển của NPC
    public float changeDirectionTime = 2f;  // Thời gian để thay đổi hướng
    public Vector2 minBoundary;              // Giới hạn dưới của khu vực di chuyển
    public Vector2 maxBoundary;              // Giới hạn trên của khu vực di chuyển

    private Vector2 movementDirection;       // Hướng di chuyển hiện tại
    private float directionChangeTimer;      // Thời gian đếm ngược cho thay đổi hướng
    private Animator animator;               // Biến để truy cập Animator

    void Start()
    {
        animator = GetComponent<Animator>(); // Lấy thành phần Animator
        ChooseRandomDirection();              // Chọn hướng di chuyển ngẫu nhiên
        directionChangeTimer = changeDirectionTime; // Khởi tạo bộ đếm thời gian
    }

    void Update()
    {
        // Di chuyển NPC theo hướng hiện tại
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        // Giới hạn NPC trong khu vực
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBoundary.x, maxBoundary.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minBoundary.y, maxBoundary.y);
        transform.position = clampedPosition;

        // Cập nhật các parameter cho Animator
        UpdateAnimationParameters();

        // Cập nhật thời gian và thay đổi hướng khi hết thời gian
        directionChangeTimer -= Time.deltaTime;
        if (directionChangeTimer <= 0f)
        {
            ChooseRandomDirection();
            directionChangeTimer = changeDirectionTime;
        }
    }

    private void UpdateAnimationParameters()
    {
        // Cập nhật biến X và Y dựa trên hướng di chuyển
        animator.SetFloat("X", movementDirection.x);
        animator.SetFloat("Y", movementDirection.y);

        // Cập nhật biến XX và YY để xác định hoạt ảnh di chuyển
        animator.SetFloat("XX", movementDirection.y > 0 ? 1f : (movementDirection.y < 0 ? -1f : 0f));
        animator.SetFloat("YY", movementDirection.x > 0 ? 1f : (movementDirection.x < 0 ? -1f : 0f));

        // Cập nhật isWalking dựa trên hướng di chuyển
        animator.SetBool("isWalking", movementDirection != Vector2.zero);
    }

    private void ChooseRandomDirection()
    {
        // Chọn một hướng ngẫu nhiên
        float angle = Random.Range(0f, 360f);
        movementDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }
}
