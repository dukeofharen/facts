namespace Ducode.Facts.Data.Migrations
{
	using Entities;
	using MySql.Data.Entity;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<FactsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
			SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
		}

        protected override void Seed(FactsContext context)
        {
			var categories = new Category[]
			{
				new Category()
				{
					Name = "Bizarre",
					Description = "Bizarre facts"
				},
				new Category()
				{
					Name = "Humans",
					Description = "Facts about humans"
				},
				new Category()
				{
					Name = "Animals",
					Description = "Facts about animals"
				},
				new Category()
				{
					Name = "Technology",
					Description = "Facts about technology"
				}
			};
			context.Categories.AddOrUpdate(c => c.Name, categories);

			var facts = new List<Fact>();
			var factLines = SeedResources.seedFacts.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			foreach(string factLine in factLines)
			{
				facts.Add(new Fact()
				{
					Contents = factLine,
					Source = "http://www.thefactsite.com/2011/07/top-100-random-funny-facts.html",
					Category = categories[0]
				});
			}
			context.Facts.AddOrUpdate(f => f.Contents, facts.ToArray());
        }
    }
}
