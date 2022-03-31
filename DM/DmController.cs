/*
 * DataManager: DmController
 * Static program part
 */

namespace DataManager
{
    using System.Data;

    public static class DmController
    {
        private static DmCruds CrudDriver;

        public static void Start(DmCruds crd)
        {
            CrudDriver = crd;
            crd.Start();
        }

        public static void Stop()
        {
            CrudDriver.Stop();
            CrudDriver = null;
        }

        public static void Create(string query, DataTable data)
        {
            CrudDriver.Create(query, data);
        }

        public static DataTable Read(string query)
        { 
            return CrudDriver.Read(query);
        }

        public static void Update(string query, DataTable data)
        {
            CrudDriver.Update(query, data);
        }

        public static void Delete(string query)
        {
            CrudDriver.Delete(query);
        }

        public static void Select(string query)
        {
            CrudDriver.Select(query);
        }
    }
}