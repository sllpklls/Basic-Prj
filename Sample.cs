using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CodeSQLGuide
{
    class Program
    {
        public const string sqlconnectStr = "Data Source=SLLPKLLS\\SQLEXPRESS;Initial Catalog=QLTV1;User ID=sa;Password=hoangthaifc01";
        public static void SQL1() //ExecuteReader
        {
            //Truy vấn SELECT ,...

            
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;


            //Cách 1 
            Console.WriteLine("Enter Gia: ");
            int Gia1 = Convert.ToInt32(Console.ReadLine());
            command.CommandText = $"select Sach.TenSach, Sach.MaSach from Sach WHERE Gia > {Gia1}";



            //Cách 2
            command.CommandText = "select Sach.TenSach, Sach.MaSach from Sach WHERE Gia > @Gia";  
            var Gia2 = command.Parameters.AddWithValue("@Gia", 1);
            Gia2.Value = "12000";
            
            



            //In ra màn hình
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // có dòng dữ liệu trả true 
                {
                    while (reader.Read()) // trả true và tăng 1 đơn vị
                    {
                        Console.WriteLine(reader.GetString(0)); // cách in ra 1
                        Console.WriteLine(reader["TenSach"]);   // cách in ra 2
                        Console.WriteLine(reader[1]);           // cách in ra 3
                    }
                }
            }
        }

        public static void SQL2() //ExecuteScalar
        {
            //trả về dòng 1 cột 1 hay dùng cho COUNT
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select Sach.TenSach, Sach.MaSach from Sach WHERE Gia > @Gia";
            var Gia2 = command.Parameters.AddWithValue("@Gia", 1);
            Gia2.Value = "12000";
            connection.Open();


            //In ra màn hình
            var sqlreader1 = command.ExecuteScalar(); 
            Console.WriteLine(sqlreader1);
        }
        public static void SQL3()
        {
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;


            //INSERT INTO
            command.CommandText = "INSERT INTO SACH (MaSach, TenSach, TacGia, Gia) VALUES (@MaSach,@TenSach,@TacGia,@Gia)";
            var MaSach = command.Parameters.AddWithValue("@MaSach", "");
            var TenSach = command.Parameters.AddWithValue("@TenSach", "");
            var TacGia = command.Parameters.AddWithValue("@TacGia", "");
            var Gia = command.Parameters.AddWithValue("@Gia", "");
            MaSach.Value = "A11";
            TenSach.Value = "SXTK";
            TacGia.Value = "Tuan";
            Gia.Value = "12000";
            

            //UPDATE

            //DELETE

            // thực thi và In ra màn hình
            connection.Open();
            var reader = command.ExecuteNonQuery();
            Console.WriteLine(reader); // in ra số dòng bị ảnh hưởng hay thêm vào

        }
        public static void Main(string[] args)
        {
            using var connection = new SqlConnection(sqlconnectStr);
            SQL3();
            connection.Close();
        }
    }
}