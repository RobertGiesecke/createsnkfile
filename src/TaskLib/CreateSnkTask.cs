using System.IO;
using Microsoft.Build.Utilities;

namespace RGiesecke.CreateSnkFile.MSBuild
{
    public class CreateSnkTask : AppDomainIsolatedTask
    {
        public string SnkFilePath { get; set; }
        public string SdkPath { get; set; }

        public override bool Execute()
        {
            var fullSnkFileName = Path.GetFullPath(SnkFilePath);

            if (!File.Exists(fullSnkFileName))
            {
                var args = string.Format(" -k \"{0}\"", fullSnkFileName);
                var startInfo = new System.Diagnostics.ProcessStartInfo("sn", args)
                {
                    WorkingDirectory = SdkPath
                };

                using (var p = System.Diagnostics.Process.Start(startInfo))
                {
                    p.WaitForExit();
                }
            }

            return true;
        }
    }
}
