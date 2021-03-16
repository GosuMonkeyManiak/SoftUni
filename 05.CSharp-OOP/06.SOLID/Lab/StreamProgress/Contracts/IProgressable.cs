namespace StreamProgress.Contracts
{
    public interface IProgressable
    {
        public int Length { get; set; }

        public int BytesSent { get; }
    }
}