using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Configuration;
using System.Data;


namespace DataLogic
{
   public class Registrationdata
    {
        SqlConnection cn = new SqlConnection(@"server = LENOVO-PC\SQLEXPRESS; database=Banking;Trusted_Connection=True");

       // BankingEntities db = new BankingEntities();
        public void insert(RegistrationBO bo,Dictionary<string,string> d1)
        {             
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText= "registration_sp";
            cn.Open();
            cmd.Parameters.Add("fname", bo.fname);
            cmd.Parameters.Add("lname", bo.lname);
            cmd.Parameters.Add("ac_no", bo._ac_no);
            cmd.Parameters.Add("address", bo._add);
            cmd.Parameters.Add("b_name", bo._brname);
            cmd.Parameters.Add("dob", bo._dob);
            cmd.Parameters.Add("usernm", d1["username"]);
            cmd.Parameters.Add("pass", d1["pass"]);
            cmd.Parameters.Add("q1", d1["q1"]);
            cmd.Parameters.Add("ans1", d1["ans1"]);
            cmd.Parameters.Add("q2", d1["q2"]);
            cmd.Parameters.Add("ans2", d1["ans2"]);
            cmd.Parameters.Add("q3", d1["q3"]);
            cmd.Parameters.Add("ans3", d1["ans3"]);
            cmd.Parameters.Add("email", d1["email"]);


            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public Dictionary<string,string> checkandgetcerditial(int ac_no,string pas)
        {
            int f = 1;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "loginselect_sp";
            cn.Open();
            cmd.Parameters.Add("ac_no", ac_no);
            cmd.Parameters.Add("password", pas);
            SqlDataReader dr = cmd.ExecuteReader();
            Dictionary<string, string> d1 = new Dictionary<string, string>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    d1.Add(dr["q1"].ToString(), dr["ans1"].ToString());
                    d1.Add(dr["q2"].ToString(), dr["ans2"].ToString());
                    d1.Add(dr["q3"].ToString(), dr["ans3"].ToString());
                }

                cn.Close();
               // return d1;
            }
           else
            {
                f = 0;
                d1.Add("Invalid", "Invalid");

            }
            return d1;
        }

        public  List<string> getaccounts(int ac_no)
        {
           
           // List<string> m1 = new List<string>();
            //Dictionary<int, List<string>> m = new Dictionary<int, List<string>>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "Getaccounts";
            cmd.Parameters.Add("ac_no", ac_no);
            cn.Open();
            List<string> m1 = new List<string>();
            SqlDataReader rd=cmd.ExecuteReader();
            while(rd.Read())
            {
                m1.Add(rd["account_type"].ToString());
                   // m.Add(Convert.ToInt32(rd["account_no"]),m1);      
            }

            return m1;
        }

        public DataSet loadaccounts(int ac_no,string ac_nm,string sp_nm)
        {
            cn.Close();
          
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = sp_nm;
            cmd.Parameters.Add("ac_no", ac_no);
             cmd.Parameters.Add("ac_type",ac_nm);
            SqlDataAdapter dr = new SqlDataAdapter();
            DataSet dt = new DataSet();
            cn.Open();
            dr.SelectCommand = cmd;
            dr.Fill(dt);  
            return dt;       

        }

        public SqlDataReader getusers(int ac_no)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "getuserdetails";
            cmd.Parameters.Add("ac_no", ac_no);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
       
                return dr;

        }
        public void add_new_account(double amt,int id,string ac_type,int ac_no)
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "Add_NewAccount_sp";
            cmd.Parameters.Add("amount", amt);
            cmd.Parameters.Add("r_id", id);
            cmd.Parameters.Add("ac_type", ac_type);
            cmd.Parameters.Add("ac_no", ac_no);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public SqlDataReader getaccount(string ac_type,int ac_no)
        {
            cn.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "Tr_getaccountdetail_sp";
            cmd.Parameters.Add("ac_type",ac_type);
            cmd.Parameters.Add("main_ac_no",ac_no);
            cn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }
        public SqlDataReader updatedepositeaccount(string email)
        {
            cn.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "Tr_getToAccount_details";
            cmd.Parameters.Add("email",email);
     
            cn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;


        }

        public void addtransfertransaction(int reg_id,int to_ac,int from_ac,double withdraw,string qest,string ans)
        {
            cn.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "Transaction_insert_sp";
            cmd.Parameters.Add("reg_id1",reg_id);
            cmd.Parameters.Add("to_ac", to_ac);
            cmd.Parameters.Add("from_ac", from_ac);
            cmd.Parameters.Add("withdraw", withdraw);
            cmd.Parameters.Add("qest",qest);
            cmd.Parameters.Add("ans", ans);

            cn.Open();
            cmd.ExecuteNonQuery();

        }
        public DataSet pendingtransaction(int ac_no)
        {

            cn.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "pending_deposite_sp";
            cmd.Parameters.Add("ac_no", ac_no);

            SqlDataAdapter dr = new SqlDataAdapter();
            DataSet dt = new DataSet();
            cn.Open();
            dr.SelectCommand = cmd;
            dr.Fill(dt);
            return dt;
        }

        public int finaldeposite(int toac,int fromac,string ac_type,double money,int tr_id)
        {
            cn.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "deposite_inaccount_sp";
            cmd.Parameters.Add("toac_no", toac);
            cmd.Parameters.Add("fromac_no",fromac);
            cmd.Parameters.Add("ac_type",ac_type);
            cmd.Parameters.Add("amount", money);
            cmd.Parameters.Add("tr_id",tr_id);
            cn.Open();
          return  cmd.ExecuteNonQuery();
        }

        public DataSet gettransaction(int ac)
        {

            cn.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetTransaction";
            cmd.Parameters.Add("ac_no", ac);
            SqlDataAdapter dr = new SqlDataAdapter();
            DataSet dt = new DataSet();
            cn.Open();
            dr.SelectCommand = cmd;
            dr.Fill(dt);
            return dt;
        }
        public SqlDataReader select_account(int ac_no)
        {
            cn.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "select_account";
            cmd.Parameters.Add("ac_no", ac_no);

            cn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;


        }

        public void update_deduct_ac(int ac,double amt,int tr_id)
        {
            cn.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "update_deduct_ac";
           
            cmd.Parameters.Add("fromac_no", ac);
            cmd.Parameters.Add("amount", amt);
            cmd.Parameters.Add("tr_id", tr_id-1);
            cn.Open();
            cmd.ExecuteNonQuery();
           

        }
        public void Transfer_between_ac(int f_ac,int t_ac,string ac_type,double amt)
        {
            cn.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "Transfer_between_ac";

            cmd.Parameters.Add("from_acno", f_ac);
            cmd.Parameters.Add("ac_type", ac_type);
            cmd.Parameters.Add("to_ac",t_ac);
            cmd.Parameters.Add("amt", amt);
            cn.Open();
            cmd.ExecuteNonQuery();


        }

    }
}