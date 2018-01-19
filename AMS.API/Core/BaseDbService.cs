using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XCU.Common.DBHelper;

namespace AMS.API
{
    public class BaseDbService
    {
        /// <summary>
        /// Retuen generic DbConnector object to communicate with database
        /// </summary>
        /// <returns></returns>
        public XCUDBBase GetDbConnector()
        {
            XCUDBBase dbConnector = new XCUDBBase();

            #region Comment : Here using XmlReader get DB connection string

            dbConnector.DBName = "AMSModuleDB";

            #endregion

            //dbConnector.DBConnectionString = DbConnectionString;
            //dbConnector.CreateDBObjects(Providers.SqlServer);
            //dbConnector.CreateConnection();

            return dbConnector;
        }

        /// <summary>
        /// Method will set default DbNull value for supplied object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected object ValueOrNull(object value)
        {
            return value ?? DBNull.Value;
        }
    }
}