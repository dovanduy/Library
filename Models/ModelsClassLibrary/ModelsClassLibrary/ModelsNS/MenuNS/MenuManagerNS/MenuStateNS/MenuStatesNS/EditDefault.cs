﻿using EnumLibrary.EnumNS;
using ModelsClassLibrary.MenuNS;
using ModelsClassLibrary.ModelsNS.ProductChildNS;
using ModelsClassLibrary.ModelsNS.ProductNS;
using ModelsClassLibrary.ModelsNS.SharedNS.Parameters;

namespace UowLibrary.MenuNS.MenuStateNS.MenuStatesNS
{
    public class EditDefault : MenuStateAbstract
    {

        public EditDefault(MenuPathMain menuPathMain, Product product, ProductChild productChild, MenuENUM menuEnum, LikeUnlikeParameter likeUnlikesCounter)
            : base(menuPathMain, product, productChild, menuEnum, likeUnlikesCounter) { }

        public override MenuENUM EditLink_MenuEnum
        {
            get { return MenuENUM.EditMenuPath1; }
        }

        public override string CreateLink_Name
        {
            get { return "Create"; }
        }


        public override MenuENUM CreateLink_MenuEnum
        {
            get { return MenuENUM.CreateMenuPath1; }
        }

        public override string BackLink_Name
        {
            get { return "Back To Menu"; }
        }


        public override MenuENUM BackLink_MenuEnum
        {
            get { return MenuENUM.IndexMenuPath1; }
        }

        public override bool ShowCreateButton
        {
            get { return true; }
        }

        public override bool ShowEditButton
        {
            get { return true; }
        }

        public override string CreateAndEditLink_ControllerName
        {
            get { return base.ControllerCurrentName; }
        }
        public override string MenuPath1Id
        {
            get { return ""; }
        }

        public override string MenuPath2Id
        {
            get { return ""; }
        }

        public override string MenuPath3Id
        {
            get { return ""; }
        }

        public override string ProductId
        {
            get { return ""; }
        }

        public override string ProductChildId
        {
            get { return ""; }
        }

        public override string MenuDisplayName
        {
            get
            {
                return "Edit " + base.MenuDisplayName;
            }
        }

    }
}
