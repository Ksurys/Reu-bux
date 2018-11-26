using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Data;

namespace Reu_bux
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Connect());
        }
        public static DataTable Tovar_Select;
        public static DataTable Tip_Tovar_Select;
        public static DataTable Sklad_Select;
        public static DataTable Tov_Na_Sklad_Select;
        public static DataTable Role_Select;
        public static DataTable Personal_Select;
        public static int RG_MA;
        public static int RG_SA;
        public static int RG_TSA;
        public static int UID;
        public static int SYACCSS;
        public static int MACCSS;
        public static int SACCSS;
        public static int TNSACCSS;
        public static bool Value;
        public static bool authorized = false;
        public static DataTable Tov_Na_Sklad_filter;
        public static DataTable _Sost_Check_Select;
        public static string _FIO;
        public static string _Role;
        public static int _Check_N;
        public static int _Folow_Id_Check_Data;
        public static int _all_cena;
        public static decimal _cena_za_sht;
        public static int _enter_Price;
        public static DataTable _Print_Tov_List;
        public static DataTable _Print_Tov_Na_Skd_List;
    }
}
