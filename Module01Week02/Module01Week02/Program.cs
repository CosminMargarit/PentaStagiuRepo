using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module01Week02
{
    struct UserData
    {
        public int year;
        public int month;
        public int day;
        public GenderType gender;
        public int age;
        public int ageUntilRetirement;
    }

    enum GenderType
    {
        Male,
        Female
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserData userData = new UserData();
            userData.year = GetNrFromUser(nameof(userData.year));
            userData.month = GetNrFromUser(nameof(userData.month));
            userData.day = GetNrFromUser(nameof(userData.day));
            userData.gender = GetGenderFromUser(nameof(userData.gender));
            userData.age = GetUserAge();
            userData.ageUntilRetirement = GetYearsUntilRetirement(userData.age, userData.gender);

            Console.WriteLine("Age until retirement is " + userData.ageUntilRetirement);
            Console.ReadLine();

            int GetNrFromUser(string key)
            {
                Console.WriteLine("Insert birth {0}:", key);
                int customInput = 0;
                bool isValid = false;
                while (!isValid)
                {
                    isValid = int.TryParse(Console.ReadLine(), out customInput);//validate if it's a number
                    if(!isValid)
                    {
                        Console.WriteLine("Input not valid! Only numbers allowed!");
                        Console.WriteLine("Try again!");
                        Console.WriteLine();
                    }
                    else
                    {
                        isValid = ValidateInputDate(customInput, key);//validate the number (year/month/day)
                    }
                }
                return customInput;
            }

            GenderType GetGenderFromUser(string key)
            {
                Console.WriteLine("Insert {0} (M/F)", key);
                char customInput = '0';
                bool isValid = false;
                while(!isValid)
                {
                    isValid = char.TryParse(Console.ReadLine(), out customInput);
                    if(!isValid)
                    {
                        Console.WriteLine("Input is not valid! Please insert 'M' for male or 'F' for female.");
                        Console.WriteLine("Try again!");
                        Console.WriteLine();
                    }
                }
                return customInput == 'M' ? GenderType.Male : GenderType.Female ;
            }

            bool ValidateInputDate(int customInput, string key)
            {
                bool isValid = false;
                switch(key)
                {
                    case nameof(userData.year):
                        if(customInput > DateTime.Now.Year - 100 && customInput <= DateTime.Now.Year - 18)
                        {
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine("The year you entered is not valid. The year should be between " +
                                               (DateTime.Now.Year - 100) + " and " + (DateTime.Now.Year - 18));
                            Console.WriteLine("Otherwise, it means you are either dead, or not born yet, or not of legal age to even have a job.");
                            Console.WriteLine("Try again!");
                            Console.WriteLine();
                        }
                        break;
                    case nameof(userData.month):
                        if(customInput > 0 && customInput <= 12)
                        {
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine("The month you entered is not valid. The month should be between 1 (Jan) and 12 (Dec).");
                            Console.WriteLine("Try again!");
                            Console.WriteLine();
                        }
                        break;
                    case nameof(userData.day):
                        if(customInput > 0 && customInput <= GetMaxDaysPerMonth(userData.month))
                        {
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine("The day you entered is not valid. The day should be between 1 and the max nr of days of the corresponding month.");
                            Console.WriteLine("Try again!");
                            Console.WriteLine();
                        }
                        break;
                }
                return isValid;
            }

            int GetYearsUntilRetirement(int currentAge, GenderType gender)
            {
                return (gender == GenderType.Male ? 65 : 63) - currentAge;
            }

            int GetMaxDaysPerMonth(int month)
            {
                int days = 0;
                switch(month)
                {
                    case 1:
                        days = 31;
                        break;
                    case 2:
                        days = 28;
                        break;
                    case 3:
                        days = 31;
                        break;
                    case 4:
                        days = 30;
                        break;
                    case 5:
                        days = 31;
                        break;
                    case 6:
                        days = 30;
                        break;
                    case 7:
                        days = 31;
                        break;
                    case 8:
                        days = 31;
                        break;
                    case 9:
                        days = 30;
                        break;
                    case 10:
                        days = 31;
                        break;
                    case 11:
                        days = 30;
                        break;
                    case 12:
                        days = 31;
                        break;
                }
                return days;
            }

            int GetUserAge()
            {
                DateTime dob = new DateTime(userData.year, userData.month, userData.day);
                TimeSpan diff = DateTime.Now - dob;
                return diff.Days / 365;
            }
        }
    }
}