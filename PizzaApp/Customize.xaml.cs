using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PizzaApp
{
    
    public partial class Customize : Window
    {
        public CustomizationOption CustomizationOption { get; set; }
        public Customize(string selectedPizza, CustomizationOption customizationOption, decimal pizzaBasePrice)
        {
            InitializeComponent();
            DataContext = this;
            CustomizationOption = customizationOption;
            selectedPizzaBasePrice = pizzaBasePrice;
            
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string option = checkBox.Content.ToString();

            if (!CustomizationOption.SelectedOptions.Contains(option))
            {
                CustomizationOption.SelectedOptions.Add(option);
                CustomizationOption.TotalCost += 10; 
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string option = checkBox.Content.ToString();

            if (CustomizationOption.SelectedOptions.Contains(option))
            {
                CustomizationOption.SelectedOptions.Remove(option);
                CustomizationOption.TotalCost -= 10; 
            }
        }
        public decimal selectedPizzaBasePrice { get; set; }
        public decimal OstPris { get; set; } = 5;
        public decimal SucukPris { get; set; } = 5;
        public decimal PoelserPris { get; set; } = 5;
        public decimal PepperoniPris { get; set; } = 5;
        public decimal SalatPris { get; set; } = 5;
        public decimal CremeFraicheDressPris { get; set; } = 5;
        public decimal TomatPris { get; set; } = 5;
        public decimal AgurkPris { get; set; } = 5;
        public decimal ChiliPris { get; set; } = 5;
        public decimal HvidløgPris { get; set; } = 5;
        public decimal SkinkePris { get; set; } = 5;
        public decimal AnanasPris { get; set; } = 5;
        public decimal BaconPris { get; set; } = 5;
        public decimal KebabPris { get; set; } = 5;
        public decimal BearnaisesovsPris { get; set; } = 5;
        public decimal KoedfarsPris { get; set; } = 5;
        public decimal PommesFritesPris { get; set; } = 5;
        public decimal RoeddressingPris { get; set; } = 5;
        public decimal JalapenosPris { get; set; } = 5;
        public decimal LøgPris { get; set; } = 5;
        public decimal ChilisaucePris { get; set; } = 5;
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            decimal TotalPrice = selectedPizzaBasePrice;

            decimal customizationPrice = CalculateCustomizationPrice(CustomizationOption);
            TotalPrice += customizationPrice;

            CustomizationOption.TotalPrice = TotalPrice;

            DialogResult = true; 
            Close();
        }

        private decimal CalculateCustomizationPrice(CustomizationOption customizationOption)
        {
            decimal customizationPrice = 0;

            
            if (customizationOption.Sucuk)
            {
                customizationPrice += SucukPris; 
            }

            if (customizationOption.Poelser)
            {
                customizationPrice += PoelserPris; 
            }

            

            return customizationPrice;
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; 
            Close();
        }
    }
}
