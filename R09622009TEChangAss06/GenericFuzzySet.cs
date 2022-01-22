using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace R09622009TEChangAss06
{
    public enum DefuzzificationType
    {
        COA, BOA, MOM, SOM, LOM
    }

    public delegate void FSParameterHandler();
    public class GenericFuzzySet
    {
        #region DATAFIELDS

        protected static Random sharedRND = new Random(); // Only one obejct is created and shared by all the children
        protected string name;
        protected double[] parameters;
        protected Universe theUniverse;
        protected Series theSeries = null;
        protected bool showMFCurve = false;
        protected TreeNode theNode;
        protected double[] bound;

        #endregion



        #region PROPERTIES
        [
            Category("Identity"),
            Description("Whether the function is monotonic or not.")
        ]
        public virtual bool IsMonotonic
        {
            get
            {
                bool check = true;
                if(GetMembershipDegree(TheUniverse.Minimum) < GetMembershipDegree(TheUniverse.Maximum))
                {
                    for(double x = TheUniverse.Minimum; x <= TheUniverse.Maximum; x += TheUniverse.Increment)
                    {
                        if (GetMembershipDegree(x) > GetMembershipDegree(x + TheUniverse.Increment)) return false; 
                    }
                }
                else
                {
                    for (double x = TheUniverse.Minimum; x <= TheUniverse.Maximum; x += TheUniverse.Increment)
                    {
                        if (GetMembershipDegree(x) < GetMembershipDegree(x + TheUniverse.Increment)) return false;
                    }
                }
                return check;
            }
        }

        [
            Category("Defuzzification value"),
            Description("Centroid of area.")
        ]
        public virtual double COACrispValue
        {
            // Centroid of area for difuzzification
            get
            {
                double area = 0.0, areaTimesDistance = 0.0;
                for (double x = TheUniverse.Minimum; x <= TheUniverse.Maximum; x += TheUniverse.Increment)
                {
                    double deltaArea = GetMembershipDegree(x) * TheUniverse.Increment;
                    area += deltaArea;
                    areaTimesDistance += deltaArea * x;
                }
                if (area == 0) return Math.Round((TheUniverse.Maximum + TheUniverse.Minimum) / 2,2);
                else return Math.Round(areaTimesDistance / area, 2);
            }
        }
        [
            Category("Defuzzification value"),
            Description("Bisector of area.")
        ]
        public virtual double BOACrispValue
        {
            // Bisector of area for difuzzification
            get
            {
                double left = TheUniverse.Minimum, right = TheUniverse.Maximum;
                double A = 0.0, B = 0.0;
                while(left < right)
                {
                    if (A == 0.0 & B == 0.0)
                    {
                        A += GetMembershipDegree(left) * TheUniverse.Increment;
                        B += GetMembershipDegree(right) * TheUniverse.Increment;
                    }
                    if (A > B)
                    {
                        right -= TheUniverse.Increment;
                        B += GetMembershipDegree(right) * TheUniverse.Increment;
                    }
                    else
                    {
                        left += TheUniverse.Increment;
                        A += GetMembershipDegree(left) * TheUniverse.Increment;
                    }
                }
                return Math.Round((left + right) / 2, 2);
            }
        }


        [
            Category("Defuzzification value"),
            Description("Mean of maximum value.")
        ]
        public virtual double MOMCrispValue
        {
            // Mean of Maximum for difuzzification
            get
            {
                double maximum = 0.0, ZLeft = 0.0, ZRight = 0.0;
                for (double x = TheUniverse.Minimum; x <= TheUniverse.Maximum; x += TheUniverse.Increment)
                {
                    maximum = GetMembershipDegree(x) > maximum ? GetMembershipDegree(x) : maximum; 
                }
                //double area = 0.0, areaTimesDistance = 0.0;
                //for (double x = TheUniverse.Minimum; x <= TheUniverse.Maximum; x += TheUniverse.Increment)
                //{
                //    if (GetMembershipDegree(x) == maximum)
                //    {
                //        double deltaArea = GetMembershipDegree(x) * TheUniverse.Increment;
                //        area += deltaArea;
                //        areaTimesDistance += deltaArea * x;
                //    }
                //}
                //if (area == 0) return Math.Round((TheUniverse.Maximum + TheUniverse.Minimum) / 2, 2);
                //else return Math.Round(areaTimesDistance / area, 2);
                for (double x = TheUniverse.Minimum; x <= TheUniverse.Maximum; x += TheUniverse.Increment)
                {
                    if (GetMembershipDegree(x) == maximum)
                    {
                        ZLeft = x;
                        break;
                    }
                }
                for (double x = TheUniverse.Maximum; x >= TheUniverse.Minimum; x -= TheUniverse.Increment)
                {
                    if (Math.Abs(GetMembershipDegree(x) - maximum) < 0.001)
                    {
                        ZRight = x;
                        break;
                    }
                }
                return Math.Round((ZLeft + ZRight) / 2, 2);
            }
        }



        [
            Category("Defuzzification value"),
            Description("Smallest of maximum value.")
        ]
        public virtual double SOMCrispValue
        {
            // Smallest of Maximum for difuzzification
            get
            {
                double maximum = 0.0;
                for (double x = TheUniverse.Minimum; x <= TheUniverse.Maximum; x += TheUniverse.Increment)
                {
                    maximum = GetMembershipDegree(x) > maximum ? GetMembershipDegree(x) : maximum;
                }
                
                for (double x = TheUniverse.Minimum; x <= TheUniverse.Maximum; x += TheUniverse.Increment)
                {
                    if (GetMembershipDegree(x) == maximum)
                    {
                        return Math.Round(x, 2);
                    }
                }
                return 99999; // For single maximum FS, override with the midpoint.
            }
        }

        [
            Category("Defuzzification value"),
            Description("Largest of maximum value.")
        ]
        public virtual double LOMCrispValue
        {
            // Largeest of Maximum for difuzzification
            get
            {
                double maximum = 0.0;
                for (double x = TheUniverse.Minimum; x <= TheUniverse.Maximum; x += TheUniverse.Increment)
                {
                    maximum = GetMembershipDegree(x) > maximum ? GetMembershipDegree(x) : maximum;
                }

                for (double x = TheUniverse.Maximum; x >= TheUniverse.Minimum; x -= TheUniverse.Increment)
                {
                    if (Math.Abs(GetMembershipDegree(x) - maximum) < 0.001)
                    {
                        return Math.Round(x, 2);
                    }
                }
                return 99999; 
            }
        }

        [
            Category("Identity"),
            Description("The maximal degree of the fuzzy set. For a normal fuzzy set, the value should be 1.0.")
        ]
        public virtual double MaxDegree
        {
            get => 1.0; // Generally, all fuzzy set fulfill the normality condition, the maxmimal degree should be 1.
            // However, when the condition is not hold, we should overide it
        }

        [
            Category("Setting"),
            Description("Whether to show the curve or not.")
        ]
        public bool ShowMFCure
        {
            set
            {
                showMFCurve = value;
                if (showMFCurve)
                {
                    if (theSeries == null)
                    {
                        theSeries = new Series();
                        theSeries.ChartType = SeriesChartType.Line;
                        PopulateMFPoints();
                        theSeries.ChartArea = theUniverse.AreaName;
                        theSeries.Name = name;
                        theSeries.Legend = theUniverse.AreaName;
                    }
                    // How to let the user to choose whether show it or not?
                    // Maybe add another event
                    else
                    {
                        theSeries.Enabled = true;
                    }
                }
                else
                {
                    // Nothing happened
                    theSeries.Enabled = false;
                }
            }
            get => showMFCurve;
        }

        [
            Browsable(false)
        ]
        public Universe TheUniverse { get => theUniverse; }

        [
            Category("Identity"),
            Description("The (user definded) name of the function.")
        ]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                if (theSeries != null)
                    theSeries.Name = name;
                theNode.Text = name;
                //  How to change the name dynamically?
                NameChanged();
            }
        }
        #endregion

        #region SERIVICE FUNCTIONS
        public event EventHandler FSNameChanged;
        protected void NameChanged()
        {
            if(FSNameChanged != null) FSNameChanged(this, null);
        }
        protected void reName()
        {
            if (theSeries != null)
            {
                theSeries.Name = name;
                if(theNode != null) theNode.Text = name;
                NameChanged(); // Keep call it until FSNameChanged == null
            }
            else
            {
                NameChanged();
            }
        }

        public event FSParameterHandler ParameterChange; // User defined EventHandler
        protected void ParameterChanged()
        {
            // 猜測：因為所有 Function 都繼承 GenericFuzzySet，所以當有參數改變時，全部都會被重畫
            if(theSeries != null)
            {
                PopulateMFPoints(); 
            }
            // trigger ParameterChanged event
            if (ParameterChange != null) ParameterChange();
        }
        void PopulateMFPoints()
        {
            if (theSeries != null)
            {
                theSeries.Points.Clear();
                for (double x = theUniverse.Minimum; x <= theUniverse.Maximum; x = x + theUniverse.Increment)
                {
                    double y;
                    y = GetMembershipDegree(x);
                    theSeries.Points.AddXY(x, y);
                }
            }
        }

        public void AddSeriresToChart(Chart cht, SeriesChartType type = SeriesChartType.Line, 
                                      ChartHatchStyle hatch = ChartHatchStyle.None)
        {
            theSeries.BackHatchStyle = hatch;
            theSeries.ChartType = type;
            cht.Series.Add(theSeries);
            cht.Series[cht.Series.Count - 1].BorderWidth = 3;
        }

        public virtual double GetMembershipDegree(double x)
        {
            throw new NotImplementedException();
        }

        protected double CalculateMaxDegree()
        {
            // start from the MinValue, find the maximal degree of the fuzzy set
            double max = double.MinValue;
            for (double x = TheUniverse.Minimum; x <= TheUniverse.Maximum; x = x + TheUniverse.Increment)
            {
                double degree = GetMembershipDegree(x);
                if (degree > max) max = degree;
            }
            return max;
        }

        public void SetTreeNode(TreeNode tn)
        {
            theNode = tn;
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual double GetUniverseValueForADegree(double degree)
        {
            // The author is debted to Ann Shu for the inspiration of this algorithm 
            double value = 0.0;
            if(GetMembershipDegree(theUniverse.Minimum) < GetMembershipDegree(theUniverse.Maximum))
            {
                if(GetMembershipDegree(theUniverse.Minimum) > degree)
                {
                    value = theUniverse.Minimum;
                    return value;
                }
                else if(GetMembershipDegree(theUniverse.Maximum) < degree)
                {
                    value = theUniverse.Maximum;
                    return value;
                }
            }
            else
            {
                if (GetMembershipDegree(theUniverse.Minimum) < degree)
                {
                    value = theUniverse.Minimum;
                    return value;
                }
                else if (GetMembershipDegree(theUniverse.Maximum) > degree)
                {
                    value = theUniverse.Maximum;
                    return value;
                }
            }

            for (double x = theUniverse.Minimum; x <= theUniverse.Maximum; x += TheUniverse.Increment)
            {
                double difference = Math.Abs(degree - GetMembershipDegree(x));
                if (difference < 0.01 & GetMembershipDegree(x) != GetMembershipDegree(x + TheUniverse.Increment))
                {
                    value = x;
                }
            }
            return value;
        }

        public virtual void SaveModel(StreamWriter sw)
        {
            sw.WriteLine($"Name:{Name}");
            sw.WriteLine($"HashCode:{this.GetHashCode()}");
            if (parameters != null)
            {
                sw.WriteLine($"NumberOfParameters:{parameters.Length}");
                foreach (double p in parameters)
                    sw.WriteLine($"ParValue:{p}");
            }
            else
            {
                sw.WriteLine($"NumberOfParameters:0");
            }
            sw.WriteLine($"ShowMF:{showMFCurve}");
        }

        [Browsable(false)]
        public int HashCodeStored { set; get; }

        public virtual void ReconnectFussySetReferences(List<GenericFuzzySet> existingFSs)
        {
            //
        }

        public virtual void ReadModel(StreamReader sr, List<GenericFuzzySet> existingFSs)
        {
            string str;
            str = sr.ReadLine().Trim();
            Name = str.Substring(str.IndexOf(":") + 1);
            str = sr.ReadLine().Trim();
            HashCodeStored = int.Parse(str.Substring(str.IndexOf(":") + 1));
            int numberOfParameters;
            str = sr.ReadLine().Trim();
            numberOfParameters = int.Parse(str.Substring(str.IndexOf(":") + 1));

            if(numberOfParameters > 0)
            {
                parameters = new double[numberOfParameters];
                for(int i = 0; i < numberOfParameters; i++)
                {
                    str = sr.ReadLine().Trim();
                    parameters[i] = double.Parse(str.Substring(str.IndexOf(":") + 1));
                }
            }

            str = sr.ReadLine().Trim();
            showMFCurve = bool.Parse(str.Substring(str.IndexOf(":") + 1));

        }
        #endregion

        #region UNIARY OPERATOR OVERLOADING
        // It must be static. "operator" is a key word.
        // This class is used to overload the FS operators.

        public static UnaryOperatedFS operator !(GenericFuzzySet operand)
        {
            // "!A" -> Negation operator
            UnaryFSOperator Operator = new NegateFSOperator();
            UnaryOperatedFS result = new UnaryOperatedFS(Operator, operand);
            return result;
        }
        public static GenericFuzzySet operator +(GenericFuzzySet operand)
        {
            // "+A" -> Concentration operator
            UnaryFSOperator Operator = new ConcentrationFSOperator();
            UnaryOperatedFS result = new UnaryOperatedFS(Operator, operand);
            return result;
        }
        public static GenericFuzzySet operator -(GenericFuzzySet operand)
        {
            // "-A" -> Dilation operator
            UnaryFSOperator Operator = new DilationFSOperator();
            UnaryOperatedFS result = new UnaryOperatedFS(Operator, operand);
            return result;
        }
        public static UnaryOperatedFS operator -(double cutValue, GenericFuzzySet operand)
        {
            // "cutValue - A" -> Value cut operator
            UnaryFSOperator Operator = new CutFSOperator(cutValue);
            UnaryOperatedFS result = new UnaryOperatedFS(Operator, operand);
            return result;
        }
        public static UnaryOperatedFS operator *(double ScaleValue, GenericFuzzySet operand)
        {
            // "ScaleValue * A" -> Value scale operator
            UnaryFSOperator Operator = new ScaleFSOperator(ScaleValue);
            UnaryOperatedFS result = new UnaryOperatedFS(Operator, operand);
            return result;
        }
        public static UnaryOperatedFS operator ++(GenericFuzzySet operand)
        {
            // "++A" -> Intensification operator
            UnaryFSOperator Operator = new IntensificationFSOperator();
            UnaryOperatedFS result = new UnaryOperatedFS(Operator, operand);
            return result;
        }
        public static UnaryOperatedFS operator --(GenericFuzzySet operand)
        {
            // "--A" -> Diminish operator
            UnaryFSOperator Operator = new DiminishFSOperator();
            UnaryOperatedFS result = new UnaryOperatedFS(Operator, operand);
            return result;
        }
        #endregion

        #region BINARY OPERATOR OVERLOADING
        public static GenericFuzzySet operator &(GenericFuzzySet operand1, GenericFuzzySet operand2)
        {
            // "A&B" -> Intersection operator
            BinaryFSOperator op = new IntersectionFSOperator();
            BinaryOperatedFS bFS = new BinaryOperatedFS(op, operand1, operand2);
            return bFS;
        }

        public static GenericFuzzySet operator |(GenericFuzzySet operand1, GenericFuzzySet operand2)
        {
            // "A|B" -> Union operator
            BinaryFSOperator op = new UnionFSOperator();
            BinaryOperatedFS bFS = new BinaryOperatedFS(op, operand1, operand2);
            return bFS;
        }
        #endregion





        #region CONSTRUCTION
        public GenericFuzzySet(Universe univ)
        {
            theUniverse = univ;
            // subscribe event from universe class
            theUniverse.ParameterChanged += TheUniverse_ParameterChanged;
        }

        private void TheUniverse_ParameterChanged(object sender, EventArgs e)
        {
            if (theUniverse != null)
            {
                PopulateMFPoints();
            }
        }
        #endregion



    }
}
