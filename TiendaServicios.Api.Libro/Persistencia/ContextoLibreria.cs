using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Persistencia
{
    public class ContextoLibreria: DbContext
    {
        //se crea un constructor sin parametros para que funcione el unit test
        public ContextoLibreria()
        {

        }
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options)
        {
        }
        //virtual, se puede sobreescribir a futuro. varios metodos se sobre escriben con unit test
        public virtual DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
    }
}
