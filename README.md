# RENTCAROTOMASYON

RENTCAROTOMASYON, C# Windows Forms ve Entity Framework kullanılarak geliştirilmiş bir araç kiralama otomasyonudur. Proje; müşteri kayıtlarını, araç kayıtlarını, araç kategorilerini, kiralama işlemlerini ve raporlamayı tek bir masaüstü uygulaması üzerinden yönetmek amacıyla hazırlanmıştır.

Bu proje Nesnesel Tasarım ve Programlama dersi final projesi olarak geliştirilmiştir.

## Projenin Amacı

Araç kiralama işletmelerinde müşteri, araç ve kiralama bilgilerinin düzenli şekilde tutulmasını sağlamak amaçlanmıştır. Uygulama sayesinde kullanıcılar müşterileri sisteme kaydedebilir, araç bilgilerini yönetebilir, uygun tarih aralığında kiralama işlemi oluşturabilir ve temel raporları görüntüleyebilir.

## Kullanılan Teknolojiler

- C#
- Windows Forms App (.NET Framework 4.7.2)
- Entity Framework 6.5.2
- Microsoft SQL Server
- LINQ sorguları
- Git ve GitHub

## Proje Modülleri

### 1. Giriş Ekranı

Uygulama ilk olarak kullanıcı giriş ekranı ile açılır. Kullanıcı adı ve şifre doğru girildiğinde ana müşteri işlemleri ekranına geçilir.

Varsayılan giriş bilgileri:

- Kullanıcı adı: `Berna Aldemir`
- Şifre: `3434`

### 2. Müşteri İşlemleri

Müşteri formunda müşterilere ait temel bilgiler yönetilir.

Yapılabilen işlemler:

- Müşteri listeleme
- Yeni müşteri ekleme
- Müşteri bilgilerini güncelleme
- Müşteri silme
- Müşteri bilgilerini DataGridView üzerinde görüntüleme

Tutulan müşteri bilgileri:

- Müşteri adı
- Müşteri soyadı
- E-posta
- Telefon

### 3. Araç İşlemleri

Araç işlemleri formunda kiralanacak araçların bilgileri tutulur.

Yapılabilen işlemler:

- Araç listeleme
- Yeni araç ekleme
- Araç bilgilerini güncelleme
- Araç silme
- Araç kategorisi seçme
- Kiralama kayıtlarında kullanılmış araçların silinmesini engelleme

Tutulan araç bilgileri:

- Araç adı
- Plaka
- Günlük ücret
- Kategori

### 4. Kiralama İşlemleri

Kiralama işlemleri formunda müşteri ve araç seçilerek kiralama kaydı oluşturulur.

Yapılabilen işlemler:

- Müşteri seçme
- Araç seçme
- Alış tarihi seçme
- Teslim tarihi seçme
- Toplam ücreti otomatik hesaplama
- Kiralama kaydı ekleme
- Kiralama kaydı silme
- Kiralama durumunu görüntüleme

Kiralama sırasında sistem teslim tarihi ile alış tarihi arasındaki gün sayısını hesaplar. Gün sayısı ile aracın günlük ücreti çarpılarak toplam ücret otomatik oluşturulur.

Ayrıca aynı araç aynı tarih aralığında daha önce kiralanmışsa sistem uyarı verir ve aynı araç için çakışan kiralama kaydı oluşturulmasını engeller.

### 5. Raporlar

Raporlar ekranında sistemdeki kiralama kayıtlarına göre temel raporlar görüntülenir.

Hazırlanan raporlar:

- Günlük gelir
- Aylık gelir
- Günlük toplam kiralama sayısı
- Aylık toplam kiralama sayısı
- En çok kiralanan araç

Bu raporlar LINQ sorguları ile veritabanındaki kiralama kayıtları üzerinden hesaplanır.

## Veritabanı Yapısı

Projede SQL Server üzerinde `RENTCAROTOMASYON` adlı veritabanı kullanılmaktadır.

Kullanılan tablolar:

### Table_customer

