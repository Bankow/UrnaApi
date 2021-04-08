namespace UrnaEletronica.Domain.Dtos
{
    public sealed class VoteDto
    {
        public int CandidateId { get; set; }

        public string Name { get; set; }

        public string ViceName { get; set; }

        public int Subtitle { get; set; }

        public int Votes { get; set; }
    }
}
