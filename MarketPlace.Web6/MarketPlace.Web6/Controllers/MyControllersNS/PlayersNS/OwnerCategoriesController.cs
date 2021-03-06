﻿using System.Threading.Tasks;
using System.Web.Mvc;
using ErrorHandlerLibrary.ExceptionsNS;
using MarketPlace.Web6.Controllers.Abstract;
using ModelsClassLibrary.ModelsNS.DeliveryMethodNS;
using ModelsClassLibrary.ModelsNS.PeopleNS;
using ModelsClassLibrary.ModelsNS.PlacesNS;
using ModelsClassLibrary.ModelsNS.PlayersNS;
using UowLibrary.PaymentMethodNS;
using UowLibrary.PlayersNS.OwnerCategoryNS;
using UowLibrary;
using BreadCrumbsLibraryNS.Programs;
using UowLibrary.ParametersNS;
using UowLibrary.PlayersNS;
using ModelsClassLibrary.ModelsNS.SharedNS;
using ErrorHandlerLibrary;
using UowLibrary.PageViewNS;

namespace MarketPlace.Web6.Controllers
{
    public class OwnerCategoriesController : EntityAbstractController<OwnerCategory>
    {

        OwnerCategoryBiz _OwnerCategoryBiz;
        #region Constructo and initializers

        public OwnerCategoriesController(OwnerCategoryBiz biz,  AbstractControllerParameters param)
            : base(biz, param) 
        {
            _OwnerCategoryBiz = biz;
        }

        #endregion


    }
}