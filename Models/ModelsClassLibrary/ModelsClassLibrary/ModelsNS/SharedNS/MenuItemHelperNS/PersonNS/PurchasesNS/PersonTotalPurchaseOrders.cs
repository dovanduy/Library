﻿using System.Configuration;

namespace ModelsClassLibrary.ModelsNS.SharedNS
{
    public class PersonTotalPurchaseOrders : IMenuItemHelper
    {
        public PersonTotalPurchaseOrders()
        {

        }
        public PersonTotalPurchaseOrders(decimal money, double quantity)
        {
            Money = money;
            Quantity = quantity;
        }

        decimal Money { get; set; }
        double Quantity { get; set; }
        public string MenuItem
        {
            get
            {
                string content = ConfigurationManager.AppSettings["menu.person.PurchaseOrders.Total.MenuItem"];
                string str = string.Format(content, Money, Quantity);
                return str;

            }
        }

        public string ToolTip
        {
            get
            {
                string content = ConfigurationManager.AppSettings["menu.person.PurchaseOrders.Total.ToolTip"];
                string str = string.Format(content, Money, Quantity);
                return str;
            }
        }



    }
}
