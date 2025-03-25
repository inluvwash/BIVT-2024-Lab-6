using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            private string name;
            private string surname;
            private int[] penaltyTimes;


            public string Name => name;
            public string Surname => surname;
            public int[] PenaltyTimes
            {
                get
                {
                    if (penaltyTimes == null || penaltyTimes.Length == 0) return null;

                    int[] newone = new int[penaltyTimes.Length];
                   
                    for(int i = 0; i < penaltyTimes.Length; i++)
                    {
                        newone[i] = penaltyTimes[i];
                    }
                    return newone;
                }
            } 
        public int TotalTime
            {
                get
                {
                    
                    if (penaltyTimes == null || penaltyTimes.Length == 0) return 0;
                    int total = 0;
                    foreach (var time in penaltyTimes)
                    {
                        total += time;
                    }
                    return total;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if(penaltyTimes == null || penaltyTimes.Length == 0) return false;
                    for(int i = 0; i < penaltyTimes.Length; i++)
                    {
                        if (penaltyTimes[i] == 10) return true;
                    }
                    return false;
                }
            }

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                penaltyTimes = new int[0]; 
                
            }

            public void PlayMatch(int time)
            {
                if (penaltyTimes == null || penaltyTimes.Length == 0) return;
                int[] pepenalties = new int[penaltyTimes.Length + 1];
                for(int i = 0; i < pepenalties.Length -1;i++)
                {
                    pepenalties[i] = penaltyTimes[i];
                }
                pepenalties[pepenalties.Length - 1] = time;
                penaltyTimes = pepenalties;
            }

           

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }

            }

            public void Print()
            {
                Console.WriteLine($"имя: {name}, фамилия: {surname}, время: {TotalTime}, исключён: {IsExpelled}");
            }
        }

    }
}
