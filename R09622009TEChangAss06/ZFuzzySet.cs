using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    class ZFuzzySet : GenericFuzzySet
    {
        static int current = 1;
        #region PROPERTIES

        [
            Category("Parameters"),
            Description("The left point of a Z-shaped function. Should be smaller than the right point.")
        ]
        public double Left
        {
            get => parameters[0];
            set
            {
                if (value < parameters[1])
                {
                    parameters[0] = value;
                    ParameterChanged();
                }
            }
        }

        [
            Category("Parameters"),
            Description("The right point of a Z-shaped function. Should be greater than the left point.")
        ]
        public double Right
        {
            get => parameters[1];
            set
            {
                if (value > parameters[0])
                {
                    parameters[1] = value;
                    ParameterChanged();
                }
            }
        }

        #endregion

        public ZFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            parameters[0] = -3.0;
            parameters[1] = 3.0;
            name = $"Z-shaped{current++}";
        }
        public override double GetMembershipDegree(double x)
        {
            double y;

            if (x <= parameters[0])
            {
                y = 0;
            }
            else if (x > parameters[0] & x <= (parameters[0] + parameters[1]) / 2)
            {
                y = 2 * Math.Pow((x - parameters[0]) / (parameters[1] - parameters[0]), 2);
            }
            else if (x > (parameters[0] + parameters[1]) / 2 & x <= parameters[1])
            {
                y = 1 - 2 * Math.Pow((parameters[1] - x) / (parameters[1] - parameters[0]), 2);
            }
            else
            {
                y = 1;
            }

            return 1 - y;
        }
    }
}
