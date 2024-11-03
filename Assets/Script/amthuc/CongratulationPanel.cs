using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CongratulationPanel : MonoBehaviour
{
    public GameObject congratulationPanel; // Panel chúc mừng
    public bool isPlayerInZone = false; // Kiểm tra xem người chơi có trong vùng va chạm không

    void Update()
    {
        // Chỉ kiểm tra phím "F" khi người chơi đang trong vùng va chạm
        if (isPlayerInZone && Input.GetKeyDown(KeyCode.F))
        {
            ShowCongratulationPanel(); // Gọi phương thức để hiện panel
        }
    }

    private void ShowCongratulationPanel()
    {
        congratulationPanel.SetActive(true); // Hiện panel chúc mừng
        StartCoroutine(HideCongratulationPanelAfterDelay(2f)); // Tắt panel sau 2 giây
        SceneManager.LoadScene("Man1");
    }

    private IEnumerator HideCongratulationPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Đợi trong 2 giây
        congratulationPanel.SetActive(false); // Tắt panel chúc mừng
        
        
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
            // Đảm bảo tắt panel nếu người chơi ra khỏi vùng va chạm
            congratulationPanel.SetActive(false); 
        }
    }
}
