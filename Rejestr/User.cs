using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejestr
{
    public class User
    {
        const int GENDER_MALE = 0;
        const int GENDER_FEMALE = 1;
        const int GENDER_ANOTHER = 2;

        public static readonly string[] genderMap = { "Mężczyzna", "Kobieta", "Inne" };

        public int Id { get; set; }

        public string Name { get; set; }

        public string? Surname { get; set; }

        public int? Age { get; set; }

        public int? Gender { get; set; }

        public string? PostalCode { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? HouseNumber { get; set; }

        public string? ApartmentNumber { get; set; }


    }
}
