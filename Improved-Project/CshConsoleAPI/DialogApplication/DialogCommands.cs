using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace CshConsoleAPI
{
	public class DialogCommands
	{
		public const string GUI_SHOW = "gui";
		public const string GUI_LOAD_ZIP = "zip";
		public const string GUI_LOAD_INPUT = "input";
		public const string GUI_LOAD_OUTPUT = "output";
		public const string GUI_RESULT = "results";
		public const string GUI_FRESULT = "fresults";
		public const string GUI_COMMENTS = "comments";
		public const string GUI_COMPILE = "compile";
		public const string GUI_32BIT = "c32bit";
		public const string GUI_RUN_PROGRAMS = "runprograms";
		public const string GUI_C_FILES = "cfiles";
		public const string GUI_EXEC = "exec";
		public const string GUI_ADD_TEST = "addtest";
		public const string GUI_TIMEOUT = "timeout";
		public const string GUI_GRADING = "grade";
		public const string GUI_CLOSE = "close";


		private static HETS1Design.MainScreen gui = new HETS1Design.MainScreen();
		//private static ApplicationGUI gui = new ApplicationGUI();

		/***
		* GuiShow opens the application graphical user interface.
		*/
		public static String CommandGuiShow(string[] parameters)
		{
			Task.Run(() => { gui.ShowDialog(); });
			
			return AppCommands.CMD_OK;
		}

		public static String CommandLoadZip(string[] parameters){
			gui.CmdOpenArchive();

			return AppCommands.CMD_OK; ;
		}
		public static String CommandLoadInput(string[] parameters)
		{
			gui.CmdOpenInput();
			return AppCommands.CMD_OK;
		}
		public static String CommandLoadOutput(string[] parameters)
		{
			gui.CmdOpenOutput();
			return AppCommands.CMD_OK;
		}
		
		public static String CommandGuiClose(string[] parameters)
		{
			gui.CmdClose();
			return AppCommands.CMD_OK;
		}

		public static String CommandResult(string[] parameters)
		{
			gui.CmdResults();
			return AppCommands.CMD_OK;
		}
		public static String CommandFResult(string[] parameters)
		{
			gui.CmdOpenArchive();
			gui.CmdOpenInput();
			gui.CmdOpenOutput();
			gui.CmdResults();
			return AppCommands.CMD_OK;
		}

		public static String CommandResultComments(string[] parameters)
		{
			gui.CmdComments();
			CommandFResult(null);
			return AppCommands.CMD_OK;
		}

		public static String CommandResultCompile(string[] parameters)
		{
			gui.CmdCompile();
			CommandFResult(null);
			return AppCommands.CMD_OK;
		}

		public static String CommandResultRunPrograms(string[] parameters)
		{
			gui.CmdRunPrograms();
			CommandFResult(null);
			return AppCommands.CMD_OK;
		}
		
		public static String CommandC32bit(string[] parameters)
		{
			gui.Cmd32bit();
			CommandResultCompile(null);
			return AppCommands.CMD_OK;
		}

		public static String CommandCFiles(string[] parameters)
		{
			gui.CmdCFiles();
			CommandResultCompile(null);

			return AppCommands.CMD_OK;
		}
		public static String CommandExecutable(string[] parameters)
		{
			gui.CmdExecutable();
			CommandFResult(null);
			return AppCommands.CMD_OK;
		}

		public static String CommandAddTest(string[] parameters)
		{
			CommandLoadZip(null);
			CommandLoadInput(null);
			CommandLoadOutput(null);
			gui.CmdAddTestCase();
			
			return AppCommands.CMD_OK;
		}

		public static String CommandTimeout(string[] parameters)
		{

			gui.CmdTimeout();

			return AppCommands.CMD_OK;
		}

		public static String CommandGrading(string[] parameters)
		{

			gui.CmdGrading();

			return AppCommands.CMD_OK;
		}
	}
}
