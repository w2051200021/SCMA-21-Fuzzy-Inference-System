using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    class LeftRightFuzzySet : GenericFuzzySet
    {
        static int current = 1;
        #region PROPERTIES

        [
            Category("Parameters"),
            Description("The left width a Left-Right function. Should not be zero.")
        ]
        public double LeftWidth
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
            Description("The right width a Left-Right function. Should not be zero.")
        ]
        public double RightWidth
        {
            get => parameters[1];
            set
            {
                if (value != 0)
                {
                    parameters[1] = value;
                    ParameterChanged();
                }
            }
        }

        [
            Category("Parameters"),
            Description("The center of a Left-Right function.")
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

        public LeftRightFuzzySet(Universe u) : base(u)
        {
            parameters = new double[3];
            parameters[0] = 5.0;
            parameters[1] = 3.0;
            parameters[2] = sharedRND.NextDouble() * (u.Maximum - u.Minimum) + u.Minimum;
            name = $"LeftRight{current++}";
        }
        public override double GetMembershipDegree(double x)
        {
            if (x <= parameters[2])
            {
                return Math.Sqrt(Math.Max(0, 1 - Math.Pow((parameters[2] - x) / parameters[0], 2)));
            }
            else
            {
                return Math.Exp(-Math.Pow(Math.Abs((x - parameters[2]) / parameters[1]), 3));
            }
        }
    }
}
