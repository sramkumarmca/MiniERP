﻿namespace Spitfire.Web.Users.Update
{
    using System.ComponentModel.DataAnnotations;
    using MediatR;

    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public string OriginalName { get; set; }

        [Required]
        public string Name { get; set; }
    }
}