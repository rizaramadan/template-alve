namespace App
{
    public interface IUserClaim : ITrackable
    {
        public long UserId { get; set; }
    }
}
