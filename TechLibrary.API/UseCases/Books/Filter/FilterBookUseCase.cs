
using TechLibrary.API.Infraestrutura.DataAccess;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;

namespace TechLibrary.API.UseCases.Books.Filter
{
    public class FilterBookUseCase
    {
        public ResponseBooksJson Execute(RequestFilterBooksJson request)
        {
            var dbContext = new TechLibraryDbContext();

            var books = dbContext
                .Books
                .OrderBy(book =>book.Title)
                .ToList();

            return new ResponseBooksJson 
            {
                Books = books.Select(book => new ResponseBookJson
                {
                    ID = book.ID,
                    Title = book.Title,
                    Author = book.Author,
                }).ToList()
            
            };

        }
    }
}
