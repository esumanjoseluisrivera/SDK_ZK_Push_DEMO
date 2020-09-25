using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    /// <summary>
    /// Registro de asistencia
    /// </summary>
    public class AttLogBll
    {
        private AttLogDal _dal = new AttLogDal();
        /// <summary>
        /// Obtener registros
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="userid"></param>
        /// <param name="devsn"></param>
        /// <returns></returns>
        public DataTable GetByTime(DateTime starttime, DateTime endtime, string userid, string devsn)
        {
            return _dal.GetByTime(starttime, endtime, userid, devsn);
        }
        /// <summary>
        /// Limpiar registros
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            return _dal.ClearAll();
        }
        /// <summary>
        /// Añadir
        /// </summary>
        /// <param name="attlog"></param>
        /// <returns></returns>
        public int Add(AttLogModel attlog)
        {
            if (_dal.IsExist(attlog.PIN, attlog.AttTime))
                return 0;

            return _dal.Add(attlog);
        }
    }
}
