namespace RC.FacElecCol.Fachada.Interfaz
{
    using RC.FacElecCol.Modelo.Entidades;
    using System.Collections.Generic;

    public interface IBaseFachada
    {
        List<MensajeDto> Mensajes { get; set; }
        void SetMessages(List<MensajeDto> messages);
    }
}
