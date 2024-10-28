using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class Book (FullName FullName) : Entity
{
    public override string Name => FullName.ToString();

    //private string getName(string bookName, string author, string isbn)
    //{
    //    bookName = "NO_BOOK_TITLE";
    //    author = "NO_AUTHOR_ASSIGNED";  // Author could be unknown/anonymous
    //    isbn = "ISBN_NOT_ASSIGNED";
    //    return $"{bookName} by {author}, ISBN: {isbn}";
    //}
}
