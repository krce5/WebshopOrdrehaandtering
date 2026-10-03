Webshop nyWebshop = new Webshop();
nyWebshop.OpretKunde("Jens Jensen", 12345678);
nyWebshop.OpretKunde("Lise Sørensen", 987654321);
nyWebshop.OpretKunde("Jon Allan", 852963147);

Console.WriteLine("<-------------FIND KUNDE----------------->");
Console.WriteLine(nyWebshop.FindKunde(12345678));
Console.WriteLine(nyWebshop.FindKunde(852963147));
Console.WriteLine(nyWebshop.FindKunde(987654321));
Console.WriteLine(nyWebshop.FindKunde(987654320));

nyWebshop.OpretOrdre(11, 12345678);
nyWebshop.OpretOrdre(12, 987654321);
nyWebshop.OpretOrdre(13, 852963147);

Console.WriteLine("<----UDSKRIV ALLE UBETALTE ORDRER--------->");
Console.WriteLine(nyWebshop.UdskrivOrdrer());

Console.WriteLine("<--------------BETAL ORDRE---------------->");
nyWebshop.BetalOrdre(11);
nyWebshop.BetalOrdre(11);

class Webshop
{
    List<Kunde> kunderListe = new List<Kunde>();

    List<Ordre> ordrerListe = new List<Ordre>();

    public bool BetalOrdre(int ordreNummer)
    {
        Ordre ordre = FindOrdre(ordreNummer);
        bool svar = TjekTilstand(ordre);
        if(svar == true)
        {
            Console.WriteLine("Betaling er genemfor! OrdreNR: " + ordre.ordreNummer + "; kunde: " + ordre.kundeRef.navn);
            ordre.afventerBetaling = false;
        }
        else
        {
            Console.WriteLine("---!FEJL!---- Ordren er allerede betalt");
        }
        return svar;
    }

    private bool TjekTilstand(Ordre ordre)
    {
        bool svar = false;

        if(ordre.afventerBetaling == true)
        {
            svar = true;
        }

        return svar;

    }

    //Metode for at finde specifik ordre ved at søge efter ordreNR
    private Ordre FindOrdre(int ordreNummer)
    {

        Ordre svar = null;
        int i = 0;
        while (i < ordrerListe.Count)
        {
            Ordre ordre = ordrerListe[i];
            if (ordre.ordreNummer == ordreNummer)
            {
                svar = ordre;
            }
            i++;

        }
        return svar;

    }




    public void VisOrdrer (bool afventerBetaling)
    {
        FindUbetalteOrdrer(afventerBetaling);
    }

    //Metode for at finde alle ubetalte ordrer
    private Ordre FindUbetalteOrdrer(bool afventerBetaling)
    {

        Ordre svar = null;
        int i = 0;
        while (i < ordrerListe.Count)
        {
            Ordre ordre = ordrerListe[i];
            if (ordre.afventerBetaling == afventerBetaling)
            {
                svar = ordre;
            }
            i++;

        }
        return svar;

    }


    public string UdskrivOrdrer()
    {
        string svar = "";
        int i = 0;
        while(i < ordrerListe.Count)
        {
            Ordre ordre = ordrerListe[i];
            if(ordre.afventerBetaling == true)
            {
                svar = svar + "Ordre NR:" + ordre.ordreNummer +"; Kunde: " + ordre.kundeRef.navn + Environment.NewLine;

            }
            i++;
        }

        return svar;    

    }

    public void OpretOrdre(int ordreNummer, int tlfNummer)
    {

        OpretO(ordreNummer, tlfNummer);


    }

    public void OpretO(int ordreNummer, int tlfNummer)
    {
        
        Kunde lokal = Find(tlfNummer);

        if (lokal == null)
        {
            Console.WriteLine("Kunden kan ikke findes i systemet. Ordret kan ikke oprettes.");

        }
        else
        {
            Ordre ordre = new Ordre();
            ordre.kundeRef = lokal;
            ordre.ordreNummer = ordreNummer;
            ordre.afventerBetaling = true;
            ordrerListe.Add(ordre);

        }
              
    }

      public string FindKunde(int tlfNummer)
    {

        Kunde kunde = Find(tlfNummer);
        if (kunde != null)
        {
            return kunde.navn;
        }
        return "--Kunden kan ikke findes :( --";
    }

    private Kunde Find (int tlfNummer)
    {

        Kunde svar = null;
        int i = 0;
        while (i < kunderListe.Count)
        {
            Kunde kunde = kunderListe[i];
            if(kunde.tlfNummer == tlfNummer)
            {
                svar = kunde;
            }
            i++;
        }

        return svar;

    }

    public void OpretKunde(string navn, int tlfNummer)
    {
        OpretK(navn, tlfNummer);


    }

    private void OpretK (string navn, int tlfNummer)
    {
        Kunde kunde = new Kunde();
        kunde.navn = navn;
        kunde.tlfNummer = tlfNummer;
        kunderListe.Add(kunde);

    }
}


class Kunde
{
    public string navn;
    public int tlfNummer;

}

class Ordre
{
    public int ordreNummer;
    public bool afventerBetaling;

    public Kunde kundeRef;
}