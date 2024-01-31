namespace SchoolAPI.Models;

public class Teacher
{
  public Guid Id { get; set; }
  public string Name { get; set; }

  public Teacher(Guid id, string name)
  {
    Id = id;
    Name = name;
  }
}