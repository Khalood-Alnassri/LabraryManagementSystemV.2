using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LabraryManagementSystemV._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] titles = new string[100];
            string[] authors = new string[100];
            string[] isbns = new string[100];
            bool[] available = new bool[100];
            string[] borrowers = new string[100];
            string[] bookCategory = new string[100];
            int[] borrowCount = new int[100];
            DateOnly[] returndate = new DateOnly[100];
            double[] lateFees = new double[100];

            int lastIndex = 0; // Initialize lastIndex to -1 since no books are added yet

            titles[lastIndex] = "MATH";
            authors[lastIndex] = "HASNA ";
            isbns[lastIndex] = "111";
            available[lastIndex] = true;
            borrowers[lastIndex] = "";
            bookCategory[lastIndex] = "Sciences";
            borrowCount[lastIndex] = 3;

            lastIndex++; //1

            titles[lastIndex] = "Algorithms";
            authors[lastIndex] = "HOOR";
            isbns[lastIndex] = "222";
            available[lastIndex] = true;
            borrowers[lastIndex] = "";
            bookCategory[lastIndex] = "Database";
            borrowCount[lastIndex] = 6;


            lastIndex++; //2

            titles[lastIndex] = " Sciences";
            authors[lastIndex] = "NOOR ";
            isbns[lastIndex] = "333";
            available[lastIndex] = false;
            borrowers[lastIndex] = "Karim";
            bookCategory[lastIndex] = "Sciences";
            borrowCount[lastIndex] = 2;
            




            bool exit = false;

            while (exit == false)
            {



                Console.WriteLine("===== Library Management System =====");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. Add New Book");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. List All Available Books");
                Console.WriteLine("6. Transfer Book");
                Console.WriteLine("7. View Most Popular Books.");
                Console.WriteLine("8. Search Books by Category");
                Console.WriteLine("9. Exit");
                Console.Write("Choose option: ");


                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        lastIndex++; //4

                        Console.Write("Title: ");
                        titles[lastIndex] = Console.ReadLine();

                        Console.Write("Author: ");
                        authors[lastIndex] = Console.ReadLine();

                        Console.Write("ISBN: ");
                        isbns[lastIndex] = Console.ReadLine();

                        Console.Write("bookCategory: ");
                        bookCategory[lastIndex] = Console.ReadLine();

                        available[lastIndex] = true;
                        borrowers[lastIndex] = "";

                        Console.WriteLine("Book added");
                        break;

                    case 2: //borrowing

                        Console.Write("Enter ISBN or Title : ");
                        string Input = Console.ReadLine();

             
                        bool Found = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (titles[i] == Input || isbns[i] == Input )
                            {
                                //book is found in system
                                Found = true;

                                if (available[i] == true)
                                {
                                    Console.Write("Borrower name: ");
                                    borrowers[i] = Console.ReadLine();
                                    available[i] = false;
                                    borrowCount[i]++; 
                                    DateOnly returnDate = DateOnly.FromDateTime(DateTime.Today).AddDays(10); // return date
                                    Console.WriteLine("Book borrowed successfully");
                                    Console.WriteLine("Return date: " + returnDate.ToShortDateString()); // return date
                                }
                                else
                                {
                                    Console.WriteLine("Book already borrowed");
                                }

                                break;


                            }

                        }

                        if (Found == false)
                        {
                            Console.WriteLine("Book not found");
                        }



                        break;



                    case 3:
                        //Return Book

                        Console.Write("Enter ISBN or Title : ");
                        string input = Console.ReadLine();

                        bool found = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (titles[i] == input || isbns[i] == input )
                            {
                                //book is found in system
                                found = true;
                                if (available[i] == false)
                                {


                                    DateOnly today = DateOnly.FromDateTime(DateTime.Today); 
                                    int FeePerDay = 10;

                                    if (today > returndate[i])
                                    {

                                        int lateDays = (today.DayNumber - returndate[i].DayNumber); 
                                        lateFees[i] = lateDays * FeePerDay;

                                        Console.WriteLine("Late days: " + lateDays);
                                        Console.WriteLine("Late fee: " + lateFees[i] + " OMR");

                                    }
                                    else
                                    {
                                        lateFees[i] = 0;
                                        Console.WriteLine("Book returned on time. No late fees.");
                                    }

                                    borrowers[i] = "";
                                    available[i] = true;

                                    Console.WriteLine("Book returned successfully");
                                }


                            }

                        }

                        if (found == false)
                        {
                            Console.WriteLine("Book not found");
                        }




                        break;










                    case 4:
                        // Search Book

                        Console.Write("Enter ISBN or Title or book Category: ");
                        string INPUT = Console.ReadLine();

                        bool FOUND = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (titles[i] == INPUT || isbns[i] == INPUT || bookCategory[i] == INPUT)
                            {
                                //book is found in system
                                FOUND = true;


                                Console.WriteLine("Book title: " + titles[i] + ", Book Author:" + authors[i] + ", Book ISBN:" + isbns[i] + ", Book availability:" + available[i] + ", Book category: " + bookCategory[i] );



                                break;


                            }

                        }

                        if (FOUND == false)
                        {
                            Console.WriteLine("Book not found");
                        }




                        break;











                    case 5: 
                        //print all availbel books

                        Console.WriteLine("Available Books:");

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (available[i] == true)
                            {
                                Console.WriteLine("Title: " + titles[i] + " ,Author: " + authors[i] + " ,ISBN: " + isbns[i] + " ,Category: " + bookCategory[i]);
                            }
                        }


                        break;


                    case 6:
                        // Transfer Book

                        Console.Write("Enter first borrower name:");
                        string firstBorrower = Console.ReadLine();


                        Console.Write("Enter second borrower name:");
                        string secondBorrower = Console.ReadLine();


                        bool firstBorrowerFound = false;
                        int firstBorrowerIndex = 0;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (firstBorrower == borrowers[i])
                            {
                                firstBorrowerIndex = i; // مكان / رقم تواجد الشخص الاول


                                firstBorrowerFound = true;
                                break;

                            }
                        }
                        if (firstBorrowerFound == false)
                        {
                            Console.WriteLine("current borrower name not found");
                        }
                        else
                        {
                            bool secondBorrowerFound = false;
                            int secondBorrowerIndex = 0;
                            for (int i = 0; i < 100; i++)
                            {
                                if (secondBorrower == borrowers[i])
                                {
                                    secondBorrowerIndex = i;//مكان / رقم تواجد الشخص التانى

                                    secondBorrowerFound = true;
                                    break;

                                }
                            }
                            if (secondBorrowerFound == false)
                            {
                                Console.WriteLine("New borrower name not found");
                            }
                            else
                            {

                                string temp = "";

                                temp = borrowers[firstBorrowerIndex];

                                borrowers[firstBorrowerIndex] = borrowers[secondBorrowerIndex];

                                borrowers[secondBorrowerIndex] = temp;

                            }
                        }







                        break;

                    case 7:
                        // View Most Popular Books
                        
                        int populerBook = 0;
                        int populerBookIndex = 0;
                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (populerBook < borrowCount[i])
                            {
                                
                                populerBook = borrowCount[i];
                                populerBookIndex = i;
                            }
                        }
                        if ((populerBook != 0))
                        {
                            Console.WriteLine("Most populer book :");
                            Console.WriteLine("Tittle :" + titles[populerBookIndex]);
                            Console.WriteLine("ISBN :" + isbns[populerBookIndex]);
                            Console.WriteLine("Authors :" + authors[populerBookIndex]);
                            Console.WriteLine("Category :" + bookCategory[populerBookIndex]);
                            Console.WriteLine("Availability :" + available[populerBookIndex]);
                            Console.WriteLine("Borrow Count :" + borrowCount[populerBookIndex]);

                        }
                        else
                        {
                            Console.WriteLine("No borrowed yet!");
                        }



                        break;

                        case 8:
                        // Search Books by Category

                        Console.WriteLine("Enter book category : ");
                        string category = Console.ReadLine();

                        bool book_found = false;
                        for (int i = 0; i < lastIndex; i++)
                        {
                            if ((category == bookCategory[i])) 
                            {

                                book_found = true;

                                string availabilityStatus = available[i] ? "Available" : "Borrowed";
                                Console.WriteLine("Title: " + titles[i] + " ,Author: " + authors[i] + " ,ISBN: " + isbns[i] + " ,Category: " + bookCategory[i] + " ,BorrowCount: " + borrowCount[i] + " ,Status: " + availabilityStatus);

                            }
                        }
                         
                        if (book_found == false)
                        {
                            Console.WriteLine("No book found in this category.");
                        }

                        break;


                    case 9:
                        //Exit

                        Console.WriteLine("Exiting program...");
                        Console.WriteLine("-----------------------------");
                        exit = true;

                        break;


                    default:

                        Console.WriteLine("Invalid option. Please try again.");

                        break;







                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }





        }
    }
}