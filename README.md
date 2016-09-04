# EvYapimiTv
Arduino ve c#  ile basit  televizyon uygulaması

Evdeki televizyonun bozulması ile beraber yapmış olduğum basit ama en azından iş görür tv uygulaması


Direkt olarak kullanmak için

- IR alıcısını arduinonun 2. pine bağlayın.
- Arduino IRremote master klasöründeki kütüphaneyi import edin
- Tv_kumanda klasöründeki arduino yazılımını yükleyin.
- Serial monitorden evinizdeki kumandanın tuşlarına basarak  hangi tuşa basınca hangi değer çıktığını not alın.
- Not aldığınız değerleri tv klasöründeki form1.cs içersiinde  t1 t2 ses v.s  şeklinde listelenmiş değişkenlere  tuşlara göre aratayın.
- Form1 içerisindeki listbox da toplam 10 adet kanal listelenmiş durumda (Her tuş için bir kanal ekledim örneğin 1 e basınca atv gibi) bu listedeki kanal linklerini kendi izleyebileceğiniz kanallarınki ile değiştirebilirsiniz.
- tv klasöründeki debug  klasörü içerisinde bulunan comport.txt metin dosyasını açıp arduinonun bağlı olduğu port ile değiştirin.
- Uygulamayı başlatın.
Mevcutta her tuş numarasına (0-9 tuşlarına) birer adet kanal ve ses açıp kapatma foknksiyonu eklidir.

Belirlediğim kanalları izleyebilecek şekilde fazla kanal gereksinimi duymadan 10 adet kanal için basit bir şekilde yaptım. Dilediğiniz gibi geliştirebilir yeni özellikler ekleyebilir hatta smart tv kıvamına bile getirebilirsiniz. :)

NOT: İNTERNET EXPLORER  10 VE ÜZERİNİ BİLGİSAYARINIZA KURMANIZ FAYDALI OLACAKTIR. DİĞER SÜRÜMLERDE BAZEN FLSAH HATASI V.B ŞEYLER OLABİLİYOR
