using Semesterprojekt.Models;
using System.Text.Json;

namespace Semesterprojekt.Service
{
	public class JasonFileOrdreService
	{
		public IWebHostEnvironment WebHostEnvironment { get; }


		public JasonFileOrdreService(IWebHostEnvironment webHostEnvironment)
		{
			WebHostEnvironment = webHostEnvironment;
		}

		private string JsonFileName
		{
			get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Ordre.json"); }
		}

		public void SaveJsonOrdre(List<Ordre> ordre)
		{
			using (FileStream jsonFileWriter = File.Create(JsonFileName))
			{
				Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
				{
					SkipValidation = false,
					Indented = true
				});
				JsonSerializer.Serialize<Ordre[]>(jsonWriter, ordre.ToArray());
			}
		}

		public IEnumerable<Ordre> GetJsonOrdre()
		{
			using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
			{
				return JsonSerializer.Deserialize<Ordre[]>(jsonFileReader.ReadToEnd());
			}
		}
	}
}
