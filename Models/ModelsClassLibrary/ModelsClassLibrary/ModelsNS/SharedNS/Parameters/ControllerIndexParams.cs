﻿using BreadCrumbsLibraryNS.Programs;
using EnumLibrary.EnumNS;
using InterfacesLibrary.SharedNS;
using ModelsClassLibrary.ModelsNS.SharedNS.Parameters;
using System.ComponentModel.DataAnnotations.Schema;
using UserModels;

namespace ModelsClassLibrary.ModelsNS.SharedNS
{
    /// <summary>
    /// These are the parameters that are returned by all the index methods. This class is used just to transport them.
    /// Now, everytime you change the parameters, this class will shield the change from all the various layers.
    /// </summary>
    [NotMapped]
    public class ControllerIndexParams
    {
        public ControllerIndexParams()
        {
            //Menu = new MenuParameters(MenuENUM.IndexDefault, "");

        }

        public ControllerIndexParams(
            string id,
            string menuPathMainId,
            string searchFor,
            string isandForSearch,
            string selectedId,
            MenuENUM menuEnum,
            SortOrderENUM sortBy,
            string logoAddress,
            ICommonWithId entity,
            ICommonWithId dudEntity,
            string userId,
            string userName,
            bool isUserAdmin,
            bool isMenu,
            BreadCrumbManager breadCrumbManager,
            ActionNameENUM actionNameEnum,
            LikeUnlikeParameters likesCounter,
            string productId,
            string returnUrl,
            BuySellDocumentTypeENUM buySellDocumentTypeEnum,
            BuySellDocStateENUM buySellDocStateEnum, string button)
        {
            Id = id;
            Button = button;
            SearchFor = searchFor;
            IsAndForSearch = isandForSearch == "And";
            SelectedId = selectedId;
            Entity = entity;
            SortBy = sortBy;
            //Menu = new MenuParameters(menuEnum, id);
            MenuEnum = menuEnum;

            LogoAddress = logoAddress;
            UserName = userName;
            UserId = userId;
            IsUserAdmin = isUserAdmin;
            ActionNameEnum = actionNameEnum;
            DudEntity = dudEntity;
            BreadCrumbManager = breadCrumbManager;
            LikeUnlikeCounter = likesCounter;
            IsMenu = isMenu;
            MenuPathMainId = menuPathMainId;
            ProductId = productId;
            ReturnUrl = returnUrl;
            BuySellDocumentTypeEnum = buySellDocumentTypeEnum;
            BuySellDocStateEnum = buySellDocStateEnum;
        }

        public BuySellDocumentTypeENUM BuySellDocumentTypeEnum { get; set; }
        public BuySellDocStateENUM BuySellDocStateEnum { get; set; }

        /// <summary>
        /// If this is true then Menu features will work in the View: _IndexMiddlePart - TiledPictures
        /// </summary>
        public bool IsMenu { get; set; }
        public MenuENUM MenuEnum { get; set; }
        /// <summary>
        /// This is used in the view of Product and ProductChild
        /// It causes the features to display as editable during create
        /// and not during Edit or any other operation.
        /// It is switched on in CreateHttp of EntityAbstractController
        /// </summary>
        public bool IsCreate { get; set; }
        public string Button { get; set; }
        public ApplicationUser User { get; set; }
        public string ProductId { get; set; }
        public string ProductChildId { get; set; }

        public string ReturnUrl { get; set; }
        public string MenuPathMainId { get; set; }
        public BreadCrumbManager BreadCrumbManager { get; set; }
        public ActionNameENUM ActionNameEnum { get; set; }
        public bool IsAndForSearch { get; set; }
        public ICommonWithId Entity { get; set; }
        public ICommonWithId DudEntity { get; set; }
        public string SearchFor { get; set; }
        public SortOrderENUM SortBy { get; set; }
        public string SelectedId { get; set; }

        /// <summary>
        /// this is the Id of the main item
        /// </summary>
        public string Id { get; set; }
        public string LogoAddress { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        //public ApplicationUser User { get; set; }

        public bool IsUserAdmin { get; set; }
        //public string ReturnUrl { get; set; }
        public MenuParameters Menu { get; set; }
        public LikeUnlikeParameters LikeUnlikeCounter { get; set; }
        //public string UserPersonId { get; set; }
        //public string ProductChildPersonId { get; set; }

    }
}
