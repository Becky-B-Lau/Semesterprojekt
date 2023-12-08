﻿using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
	public interface IItemService
	{
		//
		IEnumerable<Ordre> NameSearch(string str);

		List<Ordre> GetItems();
		void AddItem(Ordre item);
	}
}
