using System;
using System.Globalization;

namespace gr
{
    public class Person
    {
        public string LastName { get; }
        public string FirstName { get; }
        public string Email { get; }
        public string FavoriteColor { get; }
        public DateTime DateOfBirth { get; }

        public Person(string lastName, string firstName, string email, string favoriteColor, DateTime dateOfBirth)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            FavoriteColor = favoriteColor;
            DateOfBirth = dateOfBirth;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType())) return false;

            Person p = (Person)obj;

            return LastName == p.LastName &&
                FirstName == p.FirstName &&
                Email == p.Email &&
                FavoriteColor == p.FavoriteColor &&
                DateOfBirth == p.DateOfBirth;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(
                    LastName,
                    FirstName,
                    Email,
                    FavoriteColor,
                    DateOfBirth)
                .GetHashCode();
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {Email} {FavoriteColor} {DateOfBirth.ToString("M/d/yyyy", CultureInfo.InvariantCulture)}";
        }

        public static Person Parse(string line)
        {
            if (line == null) return null;

            var lineClean = line.Replace(" |", string.Empty).Replace(",", string.Empty);

            var parts = lineClean.Split(' ');

            if (parts.Length != 5) return null;

            var isDateOfBirthParseable = DateTime.TryParse(parts[4], out var dateOfBirth);

            if (!isDateOfBirthParseable) return null;

            return new Person(parts[0], parts[1], parts[2], parts[3], dateOfBirth);
        }
    }
}