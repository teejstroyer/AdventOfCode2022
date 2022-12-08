public static class Day5
{
    public static void Solve()
    {
        List<List<char>> bays = new List<List<char>>();
        List<List<char>> bays2 = new List<List<char>>();

        string[] text = System.IO.File.ReadAllText("./ProblemInput/Day5Input.txt").TrimEnd().Split('\n');
        int endOfGrid = Array.FindIndex(text, 0, i => string.IsNullOrWhiteSpace(i));
        for (int i = 0; i < endOfGrid - 1; i++)
        {
            for (int j = 1, b = 0; j < text[i].Length; j += 4, b++)
            {
                if (!char.IsLetter(text[i][j])) continue;
                while (bays.Count < b + 1)
                {
                    bays.Add(new List<char>());
                    bays2.Add(new List<char>());
                }
                bays[b].Add(text[i][j]);
                bays2[b].Add(text[i][j]);
            }
        }

        for (int i = endOfGrid + 1; i < text.Length; i++)
        {
            var instruction = text[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var qty = int.Parse(instruction[1]);
            var start = int.Parse(instruction[3]);
            var end = int.Parse(instruction[5]);

            var itemsToMove = bays[start - 1].Take(qty).Reverse();
            bays[start - 1] = bays[start - 1].Skip(qty).ToList();
            bays[end - 1].InsertRange(0, itemsToMove);

            //Part 2, No Reverse
            var itemsToMove2 = bays2[start - 1].Take(qty);
            bays2[start - 1] = bays2[start - 1].Skip(qty).ToList();
            bays2[end - 1].InsertRange(0, itemsToMove2);
        }

        Console.WriteLine(bays.Select(i => i.FirstOrDefault()).ToArray());
        Console.WriteLine(bays2.Select(i => i.FirstOrDefault()).ToArray());
    }
}
