use battalion;

SELECT serviceman.name, post.name as post
FROM serviceman 
INNER JOIN post on serviceman.post_id = post.id;

SELECT serviceman.name AS Name, 
military_rank.name AS Military_Rank
FROM serviceman 
LEFT JOIN military_rank on serviceman.military_rank_id = military_rank.id; 

UPDATE absence  
LEFT JOIN serviceman on 
	serviceman.id = absence.serviceman_id
INNER JOIN absence_type on 
	absence.absence_type_id = absence_type.id
SET absence.start_date = '2021-02-21'
WHERE serviceman.name = 'Evelyn Frost'
AND absence_type.name = 'Training';

SELECT s.name, p.name AS post, mr.name AS military_rank,
ut.name AS unit_type_1, mu.name AS unit_name_1,
ut2.name AS unit_type_2, mu2.name AS unit_name_2,
ut3.name AS unit_type_3, mu3.name AS unit_name_3,
ut4.name AS unit_type_4, mu4.name AS unit_name_4
FROM military_unit AS mu
INNER JOIN serviceman AS s
	ON s.military_unit_id = mu.id
INNER JOIN unit_type AS ut
	ON mu.unit_type_id = ut.id
LEFT JOIN military_rank AS mr 
	ON s.military_rank_id = mr.id
LEFT JOIN post AS p 
	ON s.post_id = p.id
LEFT JOIN military_unit AS mu2
	ON mu.parent_unit_id = mu2.id
LEFT JOIN unit_type AS ut2
	ON mu2.unit_type_id = ut2.id
LEFT JOIN military_unit AS mu3
	ON mu2.parent_unit_id = mu3.id
LEFT JOIN unit_type AS ut3
	ON mu3.unit_type_id = ut3.id
LEFT JOIN military_unit AS mu4
	ON mu3.parent_unit_id = mu4.id
LEFT JOIN unit_type AS ut4
	ON mu4.unit_type_id = ut4.id;

SELECT ut.name AS unit_type_1, mu.name AS unit_name_1,
ut2.name AS unit_type_2, mu2.name AS unit_name_2,
ut3.name AS unit_type_3, mu3.name AS unit_name_3,
ut4.name AS unit_type_4, mu4.name AS unit_name_4,
s.name
FROM military_unit AS mu
INNER JOIN serviceman AS s
	ON s.military_unit_id = mu.id
INNER JOIN unit_type AS ut
	ON mu.unit_type_id = ut.id
LEFT JOIN military_unit AS mu2
	ON mu.parent_unit_id = mu2.id
LEFT JOIN unit_type AS ut2
	ON mu2.unit_type_id = ut2.id
LEFT JOIN military_unit AS mu3
	ON mu2.parent_unit_id = mu3.id
LEFT JOIN unit_type AS ut3
	ON mu3.unit_type_id = ut3.id
LEFT JOIN military_unit AS mu4
	ON mu3.parent_unit_id = mu4.id
LEFT JOIN unit_type AS ut4
	ON mu4.unit_type_id = ut4.id;

SELECT s.id, s.name, a.start_date,
a.end_date, at.name as reason
FROM absence AS a
LEFT JOIN serviceman AS s on
	s.id = a.serviceman_id
INNER JOIN absence_type AS at on 
	a.absence_type_id = at.id
ORDER by id;

INSERT INTO serviceman
	(name, post_id, military_rank_id, military_unit_id)
VALUES
	('Xander Hawthorne', 1, 1, 4),
    ('Zephyr Blackwood', 2, 2, 5);

SET SQL_SAFE_UPDATES = 0;

DELETE FROM serviceman
WHERE name = 'Eleanor Thompson'
OR name = 'Eleanor Hayes';

SELECT mr.name AS military_rank, p.name AS post, COUNT(a.id) AS total_absences
FROM military_unit AS mu
INNER JOIN serviceman AS s
	ON s.military_unit_id = mu.id
INNER JOIN unit_type AS ut
	ON mu.unit_type_id = ut.id
LEFT JOIN military_rank AS mr 
	ON s.military_rank_id = mr.id
LEFT JOIN post AS p 
	ON s.post_id = p.id
LEFT JOIN military_unit AS mu2
	ON mu.parent_unit_id = mu2.id
LEFT JOIN unit_type AS ut2
	ON mu2.unit_type_id = ut2.id
LEFT JOIN military_unit AS mu3
	ON mu2.parent_unit_id = mu3.id
LEFT JOIN unit_type AS ut3
	ON mu3.unit_type_id = ut3.id
LEFT JOIN military_unit AS mu4
	ON mu3.parent_unit_id = mu4.id
LEFT JOIN unit_type AS ut4
	ON mu4.unit_type_id = ut4.id
LEFT JOIN absence AS a
	ON s.id = a.serviceman_id
GROUP BY mr.name, p.name
ORDER BY mr.name;

SELECT at.name AS absence_type, COUNT(a.id) AS total_absences
FROM military_unit AS mu
INNER JOIN serviceman AS s
	ON s.military_unit_id = mu.id
INNER JOIN unit_type AS ut
	ON mu.unit_type_id = ut.id
LEFT JOIN military_unit AS mu2
	ON mu.parent_unit_id = mu2.id
LEFT JOIN unit_type AS ut2
	ON mu2.unit_type_id = ut2.id
LEFT JOIN military_unit AS mu3
	ON mu2.parent_unit_id = mu3.id
LEFT JOIN unit_type AS ut3
	ON mu3.unit_type_id = ut3.id
LEFT JOIN military_unit AS mu4
	ON mu3.parent_unit_id = mu4.id
LEFT JOIN unit_type AS ut4
	ON mu4.unit_type_id = ut4.id
LEFT JOIN absence AS a
	ON s.id = a.serviceman_id
LEFT JOIN absence_type AS at
	ON a.absence_type_id = at.id
GROUP BY at.name
ORDER BY at.name;