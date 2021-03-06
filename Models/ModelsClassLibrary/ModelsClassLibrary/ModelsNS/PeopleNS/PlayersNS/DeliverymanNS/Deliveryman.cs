﻿using EnumLibrary.EnumNS;
using InterfacesLibrary.PeopleNS.PlayersNS;
using InterfacesLibrary.SharedNS;
using ModelsClassLibrary.ModelsNS.AddressNS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using UserModels;
using AliKuli.Extentions;
using System;
using System.Collections.Generic;
using ModelsClassLibrary.ModelsNS.DocumentsNS.FreightOffersTrxNS;
using System.Configuration;


namespace ModelsClassLibrary.ModelsNS.PlayersNS
{
    /// <summary>
    /// Note. The DeliverymanVendorAbstract is connected to the User. Therefore, this deliveryman is tied up with the login ID.
    /// </summary>
    public class Deliveryman : PlayerAbstract
    {
        public override ClassesWithRightsENUM ClassNameForRights()
        {
            return EnumLibrary.EnumNS.ClassesWithRightsENUM.Deliveryman;
        }



        [Display(Name = "Category")]
        [MaxLength(128)]
        public string DeliverymanCategoryId { get; set; }

        public virtual ICategory DeliverymanCategory { get; set; }

        [Display(Name = "Freight Offers")]
        public virtual ICollection<FreightOfferTrx> FreightOfferTrxs { get; set; }

        [NotMapped]
        public SelectList SelectListDeliverymanCategory { get; set; }

        [Display(Name = "Min Charge")]
        public decimal MinimumDeliveryCost { get; set; }

        /// <summary>
        /// This is in percent. 2% = 2
        /// </summary>
        [Display(Name = "Percent Cost")]
        
        [Range(0,100)]
        public double CostOfDeliveryPct { get; set; }

        [Display(Name = "Max Package Weight")]
        public double MaxWeightInKg { get; set; }
        public override void UpdatePropertiesDuringModify(ICommonWithId ic)
        {
            Deliveryman deliveryman = ic as Deliveryman;
            deliveryman.IsNullThrowException("Unable to unbox deliveryman");

            DeliverymanCategoryId = deliveryman.DeliverymanCategoryId;
            DefaultBillAddressId = deliveryman.DefaultBillAddressId;

            MinimumDeliveryCost = deliveryman.MinimumDeliveryCost;
            CostOfDeliveryPct = deliveryman.CostOfDeliveryPct;
            MaxWeightInKg = deliveryman.MaxWeightInKg;

            base.UpdatePropertiesDuringModify(ic);
        }

        public override void SelfErrorCheck()
        {
            base.SelfErrorCheck();

            if (CostOfDeliveryPct < 0)
                throw new Exception("Cost of Delivery % cannot be less than 0.");

        }



        static string CommissionPct_DeliverymanSalesman_String()
        {
            string commission = ConfigurationManager.AppSettings["PercentOfSale.Salesman.Deliveryman"];

            if (commission.IsNullOrWhiteSpace())
            {
                throw new Exception("Please set PercentOfSale.Salesman.Deliveryman in WebConfig");
            }

            return commission;
        }
        static string CommissionPct_Deliveryman_Super_Salesman_String()
        {
            string commission = ConfigurationManager.AppSettings["PercentOfSale.Super.Salesman.Deliveryman"];

            if (commission.IsNullOrWhiteSpace())
            {
                throw new Exception("Please set PercentOfSale.Super.Salesman.Deliveryman in WebConfig");
            }

            return commission;
        }
        static string CommissionPct_Deliveryman_Super_Super_Salesman_String()
        {
            string commission = ConfigurationManager.AppSettings["PercentOfSale.Super.Super.Salesman.Deliveryman"];

            if (commission.IsNullOrWhiteSpace())
            {
                throw new Exception("Please set PercentOfSale.Super.Super.Salesman.Deliveryman in WebConfig");
            }

            return commission;
        }
        public static decimal CommissionPct_DeliverymanSalesman
        {
            get
            {
                return CommissionPct_DeliverymanSalesman_String().ToDecimal();
            }
        }

        public static decimal CommissionPct_Deliveryman_Super_Salesman
        {
            get
            {
                return CommissionPct_Deliveryman_Super_Salesman_String().ToDecimal();
            }
        }

        public static decimal CommissionPct_Deliveryman_Super_Super_Salesman
        {
            get
            {
                return CommissionPct_Deliveryman_Super_Super_Salesman_String().ToDecimal();
            }
        }

    }
}