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
        private CustomizationOption customizationOption;

        public Customize(string selectedPizza, CustomizationOption customizationOption, decimal pizzaBasePrice)
        {
            InitializeComponent();
            DataContext = this;
            CustomizationOption = customizationOption;
            this.customizationOption = customizationOption;

        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string option = checkBox.Content.ToString();

            if (!checkedOptions.Contains(option))
            {
                checkedOptions.Add(option);
                UpdateCustomizationPrice();
                UpdateCustomizationOption();
            }


        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string option = checkBox.Content.ToString();

            if (checkedOptions.Contains(option))
            {
                checkedOptions.Remove(option);
                UpdateCustomizationPrice();
                UpdateCustomizationOption();
            }
        }

        private void UpdateCustomizationOption()
        {
            // Update the customization options and calculate the total customization cost
            customizationOption.Ost = OstCheckBox.IsChecked ?? false;
            customizationOption.Sucuk = SucukCheckBox.IsChecked ?? false;
            // ... Add similar lines for other toppings

            // Calculate the customization cost and update the TotalCost property
            
        }
        private void UpdateCustomizationPrice()
        {
            decimal customizationPrice = 0;
            foreach (var option in checkedOptions)
            {
                if (customizationPrices.ContainsKey(option))
                {
                    customizationPrice += customizationPrices[option];
                }
            }

            CustomizationOption.TotalCost = customizationPrice;
        }


        private Dictionary<string, decimal> customizationPrices = new Dictionary<string, decimal>
        {
          { "Ost", 5 },
          { "Sucuk", 5 },
          { "Poelser", 5 },
          { "Pepperoni", 5 },
          { "Salat", 5 },
          { "CremeFraicheDress", 5 },
          { "Tomat", 5 },
          { "Agurk", 5 },
          { "Chili", 5 },
          { "Hvidløg", 5 },
          { "Skinke", 5 },
          { "Ananas", 5 },
          { "Bacon", 5 },
          { "Kebab", 5 },
          { "Bearnaisesovs", 5 },
          { "Koedfars", 5 },
          { "PommesFrites", 5 },
          { "Roeddressing", 5 },
          { "Jalapenos", 5 },
          { "Løg", 5 },
          { "Chilisauce", 5 }
        };

        private HashSet<string> checkedOptions = new HashSet<string>(); 
        private decimal GetCustomizationPrice(string option)
        {
            
            var customizationPrices = new Dictionary<string, decimal>
            {
                { "Ost", 5 },
                { "Sucuk", 5 },
                { "Poelser", 5 },
                { "Pepperoni", 5 },
                { "Poelser", 5 },
                { "Salat", 5 },
                { "CremeFraicheDress", 5 },
                { "Tomat", 5 },
                { "Agurk", 5 },
                { "Chili", 5 },
                { "Hvidløg", 5 },
                { "Skinke", 5 },
                { "Ananas", 5 },
                { "Bacon", 5 },
                { "Kebab", 5 },
                { "Bearnaisesovs", 5 },
                { "Koedfars", 5 },
                { "PommesFrites", 5 },
                { "Roeddressing", 5 },
                { "Jalapenos", 5 },
                { "Løg", 5 },
                { "Chilisauce", 5 }

            };

            if (customizationPrices.TryGetValue(option, out decimal price))
            {
                return price;
            }

            
            return 0;
        }
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

       

            
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
