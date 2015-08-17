using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    //[DataContract]
    public class Respuesta
    {
        public Respuesta()
        {
            PilaLlamadas = new List<string>();
        }

        //[DataMember]
        public string Mensaje { get; set; }
        //[DataMember]
        public object Objeto { get; set; }
        //[DataMember]
        public string Codigo { get; set; }
        //[DataMember]
        public Exception Error { get; set; }
        //[DataMember]
        public List<string> PilaLlamadas { get; set; }
    }

    public struct CodigoRespuestaTransaccion
    {
        public const string Exitoso = "01";
        public const string Fallido = "02";
        public const string ErrorGeneral = "03";
    }
}
