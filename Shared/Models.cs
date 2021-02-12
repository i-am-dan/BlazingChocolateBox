using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazingChocolate.Shared
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    //public class Customer
    //{
    //    // makesure to say CustomerId as Unique & !Null & Index so it won't allow duplicates
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int Id { get; set; }
    //    [Index(IsClustered = true, IsUnique = true)]
    //    public string CustomerId { get; set; }
    //    public string Name { get; set; }

    //    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    //}

    //public class Subscription
    //{
    //    // makesure to say SubId as Unique & !Null & Index so it won't allow duplicates
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int Id { get; set; }
    //    [Index(IsClustered = true, IsUnique = true)]
    //    public string SubscriptionId { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }

    //    //FK & navigation
    //    public string CustomerId { get; set; }
    //    public Customer Customer { get; set; }

    //    public virtual ICollection<ResourceGroup> ResourceGroups { get; set; } = new List<ResourceGroup>();

    //}
    //public class ResourceGroup
    //{
    //    // makesure to say RgId as Unique & !Null & Index so it won't allow duplicates
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int Id { get; set; }
    //    [Index(IsClustered = true, IsUnique = true)]
    //    public string ResourceGroupId { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }

    //    //FK & inverse navigation
    //    public string SubscriptionId { get; set; }
    //    public Subscription Subscription { get; set; }
    //}


}
