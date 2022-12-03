using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp.Models
{       

    public class Person
    {
        public Int32 id;
        public String first_name;
        public String last_name;
        public String email;
        public String date_birth;
        public String image;
        public String country;
        public Person(Int32 id ,String first,String last,String email,String date,String image,String country)
        {
            this.id = id;
            this.first_name = first;
            this.last_name = last;
            this.email = email;
            this.date_birth = date;
            this.image = image;
            this.country = country;
        }
    }
}
