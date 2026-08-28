using System;
using System.Collections.Generic;
using System.Text;

namespace EventBooking.TicketMgt.Domain.Common;
/// <summary>
/// Class used to track data; this serves as a base class
/// </summary>
public class AuditableEntity
{
    public string? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
