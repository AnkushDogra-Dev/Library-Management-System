using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LMS.Application.Common.Entities;

namespace LMS.BorrowersRecord.API.Entities
{
    public class Borrower : SqlEntity
    {
        public string FullName { get; private set; }

        // Contact Information
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private set; }

        // Account Details
        public string MembershipType { get; private set; } // e.g., "Student", "Regular Member"
        public string AccountStatus { get; private set; } // e.g., "Active", "Inactive"

        // Library-Specific Information
        public string LibraryCardNumber { get; private set; }
        public int IssuedBooksCount { get; private set; }
        public decimal OverdueFineBalance { get; private set; } // Assuming fines are monetary

        // Administrative Details
        public DateTime RegistrationDate { get; private set; }

        // Constructor to initialize necessary fields
        public Borrower(string fullName, string emailAddress, string phoneNumber, string membershipType, string libraryCardNumber, DateTime registrationDate
        )
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            MembershipType = membershipType;
            LibraryCardNumber = libraryCardNumber;
            RegistrationDate = registrationDate;
            AccountStatus = "Active";
            IssuedBooksCount = 0;
            OverdueFineBalance = 0.0m;
        }

        // Public methods to modify fields when necessary
        public void UpdatePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void UpdateAccountStatus(string status)
        {
            AccountStatus = status;
        }

        public void IncrementIssuedBooksCount()
        {
            IssuedBooksCount++;
        }

        public void DecrementIssuedBooksCount()
        {
            if (IssuedBooksCount > 0)
                IssuedBooksCount--;
        }

        public void AddFine(decimal fineAmount)
        {
            OverdueFineBalance += fineAmount;
        }

        public void ClearFine()
        {
            OverdueFineBalance = 0.0m;
        }
    }
}
