using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SportClub.Models;

namespace SportClub.Models
{
    //test class data
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {
            var client = new List<Client>
            {
            new Client{FName="mark",LName="loyd",Phone=252525,Adress="home",activen=true}
            };

            client.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();
        }
    }
}