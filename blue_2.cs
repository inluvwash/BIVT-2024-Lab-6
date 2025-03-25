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
            private string name;
            private string surname;
            private int[,] marks;
            

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.marks = new int[2, 5];

            }


            public string Name => name;
            public string Surname => surname;
            public int[,] Marks
            {
                get
                {
                    if (marks == null) return null;
                    int[,]newmarks = new int[2,5];
                    for(int i = 0; i < 2; i ++)
                    {
                        for(int j = 0; j < 5; j ++)
                        {
                            newmarks[i,j] = marks[i,j];
                        }
                    }

                    return newmarks;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (marks == null) return 0;
                    int total = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            total += marks[i, j];
                        }
                    }
                    return total;
                }
            }

            public void Jump(int[] result)
            {
                if (marks == null || result == null || result.Length == 0 || marks.GetLength(0) == 0) return;
                
                for (int i = 0; i < 2; i++)
                { 
                    
                    if (marks[i, 0] == 0)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            marks[i, j] = result[j];
                        }
                        return;
                    }
                   
                }
               
            }


            

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                if(array.Length == 0) return;

                Array.Sort(array, (x, y) => y.TotalScore.CompareTo(x.TotalScore));
            }

            public void Print()
            {
                Console.WriteLine($"мя: {Name} {Surname}. общий балл: {TotalScore}");
            }
        }
    }
}

