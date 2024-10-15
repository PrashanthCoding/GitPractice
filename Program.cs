[HttpPost]
[Route("AddAllLocation")]
public async Task<IActionResult> AddAllLocation([FromBody] AllLocation data)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    using (var transaction = await DbContextAccess.Database.BeginTransactionAsync())
    {
        try
        {
            // Add Location
            var location = new LocationMaster
            {
                location_code = data.location_code,
                location_description = data.location_description,
                location_type = data.location_type,
                address_id = data.address_id,
                company_contact_no = data.company_contact_no,
                company_contact_person = data.company_contact_person,
                mobile_no = data.mobile_no,
                email = data.email,
                geo_fence_range = data.geo_fence_range,
                range_uom_id = data.range_uom_id,
                geo_fence_name = data.geo_fence_name,
                name_of_bank = data.name_of_bank,
                branch_name = data.branch_name,
                IFSC_code = data.IFSC_code,
                account_number = data.account_number,
                group_company_code = data.group_company_code,
                organization_id = data.organization_id,
                status = data.status,
                maker_id = data.maker_id,
                make_time = data.make_time,
                last_modified_by = data.last_modified_by,
                last_modified_on = data.last_modified_on,
                others = data.others
            };

            DbContextAccess.Location.Add(location);
            await DbContextAccess.SaveChangesAsync();

            // Add LocationCustomer
            var locationCustomer = new LocationCustomer
            {
                location_id = location.location_id,
                customer_id = data.customer_id,
                allow_revenue_protection = data.allow_revenue_protection
            };

            DbContextAccess.LocationCustomer.Add(locationCustomer);
            await DbContextAccess.SaveChangesAsync();

            // Add LocationFinance
            var locationFinance = new LocationFinance
            {
                location_id = location.location_id,
                division_id = data.division_id,
                cost_centre_charge_type = data.cost_centre_charge_type,
                finance_book = data.finance_book,
                account_code = data.account_code,
                account_name = data.account_name,
                charge_type = data.charge_type,
                cash_code = data.cash_code,
                cash_name = data.cash_name
            };

            DbContextAccess.LocationFinance.Add(locationFinance);
            await DbContextAccess.SaveChangesAsync();

            // Add LocationHoliday
            var locationHoliday = new LocationHoliday
            {
                location_id = location.location_id,
                holiday_id = data.holiday_id
            };

            DbContextAccess.LocationHoliday.Add(locationHoliday);
            await DbContextAccess.SaveChangesAsync();

            // Add LocationOperatingDay
            var locationOperatingDay = new LocationOperatingDay
            {
                location_id = location.location_id,
                working_days = data.working_days,
                operating_from = data.operating_from,
                operating_to = data.operating_to,
                cut_off_time = data.cut_off_time
            };

            DbContextAccess.LocationOperatingDay.Add(locationOperatingDay);
            await DbContextAccess.SaveChangesAsync();

            // Add LocationService
            var locationService = new LocationService
            {
                location_id = location.location_id,
                geography_type = data.geography_type,
                geography_id = data.geography_id,
                service_id = data.service_id
            };

            DbContextAccess.LocationService.Add(locationService);
            await DbContextAccess.SaveChangesAsync();

            // Add LocationShippoint
            var locationShippoint = new LocationShippoint
            {
                location_id = location.location_id,
                ship_point_id = data.ship_point_id
            };

            DbContextAccess.LocationShippoint.Add(locationShippoint);
            await DbContextAccess.SaveChangesAsync();

            // Commit the transaction
            await transaction.CommitAsync();

            return Ok(new { message = "Location and related data added successfully" });
        }
        catch (Exception ex)
        {
            // Rollback the transaction in case of an error
            await transaction.RollbackAsync();
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
