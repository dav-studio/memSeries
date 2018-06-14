using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Series
{
    class SaveAndRestore
    {
        private DataGridView _data;

        public SaveAndRestore()
        {
        }

        /// <summary>
        /// Save Contents In An External File (xml).
        /// </summary>
        /// <param name="table"></param>
        public void save(DataTable table)
        {
            File.Delete("dFile");
            DataSet dsSend = new DataSet();
            dsSend.Tables.Add(table);
            dsSend.WriteXml("dFile");
            dsSend.Tables.Remove(table);
        }

        /// <summary>
        /// Load Contents From External File (xml).
        /// </summary>
        /// <returns>   DataTable   </returns>
        public DataTable Load()
        {
            DataSet dsLoad = new DataSet();
            try
            {
                dsLoad.ReadXml("dFile");
                return dsLoad.Tables["File"];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
