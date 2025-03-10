using AdvertisementPlatfornDatabase;

namespace AdvertisementPlatformDatabase.Tests
{
	public class UnitTest1
	{
		[Fact]
		public void Sum3LevelTree()
		{
			Location left = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"msk",
						new List<string>() {  },
						new List<Location>()
						{
							new Location
							(
								"btv",
								new List<string>() { "1" },
								new List<Location>() { }
							)
						})
				}
			);


			Location right = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"msk",
						new List<string>() {  },
						new List<Location>()
						{
							new Location
							(
								"cherb",
								new List<string>() { "2" },
								new List<Location>() { }
							)
						})
				}
			);

			Location expected = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"msk",
						new List<string>() {  },
						new List<Location>()
						{
							new Location
							(
								"btv",
								new List<string>() { "1" },
								new List<Location>() { }
							),
							new Location
							(
								"cherb",
								new List<string>() { "2" },
								new List<Location>() { }
							)
						})
				}
			);

			Location actual = left + right;

			Assert.Equal(expected.ToString(), actual.ToString());
		}

		[Fact]
		public void Sum2LevelTree()
		{
			Location left = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"srvd",
						new List<string>() { "2" },
						new List<Location>() { }
					)
				}
			);


			Location right = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"msk",
						new List<string>() { "1" },
						new List<Location>() { }
					)
				}
			);

			Location expected = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"srvd",
						new List<string>() { "2" },
						new List<Location>() { }
					),
					new Location
					(
						"msk",
						new List<string>() { "1" },
						new List<Location>() { }
					)

				}
			);

			Location actual = left + right;

			Assert.Equal(expected.ToString(), actual.ToString());
		}

		[Fact]
		public void Sum1LevelTree()
		{
			var left = new Location
				(
					"srvd",
					new List<string>() { "2" },
					new List<Location>() { }
				);
			var right = new Location
				(
					"msk",
					new List<string>() { "1" },
					new List<Location>() { }
				);

			Location expected = new Location
			(
				"",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"srvd",
						new List<string>() { "2" },
						new List<Location>() { }
					),
					new Location
					(
						"msk",
						new List<string>() { "1" },
						new List<Location>() { }
					)

				}
			);

			Location actual = left + right;

			Assert.Equal(expected.ToString(), actual.ToString());
		}

		[Fact]
		public void SumUnequalTrees()
		{
			Location left = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"msk",
						new List<string>() {  },
						new List<Location>()
						{
							new Location
							(
								"btv",
								new List<string>() { "1" },
								new List<Location>() { }
							)
						})
				}
			);

			Location right = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"srvd",
						new List<string>() { "2" },
						new List<Location>() { }
					)
				}
			);

			Location expected = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"msk",
						new List<string>() {  },
						new List<Location>()
						{
							new Location
							(
								"btv",
								new List<string>() { "1" },
								new List<Location>() { }
							)
						}
					),
					new Location
					(
						"srvd",
						new List<string>() { "2" },
						new List<Location>() { }
					)
				}
			);

			Location actual = left + right;

			Assert.Equal(expected.ToString(), actual.ToString());
		}

		[Fact]
		public void SumTreeToOnlyRoot()
		{
			Location left = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"msk",
						new List<string>() {  },
						new List<Location>()
						{
							new Location
							(
								"btv",
								new List<string>() { "1" },
								new List<Location>() { }
							)
						})
				}
			);

			Location right = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>() { }
			);

			Location expected = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"msk",
						new List<string>() {  },
						new List<Location>()
						{
							new Location
							(
								"btv",
								new List<string>() { "1" },
								new List<Location>() { }
							)
						}
					)
				}
			);

			Location actual = left + right;

			Assert.Equal(expected.ToString(), actual.ToString());
		}

		[Fact]
		public void SumTreeToOnlyRootInverted()
		{
			Location left = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>() { }
			);

			Location right = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"msk",
						new List<string>() {  },
						new List<Location>()
						{
							new Location
							(
								"btv",
								new List<string>() { "1" },
								new List<Location>() { }
							)
						})
				}
			);

			Location expected = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"msk",
						new List<string>() {  },
						new List<Location>()
						{
							new Location
							(
								"btv",
								new List<string>() { "1" },
								new List<Location>() { }
							)
						}
					)
				}
			);

			Location actual = left + right;

			Assert.Equal(expected.ToString(), actual.ToString());
		}

		[Fact]
		public void SumUnequalTreeWithPlatforms()
		{
			Location left = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"svrd",
						new List<string>() {  },
						new List<Location>()
						{
							new Location
							(
								"pervik",
								new List<string>() { "Ревдинский рабочий" },
								new List<Location>() { }
							)
						})
				}
			);

			Location right = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"svrd",
						new List<string>() { "Крутая реклама" },
						new List<Location>() {  }
					)
				}
			);

			Location expected = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"svrd",
						new List<string>() { "Крутая реклама" },
						new List<Location>()
						{
							new Location
							(
								"pervik",
								new List<string>() { "Ревдинский рабочий" },
								new List<Location>() { }
							)
						})
				}
			);

			Location actual = left + right;

			Console.WriteLine(actual.ToString());

			Assert.Equal(expected.ToString(), actual.ToString());
		}

		[Fact]
		public void Sum1LevelTreeWithPlatforms()
		{
			Location left = new Location
			(
				"ru",
				new List<string>() { },
				new List<Location>()
				{
					new Location
					(
						"svrd",
						new List<string>() {  },
						new List<Location>()
						{
							new Location
							(
								"pervik",
								new List<string>() { "Ревдинский рабочий" },
								new List<Location>() { }
							)
						})
				}
			);

			Location right = new Location
			(
				"ru",
				new List<string>() { "Крутая реклама" },
				new List<Location>()
				{
					new Location
					(
						"svrd",
						new List<string>() {  },
						new List<Location>() {  }
					)
				}
			);

			Location expected = new Location
			(
				"ru",
				new List<string>() { "Крутая реклама" },
				new List<Location>()
				{
					new Location
					(
						"svrd",
						new List<string>() { },
						new List<Location>()
						{
							new Location
							(
								"pervik",
								new List<string>() { "Ревдинский рабочий" },
								new List<Location>() { }
							)
						})
				}
			);

			Location actual = left + right;

			Console.WriteLine(actual.ToString());

			Assert.Equal(expected.ToString(), actual.ToString());
		}
	}
}