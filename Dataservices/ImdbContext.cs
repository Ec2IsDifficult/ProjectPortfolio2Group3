using System;
using System.Linq;
using System.Text;
using Dataservices.Domain;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Dataservices
{
    public class ImdbContext : DbContext
    {
        public DbSet<ImdbGenre> ImdbGenre { get; set; }
    }
}