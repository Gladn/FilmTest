Create database TestFilms
use TestFilms

CREATE TABLE Film (
    FmID INT PRIMARY KEY IDENTITY,
    FmTitle VARCHAR(255) NOT NULL,
    FmYear INT NOT NULL);


CREATE TABLE Genre (
    GenID INT PRIMARY KEY IDENTITY,
    GenName VARCHAR(50) NOT NULL);


CREATE TABLE Actor (
    ActID INT PRIMARY KEY IDENTITY,
    ActName VARCHAR(255) NOT NULL);


CREATE TABLE Film_Genre (
    FmID INT,
    GenID INT,
    PRIMARY KEY (FmID, GenID),
    FOREIGN KEY (FmID) REFERENCES Film(FmID),
    FOREIGN KEY (GenID) REFERENCES Genre(GenID));


CREATE TABLE Film_Actor (
    FmID INT,
    ActID INT,
    PRIMARY KEY (FmID, ActID),
    FOREIGN KEY (FmID) REFERENCES Film(FmID),
    FOREIGN KEY (ActID) REFERENCES Actor(ActID));

--drop table Film_Actor, Film_Genre;
--drop table Actor, Genre, Film;


INSERT INTO Film (FmTitle, FmYear)
VALUES
  ('����� �� ��������', 1994),
  ('������� ����', 1972),
  ('Ҹ���� ������', 2008),
  ('������� ���� 2', 1974),
  ('12 ������������ ������', 1957),
  ('������ ��������', 1993),
  ('��������� �����: ����������� ������', 2003),
  ('������������ �����', 1994),
  ('��������� �����: �������� ������', 2001),
  ('������� ����', 1994),
  ('���������� ����', 1999),
  ('��������� �����: ��� ��������', 2002)

INSERT INTO Genre (GenName)
VALUES
  ('�����'),
  ('��������'),
  ('������'),
  ('���������'),
  ('������������ �����'),
  ('�����������'),
  ('�������'),
  ('������������� �����'),
  ('������� ����������'),
  ('�������');

INSERT INTO Actor (ActName)
VALUES
  ('��� �������'),
  ('������ ������'),
  ('��� ������'),
  ('������ ������'),
  ('��� ������'),
  ('������ ����'),
  ('�������� ����'),
  ('��� ������'),
  ('���� ������'),
  ('������ ������'),
  ('���� ������'),
  ('�� ���� ����'),
  ('���� �����'),
  ('��� �������'),
  ('���� �����'),
  ('������� ���'),
  ('����� ���������'),
  ('��� �����'),
  ('��� ���������'),
  ('������� ����'),
  ('���� ��������'),
  ('������ �. �������'),
  ('���� ������'),
  ('������ ������'),
  ('���� ����'),
  ('������ ����� ������'),
  ('������ ����'),
  ('��� �����'),
  ('����� ����'),
  ('���� �����');


INSERT INTO Film_Genre (FmID, GenID)
VALUES
(1, 1),
(2, 1),
(2, 2), 
(3, 1), 
(3, 2),
(3, 3),
(4, 1),
(4, 2),
(5, 1),
(5, 2),
(6, 1),
(6, 4),
(6, 5),
(7, 1),
(7, 3),
(7, 6),
(8, 1),
(8, 2),
(9, 1),
(9, 3),
(9, 6),
(10, 1),
(10, 8),
(11, 1),
(12, 1),
(12, 2),
(12, 6);

INSERT INTO Film_Actor (FmID, ActID)
VALUES
(1, 1),
(1, 2),
(1, 3), 
(2, 4), 
(2, 5),
(2, 6),
(3, 7), 
(3, 8),
(3, 9),
(4, 4), 
(4, 5),
(4, 6),
(5, 10), 
(5, 11),
(5, 12),
(6, 13),
(6, 14),
(6, 15),
(7, 16),
(7, 17),
(7, 18),
(7, 19),
(7, 20),
(8, 21),
(8, 22),
(8, 23),
(9, 16),
(9, 17),
(9, 18),
(9, 19),
(9, 20),
(10, 28),
(10, 29),
(10, 30),
(10, 27),
(11, 24),
(11, 25),
(11, 26),
(12, 16),
(12, 17),
(12, 18),
(12, 19),
(12, 20);

SELECT DISTINCT  F.*, 
		STRING_AGG(G.GenName, ', ') AS AllGenres
FROM Film F
JOIN Film_Genre FG ON F.FmID = FG.FmID
JOIN Genre G ON FG.GenID = G.GenID
GROUP BY F.FmID, F.FmTitle, F.FmYear;


SELECT DISTINCT  F.*, 
		STRING_AGG(G.GenName, ', ') AS AllGenres,
		STRING_AGG(A.ActName, ', ') AS AllActors
FROM Film F
JOIN Film_Genre FG ON F.FmID = FG.FmID
JOIN Genre G ON FG.GenID = G.GenID
JOIN Film_Actor FA ON F.FmID = FA.FmID
JOIN Actor A ON FA.ActID = A.ActID
GROUP BY F.FmID, F.FmTitle, F.FmYear;

