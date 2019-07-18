USE canadianball;

-- teams
-- CREATE TABLE teams 
-- (
--     id INT AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     mascot VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- );

-- players
-- CREATE TABLE players 
-- (
--     id INT AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     teamId INT NOT NULL,

--     FOREIGN KEY (teamId)
--         REFERENCES teams(id),

--     PRIMARY KEY (id)
-- );

-- DELETE FROM teams
-- WHERE id = @id;
-- UPDATE players
-- SET teamId = 0
-- WHERE teamId = @id;

-- games
-- DROP TABLE games;
-- CREATE TABLE games 
-- (
--     id INT AUTO_INCREMENT,
--     homeTeamId INT NOT NULL,
--     awayTeamId INT NOT NULL,
--     winningTeamId INT,
--     homeScore INT,
--     awayScore INT,

--     INDEX(homeTeamId, awayTeamId),

--     FOREIGN KEY (homeTeamId)
--         REFERENCES teams(id),

--     FOREIGN KEY (awayTeamId)
--         REFERENCES teams(id),

--     FOREIGN KEY (winningTeamId)
--         REFERENCES teams(id),

--     PRIMARY KEY (id)
-- );