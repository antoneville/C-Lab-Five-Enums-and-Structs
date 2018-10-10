using System;

public enum Currency { USD, Yen }                             //Currency should either be USD or Yen

namespace StuctsAndEnums
{
    struct Money                                        //Money Structure
    {
        private const double YentoUSD = 0.14;           //Consts
        private const double USDtoYen = 113.24;

        public double amount { get; set; }              //Auto-Implemented Property
        public Currency currencyUnit { get; set; }


        public Money(double amount, Currency currencyUnit)                  //Non Default Constructor
            : this()
        {
            this.amount = amount;
            this.currencyUnit = currencyUnit;
        }

        public double converter(Currency currencyCheck)                              //Allows the currencies to be converted
        {

            if (currencyUnit == currencyCheck)                                      //No need to be converted
            {
                return amount;
            }
            else
            {
                if (currencyCheck == Currency.USD)
                {
                    double exchangeToYen = amount * YentoUSD;
                    return exchangeToYen;
                }
                else 
                {
                    double exchangeToUSD = amount * USDtoYen;
                    return exchangeToUSD;
                }
            }
        }

        public static Money operator +(Money objOne, Money objTwo)                          //Overloaded Operators
        {
            if (objOne.currencyUnit == objTwo.currencyUnit)
            {
                double amount = objOne.amount + objTwo.amount;
                Currency currency = objOne.currencyUnit;

                return new Money(amount, currency);

            }
            else
            {
                double objTwoConv = objTwo.converter(objOne.currencyUnit);

                double amount = objOne.amount + objTwoConv;
                Currency currency = objOne.currencyUnit;
                return new Money(amount, currency);
            }

        }

        public override string ToString()
        {
            return "The Money is: "+ currencyUnit + " " + amount;
        }
    }


    class Test
    {
        public static void Main()
        {

            //Yen To USD Objects Created
            Money USDobjectOne = new Money(33.75, Currency.USD);
            Money YenobjectOne = new Money(4000.96 ,Currency.Yen);
            Money USDobjectTwo = USDobjectOne + YenobjectOne;

            //No Conversion Needed Objects
            Money YenobjectFive = new Money(45677.21, Currency.Yen);
            Money YenobjectSix = new Money(442222.75, Currency.Yen);
            Money YenObjectAdd = YenobjectFive + YenobjectSix;

            //USD To Yen Objects Created
            Money YenobjectTen = new Money(8577.21, Currency.Yen);
            Money USDobjectTen = new Money(224.75, Currency.USD);
            Money YenObjectConv = YenobjectTen + USDobjectTen;

            //Yen To USD Print outs
            Console.WriteLine("*********************************");
            Console.WriteLine("\tYen to USD Conversion");
            Console.WriteLine("*********************************");
            Console.WriteLine(YenobjectOne);
            Console.WriteLine("Yen to USD: USD {0}", YenobjectOne.converter(Currency.USD));

            Console.WriteLine(USDobjectOne);
            Console.WriteLine(USDobjectTwo);
            Console.WriteLine("*********************************");

            //USD to Yen Print outs
            Console.WriteLine("*********************************");
            Console.WriteLine("\tUSD to Yen Conversion");
            Console.WriteLine("*********************************");
            Console.WriteLine(USDobjectTen);
            Console.WriteLine("USD to Yen: Yen {0}", USDobjectTen.converter(Currency.Yen));

            Console.WriteLine(YenobjectTen);
            Console.WriteLine(YenObjectConv);
            Console.WriteLine("*********************************");

            //No conversion Needed Prints
            Console.WriteLine("*********************************");
            Console.WriteLine("\tNo Conversion");
            Console.WriteLine("*********************************");
            Console.WriteLine(YenobjectFive);
            Console.WriteLine(YenobjectSix);
            Console.WriteLine(YenObjectAdd);
            Console.WriteLine("*********************************");

        }
    }
}