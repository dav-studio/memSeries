using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace Series
{
    public partial class Menu : Form
    {

        private static string _name;
        private static int _Season;
        private static int _Episod;

        /// <summary>
        /// Table of Data.
        /// </summary>
        DataTable dt = new DataTable("File");

        /// <summary>
        /// Create Save and Restore Class Object.
        /// </summary>
        SaveAndRestore save = new SaveAndRestore();

        /// <summary>
        /// Constructure.
        /// </summary>
        public Menu()
        {
            InitializeComponent();
            /// Read and Load the Contents.
            refresh();
            /// Create Table Structure.
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Names", typeof(string));
            dt.Columns.Add("Season", typeof(int));
            dt.Columns.Add("Episod", typeof(int));
        }

        /// <summary>
        /// Add new Content And Load The Grid. (Action)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAdd.Text != "")
            {
                saveName();
                refresh();
                for (int i = 0; i < dgvList.Rows.Count; i++)
                    dgvList.CurrentCell = dgvList.Rows[i].Cells["Names"];
            }
        }

        /// <summary>
        /// Modifying an Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                int _id = Int32.Parse(dgvList.CurrentRow.Cells["ID"].Value.ToString());
                ///
                int index = dgvList.SelectedRows[0].Index;
                /// Updating ...
                File.Delete("dFile");                
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = Int32.Parse(dgvList.Rows[i].Cells["ID"].Value.ToString());
                    dr["Names"] = txtAdd.Text;
                    dr["Season"] = Int32.Parse(dgvList.Rows[i].Cells["Season"].Value.ToString()); ;
                    dr["Episod"] = Int32.Parse(dgvList.Rows[i].Cells["Episod"].Value.ToString()); ;
                    /// Save On File.
                    dt.Rows.Add(dr);
                }
                save.save(dt);
                ///
                refresh();
                ///
                dgvList.CurrentCell = dgvList.Rows[index].Cells["Names"];
            }
        }

        /// <summary>
        /// Removing an Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                int index = dgvList.SelectedRows[0].Index;
                /// Removing ...
                dgvList.Rows.RemoveAt(index);
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = Int32.Parse(dgvList.Rows[i].Cells["ID"].Value.ToString());
                    dr["Names"] = dgvList.Rows[i].Cells["Names"].Value.ToString();
                    dr["Season"] = Int32.Parse(dgvList.Rows[i].Cells["Season"].Value.ToString()); ;
                    dr["Episod"] = Int32.Parse(dgvList.Rows[i].Cells["Episod"].Value.ToString()); ;
                    /// Save On File.
                    dt.Rows.Add(dr);
                }
                save.save(dt);
                dt.Clear();
                int count = dgvList.Rows.Count;
                for (int i = count; i > 0; i--)
                    dgvList.Rows.RemoveAt(i - 1);
                /// 
                refresh();
                ///
                if (dgvList.Rows.Count > 0)
                    if (dgvList.Rows.Count > 1)
                        dgvList.CurrentCell = dgvList.Rows[index - 1].Cells["Names"];
                    else
                        dgvList.CurrentCell = dgvList.Rows[0].Cells["Names"];
            }
        }

        /// <summary>
        /// Action of Season Watched.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeasonWatched_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                _Season = Int32.Parse(dgvList.CurrentRow.Cells["Season"].Value.ToString());
                _Episod = Int32.Parse(dgvList.CurrentRow.Cells["Episod"].Value.ToString());
                //
                int _id = Int32.Parse(dgvList.CurrentRow.Cells["ID"].Value.ToString());
                //
                updateStatus(_id, true);
            }
        }

        /// <summary>
        /// Action of Episod Watched.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEpisodWatched_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                _Season = Int32.Parse(dgvList.CurrentRow.Cells["Season"].Value.ToString());
                _Episod = Int32.Parse(dgvList.CurrentRow.Cells["Episod"].Value.ToString());
                //
                int _id = Int32.Parse(dgvList.CurrentRow.Cells["ID"].Value.ToString());
                //
                updateStatus(_id, false);
            }
        }

        /// <summary>
        /// Create New Code for New Content.
        /// </summary>
        /// <returns>   codeValue   </returns>
        private int generateCode()
        {
            int count = dgvList.Rows.Count;
            int[] codes = new int[count];
            for (int i = 0; i < dgvList.Rows.Count; i++)
                codes[i] = Int32.Parse(dgvList.Rows[i].Cells["ID"].Value.ToString());
            ///
            int newID = 1;
            for (int i = 0; i < count; i++)
                if (codes[i] == newID)
                    newID++;
            ///
            return newID;
        }

        /// <summary>
        /// Reload the Contents.
        /// </summary>
        private void refresh()
        { dgvList.DataSource = save.Load(); }

        /// <summary>
        /// Save New Content and Created.
        /// </summary>
        private void saveName()
        {
            DataRow dr;
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr["ID"] = Int32.Parse(dgvList.Rows[i].Cells["ID"].Value.ToString());
                dr["Names"] = dgvList.Rows[i].Cells["Names"].Value.ToString();
                dr["Season"] = Int32.Parse(dgvList.Rows[i].Cells["Season"].Value.ToString()); ;
                dr["Episod"] = Int32.Parse(dgvList.Rows[i].Cells["Episod"].Value.ToString()); ;
                /// Save On File.
                dt.Rows.Add(dr);        
            }
            dr = dt.NewRow();
            //
            dr["ID"] = generateCode();
            dr["Names"] = txtAdd.Text;
            dr["Season"] = "0";
            dr["Episod"] = "0";
            /// Save On File.
            dt.Rows.Add(dr);
            save.save(dt);
            dt.Clear();
            int count = dgvList.Rows.Count;
            for (int i = count; i > 0; i--)
                dgvList.Rows.RemoveAt(i - 1);
        }

        /// <summary>
        /// Update the Value of Data Based on episod or seasons that been watched.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        private void updateStatus(int id, bool type)
        {
            if (type)
            {
                _Season++;
            }
            else
            {
                _Episod++;
            }
            /// Updating ...
            //File.Delete("dFile");    
            for (int i = 0; i < dgvList.Rows.Count; i++)
                if (Int32.Parse(dgvList.Rows[i].Cells["ID"].Value.ToString()) == id)
                {
                    dgvList.Rows[i].Cells["Season"].Value = _Season.ToString();
                    dgvList.Rows[i].Cells["Episod"].Value = _Episod.ToString();
                }
            ///

            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = Int32.Parse(dgvList.Rows[i].Cells["ID"].Value.ToString());
                dr["Names"] = dgvList.Rows[i].Cells["Names"].Value.ToString();
                dr["Season"] = Int32.Parse(dgvList.Rows[i].Cells["Season"].Value.ToString()); ;
                dr["Episod"] = Int32.Parse(dgvList.Rows[i].Cells["Episod"].Value.ToString()); ;
                /// Save On File.
                dt.Rows.Add(dr);                
            }
            save.save(dt);
            dt.Clear();
            int count = dgvList.Rows.Count;
            for (int i = count; i > 0; i--)
                dgvList.Rows.RemoveAt(i-1);
            ///
            refresh();
            ///
            for (int i = 0; i < dgvList.Rows.Count; i++)
                if (Int32.Parse(dgvList.Rows[i].Cells["ID"].Value.ToString()) == id)
                    dgvList.CurrentCell = dgvList.Rows[i].Cells["Names"];
        }

        /// <summary>
        /// based on List Selections changed to Select the Record.
        /// </summary>
        /// <param Name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
                txtAdd.Text = dgvList.SelectedRows[0].Cells["Names"].Value.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}



