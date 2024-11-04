using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float startX, endX; // Giới hạn cho trục X
    public float topY, downY;   // Giới hạn cho trục Y

    private void Update()
    {
        // Lấy vị trí x và y của player
        var xPlayer = player.transform.position.x;
        var yPlayer = player.transform.position.y;

        // Xử lý giới hạn cho trục X
        float xCam = transform.position.x;
        if (xPlayer > startX && xPlayer < endX)
        {
            xCam = xPlayer;
        }
        else
        {
            if (xPlayer < startX)
                xCam = startX;
            if (xPlayer > endX)
                xCam = endX;
        }

        // Xử lý giới hạn cho trục Y
        float yCam = transform.position.y;
        if (yPlayer > downY && yPlayer < topY)
        {
            yCam = yPlayer;
        }
        else
        {
            if (yPlayer < downY)
                yCam = downY;
            if (yPlayer > topY)
                yCam = topY;
        }

        // Cập nhật vị trí camera
        transform.position = new Vector3(xCam, yCam, transform.position.z);
    }
}
