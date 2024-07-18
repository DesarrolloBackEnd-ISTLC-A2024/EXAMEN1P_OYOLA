namespace EXAMEN1P_OYOLA.Models
{
    public class Futbolista
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int numero_camisa { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public DateTime fecha_retiro { get; set; }
        public string estado { get; set; }

    }
}
