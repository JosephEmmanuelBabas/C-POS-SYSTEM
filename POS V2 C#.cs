namespace POSV2
{
    //  POS SYSTEM
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;// ENABLE TO DISPLAY THE PESO SIGN or SYMBOL
            FI f = new FI();// INSTANTIATOR TO GIVE ACCESS IN OTHER CLASS 

            // GLOBAL VARIABLES
            float totalprice, finalttlamt = 0, cash = 0, change = 0;
            int opt = 0, ord = 0, pord = 0 ,cancel = 0 , qty = 0, index = 0, rpet = 0,pass = 0;
            


                while (true)
                {
                    // DISPLAY MENU OPTION
                    Console.WriteLine("======== OPTION ==========");
                    Console.WriteLine("1.MENU");
                    Console.WriteLine("2.ORDER");
                    Console.WriteLine("3.INVENTORY(ADMIN ONLY)");
                    Console.WriteLine("4.CANCEL ORDER");
                    Console.WriteLine("5.CART AND CHECK OUT ORDER");
                    Console.WriteLine("6.EXIT");
                    Console.WriteLine("==========================");

                    Console.Write("ENTER: ");
                    opt = f.input(opt);

                        switch (opt)
                        {
                            case 1:
                                f.Pdisplay();
                                Console.Write("Press Enter to go back to Menu...");
                                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { } // Loop until Enter is pressed
                                Console.WriteLine("");
                                break;

                            case 2:
                                while (true) { 
                                // DISPLAY CATEGORY
                                Console.WriteLine("============================================");
                                f.Catdisplay();
                                Console.Write("WHAT CATEGORY YOU WANT TO ORDER? IF NOT PRESS 6: ");
                                ord = f.cpinput(ord);
                                Console.WriteLine("\n============================================");
                                if (ord == 6) break;
                                


                                // DISPLAY PRODUCTS WITH IN THE CATEGORY YOU CHOOSE
                                f.Proddisplay(ord);

                                //DISPLAY THE PRODUCT YOU CHOOSE
                                Console.WriteLine("============================================");
                                Console.Write("WHAT PRODUCT YOU WANT TO ORDER? IF NOT PRESS 6: ");
                                pord = f.cpinput(pord);
                                if (pord == 6) break;
                                f.SPdisplay(ord, pord);
                                

                                
                                // CALCULATE TOTAL AMOUNT
                                Console.WriteLine("============================");
                                Console.Write("ENTER QUANTITY: ");
                                qty = f.input(qty);
                                Console.WriteLine("");
                                f.SPdisplay(ord, pord, qty);
                                totalprice = f.totalamt(ord, pord, qty);
                                
                                
                                // ADDING TO CART
                                f.addtocart(ord, pord, qty,index);
                                f.stockupdater(ord, pord, qty);
                                finalttlamt += totalprice;
                                index++;

                                Console.WriteLine("============================");
                                Console.Write("ENTER [1] ORDER AGAIN [2] IF NOT: ");
                                rpet = f.optinput(rpet);
                                if (rpet == 2) break;
                                }
                                break;

                            case 3:
                                Console.Write("ENTER PIN PASSWORD: ");
                                pass = f.passinput(pass);
                                if (pass == 0) {Console.WriteLine("YOUR NOT ADMIN..."); break; }
                                f.INVdisplay();

                                Console.Write("Press Enter to go back to Menu...");
                                while (Console.ReadKey(true).Key != ConsoleKey.Enter){ } // Loop until Enter is pressed
                                Console.WriteLine("");
                        break;

                        // CANCEL SPECIFIC ORDER 
                        case 4:
                        if (finalttlamt != 0) 
                        { 
                            f.cartdisplay(index, finalttlamt);
                            Console.Write("ENTER [1] CANCEL SPECIFIC ORDER [2] IF NOT: ");
                            rpet = f.optinput(rpet);

                            if (rpet == 1)
                            {
                                Console.Write("ENTER THE NUMBER OF ORDER YOU WANT TO CANCEL: ");
                                cancel = f.cancelinput(cancel, index);
                                finalttlamt -= f.padcart[cancel - 1];
                                f.cancel(cancel, index);
                                index--;
                            }
                            if (rpet == 2) break;
                        }

                        else if (finalttlamt == 0) Console.WriteLine("YOU HAVE NOT YET ORDERED PLEASE ORDER FIRST.....");
                        break;

                        case 5:
                        // CHECK OUT ORDER 
                        if (finalttlamt != 0)
                        {

                            f.cartdisplay(index, finalttlamt);

                            Console.Write("ENTER [1] CHECK OUT[2] IF NOT: ");
                            rpet = f.optinput(rpet);

                            if (rpet == 1)
                            {
                                Console.Write("ENTER CASH HERE: ");
                                cash = f.input(cash,finalttlamt);
                                change = cash - finalttlamt;

                                f.cartdisplay(index, finalttlamt,change,cash);
                                f.checkout(index);
                                index = 0;
                                finalttlamt = 0;
                                Console.WriteLine("ORDER SUCCESSFULLY CHECK OUT..... ");
                            }
                            if (rpet == 2) break;
                        }
                        else if(finalttlamt == 0) Console.WriteLine("YOU HAVE NOT YET ORDERED PLEASE ORDER FIRST.....");
                        break;
                        
                        }
                if (opt == 6) { Console.WriteLine("EXITING......."); break; }
                else { continue; }



            }
            

        }
    }
}
