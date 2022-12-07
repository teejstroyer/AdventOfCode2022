public static class Day5
{
    public static void Solve()
    {
        List<char>[] bays = new List<char>[]{
            new List<char>(),
            new List<char>(),
            new List<char>(),
            new List<char>(),
            new List<char>(),
            new List<char>(),
            new List<char>(),
            new List<char>(),
            new List<char>(),
        };

        string[] text = System.IO.File.ReadAllText("./ProblemInput/Day5Input.txt").Split('\n');
        int endOfGrid = Array.FindIndex(text, 0, i => string.IsNullOrWhiteSpace(i));
        for (int i = 0; i < endOfGrid - 1; i++)
        {
            for (int j = 1, b = 0; j < text[i].Length; j += 4, b++)
            {
                if (char.IsLetter(text[i][j]))
                {
                    bays[b].Add(text[i][j]);
                }
            }
        }


        for (int i = endOfGrid + 1; i < text.Length; i++)
        {
            var instruction = text[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var qty = int.Parse(instruction[1]);
            var start = int.Parse(instruction[3]);
            var end = int.Parse(instruction[5]);
            Console.WriteLine($"{qty} {start}=>{end}");
            bays[end-1].InsertRange(0,bays[start-1].Take(qty));
        }
        
        Console.WriteLine("here");
        foreach(var bay in bays)
        {
            Console.Write(bay.FirstOrDefault());
        }
        Console.WriteLine();
    }
}
