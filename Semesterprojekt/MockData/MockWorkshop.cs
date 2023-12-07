using Semesterprojekt.Models;

namespace Semesterprojekt.MockData
{
    public class MockWorkshop
    {
        private static List<Workshop> workshops = new List<Workshop>()
        {
            new Workshop(1, "Festival", 22, "Roskilde", "17 December"),
            new Workshop(2, "Festival", 28, "Roskilde", "12 September"),
            new Workshop(3, "Show", 45, "Holbæk", "23 Juni")
        };

        public static List<Workshop> GetMockWorkshop()
        {
            return workshops;
        }
    }
}
