using System;
using System.ComponentModel;

namespace R09622009TEChangAss06
{
    public class GaussianFuzzySet : GenericFuzzySet
    {
        static int current = 1;
        #region PROPERTIES

        [
            Category("Parameters"),
            Description("The mean (expected value) of a Gaussian function.")
        ]
        public double Mean
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
            Description("The standard deviation of a Gaussian function. Should be a non-negative number.")
            
        ]
        public double StandardDeviation
        {
            get => parameters[1];
            set
            {
                if (value >= 0)
                {
                    parameters[1] = value;
                    ParameterChanged();
                }
            }
        }

        #endregion

        public GaussianFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            parameters[0] = sharedRND.NextDouble() * (u.Maximum - u.Minimum) + u.Minimum; // 0 <= RND <= 1
            parameters[1] = sharedRND.NextDouble() * 3 + 1.5;
            name = $"Gaussian{current++}";
        }
        public override double GetMembershipDegree(double x)
        {
            return Math.Exp(-0.5 * Math.Pow((x - parameters[0]) / parameters[1], 2)); 
        }

        //public override string ToString()
        //{
        //    return $"GaussianFS:{name}";
        //}
    }
}
