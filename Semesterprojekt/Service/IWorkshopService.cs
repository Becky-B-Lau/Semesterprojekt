﻿using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
    public interface IWorkshopService
    {

        List<Workshop> GetWorkshops();
        void AddWorkshop(Workshop workshop);

        IEnumerable<Workshop> NameSearch(string str);

        IEnumerable<Workshop> PriceFilter(int maxPrice, int minPrice = 0);

    }
}
