namespace App
{
    using System;
    public interface ITrackable
    {
        DateTime CreatedAt { get; set; }
        long CreatedBy { get; set; }

        DateTime UpdatedAt { get; set; }
        long UpdatedBy { get; set; }
    }
}
