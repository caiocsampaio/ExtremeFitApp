using ExtremeFit.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExtremeFit.Repository.DataContext
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options){}

        public DbSet<AlternativaDomain> Alternativas { get; set; }
        public DbSet<AtletaDomain> Atletas { get; set; }
        public DbSet<DadosFuncionarioDomain> DadosFuncionarios { get; set; }
        public DbSet<DicaDomain> Dicas { get; set; }
        public DbSet<EmpresaDomain> Empresas { get; set; }
        public DbSet<EspecialistaDomain> Especialistas { get; set; }
        public DbSet<EventoDomain> Eventos { get; set; }
        public DbSet<FuncionarioDomain> Funcionarios { get; set; }
        public DbSet<FuncionarioUnidadeSesiDomain> FuncionariosUnidadesFavoritas { get; set; }
        public DbSet<IntensidadeDorDomain> IntensidadeDores { get; set; }
        public DbSet<LocalDorDomain> LocalDores { get; set; }
        public DbSet<PerguntaDomain> Perguntas { get; set; }
        public DbSet<PermissaoDomain> Permissoes { get; set; }
        public DbSet<PesquisaDomain> Pesquisas { get; set; }
        public DbSet<RelatorioDorDomain> Relatorios { get; set; }
        public DbSet<UnidadeFavoritaDomain> UnidadesSesi { get; set; }
        public DbSet<UsuarioDomain> Usuarios { get; set; }
        public DbSet<UsuarioPermissaoDomain> UsuariosPermissoes { get; set; }
    }
}