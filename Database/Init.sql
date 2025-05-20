-- init.sql
CREATE EXTENSION IF NOT EXISTS postgis;

CREATE TABLE locations (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    type TEXT,
    geom GEOGRAPHY(POINT, 4326)
);

-- Sample data
INSERT INTO locations (name, type, geom)
VALUES
('Warehouse A', 'Warehouse', ST_GeogFromText('POINT(106.8 -6.2)')),
('Office B', 'Office', ST_GeogFromText('POINT(106.9 -6.3)'));
