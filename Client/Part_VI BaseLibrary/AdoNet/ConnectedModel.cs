using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Common;

namespace Client.BaseLibrary
{
    partial class AdoNET
    {
        public static void ADO_Connected()
        {
            Console.WriteLine("/* DataReader*/");
              ADO_Connected_DataReader();
            Console.WriteLine("/* ADO_Connected_ExecuteNonQuery_Parameters*/");
            //   ADO_Connected_ExecuteNonQuery_Parameters();
            Console.WriteLine("/* ADO_Connected_Transaction*/");
            //   ADO_Connected_Transaction();
            Console.WriteLine("/* ADO_Connected_Stored Procedure*/");
            //  ADO_Connected_Procedure
            ADD_Connected_Async();
        }

        private static void ADO_Connected_DataReader()
        {

             using (SqlConnection cn = ADO_CreateConnection())         // <-- or SqlConnection cn   = new SqlConnection(connectionString) */
            {
                cn.InfoMessage += Cn_InfoMessage;
                string sqlQuery = "Select * from Aircraft";

                
                using (SqlCommand comm = cn.CreateCommand())       // <=--  or   using (SqlCommand comm = new SqlCommand(sqlcmd, cn))
                {
                    try
                    {
                        cn.Open();

                        ADO_ConnectionProp(cn);

                        comm.CommandText = sqlQuery;

                       // ADO_CommandProperties(comm);

                        using (SqlDataReader dr = comm.ExecuteReader())
                        {

                              while (dr.Read())
                            {
                                Console.WriteLine($"ID: {dr[0]} name: {dr[2]}  model: {dr[1]}");
                             
                            }
                        }

                        comm.CommandText += " Select *from Airlines";              // <--- Multiple query

                        Console.WriteLine("\n\n Multiple query");
                        using (SqlDataReader dr = comm.ExecuteReader())
                        {
                           
                            do
                            {


                                while (dr.Read())
                                {
                                   for(int i =0;  i<dr.FieldCount;i++)
                                    {
                                        Console.WriteLine($"{dr.GetName(i)} = {dr.GetValue(i)}");
                                    }
                                }
                            } while (dr.NextResult());
                        }




                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }

        }

        private static void Cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void ADO_Connected_ExecuteNonQuery_Parameters()
        {
            string dbParPlanName = "Param_Tupolev";
            string connectionString = @"Data Source = (localdb)\Projectsv12; Initial Catalog = Airplanes; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            DbParameter dbParameter2 = new SqlParameter { ParameterName = "@Plane", Value = dbParPlanName, Size = 10, SqlDbType = SqlDbType.Char };

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand comm = cn.CreateCommand())
                {
                    comm.Parameters.Add(dbParameter2);

                    try
                    {
                        cn.Open();
                        comm.CommandText = "Insert into AirplaneSet (Name,engines) VALUES ('2',@Plane)";
                        comm.ExecuteNonQuery();
                        Console.WriteLine("success");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message.ToString());

                    }
                }
            }

            /*Read out */
            ADO_Connected_DataReader();

        }
        private static void ADO_Connected_Transaction()
        {


            DbTransaction dbTrans = null;

            using (SqlConnection cn = new SqlConnection(@"Data Source = (localdb)\Projectsv12; Initial Catalog = Airplanes; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
            {

                using (SqlCommand comm = cn.CreateCommand())
                {

                    if (cn.State != ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    if (cn.State == ConnectionState.Open)
                    {
                        dbTrans = cn.BeginTransaction("Trans1");
                        comm.Transaction = dbTrans as SqlTransaction;
                    }
                    else
                    {
                        return;
                    }
                    try
                    {
                        comm.CommandText = "Insert into AirplaneSet (Name,engines) VALUES (2,'Trans_F-16')";
                        comm.ExecuteNonQuery();
                        comm.CommandText = "Insert into AirplaneSet (Name,engines) VALUES ('2','Trans_F-18')"; //wrong column ame to simulate rollback
                        comm.ExecuteNonQuery();

                        dbTrans.Commit();
                        Console.WriteLine("success");
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        Console.WriteLine("RollBack " + ex.Message.ToString());

                    }
                    finally
                    {
                        dbTrans.Dispose();

                    }

                    ADO_Connected_DataReader();
                }
            }

        }
        private static void ADO_Connected_Procedure()
        {
            string sWizzair = "Boi"; ;
            using (SqlConnection cn = new SqlConnection(@"Data Source = (localdb)\Projectsv12; Initial Catalog = Airplanes; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
            {
                cn.Open();
                using (SqlCommand comm = cn.CreateCommand())
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter() { ParameterName = "@MachineName", Value = sWizzair, SqlDbType = SqlDbType.Char, Direction = ParameterDirection.Input });
                    comm.CommandText = "FindAir";
                    SqlDataReader dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine($" name {dr[1]}  engines { dr[2] } ");
                    };
                    dr.Close();
                }
            }

        }
        private static async void ADD_Connected_Async()
        {

            string connectionString = @"Data Source = (localdb)\Projectsv12; Initial Catalog = Airplanes; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string sqlcmd = "Select * from AirplaneSet";

                //using (SqlCommand comm = new SqlCommand(sqlcmd, cn))
                using (SqlCommand comm = cn.CreateCommand())
                {

                    try
                    {
                        //    cn.Open();
                        await cn.OpenAsync();  /* .net 4.6 */
                        comm.CommandText = sqlcmd;


                        IAsyncResult iar = comm.BeginExecuteReader();

                        while (!iar.IsCompleted)
                        {
                            Console.WriteLine("wait");
                        }

                        using (SqlDataReader dr = comm.EndExecuteReader(iar))
                        {

                            Console.WriteLine($"AccessToken: {cn.AccessToken} \nConnectionTimeout: {cn.ConnectionTimeout} \nCredential.UserId: {cn.Credential} \nDatabase: {cn.Database} \nWorkstationId: {cn.WorkstationId}");
                            while (dr.Read())
                            {
                                Console.WriteLine($"ID: {dr[0]} name: {dr[2]}  engines: {dr[1]}");
                            }
                        }

                        //   using (Task<SqlDataReader> drAsync = comm.ExecuteReaderAsync())
                        using (SqlDataReader dr = await comm.ExecuteReaderAsync())
                        {
                            Console.WriteLine($"AccessToken: {cn.AccessToken} \nConnectionTimeout: {cn.ConnectionTimeout} \nCredential.UserId: {cn.Credential} \nDatabase: {cn.Database} \nWorkstationId: {cn.WorkstationId}");
                            while (dr.Read())
                            {
                                Console.WriteLine($"ID: {dr[0]} name: {dr[2]}  engines: {dr[1]}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
        }

    }
}
