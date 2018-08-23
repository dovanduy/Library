﻿using AliKuli.Extentions;
using AliKuli.UtilitiesNS;
using ApplicationDbContextNS;
using BreadCrumbsLibraryNS.Programs;
using DalLibrary.Interfaces;
using ErrorHandlerLibrary.ExceptionsNS;
using ModelsClassLibrary.ModelsNS.DeliveryMethodNS;
using ModelsClassLibrary.ModelsNS.SharedNS;
using ModelsClassLibrary.RightsNS;
using ModelsClassLibrary.ViewModels;
using System;
using System.Reflection;
using UowLibrary.MyWorkClassesNS;
using UowLibrary.PlayersNS;
using UowLibrary.UploadFileNS;
using UserModels;
using WebLibrary.Programs;

namespace UowLibrary.PaymentTermNS
{
    public partial class PaymentTermBiz : BusinessLayer<PaymentTerm>
    {
        public PaymentTermBiz(IRepositry<PaymentTerm> entityDal, MyWorkClasses myWorkClasses, UploadedFileBiz uploadedFileBiz, BreadCrumbManager breadCrumbManager)
            : base(myWorkClasses, entityDal, uploadedFileBiz, breadCrumbManager)
        {

        }

    }
}
