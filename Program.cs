
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace QLCH
{
    class Program
    {
        const string sqlconnectStr = "Data Source=SLLPKLLS\\SQLEXPRESS;Initial Catalog=QTCH;User ID=sa;Password=hoangthaifc01"; //bug 1 QLCH //bug 2 QTCH moi dung //30p

        public static void Menu()
        {
            Console.WriteLine("--Menu--");
            Console.WriteLine("1,Add");
            Console.WriteLine("2,Edit");
            Console.WriteLine("3,Report");
            Console.WriteLine("10,Exit");
        }
        public static void AddSanPham()
        {

            //1.1
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO SanPham (MaSP, TenSP, Gia) VALUES (@MaSP,@TenSP,@Gia)";
            var MaSP = command.Parameters.AddWithValue("@MaSP","");
            var TenSP = command.Parameters.AddWithValue("@TenSP", "");
            var Gia = command.Parameters.AddWithValue("@Gia", "");
            Console.WriteLine("Enter MaSP: ");
            MaSP.Value = Console.ReadLine();
            Console.WriteLine("Enter TenSP: ");
            TenSP.Value = Console.ReadLine();
            Console.WriteLine("Enter Gia: ");
            Gia.Value = Console.ReadLine();
            Console.WriteLine(MaSP.Value+" "+TenSP.Value+" "+Gia.Value);
            connection.Open();
            var reader = command.ExecuteNonQuery();
            if (reader == 1) Console.WriteLine(reader+" line added!");
            else Console.WriteLine(reader+" lines added!");
            Console.ReadKey();
        }
        public static void AddKhachHang()
        {
            //1.2
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO KhachHang (MaKH, TenKH, DiaChi) VALUES (@MaKH,@TenKH,@DiaChi)";
            var MaKH = command.Parameters.AddWithValue("@MaKH", "");
            var TenKH = command.Parameters.AddWithValue("@TenKH", "");
            var DiaChi = command.Parameters.AddWithValue("@DiaChi", "");
            Console.WriteLine("Enter MaKH: ");
            MaKH.Value = Console.ReadLine();
            Console.WriteLine("Enter TenKH: ");
            TenKH.Value = Console.ReadLine();
            Console.WriteLine("Enter DiaChi: ");
            DiaChi.Value = Console.ReadLine();
            Console.WriteLine(MaKH.Value + " " + TenKH.Value + " " + DiaChi.Value);
            connection.Open();
            var reader = command.ExecuteNonQuery();
            if (reader == 1) Console.WriteLine(reader + " line added!");
            else Console.WriteLine(reader + " lines added!");
            Console.ReadKey();
        }
        public static void AddDonHang()
        {
            //1.3
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO DonHang (MaDH, MaKH, MaSP, SoLuong) VALUES (@MaDH,@MaKH,@MaSP,@SoLuong)";
            var MaDH = command.Parameters.AddWithValue("@MaDH", "");
            var MaKH = command.Parameters.AddWithValue("@MaKH", "");
            var MaSP = command.Parameters.AddWithValue("@MaSP", "");
            var SoLuong = command.Parameters.AddWithValue("@SoLuong", "");
            Console.WriteLine("Enter MaDH: ");
            MaDH.Value = Console.ReadLine();
            Console.WriteLine("Enter MaKH: ");
            MaKH.Value = Console.ReadLine();
            Console.WriteLine("Enter MaSP: ");
            MaSP.Value = Console.ReadLine();
            Console.WriteLine("Enter SoLuong: ");
            SoLuong.Value = Console.ReadLine(); 
            Console.WriteLine(MaDH.Value + " " + MaKH.Value + " " + MaSP.Value+" "+SoLuong.Value);
            connection.Open();
            var reader = command.ExecuteNonQuery();
            if (reader == 1) Console.WriteLine(reader + " line added!");
            else Console.WriteLine(reader + " lines added!");
            Console.ReadKey();
        }
        public static void EditUpdateSanPham()
        {
            //2.1.1
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE SanPham SET TenSP = @TenSP, Gia = @Gia WHERE MaSP = @MaSP";
            var MaSP = command.Parameters.AddWithValue("@MaSP", "");
            var TenSP = command.Parameters.AddWithValue("@TenSP", "");
            var Gia = command.Parameters.AddWithValue("@Gia", "");
            Console.WriteLine("Enter MaSP: ");
            MaSP.Value = Console.ReadLine();
            Console.WriteLine("Enter TenSP: ");
            TenSP.Value = Console.ReadLine();
            Console.WriteLine("Enter Gia:");
            Gia.Value = Console.ReadLine();
            Console.WriteLine(TenSP.Value + " "+MaSP.Value+" "+Gia.Value);
            connection.Open();
            var reader = command.ExecuteNonQuery();
            if (reader == 1) Console.WriteLine(reader + " line edited!");
            else Console.WriteLine(reader + " lines edited!");
            Console.ReadKey();
        }
        public static void EditUpdateKhachHang()
        {
            //2.1.2
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE KhachHang SET TenKH = @TenKH, DiaChi = @DiaChi WHERE MaKH = @MaKH";
            var MaKH = command.Parameters.AddWithValue("@MaKH", "");
            var TenKH = command.Parameters.AddWithValue("@TenKH", "");
            var DiaChi = command.Parameters.AddWithValue("@DiaChi", "");
            Console.WriteLine("Enter MaKH: ");
            MaKH.Value = Console.ReadLine();
            Console.WriteLine("Enter TenKH: ");
            TenKH.Value = Console.ReadLine();
            Console.WriteLine("Enter DiaChi:");
            DiaChi.Value = Console.ReadLine();
            Console.WriteLine(TenKH.Value + " " + MaKH.Value + " " +DiaChi.Value);
            connection.Open();
            var reader = command.ExecuteNonQuery();
            if (reader == 1) Console.WriteLine(reader + " line edited!");
            else Console.WriteLine(reader + " lines edited!");
            Console.ReadKey();
        }
        public static void EditUpdateDonHang()
        {
            //2.1.3
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE DonHang SET MaKH = @MaKH, MaSP = @MaSP, SoLuong = @Soluong WHERE MaDH = @MaDH";
            var MaDH = command.Parameters.AddWithValue("@MaDH", "");
            var MaKH = command.Parameters.AddWithValue("@MaKH", "");
            var MaSP = command.Parameters.AddWithValue("@MaSP", "");
            var SoLuong = command.Parameters.AddWithValue("@SoLuong", "");
            Console.WriteLine("Enter MaDH: ");
            MaDH.Value = Console.ReadLine();
            Console.WriteLine("Enter MaKH: ");
            MaKH.Value = Console.ReadLine();
            Console.WriteLine("Enter MaSP:");
            MaSP.Value = Console.ReadLine();
            Console.WriteLine("Enter SoLuong: ");
            SoLuong.Value = Console.ReadLine();
            Console.WriteLine(MaDH.Value + " " + MaKH.Value + " " + MaSP.Value+" "+ SoLuong.Value);
            connection.Open();
            var reader = command.ExecuteNonQuery();
            if (reader == 1) Console.WriteLine(reader + " line edited!");
            else Console.WriteLine(reader + " lines edited!");
            Console.ReadKey();
        }
        public static void EditDeleteSanPham()
        {
            //2.2.1
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM SanPham WHERE MaSP = @MaSP";
            var MaSP = command.Parameters.AddWithValue("@MaSP", "");
            Console.WriteLine("Enter MaSP: ");
            MaSP.Value = Console.ReadLine();
            connection.Open();
            var reader = command.ExecuteNonQuery();
            if (reader == 1) Console.WriteLine(reader + " line deleted!");
            else Console.WriteLine(reader + " lines deleted!");
            Console.ReadKey();
        }
        public static void EditDeleteKhachHang()
        {
            //2.2.2
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
            var MaKH = command.Parameters.AddWithValue("@MaKH", "");
            Console.WriteLine("Enter MaKH: ");
            MaKH.Value = Console.ReadLine();
            connection.Open();
            var reader = command.ExecuteNonQuery();
            if (reader == 1) Console.WriteLine(reader + " line deleted!");
            else Console.WriteLine(reader + " lines deleted!");
            Console.ReadKey();
        }
        public static void EditDeleteDonHang()
        {
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM DonHang WHERE MaDH = @MaDH";
            var MaDH = command.Parameters.AddWithValue("@MaDH", "");
            Console.WriteLine("Enter MaDH: ");
            MaDH.Value = Console.ReadLine();
            connection.Open();
            var reader = command.ExecuteNonQuery();
            if (reader == 1) Console.WriteLine(reader + " line deleted!");
            else Console.WriteLine(reader + " lines deleted!");
            Console.ReadKey();
        }
        public static void ReportSanPham()
        {
            //3.1
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM SanPham";
            connection.Open();
            int i = 1;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)  
                {
                    while (reader.Read()) 
                    {
                        Console.WriteLine(i+","+reader["MaSP"]+"-"+reader["TenSP"]+"-"+reader["Gia"]);
                        i++;
                    }
                }
            }
            Console.ReadKey();
        }
        public static void ReportKhachHang()
        {
            //3.1
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM KhachHang";
            connection.Open();
            int i = 1;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(i + "," + reader["MaKH"] + "-" + reader["TenKH"] + "-" + reader["DiaChi"]);
                        i++;
                    }
                }
            }
            Console.ReadKey();
        }
        public static void ReportDonHang()
        {
            //3.1
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT TenKH, TenSP From KhachHang a, DonHang b, SanPham c WHERE a.MaKH=b.MaKH and c.MaSP=b.MaSP";
            connection.Open();
            int i = 1;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(i + "," + reader["TenKH"] + "-" + reader["TenSP"]);
                        i++;
                    }
                }
            }
            Console.ReadKey();
        }
        public static void Main(string[] args)
        {

            int choice = 0 ;
            while(choice != 10)
            {
                Console.Clear();
                Menu();
                Console.WriteLine("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("--Add--");
                            Console.WriteLine("1,San Pham");
                            Console.WriteLine("2,Khach Hang");
                            Console.WriteLine("3,Don Hang");
                            Console.WriteLine("Enter your choice: ");
                            int choiceAdd = Convert.ToInt32(Console.ReadLine());
                            switch (choiceAdd)
                            {
                                case 1:
                                    {
                                        Console.Clear();
                                        AddSanPham();
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        AddKhachHang();
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.Clear();
                                        AddDonHang();
                                        break;
                                    }
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("--Edit--");
                            Console.WriteLine("1,UPDATE");
                            Console.WriteLine("2,DELETE");
                            int choiceEdit = Convert.ToInt32(Console.ReadLine());
                            switch (choiceEdit)
                            {
                                case 1:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("--UPDATE--");
                                        Console.WriteLine("1,San Pham");
                                        Console.WriteLine("2,Khach Hang");
                                        Console.WriteLine("3,Don Hang");
                                        Console.WriteLine("Enter your choice: ");
                                        int choiceEdit1 = Convert.ToInt32(Console.ReadLine());
                                        switch (choiceEdit1)
                                        {
                                            case 1:
                                                {
                                                    Console.Clear();
                                                    EditUpdateSanPham();
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    Console.Clear();
                                                    EditUpdateKhachHang();
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    Console.Clear();
                                                    EditUpdateDonHang();
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("--DELETE--");
                                        Console.WriteLine("1,San Pham");
                                        Console.WriteLine("2,Khach Hang");
                                        Console.WriteLine("3,Don Hang");
                                        Console.WriteLine("Enter your choice: ");
                                        int choiceEdit2 = Convert.ToInt32(Console.ReadLine());
                                        switch (choiceEdit2)
                                        {
                                            case 1:
                                                {
                                                    Console.Clear();
                                                    EditDeleteSanPham();
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    Console.Clear();
                                                    EditDeleteKhachHang();
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    Console.Clear();
                                                    EditDeleteDonHang();
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                            }

                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("--Report--");
                            Console.WriteLine("1,San Pham");
                            Console.WriteLine("2,Khach Hang");
                            Console.WriteLine("3,Don Hang");
                            Console.WriteLine("Enter your choice: ");
                            int choiceAdd = Convert.ToInt32(Console.ReadLine());
                            switch (choiceAdd)
                            {
                                case 1:
                                    {
                                        Console.Clear();
                                        ReportSanPham();
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        ReportKhachHang();
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.Clear();
                                        ReportDonHang();
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
        }
    }
}


