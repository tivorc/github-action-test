using GraphQL.Types;
using SchoolAPI.Models;

namespace SchoolAPI.Types;

public class TeacherType : ObjectGraphType<Teacher>
{
  public TeacherType()
  {
    Field(t => t.Id);
    Field(t => t.Name);
  }
}
