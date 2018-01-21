namespace _04_DataTransferObjects.Objects
{
    public class DtoLibroCategoria
    {
        #region properties
        
        public string codigoLibroCategoria { get; set; }
        public string codigoCategoria { get; set; }
        public string codigoLibro { get; set; }

        #endregion

        #region parents
        
        public virtual DtoCategoria parentCategoria { get; set; }
        
        public virtual DtoLibro parentLibro { get; set; }

        #endregion
    }
}