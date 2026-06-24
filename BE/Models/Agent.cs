using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class Agent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal? Discount { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool? IsActive { get; set; }

    public string? BankAccountNumber { get; set; }

    public string? BankName { get; set; }

    public string? Phone { get; set; }

    public decimal? AgentDiscount { get; set; }

    public string? VerifyCode { get; set; }

    public DateTime? ExpiredDate { get; set; }
}
