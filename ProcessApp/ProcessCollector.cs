using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class ProcessCollector
{
    public static List<object> GetRunningProcesses()
    {
        var processList = new List<object>();
        foreach (var process in Process.GetProcesses())
        {
            processList.Add(new
            {
                ProcessName = process.ProcessName,
                ProcessId = process.Id
            });
        }
        return processList;
    }
}
