using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;
using Crypt;


namespace Reu_bux
{
    class Reg_Info
    {
        public Crypt_Class Crpt = new Crypt_Class();
        public static string DS;
        public static string IC;
        public static string UN;
        public static string UP;
        public SqlConnection Connection = new SqlConnection("Data Source = Empty; Initial Catalog = Empty; " +
        "Persist Security Info = True; User ID = Empty; Password = \"Empty\"");

        public void Register_get()
        {
            try
            {
                RegistryKey Sale_Option = Registry.CurrentUser;
                RegistryKey DBCon = Sale_Option.CreateSubKey("DBConOp");
                DS = Crpt.de_code_text(DBCon.GetValue("DS").ToString());
                IC = Crpt.de_code_text(DBCon.GetValue("IC").ToString());
                UN = Crpt.de_code_text(DBCon.GetValue("UN").ToString());
                UP = Crpt.de_code_text(DBCon.GetValue("UP").ToString());
                Set_Connection();
            }
            catch
            {
                RegistryKey Sale_Option = Registry.CurrentUser; 
                RegistryKey DBCon = Sale_Option.CreateSubKey("DBConOp");
                DBCon.SetValue("DS", "Empty");
                DBCon.SetValue("IC", "Empty");
                DBCon.SetValue("UN", "Empty");
                DBCon.SetValue("UP", "Empty");
            }
        }

        public void Register_set(string DSvalue, string ICvalue, string UNvalue, string UPvalue)
        {
            RegistryKey Sale_Option = Registry.CurrentUser;
            RegistryKey DBCon = Sale_Option.CreateSubKey("DBConOp");
            DBCon.SetValue("DS", Crpt.code_text(DSvalue));
            DBCon.SetValue("IC", Crpt.code_text(ICvalue));
            DBCon.SetValue("UN", Crpt.code_text(UNvalue));
            DBCon.SetValue("UP", Crpt.code_text(UPvalue));
            Register_get();
        }

        public void Set_Connection()
        {
            Connection.ConnectionString = "Data Source = " + DS + "; Initial Catalog = " + IC + "; Persist Security Info=True;" +
            " User ID = " + UN + ";Password=\"" + UP + "\"";
        }
    }
}