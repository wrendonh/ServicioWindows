namespace RC.FacElecCol.ServicioWindows
{
    using Fachada.Interfaz;
    using log4net;
    using RC.FacElecCol.Modelo.Entidades;
    using RC.FacElecCol.Modelo.Enums;
    using System;
    using System.Linq;
    using System.ServiceModel;
    using System.Threading.Tasks;
    using System.Timers;

    public partial class ServicioWindows : WinServiceBase
    {
        #region Logger
        protected ILog _logger;
        #endregion

        #region Timer
        Timer GeneralTimer;
        #endregion

        #region const
        private const string messageUnhandledException = "Unhandle Exception: ";
        #endregion

        IActividadesFachada _actividades;

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
                _actividades = Kernel.Resolve<IActividadesFachada>(GetService<IActividadesFachada>());
                _actividades.MarcarActividadesEnEjecucionAEstadoNinguno();
                InicializarTimers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected override void OnStop()
        {

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
            GeneralTimer = new Timer();

            ConfigurarTimer(GeneralTimer);
        }

        private void ConfigurarTimer(Timer timer)
        {
            timer.Interval = Convert.ToDouble(300000);
            timer.Elapsed += new ElapsedEventHandler(EncolarGeneralTimer_Elapsed);
            timer.Enabled = true;
        }

        private void EncolarGeneralTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var listaActividades = Enum.GetValues(typeof(Tareas)).Cast<Tareas>().ToList();
            Parallel.ForEach(listaActividades, actividad =>
            {
                EjecutarActividad(actividad);
            });
        }

        private void EjecutarActividad(Tareas actividad)
        {
            ActividadesDto actividadPorEjecutar = _actividades.CargarActividadPorId((int)actividad);
            if (actividadPorEjecutar.PorEjecutar)
            {
                RentingFacElecCol.RentingFeCoServiceClient servicioWcf = new RentingFacElecCol.RentingFeCoServiceClient();
                //using (new OperationContextScope(servicioWcf.InnerChannel))
                //{

                //}

                switch (actividad)
                {
                    case Tareas.GenerarDocumento:
                        servicioWcf.GenerarXml();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
