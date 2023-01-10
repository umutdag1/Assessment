namespace ProjectApp.models
{
    public class ResultData
    {
        public int DistinctPlayCount { get; private set; }
        public int ClientCount { get; private set; }

        public ResultData(int distinctPlayCount, int clientCount)
        {
            DistinctPlayCount = distinctPlayCount;
            ClientCount = clientCount;
        }
    }
}