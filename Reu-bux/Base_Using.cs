using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Reu_bux
{
    class Base_Using
    {
        //public string main_accss_value = "select [dbo].[role_list].[main_access] from [dbo].[role_list] where [naim_role]='";
        //public string sale_accss_value = "select [dbo].[role_list].[sale_access] from [dbo].[role_list] where [naim_role]='";
        //public string tov_skld_accss_value = "select [dbo].[role_list].[tovar_sklad_access] from [dbo].[role_list] where [naim_role]='";
        //public void View_Price_void(DataGridView valueTable)
        //{
        //    _RI = new Reg_Info();
        //    _RI.Set_Connection();
        //    SqlCommand View_Price_Select = new SqlCommand("select * from [dbo].[AllTovar]", _RI.Connection);
        //    _RI.Connection.Open();
        //    SqlDataReader tableReader = View_Price_Select.ExecuteReader();
        //    DataTable dataValue = new DataTable();
        //    dataValue.Load(tableReader);
        //    valueTable.DataSource = dataValue;
        //    valueTable.Columns[0].Visible = true;
        //    valueTable.Columns[1].Visible = true;
        //    valueTable.Columns[2].Visible = true;
        //    valueTable.Columns[0].Width = 300;
        //    valueTable.Columns[1].Width = 400;
        //    valueTable.Columns[2].Width = 400;
        //    valueTable.ReadOnly = true;
        //    _RI.Connection.Close();
        //}
        public decimal price(int tovar)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand Cmd = new SqlCommand("Select [cena_tovara] from [dbo].[tovar_na_sklade] inner join [dbo].[tovar] on [dbo].[tovar_na_sklade].[tovar_id] = " +
                                            "[dbo].[tovar].[id_tovar] inner join [dbo].[sklad] on [dbo].[tovar_na_sklade].[sklad_id] = [dbo].[sklad].[id_sklad] " +
                                            "where [id_tovar_na_sklade] = " + tovar.ToString(), _RI.Connection);
            decimal a = Convert.ToDecimal(Cmd.ExecuteScalar().ToString());
            _RI.Connection.Close();
            return a;
        }

        //public void Tovar_void()
        //{
        //    _RI = new Reg_Info();
        //    _RI.Set_Connection();
        //    _RI.Connection.Open();
        //    SqlCommand Tovar_Select = new SqlCommand("select [id_tovar], [naim_tovar], [cena_tovara], [vid_tovara_id] from " +
        //                                             "[dbo].[tovar]", _RI.Connection);
        //    SqlDataReader tableReader = Tovar_Select.ExecuteReader();
        //    DataTable Table = new DataTable();
        //    Table.Load(tableReader);
        //    Program.Tovar_Select = Table;
        //    _RI.Connection.Close();
        //}

        


     



        //public void Tovar_Na_Sklad_void()
        //{
        //    _RI = new Reg_Info();
        //    _RI.Set_Connection();
        //    _RI.Connection.Open();
        //    SqlCommand Tov_Na_Sklad_Select = new SqlCommand("select [id_tovar_na_sklade], [tovar_id], [sklad_id], " +
        //                                                    "[kol_vo_tovara], [id_tovar], [naim_tovar], [cena_tovara], " +
        //                                                    "[vid_tovara_id], [id_sklad], [adress_sklad] from [dbo].[tovar_na_sklade] " +
        //                                                    "inner join [dbo].[tovar] on [dbo].[tovar_na_sklade].[tovar_id]=" +
        //                                                    "[dbo].[tovar].[id_tovar] inner join [dbo].[sklad] on " +
        //                                                    "[dbo].[tovar_na_sklade].[sklad_id]=[dbo].[sklad].[id_sklad]", _RI.Connection);
        //    SqlDataReader tableReader = Tov_Na_Sklad_Select.ExecuteReader();
        //    DataTable Table = new DataTable();
        //    Table.Load(tableReader);
        //    Program.Tov_Na_Sklad_Select = Table;
        //    _RI.Connection.Close();
        //}

        internal void Personal_new_void(string text1, string text2, string text3, string text4, int v)
        {
            throw new NotImplementedException();
        }

        //public void Role_List_Select_void()
        //{
        //    _RI = new Reg_Info();
        //    _RI.Set_Connection();
        //    _RI.Connection.Open();
        //    SqlCommand Role_Select = new SqlCommand("select [id_role_list], [naim_role], [main_access], [sale_access], [tovar_sklad_access] " +
        //                                            "from [Prodazhi_tovarov_i_uslug].[dbo].[role_list]", _RI.Connection);
        //    SqlDataReader tableReader = Role_Select.ExecuteReader();
        //    DataTable Table = new DataTable();
        //    Table.Load(tableReader);
        //    Program.Role_Select = Table;
        //    _RI.Connection.Close();
        //}

        

   

        //public void Tip_Isrt_void(string NMValue)
        //{
        //    _RI = new Reg_Info();
        //    _RI.Set_Connection();
        //    _RI.Connection.Open();
        //    SqlCommand StrPrc = new SqlCommand("vid_tovara_add", _RI.Connection);
        //    StrPrc.CommandType = CommandType.StoredProcedure;
        //    StrPrc.Parameters.AddWithValue("@naim_vid_tovara", NMValue);
        //    StrPrc.ExecuteNonQuery();
        //    _RI.Connection.Close();
        //}
        //public void Tip_Updt_void(string NMValue, int ID)
        //{
        //    _RI = new Reg_Info();
        //    _RI.Set_Connection();
        //    _RI.Connection.Open();
        //    SqlCommand StrPrc = new SqlCommand("vid_tovara_update", _RI.Connection);
        //    StrPrc.CommandType = CommandType.StoredProcedure;
        //    StrPrc.Parameters.AddWithValue("@naim_vid_tovara", NMValue);
        //    StrPrc.Parameters.AddWithValue("@id_vid_tovara", ID);
        //    StrPrc.ExecuteNonQuery();
        //    _RI.Connection.Close();
        //}
        //public void Tip_Del_void(int ID)
        //{
        //    _RI = new Reg_Info();
        //    _RI.Set_Connection();
        //    _RI.Connection.Open();
        //    SqlCommand StrPrc = new SqlCommand("vid_tovara_delete", _RI.Connection);
        //    StrPrc.CommandType = CommandType.StoredProcedure;
        //    StrPrc.Parameters.AddWithValue("@id_vid_tovara", ID);
        //    StrPrc.ExecuteNonQuery();
        //    _RI.Connection.Close();
        //}



        public Connect _CN = new Connect();
        private Reg_Info _RI;
        private SqlCommand _CmdSql;
        public event Action<bool> Status;
        public event Action<DataTable> List_Server;
        public event Action<DataSet> List_Dbs;
        //private string sy_access = "Select [dbo].[Pravo].Access, [dbo].[Pravo].Dolzhnost from [dbo].[Polzovatel] " +
        //    "JOIN [dbo].[Pravo] ON [dbo].[Polzovatel].Pravo_id = [dbo].[Pravo].id_Pravo WHERE [dbo].[Polzovatel].id_Polzovatel = 1";
        private string us_id_qr = "SELECT [dbo].[Polzovatel].[id_Polzovatel] from [dbo].[Polzovatel] " +
                                  "where [dbo].[Polzovatel].[password_Polz] = '";
        private string find_user = "SELECT COUNT(*) from [dbo].[Polzovatel] " +
                                  "where [dbo].[Polzovatel].[password_Polz] = '";

        public void Connection_State()
        {
            _RI = new Reg_Info();
            _RI.Register_get();
            try
            {
                _RI.Connection.Open();
                Status(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Status(false);
            }
        }

        public void Get_Server_List()
        {
            SqlDataSourceEnumerator ServersCheck = SqlDataSourceEnumerator.Instance;
            DataTable ServersTable = ServersCheck.GetDataSources();
            List_Server(ServersTable);
        }

        public void Get_Base_List()
        {
            _RI = new Reg_Info();
            try
            {
                SqlConnection GDtBsLstCn = new SqlConnection("Data Source = " + Reg_Info.DS + "; Initial Catalog = master; " +
                                                             "Persist Security Info=True; User ID = " + Reg_Info.UN +
                                                             ";Password=\"" + Reg_Info.UP + "\"");
                GDtBsLstCn.Open();
                SqlDataAdapter BsAdpt = new SqlDataAdapter("exec sp_helpdb", GDtBsLstCn);
                DataSet BDst = new DataSet();
                BsAdpt.Fill(BDst, "db");
                List_Dbs(BDst);
                _RI.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Autorization(string user_password)
        {
            try
            {
                _RI = new Reg_Info();
                _RI.Set_Connection();
                //_CmdSql = new SqlCommand(sy_access, _RI.Connection);
                //Program.SYSACCESS = Convert.ToInt32(_CmdSql.ExecuteScalar().ToString());
                _CmdSql = new SqlCommand(find_user + user_password + "'", _RI.Connection);
                _RI.Connection.Open();
                Program.AUTH = Convert.ToInt32(_CmdSql.ExecuteScalar().ToString());
                _RI.Connection.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка авторизации");
            }
        }

        public void Autentification(string us_pas)
        {
            try
            {
                _RI = new Reg_Info();
                _RI.Set_Connection();
                _CmdSql = new SqlCommand(us_id_qr + us_pas + "'", _RI.Connection);
                _RI.Connection.Open();
                Program.UID = Convert.ToInt32(_CmdSql.ExecuteScalar().ToString());
                switch (Program.UID)
                {
                    case (0):
                        MessageBox.Show("Вас нет в системе! Повторите ввод пароля!");
                        break;
                    case (1):
                        Program.authorized = true;
                        break;
                    //default:
                    //    _RI = new Reg_Info();
                    //    _CmdSql = new SqlCommand(sy_access + Program.UID, _RI.Connection);
                    //    _RI.Set_Connection();
                    //    _RI.Connection.Open();
                    //    Program.SYACCSS = Convert.ToInt32(_CmdSql.ExecuteScalar().ToString());
                    //    switch (Program.SYACCSS)
                    //    {
                    //        case (0):
                    //            MessageBox.Show("У вас нет прав доступа к системе!");
                    //            break;
                    //        case (1):
                    //            _RI = new Reg_Info();
                    //            _RI.Set_Connection();
                    //            _RI.Connection.Open();
                    //            SqlCommand SAccssCmd = new SqlCommand(sl_access + Program.UID, _RI.Connection);
                    //            SqlCommand TNSAccssCmd = new SqlCommand(tv_skld_access + Program.UID, _RI.Connection);
                    //            SqlCommand MAccssCmd = new SqlCommand(m_access + Program.UID, _RI.Connection);
                    //            Program.SACCSS = Convert.ToInt32(SAccssCmd.ExecuteScalar().ToString());
                    //            Program.TNSACCSS = Convert.ToInt32(TNSAccssCmd.ExecuteScalar().ToString());
                    //            Program.MACCSS = Convert.ToInt32(MAccssCmd.ExecuteScalar().ToString());
                    //            Program.Value = true;
                    //            _RI.Connection.Close();
                    //            break;
                    //    }
                    //    _RI.Connection.Close();
                    //    break;
                }
                _RI.Connection.Close();
            }
            catch
            {
                MessageBox.Show("Пользователь не найден!");
            }
        }

        public void sotr_void()
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand STR = new SqlCommand("select [id_sotr], [F_sotr], [I_sotr], [O_sotr], [Prihod], [Uxod] " +
                                                        "from [Rabochee_Vremya].[dbo].[sotr]", _RI.Connection);
            SqlDataReader tableReader = STR.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(tableReader);
            Program.STR = Table;
            _RI.Connection.Close();
        }

        public void polz_void()
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand PLZ = new SqlCommand("select [id_Polzovatel], [F_Polz], [I_Polz], [O_Polz], [password_Polz], [Pravo_id] " +
                                                        "from [Rabochee_Vremya].[dbo].[Polzovatel]", _RI.Connection);
            SqlDataReader tableReader = PLZ.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(tableReader);
            Program.PLZ = Table;
            _RI.Connection.Close();
        }

        public void Sotr_edit_void(int ID, string FV, string IV, string OV, string PR, string UX)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("Sotr_edit", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@id_Sotr", ID);
            StrPrc.Parameters.AddWithValue("@f_Sotr", FV);
            StrPrc.Parameters.AddWithValue("@i_Sotr", IV);
            StrPrc.Parameters.AddWithValue("@o_Sotr", OV);
            StrPrc.Parameters.AddWithValue("@Prihod", PR);
            StrPrc.Parameters.AddWithValue("@Uxod", UX);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }

        public void Polz_edit_void(int ID, string FV, string IV, string OV, string PW, string PO)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("Polzovatel_edit", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@id_Polzovatel", ID);
            StrPrc.Parameters.AddWithValue("@F_Polz", FV);
            StrPrc.Parameters.AddWithValue("@I_Polz", IV);
            StrPrc.Parameters.AddWithValue("@O_Polz", OV);
            StrPrc.Parameters.AddWithValue("@password_Polz", PW);
            StrPrc.Parameters.AddWithValue("@Pravo_id", PO);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
            //public void Personal_Sale_void(int ID)
            //{
            //    string FIO, role;
            //    _RI = new Reg_Info();
            //    _RI.Set_Connection();
            //    _RI.Connection.Open();
            //    SqlCommand FIO_Cmd = new SqlCommand("select [dbo].[personal_list].[f_p]+' ' + SUBSTRING([dbo].[personal_list].[i_p],1,1)+'. '+SUBSTRING([dbo].[personal_list].[o_p],1,1) as \"FIO\" from [dbo].[personal_list] where [dbo].[personal_list].[id_personal_list] = " + ID.ToString(), _RI.Connection);
            //    SqlCommand Role_CMD = new SqlCommand("select [dbo].[role_list].[naim_role] from [dbo].[role_list] inner join [dbo].[personal_list] on [dbo].[personal_list].[role_list_id]=[dbo].[role_list].[id_role_list] where [personal_list].[id_personal_list]=" + ID.ToString(), _RI.Connection);
            //    FIO = FIO_Cmd.ExecuteScalar().ToString();
            //    role = Role_CMD.ExecuteScalar().ToString();
            //    Program._FIO = FIO;
            //    Program._Role = role;
            //    _RI.Connection.Close();
            //}
            //public void Check_sost_void(int id)
            //{
            //    _RI = new Reg_Info();
            //    _RI.Set_Connection();
            //    _RI.Connection.Open();
            //    SqlCommand Check_sost_cmd = new SqlCommand(sost_check + id.ToString(), _RI.Connection);
            //    SqlDataReader tableReader = Check_sost_cmd.ExecuteReader();
            //    DataTable Table = new DataTable();
            //    Table.Load(tableReader);
            //    Program._Sost_Check_Select = Table;
            //    _RI.Connection.Close();
            //}






        }
}
