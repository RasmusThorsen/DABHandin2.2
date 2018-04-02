using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandIn2._2_Relation_Database;
using System.Data.Entity;

namespace HandIn2._2_Relation_Database.Application
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var adressePrivat = new Adresse {Husnummer = "9E", Vejnavn = "Brendstrupsgårdsvej", Type = "Privat"};
            UnitOfWork uow = new UnitOfWork();
            uow.PersonRepository.Insert(new Person { Fornavn = "Nicolai", Efternavn = "Andersen", Email = "TestMail@emial.dk", Type = "Studerende" });
            uow.PersonRepository.GetById(0).Telefon.Add(new Telefon { Nummer = "6", Teleselskab = "TDC", Type = "Privat" });
            uow.PersonRepository.GetById(0).Adresse.Add(adressePrivat);
            uow.PersonRepository.GetById(0).Adresse.Add(new Adresse { Husnummer = "22", Vejnavn = "Finlandsgade", Type = "Skole" });

            //uow.PersonRepository.GetById(1).Telefon.Add(new Telefon { Nummer = "7", Teleselskab = "TDC", Type = "Arbejde" });

            //uow.PersonRepository.GetById(1).Telefon.Add(new Telefon { Nummer = "609", Teleselskab = "TDC", Type = "Privat" });
            //uow.PersonRepository.GetById(0).Adresse.Add(adressePrivat);
            //uow.PersonRepository.GetById(1).Adresse.Add(new Adresse { Husnummer = "22", Vejnavn = "Finlandsgade", Type = "Test" });

            //uow.ByRepository.Insert(new By{Bynavn = "Aarhus", Postnummer = "8000"});
            //uow.ByRepository.GetById(8000).ByAdresses.Add(adressePrivat);

            uow.Save();

           // Console.WriteLine(uow.PersonRepository.GetById(1).Adresse[0].Vejnavn);
        }
    }

   
}
