using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Infrastructure
{
    public class ApplicationRole : IdentityRole
    {
        /// <summary>
        /// Descripcion en pocas palabras del rol y su uso.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Description { set; get; }
    }
}