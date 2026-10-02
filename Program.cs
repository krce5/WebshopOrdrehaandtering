Webshop nyWebshop = new Webshop();
nyWebshop.OpretKunde("Jens Jensen", 12345678);
nyWebshop.OpretKunde("Lise Sørensen", 987654321);
nyWebshop.OpretKunde("Jon Allan", 852963147);

class Webshop
{
    List<Kunde> kunderListe = new List<Kunde>();

    public void OpretKunde(string navn, int tlfNummer)
    {
        opret(navn, tlfNummer);


    }

    private void opret (string navn, int tlfNummer)
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