﻿using AliKuli.Extentions;
using ModelsClassLibrary.ModelsNS.SharedNS;
using System.ComponentModel.DataAnnotations;
namespace ModelsClassLibrary.ModelsNS.ProductNS
{

    public abstract partial class ProductAbstract 
    {



        /// <summary>
        /// If this is a child, then we will need the parent.
        /// </summary>
        [Display(Name = "Child?")]
        public bool IsChild
        {
            get
            {
                return !ParentId.IsNullOrWhiteSpace();
            }
        }


        /// <summary>
        /// If true, product will be displayed on Website.
        /// </summary>
        [Display(Name = "Display on Website?")]
        public bool IsDisplayedOnWebsite { get; set; }


        /// <summary>
        /// If product is saleable, it will be able to be sold, and so be displayed on the webpage.
        /// It is possible to be not saleable and be IsDisplayedOnWebsite - eg. advert.
        /// </summary>
        public bool IsSaleable { get; set; }




        /// <summary>
        /// This disables the name in the view.
        /// </summary>
        /// <returns></returns>
        //public override bool DisableNameInView()
        //{
        //    return true;
        //}

        public override bool HideNameInView()
        {
            return true;
        }

    }
}