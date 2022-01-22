using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    class TriangularFuzzySet : GenericFuzzySet
    {
        static int current = 1;
        #region PROPERTIES

        [
            Category("Parameters"),
            Description("The left point of a Triangular function.")
        ]
        public double Left
        {
            get => parameters[0];
            set
            {
                if (value <= parameters[1] & value <= parameters[2])
                {
                    parameters[0] = value;
                    ParameterChanged();
                }
            }
        }

        [
            Category("Parameters"),
            Description("The peak point of a Triangular function.")
        ]
        public double Peak
        {
            get => parameters[1];
            set
            {
                if (value >= parameters[0] & value <= parameters[2])
                {
                    parameters[1] = value;
                    ParameterChanged();
                }
            }
        }

        [
            Category("Parameters"),
            Description("The right point of a Triangular function.")
        ]
        public double Right
        {
            get => parameters[2];
            set
            {
                if (value >= parameters[0] & value >= parameters[1])
                {
                    parameters[2] = value;
                    ParameterChanged();
                }
            }
        }

        #endregion

        public TriangularFuzzySet(Universe u) : base(u)
        {
            parameters = new double[3];
            parameters[0] = -3.0;
            parameters[1] = 0.0;
            parameters[2] = 3.0;
            name = $"Triangular{current++}";
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
            else if (x >= parameters[1] & x <= parameters[2])
            {
                y = (parameters[2] - x) / (parameters[2] - parameters[1]);
            }
            else
            {
                y = 0;
            }

            return y;
        }
    }
}
