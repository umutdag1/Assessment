using ProjectApp.libs;
using System.Diagnostics;

namespace ProjectApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program is Started");

            var watch = Stopwatch.StartNew();

            Program p = new Program();
            p.DoAction();

            watch.Stop();

            Console.WriteLine($"Program Execution Time: {watch.ElapsedMilliseconds}");
            Console.WriteLine("Program is Finished");
        }

        private void DoAction()
        {
            string fileName = "exhibitA-input.csv";
            string fileLineSep = "\t";
            DateTime date = new DateTime(2016, 08, 10);

            MusicDataHandler mdh = new MusicDataHandler(fileName, fileLineSep, date);
            mdh.ProduceResult();
            mdh.WriteMusicDataToFile();

            var resultList = mdh.ResultDataList;

            // if (resultList != null)
            // {
            //     foreach (var result in resultList)
            //     {
            //         Console.WriteLine($"DistinctPlayCount: {result.DistinctPlayCount}, ClientCount: {result.ClientCount}");
            //     }
            // }

            // Console.WriteLine(resultList?.MaxBy(dt => dt.DistinctPlayCount)?.DistinctPlayCount);
            // Console.WriteLine(mdh.MusicDataList?.Count());
            // Console.WriteLine(mdh.ResultDataList?.Where(dt => dt.DistinctPlayCount == 346).Count());
        }
    }
}