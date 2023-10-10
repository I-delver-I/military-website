using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MilitaryWebsite.Models;
using MySqlConnector;

namespace MilitaryWebsite.DB
{
    public class AppDb : IDisposable
    {
        private const string ConnectionString = "Server=localhost;Port=3306;Database=battalion;Uid=admin;Pwd=admin;";
        private readonly MySqlConnection _connection = new(ConnectionString);

        public async Task<List<Absence>> GetAbsentServicemenInUnit(string unitName)
        {
            var absentServicemen = new List<Absence>();
            await using var cmd = _connection.CreateCommand();

            cmd.CommandText = SqlCommands.GetAbsentServicemenInUnit(unitName);

            await _connection.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var absence = new Absence
                {
                    Id = Convert.ToInt32(reader["id"]),
                    ServicemanName = reader["name"].ToString(),
                    ServicemanId = Convert.ToInt32(reader["serviceman_id"]),
                    StartDate = Convert.ToDateTime(reader["start_date"]),
                    EndDate = Convert.ToDateTime(reader["end_date"]),
                    Reason = reader["reason"].ToString()
                };
                absentServicemen.Add(absence);
            }
            
            await _connection.CloseAsync();

            return absentServicemen;
        } 
        
        public async Task<List<string>> GetUnitNames()
        {
            var unitNames = new List<string>();

            await using var cmd = _connection.CreateCommand();
            cmd.CommandText = SqlCommands.GetUnitNames;
            
            await _connection.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                unitNames.Add(reader["name"].ToString());
            }

            await _connection.CloseAsync();
            
            return unitNames;
        }
        
        public async Task<List<Serviceman>> GetServicemenInUnit(string unitName)
        {
            var servicemen = new List<Serviceman>();
            
            await using var cmd = _connection.CreateCommand();
            cmd.CommandText = SqlCommands.GetServicemenInUnit(unitName);
            
            await _connection.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                var man = new Serviceman
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString(),
                    Post = reader["post"].ToString(),
                    Rank = reader["military_rank"].ToString(),
                    UnitType1 = reader["unit_type_1"].ToString(),
                    Unit1 = reader["unit_name_1"].ToString(),
                    UnitType2 = reader["unit_type_2"].ToString(),
                    Unit2 = reader["unit_name_2"].ToString(),
                    UnitType3 = reader["unit_type_3"].ToString(),
                    Unit3 = reader["unit_name_3"].ToString(),
                    UnitType4 = reader["unit_type_4"].ToString(),
                    Unit4 = reader["unit_name_4"].ToString()
                };
                servicemen.Add(man);
            }

            await _connection.CloseAsync();

            return servicemen;
        }
        
        public async Task<List<Serviceman>> GetServicemen()
        {
            var servicemen = new List<Serviceman>();

            await using var cmd = _connection.CreateCommand();
            cmd.CommandText = SqlCommands.GetAllServicemen;
            
            await _connection.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                var man = new Serviceman
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString(),
                    Post = reader["post"].ToString(),
                    Rank = reader["military_rank"].ToString(),
                    UnitType1 = reader["unit_type_1"].ToString(),
                    Unit1 = reader["unit_name_1"].ToString(),
                    UnitType2 = reader["unit_type_2"].ToString(),
                    Unit2 = reader["unit_name_2"].ToString(),
                    UnitType3 = reader["unit_type_3"].ToString(),
                    Unit3 = reader["unit_name_3"].ToString(),
                    UnitType4 = reader["unit_type_4"].ToString(),
                    Unit4 = reader["unit_name_4"].ToString()
                };
                servicemen.Add(man);
            }

            await _connection.CloseAsync();
            
            return servicemen;
        }

        public async Task<List<Absence>> GetAbsenceList()
        {
            var absenceList = new List<Absence>();
            await using var cmd = _connection.CreateCommand();

            cmd.CommandText = SqlCommands.GetAbsenceList;

            await _connection.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var absence = new Absence
                {
                    Id = Convert.ToInt32(reader["id"]),
                    ServicemanName = reader["name"].ToString(),
                    ServicemanId = Convert.ToInt32(reader["serviceman_id"]),
                    StartDate = Convert.ToDateTime(reader["start_date"]),
                    EndDate = Convert.ToDateTime(reader["end_date"]),
                    Reason = reader["reason"].ToString()
                };
                absenceList.Add(absence);
            }
            
            await _connection.CloseAsync();

            return absenceList;
        }

        public void Dispose() => _connection.Dispose();
    }
}