using SQLite;

namespace People.Models;

[Table("people")]
public sealed class Person
{
    [PrimaryKey] [AutoIncrement] public int Id { get; set; }

    [MaxLength(250)] [Unique] public string Name { get; set; }
}