public static class Day2
{
    public static void Solve()
    {
        //Part 1
        //Rock","A","X" =>  1
        //Paper","B","Y" => 2
        //Scissors","C","Z" => 3

        // 6 win
        // 3 Draw

        //Part 2
        // X LOSE Y DRAW Z WIN
        int score = 0;
        int score2 = 0;

        var text = System.IO.File.ReadAllText("./ProblemInput/Day2Input.txt").Split('\n');

        foreach (var line in text)
        {
            switch (line)
            {
                case "A X":
                    score += 1 + 3;
                    score2 += 3 + 0;
                    break;
                case "A Y":
                    score += 2 + 6;
                    score2 += 1 + 3;
                    break;
                case "A Z":
                    score += 3 + 0;
                    score2 += 2 + 6;
                    break;
                case "B X":
                    score += 1 + 0;
                    score2 += 1 + 0;
                    break;
                case "B Y":
                    score += 2 + 3;
                    score2 += 2 + 3;
                    break;
                case "B Z":
                    score += 3 + 6;
                    score2 += 3 + 6;
                    break;
                case "C X":
                    score += 1 + 6;
                    score2 += 2 + 0;
                    break;
                case "C Y":
                    score += 2 + 0;
                    score2 += 3 + 3;
                    break;
                case "C Z":
                    score += 3 + 3;
                    score2 += 1 + 6;
                    break;
            }
        }
        Console.WriteLine(score);
        Console.WriteLine(score2);

    }

}
