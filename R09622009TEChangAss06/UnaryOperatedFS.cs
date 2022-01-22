using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    public class UnaryOperatedFS : GenericFuzzySet
    {
        static int currentCount = 1;
        static int count = 1;
        static List<string> lst = new List<string>();
        UnaryFSOperator theOperator;
        GenericFuzzySet theOperand;
        int operandHashCode;

        #region PROPERTIES
        [
            Category("Operator"),
            Description("The object name of the operator.")
        ]
        [TypeConverter(typeof(ExpandableObjectConverter))] //Damnnn
        public UnaryFSOperator TheOperator
        {
            get => theOperator;
        }
        #endregion

        public UnaryOperatedFS(Universe u) : base(u)
        {
            // A default constructor simply for ModelRead function
        }

        public UnaryOperatedFS(UnaryFSOperator Operator, GenericFuzzySet fuzzySet) : base(fuzzySet.TheUniverse)
        {
            theOperator = Operator;
            theOperand = fuzzySet;
            name = $"{theOperator.Name}{theOperand.Name}_{currentCount++}";

            // subscribe ParameterChange event from fuzzySet
            fuzzySet.ParameterChange += FuzzySet_ParameterChange;
            fuzzySet.FSNameChanged += FuzzySet_FSNameChanged;
            // subscribe ParameterChange event from operator, differnent from the above
            Operator.ParameterChanged += Operator_ParameterChanged;
        }

        private void FuzzySet_FSNameChanged(object sender, EventArgs e)
        {
            // The NameChanged Event
            name = $"{theOperator.Name}{theOperand.Name}";
            if(lst.Contains(name))
                name = $"{theOperator.Name}{theOperand.Name}{count++}";
            else
                lst.Add(name);
            
            reName();
        }

        private void Operator_ParameterChanged(object sender, EventArgs e)
        {
            ParameterChanged();
            // The NameChanged Event
            name = $"{theOperator.Name}{theOperand.Name}";
            if (lst.Contains(name))
                name = $"{theOperator.Name}{theOperand.Name}{count++}";
            else
                lst.Add(name);
            reName();
        }

        private void FuzzySet_ParameterChange()
        {
            ParameterChanged();
        }

        #region OVERRIDE
        public override double GetMembershipDegree(double x)
        {
            return theOperator.CalcaulateValue(theOperand.GetMembershipDegree(x));
        }

        public override double MaxDegree => CalculateMaxDegree();

        public override void SaveModel(StreamWriter sw)
        {
            base.SaveModel(sw);
            // Save our particular data: first the operator
            Type opType = theOperator.GetType();
            sw.WriteLine($"OperatorTypeName:{opType.FullName}");
            theOperator.SaveModel(sw);
            // Second, the FS
            sw.WriteLine($"FSHashCode:{theOperand.GetHashCode()}");

        }

        public override void ReadModel(StreamReader sr, List<GenericFuzzySet> existingFSs)
        {
            base.ReadModel(sr, existingFSs);
            string str;
            str = sr.ReadLine().Trim();
            string typeName = str.Substring(str.IndexOf(":") + 1);
            Type opType = Type.GetType(typeName);
            if(typeName.Contains("Cut") | typeName.Contains("Scale"))
            {
                double alpha = 0.5;
                theOperator = (UnaryFSOperator)Activator.CreateInstance(opType, alpha);
                theOperator.ReadModel(sr);
            }
            else
            {
                theOperator = (UnaryFSOperator) Activator.CreateInstance(opType);
                theOperator.ReadModel(sr);
            }
            

            str = sr.ReadLine().Trim();
            operandHashCode = int.Parse(str.Substring(str.IndexOf(":") + 1));
            ReconnectFussySetReferences(existingFSs);
        }

        public override void ReconnectFussySetReferences(List<GenericFuzzySet> existingFSs)
        {
            foreach(GenericFuzzySet fs in existingFSs)
            {
                if(fs.HashCodeStored == operandHashCode)
                {
                    theOperand = fs;
                    break;
                }
            }
        }

        #endregion
    }
}
