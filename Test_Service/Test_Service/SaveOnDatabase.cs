using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Test_Service
{
    static class SaveOnDatabase
    {

        public static SqlConnection NameDatabase;

        public static Boolean InitDatabase(String connentString)
        {

            try
            {
                NameDatabase = new SqlConnection(connentString);
                NameDatabase.Open();
                return true;
            }
            catch (System.Exception)
            {
                OutController.WriteLog("Co the ket noi dng mo, Khong the connect database");
                return false;
            }
        }
        public static void Save(DateTime date, String changer, String path, String name)
        {
            // Biến lưu lệnh thực hiện lệnh 
            SqlCommand _command = new SqlCommand();
            _command.Connection = NameDatabase;
            String sql;
            try
            {
                // Gửi thông tin dữ liệu vào database
                sql = @"insert into informationFile values('" + date + "', '" + changer + "', '" + path + "', '" + name + "')";

                _command.CommandText = sql;
                _command.ExecuteNonQuery();
            }
            catch
            {
            }

            //Đóng kết nối
            OutController.WriteLog("Dong ket noi voi database");
            NameDatabase.Close();
        }



    }
}
