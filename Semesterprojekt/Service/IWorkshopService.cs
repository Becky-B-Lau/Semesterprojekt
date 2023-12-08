using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
    public interface IWorkshopService
    {

        List<Workshop> GetWorkshops();
        public void UpdateWorkshop(Workshop workshop);
        public Workshop GetWorkshop(int id);
        public Workshop DeleteWorkshop(int id);
        void AddWorkshop(Workshop workshop);

        IEnumerable<Workshop> NameSearch(string str);

        IEnumerable<Workshop> PriceFilter(int maxPrice, int minPrice = 0);

    }

}
