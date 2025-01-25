using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LMS.Application.Common.Entities;

namespace LMS.BooksRecordService.API.Entities
{
    public class Book : SqlEntity
    {
        // Essential Fields
        public Book() { }

        public string Title { get; private set; } = string.Empty;
        public string Author { get; private set; } = string.Empty;
        public string ISBN { get; private set; } = string.Empty;
        public string Publisher { get; private set; } = string.Empty;
        public DateTime PublicationDate { get; private set; }
        public int AvailableCopies { get; private set; }
        public int NumberOfCopies { get; private set; }
        public string ShelfLocation { get; private set; } = string.Empty;
        public string Status { get; private set; } = string.Empty;

        // Constructor to Initialize Required Fields
        public Book(string title,string author,string isbn,string publisher,DateTime publicationDate,int availableCopies,int numberOfCopies,string shelfLocation,string status
        )
        {
            //BookId = bookId;
            Title = title;
            Author = author;
            ISBN = isbn;
            Publisher = publisher;
            PublicationDate = publicationDate;
            NumberOfCopies = numberOfCopies;
            AvailableCopies = numberOfCopies;
            ShelfLocation = shelfLocation;
            Status = "Available"; // Default status
        }

        public Book(string? title, string? author, string? iSBN, string? publisher, DateTime publicationDate, int numberOfCopies, string? shelfLocation)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Publisher = publisher;
            PublicationDate = publicationDate;
            NumberOfCopies = numberOfCopies;
            ShelfLocation = shelfLocation;
        }

        // Methods for Managing Book Records
        public void BorrowBook()
        {
            if (AvailableCopies > 0)
            {
                AvailableCopies--;
                UpdateStatus();
            }
            else
            {
                throw new InvalidOperationException("No available copies to borrow.");
            }
        }

        public void ReturnBook()
        {
            if (AvailableCopies < NumberOfCopies)
            {
                AvailableCopies++;
                UpdateStatus();
            }
            else
            {
                throw new InvalidOperationException("All copies are already in the library.");
            }
        }

        public void UpdateShelfLocation(string newLocation)
        {
            ShelfLocation = newLocation;
        }

        public void UpdateStatus()
        {
            Status = AvailableCopies > 0 ? "Available" : "Borrowed";
        }

        // Method to update book details (used during upsert)
        public void UpdateBookDetails(
            string title,
            string author,
            string isbn,
            string publisher,
            DateTime publicationDate,
            int availableCopies,
            int numberOfCopies,
            string shelfLocation,
            string status
        )
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Publisher = publisher;
            PublicationDate = publicationDate;
            AvailableCopies = availableCopies;
            NumberOfCopies = numberOfCopies;
            ShelfLocation = shelfLocation;
            Status = status;

            UpdateStatus();
            UpdateShelfLocation("");
        }
    }
}
