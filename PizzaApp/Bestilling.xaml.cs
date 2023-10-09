using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static PizzaApp.MainWindow;

namespace PizzaApp
{
    public partial class Bestilling : Window
    {
        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalCost { get; set; }

        public Bestilling()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateOrderDisplay();
            totalCostTextBlock1.Text = $"Total Pris: {TotalCost.ToString("C")}";
        }

        private void UpdateOrderDisplay()
        {
            StringBuilder orderText = new StringBuilder("Din bestilling:\n");

            foreach (var item in OrderItems)
            {
                string customization = CustomizationToString(item.CustomizationOption);
                orderText.AppendLine($"{item.Name} x{item.Quantity} ({item.PricePerItem.ToString("C")}) - {customization}");
            }

            orderTextBox1.Text = orderText.ToString();
        }

        private string CustomizationToString(CustomizationOption customization)
        {
            List<string> selectedOptions = new List<string>();

            if (customization != null)
            {
                // Loop through each customization option and add it to the selectedOptions list if it's true.
                if (customization.Ost) selectedOptions.Add("Ost");
                if (customization.Sucuk) selectedOptions.Add("Sucuk");
                if (customization.Poelser) selectedOptions.Add("Poelser");
                if (customization.Pepperoni) selectedOptions.Add("Pepperoni");
                if (customization.Salat) selectedOptions.Add("Salat");
                if (customization.CremeFraicheDress) selectedOptions.Add("CremeFraicheDress");
                if (customization.Tomat) selectedOptions.Add("Tomat");
                if (customization.Agurk) selectedOptions.Add("Agurk");
                if (customization.Chili) selectedOptions.Add("Chili");
                if (customization.Hvidløg) selectedOptions.Add("Hvidløg");
                if (customization.Skinke) selectedOptions.Add("Skinke");
                if (customization.Ananas) selectedOptions.Add("Ananas");
                if (customization.Bacon) selectedOptions.Add("Bacon");
                if (customization.Kebab) selectedOptions.Add("Kebab");
                if (customization.Bearnaisesovs) selectedOptions.Add("Bearnaisesovs");
                if (customization.Koedfars) selectedOptions.Add("Koedfars");
                if (customization.PommesFrites) selectedOptions.Add("PommesFrites");
                if (customization.Roeddressing) selectedOptions.Add("Roeddressing");
                if (customization.Jalapenos) selectedOptions.Add("Jalapenos");
                if (customization.Løg) selectedOptions.Add("Løg");
                if (customization.Chilisauce) selectedOptions.Add("Chilisauce");
               
            }

            if (selectedOptions.Count > 0)
            {
                return string.Join(", ", selectedOptions);
            }
            else
            {
                return "Ingen ændring";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
