using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransporteArequipaAPI.Data;
using TransporteArequipaAPI.Models;

namespace TransporteArequipaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VehiculosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Vehiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculos()
        {
            // Solo traemos los activos y ordenados por año (más nuevos primero)
            return await _context.Vehiculos
                .Where(v => v.EstaActivo == true)
                .OrderByDescending(v => v.AnioFabricacion)
                .ToListAsync();
        }

        // GET: api/Vehiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);

            if (vehiculo == null || !vehiculo.EstaActivo)
            {
                return NotFound();
            }

            return vehiculo;
        }

        // NUEVO MÉTODO: GET: api/Vehiculos/BuscarPorRuta/Trujillo
        [HttpGet("BuscarPorRuta/{ruta}")]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculosPorRuta(string ruta)
        {
            return await _context.Vehiculos
                .Where(v => v.EstaActivo == true && v.RutaActual.Contains(ruta))
                .ToListAsync();
        }

        // PUT: api/Vehiculos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculo(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vehiculos
        [HttpPost]
        public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo vehiculo)
        {
            // Validación de placa duplicada
            var existe = await _context.Vehiculos.AnyAsync(v => v.Placa == vehiculo.Placa);
            if (existe)
            {
                return BadRequest("Error: Ya existe un vehículo registrado con esta placa.");
            }

            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculo", new { id = vehiculo.Id }, vehiculo);
        }

        // DELETE: api/Vehiculos/5 (ELIMINACIÓN LÓGICA)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            // En lugar de borrar de la DB, solo lo desactivamos
            vehiculo.EstaActivo = false;
            _context.Entry(vehiculo).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculos.Any(e => e.Id == id);
        }
    }
}
