/*
Nesne Tabanlı Programlama:Bu bir yaklaşımdır direkt bir metodoloji olarak düşünebiliriz.Yazılım geliştirme süreçlerini daha sistematik hale getirip süreyi kısaltarak verimli-
liği arttırmak için ortaya atılmış bir yaklaşımdır.Gerçek hayatı simüle etmeye çalışır gördüğümüz şeyleri nesne olarak kodlamaya eklememizi sağlar.Bir nesneyi oluşturabilmek
için önce o nesneyi modellemek gerekir.Nesneler heapte tutuluyor.
Yazılımcılar olarak biz heape erişemeyiz fakat stackteki değerler heape erişebiliyor bu yüzden biz de stacke eklediğimiz referans sayesinde heapteki nesnelere erişebiliyoruz.
OOPde bir nesne oluşturmak için önce o nesneyi modellememiz gerekiyor.Bir objenin modelinin tanımını oluşturabilmek için sınıf kullanılır.

class classİsmi
{

}

Sınıf nerede oluşturulur : 
Namespace içerisinde
Namespace dışında
Class İçerisinde(Nested Class)
Namespace : içerisinde birden fazla yapı(struct,class...) barındıran yapı.Namespace içerisindeki classlara namespace adı ile erişilebilir.Eğer bir class namespace dışındaysa
o class herkes tarafından erişilebilir.
Sınıf ile nasıl nesne oluşturulabilir.Bir class tanımlandığında o class adı bir türdür.O yüzden class adı ile o türü kullanırız.



Class Members : Sınıfı kullanmamıza yardımcı olan üyeleridir.
Field : Nesne içerisinde veri depoladığımız alanlardır.Class içerisindeki değişkenlerdir.Herhangi bir türden olabilir.Nesne oluşturarak içerisindeki fielda erişebilirz ve erişim düzenleyicilerine
göre erişebilmemizin sınırları vardır.

MyClass c1 = new MyClass();  //Bu şekilde oluşturulabilir

c1.a dersek bunun field olduğunu görürüz.

class MyClass
{
    string a;
}


Fieldlarda default değer atanır.int için 0 gibi.Türüne özgü default değer atanır.




Erişim Belirleyicileri(Kendim ekledim seride yoktu) :

public : Her yerden erişilebilir — aynı sınıf, aynı proje, başka proje, hiç sınırlama yok.

private : Sadece tanımlandığı sınıfın içinden erişilebilir. Alt sınıflar (kalıtım alan sınıflar) bile erişemez. Belirtilmezse üyelerin varsayılanı budur.

protected : Tanımlandığı sınıf ve ondan türeyen (kalıtım alan) sınıflar içinden erişilebilir. Başka yerden erişilemez. Senin örneğindeki _boy, _en bu yüzden protected — Ucgen ve Dikdortgen 
bunlara erişebilsin diye.

internal : Aynı proje (assembly) içinden her yerden erişilebilir, ama başka bir projeden erişilemez.

protected internal : protected VEYA internal — yani aynı projeden herkes ya da farklı projedeki alt sınıflar erişebilir (ikisinin birleşimi, "veya" mantığı).

private protected : Aynı proje içindeki alt sınıflar erişebilir — yani hem aynı projede olmalı hem de alt sınıf olmalı (ikisinin kesişimi, "ve" mantığı). C# 7.2 ile geldi.




Property : Nesne içerisine özellik sağlar.Property özünde bir metottur.Yani algoritmik kodlarımızı inşa ettiğimiz bir alandır.Metottan farklı olarak parametre almamaktadır ve ayrıca içerisinde
get ve set olarak iki blok vardır.Bizim fieldlarımıza erişilmesini istemediğimiz için başka yazılımcılar tarafından biz de araya girerek propertyler tarafından erişim sağlatırız.
Get : Propertynin değeri çağırıldığında get bloğu tetiklenir ve değerini return eder.
Set : Propertye değer vermemizi sağlar.
Encapsulation : Bir nesne içerisindeki dataların(fieldların içindeki değerlerin) dışarıya kontrollü şekilde açılması ve veri almasıdır.
Full Property : İçerisinde get ve set blokları tanımlanmalıdır.

class MyClass 
{
    int adi;
    string b;

    Full property :Property hangi türden bir fieldı temsil ediyorsa o türden olmalıdır.Propertyler temsil ettikleri fieldların adının ilk harfini büyük şekilde yazıp ad alırlar.
    public int Adi 
    {
        get {
            return adi; 
        }
        set {
            adi = value;
        }
    }

}
Aynı şekilde full propertyi böyle de tanımlayabiliriz
public int Adi {get => yasi;set => yasi = value;}


MyClass c1 = new MyClass();
Console.WriteLine(c1.Adi)   //get bloğu tetiklenir
c1.adi = 20    //set bloğu tetiklenir
Biz bu şekilde kritik bir işlemi veya veriyi değiştirerek gönderebiliriz talep edenlere 
Prop Property : Fieldlara olan erişimleri hiçbir kontrol yapmadan get ve set işlemlerini yapmamızı sağlayan propertylere denir.
public int Adi 
    {
        get {
            return adi; 
        }
        set {
            adi = value;
            }
    }

bunu yazmaya uğraşmak yerine direkt şöyle yazmamızı sağlıyor.
public int Adi {get;set;}
public int Adi {get => yasi;set => yasi = value;}

public int Adi {get;set;}
public int Adi {get;set;} = 15;     bu şekide default değer atamak yerine kendi istediğimiz değeri de atayabiliriz.
public int Adi {get;} = 15;     //Bu şekilde readonly yapabilirsin ama writeonly diye bir şey olmuyor get her türlü yazmak zorunda.



Ref ReadOnly Returns : Bir sınıf içerisindeki fieldı referansıyla döndürmemizi sağlayan ve bir yandan bu değişkenin değerini readonly yapan özelliktir.
string adi = "Ali";
public ref readonly string Adi = ref adi;

Computed Properties : içerisinde türetilmiş bir bağıntı taşıyan propertylerdir.

int s1 = 15;
int s2 = 25;
public int Topla 
{
    get 
    {
    return s1 * s2;
    }
}

Expression bodied Property : Readonly olanlarda kullanılır sadece 
public int Cinsiyet
{
    get 
    {
    return "Erkek oldu";
    }
}
bunun yeirne şu şekilde tanımlarız.
public string Cinsiyet => "Erkek";
Auto Property Inıtıalizersin akrabası

Inıt-Only Properties - Inıt Accessor: Nesnenin sadece ilk yaratılış anında değer vermemizi sağlar.Object initializer desteği vardır.Reccord ile bağıntılı bir property. Kullanımı : 
class Book
{
    public string Name { get; init;} = {"Kutsal Damacana"} 
    public string Yazar { get; init ; }             //Bu şekilde de tanımlanıp değer atanabilir.
    public Book()
    {
        Yazar = "Ali Rıza Göçer";
    }
}
İnit keywordü get yazılmadan yazılamaz ve set de olmayacak kullanılırken.
public int Adi 
    {
        get {
            return adi; 
        }
        init 
        {
            adi = value;    //Burada 1 kereliğe mahsus ilk tanımlanırken değer atar ve sonrasında daha değer atamaz bu şekilde set bloğunun yerini alıp tek seferlik atama yapara.
        }
    }


Indexer : Nesneye indexer özelliği kazandıran yapı olarak property ile aynı olan elemandır.
erişim belirleyicisi /geri dönüş türü /this [parametreler]
public int this[int a]
    get {
        return a;
    }
    set 
    {
        return a = 10;
    }

Kritikler : Nested class üstündeki classın bir elemanı mıdır    =>   Hayır.
Bir classın üstüne gelince açıklamalar oluyor randomda olduğu gibi overloadlarına dahi gösteriyor biz bunu nasıl sağlarız => eğer // koyarsan yorum satırı olur /// koyarsan açıklama satırı olur.
/// <summary>
/// 
/// </summary>
class MyClass
{
/// <summary>
/// 
/// </summary>
/// <param name="a"></param>
public void X(int a)
    {
        Console.WriteLine("Ali");
    }
}

Bu şekilde istediğimiz gibi açıklamalar ekleyebiliriz.




This Keyword : Bu keywordün 3 adet amacı vardır : 
1-) Sınıfın nesnesini temsil eder.
2-) Aynı isimde field ile metot parametrelerini ayırt etmek için kullanılır.
3-) Bir constructordan başka bir constructorı çağırmak için kullanılır.

1.kullanım : SInıfın memberları içerisinde kullanılan keyworddür.Elimizde istediğimiz kadar nesne oluşturabiliyoruz ya işte oluşturduğumuz bu nesneleri sınıfın modellemesi sırasında temsil
etmemizi sağlayan this keywordüdür.Bir nesneden oluşturulanı direkt sınıf modellemesinde this ile temsil eder.
2.kullanım : This keywordü ilgili class yapılanmasının o anki nesnesine karşılık gelir. This kullanmak zorudna değiliz.
class Yas 
{
    int a;
    public int AltanDüzYatan(int a)
    {
        sen burda a ile bir işlem yaparsan yukarıda property dışına yazdığımız a ile işlem yapar ama eğer parametredeki a ile işlem yapmak istiyorsan şunu yapman lazım
        this.a  böyle dersen parametredeki a ile işlem yapabilirsin.
    }
}
3.Kullanım : Nesneyi ve constructorı gördükten sonrasında anlatıcak.


Nesne Nedir : Nesne canlı bir organizmadır. İçerisinde birden fazla anlamlı ve birbirleriyle ilişkiler bulunduran fonksiyonel işlemler üreten bir yapılanma.Nesneleri modellememizi sağlayan
classlar ise Complex Typelardır.Anlamlı verilerin bir bütün oluşturduğu kompleks bir yapıdır. 
Nasıl oluşturulur : 

class MyClass
{
public void X(int a)
    {
        Console.WriteLine("Ali");
    }
}

new MyClass();   //Nesne oluşturuldu.
MyClass m1 = new MyClass();    //Bu da oluşturur.
C# 9.0 ile gelen Target Typed New Expressions özelliği sayesinde şu şekilde de oluşturabiliriz.
MyClass m1 = new();


Referans : Ramin stack bölgesinde tanımlanan ve heap bölgesindeki değerleri işaretleyen değişkenlerdir/noktalardır.Heapte ne tutuluyorsa stackte de onun türünde bir referansoluşturulur ve ona 
göre tutulur.Stack : MyClass m                    Heap : new MyClass
Referanslar illa bir nesne işaret etmek zorunda değillerdir.Eğer ki referans herhangi bir değer işaretlemiyorsa o referans null değerini alır.
MyClass m1 = new MyClass();
m1.MyProperty = 15;

Myclass m2 = null;
m2.MyProperty = 20 ;  //Hata vericek çünkü m2 hiçbir şeyi göstermiyor null stackte bir varlığı var ama heapte işaretlediği bir yer yok.

class MyClass 
{
    public int MyProperty {get; set;}


}


Referanssız Nesneler : Bir nesneyi referans oluşturmadan da oluşturabiliriz fakat referans oluşturmadığımız için ve biz programcılar olarak heape de erişemediğimizden dolayı bizim için o 
referans artık orada sadece duracaktır. Fakat c#ın getirdiği bir özellik ile ise Garbage Collector bu referanssız nesneler ile herhangi bir işlem yapamadığımız için silecektir.

Object Initializer İle Nesne Oluşturma Esnasında Propertylere İlk Değer Atama​ : 
MyClass m1 = new MyClass() 
{
    MyProperty1 = 10;
    MyProperty2 = 50
    MyProperty3 = 100;
};

Bu şekilde daha oluşturulurken default olarak değerler atanmış olur.Field ve propertyleri bu şekilde atayabiliriz değer.



Nesne Kopyalama Davranışları | Shallow Copy | Deep Copy : Daha önce de bahsetmiştik bunların ne olduğundan şimdi tam olarak tekrardan bahsedicez.
Shallow Copy : Bir nesnenin birden fazla referansla işaretlenmesi durumuna diyoruz.Referans türlü değişkenlerde default olarak shallow copy yapılır.Değer türlü değişkenlerde ise shallow copy yapmak
için ref keywordü kullanılır
MyClass m1 = new MyClass();
MyClass m2 = m1;
MyClass m3 = m2;
MyClass m4 = new MyClass();

Şu an m1in nesnesine bakan 3 tane referans var {m1,m2,m3} hepsi aynı nesneye bakıyor. m4 ise farklı nesneye bakıyor.
Deep Copy : Bir nesnenin tek bir referansla işaretlenerek aynı değerde başka bir nesne oluşturulması durumuna diyoruz.Türetim durumu olmak zorunda. Referans türlü değişkenlerde bunu yapmak için
ekstra işlem gerekir.Değer türlü değerlerde ise default olarak deep copy yapılır.
MyClass m1 = new MyClass();
MyClass m2 = m1;            //Shallow Copy
MyClass m3 = m1.Clone();    //Deep Copy

class MyClass
{

    public MyClass Clone()
    {
        this.MemberWiseClone();          //MemberWiseClone bir sınıfın içerisinde o sınıftan türetilmiş olan o anki nesneyi clonelamamızı sağlayan bir fonksiyondur.
    }
}




Encapsulation : Encapsulation, nesnelerimizdeki fieldların kontrollü bir şekilde dışarıya açılmasıdır.Bir başka deyişle, nesnelerimizi başka kişilerin yanlış kullanımlarından korumak için 
kontrolsüz değişime kapamaktır.
Eskiden nasıl yapılıyordu.
class MyClass
{
    int a;
    public int AGet()
    {
        return this.a
    }
    public void ASet(int value)
    {
        this.a = value;
    }
}

Artık Encapsulation propertyler ile yapılıyor  ama nasıl yapılıyor : 

class MyClass
{
    int a;
    public int A;
    {
    get { return a; }
    set { set a = value; }
    }
}




Record : Eğer ki tek bir objeyi değişmez/readonly yapmak istiyorsak o zaman Inıt-Only Properties kullanırız fakat bir objeyi bütünsel olarak değişmez yapmak istiyorsak o zaman daha fazlasına 
ihtiyacımız olacak.İşte bu ihtiyaca istinaden records türü geliştirilmiştir.Bir propertidense nesnenin genel değişmemezliğine bakar.Eğer sen nesneye sabitlik katmak istiyorsan o zaman record 
olarak tanımlarsın.Nesne ön plandaysa bu class,nesnenin değerleri ön plandaysa recorddur.Recordlar da bir classtır.Fakat değeri ön planda olan bir class.Classlarda nesneler eğer aynı değerlere 
sahipse bu 2 nesne aynıdır demek yanlış bir değerlendirmedir fakat recordlarda eğer nesneler aynı değerlere sahipse bu nesneler aynıdır.
record [Name]
{

}

public record Book 
{
    public string Name { get; init;} = {"Kutsal Damacana"} 
    public string Yazar { get; init ; } = {"KAYISI"}
}
init yapılanması recordda daha fazla kullanılır.

ÖRNEK:
//Main
MyClass m1 = new MyClass();
{
    MyProperty = 5;
}
MyClass m2 = new MyClass();
{
    MyProperty = 5;
}

MyRecord m3 = new MyRecord();
{
    MyProperty = 5;
}
MyRecord m4 = new MyRecord();
{
    MyProperty = 5;
}

Console.WriteLine(m1.Equals(m2));       //False döner.
Console.WriteLine(m3.Equals(m4));       //True döner.

record MyRecord 
{
    public int MyProperty{get ; set ;} 

}

class MyClass
{
    public int MyProperty{get ; set ;} 

}



With Expressions : Biz classlarda bir propertynin değerini değiştirmek istediğimizde yeni nesne oluşturup onun değerini değiştiriyoruz bu yüzden elimizde fazla nesne varsa eğer bizim için problem
oluyor ve biz bunu yapmak istemiyoruz.Biz de bu yüzden recordlarda with expressions kullanıyoruz ki.
public record Employee 
{
    public string Name {get; init;}
    public string Surname {get; init;}
    public int Position {get; init;}
}
Employee employee1 = new Employee 
{
    Name = "Ali Rıza"
    Surname = "Göçer"
    Position = 1
}
Employee employee2 = employee1 with {Position = 3}
Employee employee3 = employee1 with {Name = "BABANİNYO" , Position = 3}
Bu şekilde değiştirebiliriz eğer record kullanıyosak.


Özel Sınıf Elemanları(Özel Sınıf Fonksiyonları) :  
Constructor :  Bir nesne üretimi sırasında ilk tetiklenen fonksiyondur. Nesne oluştururken constructor tetiklenmek zorundadır. Sen tetiklemesen bile default olarak constructor oluşturulur.
Constructor işlevsel açıdan nesnelerin yaratılma aşamalarında içerisindeki fieldlara ilk değerlerini atamakla yükümlü OLABİLMEKTEDİR.Constructorların adı sınıf adıyla aynı olmak zorundadır.
Geri dönüş değeri olmaz/belirilmez.Erişlim belirleyicis public olmalıdır
class Ali
{
    public Ali 
    {
    
    }
}


//Main
new Ali(); //Output : Ya Allah,bismillah,Mohammed Salah      
Ne kadar değer vermemiş de olsak constructor nesne oluşurken tetiklendiği için çalışır.


class Ali
{
    public Ali
    {
    Console.WriteLine("Ya Allah,bismillah,Mohammed Salah")
    }
}

Default Constructor : Otomatik olarak oluşturulan constructor
Parametreli Constructor : Parametre alabilen constructordır.
Constructor Overload : Parametre aldığı için overload edilebilen fonksiyonlardır.
Constructor erişim belirleyicisi private olursa ne olur ?
Nesne üretirken hata alırız çünkü constructora erişemeyiz ve bu şekilde nesne üretimine engel oluruz çünkü constructor tetiklenmezse nesne olmaz.

This keywordü ile constructorlar arası geçiş : 
//Main
new MyClass(5)

class MyClass
{
    public MyClass()
    {
        Console.WriteLine("1.Constructor")
    }
    public MyClass(int a) : this()     //This burada şu an olduğumuz constructor harici constructorları çalıştırmayı sağlar bunun outputu önce 1.constructor çalışır this yüzünden sonra 2. çalışır.
    {                                  //10 tane construtor olsa this keywordünden önceki 9 tane çalışır en son çalışıcak olan this keywordlü constructordır.Eğer this içine parametre yazıcaksan
        Console.WriteLine($"2.Constructor : {a} ")      //sadece this olan constructorın parametrelerini yazabilirsin başka parametre yazamazsın veya sabit değer verebilirsin direkt.
    }
}


Recordlarda Constructor : Sınıflardakiyle tüm özellikler constructor hakkında aynıları birebir şekilde geçerli olucak.




Desctructor : Bir classtan türetilmiş olan bir nesne oluşturulduktan sonra imha edilmesi için otomatik çağırılan bir metottur.Desctructor parametre alamaz ve sadece class yapılanmasında 
kullanılabilir.
Bir nesnenin imha edilmesi için : 
    İlgili nesne herhangi bir referans tarafından işaretlenmemelidir.
    Yahut nesnenin oluşturulduğu veya kullanıldığı scope sona ermiştir. 
    Yani nesneye herhangi bir şekilde erişilmicek noktaya gelindiğinde/görevi bittiğinde/erişilemez olduğunda
Garbage Collector tarafından imha edilir.

Garbage Collector mimari tarafından bellek optimizasyonunu üstlenen bir yapıdır. Onun işine karışabiliriz fakat karışılması çok önerilmez. 
Main//
GC.Collect();
Console.ReadLine();
//Bu çok tavsiye edilmez şu an için gerek yok sadece bunun olduğunu bil yeter.

class MyClass 
{
    public MyClass
    {
            //Constructor
    }
    ~MyClass
    {
            //Deconstructor
    }
}

Deconstruct Metodu : Bunu pek anlamadım bakıcam buna tekrardan örnek çözerek.


Static Constructor : Static anlatılmadığı için çok anlamazsak np bir de singletondan bahsediyo onu zaten refactoring.guruda var diye almadım not
Bir sınıfın nesnesi oluşturulurken ilk tetiklenen STATİC CONSTRUCTORDIR. sonra normal constructor sonra da artık ne varsa normal akışta o işlemler ama bu belirli durumlarda olur sadece.
Bir sınıftan ilk nesne üretilirken sadece static constructor oluşur,sonra normal constructor oluşur fakat eğer bir sınıftan daha önce nesne oluştuysa o zaman static constructor tetiklenmez ilk
tetiklenen normal constructordır. 

Nasıl tanımlanır : 
class MyClass 
{
    public MyClass      //Geriye dönüş değeri yok.
    {
            //Constructor
    }
    static MyClass      //Erişim belirleyicisi ve geriye dönüş değeri yok sadece başında static yazar
    {
            //Static Constructor 
    }
}
Static const ilgili sınıf içerisinde herhangi bir static yapılanmanın da tetiklenmesi static const. tetiklenmesini sağlayacaktır. 

Nerede Kullanılır : Singleton desing patternda kullanılır.


Positional Record : 










Kalıtım : OOP'nin en önemli özelliğidir. Üretilen nesneler farklı nesnelere özelliklerini aktarabilmekte ve böylece hiyerarşik bir düzenleme yapılabilmektedir.Aynı aile grubundan gelen 
nesnelerin ya da yatayda eşit seviyede olan tüm olguların benzer özelliklerini tekrar tekrar herbirinde tanımlamaktansa bir üst sınıfta tanımlanmasını ve her bir sınıfın bu özellikleri
üst sınıftan kalıtımsal olarak almasını sağlamaktadır. Böylece hem kod maliyeti düşmekte, hem de mimarisel tasarım açısından avantaj sağlanmaktadır.
Nasıl durumlarda ya biz burda da kalıtım kullanalım diyoruz : Mesela sen geldin diyorsun ki ya kardeşim ben aynı kodu 2 defa yazıyorum ama aynı şey yani insan hayvan gibi ikisinde de aynı
özellikleri olan şeyler var ve sen de geldiğinde dedin ki ya biz aynı kodu yazıyoruz e niye burda ben bu ikisinin de ortak yönlerini bir üst sınıfa yazıp sonra bunların farklı özelliklerini
de kendi sınıflarına yazmıyorum.İşte bunu aklından geçirdiğin an ya da bunun ihtiyacını hissettiğin an kısacası KOD TEKRARIna düşüyorsan kalıtım yapabilirsin. 
                                                    Canlı
                                        İnsan                   Hayvan
                                    Erkek    Kadın      Kedi      İnek     Tavuk
                                                            Angus   Sığır
Tam olmadı ama bu şekil bir tablo ortaya çıkıyor sen gelip de ben bunların hepsinin ortak özelliklerini bunların parentında toplayayım ayrılan özelliklerini ise kendi sınıflarında yazıyım
dediğinde kalıtım mantığını kullanmış oluyorsun.


C# programlama dilinde kalıtım sınıflara özel bir niteliktir. Yani bir sınıf sade ve sadece bir sınıftan kalıtım alabilir.Record'lar da kalıtım alabilmekte. Lakin sadece kendi aralarında.
Kalıtım alabildikleri tek istisnai sınıf ise ileride göreceğimiz Object sınıfıdır.

class Personel
{
    public string Adi {get ; set ;}
    public string Soyadi {get ; set ; }
    public int Maas {get ; set ; } 
}

class Avukat : Personel
{
    public int BaroPuan {get; set;}
}

class Yazilimci : Personel
{
    public string[] KodladigiDiller {get ; set ;}
}

class Pentester : Personel
{
    public int THMRank {get; set;}
}

Bu şekilde kalıtım örneği verebiliriz.

Kalıtım aldığımız classa Base/Parent class denir. Kalıtım alana Derived/Child class denir.Bir sınıfın sadece 1 tane parent classı olabilir.
class A : Y, X ,Z tanımlanamaz eğer bunlar interface falan değilse yukarıdaki gibi classlarsa olmaz.


Bir nesne üretimi işlemi olurken önce o üretilicek nesnenin en üst atasına gidip ordan nesne üretmeye başlar yani A classının nesnesi üretilicek Anın parenti B, Bnin parenti C ve C parentı 
olmayan bir class o zaman önce Cnin nesnesi sonra Bnin nesnesi en son Anın nesnesi üretilir. Madem ki, herhangi bir sınıftan nesne üretimi gerçekleştirilirken öncelikle base class'ından 
nesne üretiliyor, bu demektir ki önce base class'ın constructor'ı tetikleniyor. Haliyle bizler nesne üretimi esnasında base class'ta üretilecek olan nesnenin istediğimiz constructor'larını 
tetikleyebilmeli yahut varsa parametre bu değerleri verebilmeliyiz. İşte bunun için base Keyword'ü nü kullanmaktayız.
//Main
new MyClass2();

class MyClass
{
    public MyClass(int a)
    {
    
    }
}

class MyClass2 : MyClass
{
    public MyClass2() : base(5)   //Burada constructor hata vermesin diye parametre gönderdik base keywordü ile.
}
Eger ki base class'ta bos parametreli bir constructor varsa derived classta base ile bir bildirilmde bulunmak zorunda degiliz.Cunku varsayilan olarak kalitimsal durumda bos paarametreleri 
constructor tetiklenir.

Bir classin constructorinin yaninda : base( ... ) keywordunu kullanirsak eger o class'in base classinin tum constructorlarini bize getirecektir. Haliyle ilgili siniftan bir nesne uretililrken
base classtan nesne uretimi esnasinda hangi constructorin tetiklenegini bu sekilde belirleyebiliriz.

Base ile This Keywordleri Karşılaştırması : 
This, bir sınıftaki constructor'lar arasında geçiş yapmamızı sağlar.
Base, bir sınıfın base class'ının constructor'larından hangisinin tetikleneceğini belirlememizi ve varsa parametrelerinin değerlerinin derived class'tan verilmesini sağlar.
//Main
MyClass m = new();
m.     Sen . operatörü ile class içindeki üyelere erişebiliyorsun fakat burada class içinde herhangi bir şey tanımlamasak da var olan 4 tane üye var

class MyClass
{
    //Burada hiçbir şey tanımlamıyoruz veya tanımlayadabiliriz fark etmez
}

ToString,Equals,GetHashCode ve GetType bu 4 metot ne yaparsan yap her şekilde . operatörünü kullanınca gelirler. Nereden geliyorlar 
C# programlama dilinde tüm sınıflar(delegate hariç ) Object sınıfından türetilir. Sen gelip de : Object yazsan da yazmasan da otomatik olarak Object sınıfından kalıtım almış oluyor.
C# programlama dilindeki en üst sınıf Object sınıfıdır ve bu metotlar da Object sınıfından kalıtımsal olarak gelir.

class Ali          //Direkt object sınıfıdan türemiştir.
{

}



class Insan              // Eğer bir parentı yoksa bu da object sınıfından türemiştir. O yüzden bunun child sınıfları da object sınıfının özelliklerini bu sınıftan dolayı elde edecektir.
{

}
class Ali : Insan        //Tek bir parentı olabiliceği için Ali sınıfının object sınıfı parentı değildir.
{

}


İsim Saklama(Name Hiding) Sorunsalı : 
class A
{
    public int X { get; set; }
}
class B : A
{
    public int X { get; set; }
}
Şimdi bu X A'dan mı
geliyor, yoksa B'den mi
Name Hiding denme sebebi B classından A'daki Xe erişmemiz mümkün değildir
Günümüzde bunun için ekstra bir bildiri yapmamıza gerek yoktur.Fakat eskiden şöyle yapıyorduk(Makalede görürsen karıştırma diye)
class A
{
    public int X { get; set; }
}
class B : A
{
    public new int X { get; set; }
}



Recordlarda Kalıtım : 
Record'lar sade ve sadece Record'lar dan kalıtım alabilmektedirler. Class'lar dan kalıtım alamazlar yahut veremezler! Kalıtımın tüm temel kuralları record'lar için geçerlidir; Bir record 
aynı anda birden fazla record'dan kalıtım alamaz! Record'lar da temelde class oldukları için üretilir üretilmez otomatik olarak Object'ten türerler.Base ve this keywordleri aynı amaçla 
kullanılabilmektedir. Name Hiding söz konusu olabilmektedir. Ve aklıma gelmeyen diğer tüm durumlar da record'lar için geçerlidir.

Sanal Yapılar (Virtual - Override):  Sanal yapılar, bir sınıf içerisinde bildirilmiş olan ve o sınıftan türeyen alt sınıflarda da tekrar bildirilebilen yapılardır.Bu yapılar metotlar veya
propertyler olabilir.
Name Hiding ile bir sınıftaki herhangi bir member'ı ondan türeyen torunlarda oluşturabiliyoruz ve buradaki yaşanan çakışmaya da Name Hiding diyoruz.
Lakin, sanal yapılarda olay bu şekilde değildir. Bir sınıfta bildirilen sanal yapı(metot ya da property) bu sınıftan türeyen torunlarında ezilebilmekte yani devre dışı bırakılıp 
yeniden oluşturulabilmektedir.
Sanal yapılarda çağrılan member'ın hangi türe ait olduğu Run Time'da belirlenir.
 
Ne için Kullanılır : Eğer ben miras aldığım bir özelliği ezip değiştirmek istiyorsam ve o özellik de sanalsa ben bu özelliği ezebilirim. Fakat ezmek gibi bir zorunluluğum yok!!!!
Nasıl Sanal Yapı Oluşturulur : 
class MyClass
{
    public virtual void MyMethod()
    {

    }
}

Sanal Yapılar Nasıl Ezilir : 
Bir class'ta virtual ile işaretlenerek sanal hale getirilmiş bir member(metot ya da property), bu class'tan miras alan torunlarında ezilmek/yeniden yazılmak isteniyorsa eğer ilgili
class'ta imzası override keywordü işaretlenmiş bir vaziyette tekrardan aynı member oluşturulur.
class MyClass
{
    public virtual void MyMethod()
    {

    }
}

class MyClass2 : MyClass 
{
    public override void MyMethod()
    {

    }
}


Örnek : 
//Main
Terlik t = new();
t.Bilgi();

Kalem k = new();
k.Bilgi();

class Obje 
{
    public virtual void Bilgi()
        {
            Console.WriteLine("Ben objeyim kanka")
        }
}

class Terlik
{
    public override void Bilgi()
        {
            Console.WriteLine("Ben terliğim kanka")
        }
}

class Kalem
{
    public override void Bilgi()
        {
            Console.WriteLine("Ben kalmemim kanka")
        }
}
//Output :  
Ben bir kalemim
Ben bir terliğim

İkiden Çok Hiyerarşik Kalıtım Durumlarında Override Durumu :Bir class ta virtual ile işaretlenmiş herhangi bir member illa ki direkt o class'tan türeyen 1. dereceden class'lar da override
edilmek mecburiyetinde değildir! İhtiyaca binaen alt seviyede ki torunlardan herhangi birinde override edilebilir.
Kritik : Mesela şöyle bir yapı düşünelim. A en üst ata class E de en alt child class torun olan şu şekilde bir yapı var
A - > B - > C - > D - > E            Burada A'da bir virtual member var ve sen bunu C classında ezdin. D ve E classlarına senin ezilmiş halin gider A classındaki hali değil. 
Eğer sen istersen tekrardan override ederek istediğin bir şekilde kullanabilirsin fakat override etmezsen Cde edilen override halini kullanırsın D ve E classlarında.
Dedenin dedesi mavi gözlüydü baban bunu siyah göz ile override etti artık sen yeni bir göz rengi ile override etmezsen sen de siyah gözlüsün. Sen override etmdin senin de torunun override etti
çocuğun da siyah gözlü oldu torunun ise artık hangi göz rengi ile override ettiyse ona sahip olur.

Örnek : 
//Main




class Sekil
{
    protected int _boy;
    protected int _en;
    public Sekil(int boy; int en)
        {
            _boy = boy;
            _en = en;
        }
    public virtual int AlanHesapla()
    {
        return 0;
    }
}

class Ucgen : Sekil
{
    public Ucgen(int boy, int en) : base(boy,en)
    {
    
    }
    public override AlanHesapla(int boy, int en)
    {
        return _en * _boy / 2;
    }
}

class Dikdortgen : Sekil
{
    public Ucgen(int boy, int en) : base(boy,en)
    {
    
    }

    public override AlanHesapla(int boy, int en)
    {
        return en * boy / 2;
    }
}






Polimorfizm(Çok biçimlilik) :  Bir nesnenin birden fazla farklı türdeki referans tarafından işaretlenebilmesi polimorfizm'dir.Polimorfizm bir nesnenin kalıtsal olarak  ilişkisi olan diğer 
nesnelerin referanslarıyla işaretlenebilmesini sağlar.
A türünden bir nesneyi A türünden bir referansla işaretlemenin yanında B türünden bir referansla, C türünden bir referansla da işaretleyebilmeye polimorfizm denir .
Bir nesnenin, birden fazla referansla işaretlenmesi; o nesnenin, birden fazla türün davranışlarını gösterebilmesini sağlar.
Ortak atadan gelen, kalıtımsal olarak 'Kuş'tan türeyen tüm hayvanlar kendi türleri yahut 'Kuş' türü ile referans edilebilirler.
//Main
MyClass2 m = new MyClass();      //Referans olanın diğerinin atası olması lazım yani referans olması için onun aile ağacı gibi düşünürsen daha büyük,daha erdemli biri olması için daha büyük
                                //bir statüde olması gibi düşünebiliriz.
class MyClass : MyClass2 
{

}

class MyClass2
{

}

//Main
A a = new C();
B b = new C();
C c = new C();
a.   //a. yaptığın zaman sadece X metotlarına erişebilirsin.
b.   //b. yaptığın zaman sadece X ve Y metotlarına erişebilirsin.
c.   //c. yaptığın zaman hem X hem Y hem de Z metotlarına erişebilirsn.


class A : C
{
    public void X() {}
}

class B : A
{
    public void Y() {}
}

class C 
{
public void Z() {}
}

Polimorfizm Türleri : Dinamik Polimorfizm ve Statik Polimorfizm olarak ikiye ayrılır.
Statik Polimorfizm : 
Derleme zamanında sergilenen polimorfizm'dir. Hangi fonksiyonun çağrılacağına derleme zamanında karar verilir.Static polimorfizm deyince aklımıza Metot Overloading terimi gelmelidir.
Metot Overloading; aynı isimde birbirinden farklı imzalara sahip olan metotların tanımlanmasıdır. Ya da başka deyişle bir isme birden fazla farklı türde metot yüklemektir. Haliyle burada 
bir metodun birden fazla formunun olması polimorfizm'ken, bunlardan kullanılacak olanın derleme zamanında bilinmesi statik polimorfizm olarak nitelendirilmektedir.
Overload edilmiş metotlardan daha derleme zamanında hangisinin kullanılıcağını bilmemize statik polimorfizm denir.

//Main
Matematik m = new();
m.Topla(4,5,6)  //Hangi metotun kullanılıcağını derleme zamanında biliyorum. Bu yüzden bu statik polimorfizmdir.
class Matematik
{
    public long Topla(int s1, int s2)
        => s1+ s2;
    public long Topla(int s1, int s2, int s3)
        => s1+ s2+ s3;
    public long Topla(int s1, int s2, int s3, int s4)
        => s1+s2+s3+s4;
}




Dinamik Polimorfizm : Dinamik polimorfizm; çalışma zamanında sergilenen polimorfizm'dir. Yani hangi fonksiyonun çalışacağına run time'da karar verilir.
C#'da dinamik polimorfizm deyince akla Metot Override gelmektedir.
Tür Dönüşüm Operatörleri : 
Cast operatörü : 
as operatörü : 
is operatörü : 








Nesneler Arası İlişki Türleri (Association-Aggregation-Composition) : 
Nasılsa insanlar arasında bir bağ varsa nesneler arasında da bir bağ vardır. Bizim bu bağları kategorize etmemiz nesneler arası ilişki türlerini ortaya çıkartır. Biz burada nesnelerin
aralarındaki türlere isimler vereceğiz. 
Nesneler arasında terminolojik olarak nitelendirilebilir ilişki türleri mevcuttur. Bu ilişkiler; kalıtım, referans yahut soyutlama gibi durumların getirisi olan mantıksal izahatlerdir.

Nesneler arası ilişki türleri : is - a ilişkisi   , has - a ilişkisi    , can - do ilişkisi    
is - a ilişkisi : 
is - a ilişkisi tamamiyle kalıtımla alakalıdır. C# programlama dilinde, iki sınıf arasında : operatörü ile gerçekleştirilen kalıtım neticesinde ortaya bir is - a ilişkisi çıkmaktadır.

class Car 
{

}
class Opel
{

}
Opel is a Car. Bu yüzden is - a ilişkisi denir.


has - a ilişkisi : 
Bir sınıfın başka bir sınıfın nesnesine dair sahiplik ifadesinde bulunan ilişkidir. Bir yandan kompozisyon/composition ilişkisi de denmektedir.
class Car 
{

}
class Opel
{
    Motor motor;
}
class Motor
{

}

Opel is a Car. Ve Opel has a Motor 


can - do ilişkisi : 
İnterface yapılanmasının getirisi olan bir ilişki türüdür. 
interface IAraba 
{
    void Gazla();
    void Frenle();
}
class Opel : IAraba
{
    public void Gazla()
    {

    }
    public void Frenle()
    {
    
    }
}
Opel sınıfı ile IAraba arasında can-do ilişkisi vardır.


Association, sınıflar arasındaki bağlantının zayıf biçimine verilen addır. Bu bağlantı oldukça gevşektir. Yani, sınıflar kendi aralarında ilişkilidir lakin birbirlerinden de bağımsızdırlar!
Parça - bütün ilişkisi yoktur! 
Örneğin :
Bir otobüsteki yolcular ile otobüs arasındaki ilişki Association'dır.Sonuçta hepsi aynı yöne gitmektedir.Lakin bir yolcu indiğinde bu durum otobüsün ve diğer yolcuların durumunu değiştirmez!



Aggregation-Composition : 
Aggregation
Sahip olunan nesnenin, sahip olan nesneden bağımsız bir şekilde var olabilmesi durumudur.

Composition
Sahip olunan nesnenin, sahip olan nesneden bağımsız bir şekilde var olamaması durumudur:

Misal; 
Bir arabayı düşünürsek eğer, bu arabanın tekeri ile vitesi arasındaki ilişki Aggregation ya da Composition açısından değerlendirirsek eğer; 


Bu araba teker olmadan olmaz lakin teker araba olmadan da kendi başına ayrı olarak var olabileceğinden dolayı araba ile teker arasındaki ilişki Aggregation'dır.

Benzer mantıkla bu araba vites olamdan da olmaz lakin vites araba olmadan bir anlam ifade etmeyeceğinden dolayı araba ile vites arasındaki ilişki Composition'dır.

Başka bir misal;
Bir kitap sayfalardan ve kapaktan meydana gelmektedir. Kitapla sayfa ve kapak arasındaki ilişkiyi değerlendirirsek eğer;

Kitabın herhangi bir sayfasının yırtılması işlevselliğini kaybettireceği aşikar. Lakin her bir sayfa başlı başına bağımsız bir şekilde var olabileceğinden dolayı kitapla sayfa arasındaki 
ilişki Aggregation'dır.

Kapak ise kitapla bir anlam kazanmaktadır ve kitabın dışında bağımsız bir şekilde var olmasının bir izahı yoktur. Dolayısıyla kitapla kapak arasındaki ilişki Composition'dır.




Readonly Keywordü :Bir class içerisinde tanımlanmış olan değişkenin yahut referansın sadece okunabilir olmasını sağlayan bir keyword'dür.
readonly keyword'u ile işaretlenmiş olan referansların değerleri ya tanımlama noktasında ya da constructor'da verilebilir.

Const ile arasındaki fark : Const tanımlanırken değer vermek zorundayız fakat readonly constructor ile de tanımlama noktasında da değer atayabiliriz. Const statiktir ayrıca.


Sealed Keywordü : Bir sınıfın miras vermesini yani başka bir sınıf tarafından miras olarak alınmasını engelleyen bir keyworddür. 
sealed class X
{

}
Bu şekilde kullanılır.
Sadece sınıflarda ve sadece ovverride edilmiş fonksiyonlarda kullanılır.Recordlarda da kullanılabilir.
Kalıtımsal durumlarda atalardan gelen ve birinci derece sınıf tarafından override edilmiş metotların alt sınıflar tarafından override edilmemesi için kullanabiliriz.

class A 
{
    public virtual void X() {}
}

class B : A
{
    sealed public override void X() {}
}

class C : B
{
    public override void X() {}  //biz üstteki metotu sealed ile işaretlediğimiz için override edemeyiz.
}


Mikro çapta da olsa bir sınıf eğer sealed ile işaretlendiyse ufak bir performans artışı sağlar çünkü derleyici sealed ile işaretlenen clasın miras alınmayacağını bilir. Singletonda kullanılır.




Partial Yapılanmalar : Bir class'ın,struct'ın yahut interface'in aynı yahut farklı dosyalarda birden fazla parçasının tasarlanmasını lakin bu parçaların özünde bir bütün olarak kullanılmasını
sağlayan, kodun daha organize ve kolay okunabilirliğini arttıran özelliklerdir.
Fiziksel olarak farklı olan bu tanımların birbirlerinin parçaları olabilmesi için aynı namespace içerisinde, aynı isimde ve aynı yapıda olmaları gerekmektedir.

Partial yapılanmaları genellikle aşağıdaki amaçlar doğrultusunda tercih etmekteyiz;
Kod Bölümleme : Büyük ve karmaşık yapıdaki sınıfları daha okunabilir ve düzenlenebilir parçalara bölmek için kullanılabilir.
İş Bölümü : Ekiplerin, aynı sınıfın farklı kısımlarını aynı anda geliştirebilmeleri için kullanılabilir.
Code Generator(yazılım geliştirme süreçlerini hızlandırmak, tekrarlayan kod yazımını önlemek ve otomasyon sağlamak amacıyla kullanılan araç veya mekanizmalara verilen genel addır.) :
Code Generator sistemleri tarafından yazdığınız kodun ezilmemesi için kullanılabilir.

Partial Yapılanmalarda Kısıtlamalar Nelerdir ? 
Parça olması amaçlanan tüm yapılar partial keyword'ü ile işaretlenmelidir.
İç içe partial türler kullanılabilir.
Tüm partial yapılar aynı namespace altında bulunmalıdır. Farklı projeler yahut modüllere yayılamaz!
Partial olan bir yapının tüm parçalarının türleri ve isimleri aynı olmak zorundadır.


Partial Olabilen Yapılar :
Struct 
Class
Record
Abstract class
Interface

Partial Metotlar Nelerdir? : Partial yapılar partial metotlar barındırabilirler.
Partial metotlar, sınıfın bir parçasında geliştiricinin metot bildiriminde bulunmasını sağlar. Başka bir parçasında ise diğer geliştirici tarafından bu metot tanımlanabilir.
Bunun yararlı olduğu iki senaryo vardır;



Template Code : Geliştirilen kodda metotlara dair bir şablon oluşturmak için kullanılabilir. Bu şablonların uygulanıp uygulanmayacağına dair geliştiricinin karar vermesine olanak tanınır.
Eğer şablonu tanımlanan metot uygulanmazsa derleyici tarafından metodun imzası ve o metoda dair yapılan tüm çağrılar/tetiklemeler kaldırılır.
Yani anlayacağınız, partial bir metot tanımlandığı taktirde ister uygulansın ister uygulanmasın herhangi bir farklı noktadan çağrılabilir/tetiklenebilir. Ancak uygulanmadığı taktirde 
herhangi bir derleme yahut çalışma zamanı hatası alınmayacaktır.


Source Generator : Source generator sistemleri ile sınıflarda tanımlanmış olan partial metot imzalarına karşılık gövdeler oluşturulabilir. Geliştirici, uygulanacak metodun partial bir şekilde
şablonunu ekledikten sonra source generator derleme sırasında bu metodun uygulamasını sağlar.
Tabi geliştirici isterse, bu metotların govdeleri source generator tarafından üretilmeden önce ya da bir başka deyişle bu metotlar uygulanmadan önce başka bir noktada çağırabilir.


Partial metotlarla ilgili aşağıdaki ekstra bilgileri bilmekte fayda vardır;

partial metotların runtime'da var olacağı kesin değildir. Eğer implementation edilmedilerse partial metotlar derleme sırasında yok sayılırlar.

Yukarıdaki durumdan dolayı partial metotlar delegate'ler ile temsil edilemezler.

partial metotlar;

ancak partial yapılar içerisinde tanımlanabilirler.

geri dönüş tipleri her daim void olmak zorundadır.

static veya generic olabilirler.

out parametresi alamazlar lakin ref parametresi alabilirler.

extern ve virtual olamazlar.

Aynı class'lar da olduğu gibi partial metodun hem tanımı hem de gövdesi partial ile işaretlenmelidir.

Bir metot imzasına karşılık tanım ve gövde olabilir.

Eğer ki partial metotlar başka bir metot tarafından çağrılırlarsa compiler tarafından var oldukları bilinecektir
yok eğer çağrılmazlarsa compiler derleme aşamasında ilgili metodu hiç görmeyecektir.








Abstraction : Lazım olan durumlara karşı sadece gerekli şeyleri görmemiz için soyutlama yaparız. Masamızda sadece o gün çalışıcağımız dersin kitaplarını tutmak diğerlerini kitaplığa 
kaldırmak gibi. Yazılımda da bir işlem yapıcakken ihtiyacımız olmayan metotları soyutlayarak o an işimize yarayan metotları gözümüzün önünde tutabilmek için bize bir fayda sağlar. 
Abstraction, bir sınıfın member'larından ihtiyaç noktasında alakalı olanları gösterip, alakasız olmayanları göstermemek demek oluyor.Abstraction interface ve abstract class ile doğrudan
direkt bir alakası yoktur. Sadece interface ve abstract classlar diğer yapılara göre daha rahat abstraction uygulanır.
Abstraction, bir sınıfın belirli bir davranışa sahip olduğunun garantisini sağlamaktadır.
Abstraction'ın Ana Hedefi Nedir? :  Bir nesnenin yalnızca o anki duruma göre ilgili davranışları gösterilmekte, gereksiz ayrıtıları gizlenmektedir


Abstract Class : Abstract Class, özünde kalıtımsal davranış göstererek bir sınıf üzerinde implementasyonlar yapmamızı sağlayan özel bir yapılanmadır!
Abstract class içerisinde normal memberlar tanımlanabileceği gibi kalıtımsal olarak bu abstract classı uygulayan sınıflara zoraki olarak uygulattırılacak member imzaları da tanimlanabilir.
abstract class MyClass
{
    public void X()
    {
    
    }
    public void Y()
    {
    
    }
}

Abstract Class İle Nesne Arasındaki İlişki : Abstract Class'lar soyut yapılanmalar olduğu için yapısal olarak iradeli bir şekilde(new operatörü ile vs.) nesne üretilebilir bir tür değildir!

new MyClass();

Yani bu şekilde bir abstract class'tan nesne üretmeye çalışmak mümkün değildir!
Ama bu abstract class türündenbir nesne hiçbir zaman olamaz anlamına gelmemektedir.
Kalıtımsal olarak bir abstract class herhangi bir sınıfa miras verdiği taktirde buradaki davranış şöyle olacaktır;
abstract class MyClass
{

}
class MyClass2 : MyClass
{

}

Yukarıdaki gibi kalıtımsal durumun söz konusu olduğu durumlarda

new MyClass2();

komutu ile MyClass2 isimli sınıftan bir nesne üretilirse eğer burada kalıtımsal hiyerarşinin gereği olarak abstract class'ın da dahil normal class'ın nesneleri üretilecektir.
İnterface ile arasındaki fark!!!!
Myclass m = new Myclass2();         //Bu şekilde abstract class kalıtım verdiği sınıfı referans da edebiliri duruma gelebiliyor.

abstract class MyAbstractClass
{
    int a;

    public void X()
    {
    
    }
    public int MyProperty { get; set; }
    abstract public void Z();
}

class MyClass : MyAbstractClass 
{
    public override void Z()
    {
    
    }
}

Burada hangi metot imzası oldu hangi metodun gövdesini oluşturucam takip etmek zor olduğu için gelip CTRL + . + ENTER       yaparsak direkt otomatik implemente edilmiş olacaktır.

KRİTİK : Abstract classlar da sonuçta bir class olduğu için ve bir class sadece tek 1 classdan miras alabildiği için abstract class implemente yöntemi olmasına rağmen bir class sadece 1 adet 
abstract classtan miras alabilir fakat interfacelerde sınır yok. 
Abstract olarak işaretlenen yapıların erişlm belirleyicilerinin public olması zorunludur.

Bir abstract class, başka bir abstract class'a miras verebilir.
Burada dikkat ederseniz bir abstract class'ın başka bir abstract class'a miras vermesi implementation olarak nitelendirilmemektedir.
Bu düpedüz bir kalıtımdır. Çünkü abstract class'lar içlerinde abstract olarak işaretlenmiş olan yapıları zoraki olarak sadece kendilerini uygulayan sınıflara uygulattirırlar, abstract 
class'lara değil! 






İnterface nedir : Interfaceler referans türlü değişkenlerdir. Mimari için bize katkı verir.







































































*/
