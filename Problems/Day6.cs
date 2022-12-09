public static class Day6
{
    public static void Solve()
    {
        char[] data = System.IO.File.ReadAllText("./ProblemInput/Day6Input.txt").TrimEnd().ToArray();
        HashSet<char> characters = new HashSet<char>();
        for (int i = 0; i < data.Length - 4; i++)
        {
            if (data[i..(i + 4)].Distinct().Count() == 4)
            {
                Console.WriteLine(i + 4);
                break;
            }
        }

        //Part 2 Find 14 unique
        for (int i = 0; i < data.Length - 14; i++)
        {
            if (data[i..(i + 14)].Distinct().Count() == 14)
            {
                Console.WriteLine(i + 14);
                break;
            }
        }
    }
}
