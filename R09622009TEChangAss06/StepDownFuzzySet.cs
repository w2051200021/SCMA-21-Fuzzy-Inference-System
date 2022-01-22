using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    class StepDownFuzzySet : GenericFuzzySet
    {
        static int current = 1;
        #region PROPERTIES

        [
            Category("Parameters"),
            Description("The left-top point of a step-down function.")
        ]
        public double Left
        {
            get => parameters[0];
            set
            {
                if (value <= parameters[1])
                {
                    parameters[0] = value;
                    ParameterChanged();
                }
            }
        }

        [
            Category("Parameters"),
            Description("The right-bottom point of a step-down function.")
        ]
        public double Right
        {
            get => parameters[1];
            set
            {
                if (value >= parameters[0])
                {
                    parameters[1] = value;
                    ParameterChanged();
                }
            }
        }

        #endregion

        public StepDownFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            parameters[0] = -3.0;
            parameters[1] = 3.0;
            name = $"StepDown{current++}";
        }
        public override double GetMembershipDegree(double x)
        {
            double y;

            if (x <= parameters[0])
            {
                y = 1;
            }
            else if (x >= parameters[0] & x <= parameters[1])
            {
                y = 1 - (x - parameters[0]) / (parameters[1] - parameters[0]);
            }
            else
            {
                y = 0;
            }

            return y;
        }
    }
}
