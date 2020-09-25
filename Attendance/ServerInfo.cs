using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Attendance
{
    /// <summary>
    /// información del servidor
    /// </summary>
    public class ServerInfo
    {
        /// <summary>
        /// Número de versión del protocolo admitido por el servidor
        /// </summary>
        public const string VERSION = "2.2.14";
        /// <summary>
        /// Según la versión del protocolo que se desarrolle el servidor
        /// </summary>
        public const string PushProtVer = "2.4.1";

        /// <summary>
        /// ¿El software admite la solicitud de parámetro de configuración de inserción del dispositivo? 0 no lo admite, 1 lo admite y no lo admite de forma predeterminada cuando no está configurado.
        /// </summary>
        public const string PushOptionsFlag = "1";
    }
}
