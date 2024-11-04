using TMPro; // Nhập không gian tên cho TextMeshPro
using UnityEngine;
using UnityEngine.UI;

public class IngredientTable : MonoBehaviour
{
    public GameObject ingredientPanel; // Panel chọn nguyên liệu
    public Button[] ingredientButtons; // Các nút nguyên liệu trên bàn
    public TextMeshProUGUI[] ingredientTexts; // Tên nguyên liệu trên công thức (TextMeshPro)
    public int[] ingredientIDs; // ID nguyên liệu tương ứng với mỗi nút

    public bool isPlayerInZone = false; // Kiểm tra xem người chơi có trong vùng va chạm không

    void Start()
    {
        // Gán sự kiện cho từng nút nguyên liệu
        for (int i = 0; i < ingredientButtons.Length; i++)
        {
            int index = i; // Đảm bảo index đúng trong closure
            ingredientButtons[i].onClick.AddListener(() => SelectIngredient(index));
        }
    }

    void Update()
    {
        // Mở panel nếu người chơi nhấn phím F khi ở trong vùng va chạm
        if (isPlayerInZone)
        {
            Debug.Log("Người chơi đang ở trong vùng tương tác.");
            if (Input.GetKeyDown(KeyCode.F))
            {
                ShowIngredientPanel();
            }
        }
    }

    // Hiển thị panel chọn nguyên liệu
    public void ShowIngredientPanel()
    {
        ingredientPanel.SetActive(true);
    }

    // Xử lý khi người chơi chọn một nguyên liệu
    private void SelectIngredient(int index)
    {
        if (index >= 0 && index < ingredientIDs.Length)
        {
            int ingredientID = ingredientIDs[index];
            if (ingredientID >= 0 && ingredientID < ingredientTexts.Length)
            {
                // Gạch tên nguyên liệu trong công thức
                // Thay đổi màu sắc và kích thước văn bản để làm nổi bật hơn
                ingredientTexts[ingredientID].text =
                    "<s><color=#FF0000><size=14>"
                    + ingredientTexts[ingredientID].text
                    + "</size></color></s>";
            }
        }
        // Đóng panel sau khi chọn
        ingredientPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Va chạm xảy ra với: " + other.gameObject.name);
        // Kiểm tra xem đối tượng va chạm có phải là người chơi không
        if (other.CompareTag("Player"))
        {
            Debug.Log("Người chơi vào vùng tương tác.");
            isPlayerInZone = true; // Đặt cờ người chơi ở trong vùng va chạm
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng ra khỏi vùng va chạm có phải là người chơi không
        if (other.CompareTag("Player"))
        {
            Debug.Log("Người chơi ra khỏi vùng tương tác.");
            isPlayerInZone = false; // Đặt cờ người chơi không còn ở trong vùng va chạm
            ingredientPanel.SetActive(false); // Đóng panel khi người chơi rời khỏi
        }
    }
}
