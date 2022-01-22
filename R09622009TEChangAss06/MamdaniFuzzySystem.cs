using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    public class MamdaniFuzzySystem
    {
        // Data members
        MamdaniIfThenFuzzyRule[] allRules;

        public MamdaniIfThenFuzzyRule[] AllRules { get => allRules; }

        public GenericFuzzySet FuzzyInFuzzyOutInferencing(List<GenericFuzzySet> conditions, bool UseCutOperator = true)
        {
            GenericFuzzySet resultedFS = null;
            for (int r = 0; r < allRules.Length; r++)
            {
                if (r == 0)
                {
                    resultedFS = allRules[r].FuzzyInFuzzyOutInferencing(conditions, UseCutOperator);
                }
                else
                {
                    resultedFS |= allRules[r].FuzzyInFuzzyOutInferencing(conditions, UseCutOperator);
                }

            }
            return resultedFS;
        }

        public GenericFuzzySet CrispInFuzzyOutInferencing(double[] conditions, bool UseCutOperator = true)
        {
            // loop through all rules to get united output (cut or scaled) fuzzy sets
            GenericFuzzySet resultedFS = null;
            for (int r = 0; r < allRules.Length; r++)
            {
                if (r == 0)
                {
                    resultedFS = allRules[r].CrispInFuzzyOutInferencing(conditions, UseCutOperator);
                }
                else
                {
                    resultedFS |= allRules[r].CrispInFuzzyOutInferencing(conditions, UseCutOperator);
                }
                
            }
            return resultedFS;
        }

        public double CrispInCrispOutInferencing(double[] conditions, DefuzzificationType DefuzzificationMode, bool UseCutOperator = true)
        {
            // Crisp input conditions -> Fuzzy output conclusion -> Crisp defuzzification value
            GenericFuzzySet resultedFS = CrispInFuzzyOutInferencing(conditions, UseCutOperator);
            double crispValue = 0.0;
            // return defuzzified crisp value
            switch(DefuzzificationMode)
            {
                case DefuzzificationType.COA:
                    crispValue = resultedFS.COACrispValue;
                    break;
                case DefuzzificationType.BOA:
                    crispValue = resultedFS.BOACrispValue;
                    break;
                case DefuzzificationType.MOM:
                    crispValue = resultedFS.MOMCrispValue;
                    break;
                case DefuzzificationType.SOM:
                    crispValue = resultedFS.SOMCrispValue;
                    break;
                case DefuzzificationType.LOM:
                    crispValue = resultedFS.LOMCrispValue;
                    break;
            }
            return crispValue;
        }

        #region CONSTRUCTOR
        public MamdaniFuzzySystem()
        {
            // Default constructor
        }

        public void UpdateRuleSet(MamdaniIfThenFuzzyRule[] allRules)
        {
            this.allRules = allRules;
        }

        public MamdaniFuzzySystem(List<MamdaniIfThenFuzzyRule> ruleList)
        {
            allRules = ruleList.ToArray();

            //allRules = new IfThenFuzzyRule[ruleList.Count];
            //for(int i = 0; i < allRules.Length; i++)
            //    allRules[i] = ruleList[i];
        }

        public void SaveModel(StreamWriter sw)
        {
            sw.WriteLine($"NumberOfRules:{allRules.Length}");
            for(int i = 0; i < allRules.Length; i++)
            {
                allRules[i].SaveModel(sw);
            }
        }

        public void ReadModel(StreamReader sr)
        {
            string str; int numberOfRules;
            str = sr.ReadLine().Trim();
            numberOfRules = int.Parse(str.Substring(str.IndexOf(":") + 1));

            
            List<MamdaniIfThenFuzzyRule> AllRules = new List<MamdaniIfThenFuzzyRule>();
            for(int i = 0; i < numberOfRules; i++)
            {
                List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
                GenericFuzzySet consequence = null;
                MamdaniIfThenFuzzyRule aRule = new MamdaniIfThenFuzzyRule(antecedents, consequence);
                aRule.ReadModel(sr);
                AllRules.Add(aRule);
            }

            allRules = AllRules.ToArray();
        }
        #endregion
    }
}
