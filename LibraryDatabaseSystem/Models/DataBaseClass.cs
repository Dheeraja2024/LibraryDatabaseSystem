using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
namespace LibraryDatabaseSystem.Models
{
    public class DataBaseClass
    {
        SqlConnection con;
         public DataBaseClass()
        {
            con = new SqlConnection(@"server=DESKTOP-ISLO3KG\SQLEXPRESS ;database=LibraryDbCore ;Integrated security= true;");
        }

        public string InsertDB(Customer objcls)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("RegisterUserWithTransaction", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", objcls.Name);
                cmd.Parameters.AddWithValue("@MembershipDate", objcls.MembershipDate);
                cmd.Parameters.AddWithValue("@Email", objcls.Email);
                cmd.Parameters.AddWithValue("@Password", objcls.Password);
                cmd.Parameters.AddWithValue("@Usertype", objcls.Usertype); 
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("INSERTED SUCCESSFULLY");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }

        public int LoginDB(Employee objcls)
        {
            try
            {
                int cid = 0;
                SqlCommand cmd = new SqlCommand("sp_LoginCount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", objcls.Id);
                cmd.Parameters.AddWithValue("@ena", objcls.ename);
                con.Open();
                cid = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                con.Close();
                return cid;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
                //return ex.Message.ToString();
            }
        }

        public Employee SelectProfileDB(int id)
        {
            var getdata = new Employee();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_selectProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    getdata = new Employee
                    {
                        Id = Convert.ToInt32(dr["Emp_Id"]),
                        ename = dr["Emp_Name"].ToString(),
                        eaddr = dr["Emp_Address"].ToString(),
                        esal = dr["Emp_Salary"].ToString(),
                    };
                }
                con.Close();
                return getdata;
            }

            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;

            }
        }

        public List<Employee> SelectDB()
        {
            var list = new List<Employee>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_selectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var o = new Employee
                    {
                        Id = Convert.ToInt32(dr["Emp_Id"]),
                        ename = dr["Emp_Name"].ToString(),
                        eaddr = dr["Emp_Address"].ToString(),
                        esal = dr["Emp_Salary"].ToString(),
                    };
                    list.Add(o);
                }
                con.Close();
                return list;
            }

            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;

            }

        }
    }
}
