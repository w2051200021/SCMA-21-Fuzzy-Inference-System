using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    public class SugenoIfThenFuzzyRule
    {
        // A single Sugeno fuzzy rule
        List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
        int equationID;

        List<int> antecedentHashCodes = new List<int>();

        public List<GenericFuzzySet> Antecedents { get => antecedents; }
        public int EquationID { get => equationID; }

        public SugenoIfThenFuzzyRule(List<GenericFuzzySet> antecedents, int EquationID)
        {
            this.antecedents = antecedents;
            this.equationID = EquationID;
        }

        public double GetOutputValue(double[] inputs)
        {
            double SugenoOutput = 0.0;
            switch (equationID)
            {
                case 0: // Y = 0.1 * X + 6.4 
                    SugenoOutput = 0.1 * inputs[0] + 6.4;
                    break;
                case 1: // Y = -0.5 * X + 4 
                    SugenoOutput = -0.5 * inputs[0] + 4;
                    break;
                case 2: // y = x - 2
                    SugenoOutput = inputs[0] - 2;
                    break;
                case 3: // Z = -X + Y + 1
                    SugenoOutput = -inputs[0] + inputs[1] + 1;
                    break;
                case 4: // Z = -Y + 3
                    SugenoOutput = -inputs[1] + 3;
                    break;
                case 5: // Z = -X + 3
                    SugenoOutput = -inputs[0] + 3;
                    break;
                case 6: // Z = X + Y + 2
                    SugenoOutput = inputs[0] + inputs[1] + 2;
                    break;
            }
            return SugenoOutput;
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
                inputs[i] = conditions[i].LOMCrispValue;
                double w = (antecedents[i] & conditions[i]).MaxDegree;
                firingStrength = firingStrength > w ? w : firingStrength;
            }
            Output = GetOutputValue(inputs);
            
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
            Output = GetOutputValue(conditions);

            return Output;
        }
        public void SaveModel(StreamWriter sw)
        {
            sw.WriteLine($"NumberOfAntecedents:{antecedents.Count}");
            foreach (GenericFuzzySet fs in antecedents)
            {
                sw.WriteLine($"AntecedentFSCode:{fs.GetHashCode()}");
            }
            sw.WriteLine($"EquationID:{equationID}");
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
            equationID = int.Parse(str.Substring(str.IndexOf(":") + 1));
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
        }
    }
}
