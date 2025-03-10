using Microsoft.AspNetCore.Mvc;

namespace AdvertisementPlatfornDatabase.Controllers
{
	[ApiController]
	[Route("api/v1")]
	public class LocationController : ControllerBase
	{
		private readonly ILogger<LocationController> _logger;
		private static Location root = null;


		public LocationController(ILogger<LocationController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<string> Get(string location)
		{
			List<string> platforms = new List<string>();

			platforms = root.Select(location);

			return platforms;
		}

		[HttpPost]
		public int Set(IFormFile file)
		{
			root = null;
			if (file == null) return 0;

			string[] permittedExtentions = [".txt"];
			int objectCounter = 0;

			string ext = Path.GetExtension(file.FileName).ToLowerInvariant();

			if (string.IsNullOrEmpty(ext) || !permittedExtentions.Contains(ext))
			{
				return objectCounter;
			}


			using (StreamReader sr = new StreamReader(file.OpenReadStream()))
			{
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine(); // read one line from file

					string[] nameLocations = line!.Split(":", StringSplitOptions.RemoveEmptyEntries); // split line -> platform name, locations (as one string)
					if (nameLocations.Length < 2) return 0;
					string adPlatformName = nameLocations[0];

					string[] locations = nameLocations[1].Split(",", StringSplitOptions.RemoveEmptyEntries); // split location string into separate locations -> location 1, location 2, ...
					if (locations.Length < 1) return 0;

					// create temp tree
					foreach (string location in locations)
					{
						string[] splittedlocations = location.Split("/", StringSplitOptions.RemoveEmptyEntries); // split location into elements | /ru/srvd/revda -> ru, srvd, revda
						if (splittedlocations.Length < 1) return 0;
						List<Location> newTreeLocations = new List<Location>();
						foreach (var splittedLocation in splittedlocations)
						{
							Location newLocation = new Location(splittedLocation);
							if (splittedLocation == splittedlocations.Last()) newLocation.Platforms.Add(adPlatformName);

							newTreeLocations.Add(newLocation);
						}

						for (int i = 0; i < newTreeLocations.Count - 1; i++) newTreeLocations[i].Locations.Add(newTreeLocations[i + 1]);
						
						if (root == null) root = newTreeLocations.First();
						else root += newTreeLocations.First();

					}
					objectCounter++;
				}
			}

			return objectCounter;
		}
	}
}
