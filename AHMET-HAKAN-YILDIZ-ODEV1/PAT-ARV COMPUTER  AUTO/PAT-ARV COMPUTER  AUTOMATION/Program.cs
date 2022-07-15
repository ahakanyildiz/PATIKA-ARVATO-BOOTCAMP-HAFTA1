using System.Collections;

//  PROGRAMIN BÜTÜNÜNDE KULLANILAN DEĞİŞKENLER BURDA TANIMLANDI.
#region Variables

int indx = 0;
string productid;
string productpiece;
bool drm = true;
string confirmation;
int lastprice;
int i = 0;
string discount;
double lastprice2;
int percent;
#endregion 

//  MÜŞTERİLERİN BİLGİLERİNİN BARINDIRILDIĞI LİSTELER BURDA TANIMLANDI.
#region Customers Data Lists
List<string> idnumber = new List<string>() { "1", "2", "3", "4", "5" };
List<string> name = new List<string>() { "Hakan", "Aziz", "Talha", "Mücahid", "Can" };
List<string> surname = new List<string>() { "Yıldız", "Salman", "Haksever", "Eren", "Yıldız" };
List<string> phone = new List<string>() { "05526580828", "05342340101", "05326734546", "05526580672", "05362298902" };
List<string> mails = new List<string>() { "hakan34@gmail.com", "azizsalman23@icloud.com", "talhahksvr2@gmail.com", "mchdern@comu.ogr.edu.tr", "canflex01@gmail.com" };
#endregion

//  SİSTEME MÜŞTERİ KAYDEDEN FONKSİYON.
#region Add Customers
void addcustomers(string tcnu, string names, string surnames, string phones, string email)
{
    idnumber.Add(tcnu);
    name.Add(names);
    surname.Add(surnames);
    phone.Add(phones);
    mails.Add(email);
}
#endregion

//  ÜRÜNLERİN BİLGİLERİNİN BARINDIRILDIĞI LİSTELER BURDA TANIMLANDI.
#region Products Data Lists
List<string> urunad = new List<string>() { "Iphone 13 Pro Max", "Iphone 13 Pro", "Iphone 13", "Iphone 13 Mini" };
List<string> urunfiyat = new List<string>() { "32000", "26000", "22000", "18000" };
List<string> urunadet = new List<string>() { "8", "6", "9", "8" };
#endregion 

// ÜRÜN EKLE FONKSİYONU
#region Add Products
void addproducts()
{
    while (true)
    {
        Console.Write("Ürün adını giriniz:");
        string pname = Console.ReadLine();
        Console.Write("Ürün fiyatını giriniz:");
        string pprice = Console.ReadLine();
        Console.Write("Ürün adet giriniz:");
        string ppiece = Console.ReadLine();
        Console.Write("ÜRÜN EKLEMEYİ ONAYLAMAK 'ONAY' , PANELE DÖNMEK İÇİN 'PNL' yazınız:");
        string verificiation = Console.ReadLine();

        if (verificiation == "ONAY")
        {
            urunad.Add(pname);
            urunfiyat.Add(pprice);
            urunadet.Add(ppiece);
            Console.WriteLine("Ürün başarılı bir şekilde eklenmiştir.");
            backpanel();
            break;
        }
        else if (verificiation == "PNL")
        {
            adminpanel();
        }
        else
        {
            Console.WriteLine("DOĞRU KOMUT YAZDIĞINIZDAN EMİN MİSİNİZ?");
        }
    }


}
#endregion

//  ÜRÜNLERİ VE STOKLARI EKRANA LİSTELEYEN FONKSİYON.
#region Products Listing
void productslisting()
{
    Console.Clear();
    Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
    for (int c = 0; c < urunad.Count; c++)
    {
        Console.WriteLine("Urun adı : {0}   \tUrun Adet: {1}\t Urun Fiyat: {2} için  ==>  ", urunad[c], urunadet[c], urunfiyat[c]);
    }
    Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
    backpanel();

}
#endregion

//  SİPARİŞ BİLGİLERİNİN BARINDIRILDIĞI LİSTELER BURDA TANIMLANDI.
#region Orders
List<string> Musteriid = new List<string>();
List<string> Urunid = new List<string>();
List<string> Adet = new List<string>();
List<string> Ucret = new List<string>();
#endregion

//  EKRANA SİPARİŞLERİ LİSTELEYEN FONKSİYON.
#region Orders Listing
void orderslisting()
{
    Console.Clear();
    Console.WriteLine("--------------------------------------SİPARİŞLER--------------------------------------------------");
    try
    {
        for (int i = 0; i < Musteriid.Count; i++)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Müşterinin Adı Soyadı:{0}  {1} Urun Ad: {2} --- Urun Adet: {3} --- Ucret{4}", name[int.Parse(Musteriid[i])], surname[int.Parse(Musteriid[i])], urunad[int.Parse(Urunid[i])], Adet[i], Ucret[i]);
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Hata yakalandı.");
        throw;
    }
    finally
    {
        backpanel();
    }
}


