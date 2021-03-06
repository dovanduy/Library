﻿
using AliKuli.Extentions;
using EnumLibrary.EnumNS;
using InterfacesLibrary.SharedNS;
using ModelsClassLibrary.ModelsNS.UploadedFileNS;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using UserModels;

namespace ModelsClassLibrary.ModelsNS.SharedNS
{
    /// <summary>
    /// This class will carry all the information from the create and edit modules in the controller all the way through
    /// Morevover, it will also dea
    /// </summary>
    /// 
    [NotMapped]
    public class ControllerCreateEditParameter
    {
        public ControllerCreateEditParameter()
        {
            MiscUploadedFiles = new ControllerCreateEditParameterDetail();
            SelfieUpload = new ControllerCreateEditParameterDetail();
            IdCardFront = new ControllerCreateEditParameterDetail();
            IdCardBack = new ControllerCreateEditParameterDetail();
            PassportFront = new ControllerCreateEditParameterDetail();
            PassportVisa = new ControllerCreateEditParameterDetail();
            LiscenseFront = new ControllerCreateEditParameterDetail();
            LiscenseBack = new ControllerCreateEditParameterDetail();
        }


        public ControllerCreateEditParameter(ICommonWithId entity, HttpPostedFileBase[] httpMiscUploadedFiles, HttpPostedFileBase[] httpSelfieUpload, HttpPostedFileBase[] httpIdCardFront, HttpPostedFileBase[] httpIdCardBack, HttpPostedFileBase[] httpPassportFront, HttpPostedFileBase[] httpPassportVisa, HttpPostedFileBase[] httpLiscenseFront, HttpPostedFileBase[] httpLiscenseBack, MenuLevelENUM menuLevelEnum, string userName, string productCat1Id, string productCat2Id, string productCat3Id)
            : this()
        {
            Entity = entity;
            MiscUploadedFiles.HttpBase = httpMiscUploadedFiles;
            SelfieUpload.HttpBase = httpSelfieUpload;
            IdCardFront.HttpBase = httpIdCardFront;
            IdCardBack.HttpBase = httpIdCardBack;
            PassportFront.HttpBase = httpPassportFront;
            PassportVisa.HttpBase = httpPassportVisa;
            LiscenseFront.HttpBase = httpLiscenseFront;
            LiscenseBack.HttpBase = httpLiscenseBack;

            UserName = userName;
            
            Menu = new MenuParameters(menuLevelEnum, productCat1Id, productCat2Id, productCat3Id);
            //todo what should we do if userName is empty?

            if (IsIHasUploads)
            {
                MiscUploadedFiles.FileLocationConst = Entity_IHasUploads.MiscFilesLocation(UserName);
            }

            //this is where the file gets it's location. The location comes from the constants
            if (IsIUserHasUploads)
            {
                SelfieUpload.FileLocationConst = Entity_IUserHasUploads.SelfieLocationConst(UserName);

                IdCardFront.FileLocationConst = Entity_IUserHasUploads.IdCardFrontLocationConst(UserName);
                IdCardBack.FileLocationConst = Entity_IUserHasUploads.IdCardBackLocationConst(UserName);

                PassportFront.FileLocationConst = Entity_IUserHasUploads.PassportFrontLocationConst(UserName);
                PassportVisa.FileLocationConst = Entity_IUserHasUploads.PassportVisaLocationConst(UserName);

                LiscenseFront.FileLocationConst = Entity_IUserHasUploads.LiscenseFrontLocationConst(UserName);
                LiscenseBack.FileLocationConst = Entity_IUserHasUploads.LiscenseBackLocationConst(UserName);
            }

        }

        public ICommonWithId Entity { get; set; }
        public string UserName { get; set; }

        //public string ProductCat1Id { get; set; }
        //public string ProductCat2Id { get; set; }
        //public string ProductCat3Id { get; set; }
        public MenuParameters Menu { get; set; }

        #region Uploads


        public ControllerCreateEditParameterDetail MiscUploadedFiles { get; set; }

        public ControllerCreateEditParameterDetail SelfieUpload { get; set; }
        public ControllerCreateEditParameterDetail IdCardFront { get; set; }
        public ControllerCreateEditParameterDetail IdCardBack { get; set; }
        public ControllerCreateEditParameterDetail PassportFront { get; set; }
        public ControllerCreateEditParameterDetail PassportVisa { get; set; }
        public ControllerCreateEditParameterDetail LiscenseFront { get; set; }
        public ControllerCreateEditParameterDetail LiscenseBack { get; set; }


        //public ControllerCreateEditParameterDetail ProductBigPic { get; set; }
        //public ControllerCreateEditParameterDetail ProductSmallPic { get; set; }



        #endregion


        #region IsIHasUploads
        public bool IsIHasUploads
        {
            get
            {
                return !Entity_IHasUploads.IsNull();
            }
        }

        public IHasUploads Entity_IHasUploads
        {
            get
            {
                return Entity as IHasUploads;
            }
        }
        #endregion

        #region IUserHasUploads

        public bool IsIUserHasUploads
        {
            get
            {
                return !Entity_IUserHasUploads.IsNull();
            }
        }

        public IUserHasUploads Entity_IUserHasUploads
        {
            get
            {
                return Entity as IUserHasUploads;
            }
        }
        #endregion

    }
}
