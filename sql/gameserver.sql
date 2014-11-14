DROP TABLE IF EXISTS game CASCADE;
DROP TABLE IF EXISTS player CASCADE;
DROP TABLE IF EXISTS item CASCADE;
DROP TABLE IF EXISTS item_instance CASCADE;
DROP TABLE IF EXISTS has_item CASCADE;
DROP TABLE IF EXISTS team CASCADE;
DROP TABLE IF EXISTS player_game_info CASCADE;


CREATE TABLE player
(
  id serial PRIMARY KEY, 
  username text NOT NULL
)
WITH (
  OIDS=FALSE
);
ALTER TABLE player
  OWNER TO postgres;


CREATE TABLE game
(
  id serial PRIMARY KEY, 
  host_id int NOT NULL REFERENCES player(id),
  alias text NOT NULL,
  create_time date NOT NULL,
  start_time date NOT NULL,
  end_time date NOT NULL,
  invisibility int NOT NULL,
  boundary_x float NOT NULL,
  boundary_y float NOT NULL
)
WITH (
  OIDS=FALSE
);
ALTER TABLE game
  OWNER TO postgres;


CREATE TABLE team
(
  id serial PRIMARY KEY, 
  points int NOT NULL
)
WITH (
  OIDS=FALSE
);
ALTER TABLE team
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


CREATE TABLE item_instance
(
  id serial PRIMARY KEY, 
  game_id int NOT NULL REFERENCES game(id),
  item_id int NOT NULL REFERENCES item(id),
  loc_x float NOT NULL,
  loc_y float NOT NULL,
  team_id int NOT NULL REFERENCES team(id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE item_instance
  OWNER TO postgres;


CREATE TABLE player_game_info
(
  id serial PRIMARY KEY, 
  player_id int NOT NULL REFERENCES player(id),
  team_id int NOT NULL REFERENCES team(id),
  game_id int NOT NULL REFERENCES game(id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE player_game_info
  OWNER TO postgres;
  

CREATE TABLE has_item
(
  id serial PRIMARY KEY, 
  player_game_info_id int NOT NULL REFERENCES player_game_info(id),
  item_id int NOT NULL REFERENCES item(id),
  count int NOT NULL
)
WITH (
  OIDS=FALSE
);
ALTER TABLE has_item
  OWNER TO postgres;
