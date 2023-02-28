TimeSpan peakHourStart = new TimeSpan(9, 0, 0);
TimeSpan peakHourEnd = new TimeSpan(22, 59, 59);

float peakPulseRate = 0.30f;
float offPeakPulseRate = 0.20f;

DateTime startTime = DateTime.ParseExact("2019-08-31 08:59:13", "yyyy-MM-dd HH:mm:ss", null);
DateTime endTime = DateTime.ParseExact("2019-08-31 09:00:39", "yyyy-MM-dd HH:mm:ss", null);

float mobileBill = 0f;

if (startTime < endTime)
{
    for (DateTime callStartTime = startTime; callStartTime < endTime;)
    {
        callStartTime = callStartTime.AddSeconds(20);
        float rate;

        if (callStartTime > endTime)
        {
            if (endTime.TimeOfDay >= peakHourStart && endTime.TimeOfDay <= peakHourEnd)
            {
                rate = peakPulseRate;
                Console.WriteLine("rate: " + peakPulseRate);
            }
            else
            {
                rate = offPeakPulseRate;
                Console.WriteLine("rate: " + offPeakPulseRate);
            }
        }
        else
        {
            if (callStartTime.TimeOfDay >= peakHourStart && callStartTime.TimeOfDay <= peakHourEnd)
            {
                rate = peakPulseRate;
                Console.WriteLine("rate: " + peakPulseRate);
            }
            else
            {
                rate = offPeakPulseRate;
                Console.WriteLine("rate: " + offPeakPulseRate);
            }
        }

        mobileBill += rate;
        callStartTime = callStartTime.AddSeconds(1);
    }
}

Console.WriteLine("The Final mobile bill is: " + Math.Round(mobileBill, 1));



/* Problem: 
Calculate mobile bill between two date times.
Peak Hour: 9.00.00 am to 10.59.59 pm
20 second pulse and each pulse rate 30 paisa

Off-peak Hour: 12.00.00 am to 8.59.59 am and 11.00.00 pm to 11.59.59 pm
20 second pulse and each pulse rate 20 paisa

Note: If pulse overlap (peak to off-peak or off-peak to peak) then take peak hour rate for that pulse.

Sample input:  
Start time: 2019-08-31 08:59:13 am
End time: 2019-08-31 09:00:39 am

Breakdown (Optional to show): 
2019-09-31 08:59:13 + 20 second (2019-09-31 08:59:33) = 20 paisa
2019-09-31 08:59:34 + 20 second (2019-09-31 08:59:54) = 20 paisa
2019-09-31 08:59:55 + 20 second (2019-09-31 09:00:15) = 30 paisa
2019-09-31 09:00:16 + 20 second (2019-09-31 09:00:36) = 30 paisa
2019-09-31 09:00:37 + 3 second (2019-09-31 09:00:39) = 30 paisa

Sample output: 1.3 taka */
