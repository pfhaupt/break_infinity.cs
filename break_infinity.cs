        //Define your numbers at the beginning of the script!
        //BigNumber n = new BigNumber(mantissa, exponent)
        BigNumber n1 = new BigNumber(4.22, 308);
        BigNumber n2 = new BigNumber(3.1533, 307);
        BigNumber n3 = new BigNumber(5.4, 310);
        BigNumber n4 = new BigNumber(4.22, 308);
        BigNumber n5 = new BigNumber(9.23, 990);

            public struct BigNumber
        {
            public double Mantissa;
            public int Exponent;

            public BigNumber(double m, int e)
            {
                Mantissa = m;
                Exponent = e;
            }

            public static BigNumber operator +(BigNumber n1, BigNumber n2)
            {
                int exp_diff = n2.Exponent - n1.Exponent;
                double scaled_mantissa = n2.Mantissa * Math.Pow(10, exp_diff);
                n1.Mantissa += scaled_mantissa;
                n1.Calculate();
                return n1;
            }

            public static BigNumber operator -(BigNumber n1, BigNumber n2)
            {
                int exp_diff = n2.Exponent - n1.Exponent;
                double scaled_mantissa = n2.Mantissa * Math.Pow(10, exp_diff);
                n1.Mantissa -= scaled_mantissa;
                n1.Calculate();
                return n1;
            }

            public static BigNumber operator *(BigNumber n1, BigNumber n2)
            {
                int new_diff = n2.Exponent + n1.Exponent;
                double new_mantissa = n2.Mantissa * n1.Mantissa;
                while(new_mantissa>=10)
                {
                    new_mantissa /= 10;
                    new_diff++;
                }
                n1.Mantissa = new_mantissa;
                n1.Exponent = new_diff;
                return n1;
            }

            public static BigNumber operator /(BigNumber n1, BigNumber n2)
            {
                int new_diff = n1.Exponent - n2.Exponent;
                double new_mantissa = n1.Mantissa / n2.Mantissa;
                while (new_mantissa<1)
                {
                    new_mantissa *= 10;
                    new_diff--;
                }
                n1.Mantissa = new_mantissa;
                n1.Exponent = new_diff;
                return n1;
            }

            public void Calculate()
            {
                if (Mantissa >= 10.0 || Mantissa < 1.0)
                {
                    int diff = (int)Math.Floor(Math.Log10(Mantissa));
                    Mantissa /= Math.Pow(10, diff);
                    Exponent += diff;
                }
            }

            public override string ToString()
            {
                if (Exponent < 10)
                    return (Mantissa * Math.Pow(10, Exponent)).ToString();
                else
                    return Mantissa.ToString("0.000") + "e" + Exponent.ToString();
            }
            n1 = n2 + n1;
            Console.WriteLine("Addition: "+n1);
            n3 = n3 - n2;
            Console.WriteLine("Subtraction: " + n3);
            n4 = n2 * n4;
            Console.WriteLine("Multiplication: " + n4);
            n5 = n5 / n1;
            Console.WriteLine("Division: " + n5);
        }
