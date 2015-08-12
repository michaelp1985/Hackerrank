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
