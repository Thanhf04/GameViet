using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public Texture2D originalImage; // Ảnh gốc chỉ chứa line art
    private Texture2D coloringImage; // Ảnh để tô màu

    public Color selectedColor = Color.red;
    private SpriteRenderer spriteRenderer;

    // Biến lưu số pixel đã tô màu và số lượng tối đa của khu vực cần tô
    private int filledPixelCount = 0;
    private int totalTargetPixels = 0;

    void Start()
    {
        // Khởi tạo texture từ ảnh gốc
        coloringImage = new Texture2D(originalImage.width, originalImage.height);
        coloringImage.SetPixels(originalImage.GetPixels());
        coloringImage.Apply();

        // Gán coloringImage vào SpriteRenderer của đối tượng
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Sprite.Create(coloringImage, new Rect(0, 0, coloringImage.width, coloringImage.height), new Vector2(0.5f, 0.5f));

        // Tính toán số lượng pixel cần tô màu
        foreach (Color pixelColor in coloringImage.GetPixels())
        {
            if (pixelColor != selectedColor && pixelColor.a > 0) // Chỉ tính các pixel không phải là trong suốt và chưa được tô
            {
                totalTargetPixels++;
            }
        }
    }

    void Update()
    {
        // Kiểm tra khi người dùng nhấn chuột trái
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Tính toán tọa độ trên texture từ vị trí điểm va chạm trong thế giới
                Vector2 localPoint = transform.InverseTransformPoint(hit.point); // Chuyển đổi điểm va chạm sang tọa độ local
                float pixelPerUnit = coloringImage.width / spriteRenderer.bounds.size.x; // Tính số pixel trên mỗi đơn vị của sprite
                int x = (int)((localPoint.x + spriteRenderer.bounds.extents.x) * pixelPerUnit);
                int y = (int)((localPoint.y + spriteRenderer.bounds.extents.y) * pixelPerUnit);

                // Lấy màu tại tọa độ (x, y) và tô màu
                Color targetColor = coloringImage.GetPixel(x, y);
                filledPixelCount = 0; // Reset bộ đếm pixel
                FloodFill(x, y, targetColor, selectedColor);
                coloringImage.Apply(); // Cập nhật Texture sau khi tô màu

                // Kiểm tra nếu toàn bộ vùng đã được tô màu thành công
                if (filledPixelCount >= totalTargetPixels)
                {
                    Debug.Log("Tô màu thành công toàn bộ khu vực!");
                }
            }
        }
    }

    private void FloodFill(int x, int y, Color targetColor, Color fillColor)
    {
        if (targetColor == fillColor) return;

        Queue<Vector2Int> pixels = new Queue<Vector2Int>();
        HashSet<Vector2Int> visited = new HashSet<Vector2Int>(); // Sử dụng tập hợp để lưu các pixel đã kiểm tra
        pixels.Enqueue(new Vector2Int(x, y));
        visited.Add(new Vector2Int(x, y));

        int maxPixels = 100000; // Giới hạn số pixel tối đa để tránh quá tải

        while (pixels.Count > 0)
        {
            Vector2Int pixel = pixels.Dequeue();
            int px = pixel.x;
            int py = pixel.y;

            // Kiểm tra giới hạn kích thước ảnh
            if (px < 0 || px >= coloringImage.width || py < 0 || py >= coloringImage.height)
                continue;

            if (coloringImage.GetPixel(px, py) == targetColor)
            {
                coloringImage.SetPixel(px, py, fillColor);
                filledPixelCount++; // Tăng số pixel đã tô màu

                if (pixels.Count < maxPixels)
                {
                    // Thêm các pixel lân cận nếu chúng chưa được kiểm tra
                    EnqueuePixel(pixels, visited, new Vector2Int(px + 1, py));
                    EnqueuePixel(pixels, visited, new Vector2Int(px - 1, py));
                    EnqueuePixel(pixels, visited, new Vector2Int(px, py + 1));
                    EnqueuePixel(pixels, visited, new Vector2Int(px, py - 1));
                }
                else
                {
                    Debug.LogWarning("Reached max flood fill limit. Fill is limited.");
                    break;
                }
            }
        }
    }

    // Hàm hỗ trợ để thêm pixel lân cận nếu chưa có trong tập hợp
    private void EnqueuePixel(Queue<Vector2Int> pixels, HashSet<Vector2Int> visited, Vector2Int pixel)
    {
        if (!visited.Contains(pixel))
        {
            pixels.Enqueue(pixel);
            visited.Add(pixel);
        }
    }
}
