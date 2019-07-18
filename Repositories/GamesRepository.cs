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

        public DataGame GetById(int id)
        {
            string query = @"
            SELECT g.id, g.homeScore, g.awayScore, 
            at.name AS AwayTeam, 
            ht.name AS HomeTeam,
            wt.name AS WinningTeam
            
            FROM games g
            JOIN teams at ON at.id = g.awayTeamId
            JOIN teams ht ON ht.id = g.homeTeamId
            JOIN teams wt ON wt.id = g.winningTeamId
            WHERE g.id = @Id";


            DataGame data = _db.QueryFirstOrDefault<DataGame>(query, new { id });
            if (data == null) throw new Exception("Invalid ID");
            return data;
        }

        public Game Create(Game value)
        {
            string query = @"
            INSERT INTO games (homeTeamId, awayTeamId)
            VALUES (@HomeTeamId, @AwayTeamId);
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

