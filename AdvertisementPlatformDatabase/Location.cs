namespace AdvertisementPlatfornDatabase
{
	public class Location
	{
		public string Name { get; set; }
		public List<string> Platforms { get; set; } = new List<string>();
		public List<Location> Locations { get; set; } = new List<Location>();


		public Location(string name)
		{
			Name = name;
		}

		public Location(string name, List<string> platforms, List<Location> locations)
		{
			Name = name;
			Platforms = platforms;
			Locations = locations;
		}

		// BFS alghoritm for location tree
		public List<string> Select(string searchParameter)
		{
			List<string> result = new List<string>();

			Queue<Location> queue = new Queue<Location>();
			queue.Enqueue(this);

			while (queue.Count > 0)
			{
				Location temp = queue.Dequeue();

				if (temp.Name == searchParameter)
				{
					result = SelectCount(temp);
					break;
				}

				foreach (Location location in temp.Locations) queue.Enqueue(location);
			}

			return result;
		}

		private List<string> SelectCount(Location node)
		{
			List<string> result = new List<string>();

			Queue<Location> queue = new Queue<Location>();
			queue.Enqueue(node);

			while (queue.Count > 0)
			{
				Location temp = queue.Dequeue();
				result.AddRange(temp.Platforms);
				foreach (Location location in temp.Locations) queue.Enqueue(location);
			}

			return result;
		}

		public static Location operator +(Location left, Location right)
		{
			if (left.Name == right.Name)
			{
				left.Platforms = left.Platforms.Union(right.Platforms).ToList();
				foreach (var location in right.Locations)
				{
					if (left.Locations.Select(x => x.Name).Contains(location.Name))
					{
						int index = left.Locations.Select(x => x.Name).ToList().IndexOf(location.Name);
						left.Locations[index].Platforms = left.Locations[index].Platforms.Union(location.Platforms).ToList();
						left.Locations[index] += location;
					}
					else
					{
						left.Locations.Add(location);
					}
				}

				return left;
			}
			else
			{
				List<Location> locations = new List<Location>() { left, right };
				return new Location(string.Empty, [], locations);
			}
		}

		public override string ToString()
		{
			return $"Location( \"{Name}\", [ \"{string.Join("\", \"", Platforms)}\" ], [ {string.Join(", ", Locations.Select(x => x.ToString()))} ] )";
		}
	}
}
