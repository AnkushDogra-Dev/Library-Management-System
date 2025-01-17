using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.BooksRecordService.API.Entities
{
    public class Book
    {
        // Essential Fields
        public Guid BookId { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public string Publisher { get; private set; }
        public DateTime PublicationDate { get; private set; }
        public int AvailableCopies { get; private set; }
        public int NumberOfCopies { get; private set; }
        public string ShelfLocation { get; private set; }
        public string Status { get; private set; }

        // Constructor to Initialize Required Fields
        public Book(
            string bookId,
            string title,
            string author,
            string isbn,
            string publisher,
            DateTime publicationDate,
            int numberOfCopies,
            string shelfLocation
        )
        {
            BookId = bookId;
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
    
    }
}