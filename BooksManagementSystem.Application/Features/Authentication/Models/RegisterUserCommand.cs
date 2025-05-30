﻿using BooksManagementSystem.Application.Features.Authentication.Responses;
using BooksManagementSystem.Application.ResponseBase;
using MediatR;

namespace BooksManagementSystem.Application.Features.Authentication.Models
{
    public class RegisterUserCommand : IRequest<Response<JwtAuthResponse>>
    {
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
