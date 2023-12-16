using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
    public interface IWorkshopService
    
    // interface refere til den samlig af metoder og egenskaber som difinere hvad de forskellige klasser skal gøre
    // uden at implimentere selve funtionerne for at akte som et link imellem klasserne
    {

        List<Workshop> GetWorkshops();
        public void UpdateWorkshop(Workshop workshop);
        public Workshop GetWorkshop(int id);
        public Workshop DeleteWorkshop(int id); // Sletter en Workshop baseret på det givne id og returnerer den slettede Workshop
        void AddWorkshop(Workshop workshop);

        IEnumerable<Workshop> NameSearch(string str);

        IEnumerable<Workshop> PriceFilter(int maxPrice, int minPrice = 0);

    }

}
