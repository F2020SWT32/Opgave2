﻿using System;
using System.IO;

/// <summary>
/// Summary description for Class1
/// </summary>
public class LogFile
{

	private string logFile = "logfile.txt";

	public LogFile();
	public logWrite(int arg, int rfid)
    {
		using (var writer = File.AppendText(logFile))
        {
            if(arg = 1)
            {
                writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", rfid);
            }
            else if(arg = 2)
            {
                writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", rfid);
            }
        }
    }

}

public interface ILogFile
{
    public logWrite(int arg, int rfid);
}