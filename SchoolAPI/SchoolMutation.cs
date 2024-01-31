using GraphQL;
using GraphQL.Types;
using SchoolAPI.DTO;
using SchoolAPI.InputTypes;
using SchoolAPI.Models;
using SchoolAPI.Services;
using SchoolAPI.Types;

namespace SchoolAPI;

public class SchoolMutation : ObjectGraphType
{
  public SchoolMutation(TeacherNotification teacherNotification, DatabaseConnection databaseConnection)
  {
    Field<TeacherType>("saveTeacher")
      .Argument<NonNullGraphType<TeacherInput>>("teacher")
      .ResolveAsync(async context =>
      {
        var teacher = context.GetArgument<TeacherDTO>("teacher");

        var parameters = new Dictionary<string, object>
        {
          { "name", teacher.Name }
        };
        var result = await databaseConnection.GetOne<Teacher>("teacher_insert", parameters) ?? throw new ExecutionError("Error saving teacher");

        teacherNotification.SendNotification(result);
        return await Task.FromResult(result);
      });
  }
}