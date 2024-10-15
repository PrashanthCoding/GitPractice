using System;

public class DivisionDto
{
    public int DivisionId { get; set; }

    [MaxLength(25)]
    public string DivisionCode { get; set; }

    public string Description { get; set; }

    [MaxLength(1)]
    public string Status { get; set; }

    public int OrganizationId { get; set; }
    public int MakerId { get; set; }
    public DateTime MakeTime { get; set; }
    public int LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public string Others { get; set; }

    // New properties for dropdowns
    public int EmployeeId { get; set; } // KAM employee ID
    public int ServiceId { get; set; } // Service ID from the dropdown
    public int SubServiceId { get; set; } // Sub-service ID from the dropdown
}
