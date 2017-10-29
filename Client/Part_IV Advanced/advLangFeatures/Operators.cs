using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ADVANCED.advLangFeatures
{
    class TestOperators
    {
        public void Test()
        {
            BinaryOperators o1 = new BinaryOperators() { X = 20, Y = 12 };
            BinaryOperators o2 = new BinaryOperators() { X = 30, Y = 38 };
            BinaryOperators o3 = o1 + o2;
            o3 += 2;
            Console.WriteLine("o3.X {0}, o3.Y {1}", o3.X, o3.Y);

            UnaryOperators uOp1 = new UnaryOperators() { X = 100, Y = 200 };
            Console.WriteLine("uOp1.X {0}, uOp1.Y {1}", uOp1.X, uOp1.Y);
            uOp1++;
            ++uOp1;
            Console.WriteLine("uOp1.X {0}, uOp1.Y {1}", uOp1.X, uOp1.Y);

            EqualityOperator eo1 = new EqualityOperator() { X = 100, Y = 200 };
            EqualityOperator eo2 = new EqualityOperator() { X = 100, Y = 200 };
            Console.WriteLine("eo1 == eo2 {0}   eo1.Equals(eo2) {1} ", eo1==eo2, eo1.Equals(eo2));
            ComparisonOperator co1 = new ComparisonOperator() { X = 2, Y = 2 };
            ComparisonOperator co3 = new ComparisonOperator() { X = 6, Y = 6 };
            ComparisonOperator co2 = new ComparisonOperator() { X = 4, Y = 4};
            Console.WriteLine(" co1 < co2  {0}", co1 < co2);
            Console.WriteLine(" co1 < co2  {0}", co1 > co2);
            Console.WriteLine(" co3 < co2  {0}", co3 > co2);


            CustomConversionA customA = new CustomConversionA() { Description = "My Description" };
            CustomConversionC customC = new CustomConversionC() { Description = "My Description" };

            CustomConversionB customBfromA = (CustomConversionB)customA;
            CustomConversionB customBfromCex = (CustomConversionB)customC;
            CustomConversionB customBfromCimp = (CustomConversionB)customC;
            Console.WriteLine("CustomBfromA : {0}", customBfromA.ReverseDescription);
            Console.WriteLine("CustomBfromC(explicit) :  {0}", customBfromCex.ReverseDescription);
            Console.WriteLine("CustomBfromC(implpicit) : {0}", customBfromCimp.ReverseDescription);
        }
        class ComparisonOperator
        {
            public int X { get; set; }
            public int Y { get; set; }
            public static bool operator <(ComparisonOperator co1, ComparisonOperator co2)
            {
                bool extr = Math.Sqrt(Math.Pow((co1.Y), 2) + Math.Pow((co1.X), 2)) < Math.Sqrt(Math.Pow((co2.Y), 2) + Math.Pow((co2.X), 2));

                return  extr;
                   
            }
            public static bool operator >(ComparisonOperator co1, ComparisonOperator co2)
            {
                return (
                //   Math.Sqrt(Math.Pow((co1.Y), 2) + Math.Pow((co1.X), 2)) > Math.Sqrt(Math.Pow((co2.Y), 2) + Math.Pow((co2.X), 2))
                co1.CompareTo(co2) > 0
          
                  );
            }
          public int CompareTo(ComparisonOperator co2)
            {
                if (Math.Sqrt(Math.Pow((this.Y), 2) + Math.Pow((this.X), 2)) < Math.Sqrt(Math.Pow((co2.Y), 2) + Math.Pow((co2.X), 2)))

                    return -1;
                else if (Math.Sqrt(Math.Pow((this.Y), 2) + Math.Pow((this.X), 2)) > Math.Sqrt(Math.Pow((co2.Y), 2) + Math.Pow((co2.X), 2)))
                    {
                    return 1;
                     }
                else { return 0; }



            }
        }
        class EqualityOperator
        {
            public int X { get; set; }
            public int Y { get; set; }

            public static bool operator ==(EqualityOperator eO1, EqualityOperator eO2 )
            {
                return eO1.Equals(eO2);
            }
            public static bool operator !=(EqualityOperator eO1, EqualityOperator eO2)
            {
                return !eO1.Equals(eO2);
            }
            public override bool Equals(object obj)
            {
                EqualityOperator eO2 = obj as EqualityOperator;

                return ((this.X == eO2.X) && (this.Y == eO2.Y));
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

        }
        class UnaryOperators
        {
            public int X { get; set; }
            public int Y { get; set; }
            public static UnaryOperators operator ++(UnaryOperators uO)
            {
                return new UnaryOperators() { X = uO.X + 1, Y= uO.Y + 1};
            }
            public static UnaryOperators operator --(UnaryOperators uO)
            {
                return new UnaryOperators() { X = uO.X - 1, Y = uO.Y - 1 };
            }
            
        }
        class BinaryOperators
        {
            public int X { get; set; }
            public int Y { get; set; }
            public static BinaryOperators operator +(BinaryOperators o1, BinaryOperators o2)
            {
                return new BinaryOperators() { X = o1.X + o2.X, Y = o1.Y + o2.Y };
            }
            public static BinaryOperators operator +(BinaryOperators o1, int offset)
            {
                return new BinaryOperators() { X = o1.X + offset, Y = o1.Y + offset };
            }
        }
        class CustomConversionA
        {
            public string Description { get; set; }
            public static explicit operator CustomConversionB(CustomConversionA CCa)
            {
                  return new CustomConversionB() { ReverseDescription = "Explicit" };

            } 

        }
        class CustomConversionC
        {
            public string Description { get; set; }
            public static implicit operator CustomConversionB(CustomConversionC CCa)
            {
                return new CustomConversionB() { ReverseDescription = "Implicit" };

            }

        }
        class CustomConversionB
        {
            public string ReverseDescription { get; set; }
            
        }
    }
}
