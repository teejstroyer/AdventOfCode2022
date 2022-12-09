public static class Day7
{
    public static void Solve()
    {
        string[] data = System.IO.File.ReadAllText("./ProblemInput/Day7Input.txt").TrimEnd().Split('\n');
        HashSet<string> items = new HashSet<string>() { "/" };

        string pwd = "";
        foreach (var prompt in data)
        {
            var tokens = prompt.Split(' ');
            if (tokens[0] == "$")
            {
                if (tokens[1] == "ls") continue;
                // cmd == cd
                switch (tokens[2])
                {
                    case "/":
                        items.Add("/");
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
                var item = tokens[0] == "dir"? tokens[1]:tokens[0];
                items.Add("/" + string.Join("/", (pwd + "/" + item).Split("/", StringSplitOptions.RemoveEmptyEntries)));
            }
        }
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }

    }
}
