using GraphQL.Types;

namespace SchoolAPI.InputTypes;

public class TeacherInput : InputObjectGraphType
{
  public TeacherInput()
  {
    Name = "TeacherInput";
    Field<StringGraphType>("name");
  }
}