using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndCompanies.Model
{
    static class RandomStringGenerator
    {
        private static Random random = new Random();

        private static IReadOnlyList<string> firstNames = new[]
        {
            "Tom", "John", "Frank", "Tim", "Alex", 
            "Bob", "Rosa", "Chris", "Natalie", "Sarah", 
            "Tanya", "Sam", "Peter", "Ember", "Marta"
        };

        private static IReadOnlyList<string> lastNames = new[]
        {
            "Smith", "Tompson", "Johnson", "Williams", "Brown", 
            "Jones", "Miller", "Davis", "Garcia", "Anderson", 
            "Moore", "Jackson", "Taylor", "Martin", "Robinson", 
            "Walker", "Young", "Allen", "King", "Wright"
        };

        private static IReadOnlyList<string> words = new[]
        {
            "Apple", "Black", "Pineapple", "Star", "Oracle", "Hot", "Spirit", "Wind", "West", "Word", "Speed", "Bricks"
        };

        public static string GenerateName()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(firstNames[random.Next(0, firstNames.Count)]);
            stringBuilder.Append(' ');
            stringBuilder.Append(lastNames[random.Next(0, lastNames.Count)]);
            return stringBuilder.ToString();
        }

        public static string GenerateString(int size, bool lowerCase)
        {
            StringBuilder stringBuilder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                stringBuilder.Append(ch);
            }
            if (lowerCase)
                return stringBuilder.ToString().ToLower();
            return stringBuilder.ToString();
        }

        public static string GenerateCompanyName()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(words[random.Next(0, words.Count)]);
            stringBuilder.Append(' ');
            stringBuilder.Append(words[random.Next(0, words.Count)]);
            return stringBuilder.ToString();
        }
    }
}
