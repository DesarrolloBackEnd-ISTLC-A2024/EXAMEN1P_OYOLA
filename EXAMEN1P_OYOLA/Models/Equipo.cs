namespace EXAMEN1P_OYOLA.Models
{
    public class Equipo
    {
        public int id_equipo { get; set; }
        public string nombre { get; set; }
        public string lugar_equipo { get; set; }
        public int campeonatos_ganados { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string estado { get; set; }
    }
}
