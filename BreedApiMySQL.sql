-- CREATE DATABASE csci495cycle6api;
USE csci495cycle6api;
-- CREATE USER 'csci495user'@'localhost' IDENTIFIED BY 'csci495pass';
GRANT ALL PRIVILEGES ON *.* TO 'csci495user'@'localhost' WITH GRANT OPTION;

DROP TABLE IF EXISTS Breeds;

CREATE TABLE Breeds (
 Name VARCHAR(100), 
 Lifespan VARCHAR(100), 
 Traits VARCHAR(200),
 CoatLength VARCHAR(50),
 PRIMARY KEY (Name)
 );
 
INSERT INTO Breeds VALUES ("Shih Tzu", "10-18 Years", "playful, affectionate, outgoing", "Long");
INSERT INTO Breeds VALUES ("Doberman", "10-13 Years", "intelligent, loyal, obedient", "Short");

