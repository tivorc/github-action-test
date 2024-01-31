using System.Reactive.Linq;
using System.Reactive.Subjects;
using SchoolAPI.Models;

namespace SchoolAPI.Services;

public class TeacherNotification
{
  private readonly Subject<Teacher> _teacherStream = new();

  public void SendNotification(Teacher teacher)
  {
    _teacherStream.OnNext(teacher);
  }

  public IObservable<Teacher> Notifications()
  {
    return _teacherStream.AsObservable();
  }
}
