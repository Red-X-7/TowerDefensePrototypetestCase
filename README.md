Proje Özeti
Bu proje, Unity üzerinde geliştirilen 3D ortamda 2D sprite’larla temsil edilen bir Tower Defence prototipidir. Oyun döngüsü, dalga tabanlı düşman akışı, otomatik saldırı sistemi ve FPS dostu optimizasyonlarla kurulmuştur. Tüm sistemler modüler ve test edilebilir şekilde tasarlanmıştır.

Kullanılan Oyun Motoru
- Unity 2022.3 LTS
- Render Pipeline: Built-in
- 2D Sprite Renderer + 3D World (Billboard mantığı)

Teknik Özellikler

Oyuncu Sistemi
- WASD ile serbest hareket
- Alan sınırlandırması (LateUpdate ile clamp)
- En yakındaki düşmana otomatik menzilli saldırı (ArcherProximity)
- Saldırı animasyonu tetikleme (PlayerController)
- Hasar alma sistemi (PlayerHealthController)

Düşman Sistemi
- Coroutine tabanlı yol takibi (EnemyPathBase)
- Prefab varyantları: Zombie, Lion, Spider, Horse, BossMonster
- Renk ve prefab ile hız/can/güç ayarlanabilir
- Yol sonuna ulaşınca oyuncuya hasar verir

Dalga Sistemi
- WaveManager ile otomatik dalga geçişi
- F tuşu ile sıradaki dalgayı erken çağırma
- Her 5. dalga boss içerir
- UI ile dalga ve geri sayım gösterimi

Spawn Sistemi
- EnemySpawner ile prefab varyantlarına göre spawn
- Her dalgada farklı düşmanlar aktif olur
- Spawn limitleri ve sahne içi kontrol optimize edilmiştir

Saldırı Sistemi
- ArcherProximity ile en yakın düşmana ok fırlatma
- ArrowHit ile çarpışma ve hasar uygulama
- Rigidbody tabanlı fiziksel yönlendirme

### Görev Tanımına Uyum

- Oyuncu WASD ile hareket eder, en yakındaki düşmana otomatik menzilli saldırı yapar.
- Düşmanlar coroutine tabanlı yol takibi ile sahnede ilerler.
- Dalga sistemi `WaveManager` ile kontrol edilir, F tuşu ile erken çağırma mümkündür.
- Her 5. dalga boss içerir, prefab varyantları ile düşman çeşitliliği,güç,can,hız ayrı ayrı ayarlanabilirlik sağlanmıştır.
- 1500 aktif düşman prefab’ında 30 FPS sabit alınmıştır(60fps seçeneği de mevcut) (GTX 1650 düşük ekran kartı test ortamı). not : Stress testi sahnesi ayrı bulunmaktadır.
- Başlangıç menüsü, sahne geçişi ve UI sistemleri entegredir.
- Ayrıca prefablar ve health sistemi unity assetsstore'dan alınmıştır

---

### Not

Bu proje sürecinde teknik planlama, kod organizasyonu ve README hazırlığı için Microsoft Copilot desteğinden faydalanılmıştır. Tüm kararlar ve uygulamalar tarafımdan değerlendirilmiş ve projeye entegre edilmiştir.


