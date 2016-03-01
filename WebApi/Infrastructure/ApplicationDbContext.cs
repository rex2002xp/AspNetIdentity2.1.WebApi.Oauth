using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WebApi.Infrastructure
{
    /// <summary>
    /// Contexto para interactuar con la base de datos.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// Metodo estatico para llamar nuestra clase Owin Startup
        /// </summary>
        /// <returns></returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.Id).HasColumnName("Id").HasMaxLength(36);
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.UserName).HasColumnName("Usuario").HasMaxLength(50);
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.PhoneNumber).HasColumnName("Telefono").HasMaxLength(50);
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.PhoneNumberConfirmed).HasColumnName("TelefonoConfirmado");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.Email).HasColumnName("Email").HasMaxLength(100);
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.EmailConfirmed).HasColumnName("EmailConfirmado");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.TwoFactorEnabled).HasColumnName("DobleAutenticacion");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.AccessFailedCount).HasColumnName("TotalIntentosFallidos");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.LockoutEnabled).HasColumnName("BloqueoPermitido");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.LockoutEndDateUtc).HasColumnName("UltimoBloqueo");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.SecurityStamp).HasColumnName("TokenSeguridad");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.FirstName).HasColumnName("Nombres");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.LastName).HasColumnName("Apellidos");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.Level).HasColumnName("Nivel");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios", "dbo").Property(p => p.JoinDate).HasColumnName("FechaRegistro");

            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "dbo").Property(p => p.Id).HasColumnName("Id").HasMaxLength(36);
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "dbo").Property(p => p.Name).HasColumnName("Nombre").HasMaxLength(50);
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles", "dbo").Property(p => p.Description).HasColumnName("Descripcion").HasMaxLength(200);

            modelBuilder.Entity<IdentityUserRole>().ToTable("UsuariosRoles", "dbo").Property(p => p.RoleId).HasColumnName("RolId").HasMaxLength(36);
            modelBuilder.Entity<IdentityUserRole>().ToTable("UsuariosRoles", "dbo").Property(p => p.UserId).HasColumnName("UsuarioId").HasMaxLength(35);

            modelBuilder.Entity<IdentityUserLogin>().ToTable("UsuariosLogines", "dbo").Property(p => p.UserId).HasColumnName("UsuarioId").HasMaxLength(36);
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UsuariosLogines", "dbo").Property(p => p.LoginProvider).HasColumnName("Proveedor");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UsuariosLogines", "dbo").Property(p => p.ProviderKey).HasColumnName("ProveedorToken");

            modelBuilder.Entity<IdentityUserClaim>().ToTable("UsuariosNotificaciones", "dbo").Property(p => p.ClaimType).HasColumnName("Tipo");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UsuariosNotificaciones", "dbo").Property(p => p.UserId).HasColumnName("UsuarioId").HasMaxLength(36);
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UsuariosNotificaciones", "dbo").Property(p => p.ClaimValue).HasColumnName("Valor");
        }
    }
}