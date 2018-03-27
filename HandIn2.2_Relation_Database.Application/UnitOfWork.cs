using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._2_Relation_Database.Application
{
    class UnitOfWork
    {
        private PersonKartotekContext context = new PersonKartotekContext();
        private PersonRepository personRepository;
        private AdresseRepository adresseRepository;
        private TelefonRepository telefonRepository;
        private ByRepository byRepository;

        public PersonRepository PersonRepository
        {
            get { return this.personRepository ?? (personRepository = new PersonRepository(context)); }
        }

        public AdresseRepository AdresseRepository
        {
            get { return this.adresseRepository ?? (adresseRepository = new AdresseRepository(context)); }
        }

        public TelefonRepository TelefonRepository
        {
            get { return this.telefonRepository ?? (telefonRepository = new TelefonRepository(context)); }
        }

        public ByRepository ByRepository
        {
            get { return this.byRepository ?? (byRepository = new ByRepository(context)); }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
