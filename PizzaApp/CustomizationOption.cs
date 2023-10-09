using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp
{
    public class CustomizationOption
    {

        public decimal CustomizationCost { get; set; } = 0;
        public List<string> SelectedOptions { get; set; } = new List<string>();
        public decimal TotalCost { get; set; }

        public bool Ost { get; set; }
        public decimal OstPris { get; set; } = 5;
        public bool Sucuk { get; set; }
        public decimal SucukPris { get; set; } = 5;
        public bool Poelser { get; set; }
        public decimal PoelserPris { get; set; } = 5;
        public bool Pepperoni { get; set; }
        public decimal PepperoniPris { get; set; } = 5;
        public bool Salat { get; set; }
        public decimal SalatPris { get; set; } = 5;
        public bool CremeFraicheDress { get; set; }
        public decimal CremeFraicheDressPris { get; set; } = 5;
        public bool Tomat { get; set; }
        public decimal TomatPris { get; set; } = 5;
        public bool Agurk { get; set; }
        public decimal AgurkPris { get; set; } = 5;
        public bool Chili { get; set; }
        public decimal ChiliPris { get; set; } = 5;
        public bool Hvidløg { get; set; }
        public decimal HvidløgPris { get; set; } = 5;
        public bool Skinke { get; set; }
        public decimal SkinkePris { get; set; } = 5;
        public bool Ananas { get; set; }
        public decimal AnanasPris { get; set; } = 5;
        public bool Bacon { get; set; }
        public decimal BaconPris { get; set; } = 5;
        public bool Kebab { get; set; }
        public decimal KebabPris { get; set; } = 5;
        public bool Bearnaisesovs { get; set; }
        public decimal BearnaisesovsPris { get; set; } = 5;
        public bool Koedfars { get; set; }
        public decimal KoedfarsPris { get; set; } = 5;
        public bool PommesFrites { get; set; }
        public decimal PommesFritesPris { get; set; } = 5;
        public bool Roeddressing { get; set; }
        public decimal RoeddressingPris { get; set; } = 5;
        public bool Jalapenos { get; set; }
        public decimal JalapenosPris { get; set; } = 5;
        public bool Løg { get; set; }
        public decimal LoegPris { get; set; } = 5;
        public bool Chilisauce { get; set; }
        public decimal ChilisaucePris { get; set; } = 5;
        public decimal TotalPrice { get; set; }
    }
}



