﻿using AliKuli.Extentions;
using AliKuli.UtilitiesNS;
using BreadCrumbsLibraryNS.Programs;
using ErrorHandlerLibrary;
using ErrorHandlerLibrary.ExceptionsNS;
using InterfacesLibrary.SharedNS;
using InterfacesLibrary.SharedNS.FeaturesNS;
using Microsoft.AspNet.Identity;
using ModelsClassLibrary.ModelsNS.SharedNS;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using UowLibrary;
using UowLibrary.Interface;
using UowLibrary.ParametersNS;
using UowLibrary.PageViewNS;
using UowLibrary.PlayersNS;
using UowLibrary.UploadFileNS;
using UserModels;
using WebLibrary.Programs;

namespace MarketPlace.Web4.Controllers
{
    /// <summary>
    /// Note. The Error_Controller and the Error_Uow are the same
    /// After exectuing an action, the AbstractController automaticlly adds the errors.
    /// You must wire up tye Uow in the Controllers so that the Uow goes into Uow and then
    /// you can create one from that which is for that particular controller if you need it.
    /// </summary>
    public abstract partial class AbstractController : Controller
    {

        private string _userId;
        readonly PageViewBiz _pageViewBiz;
        BreadCrumbManager _bcm;
        IErrorSet _err;
        IMemoryMain _memoryMain;
        ConfigManagerHelper _configManagerHelper;
        /// <summary>
        /// All errorsets taken from DI point to the same reference.
        /// </summary>
        /// <param name="errorSet"></param>

        public AbstractController(AbstractControllerParameters param)
        {
            _bcm = param.BreadCrumbManager;
            _err = param.ErrorSet;
            _pageViewBiz = param.PageViewBiz;
            _memoryMain = param.MemoryMain;
            _configManagerHelper = param.ConfigManagerHelper;

        }

        public ConfigManagerHelper ConfigManagerHelper
        {
            get 
            {
                return _configManagerHelper; 
            }
        }
        /// <summary>
        /// There is a complication with UserStringId. It gets initialized here in the OnActionExecuting(ActionExecutingContext filterContext).
        /// Thereafter, the Uow UserStringId in the Uow initializes over here. However, to use this, the Uow must be initialized in the constructor
        /// of the calling controller.
        /// </summary>

        private IBiz _uow;

        protected IBiz Uow
        {
            get
            {
                _uow.IsNullThrowException();
                return _uow;
            }
            set
            {
                _uow = value;
            }
        }

        protected IMemoryMain MemoryMain
        {
            get
            {
                _memoryMain.IsNullThrowException();
                return _memoryMain;
            }
        }

        protected BreadCrumbManager BreadCrumbManager{
            get
            {
                _bcm.IsNullThrowException();
                return _bcm;
            }
        }

        public IErrorSet ErrorsGlobal
        {
            get
            {
                _err.IsNullThrowException();
                return _err;
            }
        }

        //public string HomeUrl
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //        //var req = new System.Web.Routing.RequestContext();
        //        //string home = UrlHelper.GenerateUrl("Default", "Index", "Home", null, null, req, false);
        //        //return home;
        //    }
        //}


        protected string UserId
        {
            get
            {

                if (!User.IsNull())
                    return (_userId = User.Identity.GetUserId());

                return "";
            }
        }


        protected string UserName
        {

            get
            {
                if (!User.IsNull())
                    return (User.Identity.GetUserName());
                return "";

            }
        }


        protected PageViewBiz PageViewBiz
        {
            get { return _pageViewBiz; }
        }





    }
}