﻿
namespace ModelsClassLibrary.ModelsNS.MenuNS.MenuManagerNS.CreateMenuStatesNS
{
    public class CreateEditMenuState_Lv4 : CreateEditMenuStateAbstract
    {

        public CreateEditMenuState_Lv4(
            string currentViewName, 
            string menuPath1Id, 
            string menuPath2Id, 
            string menuPath3Id, 
            string productId, 
            string productChildId,
            string menuPathMainId,
            string productVmNameEditLink)
            : base(currentViewName, menuPath1Id, menuPath2Id, menuPath3Id, productId, productChildId, menuPathMainId, productVmNameEditLink)

        {
            _currrentViewName = currentViewName;
        }

        public override bool Disable_MenuPath1 { get { return true; } }
        public override bool Disable_MenuPath2 { get { return true; } }


        public string EditButtonController_ControllerName
        {
            get { return "Products"; }
        }

        public override string Id_EditLink
        {
            get
            {
                return _productId;
            }
        }

    }
}
