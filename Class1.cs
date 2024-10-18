using System;

namespace MasterDataServices.Models.DTOModels.Location
{
    public class AllLocation
    {
        public string address_line1 { get; set; }
        public string address_line2 { get; set; }
        public string building_no { get; set; }
        public string street_name { get; set; }
        public int suburb_id { get; set; }

        [Required]
        public int zipcode_id { get; set; }

        [Required]
        public int city_id { get; set; }
        public int district_id { get; set; }

        [Required]
        public int state_id { get; set; }
        public int country_id { get; set; }

        [Required]
        public string primary_contact_no { get; set; }

        [Required]
        public string secondary_contact_no { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string fax { get; set; }

        [Required]
        public decimal latitude { get; set; }

        [Required]
        public decimal longitude { get; set; }
        public string time_zone_identifier { get; set; }
        public string time_zone_offset { get; set; }
        public int organization_id { get; set; }

        [Required]
        public int location_id { get; set; }

        [Required]
        [MaxLength(25)]
        public string location_code { get; set; }

        [Required]
        public string location_description { get; set; }

        [Required]
        public string location_type { get; set; }

        [Required]
        public string company_contact_no { get; set; }

        [Required]
        public string company_contact_person { get; set; }

        [Required]
        public string mobile_no { get; set; }

        public decimal geo_fence_range { get; set; }
        public int range_uom_id { get; set; }
        public string geo_fence_name { get; set; }
        public string name_of_bank { get; set; }
        public string branch_name { get; set; }

        [MaxLength(20)]
        public string IFSC_code { get; set; }
        public string account_number { get; set; }

        [MaxLength(25)]
        public string group_company_code { get; set; }
        public string others { get; set; }
        public int maker_id { get; set; }
        public DateTime make_time { get; set; }
        public int last_modified_by { get; set; }
        public DateTime last_modified_on { get; set; }


        // Location Customer
        [Key]
        public int location_customer_id { get; set; }

        [Required]
        public int customer_id { get; set; }

        [MaxLength(5)]
        public string allow_revenue_protection { get; set; }



        // Location Finance
        [Key]
        public int location_finance_id { get; set; }
        public int division_id { get; set; }

        [MaxLength(30)]
        public string cost_centre_charge_type { get; set; }

        [MaxLength(30)]
        public string finance_book { get; set; }

        [MaxLength(30)]
        public string account_code { get; set; }
        public string account_name { get; set; }

        [MaxLength(30)]
        public string charge_type { get; set; }

        [MaxLength(20)]
        public string cash_code { get; set; }
        public string cash_name { get; set; }

        [MaxLength(1)]
        public string status { get; set; }


        // Location Holiday
        [Key]
        public int location_holiday_id { get; set; }
        [Required]
        public int holiday_id { get; set; }



        // Location Operating day
        [Key]
        public int location_operatingday_id { get; set; }

        [MaxLength(10)]
        public string working_days { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan operating_from { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan operating_to { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan cut_off_time { get; set; }


        // Location Service
        [Key]
        public int location_service_id { get; set; }

        [MaxLength(20)]
        public string geography_type { get; set; }
        public int geography_id { get; set; }
        public int service_id { get; set; }


        // Location Shippoint
        [Key]
        public int location_shippoint_id { get; set; }

        [Required]
        public int ship_point_id { get; set; }
    }
}
