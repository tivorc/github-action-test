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
  public SchoolMutation(TeacherNotification teacherNotification)
  {
    Field<TeacherType>("saveTeacher")
        .Argument<NonNullGraphType<TeacherInput>>("teacher")
        .ResolveAsync(async context =>
        {
          var teacher = context.GetArgument<TeacherDTO>("teacher");

          var newTeacher = new Teacher(Guid.NewGuid(), teacher.Name);
          teacherNotification.SendNotification(newTeacher);
          return await Task.FromResult(newTeacher);
        });
  }
}