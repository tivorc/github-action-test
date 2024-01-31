using GraphQL.Types;

namespace SchoolAPI;
public class SchoolSchema : Schema
{
  public SchoolSchema(IServiceProvider serviceProvider) : base(serviceProvider)
  {
    Query = serviceProvider.GetRequiredService<SchoolQuery>();
    Mutation = serviceProvider.GetRequiredService<SchoolMutation>();
    Subscription = serviceProvider.GetRequiredService<SchoolSubscription>();
  }
}
