using lovedmemory.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lovedmemory.application.DTOs
{

    public class AddMemorialInfoDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Biography { get; set; }
        public string? PersonalPhrase { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? Dod { get; set; }
        public string? Gender { get; set; }
        public string? MemorialName { get; set; }
        public CoverPhoto? CoverPhoto { get; set; }
        public bool? Privacy { get; set; }
        public string? NickName { get; set; }
        public DateTimeOffset? RunDate { get; set; }
        public bool? Published { get; set; }
        public string? Slug { get; set; }
        public string? MainImageUrl { get; set; }
        public string BirthCountry { get; set; }
        public string deathCountry { get; set; }

    }
}
