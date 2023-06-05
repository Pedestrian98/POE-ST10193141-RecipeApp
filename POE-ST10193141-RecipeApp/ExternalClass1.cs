using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_Part2_ST10193141_RecipeApp
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double OQ { get; set; }
        public double Q1 { get; set; }
        public string Unit { get; set; }
        public float FB { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }
    class Step
    {
        public string Description { get; set; }
    }
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }
    }
}





/* public void Menue()
 {
     Console.ForegroundColor = ConsoleColor.Green;
    // ExternalClass2 EXT2 = new ExternalClass2();
     //ExternalClass3 EXT3 = new ExternalClass3();
     //ExternalClass4 EXT4 = new ExternalClass4();
     Console.WriteLine("Choose option to proceed: \r\n" +
                       "1. Create New Recipe \r\n" +
                       "2. Search and Display Recipe \r\n" +
                       "3. Reset Recipe \r\n" +
                       "4. Calcute and Display\r\n" +
                       "5. Exit Application");
     int Option = 0;
     if (Option == 1)
     {
     //    EXT2.CreateRecipe();

     }
     //menue
     //create recipe
     //search print recipe
     //delete/reset recipe
     //add one recipe
     //calculate calories
     //exit
}
}
}*/


