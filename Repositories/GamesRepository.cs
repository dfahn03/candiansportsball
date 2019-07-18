using System;
using System.Collections.Generic;
using System.Data;
using canadiansportsball.Models;
using Dapper;

namespace canadiansportsball.Repositories
{
    public class GameRepository
    {
        private readonly IDbConnection _db;

        public GameRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Game> GetAll()
        {
            return _db.Query<Game>("SELECT * FROM games");
        }

        public Game GetById(int id)
        {
            string query = "SELECT * FROM games WHERE id = @Id";
            Game data = _db.QueryFirstOrDefault<Game>(query, new { id });
            if (data == null) throw new Exception("Invalid ID");
            return data;
        }

        public Game Create(Game value)
        {
            string query = @"
            INSERT INTO games (homeTeamId, awayTeamId, winningTeamId, homeScore, awayScore)
            VALUES (@HomeTeamId, @AwayTeamId, @WinningTeamId, @HomeScore, @AwayScore);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(query, value);
            value.Id = id;
            return value;
        }

        public Game Update(Game value)
        {
            string query = @"
            UPDATE games 
            SET
            homeTeamId = @HomeTeamId,
            awayTeamId = @AwayTeamId,
            winningTeamId = @WinningTeamId,
            homeScore = @HomeScore,
            awayScore = @AwayScore
            WHERE id = @Id ;
            SELECT * FROM games WHERE id = @Id ;
           ";
            return _db.QueryFirstOrDefault<Game>(query, value);

        }

        public string Delete(int id)
        {
            string query = "DELETE FROM games WHERE id = @Id;";
            int changedRows = _db.Execute(query, new { id });
            if (changedRows < 1) throw new Exception("Invalid Id");
            return "Successfully Deleted Game";
        }
    }
}

