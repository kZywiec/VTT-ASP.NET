using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace VTT.Models.Entities
{
    public class JournalEntry : EntityBase
    {
        // ---|*|ATTRIBIUTES|*|---
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;
        private string type;
        private string name;
        private string title;
        private string description = "";



        // ---|*|PROPERTIES|*|---

        ///<summary> 
        ///Database Identifier. 
        ///</summary>
        [HiddenInput]
        public int Id { get => id; set => id = value; }

        ///<summary> 
        ///Helps to manage notes. 
        ///</summary>
        public string Type { get => type; set => type = value; }

        ///<summary> 
        ///Note header. 
        ///</summary>
        public string Title { get => title; set => title = value; }

        ///<summary> 
        ///It stores a content of the note. 
        ///</summary>
        public string Description { get => description; set => description = value; }



        // ---|*|CONSTRUCTORS|*|---  

        public JournalEntry(int Id, string Type, string Name)
        {
            id = Id;
            type = Type;
            name = Name;
            title = Name;
        }
    }
}

