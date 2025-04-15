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
            private string _name;
            private string _surname;
            private int[] _penaltyTimes;


            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltyTimes == null || _penaltyTimes.Length == 0) return null;

                    int[] newone = new int[_penaltyTimes.Length];
                   
                    for(int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        newone[i] = _penaltyTimes[i];
                    }
                    return newone;
                }
            } 
        public int TotalTime
            {
                get
                {
                    
                    if (_penaltyTimes == null || _penaltyTimes.Length == 0) return 0;
                    int total = 0;
                    foreach (var time in _penaltyTimes)
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
                    
                    for(int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        if (_penaltyTimes[i] == 10) return true;
                    }
                    return false;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTimes = new int[0]; 
                
            }

            public void PlayMatch(int time)
            {
                if (_penaltyTimes == null) return;
                int[] pepenalties = new int[_penaltyTimes.Length + 1];
                for(int i = 0; i < pepenalties.Length -1;i++)
                {
                    pepenalties[i] = _penaltyTimes[i];
                }
                pepenalties[pepenalties.Length - 1] = time;
                _penaltyTimes = pepenalties;
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
                Console.WriteLine($"имя: {_name}, фамилия: {_surname}, время: {TotalTime}, исключён: {IsExpelled}");
            }
        }

    }
}
