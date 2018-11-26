using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Reu_bux
{
    class Base_Using
    {
        public string main_accss_value = "select [dbo].[role_list].[main_access] from [dbo].[role_list] where [naim_role]='";
        public string sale_accss_value = "select [dbo].[role_list].[sale_access] from [dbo].[role_list] where [naim_role]='";
        public string tov_skld_accss_value = "select [dbo].[role_list].[tovar_sklad_access] from [dbo].[role_list] where [naim_role]='";
        public void View_Price_void(DataGridView valueTable)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            SqlCommand View_Price_Select = new SqlCommand("select * from [dbo].[AllTovar]", _RI.Connection);
            _RI.Connection.Open();
            SqlDataReader tableReader = View_Price_Select.ExecuteReader();
            DataTable dataValue = new DataTable();
            dataValue.Load(tableReader);
            valueTable.DataSource = dataValue;
            valueTable.Columns[0].Visible = true;
            valueTable.Columns[1].Visible = true;
            valueTable.Columns[2].Visible = true;
            valueTable.Columns[0].Width = 300;
            valueTable.Columns[1].Width = 400;
            valueTable.Columns[2].Width = 400;
            valueTable.ReadOnly = true;
            _RI.Connection.Close();
        }
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

        public void Tovar_void()
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand Tovar_Select = new SqlCommand("select [id_tovar], [naim_tovar], [cena_tovara], [vid_tovara_id] from " +
                                                     "[dbo].[tovar]", _RI.Connection);
            SqlDataReader tableReader = Tovar_Select.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(tableReader);
            Program.Tovar_Select = Table;
            _RI.Connection.Close();
        }

        public void Tip_Tovara_void()
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand Tip_Tovar_Select = new SqlCommand("select [id_vid_tovara], [naim_vid_tovara] from [dbo].[vid_tovara]", _RI.Connection);
            SqlDataReader tableReader = Tip_Tovar_Select.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(tableReader);
            Program.Tip_Tovar_Select = Table;
            _RI.Connection.Close();
        }


        public void Sklad_void()
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand Sklad_Select = new SqlCommand("select [id_sklad], [adress_sklad] from [dbo].[sklad]", _RI.Connection);
            SqlDataReader tableReader = Sklad_Select.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(tableReader);
            Program.Sklad_Select = Table;
            _RI.Connection.Close();
        }



        public void Tovar_Na_Sklad_void()
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand Tov_Na_Sklad_Select = new SqlCommand("select [id_tovar_na_sklade], [tovar_id], [sklad_id], " +
                                                            "[kol_vo_tovara], [id_tovar], [naim_tovar], [cena_tovara], " +
                                                            "[vid_tovara_id], [id_sklad], [adress_sklad] from [dbo].[tovar_na_sklade] " +
                                                            "inner join [dbo].[tovar] on [dbo].[tovar_na_sklade].[tovar_id]=" +
                                                            "[dbo].[tovar].[id_tovar] inner join [dbo].[sklad] on " +
                                                            "[dbo].[tovar_na_sklade].[sklad_id]=[dbo].[sklad].[id_sklad]", _RI.Connection);
            SqlDataReader tableReader = Tov_Na_Sklad_Select.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(tableReader);
            Program.Tov_Na_Sklad_Select = Table;
            _RI.Connection.Close();
        }

        internal void Personal_new_void(string text1, string text2, string text3, string text4, int v)
        {
            throw new NotImplementedException();
        }

        public void Role_List_Select_void()
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand Role_Select = new SqlCommand("select [id_role_list], [naim_role], [main_access], [sale_access], [tovar_sklad_access] " +
                                                    "from [Prodazhi_tovarov_i_uslug].[dbo].[role_list]", _RI.Connection);
            SqlDataReader tableReader = Role_Select.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(tableReader);
            Program.Role_Select = Table;
            _RI.Connection.Close();
        }

        public void Personal_Select_void()
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand Personal_Select = new SqlCommand("select [id_personal_list], [f_p], [i_p], [o_p], [password_personal], [role_list_id], " +
                                                        "[date_create_personal], [system_access] from [Prodazhi_tovarov_i_uslug].[dbo].[personal_list]", _RI.Connection);
            SqlDataReader tableReader = Personal_Select.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(tableReader);
            Program.Personal_Select = Table;
            _RI.Connection.Close();
        }

        public void get_role_setting_void(string value)
        {
            int a, b, c;
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand MA_cmd = new SqlCommand(main_accss_value + value + "'", _RI.Connection);
            SqlCommand SA_cmd = new SqlCommand(sale_accss_value + value + "'", _RI.Connection);
            SqlCommand TNA_cmd = new SqlCommand(tov_skld_accss_value + value + "'", _RI.Connection);
            a = Convert.ToInt16(MA_cmd.ExecuteScalar().ToString());
            b = Convert.ToInt16(SA_cmd.ExecuteScalar().ToString());
            c = Convert.ToInt16(TNA_cmd.ExecuteScalar().ToString());
            Program.RG_MA = a;
            Program.RG_SA = b;
            Program.RG_TSA = c;
            _RI.Connection.Close();
        }

        public void Tip_Isrt_void(string NMValue)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("vid_tovara_add", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@naim_vid_tovara", NMValue);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
        public void Tip_Updt_void(string NMValue, int ID)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("vid_tovara_update", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@naim_vid_tovara", NMValue);
            StrPrc.Parameters.AddWithValue("@id_vid_tovara", ID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
        public void Tip_Del_void(int ID)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("vid_tovara_delete", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@id_vid_tovara", ID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
        public void Tovar_insert_void(string NTvalue, float CNvalue, int TID)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("tovar_add", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@naim_tovar", NTvalue);
            StrPrc.Parameters.AddWithValue("@cena_tovara", CNvalue);
            StrPrc.Parameters.AddWithValue("@vid_tovara_id", TID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
        public void Tovar_update_void(int ID, string NTvalue, float CNvalue, int TID)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("tovar_edit", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@naim_tovar", NTvalue);
            StrPrc.Parameters.AddWithValue("@cena_tovara", CNvalue);
            StrPrc.Parameters.AddWithValue("@vid_tovara_id", TID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
        public void Tovar_delete_void(int ID)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("tovar_delete", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@id_tovar", ID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
        public void Sklad_insert_void(string value)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("sklad_add", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@adress_sklad", value);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
        public void Sklad_update_void(int ID, string value)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("sklad_edit", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@adres_sklad", value);
            StrPrc.Parameters.AddWithValue("@id_sklad", ID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
        public void Sklad_delete_void(int ID)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("sklad_delete", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@id_sklad", ID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
        public void Tov_n_Skld_insert_void(int TIDValue, int SkIDValue, int value)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("tovar_na_sklade_add", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@tovar_id", TIDValue);
            StrPrc.Parameters.AddWithValue("@sklad_id", SkIDValue);
            StrPrc.Parameters.AddWithValue("@kol_vo_tovara", value);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
        public void Tov_n_Skld_update_void(int ID, int TIDValue, int SkIDValue, int value)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("tovar_na_sklade_edit", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@id_tovar_na_sklade", ID);
            StrPrc.Parameters.AddWithValue("@tovar_id", TIDValue);
            StrPrc.Parameters.AddWithValue("@sklad_id", SkIDValue);
            StrPrc.Parameters.AddWithValue("@kol_vo_tovara", value);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }

        public void Tov_n_Skld_delete_void(int ID)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("tovar_na_sklade_delete", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@id_tovar_na_sklade", ID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }

        public void Role_List_insert_void(string value, int MID, int SID, int TNID)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("role_list_add", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@naim_role", value);
            StrPrc.Parameters.AddWithValue("@main_access", MID);
            StrPrc.Parameters.AddWithValue("@sale_access", SID);
            StrPrc.Parameters.AddWithValue("@tovar_sklad_access", TNID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }

        public void Role_List_update_void(int ID, string value, int MID, int SID, int TNID)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("role_list_edit", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@id_role_list", ID);
            StrPrc.Parameters.AddWithValue("@naim_role", value);
            StrPrc.Parameters.AddWithValue("@main_access", MID);
            StrPrc.Parameters.AddWithValue("@sale_access", SID);
            StrPrc.Parameters.AddWithValue("@tovar_sklad_access", TNID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }

        public void Role_List_delete_void(int ID)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("role_list_delete", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@id_role_list", ID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
        public void Personal_bag_void(int ID)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("personal_list_bag", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@id_personal_list", ID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
        public void Personal_new_void(int RV, string FV, string IV, string OV, string PV)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("personal_list_new", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@f_p", FV);
            StrPrc.Parameters.AddWithValue("@i_p", IV);
            StrPrc.Parameters.AddWithValue("@o_p", OV);
            StrPrc.Parameters.AddWithValue("@password_personal", PV);
            StrPrc.Parameters.AddWithValue("@role_list_id", RV);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }

        public void Personal_edit_void(int ID, string FV, string IV, string OV, string PV, int RV, int SID)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("personal_list_edit", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@id_personal_list", ID);
            StrPrc.Parameters.AddWithValue("@f_p", FV);
            StrPrc.Parameters.AddWithValue("@i_p", IV);
            StrPrc.Parameters.AddWithValue("@o_p", OV);
            StrPrc.Parameters.AddWithValue("@password_personal", PV);
            StrPrc.Parameters.AddWithValue("@role_list_id", RV);
            StrPrc.Parameters.AddWithValue("@system_access", SID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }
        public void Personal_delete_void(int ID)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand StrPrc = new SqlCommand("personal_list_delete", _RI.Connection);
            StrPrc.CommandType = CommandType.StoredProcedure;
            StrPrc.Parameters.AddWithValue("@id_personal_list", ID);
            StrPrc.ExecuteNonQuery();
            _RI.Connection.Close();
        }

        public Connect _CN = new Connect();
        private Reg_Info _RI;
        private SqlCommand _CmdSql;
        public event Action<bool> Status;
        public event Action<DataTable> List_Server;
        public event Action<DataSet> List_Dbs;
        private string us_id_qr = "select [dbo].[personal_list].[id_personal_list] from[dbo].[personal_list] " +
                                  "inner join [dbo].[role_list] on [dbo].[personal_list].[role_list_id]=[dbo]." +
                                  "[role_list].[id_role_list] where [personal_list].[password_personal] = '";
        private string sy_access = "select [dbo].[personal_list].[system_access] from[dbo].[personal_list] " +
                                  "inner join[dbo].[role_list] on[dbo].[personal_list].[role_list_id]=[dbo]." +
                                  "[role_list].[id_role_list] where[personal_list].[id_personal_list] = ";
        private string m_access = "select [dbo].[role_list].[main_access] from[dbo].[role_list] " +
                                  "inner join[dbo].[personal_list] on[dbo].[personal_list].[role_list_id]=[dbo]." +
                                  "[role_list].[id_role_list] where[personal_list].[id_personal_list] = ";
        private string sl_access = "select [dbo].[role_list].[sale_access] from[dbo].[role_list] inner join" +
                                  "[dbo].[personal_list] on[dbo].[personal_list].[role_list_id]=[dbo].[role_list]." +
                                  "[id_role_list] where[personal_list].[id_personal_list] = ";
        private string tv_skld_access = "select [dbo].[role_list].[tovar_sklad_access] from[dbo].[role_list] inner " +
                                  "join[dbo].[personal_list] on[dbo].[personal_list].[role_list_id]=[dbo].[role_list]." +
                                  "[id_role_list] where[personal_list].[id_personal_list] = ";
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

        public void Autentification(string us_pas)
        {
            try
            {
                _RI = new Reg_Info();
                _RI.Set_Connection();
                _CmdSql = new SqlCommand(us_id_qr + us_pas + "'", _RI.Connection);
                MessageBox.Show(_CmdSql.CommandText.ToString());
                _RI.Connection.Open();
                Program.UID = Convert.ToInt32(_CmdSql.ExecuteScalar().ToString());
                switch (Program.UID)
                {
                    case (0):
                        MessageBox.Show("Вас нет в системе! Повторите ввод пароля!");
                        break;
                    default:
                        _RI = new Reg_Info();
                        _CmdSql = new SqlCommand(sy_access + Program.UID, _RI.Connection);
                        _RI.Set_Connection();
                        _RI.Connection.Open();
                        Program.SYACCSS = Convert.ToInt32(_CmdSql.ExecuteScalar().ToString());
                        switch (Program.SYACCSS)
                        {
                            case (0):
                                MessageBox.Show("У вас нет прав доступа к системе!");
                                break;
                            case (1):
                                _RI = new Reg_Info();
                                _RI.Set_Connection();
                                _RI.Connection.Open();
                                SqlCommand SAccssCmd = new SqlCommand(sl_access + Program.UID, _RI.Connection);
                                SqlCommand TNSAccssCmd = new SqlCommand(tv_skld_access + Program.UID, _RI.Connection);
                                SqlCommand MAccssCmd = new SqlCommand(m_access + Program.UID, _RI.Connection);
                                Program.SACCSS = Convert.ToInt32(SAccssCmd.ExecuteScalar().ToString());
                                Program.TNSACCSS = Convert.ToInt32(TNSAccssCmd.ExecuteScalar().ToString());
                                Program.MACCSS = Convert.ToInt32(MAccssCmd.ExecuteScalar().ToString());
                                Program.Value = true;
                                _RI.Connection.Close();
                                break;
                        }
                        _RI.Connection.Close();
                        break;
                }
                _RI.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string sost_check = "select [id_check_sost], [check_data_id], [tovar_na_sklade_id], [naim_tovar], [cena_tovara], [kol_vo_tov_v_checke], " +
                                   "[cena_za_kol_vo] from [dbo].[check_sost] full outer join [dbo].[tovar_na_sklade] on [dbo].[tovar_na_sklade].[id_tovar_na_sklade] = " +
                                   "[dbo].[check_sost].[tovar_na_sklade_id] join [dbo].[tovar] on [dbo].[tovar].[id_tovar] = " +
                                   "[dbo].[tovar_na_sklade].[tovar_id] where [dbo].[check_sost].[check_data_id] = ";
        public void Personal_Sale_void(int ID)
        {
            string FIO, role;
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand FIO_Cmd = new SqlCommand("select [dbo].[personal_list].[f_p]+' ' + SUBSTRING([dbo].[personal_list].[i_p],1,1)+'. '+SUBSTRING([dbo].[personal_list].[o_p],1,1) as \"FIO\" from [dbo].[personal_list] where [dbo].[personal_list].[id_personal_list] = " + ID.ToString(), _RI.Connection);
            SqlCommand Role_CMD = new SqlCommand("select [dbo].[role_list].[naim_role] from [dbo].[role_list] inner join [dbo].[personal_list] on [dbo].[personal_list].[role_list_id]=[dbo].[role_list].[id_role_list] where [personal_list].[id_personal_list]=" + ID.ToString(), _RI.Connection);
            FIO = FIO_Cmd.ExecuteScalar().ToString();
            role = Role_CMD.ExecuteScalar().ToString();
            Program._FIO = FIO;
            Program._Role = role;
            _RI.Connection.Close();
        }
        public void Check_sost_void(int id)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand Check_sost_cmd = new SqlCommand(sost_check + id.ToString(), _RI.Connection);
            SqlDataReader tableReader = Check_sost_cmd.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(tableReader);
            Program._Sost_Check_Select = Table;
            _RI.Connection.Close();
        }
        public void New_Sale()
        {
            int Chek_N, folow_c_d;
            DateTime Day = DateTime.Today;
            DateTime Time = DateTime.Now;
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand Count_Chek = new SqlCommand("select COUNT(*) from [dbo].[check_data]", _RI.Connection);
            Chek_N = Convert.ToInt32(Count_Chek.ExecuteScalar().ToString()) + 1;
            Program._Check_N = Chek_N;
            SqlCommand New_Check_data = new SqlCommand("insert into [dbo].[check_data] (num_check_data,date_check_data,time_check_data,personal_list_id, itog_check_data) values (" + Chek_N.ToString() + ",'" + Day.ToString("dd-MM-yyyy") + "', '" + Time.ToString("hh:mm:ss") + "', " + Program.UID.ToString() + ",'00.00')", _RI.Connection);
            New_Check_data.ExecuteNonQuery();
            SqlCommand Select_folow_check = new SqlCommand("select MAX([id_check_data]) from [dbo].[check_data]", _RI.Connection);
            folow_c_d = Convert.ToInt32(Select_folow_check.ExecuteScalar().ToString());
            Program._Folow_Id_Check_Data = folow_c_d;
            _RI.Connection.Close();
        }
        public void select_list_to_sale(string sklad)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand Tov_Na_Sklad_filter = new SqlCommand("SELECT [id_tovar_na_sklade], [tovar_id], [sklad_id], [kol_vo_tovara], [id_tovar], [naim_tovar], [cena_tovara], [vid_tovara_id], [id_sklad], [adress_sklad], [naim_tovar]+' - кол-во: '+ CONVERT(varchar,[kol_vo_tovara]) as \"Товар со склада\" FROM" +
                "[dbo].[tovar_na_sklade] inner join [dbo].[tovar] on [dbo].[tovar_na_sklade].[tovar_id]=[dbo].[tovar].[id_tovar] inner join [dbo].[sklad] on [dbo].[tovar_na_sklade].[sklad_id]=[dbo].[sklad].[id_sklad] where [sklad_id] =" + sklad, _RI.Connection);
            SqlDataReader tableReader = Tov_Na_Sklad_filter.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(tableReader);
            Program.Tov_Na_Sklad_filter = Table;
            _RI.Connection.Close();
        }

        public void upload_check(int id_tov_sklad)
        {
            int cena_all;
            string id_s;
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand Search = new SqlCommand("select [dbo].[check_sost].[id_check_sost] from [dbo].[check_sost] join [dbo].[check_data] on [dbo].[check_sost].[check_data_id] = [dbo].[check_data].[id_check_data] where ([dbo].[check_data].[num_check_data] = " + Program._Check_N.ToString() + ") and ([dbo].[check_sost].[tovar_na_sklade_id] = " + id_tov_sklad.ToString() + ")", _RI.Connection);
            SqlCommand Upload = new SqlCommand("", _RI.Connection);
            try
            {
                id_s = Search.ExecuteScalar().ToString();
                Upload.CommandText = "update [dbo].[check_sost] set kol_vo_tov_v_checke = kol_vo_tov_v_checke+1, cena_za_kol_vo = (kol_vo_tov_v_checke+1)*" + Math.Floor(Program._cena_za_sht).ToString() + "where id_check_sost = " + id_s;
            }
            catch
            {
                id_s = null;
                Upload.CommandText = "insert into [dbo].[check_sost](check_data_id, tovar_na_sklade_id, kol_vo_tov_v_checke, cena_za_kol_vo) values (" + Program._Folow_Id_Check_Data.ToString() + "," + id_tov_sklad.ToString() + ", 1,'" + Math.Floor(Program._cena_za_sht).ToString() + "')";
            }
            Upload.ExecuteNonQuery();
            SqlCommand remove = new SqlCommand("update [dbo].[tovar_na_sklade] set kol_vo_tovara = kol_vo_tovara-1 where id_tovar_na_sklade =" + id_tov_sklad.ToString(), _RI.Connection);
            remove.ExecuteNonQuery();
            SqlCommand count = new SqlCommand("select sum([dbo].[check_sost].[cena_za_kol_vo]) from [dbo].[check_sost] where [dbo].[check_sost].[check_data_id] = " + Program._Folow_Id_Check_Data.ToString(), _RI.Connection);
            try
            {
                cena_all = Convert.ToInt32(count.ExecuteScalar().ToString());
            }
            catch
            {
                cena_all = 0;
            }
            Program._all_cena = cena_all;
            _RI.Connection.Close();
        }
        public void check_closed(int value)
        {
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            _CmdSql = new SqlCommand("update [dbo].[check_data] set [itog_check_data] =  " + value + " where [id_check_data] = " + Program._Folow_Id_Check_Data.ToString(), _RI.Connection);
            _CmdSql.ExecuteNonQuery();
            _RI.Connection.Close();
        }

        public void Tovar_Print_void(string query)
        {
            query = "";
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand Tovar_Select = new SqlCommand("SELECT [naim_tovar] as \"Название товара\",[cena_tovara] as \"Цена за шт.\" FROM [dbo].[tovar]" + query, _RI.Connection);
            SqlDataReader tableReader = Tovar_Select.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(tableReader);
            Program._Print_Tov_List = Table;
            _RI.Connection.Close();
        }
        public void Tov_Na_Sklad_Print_void(string query)
        {
            query = "";
            _RI = new Reg_Info();
            _RI.Set_Connection();
            _RI.Connection.Open();
            SqlCommand Tovar_Select = new SqlCommand("SELECT  [naim_tovar] as \"Название товара\",[cena_tovara] as \"Цена товара\",  [kol_vo_tovara] as \"Количество на складе\", [adress_sklad] as \"Склад\" FROM [dbo].[tovar_na_sklade] inner join [dbo].[tovar] on [dbo].[tovar_na_sklade].[tovar_id]=[dbo].[tovar].[id_tovar] inner join [dbo].[sklad] on [dbo].[tovar_na_sklade].[sklad_id]=[dbo].[sklad].[id_sklad]" + query, _RI.Connection);
            SqlDataReader tableReader = Tovar_Select.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(tableReader);
            Program._Print_Tov_Na_Skd_List = Table;
            _RI.Connection.Close();
        }
    }
}
