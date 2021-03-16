using StreamProgress.Contracts;

namespace StreamProgress
{
    public class StreamProgressInfo
    {
        private IProgressable file;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IProgressable file)
        {
            this.file = file;
        }

        public int CalculateCurrentPercent()
        {
            int sent = (this.file.BytesSent * 100) / this.file.Length;
            file.Length -= sent;

            return sent;
        }
    }
}