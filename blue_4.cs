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
            private string _name;
            private int[] _scores;

            public string Name => _name;
            public int[] Scores 
            { 
                get
                { 
                    if (_scores == null) return null;
                    int[] newscores = new int[_scores.Length];
                    for(int i = 0;i < _scores.Length; i ++)
                    {
                        newscores[i] = _scores[i];
                    }
                    return newscores;
                } 
            }
            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;
                    int total = 0;
                    foreach (var score in _scores)
                    {
                        total += score;
                    }
                    return total;
                }
            }
           

            public Team(string name)
            {
                _name = name;
                _scores = new int[0]; 
            }

           

            public void PlayMatch(int result)
            {
                if (_scores == null) return;
                int[] s = new int[_scores.Length +1];

                for(int i = 0; i < s.Length -1; i ++)
                {
                    s[i] = _scores[i];
                }


                s[s.Length - 1] = result;
                _scores = s;

            }

            public void Print()
            {
                Console.WriteLine($"команда: {_name}, финальный счёт: {TotalScore}");
            }
        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int teamcount;

            public string Name => _name;
            public Team[] Teams => _teams;

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12]; // максимально команд
                teamcount = 0;

            }

            public void Add(Team team)
            {
                if(_teams == null || teamcount >= _teams.Length) return;

                _teams[teamcount] = team;
                teamcount++;

            }

            public void Add(Team[] newTeams)
            {
                if (_teams == null) return;
                if(newTeams == null) return;
                if (newTeams.Length == 0) return;


                int c = 0;
                while (teamcount < _teams.Length && c < newTeams.Length)
                {
                    _teams[teamcount++] = newTeams[c++];
                }
            }

            public void Sort()
            {
                if(_teams.Length == 0 || _teams == null) return;

                for (int i = 0; i < _teams.Length; i++)
                {
                    for (int j = 0; j < _teams.Length - 1 - i; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group finalists = new Group("Финалисты");
                int l = size / 2;
                int i = 0, j = 0;

                
                while (i < l && j < l)
                {
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                    {
                        finalists.Add(group1.Teams[i]);
                        i++;
                    }
                    else 
                    {
                        finalists.Add(group2.Teams[j]);
                        j++;
                    }
                }
                while(i < l)
                {
                    finalists.Add(group1.Teams[i]);
                    i++;
                }
                while (j < l)
                {
                    finalists.Add(group2.Teams[j]);
                    j++;
                }

                return finalists;
            }

            public void Print()
            {
                Console.WriteLine($"группа: {_name}");
                for (int i = 0; i < teamcount; i++)
                {
                    _teams[i].Print();
                }
            }
        }
    }
}
