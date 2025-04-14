
using TechLibrary.API.Domain.Entities;
using TechLibrary.API.Infraestrutura.DataAccess;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using static System.Reflection.Metadata.BlobBuilder;

namespace TechLibrary.API.UseCases.Books.Filter
{
    public class FilterBookUseCase
    {
        private const int NunPaginations = 10;
        public ResponseBooksJson Execute(RequestFilterBooksJson request)
        {
            var dbContext = new TechLibraryDbContext();

            var skipPages = ((request.PageNumber - 1) * NunPaginations);


            var query = dbContext.Books.AsQueryable();

            if (string.IsNullOrWhiteSpace(request.Title) == false)
            {
                query = query.Where(book => book.Title.Contains(request.Title));

            }
            var books = query
                .OrderBy(book => book.Title).ThenBy(book => book.Author)
                .Skip(skipPages)
                .Take(NunPaginations)
                .ToList();

            var totalCount = 0;
            if (string.IsNullOrWhiteSpace(request.Title))
                totalCount = dbContext.Books.Count();
            else 
                totalCount = dbContext.Books.Count(book => book.Title.Contains(request.Title));


            return new ResponseBooksJson
            {
                Pagination = new ResponsePaginationJson
                {
                    PageNumber = request.PageNumber,
                    TotalCount = totalCount

                },
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
