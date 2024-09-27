using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController karakterKontrol;

    public float hiz = 12f;  // Yürüyüþ hýzý
    public float kosuHizi = 18f;  // Koþma hýzý
    public float yercekimi = -9.81f;  // Yerçekimi kuvveti
    public float ziplamaYuksekligi = 3f;  // Zýplama yüksekliði

    public Transform zeminKontrol;  // Zemini kontrol eden nokta
    public float zeminMesafesi = 0.4f;  // Zemin mesafesi
    public LayerMask zeminKatmani;  // Zemin katmaný

    Vector3 hizVektoru;
    bool yerdeMi;
    bool doubleJump = false;  // Ýki kere zýplama durumu
    float yatay, dikey;

    void Update()
    {
        ZeminKontrol();    // Zemin üzerinde mi kontrolü
        HareketEt();       // Hareket ve koþu iþlevi
        Zýpla();           // Zýplama iþlevi
        YercekimiEtkisi(); // Yerçekimi iþlevi
    }

    void ZeminKontrol()
    {
        // Zemin kontrolü
        yerdeMi = Physics.CheckSphere(zeminKontrol.position, zeminMesafesi, zeminKatmani);

        if (yerdeMi && hizVektoru.y < 0)
        {
            hizVektoru.y = -2f;  // Yerde olduðumuzda dikey hýz sýfýrlanýr
            doubleJump = false;  // Yere deðerse tekrar çift zýplamaya izin verilir
        }
    }

    void HareketEt()
    {
        // Yatay ve dikey hareket girdileri
        yatay = Input.GetAxis("Horizontal");
        dikey = Input.GetAxis("Vertical");

        Vector3 hareket = transform.right * yatay + transform.forward * dikey;

        // Hareket hýzý koþma durumuna göre belirlenir
        float aktifHiz = DeparAt() ? kosuHizi : hiz;

        // Hareket ettir
        karakterKontrol.Move(hareket * aktifHiz * Time.deltaTime);
    }

    bool DeparAt()
    {
        // Koþma tuþuna basýldýðýnda hýz artýrýlýr
        return Input.GetKey(KeyCode.LeftShift);
    }

    void Zýpla()
    {
        // Zýplama kontrolü
        if (Input.GetButtonDown("Jump"))
        {
            if (yerdeMi)
            {
                hizVektoru.y = Mathf.Sqrt(ziplamaYuksekligi * -2f * yercekimi);  // Ýlk zýplama
            }
            else if (!doubleJump)
            {
                hizVektoru.y = Mathf.Sqrt(ziplamaYuksekligi * -2f * yercekimi);  // Ýkinci zýplama (çift zýplama)
                doubleJump = true;  // Çift zýplama yapýldý, tekrar yapýlmaz
            }
        }
    }

    void YercekimiEtkisi()
    {
        // Yerçekimi etkisi
        hizVektoru.y += yercekimi * Time.deltaTime;
        karakterKontrol.Move(hizVektoru * Time.deltaTime);
    }
}
