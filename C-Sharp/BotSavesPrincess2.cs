/*
In this version of "Bot saves princess", Princess Peach and bot's position are randomly set. Can you save the princess?

Task
Complete the function nextMove which takes in 4 parameters - an integer N, integers r and c indicating the row & 
column position of the bot and the character array grid - and outputs the next move the bot makes to rescue the princess.

Input Format
The first line of the input is N (<100), the size of the board (NxN). 
The second line of the input contains two space separated integers, which is the position of the bot. 
Grid is indexed using Matrix Convention
The position of the princess is indicated by the character 'p' and the position of the bot is indicated by the character 'm' 
and each cell is denoted by '-' (ascii value: 45). 

Output Format
Output only the next move you take to rescue the princess. Valid moves are LEFT, RIGHT, UP or DOWN

Sample Input
5
2 3
-----
-----
p--m-
-----
-----
Sample Output
LEFT
Resultant State
-----
-----
p-m--
-----
-----
Explanation 
As you can see, bot is one step closer to the princess. 

Scoring 
Your score for every testcase would be (NxN minus number of moves made to rescue the princess)/10 where N is the size of the grid 
(5x5 in the sample testcase). Maximum score is 17.5 
*/

using System;
using System.Collections.Generic;
using System.IO;


class Solution {
static void nextMove(int n,int r, int c, String [] grid){
    
    for(int i = 0; i < grid.Length; i++){
        
        if (grid[i].IndexOf('p') >= 0){
            
            if (i == r){
                char[] row = grid[i].ToCharArray();
                
                for(int j = 0; j < row.Length; j++){
                    
                    if(row[j] == 'p'){
                        
                        if(j == c){
                            
                        }
                        else if (j > c){
                            Console.WriteLine("RIGHT");
                        }
                        else{
                            Console.WriteLine("LEFT");
                        }
                    }
                }
            }
            else if (i < r){
                Console.WriteLine("UP");
            }
            else{
                Console.WriteLine("DOWN");
            }
        }                    
    }
}
    
// - Main method was provided.
static void Main(String[] args) {
        int n;

        n = int.Parse(Console.ReadLine());
        String pos;
        pos = Console.ReadLine();
        String[] position = pos.Split(' ');
        int [] int_pos = new int[2];
        int_pos[0] = Convert.ToInt32(position[0]);
        int_pos[1] = Convert.ToInt32(position[1]);
        String[] grid  = new String[n];
        for(int i=0; i < n; i++) {
            grid[i] = Console.ReadLine(); 
        }

        nextMove(n, int_pos[0], int_pos[1], grid);
     }
}
