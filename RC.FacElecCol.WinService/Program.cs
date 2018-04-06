namespace RC.FacElecCol.ServicioWindows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            #if DEBUG
            //While debugging this section is used.
            using (ServicioWindows myService = new ServicioWindows())
            {
                myService.OnDebug();
            }

            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            #else
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new ServicioWindows()
                };
                ServiceBase.Run(ServicesToRun);
            #endif
        }
    }
}
