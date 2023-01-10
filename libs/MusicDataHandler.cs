using ProjectApp.models;

namespace ProjectApp.libs
{
    public class MusicDataHandler
    {
        public IEnumerable<MusicData>? MusicDataList { get; private set; }
        public IEnumerable<ResultData>? ResultDataList { get; private set; }
        private string FilePath = @"./assets";
        private string DataSeparator;
        private DateTime Dt;
        private string DateFormat = "dd/MM/yyyy";

        public MusicDataHandler(string fileName, string dataSeparator, DateTime searchDate)
        {
            FilePath = @$"{FilePath}/input/{fileName}";
            DataSeparator = dataSeparator;
            Dt = searchDate;

            this.ReadMusicDataFromFile();
        }

        public void ProduceResult()
        {
            var musicTotalPerClientList = MusicDataList?
                        .Where(dt => dt.PlayTs.ToString(DateFormat) == Dt.ToString(DateFormat))
                        .DistinctBy(dt => dt.SongId)
                        .GroupBy(dt => dt.ClientId)
                        .Select(dt => new { clientId = dt.Key, distinctPlayCount = dt.Count() });

            var musicTotalPerClientTotalList = musicTotalPerClientList?
                        .GroupBy(dt => dt.distinctPlayCount)
                        .Select(dt => new ResultData(dt.Key, dt.Count()))
                        //.Select(x => new { distinctPlayCount = x.Key, clientCount = x.Count() })
                        .ToList();

            ResultDataList = musicTotalPerClientTotalList;
        }

        public void WriteMusicDataToFile()
        {
            List<string>? contents = ResultDataList?
                .Select(dt => @$"{dt.DistinctPlayCount},{dt.ClientCount}")
                .ToList();

            contents?.Insert(0, @"DISTINCT_PLAY_COUNT,CLIENT_COUNT");

            if(contents != null)
            {
                FileActionHandler.WriteFileContents(FilePath.Replace("input", "output"), contents);
            }
        }

        private void ReadMusicDataFromFile()
        {
            MusicDataList = FileActionHandler.GetFileContents(FilePath)
                .Skip(1)
                .Select(line => GetMusicData(line));
        }

        private MusicData GetMusicData(string line)
        {
            string[] lineParts = line.Split(DataSeparator);

            string playId = lineParts[0];
            long songId = Convert.ToInt64(lineParts[1]);
            long clientId = Convert.ToInt64(lineParts[2]);
            DateTime playTs = Convert.ToDateTime(lineParts[3]);

            return new MusicData(playId, songId, clientId, playTs);
        }
    }
}