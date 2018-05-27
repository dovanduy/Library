﻿using Microsoft.AspNet.Identity.EntityFramework;
using ModelsClassLibrary.MenuNS;
using ModelsClassLibrary.ModelsNS.DocumentsNS.FilesDocsNS;
using ModelsClassLibrary.ModelsNS.ProductNS;
using ModelsClassLibrary.ModelsNS.UploadedFileNS;
using System.Data.Entity;
using UserModels;

namespace ApplicationDbContextNS
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {



            base.OnModelCreating(modelBuilder);

            //This causes the uploads to be deleted along with the main file.
            //we need to delete the physical uploads seperately
            #region Uploads

            modelBuilder.Entity<ProductCategory1>()
                .HasMany<UploadedFile>(x => x.MiscFiles)
                .WithOptional(x => x.ProductCategory1)
                .HasForeignKey(x => x.ProductCategory1Id)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<ProductCategory2>()
                .HasMany<UploadedFile>(x => x.MiscFiles)
                .WithOptional(x => x.ProductCategory2)
                .HasForeignKey(x => x.ProductCategory2Id)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<ProductCategory3>()
                .HasMany<UploadedFile>(x => x.MiscFiles)
                .WithOptional(x => x.ProductCategory3)
                .HasForeignKey(x => x.ProductCategory3Id)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<FileDoc>()
                .HasMany<UploadedFile>(x => x.MiscFiles)
                .WithOptional(x => x.FileDoc)
                .HasForeignKey(x => x.FileDocId)
                .WillCascadeOnDelete(true);

            //USER Images
            modelBuilder.Entity<ApplicationUser>()
                .HasMany<UploadedFile>(x => x.MiscFiles)
                .WithOptional(x => x.ApplicationUser)
                .HasForeignKey(x => x.ApplicationUserId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<UploadedFile>(x => x.SelfieUploads)
                .WithOptional(x => x.Selfie)
                .HasForeignKey(x => x.SelfieId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<ApplicationUser>()
                .HasMany<UploadedFile>(x => x.IdCardFrontUploads)
                .WithOptional(x => x.IdCardFrontUpload)
                .HasForeignKey(x => x.IdCardFrontUploadId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<UploadedFile>(x => x.IdCardBackUploads)
                .WithOptional(x => x.IdCardBackUpload)
                .HasForeignKey(x => x.IdCardBackUploadId)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<ApplicationUser>()
                .HasMany<UploadedFile>(x => x.PassportFrontUploads)
                .WithOptional(x => x.PassportFrontUpload)
                .HasForeignKey(x => x.PassportFrontUploadId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<ApplicationUser>()
                .HasMany<UploadedFile>(x => x.PassportVisaUploads)
                .WithOptional(x => x.PassportVisaUpload)
                .HasForeignKey(x => x.PassportVisaUploadId)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<ApplicationUser>()
                .HasMany<UploadedFile>(x => x.LiscenseFrontUploads)
                .WithOptional(x => x.LiscenseFrontUpload)
                .HasForeignKey(x => x.LiscenseFrontUploadId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<ApplicationUser>()
                .HasMany<UploadedFile>(x => x.LiscenseBackUploads)
                .WithOptional(x => x.LiscenseBackUpload)
                .HasForeignKey(x => x.LiscenseBackUploadId)
                .WillCascadeOnDelete(false);

            #endregion

            #region Product Categories

            modelBuilder.Entity<ProductCategory1>()
                .HasMany<ProductCategoryMain>(x => x.ProductCategoryMains)
                .WithOptional(x => x.ProductCat1)
                .HasForeignKey(x => x.ProductCat1Id)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<ProductCategory2>()
                .HasMany<ProductCategoryMain>(x => x.ProductCategoryMains)
                .WithOptional(x => x.ProductCat2)
                .HasForeignKey(x => x.ProductCat2Id)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<ProductCategory3>()
                .HasMany<ProductCategoryMain>(x => x.ProductCategoryMains)
                .WithOptional(x => x.ProductCat3)
                .HasForeignKey(x => x.ProductCat3Id)
                .WillCascadeOnDelete(false);


            #endregion

            //modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");


            //modelBuilder.Entity<User>()
            //    .HasKey(x => x.Id)
            //    .HasOptional(x => x.Address)
            //    .WithRequired(x => x.User)
            //    .WillCascadeOnDelete(true);

        }


    }
}