using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R09622009TEChangAss06
{
    public class BinaryOperatedFS : GenericFuzzySet
    {
        static int currentCount = 1;
        static int count = 1;
        static List<string> lst = new List<string>();

        BinaryFSOperator theOperator;
        GenericFuzzySet theOperand_1;
        GenericFuzzySet theOperand_2;
        int operand1HashCode;
        int operand2HashCode;
        #region PROPERTIES
        [
            Category("Operator"),
            Description("The object name of the operator.")
        ]
        [TypeConverter(typeof(ExpandableObjectConverter))] //Damnnn
        public BinaryFSOperator TheOperator
        {
            get => theOperator;
        }
        #endregion

        public BinaryOperatedFS(Universe u) : base(u)
        {
            // A default constructor simply for ModelRead function
        }

        public BinaryOperatedFS(BinaryFSOperator Operator, GenericFuzzySet fuzzySet_1, GenericFuzzySet fuzzySet_2) : base(fuzzySet_1.TheUniverse)
        {
            theOperator = Operator;
            theOperand_1 = fuzzySet_1;
            theOperand_2 = fuzzySet_2;
            name = $"{theOperand_1.Name}{theOperator.Name}{theOperand_2.Name}_{currentCount++}";

            // subscribe ParameterChange event from fuzzySet
            fuzzySet_1.ParameterChange += FuzzySet_ParameterChange;
            fuzzySet_1.FSNameChanged += FuzzySet_FSNameChanged;
            fuzzySet_2.ParameterChange += FuzzySet_ParameterChange;
            fuzzySet_2.FSNameChanged += FuzzySet_FSNameChanged;

            Operator.ParameterChanged += Operator_ParameterChanged;
        }

        private void Operator_ParameterChanged(object sender, EventArgs e)
        {
            ParameterChanged();
        }

        private void FuzzySet_FSNameChanged(object sender, EventArgs e)
        {
            // The NameChanged Event
            name = $"{theOperand_1.Name}{theOperator.Name}{theOperand_2.Name}";
            if (lst.Contains(name))
                name = $"{theOperand_1.Name}{theOperator.Name}{theOperand_2.Name}{count++}";
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
            return theOperator.CalcaulateValue(theOperand_1.GetMembershipDegree(x), theOperand_2.GetMembershipDegree(x));
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
            sw.WriteLine($"FSHashCode:{theOperand_1.GetHashCode()}");
            sw.WriteLine($"FSHashCode:{theOperand_2.GetHashCode()}");
        }

        public override void ReadModel(StreamReader sr, List<GenericFuzzySet> existingFSs)
        {
            base.ReadModel(sr, existingFSs);
            string str;
            str = sr.ReadLine().Trim();
            string typeName = str.Substring(str.IndexOf(":") + 1);
            Type opType = Type.GetType(typeName);
            if (typeName.Contains("Cut") | typeName.Contains("Scale"))
            {
                double alpha = 0.5;
                theOperator = (BinaryFSOperator)Activator.CreateInstance(opType, alpha);
                theOperator.ReadModel(sr);
            }
            else
            {
                theOperator = (BinaryFSOperator)Activator.CreateInstance(opType);
                theOperator.ReadModel(sr);
            }


            str = sr.ReadLine().Trim();
            operand1HashCode = int.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            operand2HashCode = int.Parse(str.Substring(str.IndexOf(":") + 1));
            ReconnectFussySetReferences(existingFSs);
        }

        public override void ReconnectFussySetReferences(List<GenericFuzzySet> existingFSs)
        {
            foreach (GenericFuzzySet fs in existingFSs)
            {
                if (fs.HashCodeStored == operand1HashCode)
                {
                    theOperand_1 = fs;
                    break;
                }
            }
            foreach (GenericFuzzySet fs in existingFSs)
            {
                if (fs.HashCodeStored == operand2HashCode)
                {
                    theOperand_2 = fs;
                    break;
                }
            }
        }
        #endregion 
    }
}
