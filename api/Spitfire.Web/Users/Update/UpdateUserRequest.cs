namespace Spitfire.Web.Users.Update
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MediatR;

    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Version { get; set; }

        public byte[] Timestamp
        {
            get { return Convert.FromBase64String(Version); }
        }
    }
}