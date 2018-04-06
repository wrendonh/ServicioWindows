namespace RC.FacElecCol.Aspecto
{
    using Castle.DynamicProxy;
    using log4net;
    using RC.FacElecCol.Modelo.Enums;
    using RC.FacElecCol.Modelo.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Reflection;

    public class ExcepcionAttribute : AspectAttribute
    {
        private ILog Logger { get; }

        public ExcepcionAttribute()
        {
            Logger = LogManager.GetLogger(typeof(ExcepcionAttribute));
        }

        public override void ProcessInvocation(IInvocation invocation)
        {
            IProxyTargetAccessor accessor = invocation?.Proxy as IProxyTargetAccessor;
            if (accessor == null)
            {
                return;
            }

            MethodInfo target = accessor.DynProxyGetTarget().GetType().GetMethod("SetMessages");

            try
            {
                invocation.Proceed();
            }
            catch (DbException dbEx)
            {
                object[] parameters = GetMessages(dbEx, TipoExcepciones.BaseDeDatos);
                target.Invoke(invocation.InvocationTarget, parameters);
                Logger.Error(dbEx);
            }
            catch (Exception ex)
            {
                object[] parameters = GetMessages(ex, TipoExcepciones.Generico);
                target.Invoke(invocation.InvocationTarget, parameters);
                Logger.Error(ex);
            }
        }

        public object[] GetMessages(object exceptionObj, TipoExcepciones exceptionType)
        {
            string message = string.Empty;
            switch (exceptionType)
            {
                case TipoExcepciones.Generico:
                    Exception exception = (Exception)exceptionObj;
                    message = exception.Message;
                    break;
                case TipoExcepciones.BaseDeDatos:
                    DbException dbException = (DbException)exceptionObj;
                    message = dbException.Message;
                    break;                
                default:
                    break;
            }

            List<MensajeDto> messages = new List<MensajeDto>();
            MensajeDto messageObj = new MensajeDto
            {
                Mensaje = message,
                Tipo = (int)TipoMensajes.Error
            };

            messages.Add(messageObj);
            object[] parameters = new object[1];
            parameters[0] = messages;

            return parameters;
        }
    }
}
