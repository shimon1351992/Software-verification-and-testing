﻿using System;
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
        public MainScreen()
        {
            InitializeComponent();
        }


        private void MainScreen_Load(object sender, EventArgs e)
        {
            MainScreenLogic.OnMainScreenLoad(this.menuCodeWeight, this.menuExeWeight, this.menuResultsWeight);
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
            MainScreenLogic.OnShowResults(this.dataGridResults, this.btnDetailedResults);

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

        //functions that browse for a output file for console app
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

        delegate void CRRCallback();
        public void CmdCRR()
        {
            if (this.btnCompile.InvokeRequired && this.btnRunProgram.InvokeRequired && this.btnResults.InvokeRequired)
            {

                CRRCallback d = new CRRCallback(CmdCRR);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.btnCompile_Click(null, null);
                this.btnRunProgram_Click(null, null);
                this.btnResults_Click(null, null);

            }


        }


        delegate void CompileCallback();

        public void CmdCompile()
        {
            if (this.btnCompile.InvokeRequired)
            {

                CompileCallback d = new CompileCallback(CmdCompile);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.btnCompile_Click(null, null);


            }
        }

        delegate void RunCallback();

        public void CmdRun()
        {
            if (this.btnRunProgram.InvokeRequired)
            {

                CompileCallback d = new CompileCallback(CmdRun);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.btnRunProgram_Click(null, null);


            }
        }

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


    }

}
