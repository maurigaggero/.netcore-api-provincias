﻿using api_netcore_crud.Data;
using api_netcore_crud.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiPrueba.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly ApiContext context;
        public PaisesController(ApiContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pais>> Get()
        {
            return context.Paises.Include(p => p.Provincias).ToList();
        }

        [HttpGet("{id}", Name = "ObtenerPaisPorId")]
        public ActionResult<Pais> Get(int id)
        {
            var pais = context.Paises.Include(p => p.Provincias).FirstOrDefault(p => p.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            return pais;
        }

        [HttpPost]
        //public ActionResult<Pais> Post([FromBody] Pais pais)
        public async Task<ActionResult<Pais>> Post([FromBody] Pais pais)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}

            //context.Paises.Add(pais);
            //context.SaveChanges();

            await context.Paises.AddAsync(pais);
            await context.SaveChangesAsync();

            //return pais;
            return new CreatedAtRouteResult("ObtenerPaisPorId", new { id = pais.Id }, pais);
        }

        [HttpPut("{id}")]
        public ActionResult<Pais> Put(int id, [FromBody] Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest();
            }

            context.Entry(pais).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Pais> Delete(int id)
        {
            try
            {
                var pais = context.Paises.FirstOrDefault(p => p.Id == id);
                if (pais == null)
                {
                    return NotFound();
                }

                context.Paises.Remove(pais);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}