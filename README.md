# 🧠 AI Blog Platform

> BTK Akademi · .NET 6 · Yapay Zeka Destekli Blog Yönetim Sistemi

[![.NET](https://img.shields.io/badge/.NET-6.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC-512BD4?style=for-the-badge&logo=dotnet)](https://docs.microsoft.com/en-us/aspnet/core/)
[![Entity Framework](https://img.shields.io/badge/EF_Core-6.0-512BD4?style=for-the-badge&logo=nuget)](https://docs.microsoft.com/en-us/ef/core/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-Express-CC2927?style=for-the-badge&logo=microsoft-sql-server)](https://www.microsoft.com/en-us/sql-server/)
[![SignalR](https://img.shields.io/badge/SignalR-Real--Time-009900?style=for-the-badge)](https://docs.microsoft.com/en-us/aspnet/core/signalr/)
[![OpenAI](https://img.shields.io/badge/OpenAI-GPT--4o_mini-412991?style=for-the-badge&logo=openai)](https://openai.com/)
[![Gemini](https://img.shields.io/badge/Google-Gemini_2.5-4285F4?style=for-the-badge&logo=google)](https://ai.google.dev/)
[![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)](LICENSE)

---

## 📌 Proje Hakkında

**AI Blog Platform**, BTK Akademi eğitimi kapsamında geliştirilen; **ASP.NET Core 6 MVC + RESTful Web API** mimarisi üzerine inşa edilmiş, çoklu yapay zeka entegrasyonlarıyla donatılmış tam kapsamlı bir blog yönetim sistemidir.

Proje; **makale yazımından yorum moderasyonuna**, **metin-ses dönüşümünden çok dilli içerik üretimine**, **gerçek zamanlı sohbet asistanından haber aramasına** kadar her katmanda yapay zekayı aktif olarak kullanan modern bir içerik yönetim platformudur.

---

## 🏗️ Mimari Yapı

Proje, birbirinden bağımsız iki `ASP.NET Core 6` projesiyle yapılandırılmıştır:

| Proje | Rol | Port |
|---|---|---|
| `BtkAkademi-AI_BlogProject.WebApi` | REST API · Veri Katmanı | `https://localhost:7003` |
| `BtkAkademi-AI_BlogProject.WebUI` | MVC Frontend · Admin Paneli · AI Hub | `https://localhost:xxxx` |

```
BtkAkademi-AI_BlogProject/
│
├── BtkAkademi-AI_BlogProject.WebApi/
│   ├── Context/          → EF Core DbContext (IdentityDbContext)
│   ├── Controllers/      → 12 RESTful API Endpoint
│   ├── DTO's/            → 12 DTO Klasörü (Create, Update, Result, GetById)
│   ├── Entities/         → 11 Domain Modeli
│   ├── Mapping/          → AutoMapper Profilleri
│   └── Migrations/       → EF Core Code-First Migrations
│
└── BtkAkademi-AI_BlogProject.WebUI/
    ├── Areas/Admin/      → Admin Paneli (13 Controller, 13+ View Klasörü)
    ├── Controllers/      → 15 MVC Controller
    ├── Hubs/             → SignalR ChatHub (Streaming AI Chat)
    ├── Services/         → OpenAI Makale & Başlık Servisleri
    ├── ViewComponents/   → 7 Yeniden Kullanılabilir Bileşen
    ├── Views/            → 16 View Klasörü
    └── wwwroot/          → CSS, JS, Görseller, Şablonlar
```

---

## ✨ Özellikler

### 📝 İçerik Yönetimi

| Özellik | Açıklama |
|---|---|
| **Makale CRUD** | Tam kapsamlı oluşturma, güncelleme, silme ve listeleme |
| **Kategori Yönetimi** | Teknoloji, Politika, Seyahat ve daha fazlası |
| **Çoklu Görsel Desteği** | Her makale için 600x400, 1200x600, 800x800, 300x370 gibi farklı boyutlarda görsel |
| **Feature Slider** | Manşet olarak öne çıkarılacak makaleleri toggle ile işaretleme |
| **Trending Stories** | "Gündemin Konuları" bölümü için özel işaretleme sistemi |
| **Son Makale Pinleme** | Özel slot'a sabitlenebilen ana sayfa makalesi |
| **Alt Özellik Postları** | Sub-feature bölümü için ayrı görsel ve durum yönetimi |
| **İleri/Geri Navigasyon** | Makale detay sayfasında önceki/sonraki makaleye geçiş |
| **İlgili Makale Önerisi** | Aynı kategoriden 3 makale otomatik listeleme |
| **Yorum Sistemi** | Onay mekanizmalı, puanlama destekli kullanıcı yorumları |
| **Slider Carousel** | Dinamik ana sayfa slayt yönetimi |

---

### 🤖 Yapay Zeka Entegrasyonları

#### 1. 🧠 OpenAI GPT-4o-mini — Makale İçerik Üretici
Konu girerek saniyeler içinde SEO uyumlu, akademik ve samimi tonlu, minimum 1500 karakterlik makaleler üretin.

```
Konum   : Admin → Article → Create Article with AI
Model   : gpt-4o-mini | Temperature: 0.7 | Max Tokens: 1100
```

#### 2. 💡 OpenAI GPT-4o-mini — Makale Başlık Önericisi
Anahtar kelimelerinizi girerek ilgili 3 farklı SEO uyumlu başlık seçeneği alın.

```
Konum   : Admin → Article → Create Article Title with AI
Model   : gpt-4o-mini | Temperature: 0.7
```

#### 3. 💬 SignalR + OpenAI — Gerçek Zamanlı Akışlı AI Sohbet
Server-Sent Events (SSE) streaming ile token-bazlı gerçek zamanlı AI asistan. Konuşma geçmişi oturum boyunca hafızada tutulur.

```
Konum   : Admin → Chat
Hub     : /chathub | Model: gpt-4o-mini | stream: true | Temperature: 0.5
```

#### 4. 🌍 Google Gemini 2.5 Flash — Çok Dilli İçerik Lokalizasyonu
Türkçe makale başlığı ve içeriğini; İngilizce, Almanca, İtalyanca veya Fransızcaya doğal şekilde yerelleştirin. SEO meta açıklaması da otomatik üretilir.

```
Konum   : Admin → GeminiBlog → Create Blog with Gemini
Model   : gemini-2.5-flash | Desteklenen Diller: EN, DE, IT, FR
Çıktı   : title + content + metaDescription (JSON)
```

#### 5. 🔊 ElevenLabs — Metin Ses Dönüştürücü (TTS)
Blog içeriklerinizi veya herhangi bir metni gerçekçi yapay zeka sesiyle MP3 formatında dinleyin. Üretilen ses dosyaları `wwwroot/voices/` altında saklanır.

```
Konum   : Admin → ElevenLabs → Text to Speech (3 ayrı mod)
Model   : eleven_multilingual_v2 | Voice: Rachel
```

#### 6. ☠️ HuggingFace Llama 3.1 8B — Yorum Toksisite Analizi
Kullanıcı yorumlarını 6 boyutlu toksisite skorlaması ile analiz edin: `toxic`, `severe_toxic`, `obscene`, `threat`, `insult`, `identity_hate`.

```
Konum   : Admin → Toxicity → Check Toxicity
Model   : meta-llama/Llama-3.1-8B-Instruct (via HuggingFace Router)
Çıktı   : Her kategori için 0.0-1.0 arası skor + yüzdelik gösterim
```

#### 7. 🔍 Tavily AI — Akıllı Web Araması
Admin paneli içinden Tavily arama motoru ile gelişmiş web araması yapın, AI destekli özet cevaplar alın.

```
Konum   : Admin → Tavily → Search
Mod     : advanced | Max Results: 5 | include_answer: true
```

#### 8. 📧 OpenAI GPT-4o-mini — Otomatik E-posta Yanıtlayıcı
Gelen mesajların konusunu ve içeriğini girerek, otomatik dil algılayan ve aynı dilde profesyonel e-posta yanıtı oluşturun.

```
Konum   : Admin → CreateMail → Create Mail with AI
Model   : gpt-4o-mini | Otomatik dil algılama desteği
```

#### 9. 🎬 RapidAPI IMDB — Popüler Film Listesi
IMDB API entegrasyonu ile anlık popüler film listesini admin panelinden görüntüleyin.

```
Konum   : Admin → RapidAPI → Popular Movies List
API     : imdb236.p.rapidapi.com
```

---

### 👤 Kimlik Doğrulama & Kullanıcı Yönetimi

- **ASP.NET Core Identity** tabanlı kullanıcı sistemi
- Kullanıcı kaydı (`Register`) ve giriş (`Login`) sayfaları
- `AppUser` → Ad, Soyad, Ünvan, Açıklama, Profil Görseli alanları
- Kullanıcı-Makale ilişkisi (yazar profili sayfası)
- Kullanıcı-Yorum ilişkisi

### 📬 İletişim & E-posta

- İletişim formu yönetimi (Admin panelinden CRUD)
- **MailKit (SMTP/Gmail)** entegrasyonu ile gerçek e-posta gönderme
- Mesaj yönetim sistemi (inbox)
- AI destekli otomatik e-posta yanıtı oluşturma

### 📺 Trading Video Bölümü

- Embed video URL ile video yönetimi
- Kategori ve yazar ilişkisi
- Feature işaretleme (öne çıkan video)
- Admin paneli CRUD işlemleri

---

## 🗄️ Veritabanı Modeli

```
AppUser (IdentityUser)
 ├── Article[]       → Bir kullanıcının birden fazla makalesi
 ├── TradingVideo[]  → Bir kullanıcının birden fazla videosu
 └── Comment[]       → Bir kullanıcının birden fazla yorumu

Article
 ├── Category        → Kategori ilişkisi
 ├── Comment[]       → Makaleye ait yorumlar
 └── 10+ Görsel URL  → Farklı boyut/konum için optimize görseller

Comment
 ├── AppUser         → Yorum yapan kullanıcı
 ├── Article         → Yorum yapılan makale
 ├── IsConfirm       → Admin onay durumu
 └── Rating          → Kullanıcı puanı (decimal)
```

**DbSets:**
`Abouts` · `Articles` · `Categories` · `Contacts` · `Employees` · `TradingVideos` · `Comments` · `SliderCarousels` · `Messages` · `SocialMedias`

---

## 🔌 API Endpoint'leri

### Articles (`/api/Articles`)

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/api/Articles` | Tüm makaleler (Category + User ile) |
| `POST` | `/api/Articles` | Yeni makale oluştur |
| `PUT` | `/api/Articles` | Makale güncelle |
| `DELETE` | `/api/Articles?id=` | Makale sil |
| `GET` | `.../GetArticle?id=` | ID ile makale getir |
| `GET` | `.../GetArticlesFeatureSliderByTrue` | Slider makaleleri |
| `GET` | `.../GetTrendingStoriesArticles` | Trend makaleler |
| `GET` | `.../GetLastArticle` | Pinlenmiş son makale |
| `GET` | `.../GetLast4ArticlesWithCategory` | Son 4 makale |
| `GET` | `.../GetLast5ArticleByCategory` | Kategoriye göre son 5 |
| `GET` | `.../GetLastTechnologyArticle` | Son Teknoloji makalesi |
| `GET` | `.../GetLastPoliticArticle` | Son Politika makalesi |
| `GET` | `.../GetLastTravelArticle` | Son Seyahat makalesi |
| `GET` | `.../GetArticlesSubFeaturePostsStatusByTrue` | Alt özellik makaleleri |
| `GET` | `.../GetArticlesRelatedByCategory?id=` | İlgili makaleler |
| `GET` | `.../GetNextArticle?id=` | Sonraki makale |
| `GET` | `.../GetPreviousArticle?id=` | Önceki makale |
| `GET` | `.../ChangeIsFeatureSliderFromTrueToFalse?id=` | Slider toggle OFF |
| `GET` | `.../ChangeIsFeatureSliderFromFalseToTrue?id=` | Slider toggle ON |

Ayrıca: `Categories`, `Comments`, `Contacts`, `Messages`, `SliderCarousels`, `SocialMedia`, `TradingVideos`, `Users`, `Abouts`, `Logins`, `Registers`

---

## 🛠️ Kullanılan Teknolojiler

### Backend

| Teknoloji | Versiyon | Kullanım |
|---|---|---|
| ASP.NET Core | 6.0 | Web API + MVC Framework |
| Entity Framework Core | 6.0.36 | ORM & Code-First Migrations |
| ASP.NET Core Identity | 6.0.36 | Kimlik Doğrulama |
| AutoMapper | 13.0.1 | Entity ↔ DTO Dönüşümü |
| Swashbuckle (Swagger) | 6.5.0 | API Dokümantasyonu |
| Microsoft SQL Server | Express | Veritabanı |
| SignalR | 6.0 | Gerçek Zamanlı İletişim |
| MailKit | 4.17.0 | SMTP E-posta Gönderimi |
| Newtonsoft.Json | — | JSON İşleme |

### Yapay Zeka & Dış Servisler

| Servis | Model / API | Kullanım Alanı |
|---|---|---|
| OpenAI | `gpt-4o-mini` | Makale, Başlık, E-posta, Streaming Chat |
| Google Gemini | `gemini-2.5-flash` | Çok Dilli Blog Lokalizasyonu |
| ElevenLabs | `eleven_multilingual_v2` | Text-to-Speech (MP3) |
| HuggingFace | `meta-llama/Llama-3.1-8B-Instruct` | Yorum Toksisite Analizi |
| Tavily | Search API | AI Destekli Web Araması |
| RapidAPI | IMDB236 | Popüler Film Listesi |

---

## 🚀 Kurulum & Çalıştırma

### Gereksinimler

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio 2022 veya VS Code

### 1. Repository'yi Klonlayın

```bash
git clone https://github.com/kullanici-adi/BtkAkademi-AI_BlogProject.git
cd BtkAkademi-AI_BlogProject
```

### 2. Veritabanı Bağlantısını Ayarlayın

`BtkAkademi-AI_BlogProject.WebApi/Context/BlogIAContext.cs` dosyasındaki connection string'i kendi SQL Server instance'ınıza göre güncelleyin:

```csharp
optionsBuilder.UseSqlServer("Server=YOUR_SERVER; initial Catalog=BtkAkademiIABlogDb; integrated security=true;");
```

### 3. Migration Uygulayın

```bash
cd BtkAkademi-AI_BlogProject.WebApi
dotnet ef database update
```

### 4. API Anahtarlarını Yapılandırın

`BtkAkademi-AI_BlogProject.WebUI/appsettings.json` dosyasına ekleyin:

```json
{
  "OpenAI": {
    "ApiKey": "YOUR_OPENAI_API_KEY"
  },
  "RapidAPI": {
    "Key": "YOUR_RAPIDAPI_KEY"
  }
}
```

ElevenLabs, Tavily ve Gemini anahtarlarını ilgili controller dosyalarındaki `const` değişkenlere girin.

### 5. Projeleri Çalıştırın

```bash
# Terminal 1 - WebApi
cd BtkAkademi-AI_BlogProject.WebApi
dotnet run

# Terminal 2 - WebUI
cd BtkAkademi-AI_BlogProject.WebUI
dotnet run
```

Visual Studio kullanıyorsanız: **Properties → Multiple Startup Projects** ayarlayın, her iki projeyi `Start` olarak işaretleyin.

### 6. Swagger UI

```
https://localhost:7003/swagger
```

---

## 📁 Proje Yapısı — Detaylı

### WebUI Controller'ları

| Controller | Görev |
|---|---|
| `HomeController` | Ana sayfa |
| `ArticleController` | Makale detay sayfası |
| `AdminArticleController` | Makale CRUD + AI içerik/başlık üretimi |
| `AdminTradingVideoController` | Video CRUD |
| `CategoryController` | Kategoriye göre makale listeleme |
| `AuthorController` | Yazar profil sayfası |
| `LoginController` | Giriş ekranı |
| `RegisterController` | Kayıt ekranı |
| `UserController` | Kullanıcı profil yönetimi |
| `ContactController` | İletişim sayfası |
| `AboutUsController` | Hakkımızda sayfası |
| `ErrorPagesController` | 404 ve hata sayfaları |

### Admin Area Controller'ları

| Controller | Görev |
|---|---|
| `CommentController` | Yorum onaylama/reddetme/silme |
| `ContactController` | İletişim kayıtları yönetimi |
| `SliderCarouselController` | Slayt yönetimi |
| `SocialMediaController` | Sosyal medya linkleri |
| `MessageController` | Mesaj kutusu |
| `EmailController` | MailKit ile gerçek e-posta gönderme |
| `CreateMailController` | AI ile otomatik e-posta yanıtı |
| `GeminiBlogController` | Gemini ile çok dilli lokalizasyon |
| `ElevenLabsController` | 3 farklı TTS modu |
| `ToxicityController` | Llama ile yorum analizi |
| `TavilyController` | AI destekli web araması |
| `RapidAPIController` | IMDB popüler film listesi |
| `AdminChatController` | Gerçek zamanlı AI sohbet |

### ViewComponents

| Component | Görevi |
|---|---|
| `AdminLayoutComponents` | Admin panel genel düzeni |
| `ArticleDetailComponents` | Makale detay sayfası bileşenleri |
| `DefaultComponents` | Genel site bileşenleri |
| `LayoutComponents` | Ana layout bileşenleri |
| `SubFeatureComponents` | Alt özellik bölümü |
| `SecondSubFeatureComponents` | İkinci alt özellik bölümü |
| `TradingVideoComponents` | Video bölümü bileşenleri |

---

## ⚠️ Güvenlik Notları

> **Önemli:** Proje geliştirme aşamasında olduğundan bazı API anahtarları kaynak kodunda yer alabilir.
> Production ortamına taşımadan önce mutlaka yapın:
>
> - Tüm API anahtarlarını `appsettings.json` veya **User Secrets** / **Environment Variables**'a taşıyın
> - Kaynak kodunda hardcode edilmiş anahtarları kaldırın
> - Identity yetkilendirme middleware'ini tüm admin rotalarına uygulayın
> - HTTPS yönlendirmesinin aktif olduğunu doğrulayın

---

## 🗺️ Yol Haritası

- [ ] JWT tabanlı API kimlik doğrulama
- [ ] Admin paneli için rol bazlı yetkilendirme
- [ ] Görsel yükleme optimizasyonu (CDN desteği)
- [ ] Full-text makale arama
- [ ] Makale etiketleme sistemi
- [ ] Dark/Light tema geçişi
- [ ] Docker Compose yapılandırması

---

## 🤝 Katkı

Katkılar her zaman hoş karşılanır! Önce bir **Issue** açın, ardından **Pull Request** gönderin.

1. Fork edin
2. Feature branch oluşturun: `git checkout -b feature/amazing-feature`
3. Commit edin: `git commit -m 'feat: amazing feature eklendi'`
4. Push edin: `git push origin feature/amazing-feature`
5. Pull Request açın

---

## 📄 Lisans

Bu proje **MIT Lisansı** ile lisanslanmıştır. Detaylar için [LICENSE](LICENSE) dosyasına bakın.

---

*BTK Akademi Eğitimi Kapsamında Geliştirilmiştir — Yapay Zeka · .NET · Web Geliştirme*
