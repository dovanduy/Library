﻿using AliKuli.Extentions;
using EnumLibrary.EnumNS;
using ModelsClassLibrary.ModelsNS.MenuNS.MenuManagerNS.MenuStateNS;
using ModelsClassLibrary.ModelsNS.SharedNS;
using ModelsClassLibrary.ModelsNS.UploadedFileNS;
using ModelsClassLibrary.ModelsNS.VerificatonNS;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Web.Hosting;

namespace ModelsClassLibrary.ViewModels
{
    [NotMapped]
    public class IndexItemVM : IIndexListItems
    {
        private const int MAX_LENGTH_ALLOWED = 100;
        public IndexItemVM()
        {

        }
        public IndexItemVM(string id, string name, string input1SortStr, string input2SortStr, string input3SortStr, bool isEditLocked, string description, VerificaionStatusENUM verificationStatus, decimal price, string comment)
        {
            Input3SortString = input3SortStr;
            Input2SortString = input2SortStr;
            Id = id;
            Name = name;
            Input1SortString = input1SortStr;

            AllowDelete = !isEditLocked;
            AllowEdit = !isEditLocked;

            Description = description;
            PrintLineNumber = "";
            MenuManager = null;
            VerificationStatus = verificationStatus;
            VerificationIconResult = new VerificationIconResult();

            Price = price;
            Comment = comment;
        }


        public bool IsShopAndOwnerOfShop { get; set; }
        public bool IsShop { get; set; }
        /// <summary>
        /// When this is true, there are no products for sale.
        /// </summary>
        public bool HasProductsForSale { get; set; }
        public int NoOfItems { get; set; }
        public int NoOfShops { get; set; }
        public string ShopExpiresStr { get; set; }
        //if this is true then user is accepting non-refundable payments
        public bool IsTokenPaymentAccepted { get; set; }
        public bool IsHidden { get; set; }

        public bool IsPickup { get; set; }
        public long CompleteMenuPathViews { get; set; }
        public long PictureViews { get; set; }
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string ImageAddressStr { get; set; }

        public string Description { get; set; }

        public string Comment { get; set; }

        public VerificaionStatusENUM VerificationStatus { get; set; }
        public VerificationIconResult VerificationIconResult { get; set; }

        #region Sort strings


        public string Input1SortString { get; set; }
        public string Input2SortString { get; set; }
        public string Input3SortString { get; set; }

        #endregion

        /// <summary>
        /// This is used in the descriptions
        /// </summary>
        public string Name { get; set; }
        public string ShortName
        {
            get
            {
                if (FullName.IsNullOrWhiteSpace())
                    return "";

                if (FullName.Trim().Length > MAX_LENGTH_ALLOWED)
                {
                    return Name.Trim().Substring(0, MAX_LENGTH_ALLOWED) + "...";
                }
                return Name.Trim();
            }
        }
        public string FullName
        {
            get
            {
                if (Name.IsNullOrWhiteSpace())
                    return "";

                return Name.Trim();
            }
        }

        public override string ToString()
        {
            return FullName;
        }


        //if this is true, then the item has been marked default
        public bool IsDefault { get; set; }

        public IMenuManager MenuManager { get; set; }

        #region Bools
        //public bool IsImageThere
        //{
        //    get
        //    {
        //        return !ImageAddressStr.IsNullOrWhiteSpace();
        //    }
        //}

        //public bool IsEditLocked { get; set; }

        public bool AllowDelete { get; set; }
        public bool AllowEdit { get; set; }

        public string PrintLineNumber { get; set; }

        const int MAX_PICTURE_HEIGHT_WIDTH = 350;

        /// <summary>
        /// This sets up the max height and width so there is no jumping up and down of the picture
        /// </summary>
        /// <param name="lst"></param>
        public static void GetMaxWidthHeightForCarousel(List<string> lst)
        {
            if (lst.IsNullOrEmpty())
                return;
            foreach (var item in lst)
            {

                string hostPath = HostingEnvironment.MapPath(item);
                System.Drawing.Image img;
                try
                {
                    img = System.Drawing.Image.FromFile(hostPath);
                }
                catch (System.Exception)
                {
                    UploadedFile uplf = new UploadedFile();
                    hostPath = uplf.DefaultDisplayImage;
                    img = System.Drawing.Image.FromFile(HostingEnvironment.MapPath(hostPath));

                }
                int width = img.Width;
                int height = img.Height;

                if (height > MAX_PICTURE_HEIGHT_WIDTH)
                {
                    maxHeightFound = MAX_PICTURE_HEIGHT_WIDTH;
                    break;
                }
                if (maxHeightFound < height)
                    maxHeightFound = height;

                if (height > width)
                    continue;


            }


        }
        /// <summary>
        /// This gets set in GetMaxWidthHeightForCarousel and used in PictureCalculateDimensions
        /// </summary>
        static int maxHeightFound = 0;
        static int MaxHeightFound
        {
            get { return maxHeightFound; }
        }

        /// <summary>
        /// This is the second heading line.
        /// </summary>
        public string Amount2ndLine { get; set; }

        /// <summary>
        /// The image pictureAddress is the absolute path
        /// </summary>
        /// <param name="pictureAddress"></param>
        /// <returns></returns>
        public bool IsPictureLandscape(string pictureAddress)
        {

            using (Image image = Image.FromFile(pictureAddress))
            {

                return image.Height < image.Width;
            }

        }
        public static void PictureCalculateDimensions(string pictureAddress)
        {
            PictureHeight = MaxHeightFound.ToString();
            PictureWidth = "0";


            //if picture is potrait, then look for max height
            //if picture is landscape, look for max width

            //pictureAddress.IsNullOrWhiteSpaceThrowException("PictureAddress");
            //string hostPath = HostingEnvironment.MapPath(pictureAddress);
            //System.Drawing.Image img = System.Drawing.Image.FromFile(hostPath);
            //int width = img.Width;
            //int height = img.Height;

            //if (MaxPictureWidth == 0)
            //    MaxPictureWidth = MAX_PICTURE_HEIGHT_WIDTH;

            //if (MaxPictureHeight == 0)
            //    MaxPictureHeight = MAX_PICTURE_HEIGHT_WIDTH;

            //PictureWidth = "0";
            //PictureHeight = "0";

            //if (height > width)
            //{
            //    PictureHeight = MaxPictureWidth.ToString();
            //}
            //else
            //{
            //    PictureWidth = MaxPictureWidth.ToString();
            //}
        }

        private static int MaxPictureWidth { get; set; }
        private static int MaxPictureHeight { get; set; }

        public static string PictureWidth { get; set; }
        public static string PictureHeight { get; set; }


        public decimal Price { get; set; }
        public static decimal PriceStatic { get; set; }
        public static string PriceDisplay
        {
            get
            {
                if (PriceStatic == 0)
                    return "";
                return PriceStatic.ToString().ToRuppeeFormat();
            }
        }
        #endregion


    }
}
