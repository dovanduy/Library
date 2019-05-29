﻿using System.Configuration;

namespace ModelsClassLibrary.ModelsNS.SharedNS
{
    public class SystemTotalSaleOrders : IMenuItemHelper
    {
        public SystemTotalSaleOrders()
        {

        }
        public SystemTotalSaleOrders(decimal money, double quantity)
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
                string content = ConfigurationManager.AppSettings["menu.system.SaleOrders.Total.MenuItem"];
                string str = string.Format(content, Money, Quantity);
                return str;

            }
        }

        public string ToolTip
        {
            get
            {
                string content = ConfigurationManager.AppSettings["menu.system.SaleOrders.Total.ToolTip"];
                string str = string.Format(content, Money, Quantity);
                return str;
            }
        }



    }
}
