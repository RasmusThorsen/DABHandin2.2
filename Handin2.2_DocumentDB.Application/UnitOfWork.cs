using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace Handin2._2_DocumentDB.Application
{
    class UnitOfWork
    {
        private DocumentClient client;
        private const string endPointURL = "https://localhost:8081";
        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private PersonRepository personRepository;
        public PersonRepository PersonRepository => personRepository ?? (personRepository = new PersonRepository(client));

        public UnitOfWork()
        {
            Connect().Wait();
        }

        public async Task Connect()
        {
            try
            {
                this.client = new DocumentClient(new Uri(endPointURL), PrimaryKey);
                await this.client.CreateDatabaseIfNotExistsAsync(new Database { Id = "PersonKartotekDB" });
                await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("PersonKartotekDB"),
                    new DocumentCollection { Id = "PersonCollection" });
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Console.WriteLine("Connection == true");
            }
        }
    }
}
