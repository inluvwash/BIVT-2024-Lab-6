using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string name;
            private int[] scores;

            public string Name => name;
            public int[] Scores { get { if (scores == null) return null; return scores; } }
            public int TotalScore => SumTotalScore();

            public Team(string name)
            {
                this.name = name;
                scores = new int[0]; 
            }

            private int SumTotalScore()
            {
                if (scores == null) return 0;
                int total = 0;
                foreach (var score in scores)
                {
                    total += score;
                }
                return total;
            }

            public void PlayMatch(int result)
            {
                if (scores == null) return;
                int[] s = new int[scores.Length +1];

                for(int i = 0; i < scores.Length; i ++)
                {
                    s[i] = scores[i];
                }


                s[s.Length - 1] = result;
                scores = s;

            }

            public void Print()
            {
                Console.WriteLine($"команда: {name}, финальный счёт: {TotalScore}");
            }
        }

        public struct Group
        {
            private string name;
            private Team[] teams;
            private int teamcount;

            public string Name => name;
            public Team[] Teams => teams;

            public Group(string name)
            {
                this.name = name;
                teams = new Team[12]; // максимально команд
                teamcount = 0;

            }

            public void Add(Team team)
            {
                if(teams == null) return;

                if (teamcount < 12)
                {
                    teams[teamcount] = team;
                    teamcount++;
                }
                
            }

            public void Add(Team[] newTeams)
            {
                if (teams == null) return;
                if(newTeams == null) return;
                if (newTeams.Length == 0) return;
                

                foreach (var team in newTeams)
                {
                    Add(team);
                }
            }

            public void Sort()
            {
                if(teams.Length == 0 || teams == null) return;

                for (int i = 0; i < teams.Length; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        if (teams[j].TotalScore < teams[j + 1].TotalScore)
                        {
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group finalists = new Group("Финалисты");
                int count = 0;

                for (int i = 0; i < Math.Min(size, group1.teamcount); i++)
                {
                    finalists.Add(group1.teams[i]);
                    count++;
                }

                for (int i = 0; i < Math.Min(size - count, group2.teamcount); i++)
                {
                    finalists.Add(group2.teams[i]);
                }

                return finalists;
            }

            public void Print()
            {
                Console.WriteLine($"группа: {name}");
                for (int i = 0; i < teamcount; i++)
                {
                    teams[i].Print();
                }
            }
        }
    }
}
