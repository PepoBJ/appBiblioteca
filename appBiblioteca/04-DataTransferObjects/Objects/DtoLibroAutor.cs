namespace _04_DataTransferObjects.Objects
{
    public class DtoLibroAutor
    {
        #region properties
        
        public string codigoLibroAutor { get; set; }
        public string codigoAutor { get; set; }
        public string codigoLibro { get; set; }

        #endregion

        #region parents
        
        public virtual DtoAutor parentAutor { get; set; }
        
        public virtual DtoLibro parentLibro { get; set; }

        #endregion
    }
}