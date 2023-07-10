using System;

namespace Ultraio
{
    public static class LaunchConfiguration
    {
        public static bool LaunchedFromUltraClient
        {
            get; private set;
        }

        static LaunchConfiguration()
        {
            LaunchedFromUltraClient = false;
            string[] args = Environment.GetCommandLineArgs();
            foreach (string arg in args)
            {
                if (arg.ToLower() == CommandLineConstants.UltraParameter)
                {
                    LaunchedFromUltraClient = true;
                }
            }
        }
    }
}