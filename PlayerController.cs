using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController karakterKontrol;

    public float hiz = 12f;  // Y�r�y�� h�z�
    public float kosuHizi = 18f;  // Ko�ma h�z�
    public float yercekimi = -9.81f;  // Yer�ekimi kuvveti
    public float ziplamaYuksekligi = 3f;  // Z�plama y�ksekli�i

    public Transform zeminKontrol;  // Zemini kontrol eden nokta
    public float zeminMesafesi = 0.4f;  // Zemin mesafesi
    public LayerMask zeminKatmani;  // Zemin katman�

    Vector3 hizVektoru;
    bool yerdeMi;
    bool doubleJump = false;  // �ki kere z�plama durumu
    float yatay, dikey;

    void Update()
    {
        ZeminKontrol();    // Zemin �zerinde mi kontrol�
        HareketEt();       // Hareket ve ko�u i�levi
        Z�pla();           // Z�plama i�levi
        YercekimiEtkisi(); // Yer�ekimi i�levi
    }

    void ZeminKontrol()
    {
        // Zemin kontrol�
        yerdeMi = Physics.CheckSphere(zeminKontrol.position, zeminMesafesi, zeminKatmani);

        if (yerdeMi && hizVektoru.y < 0)
        {
            hizVektoru.y = -2f;  // Yerde oldu�umuzda dikey h�z s�f�rlan�r
            doubleJump = false;  // Yere de�erse tekrar �ift z�plamaya izin verilir
        }
    }

    void HareketEt()
    {
        // Yatay ve dikey hareket girdileri
        yatay = Input.GetAxis("Horizontal");
        dikey = Input.GetAxis("Vertical");

        Vector3 hareket = transform.right * yatay + transform.forward * dikey;

        // Hareket h�z� ko�ma durumuna g�re belirlenir
        float aktifHiz = DeparAt() ? kosuHizi : hiz;

        // Hareket ettir
        karakterKontrol.Move(hareket * aktifHiz * Time.deltaTime);
    }

    bool DeparAt()
    {
        // Ko�ma tu�una bas�ld���nda h�z art�r�l�r
        return Input.GetKey(KeyCode.LeftShift);
    }

    void Z�pla()
    {
        // Z�plama kontrol�
        if (Input.GetButtonDown("Jump"))
        {
            if (yerdeMi)
            {
                hizVektoru.y = Mathf.Sqrt(ziplamaYuksekligi * -2f * yercekimi);  // �lk z�plama
            }
            else if (!doubleJump)
            {
                hizVektoru.y = Mathf.Sqrt(ziplamaYuksekligi * -2f * yercekimi);  // �kinci z�plama (�ift z�plama)
                doubleJump = true;  // �ift z�plama yap�ld�, tekrar yap�lmaz
            }
        }
    }

    void YercekimiEtkisi()
    {
        // Yer�ekimi etkisi
        hizVektoru.y += yercekimi * Time.deltaTime;
        karakterKontrol.Move(hizVektoru * Time.deltaTime);
    }
}
