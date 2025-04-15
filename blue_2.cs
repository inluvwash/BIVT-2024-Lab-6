using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks;

            private int _c;

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
                _c = 0;
            }


            public string Name => _name;
            public string Surname => _surname;
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,]newmarks = new int[2,5];
                    for(int i = 0; i < 2; i ++)
                    {
                        for(int j = 0; j < 5; j ++)
                        {
                            newmarks[i,j] = _marks[i,j];
                        }
                    }

                    return newmarks;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_marks == null) return 0;
                    int total = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            total += _marks[i, j];
                        }
                    }
                    return total;
                }
            }

            public void Jump(int[] result)
            {
                if (_c > 1 || _marks == null || result == null || result.Length == 0 || _marks.GetLength(0) == 0) return;
                
                for (int i = 0; i < 5; i++)
                {
                    _marks[_c, i] = result[i];
                   
                }
                _c++;
            }


            

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                

                Array.Sort(array, (x, y) => y.TotalScore.CompareTo(x.TotalScore));
            }

            public void Print()
            {
                Console.WriteLine($"мя: {Name} {Surname}. общий балл: {TotalScore}");
            }
        }
    }
}

