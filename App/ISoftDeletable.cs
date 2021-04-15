namespace App
{
    using System;

    public interface ISoftDeletable
    {
        DateTime? DeletedAt { get; set; }
        long? DeletedBy { get; set; }
    }
}
