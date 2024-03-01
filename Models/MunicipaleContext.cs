using Microsoft.EntityFrameworkCore;
using Municipale.Models;


public class MunicipaleContext : DbContext
{
    public MunicipaleContext(DbContextOptions<MunicipaleContext> options) : base(options)
    {
    }

    public DbSet<Agente> Agenti { get; set; }
    public DbSet<Anagrafica> Anagrafica { get; set; }
    public DbSet<TipoViolazione> TipoViolazione { get; set; }
    public DbSet<Verbale> Verbali { get; set; }
}