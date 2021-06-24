using JobAPI.Models.CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Data.Interfaces
{
    public interface ICompanyData
    {
        //Companies
        List<Company> Companies();

        Company GetCompany(int Id);

        Company AddCompany(Company company);

        Company EditCompany(Company company);

        void DeleteCompany(Company company);


        //CompanyBranches
        List<CompanyBranch> CompanyBranches();

        Company GetCompanyBranch(int Id);

        Company AddCompanyBranch(CompanyBranch companyBranch);

        Company EditCompanyBranch(CompanyBranch companyBranch);

        void DeleteCompanyBranch(CompanyBranch companyBranch);

        //ContactData
        List<CompanyContactData> CompanyContacts();

        Company GetCompanyContactData(int Id);

        Company AddCompanyContactData(CompanyContactData companyContactData);

        Company EditCompanyContactData(CompanyContactData companyContactData);

        void DeleteCompanyContactData(CompanyContactData companyContactData);

        //History
        List<CompanyHistory> CompanyHistory();

        Company GetCompanyHistoryPoint(int Id);

        Company AddCompanyHistory(CompanyHistory companyHistory);

        Company EditCompanyHistory(CompanyHistory companyHistory);

        void DeleteCompanyHistory(CompanyHistory companyHistory);
    }
}
