using GraphQL.Types;
using SchoolAPI.Models;
using SchoolAPI.Services;
using SchoolAPI.Types;

namespace SchoolAPI;

public class SchoolSubscription : ObjectGraphType<object>
{
  public SchoolSubscription(TeacherNotification teacherNotification)
  {
    Field<TeacherType, Teacher>("teacherAdded")
      .ResolveStream(_ => teacherNotification.Notifications());
  }
}
