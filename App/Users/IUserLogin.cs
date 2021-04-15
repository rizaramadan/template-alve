namespace App
{
    public interface IUserLogin : IIdName, ITrackable
    {
        public long UserId { get; set; }
    }
}
