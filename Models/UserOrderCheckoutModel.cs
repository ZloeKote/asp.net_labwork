using System.Collections.Generic;
using System.Linq;

namespace LabWork.Models
{
    public class UserOrderCheckoutModel
    {
        public string name { get; set; } // customer name
        public string surname { get; set; } // customer surname
        public string email { get; set; } // customer email
        public List<string> games { get; set; } // ordered items in form: 0 - game id, 1 - copy type, 2 - platform, 3 - amount
        public int total_price { get; set; } // total price of the order

        public UserOrderCheckoutModel()
        {
            games = new List<string>();
        }

        public UserOrderCheckoutModel(string name, string surname, string email)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
        }

        public override string ToString()
        {
            string content = "";
            if (name != null) content += "customer: " + name + ' ' + surname + '\n';
            if (email != null) content += "customer email: " + email + '\n';
            if (games != null)
            {
                for(var i = 0; i < games.Count; i+=4)
                {
                    content += "Game " + games[i] + ' ' + games[i + 1] + ' ' + games[i + 2] + " amount: " + games[i + 3] + '\n';
                }
            }
            content += "price: " + total_price;
            return content;
        }

    }
}
