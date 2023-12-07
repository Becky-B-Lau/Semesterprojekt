using Semesterprojekt.MockData;
using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
    public class WorkshopService : IWorkshopService
    {
        public List<Workshop> Workshops { get; set; }

        public WorkshopService()
        {
            Workshops = MockWorkshop.GetMockWorkshop();
        }

        public List<Workshop> GetWorkshops()
        {
            return Workshops;
        }

        public void AddWorkshop(Workshop workshop)
        {
            Workshops.Add(workshop);
        }

    }
}
