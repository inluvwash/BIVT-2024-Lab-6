using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman
        {
            private string name;
            private string surname;
            private int place;

            public string Name => name;
            public string Surname => surname;
            public int Place => place;

            public Sportsman(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.place = 0; 
            }

            public void SetPlace(int place)
            {
                if (this.place == 0) 
                {
                    this.place = place;
                }
                else
                {
                    return;
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {Place}");
            }
        }

        public struct Team
        {
            private string name;
            private Sportsman[] sportsmen;
            private int count;

            public string Name => name;
            public Sportsman[] Sportsmen => sportsmen;
            public int SummaryScore => CalculateScore();
            public int TopPlace
            {
                get
                {
                    if (sportsmen == null) return 0;
                    int topPlace = 18;
                    foreach (var s in sportsmen)
                    {
                        if (s.Place < topPlace && s.Place > 0)
                        {
                            topPlace = s.Place;
                        }
                    }

                    return topPlace;
                }
            }

            public Team(string name)
            {
                this.name = name;
                this.sportsmen = new Sportsman[6];
                this.count = 0;
            }

            public void Add(Sportsman sportsman)
            {
                if (sportsmen == null) return;

                if (count < sportsmen.Length)
                {
                    sportsmen[count++] = sportsman;
                }
            }
            public void Add(Sportsman[] newSportsmen)
            {
                if (sportsmen == null || sportsmen.Length == 0) return;
                foreach (Sportsman sportsman in newSportsmen)
                {
                    Add(sportsman);
                }
            }

            private int CalculateScore()
            {
                if (sportsmen == null) return 0;
                int score = 0;
                foreach (var sportsman in sportsmen)
                {
                    switch (sportsman.Place)
                    {
                        case 1: score += 5; break;
                        case 2: score += 4; break;
                        case 3: score += 3; break;
                        case 4: score += 2; break;
                        case 5: score += 1; break;
                        default: break; 
                    }
                }
                return score;
            }



            public static void Sort(Team[] teams)
            {
                if (teams.Length == 0) return;
                if (teams == null) return;

                for (int i = 0; i < teams.Length; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore)
                        {
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                        }

                        else if (teams[j].SummaryScore == teams[j + 1].SummaryScore)
                        {
                            if (teams[j].TopPlace > teams[j + 1].TopPlace)
                            {
                                (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                            }
                        }
                    }
                }
            }

            public void Print()
            {
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    Console.WriteLine($"{Name} {SummaryScore} {TopPlace}");
                }
            }
        }         
    }
}

