using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CBIB.Models
{
    public class CBIBContext : DbContext
    {
        public CBIBContext (DbContextOptions<CBIBContext> options)
            : base(options)
        {
        }

        public DbSet<CBIB.Models.ResearchInfo> ResearchInfo { get; set; }
    }
}
