namespace RC.FacElecCol.ServicioWindows
{
    using Fachada.Interfaz;
    using log4net;
    using RC.FacElecCol.Modelo.Enums;
    using System;
    using System.Timers;

    public partial class ServicioWindows : WinServiceBase
    {
        #region Logger
        protected ILog _logger;
        #endregion

        #region Timer
        Timer EnviarComprobanteTimer;
        #endregion

        #region const
        private const string messageUnhandledException = "Unhandle Exception: ";
        #endregion

        private IActividadesPeriodicasFachada _actividadesPeriodicas;
        //private IPeriodicActivityService _periodicActivityservice;

        public ServicioWindows()
        {
            InitializeComponent();
            InitializeClass();
        }

        protected override void OnStart(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            try
            {
                IActividadesFachada actividades = Kernel.Resolve<IActividadesFachada>(GetService<IActividadesFachada>());
                actividades.MarcarActividadesEnEjecucionAEstadoNinguno();
                InicializarTimers();

                //_actividadesPeriodicas = Kernel.Resolve<IActividadesPeriodicasFachada>(GetService<IActividadesPeriodicasFachada>());

                //_cancellationTokenSource = new CancellationTokenSource();
                //CancellationToken token = _cancellationTokenSource.Token;

                //_processActivities = Task.Run(() => VerificaYEjecutaActividadesAsincronamente(token), token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected override void OnStop()
        {
            try
            {
                _actividadesPeriodicas.Dispose();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            try
            {
                //_scheduledActivityservice.Dispose();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                _logger.Error(messageUnhandledException, (Exception)e.ExceptionObject);
            }
            catch (Exception exe)
            {
                _logger.Error(messageUnhandledException, exe);
            }
        }

        private void InicializarTimers()
        {
            EnviarComprobanteTimer = new Timer();

            ConfigurarTimer(EnviarComprobanteTimer, Actividades.EnviarDocumento);
        }

        private void ConfigurarTimer(Timer timer, Actividades parameterTimeName)
        {
            SetInterval(timer);

            switch (parameterTimeName)
            {
                case Actividades.EnviarDocumento:
                    timer.Elapsed += new ElapsedEventHandler(EncolarEnviarDocumentoTimer_Elapsed);
                    timer.Enabled = true;
                    break;
            }
        }

        private void SetInterval(Timer timer)
        {
            try
            {
                //SettingBL settingsBL = new SettingBL();
                //ResponseDto<SettingDto> responseSetting = settingsBL.GetById(parameterTimeName);
                timer.Interval = Convert.ToDouble(30000);
            }
            catch (Exception ex)
            {
                timer.Interval = 60000;
            }
        }


        private void EncolarEnviarDocumentoTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RentingFacElecCol.RentingFeCoServiceClient test = new RentingFacElecCol.RentingFeCoServiceClient();
            test.GenerarXml();
        }

        private void ValidaYEjecutaActividades()
        {
            _actividadesPeriodicas.EjecutarTodasActividadesPeriodicas();
            //_scheduledActivityservice.ExecuteAllScheduledActivities(token);
        }


    }
}