// sql version.
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using HoonamTools;
//using System.Data.SqlClient;


//namespace Series
//{
//    public partial class Menu : Form
//    {
//        private static string connectionStringFormat =
//            "Data Source = {0}; Initial Catalog = {1}; User ID = {2}; Password = {3}";

//        private static string connectionString;
//        private static string _name;
//        private static int _Season;
//        private static int _Episod;

//        SqlConnection connection;

//        DataTable dtSend = new DataTable("File");

//        public Menu()
//        {
//            InitializeComponent();
//            refresh();


//            dtSend.Columns.Add("ID", typeof(int));
//            dtSend.Columns.Add("Name", typeof(string));
//            dtSend.Columns.Add("Season", typeof(int));
//            dtSend.Columns.Add("Episod", typeof(int));
//        }

//        private void Connect()
//        {
//            connectionString = string.Format
//                (connectionStringFormat, "localhost", "chptr", "hoonamsandogh", "Sandogh");
//            /// 
//            connection = new SqlConnection(connectionString);
//            ///
//            try
//            {
//                connection.Open();
//            }
//            catch (Exception)
//            {
//                MessageBox.Show("اتصال با بانک اطلاعاتی امکان پذیر نیست");
//            }
//            //refresh();
//            //string command = new SqlCommand("Insert into seriesInfo (Name) Values ('" + txtAdd.TextSql + "')", cn);
//        }

//        private void saveName()
//        {
//            SaveAndRestore save = new SaveAndRestore(dgvList);
//            DataRow dr = dtSend.NewRow();
//            dr["Name"] = txtAdd.Text;
//            dr["Season"] = "0";
//            dr["Episod"] = "0";

//            dtSend.Rows.Add(dr);
//            save.save(dtSend);
//        }

//        private void saveNameSQL()
//        {
//            Connect();
//            SqlCommand command = new SqlCommand
//                ("Insert into seriesInfo (Name, Seasons, Episods) Values ('" + _name + "', 0, 0)", connection);
//            ///
//            command.ExecuteNonQuery();
//            ///
//            if (connection.State == ConnectionState.Open)
//            {
//                connection.Close();
//            }
//        }

