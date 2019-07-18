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
            string query = "SELECT * FROM teams WHERE id = @Id";
            Team data = _db.QueryFirstOrDefault<Team>(query, new { id });
            if (data == null) throw new Exception("Invalid ID");
            return data;
        }

        public Team Create(Team value)
        {
            string query = @"
            INSERT INTO teams (name, mascot)
            VALUES (@Name, @Mascot);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(query, value);
            value.Id = id;
            return value;
        }

        public Team Update(Team value)
        {
            string query = @"
            UPDATE teams 
            SET
            name = @Name,
            mascot = @Mascot
            WHERE id = @Id ;
            SELECT * FROM teams WHERE id = @Id ;
           ";
            return _db.QueryFirstOrDefault<Team>(query, value);

        }

        public string Delete(int id)
        {
            string query = "DELETE FROM teams WHERE id = @Id;";
            int changedRows = _db.Execute(query, new { id });
            if (changedRows < 1) throw new Exception("Invalid Id");
            return "Successfully Deleted Team";
        }
    }
}