using System;

namespace Problem1
{
    class Program
    {
        public static void Main(string[] args)
        {
            decimal bill = 0;
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddMinutes(10);
            DateTime timeNow = startTime;
            var timeIn = timeNow.ToString("tt");
            var totalSeconds = (endTime - startTime).TotalSeconds;
            while (timeNow <= endTime)
            {
                if ((timeNow.Hour >= 9 || (timeNow.Hour == 8 && timeNow.Minute == 59 && timeNow.Second > 40 && totalSeconds >= 20)) && (timeNow.Hour < 23))
                {
                    bill = bill + 30;
                    Console.WriteLine("{0:HH:mm:ss tt}, rate: {1:#,0.00}, bill: {2:#,0.00}", timeNow, 30, bill);

                }
                else if ((timeNow.Hour >= 0 && timeNow.Hour < 9) || timeNow.Hour >= 23 )
                {
                    bill = bill + 20;
                    Console.WriteLine("{0:HH:mm:ss tt}, rate: {1:#,0.00}, bill: {2:#,0.00}", timeNow, 20, bill);

                }
                totalSeconds = totalSeconds - 20;
                timeNow = timeNow.AddSeconds(21);
            }

            Console.WriteLine("Bill: {0:HH:mm:ss tt} to {1:HH:mm:ss tt}, {2:#,0} mins,{3:#,0} seconds = {4:#,0.00} taka", startTime, endTime, (endTime - startTime).TotalMinutes, (endTime - startTime).TotalSeconds, bill / 100);




        }

    }
}