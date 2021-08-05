using System;

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
            return base.ToString();
        }
    }
}