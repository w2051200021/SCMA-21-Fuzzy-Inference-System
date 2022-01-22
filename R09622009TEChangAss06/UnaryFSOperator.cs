using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    public class UnaryFSOperator
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
            Description("The name of the operator.")
        ]
        public string Name
        {
            get => name;
        }
        #endregion
        public virtual double CalcaulateValue(double x)
        {
            throw new NotImplementedException();
        }

        public virtual void SaveModel(StreamWriter sw)
        {
            sw.WriteLine($"OperatorName:{Name}");
            if(parameters != null)
            {
                sw.WriteLine($"NumberPars:{parameters.Length}");
                foreach(double p in parameters)
                {
                    sw.WriteLine($"ParValue:{p}");
                }
            }
            else
            {
                sw.WriteLine($"NumberPars:0");
            }
            
        }

        public virtual void ReadModel(StreamReader sr)
        {
            string str;
            str = sr.ReadLine().Trim();
            name = str.Substring(str.IndexOf(":") + 1);
            int number;
            str = sr.ReadLine().Trim();
            number = int.Parse(str.Substring(str.IndexOf(":") + 1));
            if(number > 0)
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

    public class NegateFSOperator : UnaryFSOperator
    {
        //constructor
        public NegateFSOperator()
        {
            name = "Not";
        }

        public override double CalcaulateValue(double x)
        {
            return 1.0 - x;
        }
    }

    public class SugenoComplementFSOperator : UnaryFSOperator
    {
        public SugenoComplementFSOperator()
        {
            parameters = new double[1];
            parameters[0] = -0.5;
            name = "SugenoNot";
        }

        [
            Category("Parameter"),
            Description("The parameter of Sugeno's complement operator. Should be greater than -1. The greater value results in the wider negation." +
                        "When s = 1, Sugeno's complement is equal to traditional negation.")
        ]
        public double sValue
        {
            get => parameters[0];
            set
            {
                if (value > -1)
                {
                    parameters[0] = value;
                    FireParameterChangeEvent();
                }
            }
        }

        public override double CalcaulateValue(double x)
        {
            return (1.0 - x) / (1 + parameters[0] * x);
        }
    }

    public class YagerComplementFSOperator : UnaryFSOperator
    {
        public YagerComplementFSOperator()
        {
            parameters = new double[1];
            parameters[0] = 5;
            name = "YagerNot";
        }

        [
            Category("Parameter"),
            Description("The parameter of Yager's complement operator. Should be greater than 0. The greater value results in the tighter negation." +
                        "When w = 1, Yager's complement is equal to traditional negation.")
        ]
        public double wValue
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

        public override double CalcaulateValue(double x)
        {
            return Math.Pow((1.0 - Math.Pow(x, parameters[0])), 1 / parameters[0]) ;
        }
    }

    public class ConcentrationFSOperator : UnaryFSOperator
    {
        public ConcentrationFSOperator()
        {
            name = "Very";
        }

        public override double CalcaulateValue(double x)
        {
            return Math.Pow(x, 2);
        }
    }

    public class ConcentrationEFSOperator : UnaryFSOperator
    {
        public ConcentrationEFSOperator()
        {
            name = "Extremly";
        }

        public override double CalcaulateValue(double x)
        {
            return Math.Pow(x, 8);
        }
    }

    public class DilationFSOperator : UnaryFSOperator
    {
        public DilationFSOperator()
        {
            name = "MoreOrLess";
        }

        public override double CalcaulateValue(double x)
        {
            return Math.Pow(x, 0.5);
        }
    }

    public class CutFSOperator : UnaryFSOperator
    {
        public CutFSOperator(double alpha = 0.5)
        {
            parameters = new double[1];
            parameters[0] = alpha;
            name = $"{Math.Round(parameters[0], 2)}-Cut";
        }

        [
            Category("Parameter"),
            Description("The cut value of the cut operator.")
        ]
        public double CutValue
        {
            get => parameters[0];
            set
            {
                if(value >= 0 & value <= 1.0)
                {
                    parameters[0] = value;
                    name = $"{Math.Round(parameters[0], 2)}-Cut";
                    FireParameterChangeEvent();
                }
            }
        }

        public override double CalcaulateValue(double x)
        {
            return x < parameters[0] ? x : parameters[0];
        }
    }

    public class ScaleFSOperator : UnaryFSOperator
    {
        public ScaleFSOperator(double alpha = 0.5)
        {
            parameters = new double[1];
            parameters[0] = alpha;
            name = $"{Math.Round(parameters[0], 2)}-Scaled";
        }

        [
         Category("Parameter"),
         Description("The scale value of the scale operator.")
        ]
        public double SacleValue
        {
            get => parameters[0];
            set
            {
                if (value >= 0 & value <= 1.0)
                {
                    parameters[0] = value;
                    name = $"{Math.Round(parameters[0], 2)}-Scaled";
                    FireParameterChangeEvent();
                }
            }
        }

        public override double CalcaulateValue(double x)
        {
            return x * parameters[0];
        }


    }

    public class IntensificationFSOperator : UnaryFSOperator
    {
        public IntensificationFSOperator()
        {
            name = "INT";
        }

        public override double CalcaulateValue(double x)
        {
            if(0 <= x & x <= 0.5)
            {
                return 2 * Math.Pow(x, 2);
            }
            else
            {
                return 1 - 2 * Math.Pow(1 - x, 2);
            }
        }
    }

    public class DiminishFSOperator : UnaryFSOperator
    {
        public DiminishFSOperator()
        {
            name = "DIM";
        }

        public override double CalcaulateValue(double x)
        {
            if (0 <= x & x <= 0.5)
            {
                return Math.Pow(0.5 * x, 0.5);
            }
            else
            {
                return 1 - Math.Pow(0.5 * (1 - x), 0.5);
            }
        }
    }
}