using Microsoft.EntityFrameworkCore;
using ORM_Excersises.Data;
using ORM_Excersises.Models;

namespace ORM_Excersises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Зад. 1 Връзка с базата данни 
            var option = new DbContextOptionsBuilder<GeographyContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Geography;Integrated Security = True")
                .Options;

            using var contex = new GeographyContext(option);

            //Зад. 2 Изведи „<CountryName>: <Population> people"
            var countries = contex.Countries.Select(c => new
            {
                c.CountryName,
                c.Population
            }).ToList();

            foreach (var country in countries)
            {
                Console.WriteLine($"{country.CountryName}: {country.Population} people");
            }
            //Зад 3. Изведи Топ 5 „<PeakName> - <Elevation> m“ в низходящ ред. 
            var peaks = contex.Peaks
                .Where(p => p.Elevation >= 5000 && p.Elevation <= 7000)
                .OrderByDescending(p => p.Elevation)
                .Take(5)
                .Select(p => new
                {
                    p.PeakName,
                    p.Elevation
                }).ToList();

            foreach (var peak in peaks)
            {
                Console.WriteLine($"{peak.PeakName} - {peak.Elevation} m");
            }
            //Зад 4. Изведи "<MountainRange> - <PeaksCount> peaks" чрез навигационно свойство
            var mountians = contex.Mountains
                .Where(m => m.Peaks.Count >= 3)
                .Select(m => new
                {
                    MountainName = m.MountainRange,
                    PeakCount = m.Peaks.Count
                })
                .OrderByDescending(m => m.PeakCount)
                .ThenBy(m => m.MountainName).ToList();

            foreach (var mountain in mountians)
            {
                Console.WriteLine($"{mountain.MountainName}-{mountain.PeakCount} peaks");
            }

            // Зад. 5: Добавяне на континент
            Continent continent = new Continent
            {
                ContinentCode = "AT",
                ContinentName = "Atlanta"
            };

            contex.Continents.Add(continent);
            contex.SaveChanges();

            Console.WriteLine("Континентът Atlanta е добавен.");

            // Зад. 6: Промяна на името
            Continent? continentToUpdate = contex.Continents
                .FirstOrDefault(c => c.ContinentCode == "AT");


            continentToUpdate.ContinentName = "Atlantida";
            contex.SaveChanges();

            Console.WriteLine("Името е променено на Atlantida.");


           // Зад. 7: Премахване на континента
            Continent? continentToDelete = contex.Continents
                .FirstOrDefault(c => c.ContinentName == "Atlantida");


            contex.Continents.Remove(continentToDelete);
            contex.SaveChanges();

            Console.WriteLine("Континентът Atlantida е премахнат.");

            //Зад. 8 Извеждаме информация от две таблици чрез navigation property 
            var peaksInMountain = contex.Peaks
                .Select(p => new
                {
                    p.PeakName,
                    MountainName = p.Mountain.MountainRange
                }).ToList();

            foreach (var peak in peaksInMountain)
            {
                Console.WriteLine($"{peak.PeakName} - {peak.MountainName}");
            }

        }
    }
}
