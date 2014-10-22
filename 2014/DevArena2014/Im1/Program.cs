using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Im1
{
    class Order
    {
        public Order()
        {
            Lines = new List<OrderLine>();
        }

        public List<OrderLine> Lines { get; private set; }
    }

    class OrderLine
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public float Discount { get; set; }

        public decimal Total
        {
            get
            {
                return Quantity * UnitPrice * (decimal)(1.0f - Discount);
            }
        }
    }


    /*
   class OrderLine
{
     public OrderLine(int quantity, decimal unitPrice, float discount)
     {
         Quantity = quantity;
         UnitPrice = unitPrice;
         Discount = discount;
     }
 
     public int Quantity { get; private set; }
 
     public decimal UnitPrice { get; private set; }
 
     public float Discount { get; private set; }
 
     public decimal Total
     {
         get
         {
          return Quantity * UnitPrice * (decimal) (1.0f - Discount);
         }
     }
    
      
     public OrderLine WithQuantity(int value)
    {
        return value == Quantity
                ? this
                : new OrderLine(value, UnitPrice, Discount);
    }

    public OrderLine WithUnitPrice(decimal value)
    {
        return value == UnitPrice
                ? this
                : new OrderLine(Quantity, value, Discount);
    }

    public OrderLine WithDiscount(float value)
    {
        return value == Discount
                ? this
                : new OrderLine(Quantity, UnitPrice, value);
    }

 }
     */

    class Program
    {
        static void Main(string[] args)
        {
            var list = ImmutableList<int>.Empty.Add(1).Add(2);

            foreach(var i in list)
                Console.WriteLine(i);

            // equality

            // builder
        }
    }
}
