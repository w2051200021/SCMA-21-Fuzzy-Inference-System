using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    class TrapzoidalFuzzySet : GenericFuzzySet
    {
        static int current = 1;
        #region PROPERTIES

        [
            Category("Parameters"),
            Description("The left-bottom point of a Trapzoidal function.")
        ]
        public double LeftBottom
        {
            get => parameters[0];
            set
            {
                if (value <= parameters[1] & value <= parameters[2] & value <= parameters[3])
                {
                    parameters[0] = value;
                    ParameterChanged();
                }
            }
        }

        [
            Category("Parameters"),
            Description("The left-top point of a Trapzoidal function.")
        ]
        public double LeftTop
        {
            get => parameters[1];
            set
            {
                if (value >= parameters[0] & value <= parameters[2] & value <= parameters[3])
                {
                    parameters[1] = value;
                    ParameterChanged();
                }
            }
        }

        [
            Category("Parameters"),
            Description("The right-top point of a Trapzoidal function.")
        ]
        public double RightTop
        {
            get => parameters[2];
            set
            {
                if (value >= parameters[0] & value >= parameters[1] & value <= parameters[3])
                {
                    parameters[2] = value;
                    ParameterChanged();
                }
            }
        }

        [
    Category("Parameters"),
    Description("The right-bottom point of a Trapzoidal function.")
]
        public double RightBottom
        {
            get => parameters[3];
            set
            {
                if (value >= parameters[0] & value >= parameters[1] & value >= parameters[2])
                {
                    parameters[3] = value;
                    ParameterChanged();
                }
            }
        }

        #endregion

        public TrapzoidalFuzzySet(Universe u) : base(u)
        {
            parameters = new double[4];
            parameters[0] = -3.0;
            parameters[1] = -1.0;
            parameters[2] = 1.0;
            parameters[3] = 3.0;
            name = $"Trapzoidal{current++}";
        }
        public override double GetMembershipDegree(double x)
        {
            double y;

            if (x <= parameters[0])
            {
                y = 0;
            }
            else if (x >= parameters[0] & x <= parameters[1])
            {
                y = (x - parameters[0]) / (parameters[1] - parameters[0]);
            }
            else if(x >= parameters[1] & x <= parameters[2])
            {
                y = 1;
            }
            else if (x >= parameters[2] & x <= parameters[3])
            {
                y = (parameters[3] - x) / (parameters[3] - parameters[2]);
            }
            else
            {
                y = 0;
            }

            return y;
        }
    }
}
