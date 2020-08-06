using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Libro.Modelo
{
    public class LibreriaMaterial
    {
        public Guid? LibreriaMaterialID { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibro { get; set; }

    }
}
