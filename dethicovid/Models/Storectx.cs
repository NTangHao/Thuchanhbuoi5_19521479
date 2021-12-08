
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace dethicovid.Models
{
    public class Storectx
    {
        public string ConnectionString { get; set; } // Biến thành viên
        public Storectx(string connectionstring)
        {
            this.ConnectionString = connectionstring;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public int Insertcachly(Diemcachlymodel cl)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into DIEMCACHLY values(@MaDiemCachLy, @TenDiemCachLy, @DiaChi)";

                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaDiemCachLy", cl.MaDiemCachLy);
                cmd.Parameters.AddWithValue("TenDiemCachLy", cl.TenDiemCachLy);
                cmd.Parameters.AddWithValue("DiaChi", cl.DiaChi);
               
                return (cmd.ExecuteNonQuery());
            }
        }

        public List<object> lietketrieuchung(int solan)
        {
            List<object> list = new List<object>();
            using(SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"select TenCongNhan,NamSinh,NuocVe ,count(ct.MaCongNhan) as sotrieuchung 
                                from CN_TC ct join CONGNHAN cn on ct.MaCongNhan = cn.MaCongNhan 
                                group by TenCongNhan,NamSinh,NuocVe 
                                having count(ct.MaCongNhan) >=@solaninput";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("solaninput", solan);
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read()){
                        list.Add(new
                        {
                            TenCongNhan = reader[0].ToString(),
                            NamSinh = reader[1].ToString(),
                            NuocVe = reader[2].ToString(),
                            SoLan = Convert.ToInt32(reader[3])
                        }) ;
                    }
                    reader.Close();
                }
                
            }
            return list;
        }

        public List<object> sqldiemcachly()
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"select MaDiemCachLy,TenDiemCachLy from DIEMCACHLY";
                SqlCommand cmd = new SqlCommand(str, conn);
               
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new 
                        {
                            MaDiemCachLy = reader[0].ToString(),
                            TenDiemCachLy = reader[1].ToString()
                            
                        });
                    }
                    reader.Close();
                }
            }
            return list;
        }

        public List<object> lscongnhan(string macachly)
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = $"select MaCongNhan, TenCongNhan from CONGNHAN where MaDiemCachLy = {macachly}"  ;
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@maso", macachly);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new 
                        {
                            MaCongNhan = reader[0].ToString(),
                            TenCongNhan = reader[1].ToString()

                        });
                    }
                    reader.Close();
                }
            }
            return list;
        }

    }
}

