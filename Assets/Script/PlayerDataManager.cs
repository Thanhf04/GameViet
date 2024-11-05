using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance; // Biến Singleton

    public Vector3 playerPosition; // Vị trí của Player

    private void Awake()
    {
        // Đảm bảo rằng chỉ có một instance của PlayerDataManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại đối tượng khi chuyển scene
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