#endregion

//  ADMİN PANELİNE YÖNLENDİREN FONKSİYON.
#region Admin Panel
void adminpanel()
{
    Console.WriteLine("Yönetim paneline gitmek için 'PANEL' yaz.");
    string admin = Console.ReadLine();
    if (admin == "PANEL")
    {
        Console.WriteLine("------------------------------------------------ADMİN PANELİ------------------------------------------------------------");
        Console.WriteLine("1-)Yeni müşteri girişi ve sipariş vermek için 1'i tuşla \n2-)Sipariş listelemek için 2'yi tuşla \n3-)Stok durumunu öğrenmek için 3'ü tuşla\n4-)Müşteri listesini görmek için 4'ü tuşla\n5-)Ürün eklemk için 5'i tuşla");
        string menu = Console.ReadLine();
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
        switch (Convert.ToInt32(menu))
        {
            case 1:
                login();
                break;
            case 2:
                orderslisting();
                break;
            case 3:
                productslisting();
                break;
            case 4:
                customerlisting();
                break;
            case 5:
                addproducts();
                break;

        }
    }
}
#endregion

// HERHANGİ BİR MODÜLDEN ADMİN PANELİNE DÖNÜŞ FONKSİYONU.
#region Return Panel
void backpanel()
{
    while (true)
    {
        Console.WriteLine("PANELE DÖNMEK İÇİN 'BACK' YAZ");
        string kmt = Console.ReadLine();
        if (kmt == "BACK")
        {
            adminpanel();
        }
    }
}
#endregion

//  EKRANA MÜŞTERİLERİ LİSTELEYEN FONKSİYON.
#region Customer Listing
void customerlisting()
{
    Console.Clear();
    Console.WriteLine("--------------------------------------MÜŞTERİ LİSTESİ--------------------------------------------------");
    for (int a = 0; a < idnumber.Count; a++)
    {
        Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.WriteLine("Adı Soyadı:{0} {1} Telefonu:{2} --- Maili:{3} --- TC Kimlik No:{4}", name[a], surname[a], phone[a], mails[a], idnumber[a]);
        Console.WriteLine("----------------------------------------------------------------------------------------");
    }
    backpanel();

}
#endregion

