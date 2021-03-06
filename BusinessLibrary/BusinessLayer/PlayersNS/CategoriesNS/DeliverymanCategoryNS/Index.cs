﻿using AliKuli.Extentions;
using DalLibrary.DalNS;
using DalLibrary.Interfaces;
using ErrorHandlerLibrary.ExceptionsNS;
using ModelsClassLibrary.ModelsNS.PlayersNS;
using ModelsClassLibrary.ModelsNS.SharedNS;
using ModelsClassLibrary.ViewModels;
using System;
using System.Reflection;
using WebLibrary.Programs;

namespace UowLibrary.PlayersNS.DeliverymanCategoryNS
{
    public partial class DeliverymanCategoryBiz : BusinessLayer<DeliverymanCategory>
    {



        public override void Event_ModifyIndexList(IndexListVM indexListVM, ControllerIndexParams parameters)
        {
            base.Event_ModifyIndexList(indexListVM, parameters);

            indexListVM.Heading.Column = "Deliveryman Category";
            indexListVM.Show.EditDeleteAndCreate = true;

        }


    }
}
