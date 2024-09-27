using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float hassasiyet = 100f;  // Fare hassasiyeti
    public Transform player;  // Oyuncu gövdesini temsil eden Transform

    float x = 0f;  // X ekseni etrafýndaki döndürme

    void Start()
    {
        // Ýmleci kilitle
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mouse
        float mouseX = Input.GetAxis("Mouse X") * hassasiyet * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * hassasiyet * Time.deltaTime;

        // Oyuncu gövdesini Y ekseni etrafýnda döndür (yatay döndürme)
        player.Rotate(Vector3.up * mouseX);

        // Kamerayý X ekseni etrafýnda döndür (dikey döndürme)
        x -= mouseY;
        x = Mathf.Clamp(x, -90f, 90f);  // Tam dikey döndürmeyi önle

        transform.localRotation = Quaternion.Euler(x, 0f, 0f);
    }
}
