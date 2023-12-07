using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
    public interface IWorkshopService
    {

        List<Workshop> GetWorkshops();
        void AddWorkshop(Workshop workshop);

    }
}
