using static MotorRepair.Client.Constants;

namespace MotorRepair.Client
{
  public static class Constants
  {
    #region Tickets
    public struct WebServiceRoutes {
      public const string GetAllTickets = "/api/ticket";
      public const string GetTicketById = "/api/ticket/{0}";
      public const string CreateTicket = "/api/ticket";
      public const string UpdateTicket = "/api/ticket";
      public const string DeleteTicket = "/api/ticket/{0}";

      public const string GetAllWorkItems = "/api/workitems";
      public const string GetWorkItemById = "/api/workitems/{0}";
      public const string GetWorkItemByParentTicket = "/api/workitems/parentticket/{0}";
      public const string CreateWorkItem = "/api/workitems";
      public const string UpdateWorkItem = "/api/workitems";
      public const string DeleteWorkItem = "/api/workitems/{0}";
    }

    public struct TicketStatuses {
      public const string TODO = "TODO";
      public const string IN_PROGRESS = "IN PROGRESS";
      public const string DONE = "DONE";
    }

    public struct WorkItemTypes {
      public const string LABOR = "LABOR";
      public const string PART = "PART";
    }

    public static List<string> TicketStatuseList = new List<string> { TicketStatuses.TODO, TicketStatuses.IN_PROGRESS, TicketStatuses.DONE };

    public static List<string> WorkItemTypeList = new List<string> { WorkItemTypes.LABOR, WorkItemTypes.PART };
    #endregion
  }
}
