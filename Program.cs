using System;

namespace challenge_test {
    class Program {

        static void Main (string[] args) {

            int tester = 0;
            int index = 0;
            string menu = null;
            bool DupChk = false;
            int upper = 0;

            //UPPER LIMIT DECLARE

            Console.WriteLine ("Enter upper limit of numbers to be drawn");
            while (tester == 0) {
                bool nub = int.TryParse (Console.ReadLine (), out upper);
                if (upper < 0 || nub == false)
                    Console.WriteLine ("Enter valid number");
                else if (upper == 0)
                    Console.WriteLine ("You need to enter a value larger than 0!");
                else break;
            }
            int[] log = new int[upper];
            int[] logOrdered = new int[upper];

            //RANDOM INITIATOR 
            Random r = new Random ();
            int rInt = r.Next (1, upper);

            while (menu != "4") {

                //MAIN MENU//
                Console.WriteLine ("Welcome to the Swinburne Bingo Club. Upper Limit = " + upper + ". Numbers Drawn = " + index);
                Console.WriteLine ("1. Draw next number");
                Console.WriteLine ("2. View all drawn numbers");
                Console.WriteLine ("3. Check specific numbers");
                Console.WriteLine ("4. Exit");

                menu = Console.ReadLine ();

                //NUMER DRAW//
                if (menu == "1") {

                    if (index == upper) {
                        Console.Clear ();
                        Console.WriteLine ("You have reached the upper limit");
                    } else {

                        while (tester == 0) {
                            DupChk = false;
                            rInt = r.Next (1, upper + 1);
                            for (int i = 0; i < index; i++) {
                                if (log[i] == rInt) DupChk = true;
                            }
                            if (DupChk == false) {
                                log[index] = rInt;
                                index++;
                                Console.Clear ();
                                Console.WriteLine ("You have drawn " + rInt + "!");
                                Console.WriteLine ();
                                break;
                            }
                        }
                    }
                }
                //PRINT ARRAY//
                else if (menu == "2") {

                    Console.Clear ();

                    Console.WriteLine ("1. Print numbers in drawn order");
                    Console.WriteLine ("2. Print numbers in sequential order");
                    string Twochoice = Console.ReadLine ();

                    //Print in drawn order//
                    if (Twochoice == "1") {
                        Console.Clear ();
                        for (int i = 0; i < index; i++) {
                            Console.WriteLine ((i + 1) + ". " + log[i]);
                        }
                    }
                    //print in sequence//                   
                    else if (Twochoice == "2") {
                        log.CopyTo (logOrdered, 0);
                        Array.Sort (logOrdered);
                        Console.Clear ();
                        int weirdchk = upper - index;

                        for (int i = (upper - index); i < upper; i++) {
                            Console.WriteLine ((i + 1 - weirdchk) + ". " + logOrdered[i]);
                        }

                    } else Console.WriteLine ("Invalid selection");
                }
                //FIND NUMBER//
                else if (menu == "3") {
                    bool numChk = false;
                    int search = 0;
                    Console.Clear ();
                    Console.WriteLine ("Enter the number you would like to confirm");
                    
                    while (tester == 0) {
                        bool nub = int.TryParse (Console.ReadLine (), out search);
                        if (search < 0 || nub == false)
                            Console.WriteLine ("Enter valid number");
                        else if (search == 0)
                            Console.WriteLine ("You need to enter a value larger than 0!");
                        else break;
                    }

                    for (int i = 0; i < index; i++) {
                        if (log[i] == search) numChk = true;
                    }
                    if (numChk == true) Console.WriteLine ("The number " + search + " has been drawn");
                    else Console.WriteLine ("The number " + search + " has NOT been drawn");

                }
                //EXIT GAME//
                else if (menu == "4") {
                    Console.WriteLine ("Thank you for playing :)");
                } else Console.WriteLine ("Invalid Selection");

            }
        }
    }
}