using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<Car> Cars { get; set; }


    }
}
