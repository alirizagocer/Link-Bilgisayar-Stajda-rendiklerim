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










































































*/
