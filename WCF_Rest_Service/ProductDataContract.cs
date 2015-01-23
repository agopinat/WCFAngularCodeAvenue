using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCF_Rest_Service
{
    [DataContract]
    public class ProductDataContract
    {
        [DataMember]
        public int ProductID { get; set; }

        [DataMember]
        public Nullable<int> CartID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Nullable<decimal> Price { get; set; }

        [DataMember]
        public string Car { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Nullable<decimal> QuantityInHand { get; set; }

        [DataMember]
        public string Image { get; set; }
         
    }
}