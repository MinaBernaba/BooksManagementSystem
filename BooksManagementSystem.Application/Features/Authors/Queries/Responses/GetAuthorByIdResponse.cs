﻿namespace BooksManagementSystem.Application.Features.Authors.Queries.Responses
{
    public class GetAuthorByIdResponse
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public List<BooksOfAuthor> Books { get; set; } = null!;
    }
}
