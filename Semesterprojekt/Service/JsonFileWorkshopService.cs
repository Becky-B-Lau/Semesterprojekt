using Semesterprojekt.Models;
using System.Text.Json;

namespace Semesterprojekt.Service
{
    public class JsonFileWorkshopService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public JsonFileWorkshopService(IWebHostEnvironment webHostEnvironment) 
        {
            WebHostEnvironment = webHostEnvironment;
        }
        private string JsonFileName 
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Workshop.Json"); }
        }
        public void SaveJsonWorkshops(List<Workshop> workshops)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Workshop[]>(jsonWriter, workshops.ToArray());
            }
        }
        public IEnumerable<Workshop> GetJsonWorkshops() 
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            { return JsonSerializer.Deserialize<Workshop[]>(jsonFileReader.ReadToEnd()); }
        }
    }
}
