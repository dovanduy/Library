﻿using AliKuli.Extentions;
using AliKuli.UtilitiesNS;
using ApplicationDbContextNS;
using BreadCrumbsLibraryNS.Programs;
using DalLibrary.Interfaces;
using ErrorHandlerLibrary.ExceptionsNS;
using ModelsClassLibrary.ModelsNS.PlacesNS;
using ModelsClassLibrary.ModelsNS.ProductNS;
using ModelsClassLibrary.ModelsNS.SharedNS;
using ModelsClassLibrary.ModelsNS.UploadedFileNS;
using ModelsClassLibrary.RightsNS;
using ModelsClassLibrary.ViewModels;
using System;
using System.Reflection;
using UowLibrary.MyWorkClassesNS;
using UowLibrary.PlayersNS;
using UowLibrary.ProductNS;
using UowLibrary.StateNS;
using UowLibrary.UploadFileNS;
using UserModels;
using WebLibrary.Programs;

namespace UowLibrary
{
    public partial class ProductIdentifierBiz : BusinessLayer<ProductIdentifier>
    {

        //ProductBiz _productBiz;
        public ProductIdentifierBiz(IRepositry<ProductIdentifier> entityDal, MyWorkClasses myWorkClasses, UploadedFileBiz uploadedFileBiz, BreadCrumbManager breadCrumbManager)
            : base(myWorkClasses, entityDal, uploadedFileBiz, breadCrumbManager)
        {
            //_productBiz = productBiz;
        }




    }
}
