using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmPartnerNote
{
    public int Id { get; set; }

    public int PartnerId { get; set; }

    public DateOnly NoteDate { get; set; }

    public string Content { get; set; } = null!;

    public string? Result { get; set; }

    public string? NextAction { get; set; }

    public DateOnly? FollowUpDate { get; set; }

    public string? FollowUpStatus { get; set; }

    public string? StaffName { get; set; }

    public string? AttachmentUrl { get; set; }

    public DateTime? CreatedAt { get; set; }
}
