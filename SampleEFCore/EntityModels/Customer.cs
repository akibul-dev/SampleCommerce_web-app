using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEFCore.EntityModels
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        
        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(11)]
        public string PhoneNo { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(250)]
        public string DeliveryLocation { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string? LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }


    }
}
