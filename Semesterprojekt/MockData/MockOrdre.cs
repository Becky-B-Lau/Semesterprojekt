﻿using Semesterprojekt.Models;

namespace Semesterprojekt.MockData
{
	public class MockOrdre
	{		
		private static List<Ordre> items = new List<Ordre>()
		{
			
			new Ordre(dateTime: new DateTime(2015, 12, 25, 10, 23, 23), kunde: new Kunde("Bo Jacobsen", 29, 13877987, "Toftebakkevej 9b, 2500 Valby", "cla@mail.com", "Erhverv"),"Jeg vil have portræt", billeder: new Billeder(4000))

		};

		public static List<Ordre> GetMockOrdre()
		{
			return items;
		}
	
	}
}
