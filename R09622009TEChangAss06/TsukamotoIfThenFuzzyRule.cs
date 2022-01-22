using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    public class TsukamotoIfThenFuzzyRule
    {
        // A single Tsukamoto fuzzy rule
        List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
        GenericFuzzySet consequence = null;

        List<int> antecedentHashCodes = new List<int>();
        int consequenceHashCode;

        public List<GenericFuzzySet> Antecedents { get => antecedents; }
        public GenericFuzzySet Consequence { get => consequence; }


        public TsukamotoIfThenFuzzyRule(List<GenericFuzzySet> antecedents, GenericFuzzySet consequences)
        {
            this.antecedents = antecedents;
            this.consequence = consequences;
        }

        public double FuzzyInCrispOutInferencing(List<GenericFuzzySet> conditions, out double firingStrength)
        {
            // For fuzzy singleton
            int numberOfAntecedents = antecedents.Count;
            double[] inputs = new double[numberOfAntecedents];
            double Output = 0.0;
            firingStrength = 1.0;
            for (int i = 0; i < numberOfAntecedents; i++)
            {
                double w = (antecedents[i] & conditions[i]).MaxDegree;
                firingStrength = firingStrength > w ? w : firingStrength;
            }
            Output = consequence.GetUniverseValueForADegree(firingStrength);

            return Output;
        }

        public double CrispInCrispOutInferencing(double[] conditions, out double firingStrength)
        {
            int numberOfAntecedents = conditions.Length;
            double Output = 0.0;
            firingStrength = 1.0;
            for (int i = 0; i < numberOfAntecedents; i++)
            {
                double w = antecedents[i].GetMembershipDegree(conditions[i]);
                firingStrength = firingStrength > w ? w : firingStrength;
            }
            Output = consequence.GetUniverseValueForADegree(firingStrength);

            return Output;
        }

        public void SaveModel(StreamWriter sw)
        {
            sw.WriteLine($"NumberOfAntecedents:{antecedents.Count}");
            foreach (GenericFuzzySet fs in antecedents)
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
            for (int i = 0; i < number; i++)
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
            foreach (int code in antecedentHashCodes)
            {
                foreach (GenericFuzzySet fs in existingFSs)
                {
                    if (fs.HashCodeStored == code)
                    {
                        antecedents.Add(fs);
                        break;
                    }
                }
            }
            foreach (GenericFuzzySet fs in existingFSs)
            {
                if (fs.HashCodeStored == consequenceHashCode)
                {
                    consequence = fs;
                    break;
                }
            }
        }
    }
}
