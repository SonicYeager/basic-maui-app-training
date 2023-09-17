using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People.Models;
using SQLite;

namespace People
{
    public sealed class PersonRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string _dbPath;

        public string StatusMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private SQLiteAsyncConnection _conn;

        /// <summary>
        /// 
        /// </summary>
        private async Task Init()
        {
            if (_conn != null)
                return;

            _conn = new(_dbPath);

            await _conn.CreateTableAsync<Person>();
        }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task AddNewPerson(string name)
        {
            var result = 0;
            try
            {
                // Call Init()
                await Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new("Valid name required");

                result = await _conn.InsertAsync(new Person
                {
                    Name = name,
                });

                StatusMessage = $"{result} record(s) added [Name: {name})";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to add {name}. Error: {ex.Message}";
            }
        }

        public async Task<List<Person>> GetAllPeople()
        {
            try
            {
                await Init();
                return await _conn.Table<Person>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve data. {ex.Message}";
            }

            return new();
        }
    }
}