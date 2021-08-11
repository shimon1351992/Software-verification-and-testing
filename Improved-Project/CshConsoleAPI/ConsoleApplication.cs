using System;
using System.Threading.Tasks;




namespace CshConsoleAPI
{
    class Program
	{
      private const int ERROR_SUCCESS = 0;


      private static Task<string> GetInputAsync()
      {
         return Task.Run(() => Console.ReadLine());
      }

      static int Main(string[] args)
		{
         // Indicates whther to continue reading input.
         bool running = true;

         // Initialize the commands object.
         Commands pCommands = CommandsApi.CommandsInit();

         // Assign the echo command function to the command list.
         CommandsApi.CommandAdd(ref pCommands, AppCommands.CMD_ECHO, AppCommands.CommandEcho);
         CommandsApi.CommandAdd(ref pCommands, AppCommands.CMD_EXIT, AppCommands.CommandExit);

         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_SHOW, DialogCommands.CommandGuiShow);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_LOAD_ZIP, DialogCommands.CommandLoadZip);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_LOAD_INPUT, DialogCommands.CommandLoadInput);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_LOAD_OUTPUT, DialogCommands.CommandLoadOutput);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_RESULT, DialogCommands.CommandResult);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_FRESULT, DialogCommands.CommandFResult);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_COMMENTS, DialogCommands.CommandResultComments);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_COMPILE, DialogCommands.CommandResultCompile);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_RUN_PROGRAMS, DialogCommands.CommandResultRunPrograms);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_32BIT, DialogCommands.CommandC32bit);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_C_FILES, DialogCommands.CommandCFiles);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_EXEC, DialogCommands.CommandExecutable);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_ADD_TEST, DialogCommands.CommandAddTest);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_TIMEOUT, DialogCommands.CommandTimeout);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_GRADING, DialogCommands.CommandGrading);
         CommandsApi.CommandAdd(ref pCommands, DialogCommands.GUI_CLOSE, DialogCommands.CommandGuiClose);

         // Store user input text.
         string command_line;

         // Continues loop.
         while (running)
         {
            // Print command promped '>'
            Console.Write(AppCommands.CMD_PROMPED);

            // Get console command text"
            //command_line = Console.ReadLine();
            command_line = GetInputAsync().Result;

            // Call for command execution.
            String result = CommandsApi.CommandExec(ref pCommands, command_line);
            Console.Out.WriteLine(result);
            running = (AppCommands.CMD_EXIT != result);
         }

         Environment.ExitCode = ERROR_SUCCESS;
         return ERROR_SUCCESS;
      }
	}
}
