namespace RC.FacElecCol.Fachada.Implementacion
{
    using RC.FacElecCol.Fachada.Interfaz;
    using RC.FacElecCol.Modelo.Entidades;
    using System.Collections.Generic;

    public class BaseFachada : IBaseFachada
    {
        public List<MensajeDto> Mensajes { get; set; }

        public void SetMessages(List<MensajeDto> mensajes)
        {
            Mensajes = mensajes;
        }
    }
}
