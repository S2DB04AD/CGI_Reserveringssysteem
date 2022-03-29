/*
 * DataManager: DmCruds
 * Declaration of the CRUDS interface
 */

namespace DataManager
{
    using System.Data;

    public interface DmCruds
    {
        public string ConStr { get; set; }
        public void Start();
        public void Stop();

        public void Create(string query, DataTable data);
        public DataTable Read(string query);
        public void Update(string query, DataTable data);
        public void Delete(string query);
        public void Select(string query);
    }
}