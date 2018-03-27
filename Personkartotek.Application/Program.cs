using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personkartotek;

namespace Personkartotek.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //Opret liste til at holde styr på personer og adresser
            List<PersonAdresse> personAdresses = new List<PersonAdresse>();

            //Oprettelser af adresser uden tilknytning med personer
            Adresse ras_adr_1 = new Adresse("Fuglesangs Alle", "28");
            Adresse ras_adr_2 = new Adresse("Rugbjergvej", "84");
            Adresse ras_adr_3 = new Adresse("Finlandsgade", "22");

            //Oprrettelse af telefoner.
            Telefon ras_tel_1 = new Telefon("1111111", "Privat", "CBB");
            Telefon cla_tel_1 = new Telefon("12345678", "Arbejd", "TDC");

            //Oprettelse af personer samt hvilken telefon og adresse de har (kun en af hver, flere kan tilføjes)
            Person rasmus = new Person("Rasmus", "Østergaard", "Thorsen", "Studerende", ras_adr_1 , ras_tel_1 , "rasmus@mail.dk");
            Person claus = new Person("Claus", " ", "Hansen", "Studerende", ras_adr_2, cla_tel_1, "claus@mail.dk");

            //Tilføjelse af adresser til specifik person
            rasmus.Adresse.Add(ras_adr_2);
            rasmus.Adresse.Add(ras_adr_3);

            //Tilføjelse af beboerer på bestemte adresser
            ras_adr_1.Beboere.Add(rasmus);           
            ras_adr_2.Beboere.Add(rasmus);
            ras_adr_2.Beboere.Add(claus);
            ras_adr_3.Beboere.Add(rasmus);

            //Opdateringer af hvem der bor hvor og hvilken type.
            personAdresses.Add(new PersonAdresse(rasmus, ras_adr_1, "Privat"));
            personAdresses.Add(new PersonAdresse(rasmus, ras_adr_2, "Anden adresse"));
            personAdresses.Add(new PersonAdresse(claus, ras_adr_2, "Hjemmeadresse"));
            personAdresses.Add(new PersonAdresse(rasmus, ras_adr_3, "Skole"));

            //Udprint af forskellige entiteter samt lister.
            Console.WriteLine("Rasmus har følgende: ");
            Console.WriteLine("Adresse(r): ");
            foreach (var adress in rasmus.Adresse)
            {
                Console.WriteLine("   {0}", adress.Vejnavn + " " + adress.Husnummer);
            }
            Console.WriteLine("Telefon(er):");
            foreach (var telefon in rasmus.Telefon)
            {
                Console.WriteLine("   {0}", telefon.Nummer + " " + telefon.Type + " " + telefon.Teleselskab);
            }
         
            Console.WriteLine();
            Console.WriteLine("Claus har følgende:");
            Console.WriteLine("Adresse(r): ");
            foreach (var adress in claus.Adresse)
            {
                Console.WriteLine("   {0}", adress.Vejnavn + " " + adress.Husnummer);
            }
            Console.WriteLine("Telefon(er):");
            foreach (var telefon in claus.Telefon)
            {
                Console.WriteLine("   {0}", telefon.Nummer + " " + telefon.Type + " " + telefon.Teleselskab);
            }

            Console.WriteLine();
            Console.WriteLine("Personer og adresser:");
            foreach (var personAdress in personAdresses)
            {
                Console.WriteLine("{0} tilhører {1} af typen {2}", personAdress.Personer.Fornavn + " " + personAdress.Personer.Efternavn, personAdress.Adresser.Vejnavn + " " + personAdress.Adresser.Husnummer, personAdress.AdresseType);
                Console.WriteLine();
            }

            By Aarhus = new By("8200", "Aarhus", ras_adr_1);
            Aarhus.ByAdresses.Add(ras_adr_2);
            Aarhus.ByAdresses.Add(ras_adr_3);
            Console.WriteLine("Adresser i {0}", Aarhus.Bynavn);
            foreach (var aarhusByAdress in Aarhus.ByAdresses)
            {
                Console.WriteLine("Adresse: {0}", aarhusByAdress.Vejnavn + " " + aarhusByAdress.Husnummer);
            }


            Console.WriteLine();
        }

    }
}
