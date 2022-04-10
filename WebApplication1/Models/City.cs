using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models {
    public class City {
        private int id;
        private string name;
        private int population;
        public int Id { get => id; set => id = value; }
       
        public string Name { get => name; set => name = value; }
  
        public int Population { get => population; set => population = value; }
  

        public City() {
     
    }

    }
}
