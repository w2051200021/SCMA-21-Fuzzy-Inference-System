using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    class PiFuzzySet : GenericFuzzySet
    {
        static int current = 1;
        #region PROPERTIES

        [
            Category("Parameters"),
            Description("The center of a Pi-shaped function.")
        ]
        public double Center
        {
            get => parameters[0];
            set
            {
                parameters[0] = value;
                ParameterChanged();
            }
        }

        [
            Category("Parameters"),
            Description("The spread on each side of the function. Should be greater than zero.")
        ]
        public double Spread
        {
            get => parameters[1];
            set
            {
                if (value > 0)
                {
                    parameters[1] = value;
                    ParameterChanged();
                }
            }
        }

        #endregion

        public PiFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            parameters[0] = sharedRND.NextDouble() * (u.Maximum - u.Minimum) + u.Minimum;
            parameters[1] = 3.0;
            name = $"Pi-shaped{current++}";
        }
        public override double GetMembershipDegree(double x)
        {
            double y;

            if (x <= parameters[0])
            {
                if (x <= parameters[0] - parameters[1])
                {
                    y = 0;
                }
                else if (x > parameters[0] - parameters[1] & x <= (2 * parameters[0] - parameters[1]) / 2)
                {
                    y = 2 * Math.Pow((x - (parameters[0] - parameters[1])) / (parameters[1]), 2);
                }
                else if (x > (2 * parameters[0] - parameters[1]) / 2 & x <= parameters[0])
                {
                    y = 1 - 2 * Math.Pow((parameters[0] - x) / (parameters[1]), 2);
                }
                else
                {
                    y = 1;
                }
            }
            else
            {
                if (x <= parameters[0])
                {
                    y = 1;
                }
                else if (x > parameters[0] & x <= (2 * parameters[0] + parameters[1]) / 2)
                {
                    y = 1 - 2 * Math.Pow((x - (parameters[0])) / (parameters[1]), 2);
                }
                else if (x > (2 * parameters[0] + parameters[1]) / 2 & x <= parameters[0] + parameters[1])
                {
                    y = 2 * Math.Pow((parameters[0] + parameters[1] - x) / (parameters[1]), 2);
                }else
                {
                    y = 0;
                }
            }

            return y;
        }
    }
}
