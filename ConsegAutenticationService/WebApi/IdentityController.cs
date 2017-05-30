using LinxServerAuthentication.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace LinxServerAuthentication.WebApi
{

    //[Route("api/[controller]/[id]")]
    public class IdentityController : ApiController
    {

        dbContext _db = new dbContext();
        dbConsegContext _dbconseg = new dbConsegContext();

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Repository.entidadesConsegs.PESSOA> Get()
        {
            List<Repository.entidadesConsegs.MEMBRO> listMembros = _dbconseg._MEMBRO.Take(500).ToList();
            List<Repository.entidadesConsegs.PESSOA> listPessoas = _dbconseg._PESSOA.Take(500).ToList();

            var query = _dbconseg._MEMBRO.Join(_dbconseg._PESSOA, c => c.ID_PESSOA, d => d.ID_PESSOA, (c, d) => new { c, d });
                 
            List <Repository.entidades.User> listUser = _db._User.ToList();
            return listPessoas;
        }

        [HttpPost]
        public List<Repository.entidades.User> PostAtualiza(Repository.entidades.User user)
        {
            dbContext _db = new dbContext();
            List<Repository.entidades.User> listUser = _db._User.ToList();
            return listUser;
        }

        // GET api/<controller>/5
        //[HttpGet("{id}")]
        public Repository.entidadesConsegs.PESSOA Get(int id)
        {
            dbContext _db = new dbContext();
            Repository.entidadesConsegs.PESSOA Pessoas = _dbconseg._PESSOA.Where(d => d.ID_PESSOA == id).SingleOrDefault();          
            return Pessoas;
        }

    }
}