using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Property.Domain.Models;

namespace Property.Context
{
    /// <summary>
    /// Clase que genera el contexto hacia BD.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Constructor propio de la clase DBcontext
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Refiere a la tabla Property
        /// </summary>
        public DbSet<Property.Domain.Models.PropertyRepository> Property { get; set; }

        /// <summary>
        /// Refiere a la tabla Owner
        /// </summary>
        public DbSet<Owner> Owner { get; set; }

        /// <summary>
        ///Rfiere a la tabla PropertyTrace
        /// </summary>
        public DbSet<PropertyTrace> PropertyTrace { get; set; }

        /// <summary>
        /// Refiere a la tabla PropertyImage
        /// </summary>
        public DbSet<PropertyImage> PropertyImage { get; set; }

    }
}
