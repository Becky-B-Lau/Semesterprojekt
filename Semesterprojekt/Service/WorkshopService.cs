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
            //Workshops = MockWorkshop.GetMockWorkshop();
            Workshops = JsonFileWorkshopService.GetJsonWorkshops().ToList();
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
            Workshop workshopToBeDeleted= null; //??
            foreach (Workshop workshop in Workshops) // for alle workshops i listen Workshop
            {
                if(workshop.WorkshopId == workshopId) //tjekker om workshoppens id macher det workshop id som man gerne vil slette
                {
                    workshopToBeDeleted = workshop; //hvis der er match, gem workshoppen som skal slettes
                    break; //stop loopet
                }
                
            }
            if(workshopToBeDeleted != null) // hvis den valgte workshop er fundet
            {
                Workshops.Remove(workshopToBeDeleted); // så fjernes workshoppen fra listen
                JsonFileWorkshopService.SaveJsonWorkshops(Workshops); //gemmer denne action i en jasonfil
            }
            return workshopToBeDeleted; // ellers returner den valgte workshop
        }
        ///<summary>
        ///vi starter med at angive metoden som er en deleteworkshop basseret på workshopId
        ///og så siger vi for hver workshop i listen workshop
        ///tjekker vi om id'et macher vores vaglte workshop,
        ///hvis det matcher gem den workshop
        /// -------- så for første loop finder vi workshoppen og trækker den ud-------
        /// derefter hvis den valgte workshop er fundet 
        /// slettes den vaglte workshop fra listen inde i workshops
        /// actionen bliver gemt i jasonfilen så vi ikke længere kan se den valgte workshop længere
        /// hvis ikke at den valgte workshop kunne slettet retunere den workshoppen igen 
        ///</summary>

    }
}
