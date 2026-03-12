using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
        // Atributos privados
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        // Propiedades públicas
        public string Code { get => _code; set => _code = value; }
        public string Name { get => _name; set => _name = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public float Price { get => _price; set => _price = value; }
        public int Category { get => _category; set => _category = value; }
        public DateTime CreationDate { get => _creationDate; set => _creationDate = value; }

        // Constructor por defecto
        public ENProduct()
        {
        }

        // Constructor con parámetros
        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            Code = code;
            Name = name;
            Amount = amount;
            Price = price;
            Category = category;
            CreationDate = creationDate;
        }

        // Los métodos Create, Update, Delete, etc. los añadiremos después
        // de hacer la clase CADProduct.

        // --- MÉTODOS DE CONEXIÓN CON CAD ---

        public bool Create()
        {
            CADProduct cad = new CADProduct();
            return cad.Create(this); // "this" le pasa este mismo producto al CAD
        }

        public bool Update()
        {
            CADProduct cad = new CADProduct();
            return cad.Update(this);
        }

        public bool Delete()
        {
            CADProduct cad = new CADProduct();
            return cad.Delete(this);
        }

        public bool Read()
        {
            CADProduct cad = new CADProduct();
            return cad.Read(this);
        }

        public bool ReadFirst()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadFirst(this);
        }

        public bool ReadNext()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadNext(this);
        }

        public bool ReadPrev()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadPrev(this);
        }
    }
}