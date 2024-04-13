using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoyDB_CRUD
{
    class manoydb
    {
        public string customer_first_name {  get; set; }
        public string customer_last_name { get; set; }
        public string customer_barangay { get; set; }
        public string customer_municipality { get; set; }
        public string contact_number { get; set; }

        public manoydb(string customer_first_name, string customer_last_name, string customer_barangay, string customer_municipality, string contact_number)
        {
            this.customer_first_name = customer_first_name;
            this.customer_last_name = customer_last_name;
            this.customer_barangay = customer_barangay;
            this.customer_municipality = customer_municipality;
            this.contact_number = contact_number;
        }
    }
    class manoydb2
    {
        public string rider_first_name { get; set; }
        public string rider_last_name { get; set; }
        public string rider_contact_number { get; set; }

        public manoydb2(string rider_first_name, string rider_last_name, string rider_contact_number)
        {
            this.rider_first_name = rider_first_name;
            this.rider_last_name = rider_last_name;
            this.rider_contact_number = rider_contact_number;
        }
    }
    class manoydb3
    {
        public string product_store { get; set; }
        public string product_name { get; set; }
        public string product_price { get; set; }
        public string order_date { get; set; }

        public manoydb3(string product_store, string product_name, string product_price, string order_date)
        {
            this.product_store = product_store;
            this.product_name = product_name;
            this.product_price = product_price;
            this.order_date = order_date;
        }
    }
    class manoydb4
    {
        public string operator_first_name { get; set; }
        public string operator_last_name { get; set; }
        public string operator_contact_number { get; set; }

        public manoydb4(string operator_first_name, string operator_last_name, string operator_contact_number)
        {
            this.operator_first_name = operator_first_name;
            this.operator_last_name = operator_last_name;
            this.operator_contact_number = operator_contact_number;
        }
    }

    class manoydb5
    {
        public string manager_first_name { get; set; }
        public string manager_last_name { get; set; }
        public string manager_contact_number { get; set; }

        public manoydb5(string manager_first_name, string manager_last_name, string manager_contact_number)
        {
            this.manager_first_name = manager_first_name;
            this.manager_last_name = manager_last_name;
            this.manager_contact_number = manager_contact_number;
        }
    }

    class manoydb6
    {
        public string service_name { get; set; }
        public string starting_fee { get; set; }

        public manoydb6(string service_name, string starting_fee)
        {
            this.service_name = service_name;
            this.starting_fee = starting_fee;
        }
    }
}
