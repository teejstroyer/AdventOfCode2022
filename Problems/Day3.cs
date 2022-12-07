public static class Day3
{
    public static void Solve()
    {
        //a=1
        //A=27
        var text = System.IO.File.ReadAllText("./ProblemInput/Day3Input.txt").Split('\n');
        int totalSum = 0, part2Sum = 0;

        for (int i = 0; i < text.Length - 3; i += 3)
        {
            //Part 1. Get Item that is in both and add their values
            //Done by groups of 3 to accomodate part 2
            totalSum += new HashSet<char>(text[i].Substring(0, text[i].Length / 2))
                .Intersect(new HashSet<char>(text[i].Substring(text[i].Length / 2, text[i].Length / 2)))
                .Sum(j => char.IsUpper(j) ? j - 'A' + 27 : j - 'a' + 1);

            totalSum += new HashSet<char>(text[i + 1].Substring(0, text[i + 1].Length / 2))
                .Intersect(new HashSet<char>(text[i + 1].Substring(text[i + 1].Length / 2, text[i + 1].Length / 2)))
                .Sum(j => char.IsUpper(j) ? j - 'A' + 27 : j - 'a' + 1);

            totalSum += new HashSet<char>(text[i + 2].Substring(0, text[i + 2].Length / 2))
                .Intersect(new HashSet<char>(text[i + 2].Substring(text[i + 2].Length / 2, text[i + 2].Length / 2)))
                .Sum(j => char.IsUpper(j) ? j - 'A' + 27 : j - 'a' + 1);

            //Part 2 find item all 3 groups
            part2Sum += new HashSet<char>(text[i])
                .Intersect(new HashSet<char>(text[i + 1])).Intersect(new HashSet<char>(text[i + 2]))
                .Sum(j => char.IsUpper(j) ? j - 'A' + 27 : j - 'a' + 1);
        }

        Console.WriteLine(totalSum);
        Console.WriteLine(part2Sum);
    }
}
