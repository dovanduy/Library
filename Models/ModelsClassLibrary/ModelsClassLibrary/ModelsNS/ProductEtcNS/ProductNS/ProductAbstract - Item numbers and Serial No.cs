﻿using ModelsClassLibrary.ModelsNS.SharedNS;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelsClassLibrary.ModelsNS.ProductNS
{
    /// <summary>
    /// Note. Scratch card 16 digit serial number is placed in Name AND in ProductsOwnNumber. I believe thqt ProductsOwnNumber
    /// needs to be removed. No need for that. Name is fine because it will not duplicate intrinsically.
    /// </summary>
    public abstract partial class ProductAbstract : CommonWithId
    {



        /// <summary>
        /// A product can have ONE or Many ProductIdentifiers. It must have at least one.
        /// For automobiles, this will be automatically created using the brand, year model etc.
        /// </summary>
        public ICollection<ProductIdentifier> ProductIdentifiers { get; set; }


        //#region Properties

        /// <summary>
        /// This is the serial number of the product Moved to the Chile
        /// </summary>
        //[Display(Name = "Serial #")]
        //public string SerialNo { get; set; }










    }
}