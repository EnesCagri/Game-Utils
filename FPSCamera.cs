using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float hassasiyet = 100f;  // Fare hassasiyeti
    public Transform player;  // Oyuncu g�vdesini temsil eden Transform

    float x = 0f;  // X ekseni etraf�ndaki d�nd�rme

    void Start()
    {
        // �mleci kilitle
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mouse
        float mouseX = Input.GetAxis("Mouse X") * hassasiyet * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * hassasiyet * Time.deltaTime;

        // Oyuncu g�vdesini Y ekseni etraf�nda d�nd�r (yatay d�nd�rme)
        player.Rotate(Vector3.up * mouseX);

        // Kameray� X ekseni etraf�nda d�nd�r (dikey d�nd�rme)
        x -= mouseY;
        x = Mathf.Clamp(x, -90f, 90f);  // Tam dikey d�nd�rmeyi �nle

        transform.localRotation = Quaternion.Euler(x, 0f, 0f);
    }
}
