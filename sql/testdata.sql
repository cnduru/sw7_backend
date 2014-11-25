INSERT INTO account (username, password) VALUES ('name', 'qwerty');
INSERT INTO account (username, password) VALUES ('user', '12345678');

INSERT INTO game (host_id, alias, create_time, start_time, end_time, visibility, boundary_x, boundary_y)
    VALUES (1, 'testGame', current_date, current_date, current_date, 1, 3.4, 4.3);
INSERT INTO game (host_id, alias, create_time, start_time, end_time, visibility, boundary_x, boundary_y)
    VALUES (1, 'othergame', current_date, current_date, current_date, 1, 3.4, 4.3);

INSERT INTO player (owner, game_id) VALUES (1,1);
INSERT INTO player (owner, game_id) VALUES (2,1);

