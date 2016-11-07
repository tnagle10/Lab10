using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;

            List<Movie> movieList = createInitMovieList();
            Hashtable categories = createCategoryList(movieList);



            do
            {

                Console.WriteLine("Welcome to the Grand Circus movie database.  Please choose an option below:");

                string[] options = {
                                     "List current movies",
                                     "Find movie by title" ,
                                     "Find movie by category",
                                     "Add movie" };

                genList(options, out option);

                switch (option)
                {

                    case 1:
                        listMovies(movieList);

                        break;
                    case 2:
                        findMovieByTitle(movieList);
                        break;
                    case 3:
                        findMoviesByCategory(movieList,categories);
                        break;

                   case 4:
                        addMovies(movieList);
                        break;


                    default:
                        break;
                }

            } while (keepGoing());


        }



        static void genList(string[] names, out int option)
        {
            Boolean valid = false;
            int input = 0;

            while (valid == false)
            {

                Console.WriteLine("Please choose one of the following options: ");
                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine(i + 1 + ": " + names[i]);
                }




                if (!(int.TryParse(Console.ReadLine(), out input)))
                {
                    Console.WriteLine("You entered an invalid number");

                }



                if ((input > 0) && (input <= names.Length + 1))
                {
                    Console.WriteLine("\nYou chose " + names[input - 1] + "\n");
                    valid = true;
                }
                else
                {
                    valid = false;
                }


            }
            option = input;

        }

        static void genList(Hashtable catHash,out string category)
        {
            Boolean valid = false;
            int input = 0;
            int ctr = 1;
            int namesEntry = 0;
            string[] names = new string[catHash.Count];
            while (valid == false)
            {

                Console.WriteLine("Please choose one of the following options: ");

                foreach (DictionaryEntry entry in catHash)
                {
                    //Console.WriteLine(ctr + ": " + entry.Value);
                    names[namesEntry] = entry.Value.ToString();
                    ctr++;
                    namesEntry++;
                }



                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine(i + 1 + ": " + names[i]);
                }




                if (!(int.TryParse(Console.ReadLine(), out input)))
                {
                    Console.WriteLine("You entered an invalid number");

                }



                if ((input > 0) && (input <= names.Length + 1))
                {
                    Console.WriteLine("\nYou chose " + names[input - 1] + "\n");
                    
                    valid = true;
                }
                else
                {
                    valid = false;
                }


            }
            category = names[input - 1];

        }

        static bool keepGoing()
        {
            /* Name: keepGoing
            * Description:  This method implements a loop to determine if users wants to continue
            * Input:  None
            * Output: Returns false if user doesn't want to continue.  Otherwise returns true.
            *         Outputs values to Console
            */


            // If user enters "q", execute exit procedure
            Console.WriteLine("\nContinue? (y/n):");
            string input = Console.ReadLine();

            if (input == "n")
            {

                return false;

            }

            return true;
        }

        public static List<Movie> createInitMovieList()
        {
            List<Movie> gcMovies = new List<Movie>();


            // Add movies to list
            gcMovies.Add(new Movie("Star Wars", "scifi"));
            gcMovies.Add(new Movie("The Empire Strikes Back", "scifi"));
            gcMovies.Add(new Movie("Return of the Jedi", "scifi"));
            gcMovies.Add(new Movie("The Jungle Book", "animated"));
            gcMovies.Add(new Movie("Cars", "animated"));
            gcMovies.Add(new Movie("Goodfellas", "drama"));
            gcMovies.Add(new Movie("Godfather I", "drama"));
            gcMovies.Add(new Movie("Godfather II", "drama"));
            gcMovies.Add(new Movie("Halloween", "horror"));
            gcMovies.Add(new Movie("Scream", "horror"));


            return gcMovies;
        }

        static Hashtable createCategoryList(List<Movie> movieList)
        {
            Hashtable categories = new Hashtable();
            foreach (Movie movie in movieList)
            {
                //Console.WriteLine(movie.Category1.GetHashCode());
                try
                {
                    categories.Add(movie.Category1.GetHashCode(), movie.Category1);
                }
                catch (Exception)
                {
                    
                }
                
            }

            return categories;

            
            
        }



        static void Search(Hashtable HTable)
        {
            Console.Write("Please enter the name your are looking for:  ");
            string input = Console.ReadLine();

            if (HTable.ContainsValue(input))
            {
                Console.WriteLine("Found it");

            }
            else
            {
                Console.WriteLine("Not found");
            }


        }


        public static void listMovies(List<Movie> input)
        {
            Console.WriteLine("\nTitle                   Category");
            Console.WriteLine("**********************************");

            foreach (Movie movies in input)
            {


                Console.WriteLine(movies.Title1.PadRight(25) + " " + movies.Category1.PadRight(10));

            }

        }

        public static void addMovies(List<Movie> input)
        {
            string title;
            string category;

            Console.WriteLine("Enter a new movie");

            title = getMovieAttributeS("title");
            category = getMovieAttributeS("category");


            input.Add(new Movie(title, category));


        }

        public static string getMovieAttributeS(string input)
        {
            string output = "";
            bool good = false;
            while (!(good))
            {
                Console.Write("\nEnter movie {0}: ", input);
                output = Console.ReadLine();
                if (output == "")
                {
                    Console.WriteLine("You entered an invalid {0}.  Please try again", input);
                    output = "";

                }
                else
                {
                    good = true;
                }

            }

            return output;
        }

        //public static void findMovieByTitle(List<Movie> input)
        //{
        //    string title = getMovieAttributeS("title");
        //    int loc = input.FindIndex(x => x.Title1 == title);
        //    if (loc >= 0)
        //    {
        //        Console.WriteLine("Congratulations, we have movie {0} ", input[loc].Title1);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Sorry, we don't have that title");
        //    }

        //}




        public static void findMovieByTitle(List<Movie> input)
        {
            string title = getMovieAttributeS("title");


            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Title1 == title)
                {
                    Console.WriteLine("Congratulations, we have movie {0} ", input[i].Title1);
                    return;
                }
            }

            Console.WriteLine("Sorry we don't have {0} ", title);


        }


        public static void findMoviesByCategory(List<Movie> movieList, Hashtable catHash)
        {
            ////Search(categories);
            //Console.WriteLine("Please choose one of the following categories to search for: ");
            //foreach (DictionaryEntry entry in catHash)
            //{
            //    Console.WriteLine("{0}", entry.Value);
            //}

            string cat;
            genList(catHash,out cat);

            //string category = getMovieAttributeS(cat);
            Console.WriteLine(cat);
            List<Movie> moviesFound = movieList.FindAll(x => x.Category1 == cat);
            listMovies(moviesFound);

        }





    }
}