using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace R09622009TEChangAss06
{
    public class Universe
    {
        static int currentCount = 1;

        // private datafields
        // Data encapsulation Object-Oriented
        // private string name = "U";
        // double min = 0, max = 10;
        int resolution = 1000;

        TreeNode theNode;
        ChartArea theArea = new ChartArea();
        Legend theLegend = new Legend();

        public void SetTreeNode(TreeNode tn)
        {
            theNode = tn;
        }

        // override function inherited from object
        public override string ToString()
        {
            return $"Universe:{Name}";
        }

        #region PROPERTIES & EVENT

        public event EventHandler ParameterChanged;

        [
            Browsable(false)
        ]
        public string AreaName
        {
            get => theArea.Name;
        }

        //// in old c++ age
        //// getter
        //public string GetName()
        //{
        //    return name;
        //}
        //// setter
        //public void setName(string newName)
        //{
        //    // data integrity checking
        //    if (newName != "")
        //    {
        //        name = newName;
        //    }
        //}


        // Properties

        [
            Category("Identity"),
            Description("The name of the universe.")
        ]
        public string Name
        {
            get
            {
                return theArea.AxisX.Title;
            }
            set
            {
                // Integrity checking statements. only when the new value is valid
                // we update the related data
                if (value != "")
                {
                    theArea.AxisX.Title = value;
                    theNode.Text = value;
                }
            }
        }



        [
            Category("Axis Setting"),
            Description("The minimum value of the universe.")
        ]
        public double Minimum
        {
            get => theArea.AxisX.Minimum;
            set
            {
                // Guarding condition.
                // The tested result shows that when max-min < 0.5 the program would crash.
                if (value <= theArea.AxisX.Maximum - 0.5)
                {
                    theArea.AxisX.Minimum = value;
                }
                else 
                {
                    theArea.AxisX.Minimum = theArea.AxisX.Maximum - 0.5;
                }
                // Fire an event when the parameter is changed
                if (ParameterChanged != null) ParameterChanged(this, null);
                
            }
        }



        [
            Category("Axis Setting"),
            Description("The maximum value of the universe.")
        ]
        public double Maximum
        {
            get => theArea.AxisX.Maximum;
            set
            {
                // Guarding condition
                // The tested result shows that when max-min < 0.5 the program would crash.
                if (value >= theArea.AxisX.Minimum + 0.5)
                {
                    theArea.AxisX.Maximum = value;
                }
                else
                {
                    theArea.AxisX.Maximum = theArea.AxisX.Minimum + 0.5;
                }
                // Fire an event when the parameter is changed
                if (ParameterChanged != null) ParameterChanged(this, null);
                
            }
        }

        [
            Category("Plot Setting"),
            Description("The resolution of the universe.")
        ]
        public int Resolution
        {
            get => resolution;
            set
            {
                if (value < 10 || value > 3000) return;
                resolution = value;
                if (ParameterChanged != null) ParameterChanged(this, null);

            }
        }

        [
            Category("Plot Setting"),
            Description("The increment value of the universe.")
        ]
        public double Increment
        {
            // Show the increment value of the universe of X. (Rounded off)
            get => Math.Round((theArea.AxisX.Maximum - theArea.AxisX.Minimum) / (resolution - 1), 4);
        }

        #endregion


        public void SaveModel(StreamWriter sw)
        {
            sw.WriteLine($"Name:{Name}");
            sw.WriteLine($"LowerBound:{Minimum}");
            sw.WriteLine($"UpperBound:{Maximum}");
            sw.WriteLine($"Resolution:{resolution}");
        }

        public void ReadModel(StreamReader sr)
        {
            string str;
            str = sr.ReadLine().Trim();
            Name = str.Substring(str.IndexOf(":") + 1);
            str = sr.ReadLine().Trim();
            Minimum = double.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            Maximum = double.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            resolution = int.Parse(str.Substring(str.IndexOf(":") + 1));
        }


        // constructor (secret word: ctor + dounle Tab)
        public Universe(Chart theChart, bool output = false)
        {
           
            theArea.AxisX.Enabled = AxisEnabled.True;
            theArea.AxisX.Title = $"Universe{currentCount++}";  // special formatted 
            theArea.AxisX.Minimum = -5.0;
            theArea.AxisX.Maximum = 5.0;

            theArea.AxisY.Enabled = AxisEnabled.True;
            theArea.AxisY.Title = "Degree";
            theArea.AxisY.Minimum = -0.1;
            theArea.AxisY.Maximum = 1.1;

            if(output) theArea.BackColor = Color.Cornsilk;

            theChart.ChartAreas.Add(theArea);
            
            theLegend.Name = theArea.Name;
            theLegend.DockedToChartArea = theArea.Name;
            theLegend.IsDockedInsideChartArea = false;
            theLegend.Docking = Docking.Bottom;
            theLegend.BackColor = System.Drawing.Color.Transparent;
            theChart.Legends.Add(theLegend);
        }

    }
}
