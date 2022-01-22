using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    class SigmoidalFuzzySet : GenericFuzzySet
    {
        static int current = 1;
        #region PROPERTIES

        [
            Category("Parameters"),
            Description("The steepness of a Sigmoidal function.")
        ]
        public double Steepness
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
            Description("The mid-point of a Sigmoidal function.")

        ]
        public double MidPoint
        {
            get => parameters[1];
            set
            {
                parameters[1] = value;
                ParameterChanged();
            }
        }

        public override bool IsMonotonic => true;
        #endregion

        public SigmoidalFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            parameters[0] = 1.0;
            parameters[1] = sharedRND.NextDouble() * (u.Maximum - u.Minimum) + u.Minimum;
            name = $"Sigmoidal{current++}";
        }
        public override double GetMembershipDegree(double x)
        {
            return 1 / (1 + Math.Exp(-parameters[0] * (x - parameters[1])));
        }
    }
}
