namespace Periytyminen;

class Lintu { //base class ... linnun pohja
    public string Nimi { get; private set; }
    public string Aani { get; private set; }
    bool siivet;
    bool nokka;
    bool lentaa;

    public Lintu(string _nimi = "Lintu", string _aani = "Kraak kraak", bool _siivet = true, bool _nokka = true, bool _lentaa = true) {
        Nimi = _nimi;
        Aani = _aani;
        siivet = _siivet;
        nokka = _nokka;
        lentaa = _lentaa;
    }

    public void AnnaAani(){ //ääntele
        Console.WriteLine($"[DEFAULT] {Nimi} ääntelee {Aani}");
        Console.Beep(600, 300); // Oletusäänimerkki ( ✅Windows ❌Linux ❌Mac)
    }

    // public virtual void AnnaAani() <--- TULOSSA
    // {
    //     Console.WriteLine($"[DEFAULT] {Nimi} ääntelee {Aani}");
    //     Console.Beep(600, 300); // Oletusäänimerkki
    // }    
}

class Talitintti:Lintu { //derived class ... käyttää (perii) lintua pohjana 
    public Talitintti() : base("Talitintti", "titityy") { } //asetetaan konstruktorille tietyn linnun erityisominaisuudet. Asettaa vain kaksi ensimmäistä ominaisuutta

    public void RoikuOksalla() //talitintin erityis ominaisuus verrattuna esim. Lokkiin on, että se osaa roikkua oksalla alassuiten.
    {
        Console.WriteLine($"{Nimi} roikkuu oksalla alaspäin ja etsii ruokaa.");
    }    
}
class Kalalokki : Lintu
{
    public Kalalokki() : base("Kalalokki", "kaa-kaa") { }

    // public override void AnnaAani() <--- TULOSSA
    // {
    //     Console.WriteLine($"{Nimi} ääntelee {Aani}");
    //     Console.Beep(800, 500); // Keskikorkea ääni
    // }

    public void Kalasta()
    {
        Console.WriteLine($"{Nimi} kalastaa vedestä.");
    }

    public void Vaani()
    {
        Console.WriteLine($"{Nimi} leijuu ilmavirtauksissa ja etsii saalista.");
    }
}

class Program
{
    static void PiirraTeksti(string[] tekstit){
        foreach (string lause in tekstit){
            Console.WriteLine();
            foreach (char kirjain in lause)
            {
                Console.Beep(800, 10);
                Console.Write(kirjain);
                Thread.Sleep(10);
            }
            Console.WriteLine();
        }
    }
    static void TeeLintu(int valinta){
        /*
        Console.WriteLine("1. Talitintti");
        Console.WriteLine("2. Kalalokki");
        Console.WriteLine("3. Strutsi");

        Konstruktori: public Lintu(string _nimi = "Lintu", string _aani = "Kraak kraak", bool _siivet = true, bool _nokka = true, bool _lentaa = true) {
        */
        switch (valinta)
        {
            case 1:
                Talitintti tt = new Talitintti();
                tt.AnnaAani();
                break; 
            case 2:
                Kalalokki kl = new Kalalokki();
                kl.AnnaAani();
                break; 
            case 3:
                Console.WriteLine();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Virhe: Lintu ei ole saatavilla!");
                Console.WriteLine("-------------------------------");
                Console.WriteLine();
                break; 
            case 4:
                Console.WriteLine("Tehtävä");Console.Beep(400, 250);
                Thread.Sleep(150); //tauko
                Console.WriteLine("1. Lisää kalalokille oma ääni (tapa tässä vaiheessa vapaa).");Console.Beep(400, 250);
                Thread.Sleep(150); //tauko
                Console.WriteLine("2. Laita valinta Strutsi toimimaan Talitinttiä ja Kalalokkia vastaavasti.");Console.Beep(400, 250);
                Thread.Sleep(150); //tauko
                Console.WriteLine("2.1. Lisää strutsille toiminto Juokse.");Console.Beep(400, 250);
                Thread.Sleep(150); //tauko
                Console.WriteLine("2.2. \"Juoksuta\" strutsia AnnaAani toiminnon jälkeen.");Console.Beep(400, 250);
                
                Console.WriteLine("Jatka painamalla ENTER");
                Console.ReadLine();
                break; 
            case 5:               
                PiirraTeksti(new string[] {"Voit näyttää tekstiä kuten ennen vanhaan elokuvissa tällä tavalla",
                "foreach (char kirjain in lause)",
                "{",
                "Console.Beep(800, 10);",
                "Console.Write(kirjain);",
                "Thread.Sleep(10);",
                "}"
                });

                break;
            default:
               Environment.Exit(0);
               break; 
        }
    }
    static void SoitaTheme(int kerrat = 3){
        for (int i = 0; i < kerrat; i++)
        {
            // "Ti-ti-tyy" 
            Console.Beep(1200, 150); //ti
            Console.Beep(1200, 150); //ti
            Thread.Sleep(50); //tauko
            Console.Beep(800, 250);  // tyy
            Thread.Sleep(200); // tauko
        }
    }
    static int PyydaNumero(){
        int valinta;
        do
        {
            Console.Write("Valinta: ");
            string syote = Console.ReadLine();

            if (!int.TryParse(syote, out valinta))
            {
                Console.WriteLine("Virhe: Syötteen täytyy olla numero!");
            }
            else
            {
                return valinta; //palauttaa numeron 
            }
        } while (true);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("------------------");
        Console.WriteLine("Birdsimulator 4000");
        Console.WriteLine("------------------");

        //varmistetaan, että args sisältää alkioita (>0) ja tarkistetaan indeksi nollan tieto
        if(args.Length == 0 || (args.Length > 0 && args[0] != "no-theme") )
            SoitaTheme();
            //voit ajaa ohjelman ilman "themeä" dotnet run no-theme

        Console.WriteLine("Valitse lintu");
        Console.WriteLine("1. Talitintti");
        Console.WriteLine("2. Kalalokki");
        Console.WriteLine("3. Strutsi");
        Console.WriteLine("4. Katso tehtävä");
        Console.WriteLine("5. Extra");
        Console.WriteLine("10. LOPETA");
        int valinta = PyydaNumero();

        TeeLintu(valinta);
        Main(new string[] { "no-theme" }); //aloita alusta
    }
}
