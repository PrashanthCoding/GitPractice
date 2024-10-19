using System;
using System.Threading.Tasks;

[HttpPost]
[Route("AddDivision")]
public async Task<IActionResult> AddDivision([FromBody] DivisionDto divisionDto)
{
    Respons_M response = new Respons_M();

    if (!ModelState.IsValid)
    {
        response.Status = false;
        response.StatusMsg = "Invalid data.";
        return BadRequest(response);
    }

    try
    {
        // Find the Employee based on the provided Employee ID (KAM)
        var employee = await DbContextAccess.Employee.FindAsync(divisionDto.EmployeeId);

        if (employee == null)
        {
            response.Status = false;
            response.StatusMsg = "Employee not found.";
            return BadRequest(response);
        }

        // You may also want to get services and sub-services based on the employee, if applicable.
        var service = await DbContextAccess.Services.FirstOrDefaultAsync(s => s.EmployeeId == divisionDto.EmployeeId); // Update based on your relationship
        var subService = await DbContextAccess.Services.FirstOrDefaultAsync(s => s.EmployeeId == divisionDto.EmployeeId); // Update based on your relationship

        // Check if all required entities are valid
        if (service == null || subService == null)
        {
            response.Status = false;
            response.StatusMsg = "Service or Sub-service not found for the given employee.";
            return BadRequest(response);
        }

        // If not exists, add the new Division
        Division newDivision = new Division
        {
            division_code = divisionDto.DivisionCode,
            description = divisionDto.Description,
            status = divisionDto.Status,
            organization_id = divisionDto.OrganizationId,
            maker_id = divisionDto.MakerId,
            make_time = divisionDto.MakeTime,
            last_modified_by = divisionDto.LastModifiedBy,
            last_modified_on = divisionDto.LastModifiedOn,
            others = divisionDto.Others
        };

        // Add the entity and save changes
        DbContextAccess.Division.Add(newDivision);
        await DbContextAccess.SaveChangesAsync();

        response.Status = true;
        response.StatusMsg = "Division added successfully.";
        return Ok(response);
    }
    catch (Exception ex)
    {
        // Handle any exceptions and return an internal server error
        response.Status = false;
        response.StatusMsg = ex.Message;
        return StatusCode(StatusCodes.Status500InternalServerError, response);
    }
}
