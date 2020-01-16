using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace LinqApp
{
    class Program
    {
        private static List<Person> _persons;
        static void Main(string[] args)
        {
            var str = File.ReadAllText("C:/datalist.json");
            _persons = JsonConvert.DeserializeObject<List<Person>>(str);

            // Select all person whoes age is between 30 to 35.

            Console.WriteLine(" \n All person whoes age is between 30 to 35 \n ");
            var personResult = _persons.Where(p => p.Age > 30 && p.Age < 35)
                .Select(per => new { per.Name, per.Age });

            Print(personResult);

            //Calculate average age of persons having eye color "blue"

            Console.WriteLine(" \n Average age of persons having eye color blue \n");
            var PersonWithBlueEye = _persons.Where(per => per.EyeColor.Equals("blue"))
                .Average(per => per.Age);
            Console.WriteLine(PersonWithBlueEye);

            //Select 10 highest age person with gender- female and eye color brown.

            Console.WriteLine(" \n 10 highest age person with gender- female and eye color brown \n");
            var PersonWithBrownEye = _persons.OrderByDescending(per => per.Age)
                .Where(per => per.Gender.Equals("female") && per.EyeColor.Equals("brown"))
                .Select(per => new { per.Name, per.Age, per.EyeColor })
                .Take(10);

            Print(PersonWithBrownEye);

            //Select bottom 5 persons with lowest age.

            Console.WriteLine(" \n Bottom 5 persons with lowest age \n");

            var PersonWithLowestAge = _persons.OrderBy(per => per.Age)
                .Select(per => new { per.Name, per.Age })
                .Take(5);

            Print(PersonWithLowestAge);

            //Select friends of person having id "5d4a6ca8e242a1e45f7d800f"

            Console.WriteLine("\n Friends of person having id '5d4a6ca8e242a1e45f7d800f'");
            var PersonWithId = _persons.Where(per => per._id.Equals("5d4a6ca8e242a1e45f7d800f"))
                .Select(per => new { per.Friends });

            Print(PersonWithId);

            // Select all persons whose email having char 'g'. 
            Console.WriteLine("\n All persons whose email having char 'g'");
            var PersonWithEmailHaving_g = _persons.Where(per => per.Email.Contains("g"))
                .Select(per => new { per.Name, per.Email });

            Print(PersonWithEmailHaving_g);

            // Count all persons who are active with green eye color
            Console.WriteLine("\nCount all persons who are active with green eye color.");
            var PersonCountWithGreenEye = _persons.Where(per => per.EyeColor.Equals("green") && per.IsActive)
                .Count();

            Console.WriteLine(PersonCountWithGreenEye);

            //Count all male persons whoes favorite fruit is "strawberry".

            Console.WriteLine("Count all male persons whoes favorite fruit is 'strawberry'");
            var PersonWithFavoriteFruitStrawberry = _persons.Where(per => per.FavoriteFruit.Equals("strawberry"))
                .Count();

            Console.WriteLine(PersonWithFavoriteFruitStrawberry);

            //Select top 10 lowest age female whoes name starts with "K".

            Console.WriteLine("Top 10 lowest age female whoes name starts with 'K'");
            var FemaleNameStartsWith_k = _persons.OrderBy(per => per.Age)
                .Where(per => per.Name.StartsWith("K") && per.Gender.Equals("female"))
                .Select(per => new { per.Name, per.Age })
                .Take(10);

            Print(FemaleNameStartsWith_k);

            // Select top 20 males name, gender, age and balance sorted by age.
            Console.WriteLine("\nTop 20 males name, gender, age and balance sorted by age.");
            var MaleNameSortedByAge = _persons.OrderBy(per => per.Age)
                .Select(per => new { per.Name, per.Age, per.Gender, per.Balance }).Take(20);

            Print(MaleNameSortedByAge);

            //Select 10th persons's friends from the bottom after sorted by age.
            Console.WriteLine("\n 10th persons's friends from the bottom after sorted by age.");
            var _10thPersonFriend = _persons.OrderBy(per => per.Age)
                .Select(per => new { per.Name, per.Age, per.Friends })
                .Skip(_persons.Count() - 11).Take(1);

            Print(_10thPersonFriend);

            //Select 20th persons name and balance whoes age is between 40 to 50. 

            Console.WriteLine("20th persons name and balance whoes age is between 40 to 50");
            var _20thPersonName = _persons.Where(per => per.Age > 40 && per.Age < 50)
                .Select(per => new { per.Name, per.Balance })
                .Skip(19)
                .Take(1);

            Print(_20thPersonName);


            Console.ReadKey(true);

        }

        //Method to Display the resulted collection 
        static void Print(IEnumerable<object> newResult)
        {
            foreach (var item in newResult)
            {
                Console.WriteLine(item);
            }
        }
    }
}
