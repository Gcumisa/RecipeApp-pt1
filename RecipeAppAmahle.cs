using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppAmahle
{
    internal class Program
    {
      



        class Ingredient
        {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
        }

        class RecipeStep
        {
            public string Description { get; set; }
        }

        class Recipe
        {
            public List<Ingredient> Ingredients { get; set; }
            public List<RecipeStep> Steps { get; set; }

            public Recipe()
            {
                Ingredients = new List<Ingredient>();
                Steps = new List<RecipeStep>();
            }
        }

        class work
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Welcome to RecipeApp!");
                Console.WriteLine("----------------------");

                Recipe recipe = GetRecipeDetails();
                DisplayRecipe(recipe);

                Console.WriteLine("Enter scaling factor (0.5, 2, or 3):");
                double scale = Convert.ToDouble(Console.ReadLine());
                ScaleRecipe(recipe, scale);
                DisplayRecipe(recipe);
            }

            static Recipe GetRecipeDetails()
            {
                Recipe recipe = new Recipe();

                Console.WriteLine("Enter the number of ingredients:");
                int ingredientCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < ingredientCount; i++)
                {
                    Console.WriteLine($"Enter details for ingredient {i + 1}:");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Quantity: ");
                    double quantity = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Unit: ");
                    string unit = Console.ReadLine();

                    recipe.Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit });
                }

                Console.WriteLine("Enter the number of steps:");
                int stepCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < stepCount; i++)
                {
                    Console.WriteLine($"Enter description for step {i + 1}:");
                    string description = Console.ReadLine();
                    recipe.Steps.Add(new RecipeStep { Description = description });
                }

                return recipe;
            }

            static void DisplayRecipe(Recipe recipe)
            {
                Console.WriteLine("\nRecipe Details:");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
                }

                Console.WriteLine("\nSteps:");
                int stepNumber = 1;
                foreach (var step in recipe.Steps)
                {
                    Console.WriteLine($"{stepNumber}. {step.Description}");
                    stepNumber++;
                }
            }

            static void ScaleRecipe(Recipe recipe, double factor)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity *= factor;
                }
            }
        }
    }

}