Müşteri bilgilerini tutar.

- `customer_ıd`
- `customer_name`
- `customer_surname`
- `customer_email`
- `customer_telephone`

### Table_car

Araç bilgilerini tutar.

- `car_ıd`
- `car_name`
- `car_plate`
- `car_dailyprice`
- `category_ıd`

### Table_category

Araç kategorilerini tutar.

- `category_ıd`
- `category_name`

### Table_customercar

Müşteri ve araç arasındaki kiralama ilişkisini tutar.

- `rental_ıd`
- `customer_ıd`
- `car_ıd`
- `rent_date`
- `return_date`
- `total_price`

## Nesnesel Yapı

Projede veritabanı tabloları C# sınıfları ile temsil edilmiştir.

Kullanılan model sınıfları:

- `Customer`
- `Car`
- `Category`
- `CustomerCar`

Veritabanı bağlantısı ve tabloların C# tarafındaki karşılıkları `CustomerDbContext` sınıfı içinde tanımlanmıştır.

`CustomerCar` sınıfı, müşteri ve araç arasındaki kiralama ilişkisini temsil eder. Bu sınıf sayesinde hangi müşterinin hangi aracı hangi tarihler arasında kiraladığı ve toplam ne kadar ücret ödediği takip edilebilir.

## Entity Framework Kullanımı

Projede Entity Framework Code First yaklaşımına benzer şekilde model sınıfları oluşturulmuş ve sınıflar `[Table]`, `[Key]`, `[Required]`, `[ForeignKey]` gibi attribute'lar ile veritabanı tablolarına bağlanmıştır.

Örnek ilişkiler:

- Bir kategori birden fazla araca sahip olabilir.
- Bir araç bir kategoriye aittir.
- Bir müşteri birden fazla kiralama işlemi yapabilir.
- Bir kiralama kaydı bir müşteri ve bir araç ile ilişkilidir.

## Kurulum ve Çalıştırma

1. Projeyi bilgisayarınıza indirin veya klonlayın.
2. Visual Studio ile `RENTCAROTOMASYON.sln` dosyasını açın.
3. SQL Server üzerinde `RENTCAROTOMASYON` veritabanını oluşturun.
4. `database.sql` dosyasındaki SQL komutlarını çalıştırarak tabloları oluşturun.
5. `App.config` dosyasındaki connection string bilgisinde yer alan `Data Source` kısmını kendi SQL Server adınıza göre düzenleyin.
6. Projeyi Visual Studio üzerinden çalıştırın.

## Connection String

Veritabanı bağlantısı `App.config` dosyasında tutulmaktadır.

Örnek:

```xml
<add name="CustomerDbContext"
     connectionString="Data Source=DESKTOP-7EBTM69\MSSQLSERVER01;Initial Catalog=RENTCAROTOMASYON;Integrated Security=True"
     providerName="System.Data.SqlClient" />
```

Farklı bir bilgisayarda çalıştırırken `Data Source` kısmı değiştirilmelidir.

## Öne Çıkan Özellikler

- İlişkili tablolarla çalışma
- Entity Framework kullanımı
- LINQ ile raporlama
- Otomatik toplam ücret hesaplama
- Araç müsaitlik kontrolü
- Kullanıcı giriş ekranı
- Görsel arayüz tasarımı
- GitHub üzerinden versiyon takibi

## Projenin Geliştirilebilir Yönleri

İlerleyen sürümlerde projeye şu özellikler eklenebilir:

- Kullanıcı bilgilerini veritabanında tutma
- Şifreleri güvenli şekilde saklama
- Kiralama kayıtlarında arama ve filtreleme
- Raporları Excel veya PDF olarak dışa aktarma
- Araç bakım durumu takibi
- Araç teslim alma işlemi
- Müşteri geçmişi görüntüleme
- Plaka format kontrolü
- Telefon ve e-posta doğrulama

## Proje Sahibi

Berna Aldemir

## Ders Bilgisi

Nesnesel Tasarım ve Programlama Final Projesi
