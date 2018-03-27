using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Handin2._2_DocumentDB.Application
{
    class PersonKartotek
    {
        public class Person
        {
            [JsonProperty(PropertyName = "id")]
            public string Id { get; set; }
            public Adresse[] Adresses { get; set; }
            public Telefon[] Telefons { get; set; }
            public string Fornavn { get; set; }
            public string Mellemnavn { get; set; }
            public string Efternavn { get; set; }
            public string Type { get; set; }
            public string Email { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }

        public class Adresse
        {
            public string Vejnavn { get; set; }
            public string Husnummer { get; set; }
            public string Type { get; set; }
            public By By { get; set; }
        }

        public class Telefon
        {
            public string Nummer { get; set; }
            public string Type { get; set; }
            public string Teleselskab { get; set; }
        }

        public class By
        {
            public string Postnummer { get; set; }
            public string Bynavn { get; set; }
            public Adresse[] ByAdresses { get; set; }
        }

    }
}
