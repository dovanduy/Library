﻿using ModelsClassLibrary.MenuNS;
using ModelsClassLibrary.ModelsNS.ProductChildNS;
using ModelsClassLibrary.SharedNS;
//using ModelsClassLibrary.Models.DiscountNS;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsClassLibrary.ModelsNS.ProductNS
{
    public partial class Product : ProductAbstract, IAmMenu
    {

        [NotMapped]
        public virtual List<CheckBoxItem> CheckedBoxesList { get; set; }

        public virtual ICollection<MenuPathMain> MenuPathMains { get; set; }

        public virtual ICollection<ProductChild> ProductChildren { get; set; }


        /// <summary>
        /// A product can have ONE or Many ProductIdentifiers. It must have at least one.
        /// For automobiles, this will be automatically created using the brand, year model etc.
        /// </summary>
        public virtual ICollection<ProductIdentifier> ProductIdentifiers { get; set; }

        ///// <summary>
        ///// This decides the menus
        ///// </summary>
        //[Display(Name = "Category")]
        //public virtual ICollection<MenuPathMain> MenuPathMains { get; set; }

        public override EnumLibrary.EnumNS.ClassesWithRightsENUM ClassNameForRights()
        {
            return EnumLibrary.EnumNS.ClassesWithRightsENUM.Product;
        }

    }
}