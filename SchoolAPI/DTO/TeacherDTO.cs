namespace SchoolAPI.DTO;
public class TeacherDTO
{
  public string Name { get; set; }

  public TeacherDTO(string name)
  {
    Name = name;
  }
}
