using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyMappingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDbContext dbContext = new MyDbContext();
            //Country country = new Country()
            //{
            //    CountryName = "India",
            //};

            //State state = new State()
            //{
            //    StateName = "CG",
            //    CountryId = country.CountryId,
            //    Country = country
            //};

            //City city = new City()
            //{
            //    CityName = "Raipur",
            //    StateId = state.StateId,
            //    State = state
            //};

            //dbContext.Countries.Add(country);
            //dbContext.States.Add(state);
            //dbContext.Cities.Add(city);

            //Country country = new Country()
            //{
            //    CountryName = "USA",
            //};

            //State state = new State()
            //{
            //    StateName = "Virginia",
            //    CountryId = country.CountryId,
            //    Country = country
            //};

            //City city = new City()
            //{
            //    CityName = "Fairfax",
            //    StateId = state.StateId,
            //    State = state
            //};

            //Country country = new Country()
            //{
            //    CountryName = "India",
            //};

            //State state = new State()
            //{
            //    StateName = "CG",
            //    CountryId = country.CountryId,
            //    Country = country
            //};

            //City city = new City()
            //{
            //    CityName = "Bhilai",
            //    StateId = state.StateId,
            //    State = state
            //};

            //var removeCountry = dbContext.Countries.FirstOrDefault(c => c.CountryId == 5);
            //dbContext.Countries.Remove(removeCountry);

            //var removeState = dbContext.States.FirstOrDefault(s => s.StateId == 1);
            //dbContext.States.Remove(removeState);

             City city = new City()
             {
                 CityName = "Durg",
                 StateId =4,
             };

            dbContext.Cities.Add(city);
            dbContext.SaveChanges();


        }

    }
}
