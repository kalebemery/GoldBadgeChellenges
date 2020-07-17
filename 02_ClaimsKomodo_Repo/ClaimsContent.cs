using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsKomodo_Repo
{
    public enum ClaimsType
    {
        Car =1,
        Home,
        Theft
    }
    public class ClaimsContent
    {
        public int ClaimsID { get; set; }
        public ClaimsType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan claimDifference = DateOfClaim - DateOfIncident;
                double claimTimeDifference = claimDifference.TotalDays;
                if (claimTimeDifference < 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public ClaimsContent() { }


        public ClaimsContent(int claimsid, ClaimsType typeofclaim, string description, decimal claimamount,
        DateTime dateofincident, DateTime dateofclaim)
        {
            ClaimsID = claimsid;
            TypeOfClaim = typeofclaim;
            Description = description;
            ClaimAmount = claimamount;
            DateOfIncident = dateofincident;
            DateOfClaim = dateofclaim;


        }
        

    }
}
