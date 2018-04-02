using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using System.Net;
using Microsoft.Azure.Documents;
using Newtonsoft.Json;

namespace Handin2._2_DocumentDB.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork uow = new UnitOfWork();
            uow.PersonRepository.CreatePerson(new PersonKartotek.Person
            {
                Adresses = new PersonKartotek.Adresse[]
                {
                    new PersonKartotek.Adresse() {
                        Husnummer = "100",
                        Type = "Hjem",
                        Vejnavn = "Finlandsgade"
                    }
                },
                Efternavn = "Thorsen",
                Email = "Rallethor@mal.dk",
                Fornavn = "Rasmus",
                Mellemnavn = "Østergaard",
                Id = "1",
                Type = "Studerende",
                Telefons = new PersonKartotek.Telefon[]
                {
                    new PersonKartotek.Telefon()
                    {
                        Nummer ="1234",
                        Teleselskab = "TDC",
                        Type = "Privat"
                    }
                }
            });

            //uow.PersonRepository.DeletePerson("1");
            //uow.PersonRepository.DeletePerson("2");
            uow.PersonRepository.PrintPerson("1");

            Console.ReadKey();
        }

    }
}
