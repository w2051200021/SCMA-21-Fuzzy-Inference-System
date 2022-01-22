using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    public class MamdaniIfThenFuzzyRule
    {
        // A single fuzzy rule.
        List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
        GenericFuzzySet consequence = null;

        List<int> antecedentHashCodes = new List<int>();
        int consequenceHashCode;

        public List<GenericFuzzySet> Antecedents { get => antecedents; }
        public GenericFuzzySet Consequence { get => consequence; }

        public MamdaniIfThenFuzzyRule(List<GenericFuzzySet> antecedents, GenericFuzzySet consequences)
        {
            this.antecedents = antecedents;
            this.consequence = consequences;
        }


        public GenericFuzzySet FuzzyInFuzzyOutInferencing(List<GenericFuzzySet> condition, bool UseCutOperator = true)
        {
            GenericFuzzySet conclusion = null;
            int numberOfAntecedents = antecedents.Count;
            double firingStrength = 1.0;
            for (int i = 0; i < numberOfAntecedents; i++)
            {
                double w = (antecedents[i] & condition[i]).MaxDegree;
                firingStrength = firingStrength > w ? w : firingStrength;
            }
            if (UseCutOperator) conclusion = firingStrength - consequence;
            else conclusion = firingStrength * consequence;

            return conclusion;
        }

        public GenericFuzzySet CrispInFuzzyOutInferencing(double[] condition, bool IsCutOperator = true)
        {
            GenericFuzzySet conclusion = null;
            int numberOfAntecedents = antecedents.Count;
            //antecedents[j].GetMembershipDegree(condition[j])
            double firingStrength = 1.0;
            for (int i = 0; i < numberOfAntecedents; i++)
            {
                double w = antecedents[i].GetMembershipDegree(condition[i]);
                firingStrength = firingStrength > w ? w : firingStrength;
            }
            if(IsCutOperator) conclusion = firingStrength - consequence;
            else conclusion = firingStrength * consequence;
            return conclusion;
        }

        public void SaveModel(StreamWriter sw)
        {
            sw.WriteLine($"NumberOfAntecedents:{antecedents.Count}");
            foreach(GenericFuzzySet fs in antecedents)
            {
                sw.WriteLine($"AntecedentFSCode:{fs.GetHashCode()}");
            }
            sw.WriteLine($"Consequence:{consequence.GetHashCode()}");
        }

        public void ReadModel(StreamReader sr)
        {
            int number;
            string str = sr.ReadLine().Trim();
            number = int.Parse(str.Substring(str.IndexOf(":") + 1));
            antecedentHashCodes.Clear();
            for(int i = 0; i < number; i++)
            {
                str = sr.ReadLine().Trim();
                antecedentHashCodes.Add(int.Parse(str.Substring(str.IndexOf(":") + 1)));
            }
            str = sr.ReadLine().Trim();
            consequenceHashCode = int.Parse(str.Substring(str.IndexOf(":") + 1));
        }

        public void ReconnectFuzzySetReferences(List<GenericFuzzySet> existingFSs)
        {
            antecedents.Clear();
            foreach(int code in antecedentHashCodes)
            {
                foreach(GenericFuzzySet fs in existingFSs)
                {
                    if(fs.HashCodeStored == code)
                    {
                        antecedents.Add(fs);
                        break;
                    }
                }
            }
            foreach(GenericFuzzySet fs in existingFSs)
            {
                if(fs.HashCodeStored == consequenceHashCode)
                {
                    consequence = fs;
                    break;
                }
            }
        }
    }
}
