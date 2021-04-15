namespace App
{
    public interface IUserRole : IIdName, ITrackable, ISoftDeletable
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
    }
}
