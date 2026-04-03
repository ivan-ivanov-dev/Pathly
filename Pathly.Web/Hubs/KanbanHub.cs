using Microsoft.AspNetCore.SignalR;

namespace Pathly.Web.Hubs
{
    public class KanbanHub: Hub
    {
        // This method will be called from JavaScript when a task drag ends in the kanban board
        public async Task NotifyTaskMoved(string taskId, int newStatus, int newPosition)
        {
            await Clients.Others.SendAsync("ReceiveTaskMove", taskId, newStatus, newPosition);
        }
    }
}
