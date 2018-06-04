﻿using ModelsClassLibrary.ModelsNS.UploadedFileNS;
using System.Collections.Generic;
using System.IO;

namespace ModelsClassLibrary.ModelsNS.DocumentsNS.FilesDocsNS
{
    //We will only use 
    public partial class FileDoc
    {
        public virtual ICollection<UploadedFile> MiscFiles { get; set; }

        //[NotMapped]
        //public string UserName { get; set; }
        /// <summary>
        /// Do not allow change of userName because users FileDoc images will be loaded in the user name.
        /// </summary>
        string IHasUploads.MiscFilesLocation()
        {
            return Path.Combine(AliKuli.ConstantsNS.MyConstants.SAVE_ROOT_DIRECTORY, "FileDoc", User.UserName);
        }




        public string MiscFilesLocation_Initialization()
        {
            return Path.Combine(AliKuli.ConstantsNS.MyConstants.SAVE_INITIALIZATION_DIRECTORY, ClassNameRaw, User.UserName);
        }
    }
}