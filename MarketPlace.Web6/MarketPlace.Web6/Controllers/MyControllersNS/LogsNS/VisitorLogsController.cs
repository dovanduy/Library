﻿using System.Threading.Tasks;
using System.Web.Mvc;
using ErrorHandlerLibrary.ExceptionsNS;
using MarketPlace.Web6.Controllers.Abstract;
using ModelsClassLibrary.ModelsNS.Logs.VisitorsLogNS;
using UowLibrary.VisitorLogNS;
using UowLibrary;
using BreadCrumbsLibraryNS.Programs;
using UowLibrary.ParametersNS;
using UowLibrary.PlayersNS;
using ModelsClassLibrary.ModelsNS.SharedNS;
using ErrorHandlerLibrary;
using UowLibrary.PageViewNS;

namespace MarketPlace.Web6.Controllers
{
    public class VisitorLogsController : EntityAbstractController<VisitorLog>
    {

        VisitorLogBiz _VisitorLogBiz;
        #region Constructo and initializers

        public VisitorLogsController(VisitorLogBiz biz, AbstractControllerParameters param)
            : base(biz, param) 
        {
            _VisitorLogBiz = biz;
        }

        #endregion



    }
}