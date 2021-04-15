using System;

namespace App
{
    public interface IUser : IIdName, ITrackable,  ISoftDeletable
    {
    }
}
