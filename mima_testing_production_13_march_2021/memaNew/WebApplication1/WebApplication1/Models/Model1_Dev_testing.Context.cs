﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Testing_Mima_Finance_DevEntities : DbContext
    {
        public Testing_Mima_Finance_DevEntities()
            : base("name=Testing_Mima_Finance_DevEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cheque> Cheques { get; set; }
        public virtual DbSet<Control> Controls { get; set; }
        public virtual DbSet<Fact> Facts { get; set; }
        public virtual DbSet<Org> Orgs { get; set; }
        public virtual DbSet<Paid_To> Paid_To { get; set; }
        public virtual DbSet<Transaction_Type> Transaction_Type { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
    
        public virtual int Debit_Credit_Logic()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Debit_Credit_Logic");
        }
    
        [DbFunction("Testing_Mima_Finance_DevEntities", "fn_ParseString")]
        public virtual IQueryable<string> fn_ParseString(string cSVString, string delimiter)
        {
            var cSVStringParameter = cSVString != null ?
                new ObjectParameter("CSVString", cSVString) :
                new ObjectParameter("CSVString", typeof(string));
    
            var delimiterParameter = delimiter != null ?
                new ObjectParameter("Delimiter", delimiter) :
                new ObjectParameter("Delimiter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<string>("[Testing_Mima_Finance_DevEntities].[fn_ParseString](@CSVString, @Delimiter)", cSVStringParameter, delimiterParameter);
        }
    
        public virtual ObjectResult<sp_Mima_Finance_Dev_BankList_Result> sp_Mima_Finance_Dev_BankList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Mima_Finance_Dev_BankList_Result>("sp_Mima_Finance_Dev_BankList");
        }
    
        public virtual ObjectResult<sp_Mima_Finance_Dev_categoryBasedDropdown_Result> sp_Mima_Finance_Dev_categoryBasedDropdown(Nullable<int> categoryid)
        {
            var categoryidParameter = categoryid.HasValue ?
                new ObjectParameter("categoryid", categoryid) :
                new ObjectParameter("categoryid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Mima_Finance_Dev_categoryBasedDropdown_Result>("sp_Mima_Finance_Dev_categoryBasedDropdown", categoryidParameter);
        }
    
        public virtual ObjectResult<sp_Mima_Finance_Dev_categoryBasedDropdown_All_Result> sp_Mima_Finance_Dev_categoryBasedDropdown_All()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Mima_Finance_Dev_categoryBasedDropdown_All_Result>("sp_Mima_Finance_Dev_categoryBasedDropdown_All");
        }
    
        public virtual ObjectResult<Sp_Mima_Finance_Dev_SelectCategory_Result> Sp_Mima_Finance_Dev_SelectCategory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Sp_Mima_Finance_Dev_SelectCategory_Result>("Sp_Mima_Finance_Dev_SelectCategory");
        }
    
        public virtual ObjectResult<Usp_APGL_Result> Usp_APGL(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<int> contractor, Nullable<int> category)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var contractorParameter = contractor.HasValue ?
                new ObjectParameter("Contractor", contractor) :
                new ObjectParameter("Contractor", typeof(int));
    
            var categoryParameter = category.HasValue ?
                new ObjectParameter("Category", category) :
                new ObjectParameter("Category", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_APGL_Result>("Usp_APGL", s_DateParameter, e_DateParameter, contractorParameter, categoryParameter);
        }
    
        public virtual ObjectResult<Usp_APGL_Summary_Result> Usp_APGL_Summary(string contractor, string project, string category)
        {
            var contractorParameter = contractor != null ?
                new ObjectParameter("Contractor", contractor) :
                new ObjectParameter("Contractor", typeof(string));
    
            var projectParameter = project != null ?
                new ObjectParameter("Project", project) :
                new ObjectParameter("Project", typeof(string));
    
            var categoryParameter = category != null ?
                new ObjectParameter("Category", category) :
                new ObjectParameter("Category", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_APGL_Summary_Result>("Usp_APGL_Summary", contractorParameter, projectParameter, categoryParameter);
        }
    
        public virtual ObjectResult<Usp_BankGL_Result> Usp_BankGL(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<int> bankID, Nullable<int> category)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var bankIDParameter = bankID.HasValue ?
                new ObjectParameter("BankID", bankID) :
                new ObjectParameter("BankID", typeof(int));
    
            var categoryParameter = category.HasValue ?
                new ObjectParameter("Category", category) :
                new ObjectParameter("Category", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_BankGL_Result>("Usp_BankGL", s_DateParameter, e_DateParameter, bankIDParameter, categoryParameter);
        }
    
        public virtual ObjectResult<Usp_Get_Projects_Par_Result> Usp_Get_Projects_Par(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, string contractor)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var contractorParameter = contractor != null ?
                new ObjectParameter("Contractor", contractor) :
                new ObjectParameter("Contractor", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_Get_Projects_Par_Result>("Usp_Get_Projects_Par", s_DateParameter, e_DateParameter, contractorParameter);
        }
    
        public virtual ObjectResult<Usp_Get_Vendors_Par_Result> Usp_Get_Vendors_Par(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_Get_Vendors_Par_Result>("Usp_Get_Vendors_Par", s_DateParameter, e_DateParameter);
        }
    
        public virtual ObjectResult<Usp_Market_GL_Result> Usp_Market_GL(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, string contractor, string project, Nullable<int> category)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var contractorParameter = contractor != null ?
                new ObjectParameter("Contractor", contractor) :
                new ObjectParameter("Contractor", typeof(string));
    
            var projectParameter = project != null ?
                new ObjectParameter("Project", project) :
                new ObjectParameter("Project", typeof(string));
    
            var categoryParameter = category.HasValue ?
                new ObjectParameter("Category", category) :
                new ObjectParameter("Category", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_Market_GL_Result>("Usp_Market_GL", s_DateParameter, e_DateParameter, contractorParameter, projectParameter, categoryParameter);
        }
    
        public virtual ObjectResult<Usp_Market_Summary_Result> Usp_Market_Summary()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_Market_Summary_Result>("Usp_Market_Summary");
        }
    
        public virtual ObjectResult<Usp_Market_Summary_Drill1_Result> Usp_Market_Summary_Drill1(string vendor)
        {
            var vendorParameter = vendor != null ?
                new ObjectParameter("Vendor", vendor) :
                new ObjectParameter("Vendor", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_Market_Summary_Drill1_Result>("Usp_Market_Summary_Drill1", vendorParameter);
        }
    
        public virtual ObjectResult<Usp_Market_Summary_Drill2_Result> Usp_Market_Summary_Drill2(string vendor, string project)
        {
            var vendorParameter = vendor != null ?
                new ObjectParameter("Vendor", vendor) :
                new ObjectParameter("Vendor", typeof(string));
    
            var projectParameter = project != null ?
                new ObjectParameter("Project", project) :
                new ObjectParameter("Project", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_Market_Summary_Drill2_Result>("Usp_Market_Summary_Drill2", vendorParameter, projectParameter);
        }
    
        public virtual int Usp_Populate_Account()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_Populate_Account");
        }
    
        public virtual int Usp_Populate_Bank()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_Populate_Bank");
        }
    
        public virtual int Usp_Populate_Branch()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_Populate_Branch");
        }
    
        public virtual int Usp_Populate_Category()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_Populate_Category");
        }
    
        public virtual int Usp_Populate_Cheque()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_Populate_Cheque");
        }
    
        public virtual int Usp_Populate_Control()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_Populate_Control");
        }
    
        public virtual int Usp_Populate_Dev()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_Populate_Dev");
        }
    
        public virtual int Usp_Populate_Fact()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_Populate_Fact");
        }
    
        public virtual int Usp_Populate_Fact_OLD_Data()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_Populate_Fact_OLD_Data");
        }
    
        public virtual int Usp_Populate_Org()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_Populate_Org");
        }
    
        public virtual int Usp_Populate_Paid_To()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_Populate_Paid_To");
        }
    
        public virtual int Usp_Populate_Tables()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_Populate_Tables");
        }
    
        public virtual int Usp_Populate_Voucher()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_Populate_Voucher");
        }
    
        public virtual ObjectResult<Usp_Print_Grid_Result> Usp_Print_Grid(string contractor, string category)
        {
            var contractorParameter = contractor != null ?
                new ObjectParameter("Contractor", contractor) :
                new ObjectParameter("Contractor", typeof(string));
    
            var categoryParameter = category != null ?
                new ObjectParameter("Category", category) :
                new ObjectParameter("Category", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_Print_Grid_Result>("Usp_Print_Grid", contractorParameter, categoryParameter);
        }
    
        public virtual ObjectResult<Usp_Project_Cost_GL_Result> Usp_Project_Cost_GL()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_Project_Cost_GL_Result>("Usp_Project_Cost_GL");
        }
    
        public virtual ObjectResult<Usp_Project_Cost_GL_Drill1_Result> Usp_Project_Cost_GL_Drill1(string project)
        {
            var projectParameter = project != null ?
                new ObjectParameter("Project", project) :
                new ObjectParameter("Project", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_Project_Cost_GL_Drill1_Result>("Usp_Project_Cost_GL_Drill1", projectParameter);
        }
    
        public virtual ObjectResult<Usp_Project_Rev_GL_Result> Usp_Project_Rev_GL()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_Project_Rev_GL_Result>("Usp_Project_Rev_GL");
        }
    
        public virtual ObjectResult<Usp_Project_Rev_GL_Drill1_Result> Usp_Project_Rev_GL_Drill1(string project)
        {
            var projectParameter = project != null ?
                new ObjectParameter("Project", project) :
                new ObjectParameter("Project", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_Project_Rev_GL_Drill1_Result>("Usp_Project_Rev_GL_Drill1", projectParameter);
        }
    
        public virtual ObjectResult<Usp_ProjectGL_Result> Usp_ProjectGL(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<int> project, Nullable<int> category)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var projectParameter = project.HasValue ?
                new ObjectParameter("Project", project) :
                new ObjectParameter("Project", typeof(int));
    
            var categoryParameter = category.HasValue ?
                new ObjectParameter("Category", category) :
                new ObjectParameter("Category", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_ProjectGL_Result>("Usp_ProjectGL", s_DateParameter, e_DateParameter, projectParameter, categoryParameter);
        }
    }
}
