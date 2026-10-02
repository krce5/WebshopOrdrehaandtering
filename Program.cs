Webshop nyWebshop = new Webshop();
nyWebshop.OpretKunde("Jens Jensen", 12345678);
nyWebshop.OpretKunde("Lise Sørensen", 987654321);
nyWebshop.OpretKunde("Jon Allan", 852963147);

Console.WriteLine("<-------------FIND KUNDE----------------->");
Console.WriteLine(nyWebshop.findKunde(12345678));
Console.WriteLine(nyWebshop.findKunde(852963147));
Console.WriteLine(nyWebshop.findKunde(987654321));
Console.WriteLine(nyWebshop.findKunde(987654320));

Console.WriteLine("<-------------OPRET ORDRE----------------->");
nyWebshop.OpretOrdre(11, 12345678);
nyWebshop.OpretOrdre(12, 987654321);
nyWebshop.OpretOrdre(13, 852963147);



class Webshop
{
    List<Kunde> kunderListe = new List<Kunde>();

    List<Ordre> ordrerListe = new List<Ordre>();


    public void OpretOrdre(int ordreNummer, int tlfNummer)
    {

        opretO(ordreNummer, tlfNummer);


    }

    public void opretO(int ordreNummer, int tlfNummer)
    {
        
        Kunde lokal = find(tlfNummer);

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

      public string findKunde(int tlfNummer)
    {

        Kunde kunde = find(tlfNummer);
        if (kunde != null)
        {
            return kunde.navn;
        }
        return "--Kunden kan ikke findes :( --";
    }

    private Kunde find (int tlfNummer)
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
        opretK(navn, tlfNummer);


    }

    private void opretK (string navn, int tlfNummer)
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