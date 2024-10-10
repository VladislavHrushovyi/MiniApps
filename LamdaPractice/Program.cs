
using System.Runtime.InteropServices;using System.Text.Json.Serialization.Metadata;

var plus = (int a, int b) => a + b;

static int Wrap(Func<int, int, int> func)
{
    Console.WriteLine("Start wrap");
    var fetchedData = Task.Run<Tuple<int, int>>( async () =>
        {
            await Task.Delay(1000);
            return new Tuple<int, int>(2,2);
        }).GetAwaiter().GetResult();
    var result = func.Invoke(fetchedData.Item1, fetchedData.Item2);

    return result;
}

Console.WriteLine(Wrap(plus));