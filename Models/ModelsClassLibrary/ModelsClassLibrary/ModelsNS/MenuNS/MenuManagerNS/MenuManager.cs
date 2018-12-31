﻿using AliKuli.Extentions;
using BreadCrumbsLibraryNS.Programs;
using EnumLibrary.EnumNS;
using ModelsClassLibrary.MenuNS;
using ModelsClassLibrary.ModelsNS.MenuNS.MenuManagerNS;
using ModelsClassLibrary.ModelsNS.MenuNS.MenuManagerNS.MenuStateNS;
using ModelsClassLibrary.ModelsNS.ProductChildNS;
using ModelsClassLibrary.ModelsNS.ProductNS;
using ModelsClassLibrary.ModelsNS.SharedNS.Parameters;
using System.Collections.Generic;
using UowLibrary.MenuNS.MenuStateNS.MenuStatesNS;

namespace UowLibrary.MenuNS.MenuStateNS
{
    public class MenuManager : IMenuManager
    {
        public MenuManager()
        {
        }
        public MenuManager(MenuPathMain menuPathMain, Product product, ProductChild productChild, MenuENUM menuEnum, BreadCrumbManager breadCrumbManager, LikeUnlikeParameter likesCounter, string userId)
            : this()
        {
            MenuPathMain = menuPathMain;
            Product = product;
            ProductChild = productChild;
            MenuEnum = menuEnum;
            BreadCrumbManager = breadCrumbManager;
            LoadMenuState();
            UserId = userId;
            UserMoneyAccount = new UserMoneyAccount();
        }

        /// <summary>
        /// This is used in the Icons IndexMenuVariables
        /// </summary>
        private string UserId { get; set; }
        private void LoadMenuState()
        {
            switch (MenuEnum)
            {

                case MenuENUM.IndexMenuPath1:
                    MenuState = new IndexMenuPath1(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;
                case MenuENUM.IndexMenuPath2:
                    MenuState = new IndexMenuPath2(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;
                case MenuENUM.IndexMenuPath3:
                    MenuState = new IndexMenuPath3(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;
                case MenuENUM.IndexMenuProduct:
                    MenuState = new IndexMenuProduct(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;
                case MenuENUM.IndexMenuProductChild:
                    MenuState = new IndexMenuProductChild(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;

                case MenuENUM.EditDefault:
                    MenuState = new EditDefault(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;

                case MenuENUM.EditMenuPath1:
                    MenuState = new EditMenuPath1(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;
                case MenuENUM.EditMenuPath2:
                    MenuState = new EditMenuPath2(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;
                case MenuENUM.EditMenuPath3:
                    MenuState = new EditMenuPath3(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;
                case MenuENUM.EditMenuProduct:
                    MenuState = new EditMenuProduct(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;
                case MenuENUM.EditMenuProductChild:
                    MenuState = new EditMenuProductChild(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;


                case MenuENUM.CreateMenuPath1:
                    MenuState = new CreateMenuPath1(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;
                case MenuENUM.CreateMenuPath2:
                    MenuState = new CreateMenuPath2(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;
                case MenuENUM.CreateMenuPath3:
                    MenuState = new CreateMenuPath3(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;
                case MenuENUM.CreateMenuProduct:
                    MenuState = new CreateMenuProduct(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;
                case MenuENUM.CreateMenuProductChild:
                    MenuState = new CreateMenuProductChild(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;

                case MenuENUM.CreateDefault:
                    MenuState = new CreateDefault(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;
                case MenuENUM.IndexDefault:
                    MenuState = new IndexDefault(MenuPathMain, Product, ProductChild, MenuEnum, LikeUnlikesCounter);
                    break;

                default:
                    break;
            }
        }

        IMenuState _menuState;
        public IMenuState MenuState
        {
            get
            {
                return _menuState;
            }
            set
            {
                _menuState = value;
                _menuState.IsNullThrowException();

            }
        }


        private MenuENUM MenuEnum { get; set; }
        public MenuENUM MenuEnumCreateButton { get; set; }
        public MenuENUM MenuEnumEditButtom { get; set; }


        public MenuPathMain MenuPathMain { get; set; }
        public Product Product { get; set; }
        public ProductChild ProductChild { get; set; }


        //public string MenuPath1Id { get; set; }
        //public string MenuPath2Id { get; set; }
        //public string MenuPath3Id { get; set; }

        public BreadCrumbManager BreadCrumbManager { get; set; }
        public string CurrentUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string SelectedId { get; set; }
        public string SearchString { get; set; }
        public SortOrderENUM SortOrderEnum { get; set; }
        public LikeUnlikeParameter LikeUnlikesCounter { get; set; }

        IndexMenuVariables _indexMenuVariables;
        public IndexMenuVariables IndexMenuVariables
        {
            get
            {
                return _indexMenuVariables ?? new IndexMenuVariables(UserId);
            }
            set
            {
                _indexMenuVariables = value;
            }
        }
        public string WebClicksCount { get; set; }
        public UserMoneyAccount UserMoneyAccount { get; set; }

        //This is used in the view of Product and ProductChild
        //It causes the features to display as editable during create
        // and not during Edit or any other operation.
        public bool IsCreate { get; set; }


        /// <summary>
        /// This holds all the addresses of the pictures for the item
        /// </summary>
        public List<string> PictureAddresses { get; set; }
    }
}
