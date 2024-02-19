using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace DataGridViewCheckBoxApp1.Models;

    public class Author
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; } 
    }

    public class AuthorDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AuthorDto ConvertAuthorToAuthorDto(Author author)
        {
            AuthorDto authorDto = new()
            {
                Id = author.Id.ToString(),
                FirstName = author.FirstName,
                LastName = author.LastName
            };
            return authorDto;
        }
    }

