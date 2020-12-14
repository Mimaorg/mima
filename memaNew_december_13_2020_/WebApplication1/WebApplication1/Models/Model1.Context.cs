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
    
    public partial class Mima_Finance_Entities : DbContext
    {
        public Mima_Finance_Entities()
            : base("name=Mima_Finance_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Bank_Details> Bank_Details { get; set; }
        public virtual DbSet<bankPaymentVoucher> bankPaymentVouchers { get; set; }
        public virtual DbSet<bankPaymentVoucher_OLD> bankPaymentVoucher_OLD { get; set; }
        public virtual DbSet<BankReceiptVoucher> BankReceiptVouchers { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<Billing_OLD> Billing_OLD { get; set; }
        public virtual DbSet<Billing_UnVerified> Billing_UnVerified { get; set; }
        public virtual DbSet<Calendar> Calendars { get; set; }
        public virtual DbSet<cashPaymentVoucher> cashPaymentVouchers { get; set; }
        public virtual DbSet<cashPaymentVoucher_OLD> cashPaymentVoucher_OLD { get; set; }
        public virtual DbSet<CashReceiptVoucher> CashReceiptVouchers { get; set; }
        public virtual DbSet<Control_Details> Control_Details { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Paid_to_Details> Paid_to_Details { get; set; }
        public virtual DbSet<Payable> Payables { get; set; }
        public virtual DbSet<Recievable> Recievables { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
    
        public virtual int AddBanks(string banks)
        {
            var banksParameter = banks != null ?
                new ObjectParameter("Banks", banks) :
                new ObjectParameter("Banks", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddBanks", banksParameter);
        }
    
        public virtual ObjectResult<Bank_Payment_Details_Result> Bank_Payment_Details(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Bank_Payment_Details_Result>("Bank_Payment_Details", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Bank_Payment_Details_Chart_Result> Bank_Payment_Details_Chart(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Bank_Payment_Details_Chart_Result>("Bank_Payment_Details_Chart", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Cash_Payment_Details_Result> Cash_Payment_Details(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Cash_Payment_Details_Result>("Cash_Payment_Details", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Controller_Volum_Chart_Result> Controller_Volum_Chart(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Controller_Volum_Chart_Result>("Controller_Volum_Chart", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CountOfBilling(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CountOfBilling", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        [DbFunction("Mima_Finance_Entities", "fn_ParseString")]
        public virtual IQueryable<string> fn_ParseString(string cSVString, string delimiter)
        {
            var cSVStringParameter = cSVString != null ?
                new ObjectParameter("CSVString", cSVString) :
                new ObjectParameter("CSVString", typeof(string));
    
            var delimiterParameter = delimiter != null ?
                new ObjectParameter("Delimiter", delimiter) :
                new ObjectParameter("Delimiter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<string>("[Mima_Finance_Entities].[fn_ParseString](@CSVString, @Delimiter)", cSVStringParameter, delimiterParameter);
        }
    
        public virtual int sp_AddBanks(string banks)
        {
            var banksParameter = banks != null ?
                new ObjectParameter("Banks", banks) :
                new ObjectParameter("Banks", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddBanks", banksParameter);
        }
    
        public virtual int sp_Cancel(Nullable<int> id, string tableName)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var tableNameParameter = tableName != null ?
                new ObjectParameter("tableName", tableName) :
                new ObjectParameter("tableName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Cancel", idParameter, tableNameParameter);
        }
    
        public virtual ObjectResult<sp_Mima_Finance__Category_Result> sp_Mima_Finance__Category()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Mima_Finance__Category_Result>("sp_Mima_Finance__Category");
        }
    
        public virtual ObjectResult<sp_PendingRecord_Result> sp_PendingRecord()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_PendingRecord_Result>("sp_PendingRecord");
        }
    
        public virtual int sp_pendingToSubmit(Nullable<int> id, string tableName)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var tableNameParameter = tableName != null ?
                new ObjectParameter("tableName", tableName) :
                new ObjectParameter("tableName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_pendingToSubmit", idParameter, tableNameParameter);
        }
    
        public virtual int spPopulateDateDimension()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spPopulateDateDimension");
        }
    
        public virtual ObjectResult<Nullable<long>> SumOfAmountBilling(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("SumOfAmountBilling", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Total_Bank_Details_Result> Total_Bank_Details(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Total_Bank_Details_Result>("Total_Bank_Details", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Total_Bank_Pending_Details_Result> Total_Bank_Pending_Details(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Total_Bank_Pending_Details_Result>("Total_Bank_Pending_Details", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Total_Bank_Pending_Units(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Total_Bank_Pending_Units", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Total_Bank_Units(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Total_Bank_Units", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Nullable<long>> Total_Bank_Volume(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("Total_Bank_Volume", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Total_Cash_Details_Result> Total_Cash_Details(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Total_Cash_Details_Result>("Total_Cash_Details", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Total_Cash_Pending_Details_Result> Total_Cash_Pending_Details(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Total_Cash_Pending_Details_Result>("Total_Cash_Pending_Details", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Total_Cash_Pending_Units(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Total_Cash_Pending_Units", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Total_Cash_Units(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Total_Cash_Units", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual ObjectResult<Nullable<long>> Total_Cash_Volume(Nullable<System.DateTime> s_Date, Nullable<System.DateTime> e_Date, Nullable<bool> isPending)
        {
            var s_DateParameter = s_Date.HasValue ?
                new ObjectParameter("S_Date", s_Date) :
                new ObjectParameter("S_Date", typeof(System.DateTime));
    
            var e_DateParameter = e_Date.HasValue ?
                new ObjectParameter("E_Date", e_Date) :
                new ObjectParameter("E_Date", typeof(System.DateTime));
    
            var isPendingParameter = isPending.HasValue ?
                new ObjectParameter("isPending", isPending) :
                new ObjectParameter("isPending", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("Total_Cash_Volume", s_DateParameter, e_DateParameter, isPendingParameter);
        }
    
        public virtual int Usp_DataEntry()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_DataEntry");
        }
    }
}
