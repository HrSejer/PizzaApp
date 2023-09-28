using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaApp
{

    public partial class MainWindow : Window
    {

        private CustomizationOption customizationOption;
        //private decimal SucukPris;
        private Dictionary<string, decimal> pizzaPrices = new Dictionary<string, decimal>
        {
                 { "Margherita Pizza - tomatsauce og ost 55,-", 55 },
                 { "Pepperoni Pizza – tomatsauce, ost og pepperoni 45,-", 45 },
                 { "Hawaiian Pizza - tomatsauce, ost, skinke og ananas 70,-", 70 },
                 { "Skinke Pizza – tomatsauce, ost og skinke 50,-", 50 },
                 { "Meat Lovers Pizza - Chilisauce, ost, pepperoni, kebab, pølser, bacon 95,-", 95 },
                 { "Bearnaise Pizza – Tomatsauce, ost, pepperoni, kebab og bearnaisesovs 80,-", 80 },
                 { "Pommesfritte Pizza - Tomatsauce, ost, kødfars, pommes, chili, dressing 84,-", 84 },
                 { "31A - Chefens special sandwich Med kebab, ost, salat, pommes frites, creme fraiche og hjemmelavet røddressing (anbefales med chili og hvidløg) 64,-", 64},
                 { "Viking Pizza – tomatsauce, ost, skinke, bacon og cocktailpølser 85,-", 85 },
                 { "Sucuk Pizza – tomatsauce, ost, kebab, sucuk, jalapenos og løg 85,-", 85 }


        };
        private Dictionary<string, decimal> drinkPrices = new Dictionary<string, decimal>
        {
                 { "Coca Cola Dåse 33cl 15,-", 15 },
                 { "Pepsi Max Dåse 33cl 15,-", 15},
                 { "Faxe Kondi Dåse 33cl 15,-", 15 },
                 { "Cocio 500ml 25,-", 25 },
                 { "Vand 500ml 10,-", 10 },
                 { "Lille Pommesfritter 35,-", 35 },
                 { "Stor Pommesfritter 45,-", 45 },
                 { "Snackkurv 5stk. løgringer, 3stk. hotwings, 3stk. mozzarellasticks, 3stk. chili cheese tops, 3stk. nuggets, salsa 78,-", 78 }
        };
        public MainWindow()
        {
            InitializeComponent();
            InitializePizzaListBoxItems();
            InitializeDrinkListBoxItems();
            customizationOption = new CustomizationOption();
            //SucukPris = 5;
        }

        private void InitializePizzaListBoxItems()
        {
            var pizzaItems = new List<string>
            {
                "Margherita Pizza - tomatsauce og ost 55,-",
                "Pepperoni Pizza – tomatsauce, ost og pepperoni 45,-",
                "Hawaiian Pizza - tomatsauce, ost, skinke og ananas 70,-",
                "Skinke Pizza – tomatsauce, ost og skinke 50,-",
                "Meat Lovers Pizza - Chilisauce, ost, pepperoni, kebab, pølser, bacon 95,-",
                "Bearnaise Pizza – Tomatsauce, ost, pepperoni, kebab og bearnaisesovs 80,-",
                "Pommesfritte Pizza - Tomatsauce, ost, kødfars, pommes, chili, dressing 84,-",
                "31A - Chefens special sandwich Med kebab, ost, salat, pommes frites, creme fraiche og hjemmelavet røddressing (anbefales med chili og hvidløg) 64,-",
                "Viking Pizza – tomatsauce, ost, skinke, bacon og cocktailpølser 85,-",
                "Sucuk Pizza – tomatsauce, ost, kebab, sucuk, jalapenos og løg 85,-"
            };

            foreach (var pizzaItem in pizzaItems)
            {
                pizzaListBox.Items.Add(new ListBoxItem { Content = pizzaItem });
            }
        }
        public List<OrderItem> GetOrderItems()
        {
            return orderItems;
        }

        private void InitializeDrinkListBoxItems()
        {
            var drinkItems = new List<string>
            {
                "Coca Cola Dåse 33cl 15,-",
                "Pepsi Max Dåse 33cl 15,-",
                "Faxe Kondi Dåse 33cl 15,-",
                "Cocio 500ml 25,-",
                "Vand 500ml 10,-",
                "Lille Pommesfritter - 35,-",
                "Stor Pommesfritter - 45,-",
                "Snackkurv 5stk. løgringer, 3stk. hotwings, 3stk. mozzarellasticks, 3stk. chili cheese tops, 3stk. nuggets, salsa 78,-"
            };

            foreach (var drinkItem in drinkItems)
            {
                drikListBox.Items.Add(new ListBoxItem { Content = drinkItem });
            }
        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
        public class OrderItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal PricePerItem { get; set; }
            public CustomizationOption CustomizationOption { get; set; }

           // public decimal customizationOption = 5;

        }

        
        private List<OrderItem> orderItems = new List<OrderItem>();


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal totalCost = CalculateTotalCost();

            if (pizzaListBox.SelectedItem != null)
            {
                string selectedPizza = ((ListBoxItem)pizzaListBox.SelectedItem).Content.ToString();

                
                if (pizzaPrices.ContainsKey(selectedPizza))
                {
                    decimal selectedPizzaPrice = pizzaPrices[selectedPizza];

                   
                    Customize customizeWindow = new Customize(selectedPizza, customizationOption, selectedPizzaPrice);
                    bool? result = customizeWindow.ShowDialog();

                    if (result == true)
                    {
                        
                        decimal totalCustomizationPrice = customizationOption.TotalCost;

                       
                        var existingItem = orderItems.FirstOrDefault(item => item.Name == selectedPizza && item.CustomizationOption.Equals(customizationOption));
                        if (existingItem != null)
                        {
                            
                            existingItem.Quantity++;
                        }
                        else
                        {
                            
                            orderItems.Add(new OrderItem { Name = selectedPizza, Quantity = 1, PricePerItem = selectedPizzaPrice, CustomizationOption = customizationOption });
                        }

                        
                        pizzaListBox.SelectedItem = null;
                        
                    }
                }
            }

            if (drikListBox.SelectedItem != null)
            {
                ListBoxItem selectedDrinkItem = (ListBoxItem)drikListBox.SelectedItem;
                string selectedItemText = selectedDrinkItem.Content.ToString();
                orderItems.Add(new OrderItem { Name = selectedItemText, Quantity = 1, PricePerItem = drinkPrices[selectedItemText] });

                
                drikListBox.SelectedItem = null;
            }

            
            UpdateOrderDisplay();
            //UpdateTotalCost(totalCost);
        }


        



       
        public void UpdateOrderDisplay()
        {
            StringBuilder orderText = new StringBuilder("Din bestilling:\n");
            foreach (var item in orderItems)
            {
                string customization = CustomizationToString(item.CustomizationOption);
                orderText.AppendLine($"{item.Name} x{item.Quantity} - {customization}");
            }
            orderTextBox.Text = orderText.ToString();
        }





        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            decimal totalCost = CalculateTotalCost();

            Bestilling bestillingsVindue = new Bestilling();
            bestillingsVindue.OrderItems = orderItems.Select(item => new OrderItem
            {
                Name = item.Name,
                Quantity = item.Quantity,
                PricePerItem = item.PricePerItem,
                CustomizationOption = item.CustomizationOption
            }).ToList(); 
            bestillingsVindue.TotalCost = totalCost;
            bestillingsVindue.ShowDialog();

        }




        public decimal CalculateTotalCost()
        {
            decimal totalCost = 0;
            decimal customizationPrice = CalculateCustomizationPrice(customizationOption);
            foreach (var item in orderItems)
            {
                
                
                totalCost += (item.PricePerItem * item.Quantity) + customizationPrice;
            }
            
            return totalCost;
        }


       public decimal CalculateCustomizationPrice(CustomizationOption customizationOption)
        {
            decimal customizationPrice = 0;

            if (customizationOption.Ost)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Sucuk)
            {
                customizationPrice += 5;
            }
           
            if (customizationOption.Poelser)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Pepperoni)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Salat)
            {
                customizationPrice += 5;
            }

            if (customizationOption.CremeFraicheDress)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Tomat)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Agurk)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Chili)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Hvidløg)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Skinke)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Ananas)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Bacon)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Kebab)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Bearnaisesovs)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Koedfars)
            {
                customizationPrice += 5;
            }

            if (customizationOption.PommesFrites)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Roeddressing)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Jalapenos)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Løg)
            {
                customizationPrice += 5;
            }

            if (customizationOption.Chilisauce)
            {
                customizationPrice += 5;
            }
            return customizationPrice;
          
       }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            orderItems.Clear();
            UpdateOrderDisplay();
            customizationOption = new CustomizationOption();
            customizationOption.Sucuk = false;
            totalCostTextBlock.Text = null;
        }
        public string CustomizationToString(CustomizationOption customization)
        {
            List<string> selectedOptions = new List<string>();
            if (customization != null)
            {

                if (customization.Ost)
                {
                    selectedOptions.Add("Ost");
                   
                }

                if (customization.Sucuk)
                {
                    selectedOptions.Add("Sucuk");
                }

                if (customization.Poelser)
                {
                    selectedOptions.Add("Poelser");
                }

                if (customization.Pepperoni)
                {
                    selectedOptions.Add("Pepperoni");
                }

                if (customization.Salat)
                {
                    selectedOptions.Add("Salat");
                }

                if (customization.CremeFraicheDress)
                {
                    selectedOptions.Add("CremeFraicheDress");
                }

                if (customization.Tomat)
                {
                    selectedOptions.Add("Tomat");
                }

                if (customization.Agurk)
                {
                    selectedOptions.Add("Agurk");
                }

                if (customization.Chili)
                {
                    selectedOptions.Add("Chili");
                }

                if (customization.Hvidløg)
                {
                    selectedOptions.Add("Hvidløg");
                }

                if (customization.Skinke)
                {
                    selectedOptions.Add("Skinke");
                }

                if (customization.Ananas)
                {
                    selectedOptions.Add("Ananas");
                }

                if (customization.Bacon)
                {
                    selectedOptions.Add("Bacon");
                }

                if (customization.Kebab)
                {
                    selectedOptions.Add("Kebab");
                }

                if (customization.Bearnaisesovs)
                {
                    selectedOptions.Add("Bearnaisesovs");
                }

                if (customization.Koedfars)
                {
                    selectedOptions.Add("Koedfars");
                }

                if (customization.PommesFrites)
                {
                    selectedOptions.Add("PommesFrites");
                }

                if (customization.Roeddressing)
                {
                    selectedOptions.Add("Roeddressing");
                }

                if (customization.Jalapenos)
                {
                    selectedOptions.Add("Jalapenos");
                }

                if (customization.Løg)
                {
                    selectedOptions.Add("Løg");
                }

                if (customization.Chilisauce)
                {
                    selectedOptions.Add("Chilisauce");
                }
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


    }
}

