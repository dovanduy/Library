﻿using AliKuli.UtilitiesNS;
using ApplicationDbContextNS;
using BreadCrumbsLibraryNS.Programs;
using DalLibrary.Interfaces;
using ErrorHandlerLibrary.ExceptionsNS;
using ModelsClassLibrary.ModelsNS.ProductNS;
using ModelsClassLibrary.ModelsNS.SharedNS;
using ModelsClassLibrary.ModelsNS.UploadedFileNS;
using ModelsClassLibrary.RightsNS;
using UowLibrary.MyWorkClassesNS;
using UowLibrary.PlayersNS;
using UowLibrary.StateNS;
using UowLibrary.UploadFileNS;
using UserModels;
using WebLibrary.Programs;

namespace UowLibrary
{
    public partial class UomWeightBiz : BusinessLayer<UomWeight>
    {

        public UomWeightBiz(IRepositry<UomWeight> entityDal, MyWorkClasses myWorkClasses, UploadedFileBiz uploadedFileBiz, BreadCrumbManager breadCrumbManager)
            : base(myWorkClasses, entityDal, uploadedFileBiz, breadCrumbManager)
        {
        }





    }
}
