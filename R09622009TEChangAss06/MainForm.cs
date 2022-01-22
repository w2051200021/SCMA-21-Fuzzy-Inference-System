using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace R09622009TEChangAss06
{
    public partial class MainForm : Form
    {
        // Some global variables
        int FuzzySystemMode = 1;    // 1 for Mamdani, 2 for Sugeno, 3 for Tsukamoto
        int outputIndex = -1;       // Record the index of output universe
        bool output = false;        // Check whether it is output universe and change the universe color
        bool UseCutOperator = true; // Whether we use cut operator or scale operator to compute the conclusion
        bool UseAverage = true;     // Whether we use weighted average or sum for Sugeno and Tsukamoto system

        MamdaniFuzzySystem mamdaniFuzzySystem = new MamdaniFuzzySystem();
        SugenoFuzzySystem sugenoFuzzySystem = new SugenoFuzzySystem();
        TsukamotoFuzzySystem tsukamotoFuzzySystem = new TsukamotoFuzzySystem();

        public void SaveModel(string filePath)
        {
            StreamWriter sw = new StreamWriter(filePath);
            // store fuzzy system mode
            if (FuzzySystemMode == 1)
            {
                sw.WriteLine($"Model:Mamdani");
                if (UseCutOperator) sw.WriteLine($"UseCutOperator:1");
                else sw.WriteLine($"UseCutOperator:0");
            }
            else if (FuzzySystemMode == 2)
            {
                sw.WriteLine($"Model:Sugeno");
                if (UseAverage) sw.WriteLine($"UseAverage:1");
                else sw.WriteLine($"UseAverage:0");
            }
            else
            {
                sw.WriteLine($"Model:Tsukamoto");
                if (UseAverage) sw.WriteLine($"UseAverage:1");
                else sw.WriteLine($"UseAverage:0");
            }
            // Store universe and FS data via the tree view
            int number = trvFuzzyModel.Nodes[0].Nodes.Count;
            // Input Universe
            sw.WriteLine($"NumberOfInputUnivers:{number}");
            Universe uni;
            for (int i = 0; i < number; i++)
            {
                uni = trvFuzzyModel.Nodes[0].Nodes[i].Tag as Universe;
                uni.SaveModel(sw);
                // Loop through the FSs defined in each universes
                int FSNumber = trvFuzzyModel.Nodes[0].Nodes[i].Nodes.Count;
                sw.WriteLine($"NumberOfFSs:{FSNumber}");
                for (int j = 0; j < FSNumber; j++)
                {
                    GenericFuzzySet fs = trvFuzzyModel.Nodes[0].Nodes[i].Nodes[j].Tag as GenericFuzzySet;
                    Type typeOfFS = fs.GetType();
                    sw.WriteLine($"FSTypeName:{typeOfFS.FullName}");

                    fs.SaveModel(sw);
                }
            }
            // Output universe
            // Add number of Output universe
            //int OutputNumber = trvFuzzyModel.Nodes[1].Nodes.Count;
            //sw.WriteLine($"NumberOfOutputUniverse:{OutputNumber}");
            //if(OutputNumber != 0)
            //{
            uni = trvFuzzyModel.Nodes[1].Nodes[0].Tag as Universe;
            uni.SaveModel(sw);
            // Loop through the FSs (equations) defined in output universes
            if (FuzzySystemMode != 2)
            {
                int OutputFSNumber = trvFuzzyModel.Nodes[1].Nodes[0].Nodes.Count;
                sw.WriteLine($"NumberOfFSs:{OutputFSNumber}");
                for (int j = 0; j < OutputFSNumber; j++)
                {
                    GenericFuzzySet fs = trvFuzzyModel.Nodes[1].Nodes[0].Nodes[j].Tag as GenericFuzzySet;
                    Type typeOfFS = fs.GetType();
                    sw.WriteLine($"FSTypeName:{typeOfFS.FullName}");
                    fs.SaveModel(sw);
                }
            }
            else
            {
                int OutputEqnNumber = trvFuzzyModel.Nodes[1].Nodes[0].Nodes.Count;
                sw.WriteLine($"NumberOfEqns:{OutputEqnNumber}");
                for (int j = 0; j < OutputEqnNumber; j++)
                {
                    int equationID = (int)trvFuzzyModel.Nodes[1].Nodes[0].Nodes[j].Tag;
                    string equationText = (string)trvFuzzyModel.Nodes[1].Nodes[0].Nodes[j].Text;
                    sw.WriteLine($"EquationID{j + 1}:{equationID}");
                    sw.WriteLine($"EquationName{j + 1}:{equationText}");
                }
            }
            
            

            // Save rules(1) create rules array to update rules of Fuzzy system
            switch(FuzzySystemMode)
            {
                case 1:
                    GenericFuzzySet consequence = null;
                    List<MamdaniIfThenFuzzyRule> rules = new List<MamdaniIfThenFuzzyRule>();
                    for (int j = 0; j < dgvRules.RowCount; j++)
                    {
                        List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
                        for (int i = 0; i < dgvRules.ColumnCount; i++)
                        {
                            if (i != outputIndex)
                            {
                                antecedents.Add(dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet);
                            }
                            else
                            {
                                consequence = dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet;
                            }
                        }
                        MamdaniIfThenFuzzyRule aRule = new MamdaniIfThenFuzzyRule(antecedents, consequence);
                        rules.Add(aRule);
                    }
                    List<GenericFuzzySet> conditions = new List<GenericFuzzySet>();
                    for (int i = 0; i < dgvCondition.ColumnCount; i++)
                        conditions.Add(dgvCondition.Rows[0].Cells[i].Value as GenericFuzzySet);

                    mamdaniFuzzySystem.UpdateRuleSet(rules.ToArray());
                    mamdaniFuzzySystem.SaveModel(sw);

                    // save condition information for the user
                    if (conditions[0] != null)
                    {
                        sw.WriteLine($"NumberOfAntecedents:{conditions.Count}");
                    
                        foreach (GenericFuzzySet fs in conditions)
                        {
                            sw.WriteLine($"conditionFSCode:{fs.GetHashCode()}");
                        }
                    }
                    else
                    {
                        sw.WriteLine($"NumberOfAntecedents:0");
                    }
                    break;

                case 2:
                    int EquationID = 0;
                    List<SugenoIfThenFuzzyRule> rules_S = new List<SugenoIfThenFuzzyRule>();

                    for (int j = 0; j < dgvRules.RowCount; j++)
                    {
                        List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
                        for (int i = 0; i < dgvRules.ColumnCount; i++)
                        {
                            if (i != outputIndex)
                            {
                                antecedents.Add(dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet);
                            }
                            else
                            {
                                EquationID = (int)dgvRules.Rows[j].Cells[i].Value;
                            }
                        }
                        SugenoIfThenFuzzyRule aRule = new SugenoIfThenFuzzyRule(antecedents, EquationID);
                        rules_S.Add(aRule);
                    }
                    List<GenericFuzzySet> conditions_S = new List<GenericFuzzySet>();
                    for (int i = 0; i < dgvCondition.ColumnCount; i++)
                        conditions_S.Add(dgvCondition.Rows[0].Cells[i].Value as GenericFuzzySet);

                    sugenoFuzzySystem.UpdateRuleSet(rules_S.ToArray());
                    sugenoFuzzySystem.SaveModel(sw);

                    // save condition information for the user
                    if (conditions_S[0] != null)
                    {
                        sw.WriteLine($"NumberOfAntecedents:{conditions_S.Count}");
                        foreach (GenericFuzzySet fs in conditions_S)
                        {
                            sw.WriteLine($"conditionFSCode:{fs.GetHashCode()}");
                        }
                    }
                    else
                    {
                        sw.WriteLine($"NumberOfAntecedents:0");
                    }
                    break;

                case 3:
                    GenericFuzzySet consequence_T = null;
                    List<TsukamotoIfThenFuzzyRule> rules_T = new List<TsukamotoIfThenFuzzyRule>();
                    for (int j = 0; j < dgvRules.RowCount; j++)
                    {
                        List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
                        for (int i = 0; i < dgvRules.ColumnCount; i++)
                        {
                            if (i != outputIndex)
                            {
                                antecedents.Add(dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet);
                            }
                            else
                            {
                                consequence_T = dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet;
                            }
                        }
                        TsukamotoIfThenFuzzyRule aRule = new TsukamotoIfThenFuzzyRule(antecedents, consequence_T);
                        rules_T.Add(aRule);
                    }
                    List<GenericFuzzySet> conditions_T = new List<GenericFuzzySet>();
                    for (int i = 0; i < dgvCondition.ColumnCount; i++)
                        conditions_T.Add(dgvCondition.Rows[0].Cells[i].Value as GenericFuzzySet);

                    tsukamotoFuzzySystem.UpdateRuleSet(rules_T.ToArray());
                    tsukamotoFuzzySystem.SaveModel(sw);

                    // save condition information for the user
                    if (conditions_T[0] != null)
                    {
                        sw.WriteLine($"NumberOfAntecedents:{conditions_T.Count}");
                        foreach (GenericFuzzySet fs in conditions_T)
                        {
                            sw.WriteLine($"conditionFSCode:{fs.GetHashCode()}");
                        }
                    }
                    else
                    {
                        sw.WriteLine($"NumberOfAntecedents:0");
                    }
                    break;
            }




            // button enability 
            sw.WriteLine("Button Enability");
            sw.WriteLine($"btnCreateAUniverse:{btnCreateAUniverse.Enabled}");
            sw.WriteLine($"btnReset:{btnReset.Enabled}");
            sw.WriteLine($"btnAddFS:false");
            sw.WriteLine($"btn_unary_op:false");
            sw.WriteLine($"btn_binary_op:false");
            sw.WriteLine($"btn_clear_lb:{btn_clear_lb.Enabled}");
            sw.WriteLine($"btn_clear_lb:{btnAddOutputEquation.Enabled}");
            sw.WriteLine($"btnAddRule:{btnAddRule.Enabled}");
            sw.WriteLine($"btnDeleteRule:{btnDeleteRule.Enabled}");
            sw.WriteLine($"btnInference:{btnInference.Enabled}");
            sw.WriteLine($"btn_final_inferencing:{btn_final_inferencing.Enabled}");
            // button visibility
            sw.WriteLine("Button Visibility");
            sw.WriteLine($"btn_final_inferencing:{btn_final_inferencing.Visible}");

            // combo box enability 
            sw.WriteLine("Combo Box Enability");
            sw.WriteLine($"cb_FS:false");
            sw.WriteLine($"cb_FS_monotonic:false");
            sw.WriteLine($"cb_unaryOperator:false");
            sw.WriteLine($"cb_binaryOperator:false");
            // combo box visibility
            sw.WriteLine("Combo Box Visibility");
            sw.WriteLine($"cb_FS:true");
            sw.WriteLine($"cb_FS_monotonic:false");

            // list box 
            sw.WriteLine("List Box Enability");
            sw.WriteLine($"lsbEuqations:{lsbEuqations.Enabled}");

            // group box visibility
            sw.WriteLine("Group Box Visibility");
            sw.WriteLine($"gb_Mamdani:{gb_Mamdani.Visible}");
            sw.WriteLine($"gb_ST:{gb_ST.Visible}");

            // TeeChart visibility
            sw.WriteLine("TeeChart Visibility");
            sw.WriteLine($"LineChart:{LineChart.Visible}");
            sw.WriteLine($"SurfaceChart:{SurfaceChart.Visible}");
            sw.WriteLine($"LineChart.Chart.Legend:{LineChart.Chart.Legend.Visible}");
            sw.WriteLine($"SurfaceChart.Chart.Legend:{SurfaceChart.Chart.Legend.Visible}");
            sw.WriteLine($"chartController1:{chartController1.Visible}");
            sw.WriteLine($"chartController2:{chartController2.Visible}");

            // split container distance
            sw.WriteLine($"splitContainer3:{splitContainer3.SplitterDistance}");


            sw.Close();
        }

        public void ReadModel(string filePath)
        {
            Reset();
            StreamReader sr = new StreamReader(filePath);
            string str;
            string modelType;
            int modelParameter;
            str = sr.ReadLine().Trim();
            modelType = str.Substring(str.IndexOf(":") + 1);
            str = sr.ReadLine().Trim();
            modelParameter = int.Parse(str.Substring(str.IndexOf(":") + 1));
            switch (modelType)
            {
                case "Mamdani":
                    FuzzySystemMode = 1;
                    lb_fuzzy_system.Text = "MAMDANI";
                    if (modelParameter == 1) cutToolStripMenuItem.PerformClick();
                    else scaleToolStripMenuItem.PerformClick();
                    break;
                case "Sugeno":
                    FuzzySystemMode = 2;
                    lb_fuzzy_system.Text = "SUGENO";
                    if (modelParameter == 1) weightedAverageToolStripMenuItem.PerformClick();
                    else weightedSumToolStripMenuItem.PerformClick();
                    break;
                case "Tsukamoto":
                    FuzzySystemMode = 3;
                    lb_fuzzy_system.Text = "SUGENO";
                    if (modelParameter == 1) weightedAverageToolStripMenuItem1.PerformClick();
                    else weightedSumToolStripMenuItem1.PerformClick();
                    break;

            }
            // Number of Input Universe
            int number;
            str = sr.ReadLine().Trim();
            number = int.Parse(str.Substring(str.IndexOf(":") + 1));
            trvFuzzyModel.Nodes[0].Nodes.Clear();
            Universe uni;
            List<GenericFuzzySet> AllExistingFSs = new List<GenericFuzzySet>();
            for (int i = 0; i < number; i++)
            {
                uni = new Universe(chtFuzzyModel);
                TreeNode tr = new TreeNode("");
                tr.Tag = uni;
                uni.SetTreeNode(tr); // Set text of the tree node
                trvFuzzyModel.Nodes[0].Nodes.Add(tr);
                uni.ReadModel(sr);

                // dgvRules
                dgvRules.Columns.Add(uni.Name, uni.Name);
                dgvRules.Columns[dgvRules.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvRules.Columns[dgvRules.Columns.Count - 1].Tag = uni;

                // dgvConditions
                dgvCondition.Columns.Add(uni.Name, uni.Name);
                dgvCondition.Columns[dgvCondition.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCondition.Columns[dgvCondition.Columns.Count - 1].Tag = uni;

                int FSNumber;
                str = sr.ReadLine().Trim();
                FSNumber = int.Parse(str.Substring(str.IndexOf(":") + 1));
                List<GenericFuzzySet> existingFS = new List<GenericFuzzySet>();
                for (int j = 0; j < FSNumber; j++)
                {
                    str = sr.ReadLine().Trim();
                    str = str.Substring(str.IndexOf(":") + 1); // Full name of FS type
                    // instantiate a particular type of FS
                    Type fsType = Type.GetType(str);
                    GenericFuzzySet fs = (GenericFuzzySet)Activator.CreateInstance(fsType, uni);
                    // creat and assign a tree node 
                    TreeNode aNode = new TreeNode(fs.Name);
                    aNode.Tag = fs;
                    trvFuzzyModel.Nodes[0].Nodes[i].Nodes.Add(aNode);
                    fs.SetTreeNode(aNode);
                    existingFS.Add(fs); AllExistingFSs.Add(fs);
                    fs.ReadModel(sr, existingFS);
                    fs.ShowMFCure = true;
                    fs.AddSeriresToChart(chtFuzzyModel);
                }
            }
            trvFuzzyModel.ExpandAll();

            // Output Universe
            // Add number of output universe
            //int Outputnumber;
            //str = sr.ReadLine().Trim();
            //Outputnumber = int.Parse(str.Substring(str.IndexOf(":") + 1));
            //if(Outputnumber != 0)
            //{
            uni = new Universe(chtFuzzyModel);
            TreeNode Output_tr = new TreeNode("");
            Output_tr.Tag = uni;
            uni.SetTreeNode(Output_tr); // Set text of the tree node
            trvFuzzyModel.Nodes[1].Nodes.Add(Output_tr);
            uni.ReadModel(sr);

            // dgvRules
            dgvRules.Columns.Add(uni.Name, uni.Name);
            dgvRules.Columns[dgvRules.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRules.Columns[dgvRules.Columns.Count - 1].Tag = uni;
            if (FuzzySystemMode != 2)
            {
                int OutputFSNumber;
                str = sr.ReadLine().Trim();
                OutputFSNumber = int.Parse(str.Substring(str.IndexOf(":") + 1));
                List<GenericFuzzySet> OutputExistingFS = new List<GenericFuzzySet>();
                for (int j = 0; j < OutputFSNumber; j++)
                {
                    str = sr.ReadLine().Trim();
                    str = str.Substring(str.IndexOf(":") + 1); // Full name of FS type
                                                                // instantiate a particular type of FS
                    Type fsType = Type.GetType(str);
                    GenericFuzzySet fs = (GenericFuzzySet)Activator.CreateInstance(fsType, uni);
                    // creat and assign a tree node 
                    TreeNode aNode = new TreeNode(fs.Name);
                    aNode.Tag = fs;
                    trvFuzzyModel.Nodes[1].Nodes[0].Nodes.Add(aNode);
                    fs.SetTreeNode(aNode);
                    OutputExistingFS.Add(fs);
                    AllExistingFSs.Add(fs);
                    fs.ReadModel(sr, OutputExistingFS);
                    fs.ShowMFCure = true;
                    fs.AddSeriresToChart(chtFuzzyModel);
                }
            }
            else
            {
                int OutputEqnNumber;
                str = sr.ReadLine().Trim();
                OutputEqnNumber = int.Parse(str.Substring(str.IndexOf(":") + 1));
                for (int j = 0; j < OutputEqnNumber; j++)
                {
                    str = sr.ReadLine().Trim();
                    int equationID = int.Parse(str.Substring(str.IndexOf(":") + 1));
                    str = sr.ReadLine().Trim();
                    string equationName = str.Substring(str.IndexOf(":") + 1);
                    // creat and assign a tree node 
                    TreeNode aNode = new TreeNode();
                    aNode.Tag = equationID;
                    aNode.Text = equationName;
                    trvFuzzyModel.Nodes[1].Nodes[0].Nodes.Add(aNode);

                }
            }
            
            
            trvFuzzyModel.ExpandAll();

            // rules
            switch(FuzzySystemMode)
            {
                case 1:
                    // Ask Mamdani system to read its data and also populate dgvRules
                    mamdaniFuzzySystem.ReadModel(sr);

                    // read-in conditions and populate data grid view conditions ...
                    List<int> conditionHashCodes = new List<int>();
                    List<GenericFuzzySet> Conditions = new List<GenericFuzzySet>();
                    int numberOfConditions;
                    str = sr.ReadLine().Trim();
                    numberOfConditions = int.Parse(str.Substring(str.IndexOf(":") + 1));
                    for (int i = 0; i < numberOfConditions; i++)
                    {
                        str = sr.ReadLine().Trim();
                        conditionHashCodes.Add(int.Parse(str.Substring(str.IndexOf(":") + 1)));
                    }
                    foreach(GenericFuzzySet fs in AllExistingFSs)
                    {
                        foreach(int code in conditionHashCodes)
                        {
                            if(code == fs.HashCodeStored)
                            {
                                Conditions.Add(fs);
                                break;
                            }
                        }
                    }
                    dgvCondition.Rows.Add();
                    for(int i = 0; i < Conditions.Count; i++)
                    {
                        dgvCondition.Rows[0].Cells[i].Value = Conditions[i];
                    }


                    // Reconnect reference with each other: Unary, binary ...
                    foreach (GenericFuzzySet fs in AllExistingFSs)
                    {
                        fs.ReconnectFussySetReferences(AllExistingFSs);
                    }

                    foreach(MamdaniIfThenFuzzyRule rule in mamdaniFuzzySystem.AllRules)
                    {
                        //btnAddRule.PerformClick();
                        dgvRules.Rows.Add();
                        rule.ReconnectFuzzySetReferences(AllExistingFSs);
                        for (int i = 0; i < rule.Antecedents.Count; i++)
                        {
                            dgvRules.Rows[dgvRules.RowCount - 1].Cells[i].Value = rule.Antecedents[i];
                        }
                        dgvRules.Rows[dgvRules.RowCount - 1].Cells[dgvRules.ColumnCount - 1].Value = rule.Consequence;
                        
                    }
                    
                    break;

                case 2:
                    sugenoFuzzySystem.ReadModel(sr);

                    // read-in conditions and populate data grid view conditions ...
                    List<int> conditionHashCodes_S = new List<int>();
                    List<GenericFuzzySet> Conditions_S = new List<GenericFuzzySet>();
                    str = sr.ReadLine().Trim();
                    numberOfConditions = int.Parse(str.Substring(str.IndexOf(":") + 1));
                    for (int i = 0; i < numberOfConditions; i++)
                    {
                        str = sr.ReadLine().Trim();
                        conditionHashCodes_S.Add(int.Parse(str.Substring(str.IndexOf(":") + 1)));
                    }
                    foreach (GenericFuzzySet fs in AllExistingFSs)
                    {
                        foreach (int code in conditionHashCodes_S)
                        {
                            if (code == fs.HashCodeStored)
                            {
                                Conditions_S.Add(fs);
                                break;
                            }
                        }
                    }
                    dgvCondition.Rows.Add();
                    for (int i = 0; i < Conditions_S.Count; i++)
                    {
                        dgvCondition.Rows[0].Cells[i].Value = Conditions_S[i];
                    }


                    // Reconnect reference with each other: Unary, binary ...
                    foreach (GenericFuzzySet fs in AllExistingFSs)
                    {
                        fs.ReconnectFussySetReferences(AllExistingFSs);
                    }

                    foreach (SugenoIfThenFuzzyRule rule in sugenoFuzzySystem.AllRules)
                    {
                        dgvRules.Rows.Add();
                        rule.ReconnectFuzzySetReferences(AllExistingFSs);
                        for (int i = 0; i < rule.Antecedents.Count; i++)
                        {
                            dgvRules.Rows[dgvRules.RowCount - 1].Cells[i].Value = rule.Antecedents[i];
                        }
                        dgvRules.Rows[dgvRules.RowCount - 1].Cells[dgvRules.ColumnCount - 1].Value = rule.EquationID;

                    }

                    break;

                case 3:
                    // Ask Mamdani system to read its data and also populate dgvRules
                    tsukamotoFuzzySystem.ReadModel(sr);

                    // read-in conditions and populate data grid view conditions ...
                    List<int> conditionHashCodes_T = new List<int>();
                    List<GenericFuzzySet> Conditions_T = new List<GenericFuzzySet>();
                    str = sr.ReadLine().Trim();
                    numberOfConditions = int.Parse(str.Substring(str.IndexOf(":") + 1));
                    for (int i = 0; i < numberOfConditions; i++)
                    {
                        str = sr.ReadLine().Trim();
                        conditionHashCodes_T.Add(int.Parse(str.Substring(str.IndexOf(":") + 1)));
                    }
                    foreach (GenericFuzzySet fs in AllExistingFSs)
                    {
                        foreach (int code in conditionHashCodes_T)
                        {
                            if (code == fs.HashCodeStored)
                            {
                                Conditions_T.Add(fs);
                                break;
                            }
                        }
                    }
                    dgvCondition.Rows.Add();
                    for (int i = 0; i < Conditions_T.Count; i++)
                    {
                        dgvCondition.Rows[0].Cells[i].Value = Conditions_T[i];
                    }


                    // Reconnect reference with each other: Unary, binary ...
                    foreach (GenericFuzzySet fs in AllExistingFSs)
                    {
                        fs.ReconnectFussySetReferences(AllExistingFSs);
                    }

                    foreach (TsukamotoIfThenFuzzyRule rule in tsukamotoFuzzySystem.AllRules)
                    {
                        //btnAddRule.PerformClick();
                        dgvRules.Rows.Add();
                        rule.ReconnectFuzzySetReferences(AllExistingFSs);
                        for (int i = 0; i < rule.Antecedents.Count; i++)
                        {
                            dgvRules.Rows[dgvRules.RowCount - 1].Cells[i].Value = rule.Antecedents[i];
                        }
                        dgvRules.Rows[dgvRules.RowCount - 1].Cells[dgvRules.ColumnCount - 1].Value = rule.Consequence;

                    }

                    break;
            }
            outputIndex = dgvRules.ColumnCount - 1;
            chtFuzzyModel.ChartAreas[outputIndex].BackColor = Color.Cornsilk;
            trvFuzzyModel.SelectedNode = trvFuzzyModel.Nodes[0];
            prgSelection.SelectedObject = trvFuzzyModel.SelectedNode.Tag;

            // button enability
            str = sr.ReadLine();
            str = sr.ReadLine().Trim();
            btnCreateAUniverse.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            btnReset.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            btnAddFS.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            btn_unary_op.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            btn_binary_op.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            btn_clear_lb.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            btnAddOutputEquation.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            btnAddRule.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            btnDeleteRule.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            btnInference.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            btn_final_inferencing.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            // button visibility
            str = sr.ReadLine();
            str = sr.ReadLine().Trim();
            btn_final_inferencing.Visible = bool.Parse(str.Substring(str.IndexOf(":") + 1));

            // combo box enability
            str = sr.ReadLine();
            str = sr.ReadLine().Trim();
            cb_FS.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            cb_FS_monotonic.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            cb_unaryOperator.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            cb_binaryOperator.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            // combo box visibility
            str = sr.ReadLine();
            str = sr.ReadLine().Trim();
            cb_FS.Visible = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            cb_FS_monotonic.Visible = bool.Parse(str.Substring(str.IndexOf(":") + 1));

            // list box enability
            str = sr.ReadLine();
            str = sr.ReadLine().Trim();
            lsbEuqations.Enabled = bool.Parse(str.Substring(str.IndexOf(":") + 1));

            // group box visibility
            str = sr.ReadLine();
            str = sr.ReadLine().Trim();
            gb_Mamdani.Visible = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            gb_ST.Visible = bool.Parse(str.Substring(str.IndexOf(":") + 1));

            // TeeChart visibility
            str = sr.ReadLine();
            str = sr.ReadLine().Trim();
            LineChart.Visible = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            SurfaceChart.Visible = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            LineChart.Chart.Legend.Visible = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            SurfaceChart.Chart.Legend.Visible = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            chartController1.Visible = bool.Parse(str.Substring(str.IndexOf(":") + 1));
            str = sr.ReadLine().Trim();
            chartController2.Visible = bool.Parse(str.Substring(str.IndexOf(":") + 1));

            // split container distance
            str = sr.ReadLine().Trim();
            splitContainer3.SplitterDistance = int.Parse(str.Substring(str.IndexOf(":") + 1));

            sr.Close();
        }

        public MainForm()
        {
            InitializeComponent();
            
            btnAddFS.Enabled = cb_FS.Enabled = btn_unary_op.Enabled 
                             = cb_unaryOperator.Enabled = btnReset.Enabled 
                             = cb_binaryOperator.Enabled = btn_binary_op.Enabled 
                             = lab_FS_1.Enabled = lab_FS_2.Enabled = btn_clear_lb.Enabled 
                             = btnAddRule.Enabled = btnDeleteRule.Enabled = btnInference.Enabled 
                             = SurfaceChart.Visible = SurfaceChart.Legend.Visible 
                             = LineChart.Visible = LineChart.Legend.Visible 
                             = chartController1.Visible = chartController2.Visible
                             = lsbEuqations.Enabled = btnAddOutputEquation.Enabled
                             = gb_Mamdani.Visible = gb_ST.Visible
                             = btn_final_inferencing.Visible = btn_final_inferencing.Enabled
                             = cb_FS_monotonic.Visible
                             = false;
            // Initial setting for selected tree node
            trvFuzzyModel.SelectedNode = trvFuzzyModel.Nodes[0];
            // Initial setting for fuzzy system model
            mamdaniToolStripMenuItem.Checked = cutToolStripMenuItem.Checked = rb_M_Cut.Checked = true;
            lb_fuzzy_system.Text = "MAMDANI";
            lb_fuzzy_system.BackColor = Color.Cornsilk;
        }

        private void btnCreateAUniverse_Click(object sender, EventArgs e)
        {
            if (trvFuzzyModel.SelectedNode.Index == 1) // 0 for Input; 1 for Ouput
            {
                output = true;
            }
            else
            {
                output = false;
            }
 
            Universe myU = new Universe(chtFuzzyModel, output);


            TreeNode tn = new TreeNode(myU.Name); // we can chage icon image!
            tn.Tag = myU;
            myU.SetTreeNode(tn); // for reference the name of the node

            trvFuzzyModel.SelectedNode.Nodes.Add(tn);

            dgvRules.Columns.Add(myU.Name, myU.Name);
            dgvRules.Columns[dgvRules.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRules.Columns[dgvRules.Columns.Count - 1].Tag = myU;

            if (trvFuzzyModel.SelectedNode.Index == 0)
            {

                dgvCondition.Columns.Add(myU.Name, myU.Name);
                dgvCondition.Columns[dgvCondition.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCondition.Columns[dgvCondition.Columns.Count - 1].Tag = myU;

                if (dgvCondition.RowCount == 0) dgvCondition.Rows.Add();

                if (outputIndex != -1)
                {
                    dgvRules.Columns[outputIndex].DisplayIndex = dgvRules.Columns.Count - 1;
                }
            }
            else if (trvFuzzyModel.SelectedNode.Index == 1)
            {
                outputIndex = dgvRules.Columns.Count - 1;
                if (trvFuzzyModel.SelectedNode.Nodes.Count == 1)
                    btnCreateAUniverse.Enabled = false; 
            }
            trvFuzzyModel.ExpandAll();
            btnReset.Enabled = btnAddRule.Enabled = true;
            
            // Default selection of property grid view
            if(prgSelection.SelectedObject == null)
            {
                prgSelection.SelectedObject = myU;
            }

            // Fault proof for tchart and fuzzy system
            if(dgvCondition.ColumnCount == 1)
            {
                LineChart.Visible = chartController2.Visible = btn_final_inferencing.Visible = true;
                SurfaceChart.Visible = chartController1.Visible = false;
                if (FuzzySystemMode == 1)
                {
                    gb_Mamdani.Visible = true;
                    gb_ST.Visible = false;
                }
                else
                {
                    gb_Mamdani.Visible = false;
                    gb_ST.Visible = true;
                }
            }
            else if(dgvCondition.ColumnCount == 2)
            {
                LineChart.Visible = chartController2.Visible = false;
                SurfaceChart.Visible = chartController1.Visible = btn_final_inferencing.Visible = true;
                if(FuzzySystemMode == 1)
                {
                    gb_Mamdani.Visible = true;
                    gb_ST.Visible = false;
                }
                else
                {
                    gb_Mamdani.Visible = false;
                    gb_ST.Visible = true;
                }
            }
            else if(dgvCondition.ColumnCount > 2)
            {
                splitContainer3.SplitterDistance = 1000;
                LineChart.Visible = SurfaceChart.Visible = chartController1.Visible = chartController2.Visible = btn_final_inferencing.Visible = false;
            }
        }

        private void trvFuzzyModel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            prgSelection.SelectedObject = e.Node.Tag;
            prgSelection.ExpandAllGridItems();
            tabControl1.Enabled = true;
            btnCreateAUniverse.BackColor = gb_PFS.BackColor = gb_UOFS.BackColor 
                                         = gb_BOFS.BackColor = gb_FR.BackColor = gb_FC.BackColor = SystemColors.Control;

            if (e.Node.Level == 0) // Input / Output Universe
            {
                btnCreateAUniverse.Enabled = true;
                btnCreateAUniverse.BackColor = Color.Cornsilk;
                btn_unary_op.Enabled = cb_unaryOperator.Enabled = btn_binary_op.Enabled
                                     = cb_binaryOperator.Enabled = lab_FS_1.Enabled
                                     = lab_FS_2.Enabled = btnAddFS.Enabled = cb_FS.Enabled = false;
                if (e.Node.Index == 1 & e.Node.Nodes.Count >= 1)
                    btnCreateAUniverse.Enabled = false;
            }
            else if (e.Node.Level == 1) // Universe i
            {
                btnAddFS.Enabled = cb_FS.Enabled = true;
                btn_unary_op.Enabled = cb_unaryOperator.Enabled = btn_binary_op.Enabled 
                                     = cb_binaryOperator.Enabled = lab_FS_1.Enabled 
                                     = lab_FS_2.Enabled = btnCreateAUniverse.Enabled = false;
                cb_FS.SelectedIndex = 0; // Default: Gaussian

                // Decorations
                gb_PFS.BackColor = Color.Cornsilk;

                // Fault poof for Sugeno and Tsukamoto
                
                if(e.Node.Parent.Text == "Output Universe")
                {
                    if(FuzzySystemMode == 2)
                    {
                        cb_FS_monotonic.Enabled = cb_FS.Enabled = btnAddFS.Enabled = false;
                        btnCreateAUniverse.BackColor = gb_PFS.BackColor 
                                                     = gb_UOFS.BackColor
                                                     = gb_BOFS.BackColor
                                                     = gb_FR.BackColor 
                                                     = gb_FC.BackColor 
                                                     = SystemColors.Control;
                        lsbEuqations.Enabled = btnAddOutputEquation.Enabled = true;
                    }
                    if (FuzzySystemMode == 3)
                    {
                        cb_FS.Visible = false;
                        cb_FS_monotonic.Visible = cb_FS_monotonic.Enabled = btnAddFS.Enabled = true;
                        cb_FS_monotonic.SelectedIndex = 0; // Default: Sigmoid
                    }
                }
                else if(e.Node.Parent.Text == "Input Universe")
                {
                    cb_FS_monotonic.Visible = false;
                    cb_FS.Enabled = cb_FS.Visible = btnAddFS.Enabled = true;
                }
            }
            else
            {
                gb_UOFS.BackColor = gb_BOFS.BackColor = gb_FR.BackColor = gb_FC.BackColor = Color.Cornsilk;

                btnCreateAUniverse.Enabled = btnAddFS.Enabled = cb_FS.Enabled = false;
                btn_unary_op.Enabled = cb_unaryOperator.Enabled = true;

                if (lab_FS_1.Tag != null & lab_FS_2.Tag != null)
                {
                    if (((GenericFuzzySet)trvFuzzyModel.SelectedNode.Tag).TheUniverse
                        == ((GenericFuzzySet)lab_FS_1.Tag).TheUniverse)
                        btn_binary_op.Enabled = cb_binaryOperator.Enabled = lab_FS_1.Enabled = lab_FS_2.Enabled = true;
                    else
                        btn_binary_op.Enabled = cb_binaryOperator.Enabled = lab_FS_1.Enabled = lab_FS_2.Enabled = false;
                }
                else if (lab_FS_1.Tag == null & lab_FS_2.Tag == null)
                {
                    lab_FS_1.Enabled = lab_FS_2.Enabled = true;
                }
                else
                {
                    if (lab_FS_1.Tag != null & lab_FS_2.Tag == null)
                    {
                        if (((GenericFuzzySet)trvFuzzyModel.SelectedNode.Tag).TheUniverse
                            == ((GenericFuzzySet)lab_FS_1.Tag).TheUniverse)
                        {
                            lab_FS_1.Enabled = lab_FS_2.Enabled = true;
                        }
                        else
                        {
                            lab_FS_1.Enabled = true;
                            lab_FS_2.Enabled = false;
                        }
                    } 
                    else if(lab_FS_2.Tag != null & lab_FS_1.Tag == null)
                    {
                        if (((GenericFuzzySet)trvFuzzyModel.SelectedNode.Tag).TheUniverse
                            == ((GenericFuzzySet)lab_FS_2.Tag).TheUniverse)
                        {
                            lab_FS_1.Enabled = lab_FS_2.Enabled = true;
                        }
                        else
                        {
                            lab_FS_2.Enabled = true;
                            lab_FS_1.Enabled = false;
                        }
                    }
                }
                cb_unaryOperator.SelectedIndex = 0; // Default: Negation
            }

        }
        private void btnAddFS_Click(object sender, EventArgs e)
        {
            Universe selectedU = (Universe) trvFuzzyModel.SelectedNode.Tag as Universe; // cast "object" to Universe

            // 0 -> Gaussian,
            // 1 -> Triangular,
            // 2 -> Bell,
            // 3 -> Sigmoidal,
            // 4 -> Left-Right,
            // 5 -> S-shaped,
            // 6 -> Z-shaped,
            // 7 -> Trapzoidal,
            // 8 -> Pi-shaped,
            // 9 -> StepUp,
            // 10 -> StepDown,
            // 11 -> Singleton

            GenericFuzzySet newFS = null;
            if (FuzzySystemMode == 3 & trvFuzzyModel.SelectedNode.Parent.Text == "Output Universe")
            {
                switch (cb_FS_monotonic.SelectedIndex)
                {
                    // Sigmoidal Function
                    case 0:
                        newFS = new SigmoidalFuzzySet(selectedU);
                        break;

                   // S-shaped function
                    case 1:
                        newFS = new SFuzzySet(selectedU);
                        break;

                    // Z-shaped function
                    case 2:
                        newFS = new ZFuzzySet(selectedU);
                        break;

                   // StepUp function
                    case 3:
                        newFS = new StepUpFuzzySet(selectedU);
                        break;
                    // StepDown function
                    case 4:
                        newFS = new StepDownFuzzySet(selectedU);
                        break;   
                }
            }

            else{
                switch (cb_FS.SelectedIndex)
                {
                    // Gaussian Function
                    case 0:
                        newFS = new GaussianFuzzySet(selectedU);
                        break;

                    // Triangular Function
                    case 1:
                        //TriangularFuzzySet TriFS = new TriangularFuzzySet(selectedU);
                        newFS = new TriangularFuzzySet(selectedU);
                        break;

                    // Bell Function
                    case 2:
                        newFS = new BellFuzzySet(selectedU);
                        break;

                    // Sigmoidal Function
                    case 3:
                        newFS = new SigmoidalFuzzySet(selectedU);
                        break;

                    // Left-Right function
                    case 4:
                        newFS = new LeftRightFuzzySet(selectedU);
                        break;

                    // S-shaped function
                    case 5:
                        newFS = new SFuzzySet(selectedU);
                        break;

                    // Z-shaped function
                    case 6:
                        newFS = new ZFuzzySet(selectedU);
                        break;

                    // Trapzoidal function
                    case 7:
                        newFS = new TrapzoidalFuzzySet(selectedU);
                        break;

                    // Pi-shaped function
                    case 8:
                        newFS = new PiFuzzySet(selectedU);
                        break;
                    // StepUp function
                    case 9:
                        newFS = new StepUpFuzzySet(selectedU);
                        break;
                    // StepDown function
                    case 10:
                        newFS = new StepDownFuzzySet(selectedU);
                        break;
                    // Singleton
                    case 11:
                        newFS = new SingletonFuzzySet(selectedU);
                        break;
                }
            }

            TreeNode tn = new TreeNode(newFS.Name)
            {
                Tag = newFS
            };
            newFS.SetTreeNode(tn);

            trvFuzzyModel.SelectedNode.Nodes.Add(tn);

            newFS.ShowMFCure = true;
            newFS.AddSeriresToChart(chtFuzzyModel);

            trvFuzzyModel.ExpandAll();

        }
        public void Reset()
        {
            chtFuzzyModel.Legends.Clear();
            chtFuzzyModel.Series.Clear();
            chtFuzzyModel.ChartAreas.Clear();
            prgSelection.SelectedObject = null;
            trvFuzzyModel.Nodes[0].Nodes.Clear(); // remove Input Universe
            trvFuzzyModel.Nodes[1].Nodes.Clear(); // remove Output Universe
            dgvRules.Columns.Clear();
            dgvCondition.Columns.Clear();

            // Fuzzy system mode
            FuzzyModeReset();
            FuzzySystemMode = 1; UseCutOperator = true;
            mamdaniToolStripMenuItem.Checked = cutToolStripMenuItem.Checked = rb_M_Cut.Checked = true;
            lb_fuzzy_system.Text = "MAMDANI";
            cb_FS_monotonic.Visible = false;
            cb_FS.Visible = true;

            // TeeChart 
            COA.Clear(); BOA.Clear(); MOM.Clear(); SOM.Clear(); LOM.Clear();
            COA.Active = BOA.Active = MOM.Active = SOM.Active = LOM.Active = true;
            COA_.Clear(); BOA_.Clear(); MOM_.Clear(); SOM_.Clear(); LOM_.Clear();
            COA_.Active = BOA_.Active = MOM_.Active = SOM_.Active = LOM_.Active = true;

            SurfaceChart.Visible = LineChart.Visible 
                                 = chartController1.Visible 
                                 = chartController2.Visible 
                                 = btn_final_inferencing.Visible 
                                 = SurfaceChart.Chart.Legend.Visible
                                 = LineChart.Chart.Legend.Visible
                                 = false;
            splitContainer3.SplitterDistance = 450;
            

            outputIndex = -1;

            trvFuzzyModel.SelectedNode = trvFuzzyModel.Nodes[0];
            btnCreateAUniverse.Enabled = true;

            btnReset.Enabled = btnAddFS.Enabled = btn_unary_op.Enabled = cb_unaryOperator.Enabled
                             = btn_binary_op.Enabled = cb_binaryOperator.Enabled
                             = lab_FS_1.Enabled = lab_FS_2.Enabled = btn_clear_lb.Enabled
                             = btnAddRule.Enabled = btnDeleteRule.Enabled = btnInference.Enabled
                             = btn_final_inferencing.Enabled = lsbEuqations.Enabled = btnAddOutputEquation.Enabled
                             = false;

            lab_FS_1.Tag = lab_FS_2.Tag = null;
            lab_FS_1.Text = "Select The First Fuzzy Set And Click";
            lab_FS_2.Text = "Select The Second Fuzzy Set And Click";
            lab_FS_1.Font = lab_FS_2.Font = new Font("Microsoft JhengHei", 9, FontStyle.Regular);
            lab_FS_1.BackColor = lab_FS_2.BackColor = Color.Transparent;
            gb_PFS.BackColor = gb_UOFS.BackColor = gb_BOFS.BackColor
                             = gb_FR.BackColor = gb_FC.BackColor = SystemColors.Control;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            //chtFuzzyModel.Legends.Clear();
            //chtFuzzyModel.Series.Clear();
            //chtFuzzyModel.ChartAreas.Clear();
            //prgSelection.SelectedObject = null;
            //trvFuzzyModel.Nodes[0].Nodes.Clear(); // remove Input Universe
            //trvFuzzyModel.Nodes[1].Nodes.Clear(); // remove Output Universe
            //dgvRules.Columns.Clear();
            //dgvCondition.Columns.Clear();

            //// Fuzzy system mode
            //FuzzyModeReset();
            //FuzzySystemMode = 1; UseCutOperator = true;
            //mamdaniToolStripMenuItem.Checked = cutToolStripMenuItem.Checked = rb_M_Cut.Checked = true;
            //lb_fuzzy_system.Text = "MAMDANI";
            //cb_FS_monotonic.Visible = false;
            //cb_FS.Visible = true;

            //// TeeChart 
            //COA.Clear(); BOA.Clear(); MOM.Clear(); SOM.Clear(); LOM.Clear();
            //COA_.Clear(); BOA_.Clear(); MOM_.Clear(); SOM_.Clear(); LOM_.Clear();
            //SurfaceChart.Visible = LineChart.Visible = chartController1.Visible = chartController2.Visible = btn_final_inferencing.Visible = false;
            //splitContainer3.SplitterDistance = 450;

            //outputIndex = -1;

            //trvFuzzyModel.SelectedNode = trvFuzzyModel.Nodes[0];
            //btnCreateAUniverse.Enabled = true;

            //btnReset.Enabled = btnAddFS.Enabled = btn_unary_op.Enabled = cb_unaryOperator.Enabled 
            //                 = btn_binary_op.Enabled = cb_binaryOperator.Enabled 
            //                 = lab_FS_1.Enabled = lab_FS_2.Enabled = btn_clear_lb.Enabled 
            //                 = btnAddRule.Enabled = btnDeleteRule.Enabled = btnInference.Enabled 
            //                 = btn_final_inferencing.Enabled = false;

            //lab_FS_1.Tag = lab_FS_2.Tag = null;
            //lab_FS_1.Text = "Select The First Fuzzy Set And Click";
            //lab_FS_2.Text = "Select The Second Fuzzy Set And Click";
            //lab_FS_1.Font = lab_FS_2.Font = new Font("Microsoft JhengHei", 9, FontStyle.Regular);
            //lab_FS_1.BackColor = lab_FS_2.BackColor = Color.Transparent;
            //gb_PFS.BackColor = gb_UOFS.BackColor = gb_BOFS.BackColor 
            //                 = gb_FR.BackColor = gb_FC.BackColor = SystemColors.Control;
            Reset();
        }


        private void btn_unary_op_Click(object sender, EventArgs e)
        {
            GenericFuzzySet fuzzySet = (GenericFuzzySet)trvFuzzyModel.SelectedNode.Tag;

            // 0 -> Negation(Not),
            // 1 -> Sugeno's Complement,
            // 2 -> Yager's Complement,
            // 3 -> Concentration(Very),
            // 4 -> Concentration(Extremly),
            // 5 -> Dilation(More or Less),
            // 6 -> Value-Cut,
            // 7 -> Value-Scale,
            // 8 -> Intensification,
            // 9 -> Diminisher,

            GenericFuzzySet newFS = null;

            switch (cb_unaryOperator.SelectedIndex)
            {
                // Negation(Not)
                case 0:
                    //UnaryFSOperator Noperator = new NegateFSOperator();
                    //newFS = new UnaryOperatedFS(Noperator, fuzzySet);
                    newFS = !fuzzySet;
                    break;

                // Sugeno's Complement
                case 1:
                    UnaryFSOperator SNoperator = new SugenoComplementFSOperator();
                    newFS = new UnaryOperatedFS(SNoperator, fuzzySet);
                    break;

                // Yager's Complement
                case 2:
                    UnaryFSOperator YNoperator = new YagerComplementFSOperator();
                    newFS = new UnaryOperatedFS(YNoperator, fuzzySet);
                    break;

                // Concentration(Very)
                case 3:
                    //UnaryFSOperator Conoperator = new ConcentrationFSOperator();
                    //newFS = new UnaryOperatedFS(Conoperator, fuzzySet);
                    newFS = +fuzzySet;
                    break;

                // Concentration(Extremly)
                case 4:
                    UnaryFSOperator ConEoperator = new ConcentrationEFSOperator();
                    newFS = new UnaryOperatedFS(ConEoperator, fuzzySet);
                    break;

                case 5:
                    //UnaryFSOperator Diloperator = new DilationFSOperator();
                    //newFS = new UnaryOperatedFS(Diloperator, fuzzySet);
                    newFS = -fuzzySet;
                    break;

                // Value-Cut
                case 6:
                    //UnaryFSOperator Cutoperator = new CutFSOperator();
                    //newFS = new UnaryOperatedFS(Cutoperator, fuzzySet);
                    newFS = 0.5 - fuzzySet; // the new experssion using operator overloading (more straightforward)
                    break;

                // Value-Scale
                case 7:
                    //UnaryFSOperator Scaledoperator = new ScaleFSOperator();
                    //newFS = new UnaryOperatedFS(Scaledoperator, fuzzySet);
                    newFS = 0.5 * fuzzySet;
                    break;

                // Intensification
                case 8:
                    //UnaryFSOperator INToperator = new IntensificationFSOperator();
                    //newFS = new UnaryOperatedFS(INToperator, fuzzySet);
                    newFS = ++fuzzySet;
                    break;

                // Diminisher
                case 9:
                    //UnaryFSOperator DIMoperator = new DiminishFSOperator();
                    //newFS = new UnaryOperatedFS(DIMoperator, fuzzySet);
                    newFS = --fuzzySet;
                    break;
            }

            TreeNode tn = new TreeNode(newFS.Name)
            {
                Tag = newFS
            };
            newFS.SetTreeNode(tn);

            trvFuzzyModel.SelectedNode.Parent.Nodes.Add(tn);

            newFS.ShowMFCure = true;
            newFS.AddSeriresToChart(chtFuzzyModel);
        }

    
        private void btn_binary_op_Click(object sender, EventArgs e)
        {
            // 0 -> Intersecion (min)
            // 1 -> Algebraic product
            // 2 -> Bounded product
            // 3 -> Drastic product
            // 4 -> Sugeno's T-norm
            // 5 -> Yager's T-norm
            // 6 -> Union (max)
            // 7 -> Algebraic sum
            // 8 -> Bounded sum
            // 9 -> Drastic sum
            // 10 -> Sugeno's S-norm
            // 11 -> Yager's S-norm
            GenericFuzzySet fuzzySet_1 = (GenericFuzzySet) lab_FS_1.Tag;
            GenericFuzzySet fuzzySet_2 = (GenericFuzzySet) lab_FS_2.Tag;
            GenericFuzzySet newFS = null;

            switch (cb_binaryOperator.SelectedIndex)
            {
                // Intersection
                case 0:
                    //BinaryFSOperator Intersec_operator = new IntersectionFSOperator();
                    //newFS = new BinaryOperatedFS(Intersec_operator, fuzzySet_1, fuzzySet_2);
                    newFS = fuzzySet_1 & fuzzySet_2;
                    break;

                // Algebraic product
                case 1:
                    BinaryFSOperator T_ap_operator = new AlgebraicProductFSOperator();
                    newFS = new BinaryOperatedFS(T_ap_operator, fuzzySet_1, fuzzySet_2);
                    break;

                // Bounded product
                case 2:
                    BinaryFSOperator T_bp_operator = new BoundedProductFSOperator();
                    newFS = new BinaryOperatedFS(T_bp_operator, fuzzySet_1, fuzzySet_2);
                    break;

                // Drastic product
                case 3:
                    BinaryFSOperator T_dp_operator = new DrasticProductFSOperator();
                    newFS = new BinaryOperatedFS(T_dp_operator, fuzzySet_1, fuzzySet_2);
                    break;

                // Sugeno's T-norm
                case 4:
                    BinaryFSOperator T_Sugeno_operator = new SugenoTnormFSOperator();
                    newFS = new BinaryOperatedFS(T_Sugeno_operator, fuzzySet_1, fuzzySet_2);
                    break;

                // Yager's T-norm
                case 5:
                    BinaryFSOperator T_Yager_operator = new YagerTnormFSOperator();
                    newFS = new BinaryOperatedFS(T_Yager_operator, fuzzySet_1, fuzzySet_2);
                    break;

                // Union
                case 6:
                    //BinaryFSOperator Union_operator = new UnionFSOperator();
                    //newFS = new BinaryOperatedFS(Union_operator, fuzzySet_1, fuzzySet_2);
                    newFS = fuzzySet_1 | fuzzySet_2;
                    break;

                // Algebraic product
                case 7:
                    BinaryFSOperator S_ap_operator = new AlgebraicSumFSOperator();
                    newFS = new BinaryOperatedFS(S_ap_operator, fuzzySet_1, fuzzySet_2);
                    break;

                // Bounded product
                case 8:
                    BinaryFSOperator S_bp_operator = new BoundedSumFSOperator();
                    newFS = new BinaryOperatedFS(S_bp_operator, fuzzySet_1, fuzzySet_2);
                    break;

                // Drastic product
                case 9:
                    BinaryFSOperator S_dp_operator = new DrasticSumFSOperator();
                    newFS = new BinaryOperatedFS(S_dp_operator, fuzzySet_1, fuzzySet_2);
                    break;

                // Sugeno's T-norm
                case 10:
                    BinaryFSOperator S_Sugeno_operator = new SugenoSnormFSOperator();
                    newFS = new BinaryOperatedFS(S_Sugeno_operator, fuzzySet_1, fuzzySet_2);
                    break;

                // Yager's T-norm
                case 11:
                    BinaryFSOperator S_Yager_operator = new YagerSnormFSOperator();
                    newFS = new BinaryOperatedFS(S_Yager_operator, fuzzySet_1, fuzzySet_2);
                    break;

            }
            TreeNode tn = new TreeNode(newFS.Name)
            {
                Tag = newFS
            };
            newFS.SetTreeNode(tn);
            trvFuzzyModel.SelectedNode.Parent.Nodes.Add(tn);
            newFS.ShowMFCure = true;
            newFS.AddSeriresToChart(chtFuzzyModel);

        }

        private void lab_FS_1_Click(object sender, EventArgs e)
        {
            if (trvFuzzyModel.SelectedNode.Tag is GenericFuzzySet)
            {
                btn_clear_lb.Enabled = true;
                lab_FS_1.Tag = trvFuzzyModel.SelectedNode.Tag;
                if(lab_FS_2.Tag == null)
                {
                    lab_FS_1.Text = ((GenericFuzzySet)trvFuzzyModel.SelectedNode.Tag).Name;
                }
                else if (((GenericFuzzySet)lab_FS_1.Tag).TheUniverse == ((GenericFuzzySet)lab_FS_2.Tag).TheUniverse)
                {
                    lab_FS_1.Text = ((GenericFuzzySet)trvFuzzyModel.SelectedNode.Tag).Name; // casting 
                    btn_binary_op.Enabled = cb_binaryOperator.Enabled = true;
                    cb_binaryOperator.SelectedIndex = 0; // Default: Intersection

                    // Some decorations
                    //lab_FS_1.Font = lab_FS_2.Font = new Font("Microsoft JhengHei", 9, FontStyle.Bold);
                    //lab_FS_1.BackColor = lab_FS_2.BackColor = SystemColors.InactiveCaption;  
                    lab_FS_1.ForeColor = lab_FS_2.ForeColor = SystemColors.ControlText;
                }
                else
                {
                    lab_FS_1.Tag = null;
                    btn_binary_op.Enabled = cb_binaryOperator.Enabled = false;

                    // Some decorations
                    lab_FS_1.Text = "Select The First Fuzzy Set And Click";
                    lab_FS_1.ForeColor = lab_FS_2.ForeColor = SystemColors.ControlDarkDark;
                    //lab_FS_1.Font = lab_FS_2.Font = new Font("Microsoft JhengHei", 9, FontStyle.Regular);
                    //lab_FS_1.BackColor = lab_FS_2.BackColor = SystemColors.Control;
                    // Warning message
                    MessageBox.Show("Two fuzzy sets chosen to be binary operated should be in the same universe.",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
        }
        
        private void lab_FS_2_Click(object sender, EventArgs e)
        {
            if (trvFuzzyModel.SelectedNode.Tag is GenericFuzzySet)
            {
                btn_clear_lb.Enabled = true;
                lab_FS_2.Tag = trvFuzzyModel.SelectedNode.Tag;
                if (lab_FS_1.Tag == null)
                {
                    lab_FS_2.Text = ((GenericFuzzySet)trvFuzzyModel.SelectedNode.Tag).Name;
                }
                else if (((GenericFuzzySet)lab_FS_1.Tag).TheUniverse == ((GenericFuzzySet)lab_FS_2.Tag).TheUniverse)
                {
                    lab_FS_2.Text = ((GenericFuzzySet)trvFuzzyModel.SelectedNode.Tag).Name; // casting 
                    btn_binary_op.Enabled = cb_binaryOperator.Enabled = true;
                    cb_binaryOperator.SelectedIndex = 0; // Default: Intersection

                    // Some decorations
                    lab_FS_1.ForeColor = lab_FS_2.ForeColor = SystemColors.ControlText;
                    //lab_FS_1.Font = lab_FS_2.Font = new Font("Microsoft JhengHei", 9, FontStyle.Bold);
                    //lab_FS_1.BackColor = lab_FS_2.BackColor = SystemColors.InactiveCaption;
                }
                else
                {
                    lab_FS_2.Tag = null;
                    btn_binary_op.Enabled = cb_binaryOperator.Enabled = false;

                    // Some decorations
                    lab_FS_2.Text = "Select The Second Fuzzy Set And Click";
                    lab_FS_1.ForeColor = lab_FS_2.ForeColor = SystemColors.ControlDarkDark;
                    //lab_FS_1.Font = lab_FS_2.Font = new Font("Microsoft JhengHei", 9, FontStyle.Regular);
                    //lab_FS_1.BackColor = lab_FS_2.BackColor = SystemColors.Control;

                    // Warning message
                    MessageBox.Show("Two fuzzy sets chosen to be binary operated should be in the same universe.",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_clear_lb_Click(object sender, EventArgs e)
        {
            lab_FS_1.Tag = lab_FS_2.Tag = null;
            lab_FS_1.Enabled = lab_FS_2.Enabled = true;

            lab_FS_1.Text = "Select The First Fuzzy Set And Click";
            lab_FS_1.Font = lab_FS_2.Font = new Font("Microsoft JhengHei", 9, FontStyle.Regular);
            lab_FS_1.BackColor = lab_FS_2.BackColor = Color.Transparent;

            lab_FS_2.Text = "Select The Second Fuzzy Set And Click";
            lab_FS_1.Font = lab_FS_2.Font = new Font("Microsoft JhengHei", 9, FontStyle.Regular);
            lab_FS_1.BackColor = lab_FS_2.BackColor = Color.Transparent;

            btn_binary_op.Enabled = cb_binaryOperator.Enabled = false;
            btn_clear_lb.Enabled = false;
        }

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            dgvRules.Rows.Add();
            btnDeleteRule.Enabled = true;
            btnInference.Enabled = false;
            // At most ....
        }
        private void btnDeleteRule_Click(object sender, EventArgs e)
        {
            if (dgvRules.SelectedRows != null)
            {
                int count = dgvRules.SelectedRows.Count;
                for (int i = 0; i < count; i++)
                {
                    dgvRules.Rows.Remove(dgvRules.SelectedRows[0]);
                }
            }
            if(dgvRules.RowCount == 0)
            {
                btnDeleteRule.Enabled = btnInference.Enabled = false;
            }

            bool check = true;
            for (int i = 0; i < dgvRules.Rows.Count; i++)
                for (int j = 0; j < dgvRules.Columns.Count; j++)
                    if (dgvRules.Rows[i].Cells[j].Value == null) check = false;
            if (check) btn_final_inferencing.Enabled = true;

            for (int j = 0; j < dgvCondition.Columns.Count; j++)
                if (dgvCondition.Rows[0].Cells[j].Value == null) check = false;
            if (check) btnInference.Enabled = true;
        }

        private void dgvRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 | e.RowIndex < 0) return;
            if (trvFuzzyModel.SelectedNode.Tag is int)
            {
                if(e.ColumnIndex == outputIndex)
                    dgvRules.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = trvFuzzyModel.SelectedNode.Tag;
            }
            else
            {
                // get fuzzy set
                GenericFuzzySet target = trvFuzzyModel.SelectedNode.Tag as GenericFuzzySet; 
                // if it is not success, then return null
                if (target == null | e.ColumnIndex < 0 | e.RowIndex < 0) return;
                // check column universe and fuzzy universe
                else if(dgvRules.Columns[e.ColumnIndex].Tag != target.TheUniverse)
                {
                    Console.Beep(); Console.Beep(); Console.Beep();
                    return;
                }
                dgvRules.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = target;
            }

            bool check = true;
            for (int i = 0; i < dgvRules.Rows.Count; i++)
                for (int j = 0; j < dgvRules.Columns.Count; j++)
                    if (dgvRules.Rows[i].Cells[j].Value == null) check = false;
            if (check) btn_final_inferencing.Enabled = true;

            for (int j = 0; j < dgvCondition.Columns.Count; j++)
                if (dgvCondition.Rows[0].Cells[j].Value == null) check = false;
            if (check) btnInference.Enabled = true;
        }

        private void dgvCondition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 | e.RowIndex < 0) return;
            // get fuzzy set
            GenericFuzzySet target = trvFuzzyModel.SelectedNode.Tag as GenericFuzzySet;
            if (FuzzySystemMode > 1)
            {
                if (!target.Name.Contains("Singleton"))
                {
                    target = null;
                    MessageBox.Show("In Sugeno and Tsukamoto system, please use fuzzy singleton for individual inference.",
                                    "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // if it is not success, then return null
            if (target == null | e.ColumnIndex < 0 | e.RowIndex < 0) return;
            // check column universe and fuzzy universe
            else if (dgvCondition.Columns[e.ColumnIndex].Tag != target.TheUniverse)
            {
                Console.Beep(); Console.Beep(); Console.Beep();
                return;
            }

            dgvCondition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = target;

            bool check = true;
            for (int i = 0; i < dgvRules.Rows.Count; i++)
                for (int j = 0; j < dgvRules.Columns.Count; j++)
                    if (dgvRules.Rows[i].Cells[j].Value == null) check = false;
            for (int j = 0; j < dgvCondition.Columns.Count; j++)
                if (dgvCondition.Rows[0].Cells[j].Value == null) check = false;
            if (check) btnInference.Enabled = true;
        }

        private void btnInference_Click(object sender, EventArgs e)
        {
            switch(FuzzySystemMode)
            {
                case 1:
                    // 1: Mamdani Fuzzy System (Individual inference)
                    // Create rules objects from DataGridViewer
                    List<GenericFuzzySet> conditions = new List<GenericFuzzySet>();
                    GenericFuzzySet consequence = null;
                    List<MamdaniIfThenFuzzyRule> rules = new List<MamdaniIfThenFuzzyRule>();
                    GenericFuzzySet conclusion = null;

                    // The conditions (facts)
                    for (int i = 0; i < dgvCondition.ColumnCount; i++)
                        conditions.Add(dgvCondition.Rows[0].Cells[i].Value as GenericFuzzySet);


                    for (int j = 0; j < dgvRules.RowCount; j++)
                    {
                        List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
                        for (int i = 0; i < dgvRules.ColumnCount; i++)
                        {
                            if (i != outputIndex)
                            {
                                antecedents.Add(dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet);
                            }
                            else
                            {
                                consequence = dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet;
                            }
                        }
                        MamdaniIfThenFuzzyRule aRule = new MamdaniIfThenFuzzyRule(antecedents, consequence);
                        rules.Add(aRule);
                    }

                    mamdaniFuzzySystem.UpdateRuleSet(rules.ToArray());
                    conclusion = mamdaniFuzzySystem.FuzzyInFuzzyOutInferencing(conditions, UseCutOperator);
                    conclusion.ShowMFCure = true;
                    conclusion.AddSeriresToChart(chtFuzzyModel, SeriesChartType.Area, ChartHatchStyle.Percent50);
                    break;

                case 2:
                    // 2: Sugeno Fuzzy System (Individual inference)
                    List<GenericFuzzySet> conditions_S = new List<GenericFuzzySet>();
                    int EquationID = 0;
                    List<SugenoIfThenFuzzyRule> rules_S = new List<SugenoIfThenFuzzyRule>();
                    double CrispValue_S = 0.0;

                    // The conditions (facts)
                    for (int i = 0; i < dgvCondition.ColumnCount; i++)
                        conditions_S.Add(dgvCondition.Rows[0].Cells[i].Value as GenericFuzzySet);

                    for (int j = 0; j < dgvRules.RowCount; j++)
                    {
                        List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
                        for (int i = 0; i < dgvRules.ColumnCount; i++)
                        {
                            if (i != outputIndex)
                            {
                                antecedents.Add(dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet);
                            }
                            else
                            {
                                EquationID = (int) dgvRules.Rows[j].Cells[i].Value;
                            }
                        }
                        SugenoIfThenFuzzyRule aRule = new SugenoIfThenFuzzyRule(antecedents, EquationID);
                        rules_S.Add(aRule);
                    }
                    sugenoFuzzySystem.UpdateRuleSet(rules_S.ToArray());
                    CrispValue_S = sugenoFuzzySystem.FuzzyInCrispOutInferencing(conditions_S, UseAverage);
                    MessageBox.Show($"Sugeno output crisp value = {CrispValue_S}", "Output crisp value");
                    break;

                case 3:
                    // 3: Tsukamoto Fuzzy System (Individual inference)
                    List<GenericFuzzySet> conditions_T = new List<GenericFuzzySet>();
                    GenericFuzzySet consequence_T = null;
                    List<TsukamotoIfThenFuzzyRule> rules_T = new List<TsukamotoIfThenFuzzyRule>();
                    double CrispValue_T = 0.0;

                    // The conditions (facts)
                    for (int i = 0; i < dgvCondition.ColumnCount; i++)
                        conditions_T.Add(dgvCondition.Rows[0].Cells[i].Value as GenericFuzzySet);

                    for (int j = 0; j < dgvRules.RowCount; j++)
                    {
                        List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
                        for (int i = 0; i < dgvRules.ColumnCount; i++)
                        {
                            if (i != outputIndex)
                            {
                                antecedents.Add(dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet);
                            }
                            else
                            {
                                consequence_T = dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet;
                            }
                        }
                        TsukamotoIfThenFuzzyRule aRule = new TsukamotoIfThenFuzzyRule(antecedents, consequence_T);
                        rules_T.Add(aRule);
                    }
                    tsukamotoFuzzySystem.UpdateRuleSet(rules_T.ToArray());
                    CrispValue_T = tsukamotoFuzzySystem.FuzzyInCrispOutInferencing(conditions_T, UseAverage);
                    MessageBox.Show($"Tsukamoto output crisp value = {CrispValue_T}", "Output crisp value");
                    break;
            }
            
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Create an universe then add some fuzzy sets. \n" +
                            "2. To create an unary operated fuzzy set, you need to select one \n    fuzzy set (click on it). \n" +
                            "3. To create a binary operated fuzzy set, select two fuzzy sets in \n    the same universe and click on the labels (right-handside) \n    respectively."
                            , "Quick Start", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(2021) Designed by Tien-En, Chang. \n\n Email: r09622009@ntu.edu.tw", "Designer", MessageBoxButtons.OK);
        }


        private void btn_final_inferencing_Click(object sender, EventArgs e)
        {
            int numberOfInput = dgvCondition.ColumnCount;
            switch (FuzzySystemMode)
            {
                case 1:
                    // 1: Mamdani Fuzzy System
                    // Construct given fuzzy rules for Mamdani fuzzy system
                    GenericFuzzySet consequence = null;
                    List<MamdaniIfThenFuzzyRule> rules = new List<MamdaniIfThenFuzzyRule>();
                    for (int j = 0; j < dgvRules.RowCount; j++)
                    {
                        List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
                        for (int i = 0; i < dgvRules.ColumnCount; i++)
                        {
                            if (i != outputIndex)
                            {
                                antecedents.Add(dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet);
                            }
                            else
                            {
                                consequence = dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet;
                            }
                        }
                        MamdaniIfThenFuzzyRule aRule = new MamdaniIfThenFuzzyRule(antecedents, consequence);
                        rules.Add(aRule);
                    }

                    mamdaniFuzzySystem.UpdateRuleSet(rules.ToArray());

                    if(numberOfInput == 1)
                    {
                        // One-dimensional Antecedents
                        double y;
                        double[] inputs = new double[1];
                        Universe InputUniverse = dgvCondition.Columns[0].Tag as Universe;
                        Universe OuputUniverse = dgvRules.Columns[outputIndex].Tag as Universe;

                        LineChart.Chart.Axes.Left.Title.Text = OuputUniverse.Name;
                        LineChart.Chart.Axes.Bottom.Title.Text = InputUniverse.Name;
                        LineChart.Legend.Visible = true;

                        COA_.Clear(); BOA_.Clear(); MOM_.Clear(); SOM_.Clear(); LOM_.Clear();

                        for (double x = InputUniverse.Minimum; x <= InputUniverse.Maximum; x += 0.3)
                        {
                            inputs[0] = x;
                            y = mamdaniFuzzySystem.CrispInCrispOutInferencing(inputs, DefuzzificationType.COA, UseCutOperator);
                            COA_.Add(x, y);
                            y = mamdaniFuzzySystem.CrispInCrispOutInferencing(inputs, DefuzzificationType.BOA, UseCutOperator);
                            BOA_.Add(x, y);
                            y = mamdaniFuzzySystem.CrispInCrispOutInferencing(inputs, DefuzzificationType.MOM, UseCutOperator);
                            MOM_.Add(x, y);
                            y = mamdaniFuzzySystem.CrispInCrispOutInferencing(inputs, DefuzzificationType.SOM, UseCutOperator);
                            SOM_.Add(x, y);
                            y = mamdaniFuzzySystem.CrispInCrispOutInferencing(inputs, DefuzzificationType.LOM, UseCutOperator);
                            LOM_.Add(x, y);
                        }
                        //COA_.Active = true;
                        //BOA.Active = MOM.Active = SOM.Active = LOM.Active = false;
                    }
                    else if(numberOfInput == 2)
                    {
                        // Two-dimensional Antecedents
                        
                        int d1 = 30, d2 = 40;
                        double y;
                        double[] inputs = new double[2];
                        Universe InputUniverse1 = dgvCondition.Columns[0].Tag as Universe;
                        Universe InputUniverse2 = dgvCondition.Columns[1].Tag as Universe;
                        Universe OuputUniverse = dgvRules.Columns[outputIndex].Tag as Universe;

                        SurfaceChart.Chart.Axes.Bottom.Title.Text = InputUniverse1.Name;
                        SurfaceChart.Chart.Axes.Depth.Title.Text = InputUniverse2.Name;
                        SurfaceChart.Chart.Axes.Left.Title.Text = OuputUniverse.Name;
                        SurfaceChart.Legend.Visible = true;

                        COA.Clear(); BOA.Clear(); MOM.Clear(); SOM.Clear(); LOM.Clear();
                        COA.NumXValues = BOA.NumXValues = MOM.NumXValues = SOM.NumXValues = LOM.NumXValues = d1;
                        COA.NumZValues = BOA.NumZValues = MOM.NumZValues = SOM.NumZValues = LOM.NumZValues = d2;

                        for (double x = InputUniverse1.Minimum; x <= InputUniverse1.Maximum; x += 0.3)
                        {
                            inputs[0] = x;
                            for (double z = InputUniverse2.Minimum; z <= InputUniverse2.Maximum; z += 0.3)
                            {
                                inputs[1] = z;
                                y = mamdaniFuzzySystem.CrispInCrispOutInferencing(inputs, DefuzzificationType.COA, UseCutOperator);
                                COA.Add(x, y, z);
                                y = mamdaniFuzzySystem.CrispInCrispOutInferencing(inputs, DefuzzificationType.BOA, UseCutOperator);
                                BOA.Add(x, y, z);
                                y = mamdaniFuzzySystem.CrispInCrispOutInferencing(inputs, DefuzzificationType.MOM, UseCutOperator);
                                MOM.Add(x, y, z);
                                y = mamdaniFuzzySystem.CrispInCrispOutInferencing(inputs, DefuzzificationType.SOM, UseCutOperator);
                                SOM.Add(x, y, z);
                                y = mamdaniFuzzySystem.CrispInCrispOutInferencing(inputs, DefuzzificationType.LOM, UseCutOperator);
                                LOM.Add(x, y, z);
                            }
                        }
                        //COA.Active = true;
                        //BOA.Active = MOM.Active = SOM.Active = LOM.Active = false;
                    }
                    
                    break;

                case 2:
                    // 2: Sugeno Fuzzy System
                    List<GenericFuzzySet> conditions_S = new List<GenericFuzzySet>();
                    int EquationID = 0;
                    List<SugenoIfThenFuzzyRule> rules_S = new List<SugenoIfThenFuzzyRule>();
                    double CrispValue_S = 0.0;

                    // The conditions (facts)
                    for (int i = 0; i < dgvCondition.ColumnCount; i++)
                        conditions_S.Add(dgvCondition.Rows[0].Cells[i].Value as GenericFuzzySet);

                    for (int j = 0; j < dgvRules.RowCount; j++)
                    {
                        List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
                        for (int i = 0; i < dgvRules.ColumnCount; i++)
                        {
                            if (i != outputIndex)
                            {
                                antecedents.Add(dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet);
                            }
                            else
                            {
                                EquationID = (int)dgvRules.Rows[j].Cells[i].Value;
                            }
                        }
                        SugenoIfThenFuzzyRule aRule = new SugenoIfThenFuzzyRule(antecedents, EquationID);
                        rules_S.Add(aRule);
                    }
                    sugenoFuzzySystem.UpdateRuleSet(rules_S.ToArray());

                    if (numberOfInput == 1)
                    {
                        // One-dimensional Antecedents
                        double y;
                        double[] inputs = new double[1];
                        Universe InputUniverse = dgvCondition.Columns[0].Tag as Universe;
                        Universe OuputUniverse = dgvRules.Columns[outputIndex].Tag as Universe;

                        LineChart.Chart.Axes.Left.Title.Text = OuputUniverse.Name;
                        LineChart.Chart.Axes.Bottom.Title.Text = InputUniverse.Name;
                        LineChart.Legend.Visible = false;

                        COA_.Clear(); BOA_.Clear(); MOM_.Clear(); SOM_.Clear(); LOM_.Clear();

                        for (double x = InputUniverse.Minimum; x <= InputUniverse.Maximum; x += 0.3)
                        {
                            inputs[0] = x;
                            y = sugenoFuzzySystem.CrispInCrispOutInferencing(inputs, UseAverage);
                            COA_.Add(x, y);
                        }
                        //COA_.Active = true;
                        //BOA.Active = MOM.Active = SOM.Active = LOM.Active = false;
                    }
                    else if(numberOfInput == 2)
                    {
                        // Two-dimensional Antecedents

                        int d1 = 30, d2 = 40;
                        double y;
                        double[] inputs = new double[2];
                        Universe InputUniverse1 = dgvCondition.Columns[0].Tag as Universe;
                        Universe InputUniverse2 = dgvCondition.Columns[1].Tag as Universe;
                        Universe OuputUniverse = dgvRules.Columns[outputIndex].Tag as Universe;

                        SurfaceChart.Chart.Axes.Bottom.Title.Text = InputUniverse1.Name;
                        SurfaceChart.Chart.Axes.Depth.Title.Text = InputUniverse2.Name;
                        SurfaceChart.Chart.Axes.Left.Title.Text = OuputUniverse.Name;
                        SurfaceChart.Legend.Visible = false;

                        COA.Clear(); BOA.Clear(); MOM.Clear(); SOM.Clear(); LOM.Clear();
                        COA.NumXValues = d1;
                        COA.NumZValues = d2;

                        for (double x = InputUniverse1.Minimum; x <= InputUniverse1.Maximum; x += 0.3)
                        {
                            inputs[0] = x;
                            for (double z = InputUniverse2.Minimum; z <= InputUniverse2.Maximum; z += 0.3)
                            {
                                inputs[1] = z;
                                y = sugenoFuzzySystem.CrispInCrispOutInferencing(inputs, UseAverage);
                                COA.Add(x, y, z);
                            }
                        }
                    }
                    break;

                case 3:
                    // 3: Tsukamoto Fuzzy System
                    List<GenericFuzzySet> conditions_T = new List<GenericFuzzySet>();
                    GenericFuzzySet consequence_T = null;
                    List<TsukamotoIfThenFuzzyRule> rules_T = new List<TsukamotoIfThenFuzzyRule>();
                    double CrispValue_T = 0.0;
                    // The conditions (facts)
                    for (int i = 0; i < dgvCondition.ColumnCount; i++)
                        conditions_T.Add(dgvCondition.Rows[0].Cells[i].Value as GenericFuzzySet);

                    for (int j = 0; j < dgvRules.RowCount; j++)
                    {
                        List<GenericFuzzySet> antecedents = new List<GenericFuzzySet>();
                        for (int i = 0; i < dgvRules.ColumnCount; i++)
                        {
                            if (i != outputIndex)
                            {
                                antecedents.Add(dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet);
                            }
                            else
                            {
                                consequence_T = dgvRules.Rows[j].Cells[i].Value as GenericFuzzySet;
                            }
                        }
                        TsukamotoIfThenFuzzyRule aRule = new TsukamotoIfThenFuzzyRule(antecedents, consequence_T);
                        rules_T.Add(aRule);
                    }
                    tsukamotoFuzzySystem.UpdateRuleSet(rules_T.ToArray());

                    if (numberOfInput == 1)
                    {
                        // One-dimensional Antecedents
                        double y;
                        double[] inputs = new double[1];
                        Universe InputUniverse = dgvCondition.Columns[0].Tag as Universe;
                        Universe OuputUniverse = dgvRules.Columns[outputIndex].Tag as Universe;

                        LineChart.Chart.Axes.Left.Title.Text = OuputUniverse.Name;
                        LineChart.Chart.Axes.Bottom.Title.Text = InputUniverse.Name;
                        LineChart.Legend.Visible = false;

                        COA_.Clear(); BOA_.Clear(); MOM_.Clear(); SOM_.Clear(); LOM_.Clear();

                        for (double x = InputUniverse.Minimum; x <= InputUniverse.Maximum; x += 0.3)
                        {
                            inputs[0] = x;
                            y = tsukamotoFuzzySystem.CrispInCrispOutInferencing(inputs, UseAverage);
                            COA_.Add(x, y);
                        }
                    }
                    else if (numberOfInput == 2)
                    {
                        // Two-dimensional Antecedents

                        int d1 = 30, d2 = 40;
                        double y;
                        double[] inputs = new double[2];
                        Universe InputUniverse1 = dgvCondition.Columns[0].Tag as Universe;
                        Universe InputUniverse2 = dgvCondition.Columns[1].Tag as Universe;
                        Universe OuputUniverse = dgvRules.Columns[outputIndex].Tag as Universe;

                        SurfaceChart.Chart.Axes.Bottom.Title.Text = InputUniverse1.Name;
                        SurfaceChart.Chart.Axes.Depth.Title.Text = InputUniverse2.Name;
                        SurfaceChart.Chart.Axes.Left.Title.Text = OuputUniverse.Name;
                        SurfaceChart.Legend.Visible = false;

                        COA.Clear(); BOA.Clear(); MOM.Clear(); SOM.Clear(); LOM.Clear();
                        COA.NumXValues = d1;
                        COA.NumZValues = d2;

                        for (double x = InputUniverse1.Minimum; x <= InputUniverse1.Maximum; x += 0.3)
                        {
                            inputs[0] = x;
                            for (double z = InputUniverse2.Minimum; z <= InputUniverse2.Maximum; z += 0.3)
                            {
                                inputs[1] = z;
                                y = tsukamotoFuzzySystem.CrispInCrispOutInferencing(inputs, UseAverage);
                                COA.Add(x, y, z);
                            }
                        }
                    }
                    break;
            }
            
        }

        private void btnAddOutputEquation_Click(object sender, EventArgs e)
        {
            int equationID = lsbEuqations.SelectedIndex;

            TreeNode tn = new TreeNode($"equation{equationID}")
            {
                Tag = equationID,
                Text = lsbEuqations.Items[equationID].ToString()
            };
            trvFuzzyModel.SelectedNode.Nodes.Add(tn);

            trvFuzzyModel.ExpandAll();
        }



        #region FUZZY SYSTEM MODE
        public void FuzzyModeReset()
        {
            mamdaniToolStripMenuItem.Checked = cutToolStripMenuItem.Checked
                                             = scaleToolStripMenuItem.Checked
                                             = rb_M_Cut.Checked
                                             = rb_M_Scale.Checked
                                             = gb_Mamdani.Visible
                                             = sugenoToolStripMenuItem.Checked 
                                             = weightedAverageToolStripMenuItem.Checked
                                             = weightedSumToolStripMenuItem.Checked
                                             = lsbEuqations.Enabled
                                             = btnAddOutputEquation.Enabled
                                             = tsukamotoToolStripMenuItem.Checked 
                                             = weightedAverageToolStripMenuItem1.Checked
                                             = weightedSumToolStripMenuItem1.Checked
                                             = cb_FS_monotonic.Visible
                                             = rb_ST_Average.Checked
                                             = rb_ST_Sum.Checked
                                             = gb_ST.Visible
                                             = false;

            cb_FS.Visible = true;

            if(trvFuzzyModel.SelectedNode.Level == 1)
            {
                cb_FS.Enabled = btnAddFS.Enabled = true;
            }
        }

        public bool ModeResetCheck(int NewMode)
        {
            bool check = true;
            if(NewMode != FuzzySystemMode)
            {
                DialogResult dialogResult = MessageBox.Show("The whole system will be reset, are you sure to change the fuzzy system?",
                                                            "Warning Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dialogResult == DialogResult.Yes)
                {
                    Reset();
                }
                else
                {
                    check = false;
                }
            }
            return check;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ModeResetCheck(1))
            {
                FuzzyModeReset();
                FuzzySystemMode = 1; // 1 for Mamdani fuzzy system
                lb_fuzzy_system.Text = "MAMDANI";
                UseCutOperator = mamdaniToolStripMenuItem.Checked 
                               = cutToolStripMenuItem.Checked 
                               = rb_M_Cut.Checked
                               = true;
                scaleToolStripMenuItem.Checked = false;

                if(dgvCondition.ColumnCount > 0 & dgvCondition.ColumnCount <= 2)
                {
                    gb_Mamdani.Visible = true;
                    gb_ST.Visible = false;
                }
            }
            
        }
        private void rb_M_Cut_Click(object sender, EventArgs e)
        {
            UseCutOperator = cutToolStripMenuItem.Checked
                           = true;
            scaleToolStripMenuItem.Checked = false;
        }
        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ModeResetCheck(1))
            {
                FuzzyModeReset();
                FuzzySystemMode = 1; // 1 for Mamdani fuzzy system
                lb_fuzzy_system.Text = "MAMDANI";
                UseCutOperator = cutToolStripMenuItem.Checked
                               = false;
                mamdaniToolStripMenuItem.Checked = scaleToolStripMenuItem.Checked
                                                 = rb_M_Scale.Checked
                                                 = true;

                if (dgvCondition.ColumnCount > 0 & dgvCondition.ColumnCount <= 2)
                {
                    gb_Mamdani.Visible = true;
                    gb_ST.Visible = false;
                }
            }
        }

        private void rb_M_Scale_Click(object sender, EventArgs e)
        {
            UseCutOperator = cutToolStripMenuItem.Checked
                           = false;
            scaleToolStripMenuItem.Checked = true;
        }
        private void weightedAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ModeResetCheck(2))
            {
                FuzzyModeReset();
                FuzzySystemMode = 2; // 2 for Sugeno fuzzy system
                lb_fuzzy_system.Text = "SUGENO";
                lsbEuqations.SelectedIndex = 0; // Default setting

                UseAverage = sugenoToolStripMenuItem.Checked
                           = weightedAverageToolStripMenuItem.Checked
                           = rb_ST_Average.Checked
                           = true;
                weightedSumToolStripMenuItem.Checked = false;

                if (trvFuzzyModel.SelectedNode.Level == 1)
                {
                    if (trvFuzzyModel.SelectedNode.Parent.Text == "Output Universe")
                    {
                        cb_FS.Enabled = cb_FS_monotonic.Enabled = btnAddFS.Enabled = false;
                    }
                }

                if (dgvCondition.ColumnCount > 0 & dgvCondition.ColumnCount <= 2)
                {
                    gb_Mamdani.Visible = false;
                    gb_ST.Visible = true;
                }
            }
        }
        private void weightedSumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ModeResetCheck(2))
            {
                FuzzyModeReset();
                FuzzySystemMode = 2; // 2 for Sugeno fuzzy system
                lb_fuzzy_system.Text = "SUGENO";
                lsbEuqations.SelectedIndex = 0; // Default setting

                UseAverage = weightedAverageToolStripMenuItem.Checked
                           = false;
                sugenoToolStripMenuItem.Checked = weightedSumToolStripMenuItem.Checked
                                                = rb_ST_Sum.Checked
                                                = true;

                if (trvFuzzyModel.SelectedNode.Level == 1)
                {
                    if (trvFuzzyModel.SelectedNode.Parent.Text == "Output Universe")
                    {
                        cb_FS.Enabled = cb_FS_monotonic.Enabled = btnAddFS.Enabled = false;
                    }
                }

                if (dgvCondition.ColumnCount > 0 & dgvCondition.ColumnCount <= 2)
                {
                    gb_Mamdani.Visible = false;
                    gb_ST.Visible = true;
                }
            }
        }

        private void weightedAverageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ModeResetCheck(3))
            {
                FuzzyModeReset();
                FuzzySystemMode = 3; // 3 for Tsukamoto fuzzy system
                lb_fuzzy_system.Text = "TSUKAMOTO";
                UseAverage = tsukamotoToolStripMenuItem.Checked
                           = weightedAverageToolStripMenuItem1.Checked
                           = rb_ST_Average.Checked
                           = true;
                weightedSumToolStripMenuItem1.Checked = rb_ST_Sum.Checked
                                                      = false;

                if (trvFuzzyModel.SelectedNode.Level == 1)
                {
                    if (trvFuzzyModel.SelectedNode.Parent.Text == "Output Universe")
                    {
                        cb_FS.Visible = false;
                        cb_FS_monotonic.Visible = cb_FS_monotonic.Enabled = btnAddFS.Enabled = true;
                        cb_FS_monotonic.SelectedIndex = 0;
                    }
                }

                if (dgvCondition.ColumnCount > 0 & dgvCondition.ColumnCount <= 2)
                {
                    gb_Mamdani.Visible = false;
                    gb_ST.Visible = true;
                }
            }
        }

        private void weightedSumToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ModeResetCheck(3))
            {
                FuzzyModeReset();
                FuzzySystemMode = 3; // 3 for Tsukamoto fuzzy system
                lb_fuzzy_system.Text = "TSUKAMOTO";
                UseAverage = weightedAverageToolStripMenuItem1.Checked
                           = rb_ST_Average.Checked
                           = false;
                tsukamotoToolStripMenuItem.Checked = weightedSumToolStripMenuItem1.Checked
                                                   = rb_ST_Sum.Checked
                                                   = true;

                if (trvFuzzyModel.SelectedNode.Level == 1)
                {
                    if (trvFuzzyModel.SelectedNode.Parent.Text == "Output Universe")
                    {
                        cb_FS.Visible = false;
                        cb_FS_monotonic.Visible = cb_FS_monotonic.Enabled = btnAddFS.Enabled = true;
                        cb_FS_monotonic.SelectedIndex = 0;
                    }
                }

                if (dgvCondition.ColumnCount > 0 & dgvCondition.ColumnCount <= 2)
                {
                    gb_Mamdani.Visible = false;
                    gb_ST.Visible = true;
                }
            }
        }
        private void rb_ST_Average_Click(object sender, EventArgs e)
        {
            if(FuzzySystemMode == 2)
            {
                UseAverage = weightedAverageToolStripMenuItem.Checked
                           = rb_ST_Average.Checked
                           = true;
                weightedSumToolStripMenuItem.Checked = rb_ST_Sum.Checked = false;
            }
            else
            {
                UseAverage = weightedAverageToolStripMenuItem1.Checked
                           = rb_ST_Average.Checked
                           = true;
                weightedSumToolStripMenuItem1.Checked = rb_ST_Sum.Checked = false;
            }
        }

        private void rb_ST_Sum_Click(object sender, EventArgs e)
        {
            if (FuzzySystemMode == 2)
            {
                weightedSumToolStripMenuItem.Checked
                           = rb_ST_Sum.Checked
                           = true;
                UseAverage = weightedAverageToolStripMenuItem.Checked = rb_ST_Average.Checked = false;
            }
            else
            {
                weightedSumToolStripMenuItem1.Checked
                           = rb_ST_Sum.Checked
                           = true;
                UseAverage = weightedAverageToolStripMenuItem1.Checked = rb_ST_Average.Checked = false;
            }
        }



        #endregion


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;

            SaveModel(dlg.FileName);

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;

            ReadModel(dlg.FileName);

        }        
        

    }
}
