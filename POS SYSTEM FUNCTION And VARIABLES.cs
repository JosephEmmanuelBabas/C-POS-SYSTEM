namespace POSV2
{
     class FI
    {
        // CATEGORIES AND PRODUCTS
        public string[] Category = { "FRESH PRODUCE", "BAKERY", "DAIRIES", "MEAT-SEAFOOD","HOUSEHOLD ITEMS" };
        public string[,] Product = {
                                    {"BANANAS", "APPLES", "CARROTS", "BROCOLLI", "SPINACH" },
                                    { "WHEAT BREAD", "CROISSANT", "BAGELS", "CHOCOLATE MUFFINS", "SOURDOUGH" },
                                    { "WHOLE MILK", "CHEDDAR CHEESE", "YOGURT", "BUTTER", "EGG" },
                                    { "CHICKEN BREAST", "GROUND BEEF", "PORK CHOP", "SALMON FILLET", "RAW SHRIMP" },
                                    { "PAPER TOWEL", "LAUNDRY DETERGENT", "DISH SOAP", "TRASH BAG", "ALL PURPOSE CREAM"} 
                                    };
        public float[,] Price = { 
                                {48,25,57,68,114}, 
                                { 120, 96, 80, 37, 110 }, 
                                { 105, 128, 69, 186, 150 }, 
                                { 170, 230, 305, 200, 160 },  
                                {75, 95, 27, 58, 190 } 
                                };

        public int[,] Stocks = { 
                                {10, 10, 10, 10, 10 },
                                { 10, 10, 10, 10, 10 },
                                { 10, 10, 10, 10, 10 },
                                { 10, 10, 10, 10, 10 },
                                { 10, 10, 10, 10, 10 } 
                                };

        public int passwordPIN = 20050702;
        public string[] adcart = new string[20];
        public float[] padcart = new float[20];
        public int[] qtyadcart = new int[20];

        public int[] indexcart1 = new int[20];
        public int[] indexcart2 = new int[20];

        public string[] spsymbol = { "|", "STOCK", "PRICE", "", "", "", "", "", "", "" };

        // INPUT FUNCTIONS VALIDATORS
        public int passinput(int num)// ADMIN INPUT VALIDATOR
        {
            for (int i = 0; i < 3; i++)
            {
                num = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
                if (num != passwordPIN) { 
                    Console.Write($"INCORRECT PASSWORD you have {3 - (i + 1)} Tries \nENTER HERE:");
                    if (i == 2) num = 0;
                continue;
                }
                else if (num == passwordPIN) break;

            }
            return num;
        }


        public int cpinput(int num) // CATEGORY AND PRODUCT VALIDATOR
        {
            while (true) {
                num = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
                if (num <= 0 || num > 6) {Console.Write("INVALID INPUT.... Please Enter only 1 - 6: "); continue; }
            else if (num > 0 || num < 7) break;
            }
            return num;
        }

        public int optinput(int num) // OPTION INPUT VALIDATOR 
        {
            while (true)
            {
                num = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
                if (num <= 0 || num > 2) { Console.Write("INVALID INPUT.... Please Enter only 1 or 2: "); continue; }
                else if (num > 0 || num < 3) break;
            }
            return num;
        }

        public int input(int num)// QUANTITY AND MENU OPTION INPUT VALIDATOR
        {
            while (true)
            {
                num = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
                if (num <= 0 ) { Console.WriteLine("INVALID INPUT"); continue; }
                else if (num > 0) break;
            }
            return num;
        }

        public float input(float num,float finalprice)// CASH INPUT VALIDATOR
        {
            while (true)
            {
                num = float.TryParse(Console.ReadLine(), out float result) ? result : 0;
                if (num <= 0 || num < finalprice) { Console.Write($"INSUFFICIENT CASH AMOUNT ENTERED... PLEASE ENTER ATLEAST ₱{finalprice}\nENTER HERE:"); continue; }
                else if (num >= finalprice) break;
            }
            return num;
        }

        public int cancelinput(int num,int index)// CANCEL INPUT VALIDATOR
        {
            while (true)
            {
                num = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
                if (num <= 0 && num < index) { Console.Write($"INVALID INPUT PLEASE CHOOSE 1 - {index + 1}\nENTER HERE:"); continue; }
                else if (num >= 1 && num <=  index) break;
            }
            return num;
        }



        // DISPLAY FUNCTIONS

        public void Pdisplay() // DISPLAY MENU PRODUCTS WITH CATEGORY
        {
            Console.WriteLine($"\n========== MENU ============");
            for (int i = 0; i < 5; i++) 
            {
                Console.WriteLine("============================");
                Console.WriteLine("{0,-15}{1,11}", Category[i], spsymbol[2]);
                Console.WriteLine("============================");
                for (int j = 0; j < 5; j++)
                {
                Console.WriteLine("{0,-20} ₱{1,2}", Product[i, j], Price[i, j]);

                }
                Console.WriteLine($"\n");
            }
        }

        public void INVdisplay() // DISPLAY INVENTORY OF PRODUCT STOCKS
        {
            Console.WriteLine($"\n======== INVENTORY =========");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("============================");
                Console.WriteLine("{0,-15} {1,10}", Category[i], spsymbol[1]);
                Console.WriteLine("============================");
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine("{0,-20} {1,2} ", Product[i, j], Stocks[i, j]);
                }
                Console.WriteLine($"\n");
            }
        }


        public void Catdisplay()// DISPLAY CATEGORY IN ORDER FUNCTION
        {
            Console.WriteLine("CATEGORY ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i + 1}.{Category[i]}");
            }

        }

        public void Proddisplay(int pnum) // DISPLAY PRODUCTS IN ORDER FUNCTION
        {
            Console.WriteLine(Category[pnum - 1]);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i + 1}.{Product[pnum - 1,i]}");
            }
        }

        public void SPdisplay(int pnum,int cnum) // DISPLAY THE CURRENT ORDER 
        {
            Console.WriteLine("========== ORDER ==========");
            Console.WriteLine("{0,-20} ₱{1,2} ", Product[pnum - 1 ,cnum - 1],Price[pnum - 1, cnum - 1]);
            
        }

        public void SPdisplay(int pnum, int cnum,int qty) // DISPLAY THE PRICE AND QUANTITY OF ORDER PICKED
        {
            Console.WriteLine("========== CART ==========");
            Console.WriteLine("{0,-20}₱{1,0} ", Product[pnum - 1, cnum - 1], Price[pnum - 1, cnum - 1]);
            Console.WriteLine($"TOTAL AMOUNT:       ₱{Price[pnum - 1, cnum - 1] * qty}");
        }

        public void cartdisplay(int index, float finalpriceamt) // DISPLAY THE ADD TO CART PRODUCTS
        {

            Console.WriteLine("========== CART ==========");
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(i + 1 + ".{0,-20}  ₱{1,0} QTY:{2,1}", adcart[i], padcart[i], qtyadcart[i]);
            }
            Console.WriteLine($"TOTAL AMOUNT:           ₱{finalpriceamt}");
            Console.WriteLine("==========================");

        }

        public void cartdisplay(int index, float finalpriceamt,float change,float cash) // DISPLAY THE CHECK OUT ORDER AND SUCCESSFULY CHECK OUT
        {

            Console.WriteLine("======= OUT OF CART =======");
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(i + 1 + ".{0,-20}  ₱{1,0} QTY:{2,1}", adcart[i], padcart[i], qtyadcart[i]);
            }
            Console.WriteLine($"TOTAL AMOUNT:           ₱{finalpriceamt}");
            Console.WriteLine($"TOTAL CASH:             ₱{cash}");
            Console.WriteLine($"CHANGE:                 ₱{change}");
            Console.WriteLine("==========================");

        }

        // CALCULATION FUNCTIONS
        public float totalamt (int pnum, int cnum, int qty) // CALCULATE THE TOTAL AMOUNT OF ALL THE PRODUCT PICKED
        {
           float ttlamt = Price[pnum - 1, cnum - 1] * qty;
        return ttlamt;
        }

        public void stockupdater(int pnum, int cnum, int qty) // UPDATE THE INVENTORY STOCKS OF EVERY PRODUCT
        {
            Stocks[pnum - 1, cnum - 1] = Stocks[pnum - 1, cnum - 1] - qty;
        }

        // ADD TO CART FUNCTION
        public void addtocart(int pnum, int cnum, int qty,int index) // GET THE LIST OF PRODUCT TO ADD IN THE CART DISPLAY
        {
            adcart[index] = Product[pnum - 1, cnum - 1];
            padcart[index] = Price[pnum - 1, cnum - 1] * qty;
            qtyadcart[index] = qty;
            indexcart1[index] = pnum - 1;
            indexcart2[index] = cnum - 1;
        }

        public void checkout(int index) // RESET THE VALUE INSIDE OF THE CART DISPLAY
        {
            for (int i = 0; i < index; i++)
            {
                adcart[i] = "";
                padcart[i] = 0;
                qtyadcart[i] = 0;
                indexcart1[i] = 0;
                indexcart2[i] = 0;
            }
        }

        // CANCEL FUNCTION (VERSION 1) 
        public void cancel( int cancel,int index)
        {
            Stocks[indexcart1[cancel - 1], indexcart2[cancel - 1]] += qtyadcart[cancel - 1];

            Console.WriteLine(index);

            if (cancel - 1 == index - 1 )
            {
                adcart[cancel - 1] = "";
                padcart[cancel - 1] = 0;
                qtyadcart[cancel - 1] = 0;
                indexcart1[cancel - 1] = 0;
                indexcart2[cancel - 1] = 0;
                Console.WriteLine("CHECKER ... 1");
            }



            else if (cancel - 1 < index - 1 )
            {

                adcart[cancel - 1] = adcart[cancel];
                padcart[cancel - 1] = padcart[cancel];
                qtyadcart[cancel - 1] = qtyadcart[cancel];
                indexcart1[cancel - 1] = indexcart1[cancel];
                indexcart2[cancel - 1] = indexcart2[cancel];

                adcart[cancel] = adcart[cancel + 1];
                padcart[cancel] = padcart[cancel + 1];
                qtyadcart[cancel] = qtyadcart[cancel + 1];
                indexcart1[cancel] = indexcart1[cancel + 1];
                indexcart2[cancel] = indexcart2[cancel + 1];

                adcart[cancel + 1] = adcart[cancel + 2];
                padcart[cancel + 1] = padcart[cancel + 2];
                qtyadcart[cancel + 1] = qtyadcart[cancel + 2];
                indexcart1[cancel + 1] = indexcart1[cancel + 2];
                indexcart2[cancel + 1] = indexcart2[cancel + 2];

                adcart[cancel + 2] = adcart[cancel + 3];
                padcart[cancel + 2] = padcart[cancel + 3];
                qtyadcart[cancel + 2] = qtyadcart[cancel + 3];
                indexcart1[cancel + 2] = indexcart1[cancel + 3];
                indexcart2[cancel + 2] = indexcart2[cancel + 3];

                adcart[cancel + 3] = adcart[cancel + 4];
                padcart[cancel + 3] = padcart[cancel + 4];
                qtyadcart[cancel + 3] = qtyadcart[cancel + 4];
                indexcart1[cancel + 3] = indexcart1[cancel + 4];
                indexcart2[cancel + 3] = indexcart2[cancel + 4];

                adcart[cancel + 4] = adcart[cancel + 5];
                padcart[cancel + 4] = padcart[cancel + 5];
                qtyadcart[cancel + 4] = qtyadcart[cancel + 5];
                indexcart1[cancel + 4] = indexcart1[cancel + 5];
                indexcart2[cancel + 4] = indexcart2[cancel + 5];

                adcart[cancel + 5] = adcart[cancel + 6];
                padcart[cancel + 5] = padcart[cancel + 6];
                qtyadcart[cancel + 5] = qtyadcart[cancel + 6];
                indexcart1[cancel + 5] = indexcart1[cancel + 6];
                indexcart2[cancel + 5] = indexcart2[cancel + 6];


                adcart[cancel + 6] = adcart[cancel + 7];
                padcart[cancel + 6] = padcart[cancel + 7];
                qtyadcart[cancel + 6] = qtyadcart[cancel + 7];
                indexcart1[cancel + 6] = indexcart1[cancel + 7];
                indexcart2[cancel + 6] = indexcart2[cancel + 7];

                adcart[cancel + 7] = adcart[cancel + 8];
                padcart[cancel + 7] = padcart[cancel + 8];
                qtyadcart[cancel + 7] = qtyadcart[cancel + 8];
                indexcart1[cancel + 7] = indexcart1[cancel + 8];
                indexcart2[cancel + 7] = indexcart2[cancel + 8];


                adcart[cancel + 8] = adcart[cancel + 9];
                padcart[cancel + 8] = padcart[cancel + 9];
                qtyadcart[cancel + 8] = qtyadcart[cancel + 9];
                indexcart1[cancel + 8] = indexcart1[cancel + 9];
                indexcart2[cancel + 8] = indexcart2[cancel + 9];

                adcart[cancel + 9] = adcart[cancel + 10];
                padcart[cancel + 9] = padcart[cancel + 10];
                qtyadcart[cancel + 9] = qtyadcart[cancel + 10];
                indexcart1[cancel + 9] = indexcart1[cancel + 10];
                indexcart2[cancel + 9] = indexcart2[cancel + 10];

                Console.WriteLine("CHECKER ... 3");
            }
        }

    }   
}
