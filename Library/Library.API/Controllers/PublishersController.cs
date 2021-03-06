﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.API.Models;
using Library.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Unit.Publishers.Get().Select(x => Factory.Create(x)).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                Publisher publisher = Unit.Publishers.Get(id);
                if (publisher == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Factory.Create(publisher));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Publishers
        [HttpPost]
        public ActionResult Post([FromBody] Publisher publisher)
        {
            try
            {
                Unit.Publishers.Insert(publisher);
                Unit.Save();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Publishers/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Publisher publisher)
        {
            try
            {
                Unit.Publishers.Update(publisher, id);
                Unit.Save();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Publisher publisher = Unit.Publishers.Get(id);
                if (publisher == null)
                {
                    return NotFound();
                }
                else
                {
                    Unit.Publishers.Delete(publisher);
                    Unit.Save();
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}