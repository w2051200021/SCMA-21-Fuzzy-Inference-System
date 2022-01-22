using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    public class TsukamotoFuzzySystem
    {
        TsukamotoIfThenFuzzyRule[] allRules;

        public TsukamotoIfThenFuzzyRule[] AllRules { get => allRules; }


        public double FuzzyInCrispOutInferencing(List<GenericFuzzySet> conditions, bool UseAverage = true)
        {
            // For fuzzy singleton
            double resultedCrispValue = 0.0;
            double SumOfFiringStrength = 0.0;
            for (int r = 0; r < allRules.Length; r++)
            {
                resultedCrispValue += allRules[r].FuzzyInCrispOutInferencing(conditions, out double firingStrength) * firingStrength;
                if (UseAverage) SumOfFiringStrength += firingStrength;
            }
            if (UseAverage) resultedCrispValue /= SumOfFiringStrength;
            return resultedCrispValue;
        }

        public double CrispInCrispOutInferencing(double[] conditions, bool UseAverage = true)
        {
            double resultedCrispValue = 0.0;
            double SumOfFiringStrength = 0.0;
            for (int r = 0; r < allRules.Length; r++)
            {
                resultedCrispValue += allRules[r].CrispInCrispOutInferencing(conditions, out double firingStrength) * firingStrength;
                if (UseAverage) SumOfFiringStrength += firingStrength;
            }
            if (UseAverage) resultedCrispValue /= SumOfFiringStrength;
            return resultedCrispValue;
        }
       

        public TsukamotoFuzzySystem()
        {
            // Default constructor
        }
        public void UpdateRuleSet(TsukamotoIfThenFuzzyRule[] allRules)
        {
            this.allRules = allRules;
        }

        public void SaveModel(StreamWriter sw)
        {
            sw.WriteLine($"NumberOfRules:{allRules.Length}");
            for (int i = 0; i < allRules.Length; i++)
            {
                allRules[i].SaveModel(sw);
            }
        }

        public void ReadModel(StreamReader sr)
        {
            string str; int numberOfRules;
            str = sr.ReadLine().Trim();
            numberOfRules = int.Parse(str.Substring(str.IndexOf(":") + 1));


            List<TsukamotoIfThenFuzzyRule> AllRules = new List<TsukamotoIfThenFuzzyRule>();
            for (int i = 0; i < numberOfRules; i++)
            {
                List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
                GenericFuzzySet consequence = null;
                TsukamotoIfThenFuzzyRule aRule = new TsukamotoIfThenFuzzyRule(antecedents, consequence);
                aRule.ReadModel(sr);
                AllRules.Add(aRule);
            }

            allRules = AllRules.ToArray();
        }
    }
}
