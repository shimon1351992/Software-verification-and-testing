using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Compression;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace HETS1Design
{
    /*We are excluding this from code coverage since we'll be testing these functions in
     MainScreenLogic class.*/
    [ExcludeFromCodeCoverage]
    public partial class MainScreen : Form
    {
        public static MainScreen main1 = null;

       
        public MainScreen()
        {
            
            InitializeComponent();
            main1 = this;
            
        }


        private void MainScreen_Load(object sender, EventArgs e)
        {
            MainScreenLogic.OnMainScreenLoad(this.menuCodeWeight, this.menuExeWeight, this.menuResultsWeight);
            this.rbRunPro.Checked = true;
        }

        private void MainScreen_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MainScreenLogic.DisplayGuideHelpBox();
        }

        private void btnCompile_Click(object sender, EventArgs e)
        { 
            MainScreenLogic.CompileHelper(this.btnCompile, this.txtArchivePath, this.txtInputPath, this.txtOutputPath);
        }


        private void btnRunProgram_Click(object sender, EventArgs e)
        {
            MainScreenLogic.RunHelper(this.btnRunProgram, this.txtArchivePath, this.txtInputPath, this.txtOutputPath, this.btnResults);
        }


        private void btnResults_Click(object sender, EventArgs e)
        {
            if(txtArchivePath.Text == "" || txtInputPath.Text == "" || txtOutputPath.Text == "")
            {
               MainScreenLogic.FormValidate(txtArchivePath, txtInputPath, txtOutputPath);

            }
            else
            {
                btnResults.Enabled = false;
                btnCompile_Click(null, null);
                btnRunProgram_Click(null, null);

                MainScreenLogic.OnShowResults(this.dataGridResults, this.btnDetailedResults);

            }
           
            
        }

        //functions that browse for a input file for console app
        delegate void ResultsCallback();
        public void CmdResults()
        {
            if (this.btnResults.InvokeRequired)
            {

                ResultsCallback d = new ResultsCallback(CmdResults);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.btnResults_Click(null, null);

            }
        }

        private void btnDetailedResults_Click(object sender, EventArgs e)
        {
            MainScreenLogic.OnSaveDetailedResults(this.txtArchivePath);
        }

        private void btnSaveIO_Click(object sender, EventArgs e)
        {
            MainScreenLogic.OnButtonSaveIOClick(this.txtInputPath, this.txtOutputPath);
            
        }

        private void btnAddTestCase_Click(object sender, EventArgs e)
        {
            MainScreenLogic.OnButtonAddTestCaseClick(this.radioTC, this.radioTNC, this.txtInputAppend, this.txtOutputAppend);
        }


        private void btnBrowseArchive_Click(object sender, EventArgs e)
        {
            MainScreenLogic.PrepareFileDialog("ZIP Archive files (*.zip)|*.zip", openArchiveDialog);
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            MainScreenLogic.PrepareFileDialog("Text files (*.txt)|*.txt", openInputDialog);
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            MainScreenLogic.PrepareFileDialog("Text files (*.txt)|*.txt", openOutputDialog);
        }

        private void openArchiveDialog_FileOk(object sender, CancelEventArgs e)
        {
            MainScreenLogic.OpenArchiveFile(this.openArchiveDialog, this.txtArchivePath, this.btnResults, this.btnDetailedResults);
        }

        //functions that browse for a ZIP file for console app
        delegate void BrowseZIPCallback();
        public void CmdOpenArchive()
        {
            if (this.txtArchivePath.InvokeRequired)
            {

                BrowseZIPCallback d = new BrowseZIPCallback(CmdOpenArchive);
                this.Invoke(d, new object[] { });
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.FileName = @"C:\Users\repti\Documents\אימות ובדיקות תוכנה\Final Phase\HETS - Azo\Assets\Test Required FIles\AUseScript\Moodle Submissions.zip";
                MainScreenLogic.OpenArchiveFile(ofd, this.txtArchivePath, this.btnResults, this.btnDetailedResults);

            }
        }


        //functions that browse for a input file for console app
        delegate void BrowseInputCallback();
        public void CmdOpenInput()
        {
            if (this.txtInputPath.InvokeRequired)
            {

                BrowseInputCallback d = new BrowseInputCallback(CmdOpenInput);
                this.Invoke(d, new object[] { });
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.FileName = @"C:\Users\repti\Documents\אימות ובדיקות תוכנה\Final Phase\HETS - Azo\Assets\Test Required FIles\AUseScript\InputTestCasesGoodExample.txt";
                MainScreenLogic.OpenInputFile(ofd, this.txtInputPath, this.txtOutputPath, this.btnAddTestCase, this.btnSaveIO);

            }
        }

        //functions that browse for a input file for console app
        delegate void BrowseOutputCallback();
        public void CmdOpenOutput()
        {
            if (this.txtOutputPath.InvokeRequired)
            {

                BrowseOutputCallback d = new BrowseOutputCallback(CmdOpenOutput);
                this.Invoke(d, new object[] { });
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.FileName = @"C:\Users\repti\Documents\אימות ובדיקות תוכנה\Final Phase\HETS - Azo\Assets\Test Required FIles\AUseScript\OutputTestCasesGoodExample.txt";
                MainScreenLogic.OpenOutputFile(ofd, this.txtOutputPath, this.txtInputPath, this.btnAddTestCase, this.btnSaveIO);

            }
        }

        private void openInputDialog_FileOk(object sender, CancelEventArgs e)
        {
            MainScreenLogic.OpenInputFile(this.openInputDialog, this.txtInputPath, this.txtOutputPath, this.btnAddTestCase, this.btnSaveIO);
        }

        private void openOutputDialog_FileOk(object sender, CancelEventArgs e)
        {
            MainScreenLogic.OpenOutputFile(this.openOutputDialog, this.txtOutputPath, this.txtInputPath, this.btnAddTestCase, this.btnSaveIO);
        }


        private void menuCodeWeight_ValueChanged(object sender, EventArgs e)
        {
            MainScreenLogic.LimitWeightsChange(this.menuCodeWeight, this.menuExeWeight, this.menuResultsWeight);
        }

        private void menuExeGrade_ValueChanged(object sender, EventArgs e)
        {
            MainScreenLogic.LimitWeightsChange(this.menuCodeWeight, this.menuExeWeight, this.menuResultsWeight);
        }

        private void menuResultsGrade_ValueChanged(object sender, EventArgs e)
        {
            MainScreenLogic.LimitWeightsChange(this.menuCodeWeight, this.menuExeWeight, this.menuResultsWeight);
        }

        private void checkBoxEnableGrading_CheckedChanged(object sender, EventArgs e)
        {
            MainScreenLogic.EnableGradingCheckedChange(this.checkBoxEnableGrading, this.menuCodeWeight, this.menuExeWeight, this.menuResultsWeight);
        }

        private void radioButton64BitCompiler_CheckedChanged(object sender, EventArgs e)
        {
            MainScreenLogic.Option64BitCompilerChange();
        }

        private void radioButton32BitCompiler_CheckedChanged(object sender, EventArgs e)
        {
            MainScreenLogic.Option32BitCompilerChange();
        }


        private void timeoutNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainScreenLogic.TimeoutValueChange(timeoutNumUpDown);
        }

        private void radioBtnExecutable_CheckedChanged(object sender, EventArgs e)
        {
            MainScreenLogic.OnCheckCodeRadioChange(this.btnCompile);
        }

        private void radioBtnCode_CheckedChanged(object sender, EventArgs e)
        {
            MainScreenLogic.OnCheckExeRadioChange(this.btnCompile);
        }

        private void radioBtnBothExeAndCode_CheckedChanged(object sender, EventArgs e)
        {
            MainScreenLogic.OnCheckBothRadioChange(this.btnCompile);
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            MainScreenLogic.OnExportToCSV(saveCSVFile, dataGridResults);
        }

        private void txtArchivePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOutputPath_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void rbCompile_CheckedChanged(object sender, EventArgs e)
        {
            btnResults.Enabled = true;
        }

        private void rbCompile_CheckedChanged_1(object sender, EventArgs e)
        {
            btnResults.Enabled = true;
        }

        private void rbCheckCommend_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbComment_CheckedChanged(object sender, EventArgs e)
        {

        }

        //check comments for console
        delegate void CommentsCallback();
        public void CmdComments()
        {
            if (this.cbComment.InvokeRequired)
            {

                CommentsCallback d = new CommentsCallback(CmdComments);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.cbComment.Checked=true;


            }
        }
        //check compilation compile for console
        delegate void compileCallback();
        public void CmdCompile()
        {
            if (this.rbCompile.InvokeRequired)
            {

                CommentsCallback d = new CommentsCallback(CmdCompile);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.rbCompile.Checked = true;


            }
        }

        delegate void runProgramsCallback();
        public void CmdRunPrograms()
        {
            if (this.rbRunPro.InvokeRequired)
            {

                runProgramsCallback d = new runProgramsCallback(CmdRunPrograms);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.rbRunPro.Checked = true;


            }
        }

        delegate void c32bitCallback();
        public void Cmd32bit()
        {
            if (this.rbRunPro.InvokeRequired)
            {

                c32bitCallback d = new c32bitCallback(Cmd32bit);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.radioButton32BitCompiler.Checked = true;


            }
        }

        delegate void cFilesCallback();
        public void CmdCFiles()
        {
            if (this.radioBtnExecutable.InvokeRequired)
            {

                c32bitCallback d = new c32bitCallback(CmdCFiles);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.radioBtnExecutable.Checked = true;

            }
        }

        delegate void executableCallback();
        public void CmdExecutable()
        {
            if (this.radioBtnCode.InvokeRequired)
            {

                executableCallback d = new executableCallback(CmdExecutable);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.radioBtnCode.Checked = true;

            }
        }

        delegate void testCaseCallback();
        public void CmdAddTestCase()
        {
            if (this.txtInputAppend.InvokeRequired && this.txtOutputAppend.InvokeRequired)
            {

                testCaseCallback d = new testCaseCallback(CmdAddTestCase);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.txtInputAppend.Text = "10 5";
                string outputtext = "enter 2 chars seperated by space:\r\nyour char diff is: 8";
                this.txtOutputAppend.Text =outputtext;
                btnAddTestCase_Click(null, null);
                btnSaveIO_Click(null, null);

            }
        }

        delegate void timeoutCallback();
        public void CmdTimeout()
        {
            if (this.timeoutNumUpDown.InvokeRequired)
            {

                timeoutCallback d = new timeoutCallback(CmdTimeout);
                this.Invoke(d, new object[] { });
            }
            else
            {
                timeoutNumUpDown.Value = 10;

            }
        }

        delegate void gradingCallback();
        public void CmdGrading()
        {
            if (this.checkBoxEnableGrading.InvokeRequired)
            {

                gradingCallback d = new gradingCallback(CmdGrading);
                this.Invoke(d, new object[] { });
            }
            else
            {
                Random randomNumberGenrator = new Random();
                int codeWeight = randomNumberGenrator.Next(100) + 1;
                int val = 100 - codeWeight;
                int exeWeight = randomNumberGenrator.Next(val) + 1;

                checkBoxEnableGrading.Checked = true;
                menuCodeWeight.Value = codeWeight;
                menuExeWeight.Value = exeWeight;
                menuResultsWeight.Value = 100 - codeWeight - exeWeight;

                this.Close();

            }
        }

        delegate void closeCallback();
        public void CmdClose()
        {
            if (this.InvokeRequired)
            {

                closeCallback d = new closeCallback(CmdClose);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.Close();

            }
        }





    }
}
