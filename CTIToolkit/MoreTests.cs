using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using ViewModels;

namespace CTIToolkit
{
    public partial class MoreTests : UserControl
    {
        MechanicalDraftPerformanceCurveViewModel MechanicalDraftPerformanceCurveViewModel { get; set; }
        public MoreTests()
        {
            InitializeComponent();
            MechanicalDraftPerformanceCurveViewModel = new MechanicalDraftPerformanceCurveViewModel(false, false);
            TestPointTabControl.TabPages.Clear();
        }

        private void AddTestPointButton_Click(object sender, EventArgs e)
        {
            string errorMessage;
            AddTabPage(TestPointName.Text, new MechanicalDraftPerformanceCurveFileData(false), out errorMessage);
            TestPointName.Text = string.Empty;
        }

        private bool AddTabPage(string title, MechanicalDraftPerformanceCurveFileData data, out string errorMessage)
        {
            bool returnValue = true;

            try
            {
                TabPage tabPage = new TabPage();
                tabPage.Text = title;
                TestPointUserControl testPointUserControl = new TestPointUserControl();
                testPointUserControl.LoadData(data, out errorMessage);
                tabPage.Controls.Add(testPointUserControl);
                TestPointTabControl.TabPages.Add(tabPage);
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Tower design page setup failed. Exception: {0} ", e.ToString());
                returnValue = false;
            }

            return returnValue;
        }
    }
}
