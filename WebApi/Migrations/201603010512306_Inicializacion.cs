namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicializacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 200),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nombre, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UsuariosRoles",
                c => new
                    {
                        UsuarioId = c.String(nullable: false, maxLength: 36),
                        RolId = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.UsuarioId, t.RolId })
                .ForeignKey("dbo.Roles", t => t.RolId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Nombres = c.String(nullable: false, maxLength: 100),
                        Apellidos = c.String(nullable: false, maxLength: 100),
                        Nivel = c.Byte(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 100),
                        EmailConfirmado = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        TokenSeguridad = c.String(),
                        Telefono = c.String(maxLength: 50),
                        TelefonoConfirmado = c.Boolean(nullable: false),
                        DobleAutenticacion = c.Boolean(nullable: false),
                        UltimoBloqueo = c.DateTime(),
                        BloqueoPermitido = c.Boolean(nullable: false),
                        TotalIntentosFallidos = c.Int(nullable: false),
                        Usuario = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Usuario, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UsuariosNotificaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.String(nullable: false, maxLength: 36),
                        Tipo = c.String(),
                        Valor = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.UsuariosLogines",
                c => new
                    {
                        Proveedor = c.String(nullable: false, maxLength: 128),
                        ProveedorToken = c.String(nullable: false, maxLength: 128),
                        UsuarioId = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.Proveedor, t.ProveedorToken, t.UsuarioId })
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuariosRoles", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuariosLogines", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuariosNotificaciones", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuariosRoles", "RolId", "dbo.Roles");
            DropIndex("dbo.UsuariosLogines", new[] { "UsuarioId" });
            DropIndex("dbo.UsuariosNotificaciones", new[] { "UsuarioId" });
            DropIndex("dbo.Usuarios", "UserNameIndex");
            DropIndex("dbo.UsuariosRoles", new[] { "RolId" });
            DropIndex("dbo.UsuariosRoles", new[] { "UsuarioId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropTable("dbo.UsuariosLogines");
            DropTable("dbo.UsuariosNotificaciones");
            DropTable("dbo.Usuarios");
            DropTable("dbo.UsuariosRoles");
            DropTable("dbo.Roles");
        }
    }
}
