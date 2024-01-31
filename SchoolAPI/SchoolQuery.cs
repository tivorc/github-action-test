using GraphQL.Types;
using SchoolAPI.Models;
using SchoolAPI.Types;

namespace SchoolAPI;

public class SchoolQuery : ObjectGraphType
{
  public SchoolQuery()
  {
    Field<TeacherType>("teacher")
      .Argument<NonNullGraphType<IdGraphType>>("id", "Teacher id")
      .Resolve(context =>
      {
        return new Teacher(Guid.NewGuid(), "John Doe");
      });

    Field<StringGraphType>("ping")
      .Resolve(context => "pong");
  }
}