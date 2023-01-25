using System.CodeDom.Compiler;
using VTT.Models;

namespace VTT.Models
{
    public class JournalEntry
    {
        // ---|*|ATTRIBIUTES|*|---
        
        protected int id;
        protected string type;
        protected string name;
        private string title;
        private string description = "";




        // ---|*|PROPERTIES|*|---

        public int Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }



        // ---|*|CONSTRUCTORS|*|---  

        public JournalEntry(int Id, string Type, string Name){
            this.id = Id;
            this.type = Type;
            this.name = Name;
            this.title = Name;        
        }
    }
}

