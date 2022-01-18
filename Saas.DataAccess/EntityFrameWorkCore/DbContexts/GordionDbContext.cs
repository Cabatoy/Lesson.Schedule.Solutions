using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.EncryptColumn;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.EntityFrameworkCore;
using Saas.DataAccess.EntityFrameWorkCore.Models;
using Saas.DataAccess.EntityFrameWorkCore.Models.UserClaims;

namespace Saas.DataAccess.EntityFrameWorkCore.DbContexts;

public class GordionDbContext :DbContext
{
    //// private readonly IEncryptionProvider _provider;
    //public GordionDbContext()
    //{
    //    //Initialize.EncryptionKey = "cokAsiriGizliSifreFenaGizli";
    //    //_provider = new GenerateEncryptionProvider();
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        /*
         *Connection
           Asp.net
           "Data Source=SQL5109.site4now.net;Initial Catalog=db_a7f4a9_dbadmin;User Id=db_a7f4a9_dbadmin_admin;Password=kutukola2310"
            
           Klasik asp
           "Provider=SQLOLEDB;Data Source=SQL5109.site4now.net;Initial Catalog=;User Id=db_a7f4a9_dbadmin_admin;Password=kutukola2310"


        @"Server =.; Database =FirstStep ; User Id =sa ; Password =kutukola ; trusted_connection=true;"
         */
        optionsBuilder.UseSqlServer(
            connectionString:
            @"Server =SQL5109.site4now.net; Database =db_a7f4a9_dbadmin ; User Id =db_a7f4a9_dbadmin_admin ; Password =kutukola2310 ;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //fluentApi

        //modelBuilder.Entity<CompanyUser>()
        //    .Property(b => b.PassWordHash)
        //    .IsRequired();//required case
        // .IsRequired(false)//optinal case
        #region CompanyUser 
        //modelBuilder.Entity<CompanyUser>()
        //    .Property(b => b.PassWordHash)
        //    .IsRequired();//required case
        //modelBuilder.Entity<CompanyUser>()
        //    .Property(b => b.PassWordSalt)
        //    .IsRequired(); //required case;
        #endregion

        //modelBuilder.HasDefaultSchema("LessonSchedule");
        //    modelBuilder.UseEncryption(this._provider);
        //   base.OnModelCreating(modelBuilder);

    }


    public DbSet<Company> Company { get; set; }

    public DbSet<CompanyUser> CompanyUser { get; set; }
    public DbSet<CompanyOperationClaim> CompanyOperationClaim { get; set; }

    public DbSet<CompanyOperationUserClaim> CompanyOperationUserClaim { get; set; }

}