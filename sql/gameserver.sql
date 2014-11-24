﻿DROP TABLE IF EXISTS game CASCADE;
DROP TABLE IF EXISTS account CASCADE;
DROP TABLE IF EXISTS item CASCADE;
DROP TABLE IF EXISTS location CASCADE;
DROP TABLE IF EXISTS inventory CASCADE;
DROP TABLE IF EXISTS team CASCADE;
DROP TABLE IF EXISTS player CASCADE;


CREATE TABLE account
(
  id serial PRIMARY KEY, 
  username text NOT NULL
)
WITH (
  OIDS=FALSE
);
ALTER TABLE account
  OWNER TO postgres;


CREATE TABLE game
(
  id serial PRIMARY KEY, 
  host_id int NOT NULL REFERENCES account(id),
  alias text NOT NULL,
  create_time date NOT NULL,
  start_time date NOT NULL,
  end_time date NOT NULL,
  visibility int NOT NULL,
  boundary_x float NOT NULL,
  boundary_y float NOT NULL
)
WITH (
  OIDS=FALSE
);
ALTER TABLE game
  OWNER TO postgres;


CREATE TABLE item
(
  id serial PRIMARY KEY,
  item_type int NOT NULL,
  effect int NOT NULL
)
WITH (
  OIDS=FALSE
);
ALTER TABLE item
  OWNER TO postgres;


CREATE TABLE team
(
  id serial PRIMARY KEY, 
  score int NOT NULL
)
WITH (
  OIDS=FALSE
);
ALTER TABLE team
  OWNER TO postgres;


CREATE TABLE player
(
  id serial PRIMARY KEY, 
  owner int NOT NULL REFERENCES account(id),
  game_id int NOT NULL REFERENCES game(id),
  team_id int REFERENCES team(id),
  score int
)
WITH (
  OIDS=FALSE
);
ALTER TABLE player
  OWNER TO postgres;


CREATE TABLE inventory
(
  id serial PRIMARY KEY, 
  player_id int NOT NULL REFERENCES player(id),
  item_id int NOT NULL REFERENCES item(id),
  count int NOT NULL
)
WITH (
  OIDS=FALSE
);
ALTER TABLE inventory
  OWNER TO postgres;


CREATE TABLE location
(
  id serial PRIMARY KEY, 
  game_id int NOT NULL REFERENCES game(id),
  item_id int NOT NULL REFERENCES item(id),
  loc_x float NOT NULL,
  loc_y float NOT NULL,
  team_id int REFERENCES team(id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE location
  OWNER TO postgres;
