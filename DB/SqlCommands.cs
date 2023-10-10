namespace MilitaryWebsite.DB
{
    public static class SqlCommands
    {
        public const string GetUnitNames = "SELECT mu.name FROM military_unit AS mu";
        
        public const string GetAllServicemen = 
            @"SELECT s.id, s.name, p.name AS post, mr.name AS military_rank, 
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
					ON mu4.unit_type_id = ut4.id";

        public const string GetAbsenceList = 
            @"SELECT s.id as id,
                s.name as name,
                a.serviceman_id AS serviceman_id,
                a.start_date as start_date,
                a.end_date as end_date,
                at.name as reason
                FROM absence AS a
                LEFT JOIN serviceman AS s on
	                s.id = a.serviceman_id
                INNER JOIN absence_type AS at on 
	                a.absence_type_id = at.id;";

        public static string GetAbsentServicemenInUnit(string unitName) =>
            $@"SELECT s.id as id,
                s.name as name,
                a.serviceman_id AS serviceman_id,
                a.start_date as start_date,
                a.end_date as end_date,
                at.name as reason
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
                INNER JOIN absence a ON s.id = a.serviceman_id
                INNER JOIN absence_type AS at ON 
	                a.absence_type_id = at.id
                WHERE mu.name = '{unitName}' OR mu2.name = '{unitName}' 
                   OR mu3.name = '{unitName}' OR mu4.name = '{unitName}'";
        
        public static string GetServicemenInUnit(string unitName) => 
            $@"SELECT s.id, s.name, p.name AS post, mr.name AS military_rank, 
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
					ON mu4.unit_type_id = ut4.id
                WHERE mu.name = '{unitName}' OR mu2.name = '{unitName}' 
                   OR mu3.name = '{unitName}' OR mu4.name = '{unitName}'";
    }
}