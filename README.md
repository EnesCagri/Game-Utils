# FPS Platformer Game - Unity Project

Bu Unity projesi, temel bir **FPS Platformer** oyun mekaniklerini içermektedir. Proje, aşağıdaki temel bileşenleri kapsar:

## İçerik
1. **Karakter Kontrolcü**  
   Oyuncu karakterinin hareketlerini, zıplamasını ve koşmasını kontrol eder.
   - Yürüyüş, koşma ve zıplama gibi hareket dinamiklerini içerir.
   - Çift zıplama özelliği eklenmiştir.

2. **FPS Kamera Kontrolü**  
   Oyuncunun bakış açısını fare hareketleriyle kontrol eder.
   - Yatay (X) ve dikey (Y) eksenlerde dönüş yaparak oyuncunun etrafına bakmasını sağlar.

3. **Game Manager**  
   Oyun yönetimi fonksiyonlarını içerir.
   - Bölümü yeniden başlatma.
   - Bir sonraki bölümü yükleme.
   - Oyundan çıkış.

4. **Trigger ve Çarpışma Algılama**  
   Oyuncunun belirli nesnelerle etkileşimini kontrol eder.
   - Bitiriş noktasına ulaşınca bir sonraki bölümü yükler.
   - Engellere çarpıldığında oyunu sonlandırır.

## Kurulum
1. Unity ile projeyi açın.
2. **Scenes** klasöründeki sahnelerden birini çalıştırarak oyunu test edebilirsiniz.
3. Kendi sahnenize yukarıdaki bileşenleri ekleyerek özelleştirebilirsiniz.

## Kullanım
- **WASD**: Yön tuşları
- **Shift**: Koşma
- **Boşluk (Space)**: Zıplama (Çift zıplama desteklenir)
- **Fare**: Etrafta bakma

## Notlar
- Bu proje, FPS türünde bir platform oyunu oluşturmak için temel bir şablondur. Karakter kontrolü ve oyun yönetimi kolayca genişletilebilir veya özelleştirilebilir.
