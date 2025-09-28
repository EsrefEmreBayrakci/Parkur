# Parkour Game / Parkur Oyunu
<img width="1370" height="822" alt="Ekran görüntüsü 2025-09-29 005358" src="https://github.com/user-attachments/assets/847da2eb-97db-4717-9a9b-aaf8be9d3788" />
<img width="1918" height="1079" alt="Ekran görüntüsü 2025-09-29 005627" src="https://github.com/user-attachments/assets/bb0017bc-bef4-4c9f-866c-c1421246752b" />



A 3D parkour game developed in Unity with obstacle courses, health system, and various interactive elements.

Unity ile geliştirilmiş, engel parkurları, sağlık sistemi ve çeşitli etkileşimli öğeler içeren 3D parkur oyunu.

## Features / Özellikler

### Gameplay / Oynanış
- **3D Character Movement** / **3D Karakter Hareketi**: Smooth movement with WASD/Arrow keys
- **Jumping System** / **Zıplama Sistemi**: Dynamic jumping with ground detection
- **Obstacle Course** / **Engel Parkuru**: Various obstacles and challenges
- **Health System** / **Sağlık Sistemi**: Health bar with damage and healing mechanics
- **Trampoline Mechanics** / **Trambolin Mekaniği**: Special jumping platforms
- **Game Over System** / **Oyun Bitişi Sistemi**: Fall detection and health-based game over

### UI Features / Arayüz Özellikleri
- **Health Bar** / **Sağlık Çubuğu**: Visual health indicator
- **Pause Menu** / **Duraklatma Menüsü**: ESC key to pause/resume
- **Game Over Screen** / **Oyun Bitişi Ekranı**: Restart and quit options
- **Visual Feedback** / **Görsel Geri Bildirim**: Color changes on damage

### Interactive Elements / Etkileşimli Öğeler
- **Obstacles** / **Engeller**: Damage-dealing obstacles
- **Healing Items** / **İyileştirme Öğeleri**: Health restoration items
- **Trampolines** / **Trambolinler**: Enhanced jumping platforms
- **Finish Line** / **Bitiş Çizgisi**: Level completion trigger

## Controls / Kontroller

| Key / Tuş | Action / Aksiyon |
|-----------|------------------|
| WASD / Arrow Keys | Move / Hareket |
| Space | Jump / Zıpla |
| ESC | Pause Menu / Duraklatma Menüsü |

## Technical Details / Teknik Detaylar

### Unity Version / Unity Sürümü
- Unity 2022.3 LTS or later / Unity 2022.3 LTS veya üzeri

### Scripts / Betikler
- `PlayerMovement.cs` - Character movement and jumping / Karakter hareketi ve zıplama
- `HealtController.cs` - Health system management / Sağlık sistemi yönetimi
- `engel_yonetimi.cs` - Obstacle damage system / Engel hasar sistemi
- `UIManager.cs` - User interface management / Kullanıcı arayüzü yönetimi
- `Finish.cs` - Level completion detection / Seviye tamamlama algılama
- `Trampoline.cs` - Trampoline mechanics / Trambolin mekaniği
- `BalanceBeam.cs` - Balance beam mechanics / Denge kirişi mekaniği
- `PendulumSwing.cs` - Pendulum obstacle mechanics / Sarkaç engel mekaniği

### Assets Used / Kullanılan Varlıklar
- **POLY STYLE - Platformer Starter Pack** - Main art assets / Ana sanat varlıkları
- **2D Casual UI** - User interface elements / Kullanıcı arayüzü öğeleri
- **TextMesh Pro** - Text rendering / Metin işleme
- **Unity Input System** - Input handling / Giriş işleme

## Installation / Kurulum

1. **Clone the repository** / **Depoyu klonlayın**
   ```bash
   git clone https://github.com/EsrefEmreBayrakci/Parkur
   ```

2. **Open in Unity** / **Unity'de açın**
   - Open Unity Hub / Unity Hub'ı açın
   - Click "Add" and select the project folder / "Ekle"ye tıklayın ve proje klasörünü seçin
   - Open the project / Projeyi açın
   💡 Alternatively: If you have downloaded the built version, you can run the Parkur.exe file inside the Parkur folder to play the game directly. Unity installation is not required.
   💡 Alternatif olarak: Derlenmiş sürümü indirdiyseniz, Parkur klasöründeki Parkur.exe dosyasını çalıştırarak oyunu doğrudan oynayabilirsiniz. Unity kurmanıza gerek yoktur.

3. **Open the scene** / **Sahneyi açın**
   - Navigate to `Assets/Scenes/testScene.unity` / `Assets/Scenes/testScene.unity` dosyasına gidin
   - Double-click to open / Açmak için çift tıklayın

4. **Play the game** / **Oyunu oynayın**
   - Press the Play button in Unity / Unity'de Oynat butonuna basın

## Game Structure / Oyun Yapısı

### Scenes / Sahne
- `testScene.unity` - Main game scene / Ana oyun sahnesi

### Scripts Organization / Betik Organizasyonu
```
Assets/Scripts/
├── PlayerMovement.cs      # Character control / Karakter kontrolü
├── HealtController.cs     # Health system / Sağlık sistemi
├── engel_yonetimi.cs      # Obstacle management / Engel yönetimi
├── UIManager.cs           # UI management / Arayüz yönetimi
├── Finish.cs              # Level completion / Seviye tamamlama
├── Trampoline.cs          # Trampoline mechanics / Trambolin mekaniği
├── BalanceBeam.cs         # Balance mechanics / Denge mekaniği
├── PendulumSwing.cs       # Pendulum mechanics / Sarkaç mekaniği
└── ...                    # Other interactive elements / Diğer etkileşimli öğeler
```

## Gameplay Tips / Oynanış İpuçları

### For Players / Oyuncular İçin
- **Watch your health** / **Sağlığınızı takip edin**: Avoid obstacles to prevent damage / Hasar almamak için engellerden kaçının
- **Use trampolines** / **Trambolinleri kullanın**: They provide extra jump height / Ekstra zıplama yüksekliği sağlarlar
- **Time your jumps** / **Zıplamalarınızı zamanlayın**: Some obstacles require precise timing / Bazı engeller hassas zamanlama gerektirir
- **Look for healing items** / **İyileştirme öğelerini arayın**: Keep your health up / Sağlığınızı yüksek tutun


