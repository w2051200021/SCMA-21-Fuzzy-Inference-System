using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    class BellFuzzySet : GenericFuzzySet
    {
        static int current = 1;
        #region PROPERTIES

        [
            Category("Parameters"),
            Description("The width a Bell function. Should not be zero.")
        ]
        public double Width
        {
            get => parameters[0];
            set
            {
                if (value != 0)
                {
                    parameters[0] = value;
                    ParameterChanged();
                }
            }
        }

        [
            Category("Parameters"),
            Description("The shape parameter of a Bell function. High absolute value of shape implies the similarity of the graph to a square wave. When it is greater than zero, the graph has a peak, vice versa.")
        ]
        public double Shape
        {
            get => parameters[1];
            set
            {
                parameters[1] = value;
                ParameterChanged();
            }
        }

        [
            Category("Parameters"),
            Description("The center of a Bell function.")
        ]
        public double Center
        {
            get => parameters[2];
            set
            {
                parameters[2] = value;
                ParameterChanged();
            }
        }

        #endregion

        public BellFuzzySet(Universe u) : base(u)
        {
            parameters = new double[3];
            parameters[0] = 1.25;
            parameters[1] = 5.0;
            parameters[2] = sharedRND.NextDouble() * (u.Maximum - u.Minimum) + u.Minimum;
            name = $"Bell{current++}";
        }
        public override double GetMembershipDegree(double x)
        {
            return 1 / (1 + Math.Pow(Math.Abs((x - parameters[2]) / parameters[0]), 2 * parameters[1]));
        }
    }
}
