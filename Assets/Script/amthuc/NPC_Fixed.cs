using UnityEngine;

public class NPC_Fixed : MonoBehaviour
{
    public GameObject[] foodPanels; // Các panel đồ ăn
    public GameObject[] ingredientPanels; // Các panel nguyên liệu tương ứng
    private GameObject activeFoodPanel;
    private GameObject activeIngredientPanel;

    private bool hasReceivedFoodPanel = false; // Kiểm tra đã nhận panel đồ ăn chưa

    // Hiển thị panel đồ ăn ngẫu nhiên
    public void ShowRandomFoodPanel()
    {
        if (activeFoodPanel != null)
        {
            activeFoodPanel.SetActive(false); // Đóng panel đồ ăn trước đó nếu có
        }

        if (!hasReceivedFoodPanel) // Kiểm tra xem đã nhận panel đồ ăn chưa
        {
            int index = Random.Range(0, foodPanels.Length);
            activeFoodPanel = foodPanels[index];
            activeFoodPanel.SetActive(true);
            hasReceivedFoodPanel = true; // Đánh dấu là đã nhận panel đồ ăn
        }
    }

    // Đóng panel đồ ăn và hiển thị panel nguyên liệu tương ứng
    public void CloseFoodPanel()
    {
        if (activeFoodPanel != null)
        {
            activeFoodPanel.SetActive(false);

            // Hiển thị panel nguyên liệu tương ứng
            int foodIndex = System.Array.IndexOf(foodPanels, activeFoodPanel);
            if (foodIndex >= 0 && foodIndex < ingredientPanels.Length)
            {
                activeIngredientPanel = ingredientPanels[foodIndex];
                activeIngredientPanel.SetActive(true);
            }

            activeFoodPanel = null; // Xóa tham chiếu đến panel đồ ăn đang hiển thị
        }
    }

    private void OnMouseDown()
    {
        if (activeFoodPanel == null)
        {
            ShowRandomFoodPanel();
        }
    }

    // Phương thức này sẽ được gọi từ nút "Đóng" trên panel đồ ăn
    public void OnCloseButtonClicked()
    {
        CloseFoodPanel();
    }
}
