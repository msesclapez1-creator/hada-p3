using System;
using System.Collections.Generic;

namespace library
{
    public class ENCategory
    {
        private int _id;
        private string _name;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        public ENCategory()
        {
        }

        public ENCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public List<ENCategory> ReadAll()
        {
            CADCategory cad = new CADCategory();
            return cad.ReadAll();
        }

        public bool Read()
        {
            CADCategory cad = new CADCategory();
            return cad.Read(this);
        }
    }
}