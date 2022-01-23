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
using Saas.Entities.Models;
using Saas.Entities.Models.UserClaims;

namespace Saas.DataAccess.EntityFrameWorkCore.DbContexts;

public class GordionDbContext :DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer(connectionString: @"Server =.; Database =ScheduleProject ; User Id =sa ; Password =kutukola ; trusted_connection=true;");
        /*
         *Connection
           Asp.net
           "Data Source=SQL5109.site4now.net;Initial Catalog=db_a7f4a9_dbadmin;User Id=db_a7f4a9_dbadmin_admin;Password=kutukola231090"
            
           Klasik asp
           "Provider=SQLOLEDB;Data Source=SQL5109.site4now.net;Initial Catalog=;User Id=db_a7f4a9_dbadmin_admin;Password=kutukola231090"


        @"Server =.; Database =FirstStep ; User Id =sa ; Password =kutukola ; trusted_connection=true;"
         */
        optionsBuilder.UseSqlServer(
            connectionString:
            @"Server =SQL5109.site4now.net; Database =db_a7f4a9_dbadmin; User Id =db_a7f4a9_dbadmin_admin; Password =kutukola231090 ;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //fluentApi
        #region Company

        //modelBuilder.Entity<Company>().Property(x => x.TaxNumber).HasMaxLength(11).IsRequired();
        //modelBuilder.Entity<Company>().Property(x => x.Deleted).HasDefaultValue(0);
        //modelBuilder.Entity<Company>().Property(x => x.FullName).IsRequired();

        #endregion


        #region CompanyUser 

        ////modelBuilder.Entity<CompanyUser>().Property(x => x.CompanyId).IsRequired();
        ////modelBuilder.Entity<CompanyUser>().Property(x => x.Email).IsRequired();
        //modelBuilder.Entity<CompanyUser>().Property(x => x.PassWordHash).IsRequired();
        //modelBuilder.Entity<CompanyUser>().Property(x => x.PassWordSalt).IsRequired();



        //modelBuilder.Entity<CompanyUserBranches>().Property(x => x.IsAdmin).HasDefaultValue(0);
        #endregion

        #region CompanyBranch 

        //modelBuilder.Entity<CompanyBranch>().Property(x => x.CompanyId).IsRequired();
        //modelBuilder.Entity<CompanyBranch>().Property(x => x.Deleted).HasDefaultValue(0);
        //modelBuilder.Entity<CompanyBranch>().Property(x => x.FullName).IsRequired();

        #endregion


        #region Roles

        //modelBuilder.Entity<CompanyOperationClaim>().Property(x => x.Name).IsRequired();

        //modelBuilder.Entity<CompanyOperationUserClaim>().Property(x => x.CompanyUserId).IsRequired();
        //modelBuilder.Entity<CompanyOperationUserClaim>().Property(x => x.CompanyOperationClaimId).IsRequired();


        #endregion
       

    }

    #region Company-User-Branch

    public DbSet<Company> Company { get; set; }

    public DbSet<CompanyUser> CompanyUser { get; set; }

    public DbSet<CompanyBranch> CompanyBranch { get; set; }

    public DbSet<CompanyUserBranches> CompanyUserBranches { get; set; }

    #endregion

    #region Roles

    public DbSet<CompanyOperationClaim> CompanyOperationClaim { get; set; }

    public DbSet<CompanyOperationUserClaim> CompanyOperationUserClaim { get; set; }

    #endregion

    public DbSet<Logs> Logs { get; set; }
}