CREATE DATABASE IF NOT EXISTS battalion;
use battalion;

CREATE TABLE IF NOT EXISTS post
(
id INT AUTO_INCREMENT NOT NULL,  
name CHAR(50) NOT NULL,
PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS military_rank 
(
id INT AUTO_INCREMENT NOT NULL,  
name CHAR(50) NOT NULL,
PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS unit_type 
(
id INT AUTO_INCREMENT NOT NULL,  
name CHAR(50) NOT NULL,
PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS military_unit
(
id INT AUTO_INCREMENT NOT NULL,  
name CHAR(50) NOT NULL,
unit_type_id INTEGER,
parent_unit_id INTEGER,
FOREIGN KEY fk_military_unit_id (parent_unit_id) REFERENCES military_unit(id),
FOREIGN KEY fk_unit_type_id (unit_type_id) 
	REFERENCES unit_type (id),
PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS serviceman
(
id INT AUTO_INCREMENT NOT NULL,  
name CHAR(50) NOT NULL,
post_id INTEGER NOT NULL,
military_rank_id INTEGER NOT NULL,
military_unit_id INTEGER NOT NULL,
FOREIGN KEY fk_post_id (post_id) REFERENCES post (id) ON DELETE CASCADE,
FOREIGN KEY fk_military_rank_id (military_rank_id) REFERENCES military_rank (id) ON DELETE CASCADE,
FOREIGN KEY fk_military_unit_id (military_unit_id) REFERENCES military_unit (id) ON DELETE CASCADE,
PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS absence_type
(
id INT AUTO_INCREMENT NOT NULL,  
name CHAR(50) NOT NULL,
PRIMARY KEY (id) 
);

CREATE TABLE IF NOT EXISTS absence
(
id INT AUTO_INCREMENT NOT NULL, 
start_date DATE NOT NULL,
end_date DATE NOT NULL,
serviceman_id INTEGER NOT NULL,
absence_type_id INTEGER NOT NULL,
FOREIGN KEY fk_serviceman_id (serviceman_id) REFERENCES serviceman (id) ON DELETE CASCADE,
FOREIGN KEY fk_absence_type_id (absence_type_id) REFERENCES absence_type (id) ON DELETE CASCADE,
PRIMARY KEY (id)
);

INSERT INTO unit_type(name)
VALUES
	('Military department'),
	('Troop'),
	('Squadron'),
	('Battalion');

INSERT INTO military_unit(name, unit_type_id, parent_unit_id)
VALUES
  ('Silverwood', 4, NULL),
  ('Azure Skyhawks', 3, 1),
  ('Crimson Guardians', 2, 2),
  ('Rapid Response Operations', 1, 1),
  ('Strategic Reconnaissance Division', 1, 3);
  
INSERT INTO military_rank
  (name)
VALUES
  ('Corpral'),
  ('Sergeant'),
  ('Captain'),
  ('Lieutenant');
  
INSERT INTO post
  (name)
VALUES
  ('Sniper'),
  ('Soldier'),
  ('Artilleryman'),
  ('Machine gunner');
  
INSERT INTO serviceman
  (name, post_id, military_rank_id, military_unit_id)
VALUES
  ('Eleanor Hayes', 1, 1, 4),
  ('Elena Johnson', 2, 2, 4),
  ('Evelyn Frost', 3, 3, 4),
  ('Liam Anderson', 4, 4, 4),
  ('Eleanor Thompson', 1, 2, 4),
  ('Eleanor Williams', 2, 4, 4),
  ('Lucas Mitchell', 2, 1, 5),
  ('Sofia Patel', 3, 3, 5),
  ('Jackson Ramirez', 2, 2, 5),
  ('Emily Nguyen', 1, 3, 5),
  ('Liam Johnson', 1, 4, 5),
  ('Amina Khan', 4, 3, 5);
  
INSERT INTO absence_type
  (name)
VALUES
  ('Hospital'),
  ('Vacation'),
  ('Training'),
  ('ROTC');
  
INSERT INTO absence
  (start_date, end_date, serviceman_id, absence_type_id)
VALUES
  ('2023-08-31', '2023-09-30', 1, 1),
  ('2023-08-29', '2023-09-25', 2, 2),
  ('2023-08-22', '2023-09-19', 3, 3),
  ('2023-09-14', '2023-10-05', 4, 4),
  ('2023-08-31', '2023-9-17', 7, 3),
  ('2023-09-11', '2023-09-27', 9, 1);
  
  
  

