using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    public class SugenoFuzzySystem
    {
        //public bool OutputAveraged { get; set; } = true;
        //SugenoIfThenFuzzyRule arule = new SugenoIfThenFuzzyRule(antecedents);
        
        SugenoIfThenFuzzyRule[] allRules;
        public SugenoIfThenFuzzyRule[] AllRules { get => allRules; }

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

        public SugenoFuzzySystem()
        {
            // Default constructor
        }
        public void UpdateRuleSet(SugenoIfThenFuzzyRule[] allRules)
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


            List<SugenoIfThenFuzzyRule> AllRules = new List<SugenoIfThenFuzzyRule>();
            for (int i = 0; i < numberOfRules; i++)
            {
                List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
                int equationID = 0;
                SugenoIfThenFuzzyRule aRule = new SugenoIfThenFuzzyRule(antecedents, equationID);
                aRule.ReadModel(sr);
                AllRules.Add(aRule);
            }

            allRules = AllRules.ToArray();
        }
    }
}
