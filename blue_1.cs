using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_1
    {
        public struct Response
        {
            private string _name;
            private string _surname;
            private int votes;

            public string Name => _name;
            public string Surname => _surname;
            public int Votes => votes;
            public Response(string name, string surname)
            {
                this.votes = 0;
                _name = name;
                _surname = surname;
            }
            public int CountVotes(Response[] responses)
            {
                if (responses == null || responses.Length == 0) return 0;

                votes = 0;
                foreach (var response in responses)
                {
                    if (response.Name == this.Name && response.Surname == this.Surname)
                    {
                        votes++;
                    }
                }
                return votes;
            }
            public void Print()
            {
                Console.WriteLine($"кандидат: {Name} {Surname}, голоса: {Votes}");
            }
        }
    }
}
