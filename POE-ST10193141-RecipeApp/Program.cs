using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace POE_Part2_ST10193141_RecipeApp
{
    class Program
    {
        static List<Recipe> recipes = new List<Recipe>(); // List to store recipes 
        /*
         * MEnue 
         * Create Recipe
         * Display Recipe list
         * Select recipe to dispay 
         * Reset Quantity
         * Reset Recipe 
         * Scale Recipe 
         * Calculate Calories
         */
        static void CreateRecipe()//Create a new Recipe
        {
            Recipe recipe = new Recipe();


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("- New_Recipe: \r\n");

            Console.Write("Enter Recipe name: ");
            recipe.Name = Console.ReadLine();//grab name and store in recipe

            Console.Write("Enter number of ingredients: ");
            int NI_Loop = Convert.ToInt32(Console.ReadLine());//number of times loop will repeate and/Ingredient Size
            int count = 0;
            for (int i = 0; i < NI_Loop; i++)
            {
                count = i;
                count++;//adds +1 everytime the loop repeats/stores vars 
                Ingredient ingredient = new Ingredient();
                Console.Write($"Enter Ingredient Name [{count}]: ");
                ingredient.Name = Console.ReadLine();
                Console.Write($"Enter {ingredient.Name} Quantity [{count}]: ");
                ingredient.Quantity = Convert.ToDouble(Console.ReadLine());
                Console.Write($"Enter {ingredient.Name}-unit-of-measurement [{count}]: ");

                ingredient.Unit = Console.ReadLine();
                Console.Write($"Enter Ingredient Number of calories [{count}]: ");
                ingredient.Calories = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Enter Ingredient food group [{count}]: \r\n" +
                "1. Fruit\r\n2. Vegetables\r\n3. Grains\r\n4. Dairy\r\n5. Protein\r\n");
                int FD = Convert.ToInt32(Console.ReadLine());
                if (FD == 1)
                {
                    ingredient.FoodGroup = "Fruit";
                }
                else if (FD == 2)
                {
                    ingredient.FoodGroup = "Vegetables";
                }
                else if (FD == 3)
                {
                    ingredient.FoodGroup = "Grains";
                }
                else if (FD == 4)
                {
                    ingredient.FoodGroup = "Dairy";
                }
                else if (FD == 5)
                {
                    ingredient.FoodGroup = "Protein";
                }

                //ingredient.FoodGroup =FD;

                recipe.Ingredients.Add(ingredient);
            }

            Console.Write("Enter number of steps for Description: ");//step size 
            int NSteps = Convert.ToInt32(Console.ReadLine());
            count = 0;
            for (int i = 0; i < NSteps; i++)
            {
                count = i;
                count++;
                Step step = new Step();
                Console.Write($"Enter description of step {count}: ");
                step.Description = Console.ReadLine();

                recipe.Steps.Add(step);
            }

            recipes.Add(recipe);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Recipe details Captured successfully!");
        }


        static void SelectRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("Select a Recipe:");
            int count = 0;
            for (int i = 0; i < recipes.Count; i++)
            {
                count = i;
                count++;
                Console.WriteLine($"{count}. {recipes[i].Name}");
            }

            Console.Write("Enter the recipe number: ");
            int RNumber = Convert.ToInt32(Console.ReadLine());

            if (RNumber >= 1 && RNumber <= recipes.Count)
            {
                Recipe selectedRecipe = recipes[RNumber - 1];
                PrintRecipe(selectedRecipe);


            }
            else
            {
                Console.WriteLine("Invalid recipe number.");
            }
        }
        static void Print()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (recipes.Count == 0)
            {
                Console.WriteLine("Null- No recipes found.");
                return;
            }

            Console.WriteLine("All Recipes:");
            List<Recipe> sortedRecipes = recipes.OrderBy(r => r.Name).ToList();//print recipes in alphabetical order

            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }
        static void PrintRecipe(Recipe recipe)//Display Recipe
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Recipe: \r\n" +
                "=================================================================\r\n");
            Console.WriteLine($"Recipe Name: {recipe.Name}");//Grap and print 
            Console.WriteLine("Ingredients: \r\n");

            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"Ingredient Name: {ingredient.Name}");
                Console.WriteLine($"Quantity: {ingredient.Quantity};");
                Console.WriteLine($"Unit-Of-Measurement: {ingredient.Unit}");
                Console.WriteLine($"Calories: {ingredient.Calories}");
                Console.WriteLine($"Food Group: {ingredient.FoodGroup}");
            }
            Console.WriteLine("Steps:");
            int count = 0;
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                count = i;
                count++;
                Console.WriteLine($"{count}. {recipe.Steps[i].Description}");
            }


            int TotalCal = recipe.Ingredients.Sum(ingredient => ingredient.Calories);
            Console.WriteLine($"Total Calories: {TotalCal}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (TotalCal > 300)
            {
                Console.WriteLine("Warning: Total calories exceed 300! \r\n -------------------------------------------------------------------------");
            }
        }
        static void Sscale()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("Select a Recipe:");
            int count = 0;
            for (int i = 0; i < recipes.Count; i++)
            {
                count = i;
                count++;
                Console.WriteLine($"{count}. {recipes[i].Name}");
            }

            Console.Write("Enter the recipe number: ");
            int RNumber = Convert.ToInt32(Console.ReadLine());

            if (RNumber >= 1 && RNumber <= recipes.Count)
            {
                Recipe selectedRecipe = recipes[RNumber - 1];
                Scale(selectedRecipe);

            }
        }
        static void Scale(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Scale: \r\n" +
                "=================================================================\r\n");

            Console.WriteLine("What would you like to scale by:\r\n1.--0.5(Half)\r\n2.--2(Double)\r\n3.--3(Triple): \r\n");
            int Option = 0;
            Option = Convert.ToInt32(Console.ReadLine());
           
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.OQ = ingredient.Quantity;
                if (Option == 1)
                {

                    double Q1 = ingredient.Quantity;
                    ingredient.Quantity = Q1 / 0.5;
                    Console.WriteLine($"Quantity-{ingredient.Quantity};");


                }
                else if (Option == 2)
                {

                    double Q1 = ingredient.Quantity;
                    ingredient.Quantity = Q1 / 2;
                    Console.WriteLine($"Quantity-{ingredient.Quantity};");



                }
                else if (Option == 3)
                {

                    double Q1 = ingredient.Quantity;
                    ingredient.Quantity = Q1 / 3;
                    Console.WriteLine($"Quantity-{ingredient.Quantity};");



                }
                Console.WriteLine("Quantities Succesfully Scaled ");
            }
        }
        static void Rscale()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("Select Recipe you would like to reset Quantity:");
            int count = 0;
            for (int i = 0; i < recipes.Count; i++)
            {
                count = i;
                count++;
                Console.WriteLine($"{count}. {recipes[i].Name}");
            }

            Console.Write("Enter the recipe number: ");
            int RNumber = Convert.ToInt32(Console.ReadLine());

            if (RNumber >= 1 && RNumber <= recipes.Count)
            {
                Recipe selectedRecipe = recipes[RNumber - 1];
                ResetQuantity(selectedRecipe);

            }
        }
        static void ResetQuantity(Recipe recipe)
        {
            // if original value is not equals to new value print new value 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Would you like to reset Quantities \r\n1.Yes\r\n2. No");
            int Option = 0;
            Option = Convert.ToInt32(Console.ReadLine());
            if (Option == 1)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity = ingredient.OQ;
                    Console.Write($"Quantity: {ingredient.Quantity}");

                }
            }
            else if (Option == 2)
            {
                Console.Write("Recipe Quantities not Reset!");

            }


        }

        static void ResetRecipe()
        {

            Console.WriteLine("Do you want to reset resipe \r\n 1.yes \r\n 2.No\r\n");

            int Option = 0;
            Option = Convert.ToInt32(Console.ReadLine());
            if (Option == 1)
            {
                recipes.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Recipes Successfully Reset!\r\n==============================\r\n");
            }
            else if (Option == 2)
            { Console.WriteLine("recipe not reset!"); }

        }
        static void ReRp()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("Select Recipe you would like to reset Quantity:");
            int count = 0;
            for (int i = 0; i < recipes.Count; i++)
            {
                count = i;
                count++;
                Console.WriteLine($"{count}. {recipes[i].Name}");
            }

            Console.Write("Enter the recipe number: ");
            int RNumber = Convert.ToInt32(Console.ReadLine());

            if (RNumber >= 1 && RNumber <= recipes.Count)
            {
                Recipe selectedRecipe = recipes[RNumber - 1];
                ReRecipe(selectedRecipe);

            }
        }
        static void ReRecipe(Recipe recipe)
        {

            Console.WriteLine("Do yo want to reset all resipes \r\n 1.yes \r\n 2.No\r\n");

            int Option = 0;
            Option = Convert.ToInt32(Console.ReadLine());
            if (Option == 1)
            {
                recipes.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Recipes Successfully Reset!\r\n==============================\r\n");
            }
            else if (Option == 2)
            { Console.WriteLine("recipe not reset!"); }

        }


        //return TotalCal;







        static void Main(string[] args)
        {


            while (true)//Repeat loop until app exits
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1. Enter a new recipe" + "\r\n" +//Recipe Attrributes
                                  "2. Display all recipes" + "\r\n" +
                                  "3. Select a recipe to Print" + "\r\n" +
                                  "4. Reset-All-Recipes" + "\r\n" +
                                  "5. Reset selected recipe" + "\r\n" +
                                  "6. Scale Quantities" + "\r\n" +
                                  "7. Reset Quantities" + "\r\n" +
                                  "8. Exit ");
                Console.Write("Enter your Option: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateRecipe();//Create Recpe * Working 
                        break;

                    case 2:
                        Print();//Print all recipes* working
                        break;

                    case 3:
                        SelectRecipe();//Print selected Recipe *working
                        break;

                    case 4://Option 4
                        ResetRecipe();//reset All Recipe *Working
                        break;

                    case 5:
                        ReRp();//reset Selected Recipe *Working
                        break;

                    case 6:
                        Sscale();//scale Quantities *working
                        break;
                    case 7:
                        Rscale();//reset Quantities *Working
                        break;

                    case 8:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

