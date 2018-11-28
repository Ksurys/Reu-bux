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
        //public static DataTable Tovar_Select;
        //public static DataTable Tip_Tovar_Select;
        //public static DataTable Sklad_Select;
        //public static DataTable Tov_Na_Sklad_Select;
        //public static DataTable Role_Select;
        //public static DataTable Personal_Select;
        public static int RG_MA;
        public static int RG_SA;
        public static int RG_TSA;
        public static int UID;
        public static int AUTH;
        public static bool authorized;
        public static DataTable STR;
        public static DataTable PLZ;
        public static bool ADMINACCESS;
        public static int SYSACCESS;

    }
}
