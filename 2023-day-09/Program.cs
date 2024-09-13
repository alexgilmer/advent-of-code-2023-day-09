namespace _2023_day_09;

internal class Program
{
    static void Main(string[] args)
    {
        bool useTestData = false;
        IList<string> data = useTestData ? GetTestData() : GetPuzzleInput();
        long result = 0;
        foreach (string puzzle in data)
        {
            result += GetPuzzleAnswer(puzzle);
        }
        Console.WriteLine(result);
    }

    static IList<string> GetTestData()
    {
        return [
            "0 3 6 9 12 15",
            "1 3 6 10 15 21",
            "10 13 16 21 30 45"
            ];
    }

    static IList<string> GetPuzzleInput()
    {
        string file = Path.Combine(Environment.CurrentDirectory, "puzzle-input.txt");
        using StreamReader sr = new StreamReader(file);
        List<string> input = [];

        while (!sr.EndOfStream)
        {
            input.Add(sr.ReadLine()!);
        }

        return input;
    }

    static long GetPuzzleAnswer(string input)
    {
        CustomList nums = new(input.Split(' ').Select(long.Parse));
        Stack<CustomList> layers = PopulateStack(nums);

        while (layers.Count > 0)
        {
            CustomList layer = layers.Pop();
            long increment = layer[0];
            if (layers.Count == 0)
                return increment;

            CustomList nextList = layers.Peek();
            nextList.Insert(0, nextList[0] - increment);
        }

        throw new Exception("This shouldn't happen");
    }

    public static Stack<CustomList> PopulateStack(CustomList firstList)
    {
        Stack<CustomList> layers = new();
        layers.Push(firstList);

        // populate stack
        while (!layers.Peek().IsAllZeroes())
        {
            CustomList prevList = layers.Peek();
            CustomList nextList = [];

            for (int i = 0; i < prevList.Count - 1; i++)
            {
                nextList.Add(prevList[i + 1] - prevList[i]);
            }
            layers.Push(nextList);
        }

        return layers;
    }
}
