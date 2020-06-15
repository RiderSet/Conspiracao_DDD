using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GBastos.Conspiracao.ViewModels;

namespace GBastos.Conspiracao.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<GBastos.Conspiracao.ViewModels.ClienteViewModel> ClienteViewModel { get; set; }
    }
}
