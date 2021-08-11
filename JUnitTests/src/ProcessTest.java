import static org.junit.jupiter.api.Assertions.*;

import java.io.PrintWriter;
import java.io.StringWriter;
import org.junit.Assert;

import org.junit.jupiter.api.Test;

import Process.ProcessRun;

class ProcessTest {
	
	private static final String PROMPT = "\r\n>";
	private static final String APP_UNDER_TEST =  "C:\\Users\\repti\\Downloads\\project2\\CshConsoleAPI\\bin\\Debug\\CshConsoleAPI.exe";

	/*Test the stack trace print is working*/
	@Test
	void testTrace() {	
		try {
			//throw new Exception();
		} catch (Exception e) {

			StringWriter sw = new StringWriter();
			PrintWriter pw = new PrintWriter(sw);
			e.printStackTrace(pw);
			String trace1 = sw.toString();
			System.out.print(trace1);
			
			Assert.assertTrue(!trace1.isEmpty());
		}
	}
	
	/*Test the console application runs*/
	@Test
	void testConsole() {
		String output = "";
		ProcessRun process = new ProcessRun();
		String[] command = {APP_UNDER_TEST,""};
		try {
			output = process.Run(command);
			System.out.println(output);
						
			output = process.Exit();			
		}
		catch (Exception e) {
			//	In case of exception.
			StringWriter sw = new StringWriter();
			PrintWriter pw = new PrintWriter(sw);
			//	Read the trace information.
			e.printStackTrace(pw);
			String trace = sw.toString();
			
			//	Write the trace to console and fail the test.
			System.out.print(trace);
			Assert.assertTrue(!trace.isEmpty());
		}
		return;
	}
	
	
	/***
	 * Test the console application runs 
	 * and execute command-line echo command.
	 */
	@Test
	void simpleRunCommand() {
		String output = "";
		ProcessRun process = new ProcessRun();
		String[] command = {APP_UNDER_TEST,""};
		try {
			output = process.Run(command);
			Assert.assertTrue(output.contentEquals(">"));
			//shows gui
			output = process.Command("gui()");
			Assert.assertTrue(output.contentEquals("ok" + PROMPT));
			
			//browse zip file
			output = process.Command("zip()");
			Assert.assertTrue(output.contentEquals("ok" + PROMPT));
			
			//browse input file
			output = process.Command("input()");
			Assert.assertTrue(output.contentEquals("ok" + PROMPT));
			
			//browse output file
			output = process.Command("output()");
			Assert.assertTrue(output.contentEquals("ok" + PROMPT));
			
			//compile programs
			output = process.Command("compile()");
			Assert.assertTrue(output.contentEquals("ok" + PROMPT));

			output = process.Exit();			
		}
		catch (Exception e) {
			//	In case of exception.
			StringWriter sw = new StringWriter();
			PrintWriter pw = new PrintWriter(sw);
			//	Read the trace information.
			e.printStackTrace(pw);
			String trace = sw.toString();
			
			//	Write the trace to console and fail the test.
			System.out.print(trace);
			Assert.assertTrue(!trace.isEmpty());
		}
		return;
	}
	
	


}
