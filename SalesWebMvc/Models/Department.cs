using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
   public class Department
   {
      public int Id { get; set; }

      [Required(ErrorMessage = "{0} of department required")]
      public string Name { get; set; }

      public ICollection<Seller> Seller { get; set; } = new List<Seller>();


      public Department() { }

      public Department(int id, string name)
      {
         Id = id;
         Name = name;
      }

      public void AddSeller(Seller seller)
      {
         Seller.Add(seller);
      }

      public double totalSales(DateTime initial, DateTime final)
      {
         return Seller.Sum(seller => seller.TotalSales(initial, final));
      }
   }
}
