public static class Day4
{
    public static void Solve()
    {
        int[][] groups = System.IO.File.ReadAllText("./ProblemInput/Day4Input.txt")
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(i => Array.ConvertAll(i.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse).ToArray())
            .ToArray();

        int countContained = 0;
        int countOverlaps = 0;
        for (int i = 0; i < groups.Length; i++)
        {
            if (groups[i][0] >= groups[i][2] && groups[i][1] <= groups[i][3] || groups[i][2] >= groups[i][0] && groups[i][3] <= groups[i][1])
                countContained++;
            if (groups[i][0] <= groups[i][3] && groups[i][2] <= groups[i][1])
                countOverlaps++;
        }
        Console.WriteLine(countContained);
        Console.WriteLine(countOverlaps);
    }
}
