using StreamProgress.Contracts;

namespace StreamProgress.Models
{
    public class Movie : IProgressable
    {
        private string name;

        public Movie(int length, int bytesSent, string name)
        {
            Length = length;
            BytesSent = bytesSent;
            this.name = name;
        }

        public int Length { get; set; }

        public int BytesSent { get; }
    }
}