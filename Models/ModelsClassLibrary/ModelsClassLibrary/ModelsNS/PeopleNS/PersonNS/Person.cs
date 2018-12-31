﻿using AliKuli.Extentions;
using EnumLibrary.EnumNS;
using InterfacesLibrary.SharedNS.FeaturesNS;
using ModelsClassLibrary.ModelsNS.AddressNS;
using ModelsClassLibrary.ModelsNS.DocumentsNS.FilesDocsNS;
using ModelsClassLibrary.ModelsNS.GlobalCommentsNS;
using ModelsClassLibrary.ModelsNS.LikeUnlikeNS;
using ModelsClassLibrary.ModelsNS.PeopleNS.PlayersNS;
using ModelsClassLibrary.ModelsNS.PlacesNS;
using ModelsClassLibrary.ModelsNS.PlacesNS.EmailAddressNS;
using ModelsClassLibrary.ModelsNS.PlacesNS.PhoneNS;
//using ModelsClassLibrary.ModelsNS.PlacesNS.PhoneNS;
using ModelsClassLibrary.ModelsNS.ProductChildNS;
using ModelsClassLibrary.ModelsNS.SharedNS;
using ModelsClassLibrary.ModelsNS.UploadedFileNS;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web.Mvc;
using UserModels;
namespace ModelsClassLibrary.ModelsNS.PlayersNS
{

    //There can be NO person without a userId
    //You can create a User without a person.
    //The User cannot buy/sell/create products without person.
    //In order to be able to do that, person must exist

    //The phone, address, email defaults are made in such a way that
    //The phone, address, email have a property People which can be 0 or 1. It
    //is really a collection property and we have to make sure it is 1 through
    //code.

    public partial class Person : CommonWithId, IUserHasUploads
    {
        public Person()
        {
            PersonComplex = new PersonComplex();
            //AddressComplex = new AddressComplex();
            //BlackListed = new UserActive();
            //Suspended = new UserActive();

        }



        /// <summary>
        /// Every user can have many addresses.
        /// </summary>
        /// 

        public virtual ICollection<AddressMain> Addresses { get; set; }
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }





        public virtual PersonComplex PersonComplex { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public override bool HideNameInView()
        {
            return true;
        }


        [Display(Name = "Country")]
        [MaxLength(128)]
        public string CountryId { get; set; }
        public virtual Country Country { get; set; }

        [Display(Name = "Category")]
        public string PersonCategoryId { get; set; }

        [Display(Name = "Category")]
        public virtual PersonCategory PersonCategory { get; set; }


        public string DefaultBillAddressId { get; set; }
        public AddressMain DefaultBillAddress { get; set; }


        public string DefaultEmailAddressId { get; set; }
        public EmailAddress DefaultEmailAddress { get; set; }


        public string DefaultPhoneId { get; set; }
        public Phone DefaultPhone { get; set; }


        public virtual ICollection<Mailer> Mailers { get; set; }


        #region Uploads

        public virtual ICollection<UploadedFile> MiscFiles { get; set; }

        public string MiscFilesLocation()
        {
            return Path.Combine(AliKuli.ConstantsNS.MyConstants.SAVE_ROOT_DIRECTORY, "User");
        }


        public virtual ICollection<UploadedFile> SelfieUploads { get; set; }

        public string SelfieLocationConst(string userName)
        {
            return Path.Combine(AliKuli.ConstantsNS.MyConstants.SAVE_ROOT_DIRECTORY, "Selfie");

        }



        public virtual ICollection<UploadedFile> IdCardFrontUploads { get; set; }

        public string IdCardFrontLocationConst(string userName)
        {
            return Path.Combine(AliKuli.ConstantsNS.MyConstants.SAVE_ROOT_DIRECTORY, "IdCardfront");

        }



        public virtual ICollection<UploadedFile> IdCardBackUploads { get; set; }

        public string IdCardBackLocationConst(string userName)
        {
            return Path.Combine(AliKuli.ConstantsNS.MyConstants.SAVE_ROOT_DIRECTORY, "IdCardBack");
        }



        public virtual ICollection<UploadedFile> PassportFrontUploads { get; set; }


        public string PassportFrontLocationConst(string userName)
        {
            return Path.Combine(AliKuli.ConstantsNS.MyConstants.SAVE_ROOT_DIRECTORY, "PassportFront");

        }


        public virtual ICollection<UploadedFile> PassportVisaUploads { get; set; }

        public string PassportVisaLocationConst(string userName)
        {
            return Path.Combine(AliKuli.ConstantsNS.MyConstants.SAVE_ROOT_DIRECTORY, "PassportVisa");

        }


        public virtual ICollection<UploadedFile> LiscenseFrontUploads { get; set; }

        public string LiscenseFrontLocationConst(string userName)
        {
            return Path.Combine(AliKuli.ConstantsNS.MyConstants.SAVE_ROOT_DIRECTORY, "LiscenseFront");

        }

        public virtual ICollection<UploadedFile> LiscenseBackUploads { get; set; }

        public virtual ICollection<FileDoc> FileDocs { get; set; }

        #endregion

        public string LiscenseBackLocationConst(string userName)
        {
            return Path.Combine(AliKuli.ConstantsNS.MyConstants.SAVE_ROOT_DIRECTORY, "LiscenseBack");
        }








        public virtual ICollection<ProductChild> ProductChildren { get; set; }


        public virtual ICollection<GlobalComment> GlobalComments { get; set; }

        /// <summary>
        /// These are the likes and unlikes for this person.
        /// </summary>
        public virtual ICollection<LikeUnlike> LikeUnlikes { get; set; }


        [NotMapped]
        public SelectList SelectListPersonCategory { get; set; }



        [NotMapped]
        public SelectList SelectListBillAddress { get; set; }


        [NotMapped]
        public SelectList SelectListShipAddress { get; set; }
        [NotMapped]
        public SelectList SelectListUsers { get; set; }

        [NotMapped]
        public SelectList SelectListCountries { get; set; }

        public string MiscFilesLocation_Initialization()
        {
            return AliKuli.ConstantsNS.MyConstants.SAVE_INITIALIZATION_DIRECTORY;
        }

        public override ClassesWithRightsENUM ClassNameForRights()
        {
            return ClassesWithRightsENUM.Person;
        }

        //[NotMapped]
        //public bool SuspendedOldValue { get; set; }
        //[NotMapped]
        //public bool BlackListOldValue { get; set; }
        public override void UpdatePropertiesDuringModify(InterfacesLibrary.SharedNS.ICommonWithId ic)
        {
            base.UpdatePropertiesDuringModify(ic);
            Person person = ic as Person;
            person.IsNullThrowExceptionArgument("Unable to unbox person");
            CountryId = person.CountryId;
            DefaultBillAddressId = person.DefaultBillAddressId;
            PersonCategoryId = person.PersonCategoryId;
            PersonComplex = person.PersonComplex;
            DefaultPhoneId = person.DefaultPhoneId;
            //DefaultEmailAddressId = person.DefaultEmailAddressId;

            //AddressComplex = person.AddressComplex;
            //SuspendedOldValue = Suspended.Value;
            //BlackListOldValue = BlackListed.Value;
            //Suspended.Value= person.Suspended.Value;
            //BlackListed.Value = person.BlackListed.Value;
        }
    }
}