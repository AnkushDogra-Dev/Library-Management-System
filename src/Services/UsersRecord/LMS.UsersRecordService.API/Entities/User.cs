using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.UsersRecordService.API.Entities
{
    public class User
    {
        // Basic Information
        public Guid UserId { get; private set; }
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
        public User(
            Guid userId,
            string fullName,
            string emailAddress,
            string membershipType,
            string libraryCardNumber,
            DateTime registrationDate
        )
        {
            UserId = userId;
            FullName = fullName;
            EmailAddress = emailAddress;
            MembershipType = membershipType;
            LibraryCardNumber = libraryCardNumber;
            RegistrationDate = registrationDate;

            AccountStatus = "Active"; // Default status
            IssuedBooksCount = 0; // Default value
            OverdueFineBalance = 0.0m; // Default value
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
