using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personkartotek
{
    public class Person
    {
        public List<Adresse> Adresse = new List<Adresse>();
        public List<Telefon> Telefon = new List<Telefon>();
        public string Fornavn { get; set; }
        public string Mellemnavn { get; set; }
        public string Efternavn { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }

        public Person(string fornavn, string mellemnavn, string efternavn, string type, Adresse adresse,
            Telefon telefon, string email = " ")
        {
            Fornavn = fornavn;
            Mellemnavn = mellemnavn;
            Efternavn = efternavn;
            Type = type;
            Email = email;
            Adresse.Add(adresse);
            Telefon.Add(telefon);
        }

    }

    public class Adresse
    {
        public string Vejnavn { get; set; }
        public string Husnummer { get; set; }
        public List<Person> Beboere = new List<Person>();
        public Adresse(string vejnavn, string husnummer, Person person = null)
        {
            Vejnavn = vejnavn;
            Husnummer = husnummer;
            if(person != null) Beboere.Add(person);
        }
        
    }

    
    public class PersonAdresse
    {
        public Person Personer { get; set; }
        public Adresse Adresser { get; set; }
        public string AdresseType { get; set; }

        public PersonAdresse(Person pers, Adresse adr, string type)
        {
            Personer = pers;
            Adresser = adr;
            AdresseType = type;
        }      
    }
    

    public class Telefon
    {
        public string Nummer { get; set; }
        public string Type { get; set; }
        public string Teleselskab { get; set; }
        public Telefon(string nummer, string type, string teleselskab)
        {
            Nummer = nummer;
            Type = type;
            Teleselskab = teleselskab;
        }

    }

    public class By
    {
        public string Postnummer { get; set; }
        public string Bynavn { get; set; }
        public List<Adresse> ByAdresses = new List<Adresse>();
        public By(string postnummer, string bynavn, Adresse byAdresse)
        {
            Postnummer = postnummer;
            Bynavn = bynavn;
            ByAdresses.Add(byAdresse);
        }

    }
}
