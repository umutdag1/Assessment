namespace ProjectApp.models
{
    public class MusicData
    {
        public string PlayId { get; private set; }
        public long SongId { get; private set; }
        public long ClientId { get; private set; }
        public DateTime PlayTs { get; private set; }

        public MusicData(string playId, long songId, long clientId, DateTime playTs)
        {
            PlayId = playId;
            SongId = songId;
            ClientId = clientId;
            PlayTs = playTs;
        }
    }
}