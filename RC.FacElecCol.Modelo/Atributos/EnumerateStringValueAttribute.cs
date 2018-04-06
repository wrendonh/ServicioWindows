namespace RC.FacElecCol.Modelo.Atributos
{
    public class EnumerateStringValueAttribute : System.Attribute
    {
        #region Properties

        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public EnumerateStringValueAttribute(string value)
        {
            StringValue = value;
        }

        #endregion

    }
}
