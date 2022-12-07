public static class Day1
{
    public static void Solve()
    {
        string text = System.IO.File.ReadAllText("./ProblemInput/Day1Input.txt");

        List<int> calories = new List<int>();
        using (StringReader reader = new StringReader(text))
        {
            int current = 0;

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    calories.Add(current);
                    current = 0;
                }
                else current += Int32.Parse(line);
            }
        }
        calories.Sort();
        calories.Reverse();
        Console.WriteLine(calories[0]);
        Console.WriteLine( calories.Take(3).Sum());
    }

}
