﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._2_Relation_Database.Application
{

    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public List<Adresse> Adresse { get; set; }
        public List<Telefon> Telefon { get; set; }
        public string Fornavn { get; set; }
        public string Mellemnavn { get; set; }
        public string Efternavn { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }

        public Person()
        {
            Adresse = new List<Adresse>();
            Telefon = new List<Telefon>();
        }
    }

    public class Adresse
    {
        [Key]
        public int AdresseID { get; set; }
        public string Vejnavn { get; set; }
        public string Husnummer { get; set; }
        public string Type { get; set; }
        public List<Person> Persons { get; set; }

        public Adresse()
        {
            Persons = new List<Person>();
        }
    }

    public class Telefon
    {
        [Key]
        public string Nummer { get; set; }
        public string Type { get; set; }
        public string Teleselskab { get; set; }
    }

    public class By
    {
        [Key]
        public string Postnummer { get; set; }
        public string Bynavn { get; set; }
        public List<Adresse> ByAdresses { get; set; }

        public By()
        {
            ByAdresses = new List<Adresse>();
        }
    }

    public class PersonKartotekContext : DbContext
    {
        public PersonKartotekContext() : base("name=Handin22")
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Telefon> Telefoner { get; set; }
        public DbSet<By> Byer { get; set; }

    }
}
