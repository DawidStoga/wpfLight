using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Security;
using System.Data.Sql;
using System.ComponentModel;

namespace Client.BaseLibrary
{
    partial class AdoNET
    {
        public static void DataProviders()
        {
            using (IDbConnection sqlconn = new SqlConnection())    // <--- establish connection
            {


                using (IDbCommand sqlCommand = sqlconn.CreateCommand(),                         // <-- Create cmd Object  (1'st way)
                                  sqlCommad2 = new SqlCommand("Select * from MyTable", connection: sqlconn as SqlConnection)         // <-- Create cmd Object  (2'st way)
                                   
                                                                                              
                        )   // <-- Create Command object
                {

                  

                    using (IDataReader dataReader = sqlCommand.ExecuteReader())   //<-- Get DataReader object
                    {

                    }
                }
                
            }

            // The same by using base (abstract ) classes
            using (DbConnection sqlconn = new SqlConnection())
            {
                using (DbCommand sqlCommand = new SqlCommand())
                {
                    using (DbDataReader dataReader = sqlCommand.ExecuteReader())   //<-- Get DataReader object
                    {

                    }
                }
            }



            // The same by using dedicated provider classes  
            using (SqlConnection sqlconn = new SqlConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())   //<-- Get DataReader object
                    {

                    }
                }
            }

            DbDataAdapter dataAdapper1  = new SqlDataAdapter();
            IDataAdapter  dataAdapper2  =  new SqlDataAdapter();
            SqlDataAdapter dataAdapter3 = new SqlDataAdapter();

            SqlParameter parameter1 = new SqlParameter();
            DbParameter parameter2 = new SqlParameter();
            IDbDataParameter parameter3 = new SqlParameter();
            IDataParameter parameter4 = new SqlParameter();






            /* SqlClient*/
            SqlConnection sqlconn3 = new SqlConnection(@"Data Source = (localdb)\Projectsv12; Initial Catalog = Airplanes; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            DbConnectionStringBuilder connstring = new DbConnectionStringBuilder();
            connstring["AsynchronousProcessing"] = true;

            SqlCommand sqlCommand3 = new SqlCommand();
            sqlconn3.Open();
            sqlconn3.BeginTransaction(IsolationLevel.Unspecified, "MyTransaction");
            sqlconn3.Close();
        }


        public static SqlConnection ADO_CreateConnection()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AirPlane.Domain.Concrete.EFDbContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            /* String builder */
            SqlConnectionStringBuilder connStringBulder = new SqlConnectionStringBuilder(connectionString);
            connStringBulder["Asynchronous Processing"] = true;
            connStringBulder["Connect Timeout"] = 30;


            SqlConnection conn = new SqlConnection(connectionString);

