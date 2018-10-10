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
                    double exchangeToYen = amount * USDtoYen;
                    return exchangeToYen;
                }
                else 
                {
                    double exchangeToUSD = amount * YentoUSD;
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
                double objTwoConv = objTwo.converter(objTwo.currencyUnit);

                double amount = objOne.amount + objTwoConv;
                Currency currency = objOne.currencyUnit;
                return new Money(amount, currency);
            }

        }
    }


    class Test
    {
        public void Main()
        {
            Money start = new Money(33.75, Currency.USD);
            Console.WriteLine(start.currencyUnit);
        }
    }
}