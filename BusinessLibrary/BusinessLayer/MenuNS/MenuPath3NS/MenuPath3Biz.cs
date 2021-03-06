﻿using AliKuli.Extentions;
using AliKuli.UtilitiesNS;
using ApplicationDbContextNS;
using BreadCrumbsLibraryNS.Programs;
using DalLibrary.Interfaces;
using ErrorHandlerLibrary.ExceptionsNS;
using InterfacesLibrary.SharedNS;
using ModelsClassLibrary.MenuNS;
using ModelsClassLibrary.ModelsNS.ProductNS;
using ModelsClassLibrary.ModelsNS.SharedNS;
using ModelsClassLibrary.ModelsNS.UploadedFileNS;
using ModelsClassLibrary.RightsNS;
using System;
using System.Reflection;
using UowLibrary.FeatureNS.MenuFeatureNS;
using UowLibrary.ParametersNS;
using UowLibrary.PlayersNS;
using UowLibrary.UploadFileNS;
using UserModels;
using WebLibrary.Programs;

namespace UowLibrary.MenuNS
{
    public partial class MenuPath3Biz : BusinessLayer<MenuPath3>
    {

        MenuFeatureBiz _menuFeatureBiz;
        ProductFeatureBiz _productFeatureBiz;
            public MenuPath3Biz(IRepositry<MenuPath3> entityDal, BizParameters bizParameters, MenuFeatureBiz menuFeatureBiz, ProductFeatureBiz productFeatureBiz)
            : base(entityDal, bizParameters)
        {
            _menuFeatureBiz = menuFeatureBiz;
            _productFeatureBiz = productFeatureBiz;
        }


        MenuFeatureBiz MenuFeatureBiz
        {
            get
            {
                _menuFeatureBiz.UserId = UserId;
                _menuFeatureBiz.UserName = UserName;
                return _menuFeatureBiz;
            }
        }


        ProductFeatureBiz ProductFeatureBiz
        {
            get
            {
                _productFeatureBiz.UserId = UserId;
                _productFeatureBiz.UserName = UserName;
                return _productFeatureBiz;
            }
        }


    }
}
