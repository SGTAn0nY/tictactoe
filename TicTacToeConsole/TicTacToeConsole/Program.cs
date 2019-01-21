using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeConsole
{
    class tictactoe
    {


        //Main method, only for the very start(up), then instantly executes the Menu() method
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to TicTacToe ...!");
            Menu();
        }


        //Menu method, asks the user what gamemode he wants to play and depending on user input either runs the Spieler_vs_Spieler() method, the Spieler_vs_Bot() method or repeats itself if the user gave a wrong input
        public static void Menu()
        {
            List<string> list_displayed = new List<string>(new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " });
            List<int> list = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Console.WriteLine("You can choose between two game modes:\nPlayer vs Player     ->      1\n(1)        (2)\n\n---------- or -----------------\n\nPlayer vs Bot        ->      2\n\n");
            string menu_choice = Convert.ToString(Console.ReadLine());
            if (menu_choice == "1") { Spieler_vs_Spieler(list, list_displayed); }
            if (menu_choice == "2") { Spieler_vs_Bot(); }
            else { Console.WriteLine("Wrong Input!"); Menu(); }
        }




        public static void Spieler_vs_Spieler(List<int> list, List<string> list_displayed)
        {
            int has_someone_won = 0;
            do 
            {
                int whichplayer = 1, i_could_win_p1 = 1, i_could_win_p2 = 1;
                case_whichplayer:
                switch (whichplayer)
                {
                    case 1:                 //Player 1's turn
                        Console.Clear();
                        Console.WriteLine("Player {0}: \n", whichplayer);
                        Console.WriteLine("{0}  |  {1}  |  {2}\n___|_____|___\n{3}  |  {4}  |  {5}\n___|_____|___\n{6}  |  {7}  |  {8}\n", list_displayed[0], list_displayed[1], list_displayed[2], list_displayed[3], list_displayed[4], list_displayed[5], list_displayed[6], list_displayed[7], list_displayed[8]);
                        Console.Write("Enter your desired field: ");
                        
                        string field_p1 = Convert.ToString(Console.ReadLine()); 
                        int field_int_p1 = Convert.ToInt32(field_p1);

                        list[field_int_p1 - 1] = 1;
                        list_displayed[field_int_p1 - 1] = "X";
                        whichplayer = 2;
                        i_could_win_p1 = 1;
                        i_could_win_p2 = 0;
                        break;
                    case 2:                 //Player 2's turn
                        Console.Clear();
                        Console.WriteLine("Player {0}: \n", whichplayer);
                        Console.WriteLine("{0}  |  {1}  |  {2}\n___|_____|___\n{3}  |  {4}  |  {5}\n___|_____|___\n{6}  |  {7}  |  {8}\n", list_displayed[0], list_displayed[1], list_displayed[2], list_displayed[3], list_displayed[4], list_displayed[5], list_displayed[6], list_displayed[7], list_displayed[8]);
                        Console.Write("Enter your desired field: "); 
                        
                        string field_p2 = Convert.ToString(Console.ReadLine()); 
                        int field_int_p2 = Convert.ToInt32(field_p2);

                        

                        list[field_int_p2 - 1] = 2;
                        list_displayed[field_int_p2 - 1] = "O";
                        whichplayer = 1;
                        i_could_win_p1 = 0;
                        i_could_win_p2 = 1;
                        break;
                }
                has_someone_won = Has_someone_won(list);
                if (has_someone_won == 1)
                {
                    if (i_could_win_p1 > i_could_win_p2) { Console.WriteLine("\n\nPlayer 1 has won !\n\n{0}  |  {1}  |  {2}\n___|_____|___\n{3}  |  {4}  |  {5}\n___|_____|___\n{6}  |  {7}  |  {8}\n", list_displayed[0], list_displayed[1], list_displayed[2], list_displayed[3], list_displayed[4], list_displayed[5], list_displayed[6], list_displayed[7], list_displayed[8]); Menu(); }
                    if (i_could_win_p1 < i_could_win_p2) { Console.WriteLine("\n\nPlayer 2 has won !\n\n{0}  |  {1}  |  {2}\n___|_____|___\n{3}  |  {4}  |  {5}\n___|_____|___\n{6}  |  {7}  |  {8}\n", list_displayed[0], list_displayed[1], list_displayed[2], list_displayed[3], list_displayed[4], list_displayed[5], list_displayed[6], list_displayed[7], list_displayed[8]); Menu(); }
                }

                if (has_someone_won == 0) { goto case_whichplayer; }
                
              }
            while (has_someone_won == 0);

        }

        


        public static void Spieler_vs_Bot()
        {

        }

        

        public static int Has_someone_won(List<int> list)
        {
            if (list[0] == list[1] && list[1] == list[2]) { return 1; }
            else
            {
                if (list[3] == list[4] && list[4] == list[5]) { return 1; }
                else
                {
                    if (list[6] == list[7] && list[7] == list[8]) { return 1; }
                    else
                    {
                        if (list[0] == list[3] && list[3] == list[6]) { return 1; }
                        else
                        {
                            if (list[1] == list[4] && list[4] == list[7]) { return 1; }
                            else
                            {
                                if (list[2] == list[5] && list[5] == list[8]) { return 1; }
                                else
                                {
                                    if (list[0] == list[4] && list[4] == list[8]) { return 1; }
                                    else
                                    {
                                        if (list[2] == list[4] && list[4] == list[6]) { return 1; }
                                        else
                                        {
                                            return 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
                           


            
            
        }
    }
}



