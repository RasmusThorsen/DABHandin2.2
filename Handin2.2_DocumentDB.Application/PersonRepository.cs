using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;

namespace Handin2._2_DocumentDB.Application
{
    class PersonRepository
    {
        private DocumentClient client;
        string databaseName = "PersonKartotekDB";
        string collectionName = "PersonCollection";

        public PersonRepository(DocumentClient client)
        {
            this.client = client;
        }

        public async void CreatePerson(PersonKartotek.Person person)
        {
            try
            {
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName,
                    person.Id));
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(
                        UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), person);
                }
                else
                {
                    throw;
                }
            }
        }

        public async void DeletePerson(string persId)
        {
            await this.client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, persId));
        }

        public async void UpdatePerson(string persId, PersonKartotek.Person updatedPerson)
        {
            await this.client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, persId), updatedPerson);
        }

        public void PrintPerson(string personId)
        {
            // Set some common query options
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            // Here we find the requested person via its id
            IQueryable<PersonKartotek.Person> personQuery = this.client.CreateDocumentQuery<PersonKartotek.Person>(
                    UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), queryOptions)
                .Where(p => p.Id == personId);

            // The query is executed synchronously here, but can also be executed asynchronously via the IDocumentQuery<T> interface
            foreach (var person in personQuery)
            {
                Console.WriteLine("Person ID:\t" + person.Id);
                Console.WriteLine("Fornavn:\t" + person.Fornavn);
                Console.WriteLine("Mellemnavn: \t" + person.Mellemnavn);
                Console.WriteLine("Efternavn:\t" + person.Efternavn);
                Console.WriteLine("Email:\t" + person.Email);
                Console.WriteLine("Type:\t" + person.Type);
                Console.WriteLine("Telefoner:");
                foreach (var personTelefon in person.Telefons)
                {
                    Console.WriteLine("\tNummer: " + personTelefon.Nummer);
                    Console.WriteLine("\tTeleselskab: " + personTelefon.Teleselskab);
                    Console.WriteLine("\tType: " + personTelefon.Type);
                    Console.WriteLine();
                }
                Console.WriteLine("Adresser:");
                foreach (var personAdress in person.Adresses)
                {
                    Console.WriteLine("\t" + personAdress.Type + ": " + personAdress.Vejnavn + " " + personAdress.Husnummer);
                }
            }
        }


    }
}