//  TC GİRİŞ EKRANI (SİSTEME KAYITLI KULLANICIYSA OTOMATİK OLARAK SİPARİŞ EKRANINA YÖNLENDİRİLİR EĞER SİSTEME KAYIT DEĞİLSE YENİ MÜŞTERİ KAYDI EKRANINA YÖNLENDİRİR.)
#region LOGIN
void login()
{
    Console.Write("TC GİRİNİZ: ");  //Kullanıcıdan tc no ile giriş istenir.
    string tc = Console.ReadLine();
    foreach (string t in idnumber) 
    {
        if (t == tc) //Eğer kullanıcının girdiği tc no, idnumber listesinde kayıtlıysa foreach döngüsü break komutuyla sonlandırılır ve bool türünde oluşturduğum bool değişkeni true döner.
                     //Daha sonraki sipariş aşamasında kullanabilmek amacıyla indx değişkenine, kullanıcının girdiği tc'yle eşleşen müşterinin listedeki index numarası alınır.
        {
            Console.WriteLine("Müşteri kayıtlı");
            indx = i;
            drm = true;
            break;
        }
        else if (t != tc) //Eğer tc kayıtlı değilse drm değişkenini false olarak döndürür ve listenin son elemanına kadar döngü döner.
        {
            drm = false;
            i++;
        }
    }
    {
        if (drm == true) //Eğer müşteri sisteme kayıtlıysa 'drm' değişkeni true dönmüştü bu yüzden kullanıcı direk sipariş ekranına yönlendirilir.
        {
            while (true) // Sipariş verilip 'ONAY' komutu yazılana kadar sipariş sormaya devam eder.
            {
                Console.Clear();
                Console.WriteLine("Sayın müşterimiz : {0}  {1} \ttelefonu: {2}\te-mail: {3}", name[indx], surname[indx], phone[indx], mails[indx]);
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                for (int c = 0; c < urunad.Count; c++) //Ürünleri ekrana seçim yapabilmeniz için gereken sayılarla yazdırır.
                {
                    Console.WriteLine("Urun adı : {0}   \tUrun Adet: {1}\t Urun Fiyat: {2} için  ==>  " + c.ToString() + " Tuşlayın", urunad[c], urunadet[c], urunfiyat[c]);
                }
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("Sipariş vermek için ürün kodunu giriniz:");
                productid = Console.ReadLine();
                Console.WriteLine("Adet miktarını giriniz:");
                productpiece = Console.ReadLine();
                Console.WriteLine("İndirim yüzdesini giriniz:");
                discount = Console.ReadLine();
                Console.WriteLine("Siparişi onaylamak 'ONAY' yazınız, sil baştan sipariş vermek için 'Enterlayın'");
                confirmation = Console.ReadLine();
                if (confirmation == "ONAY") //ONAY KOMUTU GELİRSE SİPARİŞİ VER EĞER GELMEZSE TEKRAR TEKRAR SİPARİŞ SORULUR..
                {
                    try //SİPARİŞ SİSTEME INSERT EDİLİR.
                    {
                        Musteriid.Add(indx.ToString());
                        Urunid.Add(productid);
                        Adet.Add(productpiece);
                        lastprice = int.Parse(productpiece) * int.Parse(urunfiyat[int.Parse(productid)]);
                        percent = lastprice * Convert.ToInt32(discount) / 100;
                        lastprice2 = lastprice - percent;
                        Ucret.Add(lastprice2.ToString());
                        urunadet[int.Parse(productid)] = (Convert.ToInt32(urunadet[int.Parse(productid)]) - int.Parse(productpiece)).ToString();
                        Console.WriteLine("Siparişiniz başarılı bir şekilde oluşturulmuştur.");
                        Console.Clear();
                        orderslisting();
                        adminpanel();
                        indx = 0;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);           
                    }
                    finally
                    {
                        orderslisting();
                    }
                }
            }
        }
        else //Müşterinin tc numarasının listede kaydı olmadığı için 'drm' değişkeni false dönmüştü bu yüzden de kayıt ekranına yönlendirildi.
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Böyle bir müşteri bulunamadı..");
            Console.WriteLine("Kayıt ekranına yönlendiriliyorsunuz..");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("MÜŞTERİ BİLGİLERİNİ DOLDURUNUZ..");
            Console.Write("TC NO:");
            string tcnum = Console.ReadLine();
            Console.Write("AD:");
            string add = Console.ReadLine();
            Console.Write("SOYAD:");
            string soyad = Console.ReadLine();
            Console.Write("TELEFON:");
            string tel = Console.ReadLine();
            Console.Write("MAİL");
            string email = Console.ReadLine();
            addcustomers(tcnum, add, soyad, tel, email);
            Console.WriteLine("Müşteri başarılı bir şekilde eklendi");
            System.Threading.Thread.Sleep(1000);
            /////////////////////////////////
            Console.Clear();
            indx = name.Count - 1; //Burda listeye en son eklenen müşteri olduğu için sipariş verirken kullanılacak index numarası listenin son index numarası yani listenin üye sayısının 1 eksiği oldu.
            while (true) // Sipariş verilip 'ONAY' komutu yazılana kadar sipariş sormaya devam eder.
            {
                Console.Clear();
                Console.WriteLine("Sayın müşterimiz : {0}  {1} \ttelefonu: {2}\te-mail: {3}", name[name.Count - 1], surname[surname.Count - 1], phone[phone.Count - 1], mails[mails.Count - 1]);
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                for (int c = 0; c < urunad.Count; c++)
                {
                    Console.WriteLine("Urun adı : {0}   \tUrun Adet: {1}\t Urun Fiyat: {2} için  ==>  " + c.ToString() + " Tuşlayın", urunad[c], urunadet[c], urunfiyat[c]);
                }
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("Sipariş vermek için ürün kodunu giriniz:");
                productid = Console.ReadLine();
                Console.WriteLine("Adet miktarını giriniz:");
                productpiece = Console.ReadLine();
                Console.WriteLine("İndirim yüzdesini giriniz:");
                discount = Console.ReadLine();
                Console.WriteLine("Siparişi onaylamak 'ONAY' yazınız, sil baştan sipariş vermek için 'Enterlayın'");
                confirmation = Console.ReadLine();

                if (confirmation == "ONAY") //ONAY KOMUTU GELİRSE SİPARİŞİ VER EĞER GELMEZSE TEKRAR TEKRAR SİPARİŞ SORULUR..
                {
                    try //SİPARİŞ SİSTEME INSERT EDİLİR.
                    {
                        Musteriid.Add(indx.ToString());
                        Urunid.Add(productid);
                        Adet.Add(productpiece);
                        lastprice = int.Parse(productpiece) * int.Parse(urunfiyat[int.Parse(productid)]);
                        percent = lastprice * Convert.ToInt32(discount) / 100;
                        lastprice2 = lastprice - percent;
                        Ucret.Add(lastprice2.ToString());
                        urunadet[int.Parse(productid)] = (Convert.ToInt32(urunadet[int.Parse(productid)]) - int.Parse(productpiece)).ToString();
                        Console.Clear();
                        orderslisting();
                        adminpanel();
                        indx = 0;
                        break;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    finally
                    {
                        orderslisting();
                    }

               
                }
            }
        }
    }
}
#endregion

// MAIN

#region MAIN CODE
login();
#endregion


