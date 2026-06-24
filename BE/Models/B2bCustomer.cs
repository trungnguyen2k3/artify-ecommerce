using System;
using System.Collections.Generic;

namespace Artify_ecommerce.Models;

public partial class B2bCustomer
{
    public int Id { get; set; }

    public string CustomerCode { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? TaxCode { get; set; }

    public string? LegalAddress { get; set; }

    public string? ShippingAddress { get; set; }

    public string? LegalRepresentative { get; set; }

    public string? CustomerType { get; set; }

    public string? Industry { get; set; }

    public string? Status { get; set; }

    public string? ProvinceCode { get; set; }

    public string? ProvinceName { get; set; }

    public string? DistrictCode { get; set; }

    public string? DistrictName { get; set; }

    public string? AssignedStaff { get; set; }

    public string? InvoiceName { get; set; }

    public string? InvoiceAddress { get; set; }

    public string? InvoiceEmail { get; set; }

    public string? BusinessLicenseUrl { get; set; }

    public string? AuthorizedPerson { get; set; }

    public string? AuthorizationFileUrl { get; set; }

    public string? LegalNotes { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactPosition { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string? BankAccount { get; set; }
}
