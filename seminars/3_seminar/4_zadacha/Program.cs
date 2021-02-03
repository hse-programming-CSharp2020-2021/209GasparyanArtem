using System;



namespace ConsoleApp2
{
    class VoteEventArgs : EventArgs
    {
        public string Question { get; set; }
        public int VoteFor { get; set; }
        public int VoteAgainst { get; set; }
        public int VoteAbstained { get; set; }
    }
    class ElectoralComission
    {
        public event EventHandler<VoteEventArgs> onVote;
        public VoteEventArgs Vote()
        {
            VoteEventArgs vote = new VoteEventArgs();
            onVote(this, vote);
            return vote;
        }
    }
    class Vote
    {
        static Random random = new Random();
        public void VoterVote(object sender, VoteEventArgs e)
        {
            int n = random.Next(0, 3);
            if (n == 0)
                e.VoteFor++;
            else if (n == 1)
                e.VoteAgainst++;
            else
                e.VoteAbstained++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ElectoralComission electoralComission = new ElectoralComission();
            Vote[] votes = new Vote[10];
            for (int i = 0; i < votes.Length; i++)
            {
                votes[i] = new Vote();
                electoralComission.onVote += votes[i].VoterVote;
            }
            VoteEventArgs vote = electoralComission.Vote();
            Console.WriteLine($"{vote.VoteFor} - {vote.VoteAgainst} - {vote.VoteAbstained}");
        }
    }
}