            return conn;
        }
        public static void ADO_ConnectionProp(SqlConnection conn)
        {
            SecureString secStr = new SecureString();
            secStr.AppendChar('q');
            secStr.AppendChar('w');
            secStr.AppendChar('x');

            /* 
             SqlCredential credential = new SqlCredential("Dawid", secStr);
             SqlConnection conn = new SqlConnection(connectionString: connectionString, credential: credential);
             SqlConnection conn = new SqlConnection(connectionString: connectionString);
           
             * */

            
            Guid id =  conn.ClientConnectionId;
            var connTimeOut = conn.ConnectionTimeout;
            var dbName = conn.Database;
            var dataSourceName = conn.DataSource;
            var spackedSize = conn.PacketSize;
            var serverVer = "";
            if (conn.State != ConnectionState.Closed)
            {
                serverVer = conn.ServerVersion;
            }
           
            var connState = conn.State;
            var dbClient  = conn.WorkstationId;
            var token = conn.AccessToken; 
            Console.WriteLine($@" 
            SQLConnection Properties  (available in closed state)

            ClientConnectionId : {id}
            ConnectionTimeout  : {connTimeOut} 
            Database           : {dbName}
            DataSource         : {dataSourceName}     
            PacketSize         : {spackedSize}
            ServerVersion      : {serverVer}
            State              : {connState}
            AccessToken        : {token}
            WorkstationId      : {dbClient}");


            // ????
            //conn.FireInfoMessageEventOnUserErrors ???
           // SqlTransaction transaction  =conn.BeginTransaction(IsolationLevel.Unspecified, "TransactionName");
           // conn.ChangeDatabase("OtherDBName");
           // SqlCommand cmd = conn.CreateCommand();
            //conn.EnlistDistributedTransaction(...)
            // conn.EnlistTransaction(....)

         
        }
        public static async void  ADO_CommandProperties(SqlCommand cmd)
        {
            
        
         
            Console.WriteLine($@"
                 Timeout: { cmd.CommandTimeout}
                 CmdType: { cmd.CommandType}
                    Conn: { cmd.Connection}
               Container: { cmd.Container}
               Notification: { cmd.Notification}
               Parameters: { cmd.Parameters}
                           ");







            cmd.CommandType = CommandType.StoredProcedure;
          //  cmd.CommandType = CommandType.TableDirect;
            cmd.CommandType = CommandType.Text;

          

            
            //ComponentCollection comps = cmd.Container.Components;
            SqlNotificationRequest notificationReq = cmd.Notification;
            bool autoEnlist = cmd.NotificationAutoEnlist;
            SqlParameterCollection parameters = cmd.Parameters;
            //cmd.Site;
            //  cmd.Transaction;
            //  cmd.UpdatedRowSource

#if false    //obsolete - use Async instead
            IAsyncResult ar1  = cmd.BeginExecuteNonQuery();
            IAsyncResult ar2  = cmd.BeginExecuteReader();
            IAsyncResult ar3  = cmd.BeginExecuteXmlReader();

            cmd.EndExecuteNonQuery(ar1);
            cmd.EndExecuteReader(ar2);
            cmd.EndExecuteXmlReader(ar3);
#endif

            cmd.Cancel(); // tries to cancel the execution of command
            SqlParameter parameter = cmd.CreateParameter();
            parameters.Add(parameter);

            int cnt = cmd.ExecuteNonQuery();
            cnt = await cmd.ExecuteNonQueryAsync();
            SqlDataReader rd1 =  cmd.ExecuteReader();
            SqlDataReader rd2   = await  cmd.ExecuteReaderAsync();

            cmd.ExecuteScalar();
          await  cmd.ExecuteScalarAsync();
            cmd.ExecuteXmlReader();
         await   cmd.ExecuteXmlReaderAsync();
            cmd.Prepare();
        }


        public static void ADO_DataColumn()
        {

            var AirDataColumnID = new DataColumn("sID", typeof(int))
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 100,
                AutoIncrementStep = 1,
                Caption = "ID",
                Unique = true,
                ReadOnly = true
            };
            var AirDataColumnName = new DataColumn("sNazwa", typeof(string));
            var AirDataColumnEngine = new DataColumn("sSilnik", typeof(int));


            DataTable dt = new DataTable("MojeSamoloty");
            dt.Columns.AddRange(new[] { AirDataColumnID, AirDataColumnName, AirDataColumnEngine });


            // DataRow datarow = dt.Rows[0] ;
             DataRow datarow = dt.NewRow();
            /*dt.Rows.Add(newRow);*/

            datarow["sID"] = 1;
            datarow["sNazwa"] = "Bombardier";
            datarow["sSilnik"] = 3;
            dt.Rows.Add(datarow);
            datarow = dt.NewRow();
            datarow["sID"] = 2;
            datarow["sNazwa"] = "Airbus A120";
            datarow["sSilnik"] = 2;
            dt.Rows.Add(datarow);
          




            Console.WriteLine(datarow[1].ToString());
            Console.WriteLine("DataRow has error? {0}",   datarow.HasErrors);
            datarow.AcceptChanges();   //row must be in the table
            datarow.BeginEdit();
            datarow.CancelEdit();
            // datarow.Delete();
            datarow.EndEdit();
            object[] RowArray = datarow.ItemArray; // todo Ienumerate

           var descriptions =  RowArray.OfType<string>();
            datarow.RejectChanges();
           
        }
        public static void ADO_DataSetBase()
        {
            DataSet dataset = new DataSet("newDataSet");

            /* DataTable*/
            DataTable dt = new DataTable("tabela1");

            /*DataColumn*/
            DataColumn dc1 = new DataColumn("col1", typeof(int)) { AllowDBNull = false, AutoIncrementSeed = 20, AutoIncrementStep = 17, AutoIncrement = true };
            DataColumn dc2 = new DataColumn("col2", typeof(string));
            dt.Columns.AddRange(new[] { dc1, dc2 });


            /*DataRow*/
            DataRow dr = dt.NewRow();
            //   dr[0] = 1;
            dr[1] = "dana1";
            dt.Rows.Add(dr);
            dt.AcceptChanges();
            dr = dt.NewRow();
            // dr[0] = 2;
            dr[1] = "dana2";
            dt.Rows.Add(dr);

            dt.PrimaryKey = new[] { dt.Columns[0] };




            /* Test*/
            foreach (var rows in dt.Rows)
            {
                var readRow = rows as DataRow;
                Console.WriteLine(readRow[0] + " " + readRow[1]);
            }

            dt.RejectChanges(); Console.WriteLine("After Rejected Changes");
            foreach (var rows in dt.Rows)
            {

                var readRow = rows as DataRow;
                Console.WriteLine(readRow[1]);
            }
        }
     
    }
}
