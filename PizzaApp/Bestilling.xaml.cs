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
using static PizzaApp.MainWindow;



namespace PizzaApp
{
    public partial class Bestilling : Window
    {
        public string CustomizationText { get; set; }

        public string Customization {get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public decimal TotalCost { get; set; }

        
        public Bestilling()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            StringBuilder orderText = new StringBuilder("Din bestilling:\n");

            foreach (var item in OrderItems)
            {
                
                orderText.AppendLine($"{item.Name} x{item.Quantity} ({item.PricePerItem.ToString("C")})");
            }

            orderTextBox1.Text = orderText.ToString();

            totalCostTextBlock1.Text = $"Total Pris: {TotalCost.ToString("C")}";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}




