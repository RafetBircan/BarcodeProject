yapılan proje'de
GET/codes  ile Tüm kayıtlı kodlarıçekebilir
POST/codes ile benzersi bir gs1 formatına uyumlu code oluşturabilir
GET/codes/{id} ile belirli id ilişkisi olan kodu çekebilir.
POST/validate ile girilen bir kodun uyumluluğunu gözlemlemeniz mümkündür.


Edindiğim bilgilere göre gs1 standarında doğruluğu sorgularken ilk 11 basamakta bulunan tek pozisyonlu rakamlar 3 ile çarpılır, çift pozisyondakilerin 
kendi değerleri ile toplanır. bu işlemden elde edilen sonucu ise 10 a tamamlayan rakam son haneyi ifade eder.Kontrolü bu şekilde sağladım.

test kısmında ise yazdığım kuralların tümünün testini yaptığını düşündüğüm verilerin testini gerçekleştirdim.



Veritabanı sql server authentication olarak kurulu olduğu için 'sa' kullanıcı şifresi gerekmekte hali hazırdan kullanılan bağlantı cümleciğinde.
bağlantı cümleciği appsettings.json'da bulunmakta. Database ismi 'BarcodeDb'   tablo scriptim şu şekildedir; =>
CREATE TABLE [dbo].[Codes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	   Gs1Code NVARCHAR(12) NOT NULL
        CONSTRAINT UQ_Codes_Gs1Code UNIQUE,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Codes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

Ayrıca database backupda klasörün rootunda yer almaktadır.