//        private void refresh()
//        {
//            Connect();
//            string readCommand =
//                "SELECT * FROM seriesinfo";
//            ///
//            SqlDataAdapter load = new SqlDataAdapter
//                (readCommand, connection);
//            ///
//            System.Data.DataTable ret = new System.Data.DataTable();
//            load.Fill(ret);
//            dgvList.DataSource = ret;
//            ///
//            if (connection.State == ConnectionState.Open)
//            {
//                connection.Close();
//            }
//        }

//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            if (txtAdd.Text != "")
//            {
//                _name = txtAdd.Text;
//                saveName();
//                refresh();
//                for (int i = 0; i < dgvList.Rows.Count; i++)
//                {
//                    dgvList.CurrentCell = dgvList.Rows[i].Cells["Name"];
//                }
//            }
//        }

//        private void btnSeasonWatched_Click(object sender, EventArgs e)
//        {
//            if (dgvList.SelectedRows.Count > 0)
//            {
//                _Season = Int32.Parse(dgvList.CurrentRow.Cells["Seasons"].Value.ToString());
//                _Episod = Int32.Parse(dgvList.CurrentRow.Cells["Episods"].Value.ToString());
//                //
//                int _id = Int32.Parse(dgvList.CurrentRow.Cells["ID"].Value.ToString());
//                //
//                updateStatus(_id, true);
//            }
//        }

//        private void btnEpisodWatched_Click(object sender, EventArgs e)
//        {
//            if (dgvList.SelectedRows.Count > 0)
//            {
//                _Season = Int32.Parse(dgvList.CurrentRow.Cells["Seasons"].Value.ToString());
//                _Episod = Int32.Parse(dgvList.CurrentRow.Cells["Episods"].Value.ToString());
//                //
//                int _id = Int32.Parse(dgvList.CurrentRow.Cells["ID"].Value.ToString());
//                //
//                updateStatus(_id, false);
//            }
//        }

//        private void updateStatus(int id, bool type)
//        {
//            if (type)
//            {
//                _Season++;
//            }
//            else
//            {
//                _Episod++;
//            }
//            //
//            string updateCommand = string.Format
//                ("Update seriesInfo Set Seasons = {1}, Episods = {2} Where ID = {0} ", id, _Season, _Episod);
//            //
//            Connect();
//            SqlCommand command = new SqlCommand
//                (updateCommand, connection);
//            ///
//            command.ExecuteNonQuery();
//            ///
//            if (connection.State == ConnectionState.Open)
//            {
//                connection.Close();
//            }
//            //
//            refresh();
//        }

//        private void btnDel_Click(object sender, EventArgs e)
//        {
//            if (dgvList.SelectedRows.Count > 0)
//            {
//                string delCommand = string.Format
//                    ("Delete From seriesInfo Where ID = {0}", dgvList.CurrentRow.Cells["ID"].Value.ToString());
//                //
//                Connect();
//                //
//                SqlCommand command = new SqlCommand
//                    (delCommand, connection);
//                ///
//                command.ExecuteNonQuery();
//                ///
//                if (connection.State == ConnectionState.Open)
//                {
//                    connection.Close();
//                }
//                int index = dgvList.SelectedRows[0].Index;
//                refresh();
//                //
//                if (dgvList.Rows.Count > 0)
//                {
//                    if (dgvList.Rows.Count > 1)
//                    {
//                        dgvList.CurrentCell = dgvList.Rows[index - 1].Cells["Name"];
//                    }
//                    else
//                    {
//                        dgvList.CurrentCell = dgvList.Rows[0].Cells["Name"];
//                    }
//                }


//            }
//        }

//        private void btnEdit_Click(object sender, EventArgs e)
//        {
//            if (dgvList.SelectedRows.Count > 0)
//            {
//                int _id = Int32.Parse(dgvList.CurrentRow.Cells["ID"].Value.ToString());
//                string updateCommand = string.Format
//                    ("Update seriesInfo set Name = '{0}' Where ID = {1}", txtAdd.Text, _id);
//                //
//                Connect();
//                //
//                SqlCommand command = new SqlCommand
//                    (updateCommand, connection);
//                //
//                command.ExecuteNonQuery();
//                //
//                if (connection.State == ConnectionState.Open)
//                {
//                    connection.Close();
//                }
//                int index = dgvList.SelectedRows[0].Index;
//                refresh();
//                //
//                dgvList.CurrentCell = dgvList.Rows[index].Cells["Name"];
//            }
//        }

//        private void dgvList_SelectionChanged(object sender, EventArgs e)
//        {
//            if (dgvList.SelectedRows.Count > 0)
//            {
//                txtAdd.Text = dgvList.SelectedRows[0].Cells["Name"].Value.ToString();
//            }
//        }
//    }
//}

