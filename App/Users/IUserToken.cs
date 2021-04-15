namespace App
{
    public interface IUserToken : ITrackable 
    {
        public long UserId { get; set; }
    }
}
