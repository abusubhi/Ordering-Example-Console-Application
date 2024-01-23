using Ordering.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Ordering.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Created { get; set; }

        /*--يعني ممكن يكون عند العميل اكثر من عنوان و اكثر من اوردر--*/
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

public class Address
{
    public int AddressID { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public virtual ICollection<Customer> Customers { get; set; }
}

public class Order
{
    public int OrderID { get; set; }
    public DataTime OraderDate { get; set; }
    public DataTime ShipDate { get; set; }
    public Decimal totalOrder { get; set; }
    public int CustomerID { get; set; }//Foreign key
    public int AddressID { get; set; }//foreign key

    public virtual Customer Customer { get; set; }
    public virtual Address ShipToAddress { get; set; }
}


/*DbContext gives EntityFramework proparties and power */
public class OrderingContext : DbContext
{
    /*add reference for all objects*/
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Address> Addresss { get; set; }
}
}