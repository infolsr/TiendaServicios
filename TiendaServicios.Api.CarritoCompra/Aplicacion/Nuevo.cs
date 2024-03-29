﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta: IRequest
        {
            public DateTime FechaCreacionSesion { get; set; }
            public List<string> ProductoLista { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoCarrito _contexto;
            private readonly IMapper _mapper;
            public Manejador(ContextoCarrito contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSesion
                {
                    FechaCreacion = request.FechaCreacionSesion
                };
                _contexto.CarritoSesion.Add(carritoSesion);
                var value = await _contexto.SaveChangesAsync();
                if (value ==0)
                {
                    throw new Exception("Error en la insercion del carrito de compras");
                }
                int id = carritoSesion.CarritoSesionID;
                foreach (var item in request.ProductoLista)
                {
                    var detalleSesion = new CarritoSesionDetalle
                    {
                        CarritoSesionID = id,
                        FechaCreacion = DateTime.Now,
                        ProductoSeleccionado = item
                    };
                    _contexto.CarritoSesionDetalle.Add(detalleSesion);
                }
                value = await _contexto.SaveChangesAsync();
                if (value > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el detalle de carrito de compra.");
            }
        }
    }
}
