﻿using AliKuli.Extentions;
using AliKuli.UtilitiesNS;
using ErrorHandlerLibrary.ExceptionsNS;
using InterfacesLibrary.SharedNS;
using ModelsClassLibrary.ModelsNS.SharedNS;
using ModelsClassLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using UowLibrary.Abstract;
using UowLibrary.Interface;

namespace UowLibrary
{
    /// <summary>
    /// This is where all the Fix, bussiness Rules and ErrorChecks are implemented
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract partial class BusinessLayer<TEntity>
    {
        public ControllerCreateEditParameter CreateControllerCreateEditParameter(ICommonWithId iCommonWithId)
        {
            ControllerCreateEditParameter cp = new ControllerCreateEditParameter();
            cp.Entity = iCommonWithId;
            return cp;
        }
    }
}