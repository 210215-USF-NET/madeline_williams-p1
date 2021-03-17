﻿
using System.ComponentModel.DataAnnotations;
namespace ArtModel
{
    public class Artist : IArtist, IUser 
    {
        private string countryCode = "";
        private int id;
        string name = "";
        string biography = "";
        public int Id { get { return id; } set { id = value; } }
        [Required]
        public string Name { get { return name; } set { name = value; } }
        public string Biography { get { return biography; } set { biography = value; } }
        public string ArtistStatement { get; set; }
        public string Location { get; set; }
        public string Signature { get; set; }
        [Url]
        public string ArtistPhoto { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string CountryCode
        {
            get
            {
                return countryCode;
            }
            set
            {
                countryCode = value;
            }
        }
        public override string ToString()
        {
            string s = $"Artist:\nId={Id}\nname={name}\nbiography{biography}=";

            return s;
        }
    }
}
