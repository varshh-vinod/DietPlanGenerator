using System;
using System.Collections.Generic;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 },
                new[] { 2, 8 },
                new[] { 5, 2 },
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" },
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 },
                new[] { 2, 8, 5, 1 },
                new[] { 5, 2, 4, 4 },
                new[] { "tFc", "tF", "Ftc" },
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 },
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 },
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 },
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" },
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] output = new int[dietPlans.Length];
            int[] calories = new int[protein.Length];

            List<int> IndexList = new List<int>();

            for (int i = 0; i < protein.Length; i++)
            {
                calories[i] = protein[i] * 5 + carbs[i] * 5 + fat[i] * 9;
                IndexList.Add(i);
            }


            for (int i = 0; i < dietPlans.Length; i++)
            {
                List<int> IndexListOfSelectedMeals = new List<int>();
                var IndicesListUnderConsideration = IndexList;
                int min = 10000, max = -1;
                for (int j = 0; j < dietPlans[i].Length; j++)
                {
                    IndexListOfSelectedMeals = new List<int>();
                    switch (dietPlans[i][j])
                    {
                         case 'C' :         foreach (int k in IndicesListUnderConsideration)
                                                if (max < carbs[k])
                                                     max = carbs[k];
                                            foreach (int k in IndicesListUnderConsideration)
                                                if (max == carbs[k])
                                                    IndexListOfSelectedMeals.Add(k);
                                            break;
                         case 'c' :         foreach (int k in IndicesListUnderConsideration)
                                                if (min > carbs[k])
                                                     min = carbs[k];
                                            foreach (int k in IndicesListUnderConsideration)
                                                if (min == carbs[k])
                                                    IndexListOfSelectedMeals.Add(k);
                                            break;

                         case 'P' :         foreach (int k in IndicesListUnderConsideration)
                                                if (max < protein[k])
                                                    max = protein[k];
                                            foreach (int k in IndicesListUnderConsideration)
                                                if (max == protein[k])
                                                    IndexListOfSelectedMeals.Add(k);
                                            break;

                         case 'p' :         foreach (int k in IndicesListUnderConsideration)
                                                if (min > protein[k])
                                                    min = protein[k];
                                            foreach (int k in IndicesListUnderConsideration)
                                                if (min == protein[k])
                                                    IndexListOfSelectedMeals.Add(k);
                                            break;
                         case 'F' :         foreach (int k in IndicesListUnderConsideration)
                                                if (max < fat[k])
                                                    max = fat[k];
                                            foreach (int k in IndicesListUnderConsideration)
                                                if (max == fat[k])
                                                    IndexListOfSelectedMeals.Add(k);
                                            break;
                         case 'f' :         foreach (int k in IndicesListUnderConsideration)
                                                if (min > fat[k])
                                                    min = fat[k];
                                            foreach (int k in IndicesListUnderConsideration)
                                                if (min == fat[k])
                                                    IndexListOfSelectedMeals.Add(k);
                                            break;
                         case 'T' :         foreach (int k in IndicesListUnderConsideration)
                                                if (max < calories[k])
                                                    max = calories[k];
                                            foreach (int k in IndicesListUnderConsideration)
                                                if (max == calories[k])
                                                    IndexListOfSelectedMeals.Add(k);
                                            break;
                         case 't' :         foreach (int k in IndicesListUnderConsideration)
                                                if (min > calories[k])
                                                    min = calories[k];
                                            foreach (int k in IndicesListUnderConsideration)
                                                if (min == calories[k])
                                                    IndexListOfSelectedMeals.Add(k);
                                            break;
                    }
                    if (IndexListOfSelectedMeals.Count == 1)
                        break;
                    IndicesListUnderConsideration = IndexListOfSelectedMeals;
                }
                if(dietPlans[i].Equals(""))
                    IndexListOfSelectedMeals.Add(0);
                output[i] = IndexListOfSelectedMeals[0];
            }
            return output;
        }
    }
}
