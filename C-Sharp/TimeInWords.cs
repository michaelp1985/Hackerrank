using System;
using System.Collections.Generic;
using System.IO;


class Solution {
        
    private static string[] ones = new string[] {"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };        
    
    static void Main(String[] args) {
        
        int hour = Convert.ToInt32(Console.ReadLine());
        int mins = Convert.ToInt32(Console.ReadLine());
        
        if (mins == 0){
            Console.WriteLine(ones[hour] + " o' clock");
        }
        else{
                    
            string link = (mins > 30) ? "to" : "past";
        
            string wordHour = convertHour(mins, hour);
            string wordMin = convertMins(mins);
                
            string time = String.Format("{0} {1} {2}", wordMin, link, wordHour);
        
            Console.WriteLine(time);
        }
    }
    
    private static string convertHour(int mins, int hours){
        
        string hour = "";
        
        if (mins > 30)
            if (hours == 12)
                hour = ones[1];
            else
                hour = ones[hours+1];
        else
            hour = ones[hours];
        
        return hour;
    }
    
    private static string convertMins(int mins){
        
        string min = "";
        
        if (mins == 1)
            min = ones[mins] + " minute";
        else if (mins == 30)
            min = "half";
        else if (mins % 15 == 0)
            min = "quarter";
        else{
            
            if (mins > 30)
                mins = 60 - mins;
            
            if (mins < 20){
                min = (mins == 1) ? ones[mins] + " minute" : ones[mins] + " minutes";
            }
            else{                            
            
                int o = mins % 10;                
            
                min = (o == 0) ? "twenty minutes" : "twenty " + ones[o] + " minutes"; 
            }
        }
            
        return min;
    }
}
