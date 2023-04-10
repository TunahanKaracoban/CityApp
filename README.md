#ASP.NET Mvc de Web API'nin Tüketilmesi.
##Gereksinimler:
Bu projeyi çalıştırmak için aşağıdaki bileşenlere ihtiyacınız var:

-Visual Studio veya benzeri bir IDE.
-.NET 7.
-Entity Framework 7.02.
-MS SQL Server.
##Proje Açıklaması
###Web API Projesi:
-Web API projesinde, Entity Framework kullanarak Sehirler tablosu oluşturuldu ve bu tabloyu CRUD işlemleri gerçekleştirecek şekilde tasarladık.
-Sehirler tablosu, "Id", "SehirAdi" ve "UlkeAdi" sütunlarından oluşmaktadır.
-CRUD işlemleri, Repository Tasarım Deseni ile gerçekleştirilmiştir.
##MVC Projesi:
-MVC uygulaması, oluşturulan Web API servisle haberleşip bir sayfada Repository Pattern ile CRUD işlemleri yapılmıştır.
-Sehirler sayfasında, "Sehir Adi" ve "Ulke Adi" sütunları yer alacak ve bu sütunlardan oluşan tablo üzerinde Ekle, Sil ve Güncelle işlemleri gerçekleştirildi.



