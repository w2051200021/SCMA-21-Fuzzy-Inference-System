using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    public class SingletonFuzzySet : GenericFuzzySet
    {
        static int current = 1;
        #region PROPERTIES

        [
            Category("Parameters"),
            Description("The value of the singleton.")
        ]
        public double value
        {
            get => parameters[0];
            set
            {
                parameters[0] = value;
                ParameterChanged();
            }
        }

        #endregion

        public SingletonFuzzySet(Universe u) : base(u)
        {
            parameters = new double[1];
            parameters[0] = sharedRND.NextDouble() * (u.Maximum - u.Minimum) + u.Minimum; // 0 <= RND <= 1
            name = $"Singleton{current++}";
        }
        public override double GetMembershipDegree(double x)
        {
            // Use Gaussian Function to approximate a fuzzy singleton
            return Math.Exp(-0.5 * Math.Pow((x - parameters[0]) / 0.001, 2));
        }
    }
}
