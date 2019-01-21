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
            List<string> list_displayed = new List<string>(new string[] {" ", " ", " ", " ", " ", " ", " ", " ", " "}); //Only list for displaying the overlay !!! Delete spaces (so list is empty) after testing !!!
            List<int> check_if_field_already_used = new List<int>(new int[9]);
            List<int> list = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Console.WriteLine("You can choose between two game modes:\nPlayer vs Player     ->      1\n(X)        (O)\n\n---------- or -----------------\n\nPlayer vs Bot        ->      2\n\n");
            string menu_choice = Convert.ToString(Console.ReadLine());
            if (menu_choice == "1") { Spieler_vs_Spieler(list, list_displayed, check_if_field_already_used); }
            if (menu_choice == "2") { Spieler_vs_Bot(list, list_displayed, check_if_field_already_used); }
            else { Console.WriteLine(""); Menu(); }
        }




        public static void Spieler_vs_Spieler(List<int> list, List<string> list_displayed, List<int> check_if_field_already_used)
        {
            int has_someone_won = 0, i_could_win_p1 = 1, i_could_win_p2 = 1, turn_counter = 0, field_int_p1, field_int_p2; string whichplayer = "X";
            do 
            {
 
                
                switch (whichplayer)
                {
                    case "X":                 //Player 1's turn
                        Console.Clear();
                        Console.WriteLine("Player {0}: \n", whichplayer);
                        Console.WriteLine("{0}  |  {1}  |  {2}\n___|_____|___\n{3}  |  {4}  |  {5}\n___|_____|___\n{6}  |  {7}  |  {8}\n", list_displayed[0], list_displayed[1], list_displayed[2], list_displayed[3], list_displayed[4], list_displayed[5], list_displayed[6], list_displayed[7], list_displayed[8]);
                        Console.Write("Enter your desired field: ");
                        
                        string field_p1 = Convert.ToString(Console.ReadLine());

                        //TryCatch to avoid crashing when a string is given instead of an integer
                        try
                        {
                            field_int_p1 = Convert.ToInt32(field_p1);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An error occured: {0}", e.Source);
                            field_int_p1 = 0;
                            Menu();
                        }



                        try
                        {
                            if (check_if_field_already_used[field_int_p1 - 1] != 1 & check_if_field_already_used[field_int_p1 - 1] != 2)
                            {
                                list[field_int_p1 - 1] = 1;
                                check_if_field_already_used[field_int_p1 - 1] = 1;
                                list_displayed[field_int_p1 - 1] = "X";
                                whichplayer = "O";
                                i_could_win_p1 = 1;
                                i_could_win_p2 = 0;
                                turn_counter += 1;
                                break;
                            }
                            else
                            { whichplayer = "X"; break; }
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("An error occured: {0}", e.Source);
                            Menu();
                            break;
                        }
             
                        


                    case "O":                 //Player 2's turn
                        Console.Clear();
                        Console.WriteLine("Player {0}: \n", whichplayer);
                        Console.WriteLine("{0}  |  {1}  |  {2}\n___|_____|___\n{3}  |  {4}  |  {5}\n___|_____|___\n{6}  |  {7}  |  {8}\n", list_displayed[0], list_displayed[1], list_displayed[2], list_displayed[3], list_displayed[4], list_displayed[5], list_displayed[6], list_displayed[7], list_displayed[8]);
                        Console.Write("Enter your desired field: "); 
                        
                        string field_p2 = Convert.ToString(Console.ReadLine());

                        //TryCatch to avoid crashing when a string is given instead of an integer
                        try
                        {
                            field_int_p2 = Convert.ToInt32(field_p2);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An error occured: {0}", e.Source);
                            field_int_p2 = 0;
                            Menu();
                        }



                        try
                        {
                            if (check_if_field_already_used[field_int_p2 - 1] != 1 & check_if_field_already_used[field_int_p2 - 1] != 2)
                            {
                                list[field_int_p2 - 1] = 2;
                                check_if_field_already_used[field_int_p2 - 1] = 2;
                                list_displayed[field_int_p2 - 1] = "O";
                                whichplayer = "X";
                                i_could_win_p1 = 0;
                                i_could_win_p2 = 1;
                                turn_counter += 1;
                                break;
                            }
                            else
                            { whichplayer = "O"; break; }
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("An error occured: {0}", e.Source);
                            Menu();
                            break;
                        }
                }
                has_someone_won = Has_someone_won(list);
                
                
              }
            while (has_someone_won == 0 && turn_counter < 9);
            
            //In case someone has won
            if (has_someone_won == 1)
            {
                string player_name_who_won = Who_won(i_could_win_p1, i_could_win_p2, list_displayed);
                Console.WriteLine("\n\nPlayer {0} has won !\n\n{1}  |  {2}  |  {3}\n___|_____|___\n{4}  |  {5}  |  {6}\n___|_____|___\n{7}  |  {8}  |  {9}\n", player_name_who_won, list_displayed[0], list_displayed[1], list_displayed[2], list_displayed[3], list_displayed[4], list_displayed[5], list_displayed[6], list_displayed[7], list_displayed[8]);
                Menu();
            }
            if (turn_counter >= 9)
            {
                Console.WriteLine("\n\nDraw!\n\n{0}  |  {1}  |  {2}\n___|_____|___\n{3}  |  {4}  |  {5}\n___|_____|___\n{6}  |  {7}  |  {8}\n", list_displayed[0], list_displayed[1], list_displayed[2], list_displayed[3], list_displayed[4], list_displayed[5], list_displayed[6], list_displayed[7], list_displayed[8]);
                Menu();
            }
            }




        public static void Spieler_vs_Bot(List<int> list, List<string> list_displayed, List<int> check_if_field_already_used)
        {





            int has_someone_won = 0, i_could_win_p1 = 1, i_could_win_p2 = 1, turn_counter = 0, field_int_p1, field_int_p2; string whichplayer = "X";
            
            Random r = new Random();
            do
            {


                switch (whichplayer)
                {
                    case "X":                 //Player 1's turn
                        Console.Clear();
                        Console.WriteLine("Player {0}: \n", whichplayer);
                        Console.WriteLine("{0}  |  {1}  |  {2}\n___|_____|___\n{3}  |  {4}  |  {5}\n___|_____|___\n{6}  |  {7}  |  {8}\n", list_displayed[0], list_displayed[1], list_displayed[2], list_displayed[3], list_displayed[4], list_displayed[5], list_displayed[6], list_displayed[7], list_displayed[8]);
                        Console.Write("Enter your desired field: ");

                        string field_p1 = Convert.ToString(Console.ReadLine());

                        //TryCatch to avoid crashing when a string is given instead of an integer
                        try
                        {
                            field_int_p1 = Convert.ToInt32(field_p1);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An error occured: {0}", e.Source);
                            field_int_p1 = 0;
                            Menu();
                        }

                        

                        if (check_if_field_already_used[field_int_p1 - 1] != 1 & check_if_field_already_used[field_int_p1 - 1] != 2)
                        {
                            list[field_int_p1 - 1] = 1;
                            check_if_field_already_used[field_int_p1 - 1] = 1;
                            list_displayed[field_int_p1 - 1] = "X";
                            whichplayer = "O";
                            i_could_win_p1 = 1;
                            i_could_win_p2 = 0;
                            turn_counter += 1;
                            break;
                        }
                        else
                        { whichplayer = "X"; break; }


                    case "O":                 //Bot's turn
                        Console.Clear();
                        Console.WriteLine("Player {0}: \n", whichplayer);
                        Console.WriteLine("{0}  |  {1}  |  {2}\n___|_____|___\n{3}  |  {4}  |  {5}\n___|_____|___\n{6}  |  {7}  |  {8}\n", list_displayed[0], list_displayed[1], list_displayed[2], list_displayed[3], list_displayed[4], list_displayed[5], list_displayed[6], list_displayed[7], list_displayed[8]);


                        field_int_p2 = r.Next(1, 9);



                        if (check_if_field_already_used[field_int_p2 - 1] != 1 & check_if_field_already_used[field_int_p2 - 1] != 2)
                        {
                            list[field_int_p2 - 1] = 2;
                            check_if_field_already_used[field_int_p2 - 1] = 2;
                            list_displayed[field_int_p2 - 1] = "O";
                            whichplayer = "X";
                            i_could_win_p1 = 0;
                            i_could_win_p2 = 1;
                            turn_counter += 1;
                            break;
                        }
                        else
                        { whichplayer = "O"; break; }
                }
                has_someone_won = Has_someone_won(list);


            }
            while (has_someone_won == 0 && turn_counter < 9);

            //In case someone has won
            if (has_someone_won == 1)
            {
                string player_name_who_won = Who_won(i_could_win_p1, i_could_win_p2, list_displayed);
                Console.WriteLine("\n\nPlayer {0} has won !\n\n{1}  |  {2}  |  {3}\n___|_____|___\n{4}  |  {5}  |  {6}\n___|_____|___\n{7}  |  {8}  |  {9}\n", player_name_who_won, list_displayed[0], list_displayed[1], list_displayed[2], list_displayed[3], list_displayed[4], list_displayed[5], list_displayed[6], list_displayed[7], list_displayed[8]);
                Menu();
            }
            if (turn_counter >= 9)
            {
                Console.WriteLine("\n\nDraw!\n\n{0}  |  {1}  |  {2}\n___|_____|___\n{3}  |  {4}  |  {5}\n___|_____|___\n{6}  |  {7}  |  {8}\n", list_displayed[0], list_displayed[1], list_displayed[2], list_displayed[3], list_displayed[4], list_displayed[5], list_displayed[6], list_displayed[7], list_displayed[8]);
                Menu();
            }









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



        public static string Who_won(int i_could_win_p1, int i_could_win_p2, List<string> list_displayed)
        {
            if (i_could_win_p1 > i_could_win_p2)
            { return "X"; }
            if (i_could_win_p1 < i_could_win_p2)
            { return "O"; }
            else
            { return "unknown"; }
        }
    }
}



