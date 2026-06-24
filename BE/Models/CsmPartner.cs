using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class CsmPartner
{
    public int Id { get; set; }

    public string PartnerCode { get; set; } = null!;

    public string PartnerName { get; set; } = null!;

    public string? PartnerType { get; set; }

    public string? PartnerLevel { get; set; }

    public string? Representative { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? ProvinceCode { get; set; }

    public string? ProvinceName { get; set; }

    public string? WardCode { get; set; }

    public string? WardName { get; set; }

    public string? Address { get; set; }

    public string? LegalType { get; set; }

    public string? TaxCode { get; set; }

    public string? BusinessLicenseUrl { get; set; }

    public string? BankAccount { get; set; }

    public string? BankName { get; set; }

    public string? BankBranch { get; set; }

    public string? InvoiceName { get; set; }

    public string? InvoiceAddress { get; set; }

    public string? InvoiceEmail { get; set; }

    public decimal? DefaultCommissionRate { get; set; }

    public decimal? DebtLimit { get; set; }

    public string? ReconciliationCycle { get; set; }

    public string? PaymentTerm { get; set; }

    public int? ConsignmentDuration { get; set; }

    public string? AssignedStaff { get; set; }

    public string? SupportStaff { get; set; }

    public string? Department { get; set; }

    public int? CareReminderDays { get; set; }

    public DateOnly? NextCareDate { get; set; }

    public string? Status { get; set; }

    public string? RiskLevel { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public int? DebtLimitDate { get; set; }

    public string? CompanyName { get; set; }
}
