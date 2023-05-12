using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oo_sample.fruitshop
{
    public class FruitShopApp
    {
        //private
        private bool isRunning = true;

        //methods
        public FruitShopApp()
        {
            //add all stock to Supermarket collection
            
            InventoryItem item2 = new InventoryItem() { SKU="BGLO"  };//0.49    Bagel Onion
            InventoryItem item3 = new InventoryItem() { SKU="BGLP"  };//0.39    Bagel Plain
            InventoryItem item4 = new InventoryItem() { SKU="BGLE"  };//0.49    Bagel Everything
            InventoryItem item5 = new InventoryItem() { SKU="BGLS"  };//0.49    Bagel Sesame
            InventoryItem item6 = new InventoryItem() { SKU="COFB"  };//0.99    Coffee Black
            InventoryItem item7 = new InventoryItem() { SKU="COFW"  };//1.19    Coffee White
            InventoryItem item8 = new InventoryItem() { SKU="COFC"  };//1.29    Coffee Capuccino
            InventoryItem item9 = new InventoryItem() { SKU="COFL"  };//1.29    Coffee Latte
            InventoryItem item10 = new InventoryItem() { SKU="FILB" };// 0.12    Filling Bacon
            InventoryItem item11 = new InventoryItem() { SKU="FILE" };// 0.12    Filling Egg
            InventoryItem item12 = new InventoryItem() { SKU="FILC" };// 0.12    Filling Cheese
            InventoryItem item13 = new InventoryItem() { SKU="FILX" };// 0.12    Filling Cream Cheese
            InventoryItem item14 = new InventoryItem() { SKU="FILS" };// 0.12    Filling Smoked Salmon
            InventoryItem item15 = new InventoryItem() { SKU = "FILH" };//   0.12    Filling Ham

            
            this.Supermaket.Add(item2);
            this.Supermaket.Add(item3);
            this.Supermaket.Add(item4);
            this.Supermaket.Add(item5);
            this.Supermaket.Add(item6);


        }

        public void Start()
        {
            while(isRunning)
            {
                Console.Clear();
                SeeMenu();
                OutputBasket();

                Console.WriteLine("Enter SKU or q to quit...");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        //delete item
                        DeleteAnItem();
                        break;
                    case "q":
                        isRunning = false;
                        break;
                    default:
                        
                        if(ValidateSku(choice))
                        {
                            InventoryItem item = this.Supermaket.Where(x => x.SKU == choice).FirstOrDefault();
                            if (item != null)
                            {
                                this.Basket.Add(item);
                            }
                            else
                            {

                            }
                        }
                        else
                        {

                        }
                        break;
                }





            }
        }

        private void OutputBasket()
        {
            if(this.Basket.Count==0)
            {
                Console.WriteLine("basket is empty!");
            }
            else
            {

            Console.WriteLine("---------basket---------");
            foreach(InventoryItem item in this.Basket)
            {
                Console.WriteLine(item.SKU);
            }
            Console.WriteLine("-------------------------");
            }
        }

        private bool ValidateSku(string choice)
        {
            return this.Supermaket.Where(x => x.SKU == choice).ToList().Count > 0 ? true : false;
        }


        private void DeleteAnItem()
        {
            throw new NotImplementedException();
        }
        private void SeeMenu()
        {
            foreach (InventoryItem item in this.Supermaket)
            {
                Console.WriteLine(item.SKU);
            }

            Console.WriteLine("1 for delete an item from basket");

        }


        //properties
        private List<InventoryItem> Basket = new List<InventoryItem>();
        private List<InventoryItem> Supermaket = new List<InventoryItem>();

       

    }
}


