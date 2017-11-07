
namespace AccessData.DTO
{
    using System;
    public class PersonaDTO
    {

        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string PRIMERAPELLIDO { get; set; }
        public string SEGUNDOAPELLIDO { get; set; }
        public DateTime FECHAINGRESO { get; set; }
        public int EDAD { get; set; }
        public decimal SALARIO { get; set; }
        public int CARGO { get; set; }
        public int CIUDAD { get; set; }

    }
}
