using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    // Tham chiếu đến script Mask
    public Mask maskScript;
    public Text colorDisplayText; // Đảm bảo bạn đã kéo Text vào đây trong Inspector

    // Hàm này sẽ được gọi từ các nút màu
    public void SetRed()
    {
        SetColor(Color.red); // Gọi hàm SetColor với màu đỏ
    }

    public void SetGreen()
    {
        SetColor(Color.green); // Gọi hàm SetColor với màu xanh lá
    }

    public void SetBlue()
    {
        SetColor(Color.blue); // Gọi hàm SetColor với màu xanh dương
    }

    public void SetYellow()
    {
        SetColor(Color.yellow); // Gọi hàm SetColor với màu vàng
    }

    public void SetQuad()
    {
        SetColor(Color.cyan); // Gọi hàm SetColor với màu cyan
    }

    public void SetNoColor()
    {
        SetColor(new Color(0, 0, 0, 0)); // Thiết lập màu trong suốt
    }

    // Hàm thực hiện việc cập nhật màu cho Mask
    private void SetColor(Color color)
    {
        Debug.Log("Color selected: " + color); // In ra để kiểm tra
        if (maskScript != null)
        {
            maskScript.selectedColor = color; // Cập nhật màu cho Mask
            UpdateColorDisplay(color); // Cập nhật văn bản hiển thị màu
        }
        else
        {
            Debug.LogWarning("maskScript is not assigned!");
        }
    }

    private void UpdateColorDisplay(Color color)
    {
        // Cập nhật nội dung của Text
        if (colorDisplayText != null)
        {
            // Chuyển màu thành tên
            string colorName = ColorToString(color);
            colorDisplayText.text = "Màu hiện tại là: " + colorName;
        }
    }

    // Hàm chuyển đổi Color thành tên
    private string ColorToString(Color color)
    {
        if (color == Color.red) return "Đỏ";
        if (color == Color.green) return "Xanh lá";
        if (color == Color.blue) return "Xanh dương";
        if (color == Color.cyan) return "Xanh nhạt";
        if (color == Color.yellow) return "Vàng";
        if (color.a == 0) return "Không màu"; // Kiểm tra nếu là màu trong suốt
        return "Màu không xác định"; // Nếu không nhận diện được màu
    }
}
