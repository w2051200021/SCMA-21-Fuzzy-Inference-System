using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    public class BinaryFSOperator
    {
        public event EventHandler ParameterChanged;
        protected double[] parameters;
        protected string name;

        protected void FireParameterChangeEvent()
        {
            if (ParameterChanged != null) ParameterChanged(this, null);
        }

        #region PROPERTIES & EVENTS

        [
            Category("Identity"),
            Description("The name of the binary operator.")
        ]
        public string Name
        {
            get => name;
        }

        #endregion


        public virtual double CalcaulateValue(double x, double y)
        {
            throw new NotImplementedException();
        }

        internal void SaveModel(StreamWriter sw)
        {
            sw.WriteLine($"OperatorName:{Name}");
            if (parameters != null)
            {
                sw.WriteLine($"NumberPars:{parameters.Length}");
                foreach (double p in parameters)
                {
                    sw.WriteLine($"ParValue:{p}");
                }
            }
            else
            {
                sw.WriteLine($"NumberPars:0");
            }
        }

        internal void ReadModel(StreamReader sr)
        {
            string str;
            str = sr.ReadLine().Trim();
            name = str.Substring(str.IndexOf(":") + 1);
            int number;
            str = sr.ReadLine().Trim();
            number = int.Parse(str.Substring(str.IndexOf(":") + 1));
            if (number > 0)
            {
                parameters = new double[number];
                for (int i = 0; i < number; i++)
                {
                    str = sr.ReadLine().Trim();
                    parameters[i] = double.Parse(str.Substring(str.IndexOf(":") + 1));
                }
            }
        }
    }

    // 0 -> Intersecion (min)
    // 1 -> Algebraic product
    // 2 -> Bounded product
    // 3 -> Drastic product
    // 4 -> Sugeno's T-norm
    // 5 -> Yager's T-norm
    // 6 -> Union (max)
    // 7 -> Algebraic sum
    // 8 -> Bounded sum
    // 9 -> Drastic sum
    // 10 -> Sugeno's S-norm
    // 11 -> Yager's S-norm

    public class IntersectionFSOperator : BinaryFSOperator
    {
        public IntersectionFSOperator()
        {
            name = "Intersect";
        }
        public override double CalcaulateValue(double x, double y)
        {
            return x > y ? y : x;
        }
    }

    public class AlgebraicProductFSOperator : BinaryFSOperator
    {
        public AlgebraicProductFSOperator()
        {
            name = "AP";
        }
        public override double CalcaulateValue(double x, double y)
        {
            return x * y;
        }
    }

    public class BoundedProductFSOperator : BinaryFSOperator
    {
        public BoundedProductFSOperator()
        {
            name = "BP";
        }
        public override double CalcaulateValue(double x, double y)
        {
            return (x + y - 1) > 0 ? (x + y - 1) : 0;
        }
    }

    public class DrasticProductFSOperator : BinaryFSOperator
    {
        public DrasticProductFSOperator()
        {
            name = "DP";
        }
        public override double CalcaulateValue(double x, double y)
        {
            if (y == 1) return x;
            else if (x == 1) return y;
            else return 0;
        }
    }

    public class SugenoTnormFSOperator : BinaryFSOperator
    {
        public SugenoTnormFSOperator()
        {
            parameters = new double[1];
            parameters[0] = 5;
            name = "Sugeno-T";
        }

        [
         Category("Parameter"),
         Description("The parameter value of the Sugeno's T-norm operator. Should be greater than 0.")
        ]
        public double lambda
        {
            get => parameters[0];
            set
            {
                if (value >= -1)
                {
                    parameters[0] = value;
                    FireParameterChangeEvent();
                }
            }
        }

        public override double CalcaulateValue(double x, double y)
        {
            return (parameters[0] + 1) * (x + y - 1) - parameters[0] * x * y > 0 ? (parameters[0] + 1) * (x + y - 1) - parameters[0] * x * y : 0;
        }
    }

    public class YagerTnormFSOperator : BinaryFSOperator
    {
        public YagerTnormFSOperator()
        {
            parameters = new double[1];
            parameters[0] = 5;
            name = "Yager-T";
        }

        [
         Category("Parameter"),
         Description("The parameter value of the Yager's T-norm operator. Should not be less than -1.")
        ]
        public double q
        {
            get => parameters[0];
            set
            {
                if (value > 0)
                {
                    parameters[0] = value;
                    FireParameterChangeEvent();
                }
            }
        }


        public override double CalcaulateValue(double x, double y)
        {
            return 1 - Math.Min(1, Math.Pow(Math.Pow(1 - x, q) + Math.Pow(1 - y, q), 1 / q));
        }
    }

    public class UnionFSOperator : BinaryFSOperator
    {
        public UnionFSOperator()
        {
            name = "Union";
        }
        public override double CalcaulateValue(double x, double y)
        {
            return x > y ? x : y;
        }
    }

    public class AlgebraicSumFSOperator : BinaryFSOperator
    {
        public AlgebraicSumFSOperator()
        {
            name = "AS";
        }
        public override double CalcaulateValue(double x, double y)
        {
            return x + y - x * y;
        }
    }

    public class BoundedSumFSOperator : BinaryFSOperator
    {
        public BoundedSumFSOperator()
        {
            name = "BS";
        }
        public override double CalcaulateValue(double x, double y)
        {
            return Math.Min(1, x + y);
        }
    }

    public class DrasticSumFSOperator : BinaryFSOperator
    {
        public DrasticSumFSOperator()
        {
            name = "DS";
        }
        public override double CalcaulateValue(double x, double y)
        {
            if (y == 0) return x;
            else if (x == 0) return y;
            else return 1;
        }
    }

    public class SugenoSnormFSOperator : BinaryFSOperator
    {
        public SugenoSnormFSOperator()
        {
            parameters = new double[1];
            parameters[0] = 5;
            name = "Sugeno-S";
        }

        [
         Category("Parameter"),
         Description("The parameter value of the Sugeno's S-norm operator. Should not be less than -1.")
        ]
        public double lambda
        {
            get => parameters[0];
            set
            {
                if (value >= -1)
                {
                    parameters[0] = value;
                    FireParameterChangeEvent();
                }
            }
        }

        public override double CalcaulateValue(double x, double y)
        {
            // From Sugeno, 1993, the equation (2.60) in the textbook is wrong
            // S_S(a, b, lambda) = min{1, a + b + lambda * a * b}
            return Math.Min(1, x + y + parameters[0] * x * y);
        }
    }

    public class YagerSnormFSOperator : BinaryFSOperator
    {
        public YagerSnormFSOperator()
        {
            parameters = new double[1];
            parameters[0] = 5;
            name = "Yager-S";
        }

        [
         Category("Parameter"),
         Description("The parameter value of the Yager's S-norm operator. Should be greater than 0.")
        ]
        public double q
        {
            get => parameters[0];
            set
            {
                if (value > 0)
                {
                    parameters[0] = value;
                    FireParameterChangeEvent();
                }
            }
        }

        public override double CalcaulateValue(double x, double y)
        {
            return Math.Min(1, Math.Pow(Math.Pow(x, q) + Math.Pow(y, q), 1 / q));
        }
    }
}

