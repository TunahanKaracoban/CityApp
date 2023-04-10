# ASP.NET Mvc de Web API'nin Tüketilmesi.
## Gereksinimler
Bu projeyi çalıştırmak için aşağıdaki bileşenlere ihtiyacınız var

- Visual Studio veya benzeri bir IDE.
- .NET 7.
- Entity Framework 7.02.
- MS SQL Server.
## Proje Açıklaması
### Web API Projesi:
- Web API projesinde, Entity Framework kullanarak Sehirler tablosu oluşturuldu ve bu tabloyu CRUD işlemleri gerçekleştirecek şekilde tasarlandı.
- Sehirler tablosu, "Id", "SehirAdi" ve "UlkeAdi" sütunlarından oluşmaktadır.
- CRUD işlemleri, Repository Tasarım Deseni ile gerçekleştirilmiştir.
### MVC Projesi:
- MVC uygulaması, oluşturulan Web API servisle haberleşip bir sayfada Repository Pattern ile CRUD işlemleri yapılmıştır.
- Sehirler sayfasında, "Sehir Adi" ve "Ulke Adi" sütunları yer alacak ve bu sütunlardan oluşan tablo üzerinde Ekle, Sil ve Güncelle işlemleri yapıldı.

### Aşağıda Web API CRUD işlemleri tamamlandıktan sonra Sehirler tablosu GET metodu ile postmande test edilmiştir.

![postman](images/resim_(362).png)

### MVC uygulaması Web API ile haberleşip Sehirler listesi kullanıcıya gösterilmiştir.
![postman](images/resim_(363).png)

### MVC' de ekleme işlemi yapılmıştır.
![postman](images/resim_(364).png)
### Burada New York şehrinin eklendiği görülmektedir.Aynı zaman da burada yapılan Ekleme işlemi Web API' de eklenmiş olmaktadır.
![postman](images/resim_(365).png)
### Güncelleme ve Silme işlemleri de aşağıda gösterilmektedir.
![postman](images/resim_(366).png)

![postman](images/resim_(367).png)






