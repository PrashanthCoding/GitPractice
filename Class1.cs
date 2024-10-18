namespace MasterDataServices.Controllers
{
    [Authorize]
    [Route("QOM_API_V1/CMLocation")]
    [ApiController]
    /// Developer:DEVBYDIBIN
    public class LocationMastersController : ControllerBase
    {
        // Declare a private read-only field for the database context.
        public readonly BaseDbContex DbContextAccess;

        // Declare a readonly field for AutoMapper, which maps between objects (DTOs and entities).
        private readonly IMapper _mapper;

        //private readonly EncryptDecryptServices AccessEyDy;
        private readonly IConfiguration _Confi;
        //private readonly EncryptDecryptServices _encryptDecryptServices;

        // Declare a private read-only field for the response object that standardizes API responses.
        private readonly Respons_M response;


        // Constructor for the LocationMastersController class, which initializes the controller with dependencies.
        public LocationMastersController(BaseDbContex dbContextAccess, IMapper mapper, IConfiguration configuration)
        {
            // Assign the provided database context to the corresponding field for later use in database operations.
            DbContextAccess = dbContextAccess;

            // Assign the provided IMapper instance to the corresponding field for object mapping operations.
            _mapper = mapper;
            //AccessEyDy = encryptDecryptServices;
            _Confi = configuration;
            //_encryptDecryptServices = encryptDecryptServices;


            // Initialize the response object.
            response = new();
        }


        [HttpGet]
        [Route("GetLocationDetails")]
        public async Task<IActionResult> GetLocation()
        {
            try
            {
                //var userId = User.FindFirst("CUserid")?.Value;
                //var username = User.FindFirst("CUserName")?.Value;



                // Retrieve the organization ID from the authenticated user's claims
                int orgId = Convert.ToInt32(User.FindFirst("COrgid")?.Value);
                //var TId = User.FindFirst("CTenantCode")?.Value;
                var locations = await DbContextAccess.Location
                .Where(location => location.organization_id == orgId)
                .ToListAsync();
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetLocation/{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {

            // Retrieve the organization ID from the authenticated user's claims
            int orgId = Convert.ToInt32(User.FindFirst("COrgid")?.Value);


            var location = await DbContextAccess.Location
                                         .Include(l => l.address_id)
                                         .FirstOrDefaultAsync(l => l.location_id == id && l.organization_id == orgId);
            if (location == null)
            {
                return NotFound(new { message = "Location not found." });
            }
            return Ok(location);
        }

        //[HttpPost]
        //[Route("AddLocationDetails")]
        //public async Task<IActionResult> AddLocation([FromBody] LocationMaster Ldata)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {                   
        //        var result = await DbContextAccess.locations.AddAsync(Ldata);
        //        await DbContextAccess.SaveChangesAsync();
        //        return Ok(result.Entity);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}

        [HttpPost]
        [Route("AddLocations")]
        public async Task<IActionResult> AddLocationWithAddress([FromBody] AllLocation data)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            // Check for duplicate location_code
            var existingLocation = await DbContextAccess.Location.
                FirstOrDefaultAsync(l => l.location_code == data.location_code);

            if (existingLocation != null)
            {
                return BadRequest(new { message = "Duplicate location code. Please use a unique code." });
            }


            using (var transaction = await DbContextAccess.Database.BeginTransactionAsync())
            {
                try
                {
                    // Retrieve the organization ID from the authenticated user's claims
                    int orgId = Convert.ToInt32(User.FindFirst("COrgid")?.Value);

                    // Create new address record
                    var address = new AddressMaster
                    {
                        address_line1 = data.address_line1,
                        address_line2 = data.address_line2,
                        building_no = data.building_no,
                        street_name = data.street_name,
                        suburb_id = data.suburb_id,
                        zipcode_id = data.zipcode_id,
                        city_id = data.city_id,
                        district_id = data.district_id,
                        state_id = data.state_id,
                        country_id = data.country_id,
                        primary_contact_no = data.primary_contact_no,
                        secondary_contact_no = data.secondary_contact_no,
                        email = data.email,
                        fax = data.fax,
                        latitude = data.latitude,
                        longitude = data.longitude,
                        time_zone_identifier = data.time_zone_identifier,
                        time_zone_offset = data.time_zone_offset,
                        organization_id = orgId,
                        maker_id = data.maker_id,
                        make_time = data.make_time,
                        last_modified_by = data.last_modified_by,
                        last_modified_on = data.last_modified_on
                    };
                    DbContextAccess.Address.Add(address);
                    await DbContextAccess.SaveChangesAsync();


                    // Create new location record
                    var location = new LocationMaster
                    {
                        address_id = address.address_id,
                        location_code = data.location_code,
                        location_description = data.location_description,
                        location_type = data.location_type,
                        company_contact_no = data.company_contact_no,
                        company_contact_person = data.company_contact_person,
                        email = data.email,
                        mobile_no = data.mobile_no,
                        geo_fence_name = data.geo_fence_name,
                        geo_fence_range = data.geo_fence_range,
                        range_uom_id = data.range_uom_id,
                        name_of_bank = data.name_of_bank,
                        IFSC_code = data.IFSC_code,
                        branch_name = data.branch_name,
                        account_number = data.account_number,
                        group_company_code = data.group_company_code,
                        organization_id = data.organization_id,
                        maker_id = data.maker_id,
                        make_time = data.make_time,
                        last_modified_by = data.last_modified_by,
                        last_modified_on = data.last_modified_on,
                        others = data.others

                    };

                    DbContextAccess.Location.Add(location);
                    await DbContextAccess.SaveChangesAsync();


                    // Location Customer
                    var customer = new LocationCustomer
                    {
                        location_id = location.location_id,
                        customer_id = data.customer_id,
                        allow_revenue_protection = data.allow_revenue_protection,
                        maker_id = data.maker_id,
                        make_time = data.make_time,
                        last_modified_by = data.last_modified_by,
                        last_modified_on = data.last_modified_on,
                    };

                    DbContextAccess.LocationCustomer.Add(customer);
                    await DbContextAccess.SaveChangesAsync();


                    // Location Finance
                    var finance = new LocationFinance
                    {
                        location_id = location.location_id,
                        division_id = data.division_id,
                        cost_centre_charge_type = data.cost_centre_charge_type,
                        finance_book = data.finance_book,
                        account_code = data.account_code,
                        account_name = data.account_name,
                        charge_type = data.charge_type,
                        cash_code = data.cash_code,
                        cash_name = data.cash_name,
                        status = data.status
                    };

                    DbContextAccess.LocationFinance.Add(finance);
                    await DbContextAccess.SaveChangesAsync();


                    // Location Holiday
                    var holiday = new LocationHoliday
                    {
                        location_id = location.location_id,
                        holiday_id = data.holiday_id,
                        maker_id = data.maker_id,
                        make_time = data.make_time,
                        last_modified_by = data.last_modified_by,
                        last_modified_on = data.last_modified_on
                    };

                    DbContextAccess.LocationHoliday.Add(holiday);
                    await DbContextAccess.SaveChangesAsync();


                    // Location Operating day
                    var operatingday = new LocationOperationday
                    {
                        location_id = location.location_id,
                        working_days = data.working_days,
                        operating_from = data.operating_from,
                        operating_to = data.operating_to,
                        cut_off_time = data.cut_off_time,
                        maker_id = data.maker_id,
                        make_time = data.make_time,
                        last_modified_on = data.last_modified_on,
                        last_modified_by = data.last_modified_by
                    };

                    DbContextAccess.LocationOperationday.Add(operatingday);
                    await DbContextAccess.SaveChangesAsync();



                    await transaction.CommitAsync();

                    return CreatedAtAction(nameof(GetLocationById), new { id = location.location_id }, new { message = "Location added successfully", location });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, new { message = ex.Message });
                }
            }
        }

        [HttpPut]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocationWithAddress(int id, [FromBody] LocationWithAddressDto data)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = await DbContextAccess.Database.BeginTransactionAsync())
            {
                try
                {
                    // Retrieve the organization ID from the authenticated user's claims
                    int orgId = Convert.ToInt32(User.FindFirst("COrgid")?.Value);
                    var loc = await DbContextAccess.Location.FirstOrDefaultAsync(l => l.location_id == id && l.organization_id == orgId);
                    var location = await DbContextAccess.Location
                  .Include(l => l.Address) // Include the related address
                  .FirstOrDefaultAsync(l => l.location_id == id);
                    if (location == null)
                    {
                        return NotFound(new { message = "Location not found." });
                    }

                    location.Address.address_line1 = data.address_line1;
                    location.Address.address_line2 = data.address_line2;
                    location.Address.building_no = data.building_no;
                    location.Address.street_name = data.street_name;
                    location.Address.suburb_id = data.suburb_id;
                    location.Address.zipcode_id = data.zipcode_id;
                    location.Address.city_id = data.city_id;
                    location.Address.district_id = data.district_id;
                    location.Address.state_id = data.state_id;
                    location.Address.country_id = data.country_id;
                    location.Address.primary_contact_no = data.primary_contact_no;
                    location.Address.secondary_contact_no = data.secondary_contact_no;
                    location.Address.email = data.email;
                    location.Address.fax = data.fax;
                    location.Address.latitude = data.latitude;
                    location.Address.longitude = data.longitude;
                    location.Address.time_zone_identifier = data.time_zone_identifier;
                    location.Address.time_zone_offset = data.time_zone_offset;
                    //location.Address.organization_id = data.organization_id;
                    location.Address.maker_id = data.maker_id;
                    location.Address.make_time = data.make_time;
                    location.Address.last_modified_by = data.last_modified_by;
                    location.Address.last_modified_on = data.last_modified_on;


                    location.location_code = data.location_code;
                    location.location_description = data.location_description;
                    location.location_type = data.location_type;
                    location.company_contact_no = data.company_contact_no;
                    location.company_contact_person = data.company_contact_person;
                    location.email = data.email;
                    location.mobile_no = data.mobile_no;
                    location.geo_fence_name = data.geo_fence_name;
                    location.geo_fence_range = data.geo_fence_range;
                    location.range_uom_id = data.range_uom_id;
                    location.name_of_bank = data.name_of_bank;
                    location.IFSC_code = data.IFSC_code;
                    location.branch_name = data.branch_name;
                    location.account_number = data.account_number;
                    location.group_company_code = data.group_company_code;
                    location.organization_id = data.organization_id;
                    location.maker_id = data.maker_id;
                    location.make_time = data.make_time;
                    location.last_modified_by = data.last_modified_by;
                    location.last_modified_on = data.last_modified_on;
                    location.others = data.others;

                    DbContextAccess.Location.Update(location);
                    DbContextAccess.Address.Update(location.Address);

                    await DbContextAccess.SaveChangesAsync();
                    await transaction.CommitAsync();

                    response.Status = true;
                    response.StatusMsg = "Location updated successfully.";
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, new { message = ex.Message });
                }
            }
        }

        [HttpDelete]
        [Route("DeleteLocation/{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            using (var transaction = await DbContextAccess.Database.BeginTransactionAsync())
            {
                try
                {
                    // Retrieve the organization ID from the authenticated user's claims
                    int orgId = Convert.ToInt32(User.FindFirst("COrgid")?.Value);
                    var location = await DbContextAccess.Location.Include(l => l.Address).FirstOrDefaultAsync(l => l.location_id == id && l.organization_id == orgId);

                    if (location == null)
                    {
                        return NotFound(new { message = "Location not found." });
                    }
                    DbContextAccess.Location.Remove(location);

                    if (location.Address != null)
                    {
                        DbContextAccess.Address.Remove(location.Address);
                    }

                    await DbContextAccess.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Ok(new { message = "Location deleted successfully." });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, new { message = ex.Message });
                }
            }
        }


        //[HttpPost]
        //[Route("AddHoliday")]
        //public async Task<IActionResult> AddHoliday([FromBody] HolidaysDto holidaysDto)
        //{
        //    Respons_M response = new Respons_M();

        //    if (!ModelState.IsValid)
        //    {
        //        response.Status = false;
        //        response.StatusMsg = "Invalid data.";
        //        return BadRequest(response);
        //    }

        //    using (var transaction = await DbContextAccess.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            var holiday = new Holidays
        //            {
        //                holiday_date = DateOnly.FromDateTime(holidaysDto.holiday_date),
        //                holiday_description = holidaysDto.holiday_description,
        //                status = holidaysDto.status,
        //                organization_id = holidaysDto.organization_id,
        //                maker_id = holidaysDto.maker_id,
        //                make_time = holidaysDto.make_time,
        //                last_modified_by = holidaysDto.last_modified_by,
        //                last_modified_on = holidaysDto.last_modified_on
        //            };

        //            DbContextAccess.Holidays.Add(holiday);
        //            await DbContextAccess.SaveChangesAsync();
        //            await transaction.CommitAsync();

        //            response.Status = true;
        //            response.StatusMsg = "Holiday added successfully";
        //            return Ok(response);
        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync();
        //            response.Status = false;
        //            response.StatusMsg = ex.Message;
        //            return StatusCode(StatusCodes.Status500InternalServerError, response);
        //        }
        //    }
        //}


        [HttpGet]
        [Route("GetAllLocationCustomers")]
        public async Task<IActionResult> GetAllLocationCustomers()
        {
            try
            {
                var locationCustomers = await DbContextAccess.LocationCustomer.ToListAsync();
                return Ok(locationCustomers);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
                {
                    Status = false,
                    StatusMsg = ex.Message
                });
            }
        }


        [HttpGet]
        [Route("GetLocationCustomer/{id}")]
        public async Task<IActionResult> GetLocationCustomer(int id)
        {
            try
            {
                var locationCustomer = await DbContextAccess.LocationCustomer.FindAsync(id);
                if (locationCustomer == null)
                {
                    return NotFound(new Respons_M
                    {
                        Status = false,
                        StatusMsg = $"Location customer with ID {id} not found."
                    });
                }
                return Ok(locationCustomer);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
                {
                    Status = false,
                    StatusMsg = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("GetLocationCustomersPagenation")]
        public async Task<IActionResult> GetLocationCustomers(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                // Get the total number of LocationCustomer records from the database
                var totalRecords = await DbContextAccess.LocationCustomer.CountAsync();

                // Retrieve the LocationCustomer records for the current page, skipping the previous records and taking the next set based on pageSize
                var locationCustomers = await DbContextAccess.LocationCustomer
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Prepare the paginated response
                var response = new
                {
                    TotalRecords = totalRecords,
                    PageSize = pageSize,
                    CurrentPage = pageNumber,
                    TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize),
                    LocationCustomers = locationCustomers
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
                {
                    Status = false,
                    StatusMsg = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("AddLocationCustomers")]
        public async Task<IActionResult> AddLocationCustomer([FromBody] LocationCustomer locationCustomer)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                response.Status = false;  // Set to false since it wasn't found
                response.StatusMsg = "Invalid data.";
                return BadRequest(response);
            }

            try
            {
                //var locationCustomer = _mapper.Map<LocationCustomer>(locationCustomerDto);

                DbContextAccess.LocationCustomer.Add(locationCustomer);
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = "Location customer added successfully.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        [HttpPut]
        [Route("UpdateLocationCustomer/{id}")]
        public async Task<IActionResult> UpdateLocationCustomer(int id, [FromBody] LocationCustomer locationCustomer)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                response.Status = false;  // Set to false since it wasn't found
                response.StatusMsg = "Invalid data.";
                return BadRequest(response);
            }

            try
            {
                var existingLocationCustomer = await DbContextAccess.LocationCustomer.FindAsync(id);
                if (existingLocationCustomer == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location customer with ID {id} not found.";
                    return NotFound(response);
                }

                //_mapper.Map(locationCustomerDto, existingLocationCustomer);

                //DbContextAccess.Entry(existingLocationCustomer).State = EntityState.Modified;

                existingLocationCustomer.location_id = locationCustomer.location_id;
                existingLocationCustomer.customer_id = locationCustomer.customer_id;
                existingLocationCustomer.allow_revenue_protection = locationCustomer.allow_revenue_protection;
                existingLocationCustomer.last_modified_by = locationCustomer.last_modified_by;
                existingLocationCustomer.last_modified_on = locationCustomer.last_modified_on;

                DbContextAccess.LocationCustomer.Update(existingLocationCustomer);
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = $"Location customer with ID {id} updated successfully";
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        [HttpDelete]
        [Route("DeleteLocationCustomer/{id}")]
        public async Task<IActionResult> DeleteLocationCustomer(int id)
        {
            try
            {
                var existingLocationCustomer = await DbContextAccess.LocationCustomer.FindAsync(id);
                if (existingLocationCustomer == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location customer with ID {id} not found";
                    return NotFound(response);
                }

                DbContextAccess.LocationCustomer.Remove(existingLocationCustomer);
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = $"Location customer with ID {id} deleted successfully";
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet]
        [Route("GetAllLocationFinance")]
        public async Task<IActionResult> GetAllLocationFinance()
        {
            try
            {
                var locationCustomers = await DbContextAccess.LocationFinance.ToListAsync();
                return Ok(locationCustomers);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
                {
                    Status = false,
                    StatusMsg = ex.Message
                });
            }
        }


        [HttpGet]
        [Route("GetLocationFinance/{id}")]
        public async Task<IActionResult> GetLocationFinance(int id)
        {
            try
            {
                var locationFinance = await DbContextAccess.LocationFinance.FindAsync(id);
                if (locationFinance == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location Finance with ID {id} not found";
                    return NotFound(response);
                }

                return Ok(locationFinance);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost]
        [Route("AddLocationFinance")]
        public async Task<IActionResult> AddLocationFinance([FromBody] LocationFinance locationFinance)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                response.Status = false;  // Set to false since it wasn't found
                response.StatusMsg = "Invalid data.";
                return BadRequest(response);
            }


            try
            {
                DbContextAccess.LocationFinance.Add(locationFinance);
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = "Location finance added successfully";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut]
        [Route("UpdateLocationFinance/{id}")]
        public async Task<IActionResult> UpdateLocationFinance(int id, [FromBody] LocationFinance locationFinance)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                response.Status = false;  // Set to false since it wasn't found
                response.StatusMsg = "Invalid data.";
                return BadRequest(response);
            }


            try
            {

                var existingLocationFinance = await DbContextAccess.LocationFinance.FindAsync(id);
                if (existingLocationFinance == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location Finance with ID {id} not found.";
                    return NotFound(response);
                }

                existingLocationFinance.location_id = locationFinance.location_id;
                existingLocationFinance.division_id = locationFinance.division_id;
                existingLocationFinance.cost_centre_charge_type = locationFinance.cost_centre_charge_type;
                existingLocationFinance.finance_book = locationFinance.finance_book;
                existingLocationFinance.account_code = locationFinance.account_code;
                existingLocationFinance.account_name = locationFinance.account_name;
                existingLocationFinance.charge_type = locationFinance.charge_type;
                existingLocationFinance.cash_code = locationFinance.cash_code;
                existingLocationFinance.cash_name = locationFinance.cash_name;
                existingLocationFinance.status = locationFinance.status;
                existingLocationFinance.last_modified_by = locationFinance.last_modified_by;
                existingLocationFinance.last_modified_on = DateTime.UtcNow;
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = $"Location Finance with ID {id} updated successfully.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete]
        [Route("DeleteLocationFinance/{id}")]
        public async Task<IActionResult> DeleteLocationFinance(int id)
        {
            try
            {
                var existingLocationfince = await DbContextAccess.LocationFinance.FindAsync(id);
                if (existingLocationfince == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location Finance with ID {id} not found.";
                    return NotFound(response);
                }

                DbContextAccess.LocationFinance.Remove(existingLocationfince);
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = $"Location Finance with ID {id} deleted successfully.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet]
        [Route("GetAllLocationHoliday")]
        public async Task<IActionResult> GetAllLocationHoliday()
        {
            try
            {
                var locationHoliday = await DbContextAccess.LocationHoliday.ToListAsync();
                return Ok(locationHoliday);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
                {
                    Status = false,
                    StatusMsg = ex.Message
                });
            }
        }


        [HttpGet]
        [Route("GetAllLocationHoliday/{id}")]
        public async Task<IActionResult> GetAllLocationHoliday(int id)
        {
            try
            {
                var locationHoliday = await DbContextAccess.LocationHoliday.FindAsync(id);
                if (locationHoliday == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location holiday with ID {id} not found.";
                    return NotFound(response);
                }

                return Ok(locationHoliday);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
                {
                    Status = false,
                    StatusMsg = ex.Message
                });
            }
        }


        [HttpPost]
        [Route("AddLocationHoliday")]
        public async Task<IActionResult> AddLocationHoliday([FromBody] LocationWithHoliday request)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                response.Status = false;  // Set to false since it wasn't found
                response.StatusMsg = "Invalid data.";
                return BadRequest(response);
            }

            using (var transaction = await DbContextAccess.Database.BeginTransactionAsync())
            {
                try
                {
                    // Retrieve the organization ID from the authenticated user's claims
                    int orgId = Convert.ToInt32(User.FindFirst("COrgid")?.Value);

                    // Check for existing holiday with the same date
                    bool holidayExists = await DbContextAccess.Holidays.AnyAsync(h => h.holiday_date == request.holiday_date && h.organization_id == orgId);

                    if (holidayExists)
                    {
                        response.Status = false;
                        response.StatusMsg = "Holiday with the same date already exists.";
                        return Conflict(response); // 409 Conflict status code
                    }


                    // Proceed with adding new holiday
                    var holiday = new Holidays
                    {
                        holiday_date = request.holiday_date,
                        holiday_description = request.holiday_description,
                        status = request.status,
                        organization_id = orgId,
                        maker_id = request.maker_id,
                        make_time = request.make_time,
                        last_modified_by = request.last_modified_by,
                        last_modified_on = request.last_modified_on
                    };

                    DbContextAccess.Holidays.Add(holiday);
                    await DbContextAccess.SaveChangesAsync();

                    var holidayId = holiday.holiday_id;

                    var locationHoliday = new LocationHoliday
                    {
                        location_id = request.location_id,
                        holiday_id = holidayId,
                        maker_id = request.maker_id,
                        make_time = request.make_time,
                        last_modified_by = request.last_modified_by,
                        last_modified_on = request.last_modified_on
                    };

                    DbContextAccess.LocationHoliday.Add(locationHoliday);
                    await DbContextAccess.SaveChangesAsync();

                    // 


                    await transaction.CommitAsync();

                    response.Status = true;
                    response.StatusMsg = "LocationHoliday added successfully.";
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                    response.Status = false;
                    response.StatusMsg = $"An error occurred: {ex.Message}. Inner exception: {innerException}";
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
                }
            }
        }


        [HttpPut]
        [Route("UpdateLocationHoliday/{id}")]
        public async Task<IActionResult> UpdateLocationHoliday(int id, [FromBody] LocationWithHoliday locationWithHoliday)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                response.Status = false;   // Set to false since it wasn't found
                response.StatusMsg = "Invalid data.";
                return BadRequest(response);
            }

            try
            {
                // Retrieve the organization ID from the authenticated user's claims
                int orgId = Convert.ToInt32(User.FindFirst("COrgid")?.Value);

                var existingLocationholiday = await DbContextAccess.LocationHoliday.FindAsync(id);
                if (existingLocationholiday == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location Holiday with ID {id} not found.";
                    return NotFound(response);
                }

                // Check for existing holiday with the same date
                bool holidayExists = await DbContextAccess.Holidays.AnyAsync(h => h.holiday_date == locationWithHoliday.holiday_date && h.organization_id == orgId);

                if (holidayExists)
                {
                    response.Status = false;
                    response.StatusMsg = "Holiday with the same date already exists.";
                    return Conflict(response); // 409 Conflict status code
                }

                existingLocationholiday.location_id = locationWithHoliday.location_id;
                existingLocationholiday.holiday_id = locationWithHoliday.holiday_id;
                existingLocationholiday.last_modified_by = locationWithHoliday.last_modified_by;
                existingLocationholiday.last_modified_on = locationWithHoliday.last_modified_on;
                existingLocationholiday.last_modified_on = DateTime.UtcNow;
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = $"Location Holiday with ID {id} updated successfully.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete]
        [Route("DeleteLocationHoliday/{id}")]
        public async Task<IActionResult> DeleteLocationHoliday(int id)
        {
            try
            {
                var existingLocationholiday = await DbContextAccess.LocationHoliday.FindAsync(id);
                if (existingLocationholiday == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location Holiday with ID {id} not found.";
                    return NotFound(response);
                }

                DbContextAccess.LocationHoliday.Remove(existingLocationholiday);
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = $"Location Holiday with ID {id} deleted successfully.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet]
        [Route("GetLocationOperationDay")]
        public async Task<IActionResult> GetLocationOperationDay()
        {
            try
            {
                var locationHoliday = await DbContextAccess.LocationOperationday.ToListAsync();
                return Ok(locationHoliday);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
                {
                    Status = false,
                    StatusMsg = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("GetLocationOperationDay/{id}")]
        public async Task<IActionResult> GetLocationOperationDay(int id)
        {
            try
            {
                var locationHoliday = await DbContextAccess.LocationOperationday.FindAsync(id);
                if (locationHoliday == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location operatingday with ID {id} not found.";
                    return NotFound(response);
                }

                return Ok(locationHoliday);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
                {
                    Status = false,
                    StatusMsg = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("AddLocationOperationDay")]
        public async Task<IActionResult> AddLocationOperationDay([FromBody] LocationOperatingdayDto locationOperatingdayDto)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                response.Status = false;     // Set to false since it wasn't found
                response.StatusMsg = "Invalid data.";
                return BadRequest(response);
            }

            try
            {
                TimeSpan opertingFrom;
                TimeSpan opertingTo;

                if (!TimeSpan.TryParse(locationOperatingdayDto.operating_from, out opertingFrom))
                {
                    response.Status = false;
                    response.StatusMsg = "Invalid 'From' time format.";
                    return BadRequest(response);
                }

                if (!TimeSpan.TryParse(locationOperatingdayDto.operating_to, out opertingTo))
                {
                    response.Status = false;
                    response.StatusMsg = "Invalid 'To' time format.";
                    return BadRequest(response);
                }

                // Check if 'To' time is less than or equal to 'From' time
                if (opertingTo <= opertingFrom)
                {
                    response.Status = false;
                    response.StatusMsg = "'To' time should be greater than 'From' time.";
                    return BadRequest(response);
                }


                LocationOperationday locationOperationday = new LocationOperationday
                {
                    location_operatingday_id = locationOperatingdayDto.location_operatingday_id,
                    location_id = locationOperatingdayDto.location_id,
                    working_days = locationOperatingdayDto.working_days,
                    operating_from = opertingFrom,
                    operating_to = opertingTo,
                    maker_id = locationOperatingdayDto.maker_id,
                    make_time = locationOperatingdayDto.make_time,
                    cut_off_time = locationOperatingdayDto.cut_off_time.TimeOfDay,
                    last_modified_by = locationOperatingdayDto.last_modified_by,
                    last_modified_on = locationOperatingdayDto.last_modified_on,
                };


                DbContextAccess.LocationOperationday.Add(locationOperationday);
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = "Location OperationDay added successfully.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut]
        [Route("UpdateLocationOperationDay/{id}")]
        public async Task<IActionResult> UpdateLocationOperationDay(int id, [FromBody] LocationOperatingdayDto locationOperatingdayDto)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                response.Status = false;  // Set to false since it wasn't found
                response.StatusMsg = "Invalid data.";
                return BadRequest(response);
            }

            try
            {
                LocationOperationday existingLocationholiday = await DbContextAccess.LocationOperationday.FindAsync(id);
                if (existingLocationholiday == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location Operationday with ID {id} not found.";
                    return NotFound(response);
                }


                TimeSpan opertingFrom;
                TimeSpan opertingTo;

                if (!TimeSpan.TryParse(locationOperatingdayDto.operating_from, out opertingFrom))
                {
                    response.Status = false;
                    response.StatusMsg = "Invalid 'From' time format.";
                    return BadRequest(response);
                }

                if (!TimeSpan.TryParse(locationOperatingdayDto.operating_to, out opertingTo))
                {
                    response.Status = false;
                    response.StatusMsg = "Invalid 'To' time format.";
                    return BadRequest(response);
                }

                // Check if 'To' time is less than or equal to 'From' time
                if (opertingTo <= opertingFrom)
                {
                    response.Status = false;
                    response.StatusMsg = "'To' time should be greater than 'From' time.";
                    return BadRequest(response);
                }

                existingLocationholiday.location_id = locationOperatingdayDto.location_id;
                existingLocationholiday.working_days = locationOperatingdayDto.working_days;
                existingLocationholiday.location_id = locationOperatingdayDto.location_id;
                existingLocationholiday.operating_from = opertingFrom;
                existingLocationholiday.operating_to = opertingFrom;
                existingLocationholiday.cut_off_time = locationOperatingdayDto.cut_off_time.TimeOfDay;

                existingLocationholiday.last_modified_by = locationOperatingdayDto.last_modified_by;
                existingLocationholiday.last_modified_on = locationOperatingdayDto.last_modified_on;
                existingLocationholiday.last_modified_on = DateTime.UtcNow;
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = $"Location Operationday with ID {id} updated successfully.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete]
        [Route("DeleteLocationOperationDay/{id}")]
        public async Task<IActionResult> DeleteLocationOperationDay(int id)
        {
            try
            {
                var existingLocationOperationday = await DbContextAccess.LocationOperationday.FindAsync(id);
                if (existingLocationOperationday == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location Operationday with ID {id} not found.";
                    return NotFound(response);
                }

                DbContextAccess.LocationOperationday.Remove(existingLocationOperationday);
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = $"Location Operationday with ID {id} deleted successfully.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet]
        [Route("GetLocationServices")]
        public async Task<IActionResult> GetLocationServices()
        {
            try
            {
                var locationservices = await DbContextAccess.LocationService.ToListAsync();
                return Ok(locationservices);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
                {
                    Status = false,
                    StatusMsg = ex.Message
                });
            }
        }


        [HttpGet]
        [Route("GetLocationServices/{id}")]
        public async Task<IActionResult> GetLocationServices(int id)
        {
            try
            {
                var locationservices = await DbContextAccess.LocationService.FindAsync(id);
                if (locationservices == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location service with ID {id} not found.";
                    return NotFound(response);
                }

                return Ok(locationservices);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
                {
                    Status = false,
                    StatusMsg = ex.Message
                });
            }
        }



        [HttpPost]
        [Route("AddLocationServices")]
        public async Task<IActionResult> AddLocationServices([FromBody] LocationServices locationOdata)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                response.Status = false;  // Set to false since it wasn't found
                response.StatusMsg = "Invalid data.";
                return BadRequest(response);
            }


            try
            {
                DbContextAccess.LocationService.Add(locationOdata);
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = "Location Services added successfully.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut]
        [Route("UpdateLocatinServices/{id}")]
        public async Task<IActionResult> UpdateLocatinServices(int id, [FromBody] LocationServices locationOdata)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                response.Status = false;  // Set to false since it wasn't found
                response.StatusMsg = "Invalid data.";
                return BadRequest(response);
            }

            try
            {
                var existingLocatinservices = await DbContextAccess.LocationService.FindAsync(id);
                if (existingLocatinservices == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location Service with ID {id} not found";
                    return NotFound(response);
                }

                existingLocatinservices.location_id = locationOdata.location_id;
                existingLocatinservices.geography_id = locationOdata.geography_id;
                existingLocatinservices.geography_type = locationOdata.geography_type;
                existingLocatinservices.service_id = locationOdata.service_id;
                existingLocatinservices.last_modified_by = locationOdata.last_modified_by;
                existingLocatinservices.last_modified_on = DateTime.UtcNow;
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = $"Location Service with ID {id} updated successfully";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete]
        [Route("DeleteLocationServices/{id}")]
        public async Task<IActionResult> DeleteLocationServices(int id)
        {
            try
            {
                var existingLocationservices = await DbContextAccess.LocationService.FindAsync(id);
                if (existingLocationservices == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location Service with ID {id} not found";
                    return NotFound(response);
                }

                DbContextAccess.LocationService.Remove(existingLocationservices);
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = $"Location Service with ID {id} deleted successfully";
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet]
        [Route("GetLocationShippoint")]
        public async Task<IActionResult> GetLocationShippoint()
        {
            try
            {
                var locationspp = await DbContextAccess.LocationShippoint.ToListAsync();
                return Ok(locationspp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
                {
                    Status = false,
                    StatusMsg = ex.Message
                });
            }
        }


        [HttpGet]
        [Route("GetLocationShippoint/{id}")]
        public async Task<IActionResult> GetLocationShippoint(int id)
        {
            try
            {
                var locationShippoint = await DbContextAccess.LocationShippoint.FindAsync(id);
                if (locationShippoint == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location Shippoint with ID {id} not found.";
                    return NotFound(response);
                }

                return Ok(locationShippoint);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
                {
                    Status = false,
                    StatusMsg = ex.Message
                });
            }
        }


        [HttpPost]
        [Route("AddLocationShippoint")]
        public async Task<IActionResult> AddLocationShippoint([FromBody] LocationShippoint locationOdata)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                response.Status = false;   // Set to false since it wasn't found
                response.StatusMsg = "Invalid data.";
                return BadRequest(response);
            }

            try
            {

                DbContextAccess.LocationShippoint.Add(locationOdata);
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = "Location Shippoint added successfully.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut]
        [Route("UpdateLocationShippoint/{id}")]
        public async Task<IActionResult> UpdateLocationShippoint(int id, [FromBody] LocationShippoint locationOdata)
        {
            // Validate the DTO using FluentValidation
            if (!ModelState.IsValid)
            {
                response.Status = false;  // Set to false since it wasn't found
                response.StatusMsg = "Invalid data.";
                return BadRequest(response);
            }

            try
            {

                var existingLocatinshipoint = await DbContextAccess.LocationShippoint.FindAsync(id);
                if (existingLocatinshipoint == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location Service with ID {id} not found";
                    return NotFound(response);
                }

                existingLocatinshipoint.location_id = locationOdata.location_id;
                existingLocatinshipoint.ship_point_id = locationOdata.ship_point_id;
                existingLocatinshipoint.last_modified_by = locationOdata.last_modified_by;
                existingLocatinshipoint.last_modified_on = DateTime.UtcNow;
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = $"Location Shippoint with ID {id} updated successfully";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete]
        [Route("DeleteLocationShippoint/{id}")]
        public async Task<IActionResult> DeleteLocationShippoint(int id)
        {
            try
            {
                var existingLocationshippoint = await DbContextAccess.LocationShippoint.FindAsync(id);
                if (existingLocationshippoint == null)
                {
                    response.Status = false;
                    response.StatusMsg = $"Location Shippoint with ID {id} not found.";
                    return NotFound(response);
                }

                DbContextAccess.LocationShippoint.Remove(existingLocationshippoint);
                await DbContextAccess.SaveChangesAsync();

                response.Status = true;
                response.StatusMsg = $"Location Shippoint wtih ID {id} deleted successfully";
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                response.Status = false;
                response.StatusMsg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        //[HttpGet]
        //[Route("GetCountries")]
        //public async Task<IActionResult> GetCountries()
        //{
        //    try
        //    {
        //        var Countries = await DbContextAccess.countries.ToListAsync();
        //        return Ok(Countries);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
        //        {
        //            Status = false,
        //            StatusMsg = ex.Message
        //        });
        //    }
        //}

        //[HttpPost]
        //[Route("AddCountries")]
        //public async Task<IActionResult> AddCountries([FromBody] CountriesM Countriesdata)
        //{
        //    Respons_M response = new Respons_M();
        //    try
        //    {
        //        DbContextAccess.countries.Add(Countriesdata);
        //        await DbContextAccess.SaveChangesAsync();

        //        response.Status = true;
        //        response.StatusMsg = "Location Country added successfully";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.StatusMsg = ex.Message;
        //        return StatusCode(StatusCodes.Status500InternalServerError, response);
        //    }
        //}

        //[HttpPut]
        //[Route("UpadteCountries/{id}")]
        //public async Task<IActionResult> UpadteCountries(int id, [FromBody] CountriesM locationOdata)
        //{
        //    var response = new Respons_M();
        //    try
        //    {

        //        var Countries = await DbContextAccess.countries.FindAsync(id);
        //        if (Countries == null)
        //        {
        //            response.Status = false;
        //            response.StatusMsg = "Location Countries not found";
        //            return NotFound(response);
        //        }

        //        Countries.country_code = locationOdata.country_code;
        //        Countries.country_name = locationOdata.country_name;
        //        Countries.status = locationOdata.status;
        //        Countries.sequence_no = locationOdata.sequence_no;
        //        Countries.organization_id = locationOdata.organization_id;
        //        //Countries.maker_id = locationOdata.maker_id;
        //        //Countries.make_time = locationOdata.make_time;
        //        await DbContextAccess.SaveChangesAsync();

        //        response.Status = true;
        //        response.StatusMsg = "Location Country updated successfully";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.StatusMsg = ex.Message;
        //        return StatusCode(StatusCodes.Status500InternalServerError, response);
        //    }
        //}

        //[HttpDelete]
        //[Route("DeleteCountries/{id}")]
        //public async Task<IActionResult> DeleteCountries(int id)
        //{
        //    var response = new Respons_M();
        //    try
        //    {
        //        var existingcountry = await DbContextAccess.countries.FindAsync(id);
        //        if (existingcountry == null)
        //        {
        //            response.Status = false;
        //            response.StatusMsg = "Location Country not found";
        //            return NotFound(response);
        //        }

        //        DbContextAccess.countries.Remove(existingcountry);
        //        await DbContextAccess.SaveChangesAsync();

        //        response.Status = true;
        //        response.StatusMsg = "Location Country deleted successfully";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (ex) if needed
        //        response.Status = false;
        //        response.StatusMsg = ex.Message;
        //        return StatusCode(StatusCodes.Status500InternalServerError, response);
        //    }
        //}

        //[HttpGet]
        //[Route("GetStates")]
        //public async Task<IActionResult> GetStates()
        //{
        //    try
        //    {
        //        var States = await DbContextAccess.state.ToListAsync();
        //        return Ok(States);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
        //        {
        //            Status = false,
        //            StatusMsg = ex.Message
        //        });
        //    }
        //}

        //[HttpPost]
        //[Route("AddStates")]
        //public async Task<IActionResult> AddStates([FromBody] StateM Statedata)
        //{
        //    Respons_M response = new Respons_M();
        //    try
        //    {
        //        DbContextAccess.state.Add(Statedata);
        //        await DbContextAccess.SaveChangesAsync();

        //        response.Status = true;
        //        response.StatusMsg = "Location State added successfully";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.StatusMsg = ex.Message;
        //        return StatusCode(StatusCodes.Status500InternalServerError, response);
        //    }
        //}

        //[HttpPut]
        //[Route("UpdateState/{id}")]
        //public async Task<IActionResult> UpdateState(int id, [FromBody] StateM Statedata)
        //{
        //    var response = new Respons_M();
        //    try
        //    {

        //        var State = await DbContextAccess.state.FindAsync(id);
        //        if (State == null)
        //        {
        //            response.Status = false;
        //            response.StatusMsg = "Location State not found";
        //            return NotFound(response);
        //        }

        //        State.country_id = Statedata.country_id;
        //        State.state_code = Statedata.state_code;
        //        State.state_name = Statedata.state_name;
        //        State.status = Statedata.status;
        //        State.sequence_no = Statedata.sequence_no;
        //        State.organization_id = Statedata.organization_id;
        //        //State.maker_id = Statedata.maker_id;
        //        //State.make_time = Statedata.make_time;   
        //        await DbContextAccess.SaveChangesAsync();

        //        response.Status = true;
        //        response.StatusMsg = "Location State updated successfully";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.StatusMsg = ex.Message;
        //        return StatusCode(StatusCodes.Status500InternalServerError, response);
        //    }
        //}

        //[HttpDelete]
        //[Route("DeleteState/{id}")]
        //public async Task<IActionResult> DeleteState(int id)
        //{
        //    var response = new Respons_M();
        //    try
        //    {
        //        var State = await DbContextAccess.state.FindAsync(id);
        //        if (State == null)
        //        {
        //            response.Status = false;
        //            response.StatusMsg = "Location State not found";
        //            return NotFound(response);
        //        }

        //        DbContextAccess.state.Remove(State);
        //        await DbContextAccess.SaveChangesAsync();

        //        response.Status = true;
        //        response.StatusMsg = "Location State deleted successfully";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (ex) if needed
        //        response.Status = false;
        //        response.StatusMsg = ex.Message;
        //        return StatusCode(StatusCodes.Status500InternalServerError, response);
        //    }
        //}

        //[HttpGet]
        //[Route("GetDistrict")]
        //public async Task<IActionResult> GetDistrict()
        //{
        //    try
        //    {
        //        var District = await DbContextAccess.district.ToListAsync();
        //        return Ok(District);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
        //        {
        //            Status = false,
        //            StatusMsg = ex.Message
        //        });
        //    }
        //}

        //[HttpPost]
        //[Route("AddDistrict")]
        //public async Task<IActionResult> AddDistrict([FromBody] DistrictM District)
        //{
        //    Respons_M response = new Respons_M();
        //    try
        //    {
        //        DbContextAccess.district.Add(District);
        //        await DbContextAccess.SaveChangesAsync();

        //        response.Status = true;
        //        response.StatusMsg = "Location District added successfully";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.StatusMsg = ex.Message;
        //        return StatusCode(StatusCodes.Status500InternalServerError, response);
        //    }
        //}

        //[HttpPut]
        //[Route("UpdateDistrict/{id}")]
        //public async Task<IActionResult> UpdateDistrict(int id, [FromBody] DistrictM District)
        //{
        //    var response = new Respons_M();
        //    try
        //    {

        //        var Districtdata = await DbContextAccess.district.FindAsync(id);
        //        if (Districtdata == null)
        //        {
        //            response.Status = false;
        //            response.StatusMsg = "Location District not found";
        //            return NotFound(response);
        //        }

        //        Districtdata.district_name = District.district_name;
        //        Districtdata.state_id = District.state_id;
        //        Districtdata.status = District.status;
        //        Districtdata.organization_id = District.organization_id;
        //        //Districtdata.maker_id = District.maker_id;
        //        //Districtdata.make_time = District.make_time;
        //        await DbContextAccess.SaveChangesAsync();

        //        response.Status = true;
        //        response.StatusMsg = "Location District updated successfully";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.StatusMsg = ex.Message;
        //        return StatusCode(StatusCodes.Status500InternalServerError, response);
        //    }
        //}

        //[HttpDelete]
        //[Route("DeleteDistrict/{id}")]
        //public async Task<IActionResult> DeleteDistrict(int id)
        //{
        //    var response = new Respons_M();
        //    try
        //    {
        //        var district = await DbContextAccess.district.FindAsync(id);
        //        if (district == null)
        //        {
        //            response.Status = false;
        //            response.StatusMsg = "Location District not found";
        //            return NotFound(response);
        //        }

        //        DbContextAccess.district.Remove(district);
        //        await DbContextAccess.SaveChangesAsync();

        //        response.Status = true;
        //        response.StatusMsg = "Location State District successfully";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (ex) if needed
        //        response.Status = false;
        //        response.StatusMsg = ex.Message;
        //        return StatusCode(StatusCodes.Status500InternalServerError, response);
        //    }
        //}

        //[HttpGet]
        //[Route("GetTowns")]
        //public async Task<IActionResult> GetTowns()
        //{
        //    try
        //    {
        //        var District = await DbContextAccess.towns.ToListAsync();
        //        return Ok(District);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Respons_M
        //        {
        //            Status = false,
        //            StatusMsg = ex.Message
        //        });
        //    }
        //}

        //[HttpPost]
        //[Route("AddTowns")]
        //public async Task<IActionResult> AddTowns([FromBody] Towns town)
        //{
        //    Respons_M response = new Respons_M();
        //    try
        //    {
        //        DbContextAccess.towns.Add(town);
        //        await DbContextAccess.SaveChangesAsync();

        //        response.Status = true;
        //        response.StatusMsg = "Location Town added successfully";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.StatusMsg = ex.Message;
        //        return StatusCode(StatusCodes.Status500InternalServerError, response);
        //    }
        //}


        //[HttpPut]
        //[Route("UpdateTown/{id}")]
        //public async Task<IActionResult> UpdateTown(int id, [FromBody] Towns town)
        //{
        //    var response = new Respons_M();
        //    try
        //    {

        //        var towndata = await DbContextAccess.towns.FindAsync(id);
        //        if (towndata == null)
        //        {
        //            response.Status = false;
        //            response.StatusMsg = "Location Town not found";
        //            return NotFound(response);
        //        }

        //        towndata.town_name = town.town_name;
        //        towndata.district_id = town.district_id;
        //        towndata.status = town.status;
        //        towndata.organization_id = town.organization_id;
        //        //Districtdata.maker_id = District.maker_id;
        //        //Districtdata.make_time = District.make_time;
        //        await DbContextAccess.SaveChangesAsync();

        //        response.Status = true;
        //        response.StatusMsg = "Location Town updated successfully";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.StatusMsg = ex.Message;
        //        return StatusCode(StatusCodes.Status500InternalServerError, response);
        //    }
        //}

        //[HttpDelete]
        //[Route("DeleteTown/{id}")]
        //public async Task<IActionResult> DeleteTown(int id)
        //{
        //    var response = new Respons_M();
        //    try
        //    {
        //        var town = await DbContextAccess.towns.FindAsync(id);
        //        if (town == null)
        //        {
        //            response.Status = false;
        //            response.StatusMsg = "Location Town not found";
        //            return NotFound(response);
        //        }

        //        DbContextAccess.towns.Remove(town);
        //        await DbContextAccess.SaveChangesAsync();

        //        response.Status = true;
        //        response.StatusMsg = "Location Town successfully";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (ex) if needed
        //        response.Status = false;
        //        response.StatusMsg = ex.Message;
        //        return StatusCode(StatusCodes.Status500InternalServerError, response);
        //    }
        //}



        //[HttpPost]
        //[Route("AddShippoint")]
        //public async Task<IActionResult> AddShippointWithAddress([FromBody] ShippointWithAddressDto data)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    using (var transaction = await DbContextAccess.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            var address = new AddressMaster
        //            {
        //                address_line1 = data.address_line1,
        //                address_line2 = data.address_line2,
        //                building_no = data.building_no,
        //                street_name = data.street_name,
        //                suburb_id = data.suburb_id,
        //                zipcode_id = data.zipcode_id,
        //                city_id = data.city_id,
        //                district_id = data.district_id,
        //                state_id = data.state_id,
        //                country_id = data.country_id,
        //                primary_contact_no = data.primary_contact_no,
        //                secondary_contact_no = data.secondary_contact_no,
        //                email = data.email,
        //                fax = data.fax,
        //                latitude = data.latitude,
        //                longitude = data.longitude,
        //                time_zone_identifier = data.time_zone_identifier,
        //                time_zone_offset = data.time_zone_offset,
        //                organization_id = data.organization_id,
        //                maker_id = data.maker_id,
        //                make_time = data.maker_date,
        //                last_modified_by = data.last_modified_by,
        //                last_modified_on = data.last_modified_on
        //            };
        //            DbContextAccess.address.Add(address);
        //            await DbContextAccess.SaveChangesAsync();
        //            var Shippoint = new ShippointM
        //            {
        //                address_id = address.address_id,
        //                ship_point_code = data.ship_point_code,
        //                ship_point_name = data.ship_point_name,
        //                range_uom_id = data.range_uom_id,
        //                geo_fence_range = data.geo_fence_range,
        //                geo_fence_name = data.geo_fence_name,
        //                status = data.status,
        //                organization_id = data.organization_id,
        //                maker_id = data.maker_id,
        //                maker_date = data.maker_date,
        //                last_modified_by = data.last_modified_by,
        //                last_modified_on = data.last_modified_on,
        //                others = data.others

        //            };

        //            DbContextAccess.shippoints.Add(Shippoint);
        //            await DbContextAccess.SaveChangesAsync();
        //            await transaction.CommitAsync();
        //            return CreatedAtAction(nameof(GetLocationById), new { id = Shippoint.ship_point_id }, new { message = "Shippoint added successfully", Shippoint });
        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync();
        //            return StatusCode(500, new { message = ex.Message });
        //        }
        //    }
        //}

    }
}

