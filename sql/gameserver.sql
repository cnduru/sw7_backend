DROP TABLE IF EXISTS game CASCADE;
DROP TABLE IF EXISTS account CASCADE;
DROP TABLE IF EXISTS item CASCADE;
DROP TABLE IF EXISTS location CASCADE;
DROP TABLE IF EXISTS inventory CASCADE;
DROP TABLE IF EXISTS team CASCADE;
DROP TABLE IF EXISTS player CASCADE;
DROP TABLE IF EXISTS status_effect;


CREATE TABLE account
(
  id serial PRIMARY KEY, 
  username varchar(10) NOT NULL UNIQUE,
  password varchar(10) NOT NULL
)
WITH (
  OIDS=TRUE
);
ALTER TABLE account
  OWNER TO cornfield;


CREATE TABLE game
(
  id serial PRIMARY KEY, 
  host_id int NOT NULL REFERENCES account(id),
  visibility int NOT NULL,
  alias varchar(10) NOT NULL UNIQUE,
  create_time timestamp NOT NULL,
  start_time timestamp NOT NULL,
  end_time timestamp NOT NULL,
  boundary_nw_x float NOT NULL,
  boundary_nw_y float NOT NULL,
  boundary_se_x float NOT NULL,
  boundary_se_y float NOT NULL
)
WITH (
  OIDS=TRUE
);
ALTER TABLE game
  OWNER TO cornfield;


CREATE TABLE item
(
  id serial PRIMARY KEY,
  item_type int NOT NULL,
  effect int NOT NULL
)
WITH (
  OIDS=TRUE
);
ALTER TABLE item
  OWNER TO cornfield;


CREATE TABLE team
(
  id serial PRIMARY KEY, 
  score int NOT NULL
)
WITH (
  OIDS=TRUE
);
ALTER TABLE team
  OWNER TO cornfield;


CREATE TABLE player
(
  id serial PRIMARY KEY, 
  owner int NOT NULL REFERENCES account(id),
  game_id int NOT NULL REFERENCES game(id),
  team_id int REFERENCES team(id),
  score int,
  loc_x float,
  loc_y float
)
WITH (
  OIDS=TRUE
);
ALTER TABLE player
  OWNER TO cornfield;


CREATE TABLE inventory
(
  id serial PRIMARY KEY, 
  player_id int NOT NULL REFERENCES player(id),
  item_id int NOT NULL REFERENCES item(id),
  count int NOT NULL
)
WITH (
  OIDS=TRUE
);
ALTER TABLE inventory
  OWNER TO cornfield;


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
  OIDS=TRUE
);
ALTER TABLE location
  OWNER TO cornfield;

CREATE TABLE status_effect
(
  id serial PRIMARY KEY, 
  player_id int NOT NULL REFERENCES player(id),
  effect int NOT NULL,
  effect_value int, 
  end_time timestamp
)
WITH (
  OIDS=TRUE
);
ALTER TABLE status_effect
  OWNER TO cornfield;
