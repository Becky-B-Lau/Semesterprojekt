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

        public IEnumerable<Workshop> NameSearch(string str)
        {
            List<Workshop> nameSearch = new List<Workshop>();
            foreach (Workshop workshop in Workshops)
            {
                if (workshop.Navn.ToLower().Contains(str.ToLower()))
                {
                    nameSearch.Add(workshop);
                }
            }

            return nameSearch;
        }

        public IEnumerable<Workshop> PriceFilter(int maxPrice, int minPrice = 0)
        {
            List<Workshop> filterList = new List<Workshop>();
            foreach (Workshop workshop in Workshops)
            {
                if ((minPrice == 0 && workshop.Pris <= maxPrice) || (maxPrice == 0 && workshop.Pris >= minPrice) || (workshop.Pris >= minPrice && workshop.Pris <= maxPrice))
                {
                    filterList.Add(workshop);
                }
            }

            return filterList;
        }

    }
}
