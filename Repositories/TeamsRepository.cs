using System;
using System.Collections.Generic;
using System.Data;
using canadiansportsball.Models;
using Dapper;

namespace canadiansportsball.Repositories
{
    public class TeamRepository
    {
        private readonly IDbConnection _db;

        public TeamRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Team> GetAll()
        {
            return _db.Query<Team>("SELECT * FROM teams");
        }

        public Team GetById(int id)
        {
            string query = "SELECT * FROM teams WHERE id = @id";
            Team team = _db.QueryFirstOrDefault<Team>(query, new { id });
            if (team == null) throw new Exception("Invalid ID");
            return team;
        }

        public Team Create(Team value)
        {
            throw new NotImplementedException();
        }

        public Team Update(Team value)
        {
            throw new NotImplementedException();
        }

        public object Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}