﻿using AliKuli.Extentions;
using ErrorHandlerLibrary.ExceptionsNS;
using InterfacesLibrary.SharedNS;
using InterfacesLibrary.SharedNS.FeaturesNS;
using ModelsClassLibrary.ModelsNS.ProductNS;
using ModelsClassLibrary.ModelsNS.SharedNS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UowLibrary.Abstract;
using UowLibrary.Interface;

namespace UowLibrary
{
    /// <summary>
    /// This is where all the Fix, bussiness Rules and ErrorChecks are implemented
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract partial class BusinessLayer<TEntity> : AbstractBiz, IBusinessLayer<TEntity> where TEntity : class, ICommonWithId
    {


        //#region Create

        //public virtual void CreateSimple(ControllerCreateEditParameter parm)
        //{
        //    createEngineSimple(parm);
        //}

        //private void create(TEntity entity)
        //{
        //    Dal.Create(entity);
        //}

        ////public virtual void Create(ControllerCreateEditParameter parm)
        ////{
        ////    createEngineWithFileUpload(parm);
        ////}
        ////public virtual void Create(TEntity entity, HttpPostedFileBase[] files)
        ////{
        ////    createEngineWithFileUpload(entity, files);
        ////}



        ////-----------------------------------------------------------------------------------------

        ////public virtual void CreateAndSaveNoFileUpload(ControllerCreateEditParameter parm)
        ////{
        ////    createEngineSimple(parm);
        ////    SaveChanges();
        ////}

        ///// <summary>
        ///// This creates and saves for initialization only. It AUTOMATICLY looks for an image in the initialization folder and loads it, 
        ///// provided the image name is the same as the name of the product, without spaces.
        ///// </summary>
        ///// <param name="entity"></param>
        //public virtual void CreateSave_ForInitializeOnly(TEntity entity)
        //{
        //    try
        //    {
        //        Event_DoSpecialInitializationStuff(entity);
        //        entity.MetaData.IsEditLocked = Event_LockEditDuringInitialization();
        //        CreateAndSave(CreateControllerCreateEditParameter(entity as ICommonWithId));
        //    }
        //    catch (NoDuplicateException)
        //    {

        //        ErrorsGlobal.AddMessage(string.Format("Item '{0}' is already initialized.", entity.Name));
        //    }
        //    catch (Exception e)
        //    {
        //        ErrorsGlobal.Add("Error while creating entity", MethodBase.GetCurrentMethod(), e);

        //    }
        //}

        //public virtual void CreateAndSave(TEntity entity)
        //{
        //    ControllerCreateEditParameter parm = new ControllerCreateEditParameter();
        //    parm.Entity = entity;
        //    CreateAndSave(parm);
        //    //SaveChanges();
        //}

        //public virtual void CreateAndSave(ControllerCreateEditParameter parm)
        //{
        //    createEngineWithFileUpload(parm);
        //    SaveChanges();
        //}


        ////public virtual async Task CreateAndSaveAsync(TEntity entity)
        ////{
        ////    createEngineSimple(entity);
        ////    await SaveChangesAsync();
        ////}
        //public virtual async Task CreateAndSaveAsync(ControllerCreateEditParameter parm)
        //{
        //    createEngineWithFileUpload(parm);
        //    await SaveChangesAsync();
        //}



        ////-----------------------------------------------------------------------------------------






        //private void createEngineWithFileUpload(ControllerCreateEditParameter parm)
        //{
        //    //this was removed because it shows up twice... it is also in CreateEngineSimple
        //    //fixEntityAndBussinessRulesAndErrorCheck_Helper(parm);
        //    //handleRelatedFilesIfExist(parm);
        //    createEngineSimple(parm);
        //}

        //private void createEngineSimple(ControllerCreateEditParameter parm)
        //{
        //    //entity.IsCreating = true;
        //    fixEntityAndBussinessRulesAndErrorCheck_Helper(parm);
        //    handleRelatedFilesIfExist(parm);

        //    CreateEntity(parm.Entity as TEntity);
        //    ClearSelectListInCache(SelectListCacheKey);
        //}

        ///// <summary>
        ///// This needs to be overridden for the Product VM. Here we will change the Entity. This will be overridden in each individual
        ///// ProductVm
        ///// </summary>
        ///// <param name="entity"></param>
        //public virtual void CreateEntity(TEntity entity)
        //{
        //    //FixChildEntityForCreate(entity);
        //    create(entity);
        //}


        //private void fixEntityAndBussinessRulesAndErrorCheck_Helper(ControllerCreateEditParameter parm)
        //{
        //    Fix(parm);
        //    BusinessRulesFor(parm);
        //    ErrorCheck(parm);
        //}

        //public virtual void ErrorCheck(ControllerCreateEditParameter parm)
        //{

        //}

        //#endregion

        //#region Update

        //public void UpdateAndSave(TEntity entity)
        //{
        //    ControllerCreateEditParameter param = new ControllerCreateEditParameter();
        //    param.Entity = entity as ICommonWithId;
        //    UpdateAndSave(param);
        //}

        //public void UpdateAndSave(ControllerCreateEditParameter param)
        //{
        //    updateEngine(param);
        //    SaveChanges();

        //}



        //public async Task UpdateAndSaveAsync(ControllerCreateEditParameter parm)
        //{
        //    updateEngine(parm);
        //    await SaveChangesAsync();

        //}

        //private void updateEngine(ControllerCreateEditParameter parm)
        //{
        //    //parm.Entity.IsUpdating = true;
        //    fixEntityAndBussinessRulesAndErrorCheck_Helper(parm);
        //    handleRelatedFilesIfExist(parm);

        //    Product productTest = parm.Entity as Product;
        //    AddParentChildCode(parm);
        //    Update(parm.Entity as TEntity);
        //    ClearSelectListInCache(SelectListCacheKey);

        //}

        //public virtual void AddParentChildCode(ControllerCreateEditParameter parm)
        //{

        //}

        ///// <summary>
        ///// This will need to be updated in each individual Product VM
        ///// </summary>
        ///// <param name="parm"></param>
        //public virtual void Update(TEntity entity)
        //{

        //    Dal.Update(entity);
        //}




        //#endregion

        //#region Delete

        //public virtual bool Delete(string id)
        //{
        //    try
        //    {
        //        Dal.Delete(id);
        //        ErrorsGlobal.AddMessage(string.Format("*** Deleted ***"));
        //        ClearSelectListInCache(SelectListCacheKey);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        ErrorsGlobal.AddMessage(string.Format("*** NOT Deleted ***"));
        //        ErrorsGlobal.Add(string.Format("Unable to find the {0} record", typeof(TEntity).Name.ToUpper()), MethodBase.GetCurrentMethod(), e);
        //    }
        //    return false;
        //}

        //string _nameOfItemBeingDeleted;
        /////// <summary>
        /////// This stores the Entity name for onward use while deleting.
        /////// </summary>
        ////public string NameOfItemBeingDeleted
        ////{
        ////    get
        ////    {
        ////        if (_nameOfItemBeingDeleted.IsNullOrWhiteSpace())
        ////        {
        ////            ErrorsGlobal.Add("Entity Name is null", MethodBase.GetCurrentMethod());
        ////            throw new Exception(ErrorsGlobal.ToString());
        ////        }
        ////        return _nameOfItemBeingDeleted;
        ////    }
        ////}
        //public virtual bool DeleteAndSave(string id)
        //{
        //    try
        //    {
        //        Delete(id);
        //        SaveChanges();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        ErrorsGlobal.AddMessage(string.Format("*** NOT Deleted ***"));
        //        ErrorsGlobal.Add(string.Format("Unable to find the {0} record", typeof(TEntity).Name.ToUpper()), MethodBase.GetCurrentMethod(), e);
        //    }
        //    return false;
        //}

        ////public virtual bool DeleteActually(string id)
        ////{
        ////    TEntity entity = Dal.FindFor(id);
        ////    try
        ////    {
        ////        if (entity.IsNull())
        ////        {
        ////            ErrorsGlobal.Add(string.Format("Unable to find the {0} record", typeof(TEntity).Name.ToUpper()), "Delete");
        ////            ErrorsGlobal.AddMessage(string.Format("*** NOT Deleted ***"));
        ////            return false;
        ////        }
        ////        _nameOfItemBeingDeleted = entity.Name; //NameOfItemBeingDeleted is updated here
        ////        Dal.DeleteActually(entity);
        ////        Dal.SaveChanges();
        ////        ErrorsGlobal.AddMessage(string.Format("*** Deleted '{0}' ***", entity.Name));
        ////        ClearSelectListInCache(SelectListCacheKey);
        ////        return true;
        ////    }
        ////    catch (Exception e)
        ////    {

        ////        ErrorsGlobal.AddMessage(string.Format("*** NOT Deleted '{0}' ***", entity.Name));
        ////        ErrorsGlobal.Add(string.Format("Unable to find the {0} record", typeof(TEntity).Name.ToUpper()), MethodBase.GetCurrentMethod(), e);
        ////    }
        ////    return false;
        ////}
        //public virtual async Task<bool> DeleteAsync(string id)
        //{
        //    TEntity entity = await Dal.FindForAsync(id);
        //    try
        //    {
        //        if (entity.IsNull())
        //        {

        //            ErrorsGlobal.Add(string.Format("Unable to find the record"), "Delete");
        //            ErrorsGlobal.AddMessage(string.Format("*** NOT Deleted ***"));
        //            return false;
        //        }
        //        _nameOfItemBeingDeleted = entity.Name; //NameOfItemBeingDeleted is updated here
        //        Dal.Delete(id);
        //        await SaveChangesAsync();
        //        ErrorsGlobal.AddMessage(string.Format("*** Deleted '{0}' ***", entity.Name));
        //        ClearSelectListInCache(SelectListCacheKey);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        ErrorsGlobal.AddMessage(string.Format("*** NOT Deleted '{0}' ***", entity.Name));
        //        ErrorsGlobal.Add(string.Format("Unable to find the {0} record", typeof(TEntity).Name.ToUpper()), MethodBase.GetCurrentMethod(), e);
        //    }
        //    return false;
        //}



        ///// <summary>
        ///// This automatically deletes all related records for IHasUploads. 
        ///// It also removes the uploaded files themselves.
        ///// </summary>
        ///// <param name="entity"></param>
        //private void deleteRelatedRecordsForIHasUploadsAndSave(ICommonWithId entity)
        //{
        //    IHasUploads ihasuploads = entity as IHasUploads;

        //    if (!continueProcessing(ihasuploads))
        //        return;

        //    List<string> lstUploadIdsToDelete = new List<string>();

        //    //delete the actual files 
        //    deletePhysicalUploadedFiles(ihasuploads, lstUploadIdsToDelete);


        //    //now delete the upload records
        //    deleteRelatedUploadRecords(lstUploadIdsToDelete);
        //    //this just clears the navigation.
        //    ihasuploads.MiscFiles.Clear();

        //    Dal.SaveChanges();



        //}

        ///// <summary>
        ///// This deletes the uploaded Records.
        ///// </summary>
        ///// <param name="lstUploadIdsToDelete"></param>
        //private void deleteRelatedUploadRecords(List<string> lstUploadIdsToDelete)
        //{
        //    if (lstUploadIdsToDelete.IsNullOrEmpty())
        //        return;

        //    foreach (var id in lstUploadIdsToDelete)
        //    {
        //        UploadedFileBiz.DeleteActuallyAndSave(id);

        //    }
        //}

        ///// <summary>
        ///// This deletes the physically uploaded files.
        ///// </summary>
        ///// <param name="ihasuploads"></param>
        ///// <param name="lstUploadIdsToDelete"></param>
        //private static void deletePhysicalUploadedFiles(IHasUploads ihasuploads, List<string> lstUploadIdsToDelete)
        //{
        //    foreach (var upload in ihasuploads.MiscFiles)
        //    {
        //        //delete the file
        //        File.Delete(upload.AbsolutePathWithFileName());

        //        //save the id to delete later.
        //        lstUploadIdsToDelete.Add(upload.Id);

        //    }

        //}

        ///// <summary>
        ///// Checks to see if it is worth continuing
        ///// </summary>
        ///// <param name="ihasuploads"></param>
        ///// <returns></returns>
        //private bool continueProcessing(IHasUploads ihasuploads)
        //{

        //    if (ihasuploads.IsNull())
        //        return false;

        //    if (ihasuploads.MiscFiles.IsNullOrEmpty())
        //        return false;
        //    return true;
        //}

        //public virtual void EVENT_DeleteRelatedRecordsActually(ICommonWithId entity)
        //{
        //}



        //#endregion

        //#region DeleteActually

        //public async Task DeleteActuallyAndSaveAsync(TEntity entity)
        //{
        //    deleteActuallyEngine(entity);
        //    await SaveChangesAsync();
        //}

        //public void DeleteActuallyAndSave(TEntity entity)
        //{
        //    deleteActuallyEngine(entity);
        //    SaveChanges();
        //}

        ////------------------------------------------------------


        //public void DeleteActuallyAndSave(string id)
        //{
        //    id.IsNullThrowException("Id is blank");
        //    TEntity entity = Find(id);
        //    entity.IsNullThrowException("No entity found!");
        //    DeleteActuallyAndSave(entity);
        //}

        //public async Task DeleteActuallyAndSaveAsync(string id)
        //{
        //    id.IsNullThrowException("Id is blank");
        //    TEntity entity = await FindAsync(id);
        //    entity.IsNullThrowException("No entity found!");
        //    await DeleteActuallyAndSaveAsync(entity);
        //}

        ////------------------------------------------------------



        //public virtual void DeleteActuallyAllAndSave()
        //{
        //    var lst = Dal.FindAll().ToList();
        //    deleteActuallyAll(lst);
        //    SaveChanges();
        //}

        //public virtual async Task DeleteActuallyAllAndSaveAsync()
        //{
        //    var lst = await Dal.FindAll().ToListAsync();
        //    deleteActuallyAll(lst);
        //    await SaveChangesAsync();
        //}

        ////------------------------------------------------------






        //private void deleteActuallyAll(List<TEntity> lst)
        //{
        //    if (lst.IsNullOrEmpty())
        //        return;

        //    foreach (var entity in lst)
        //    {
        //        deleteActuallyEngine(entity);
        //    }
        //}


        //private void deleteActuallyEngine(TEntity entity)
        //{
        //    entity.IsNullThrowException("Argument Exception.");
        //    deleteRelatedRecordsForIHasUploadsAndSave(entity);
        //    EVENT_DeleteRelatedRecordsActually(entity);
        //    Dal.DeleteActually(entity);
        //}


        //#endregion

        //#region Find

        //public TEntity Find(string id)
        //{
        //    return Dal.FindFor(id) as TEntity;
        //}
        //public async Task<TEntity> FindAsync(string id)
        //{
        //    return (await Dal.FindForAsync(id)) as TEntity;
        //}

        //public IQueryable<TEntity> FindAll(bool deleted = false)
        //{
        //    return Dal.FindAll(deleted) as IQueryable<TEntity>;
        //}
        //public IQueryable<TEntity> FindAllNoTracking(bool deleted = false)
        //{
        //    return Dal.FindAllNoTracking(deleted) as IQueryable<TEntity>;
        //}


        //public async Task<List<TEntity>> FindAllAsync()
        //{
        //    return await Dal.FindAllAsync();
        //}
        //public TEntity FindByName(string name)
        //{
        //    return Dal.FindForName(name);

        //}
        //#endregion

        //#region Save

        //public virtual int SaveChanges()
        //{


        //    try
        //    {
        //        return Dal.SaveChanges();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        ErrorsGlobal.Add("DbEntityValidationException. Data not saved.", MethodBase.GetCurrentMethod(), e);

        //    }

        //    catch (NotSupportedException e)
        //    {

        //        ErrorsGlobal.Add("NotSupportedException. Data not saved.", MethodBase.GetCurrentMethod(), e);
        //    }


        //    catch (ObjectDisposedException e)
        //    {

        //        ErrorsGlobal.Add("ObjectDisposedException. Data not saved.", MethodBase.GetCurrentMethod(), e);

        //    }

        //    catch (InvalidOperationException e)
        //    {
        //        ErrorsGlobal.Add("InvalidOperationException. Data not saved.", MethodBase.GetCurrentMethod(), e);
        //    }

        //    catch (DbUpdateConcurrencyException e)
        //    {
        //        ErrorsGlobal.Add("DbUpdateConcurrencyException. Data not saved.", MethodBase.GetCurrentMethod(), e);
        //    }

        //    catch (DbUpdateException e)
        //    {
        //        ErrorsGlobal.Add("DbUpdateException. Data not saved.", MethodBase.GetCurrentMethod(), e);
        //    }

        //    catch (EntityException e)
        //    {
        //        ErrorsGlobal.Add("EntityException. Data not saved.", MethodBase.GetCurrentMethod(), e);
        //    }

        //    catch (DataException e)
        //    {
        //        ErrorsGlobal.Add("DataException. Data not saved.", MethodBase.GetCurrentMethod(), e);
        //    }

        //    catch (Exception e)
        //    {
        //        ErrorsGlobal.Add("Exception. Data not saved.", MethodBase.GetCurrentMethod(), e);

        //    }
        //    throw new Exception("Data not saved.");
        //}
        //public virtual async Task<int> SaveChangesAsync()
        //{

        //    try
        //    {
        //        return await Dal.SaveChangesAsync();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        ErrorsGlobal.Add("DbEntityValidationException. Data not saved.", MethodBase.GetCurrentMethod(), e);

        //    }

        //    catch (NotSupportedException e)
        //    {

        //        ErrorsGlobal.Add("NotSupportedException. Data not saved.", MethodBase.GetCurrentMethod(), e);
        //    }


        //    catch (ObjectDisposedException e)
        //    {

        //        ErrorsGlobal.Add("ObjectDisposedException. Data not saved.", MethodBase.GetCurrentMethod(), e);

        //    }

        //    catch (InvalidOperationException e)
        //    {
        //        ErrorsGlobal.Add("InvalidOperationException. Data not saved.", MethodBase.GetCurrentMethod(), e);
        //    }

        //    catch (DbUpdateConcurrencyException e)
        //    {
        //        ErrorsGlobal.Add("DbUpdateConcurrencyException. Data not saved.", MethodBase.GetCurrentMethod(), e);
        //    }

        //    catch (DbUpdateException e)
        //    {
        //        ErrorsGlobal.Add("DbUpdateException. Data not saved.", MethodBase.GetCurrentMethod(), e);
        //    }

        //    catch (EntityException e)
        //    {
        //        ErrorsGlobal.Add("EntityException. Data not saved.", MethodBase.GetCurrentMethod(), e);
        //    }

        //    catch (DataException e)
        //    {
        //        ErrorsGlobal.Add("DataException. Data not saved.", MethodBase.GetCurrentMethod(), e);
        //    }

        //    catch (Exception e)
        //    {
        //        ErrorsGlobal.Add("Exception. Data not saved.", MethodBase.GetCurrentMethod(), e);

        //    }
        //    throw new Exception("Data not saved.");

        //}


        //#endregion


    }
}
