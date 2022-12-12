public static class Day7
{
    public static void Solve()
    {
        string[] data = System.IO.File.ReadAllText("./ProblemInput/Day7Input.txt").TrimEnd().Split('\n');
        Dictionary<string, long> directorySize = new Dictionary<string, long>();
        directorySize.Add("/", 0);

        string pwd = "";
        foreach (var prompt in data)
        {
            var tokens = prompt.Split(' ');
            if (tokens[0] == "$")
            {
                if (tokens[1] == "ls") continue;
                switch (tokens[2])
                {
                    case "/":
                        pwd = "/";
                        break;
                    case "..":
                        var dir = pwd.Split("/", StringSplitOptions.RemoveEmptyEntries);
                        var s = string.Join("/", dir.Take(dir.Length - 1).ToArray());
                        pwd = "/" + s;
                        break;
                    default:
                        pwd += "/" + tokens[2];
                        break;
                }
            }
            else
            {
                var item = tokens[0] == "dir" ? tokens[1] : tokens[0];
                var path = "/" + string.Join("/", (pwd + "/" + item).Split("/", StringSplitOptions.RemoveEmptyEntries));

                if (tokens[0] == "dir" && !directorySize.ContainsKey(path))
                {
                    directorySize.TryAdd(path, 0);
                }
                else
                {
                    var directories = pwd.Split("/", StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i <= directories.Count(); i++)
                    {
                        var dir = "/" + string.Join("/", directories.Take(i));
                        directorySize[dir] += long.Parse(tokens[0]);
                    }
                }
            }
        }
        //part 1 sum of all directories of size <= 100000
        var sum = directorySize
            .Where(i => i.Value <= 100000)
            .Select(i => i.Value)
            .Sum();
        Console.WriteLine(sum);

        //Part 2 smallest directory that would free up enough space to have 
        //30000000 free  of 70000000
        var freeSpace = Math.Abs(70000000 - (directorySize["/"]));
        var itemToremove = directorySize.Values.Where(i => freeSpace + i >= 30000000).Min();
        Console.WriteLine(itemToremove);
    }
}
