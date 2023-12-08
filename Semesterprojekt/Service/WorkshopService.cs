using Semesterprojekt.MockData;
using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
    public class WorkshopService : IWorkshopService
    {
        public List<Workshop> Workshops { get; set; }
        private JsonFileWorkshopService JsonFileWorkshopService { get; set; }
        public WorkshopService(JsonFileWorkshopService jsonFileWorkshopService) 
        {
            JsonFileWorkshopService = jsonFileWorkshopService;
            Workshops = MockWorkshop.GetMockWorkshop();
        }

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
            JsonFileWorkshopService.SaveJsonWorkshops(Workshops);
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

        public void UpdateWorkshop(Workshop workshop)
        {
            if (workshop != null)
            {
                foreach (Workshop i in Workshops)
                {
                    if (i.WorkshopId == workshop.WorkshopId)
                    {
                        i.Navn = workshop.Navn;
                        i.Pris = workshop.Pris;
                        i.Lokation = workshop.Lokation;
                        i.Tid = workshop.Tid;
                    }
                }
                JsonFileWorkshopService.SaveJsonWorkshops(Workshops);
            }
        }
        public Workshop GetWorkshop(int id)
        {
            foreach (Workshop workshop in Workshops) 
            {
                if (workshop.WorkshopId == id) 
                {
                    return workshop;
                }
            }
            return null;
        }

        public Workshop DeleteWorkshop(int workshopId) 
        {
            Workshop workshopToBeDeleted= null;
            foreach (Workshop workshop in Workshops)
            {
                if(workshop.WorkshopId == workshopId) 
                {
                    workshopToBeDeleted = workshop;
                    break;
                }
                
            }
            if(workshopToBeDeleted != null) 
            {
                Workshops.Remove(workshopToBeDeleted);
                JsonFileWorkshopService.SaveJsonWorkshops(Workshops);
            }
            return workshopToBeDeleted;
        }

    }
}
