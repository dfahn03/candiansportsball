using System;
using System.Collections.Generic;
using System.Data;
using canadiansportsball.Models;
using Dapper;

namespace canadiansportsball.Repositories
{
    public class PlayerRepository
    {
        private readonly IDbConnection _db;

        public PlayerRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Player> GetAll()
        {
            return _db.Query<Player>("SELECT * FROM players");
        }

        public Player GetById(int id)
        {
            string query = "SELECT * FROM players WHERE id = @Id";
            Player data = _db.QueryFirstOrDefault<Player>(query, new { id });
            if (data == null) throw new Exception("Invalid ID");
            return data;
        }

        public Player Create(Player value)
        {
            string query = @"
            INSERT INTO players (name, teamId)
            VALUES (@Name, @TeamId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(query, value);
            value.Id = id;
            return value;
        }

        public Player Update(Player value)
        {
            string query = @"
            UPDATE players 
            SET
            name = @Name,
            teamId = @TeamId
            WHERE id = @Id ;
            SELECT * FROM players WHERE id = @Id ;
           ";
            return _db.QueryFirstOrDefault<Player>(query, value);

        }

        public string Delete(int id)
        {
            string query = "DELETE FROM players WHERE id = @Id;";
            int changedRows = _db.Execute(query, new { id });
            if (changedRows < 1) throw new Exception("Invalid Id");
            return "Successfully Deleted Player";
        }
    }
}

