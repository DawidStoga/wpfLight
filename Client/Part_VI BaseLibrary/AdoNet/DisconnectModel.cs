using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Common;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client.BaseLibrary
{
  partial  class AdoNET
    {

        public static void DataAdapter()
        {
            SqlConnection cn = new SqlConnection(); ;
            SqlDataAdapter da = new SqlDataAdapter(selectCommandText: "Select * from Aircraft", selectConnection: cn);
            var sqlbuilder = new SqlCommandBuilder(da);
            bool acceptChangesDuringFill = da.AcceptChangesDuringFill;
            bool acceptChangesDuringUpdate = da.AcceptChangesDuringUpdate;
            bool continueUpdateOnError = da.ContinueUpdateOnError;
            SqlCommand sqlcmdDelete = da.DeleteCommand;
            SqlCommand sqlcmdInsert = da.InsertCommand;
            SqlCommand sqlcmdSelect = da.SelectCommand;
            SqlCommand sqlcmdUpdate = da.UpdateCommand;
            LoadOption loadOption = da.FillLoadOption;

            MissingMappingAction mapingAction = da.MissingMappingAction; //passthroug 1, ignore 2, error 3
            MissingSchemaAction schemaAction = da.MissingSchemaAction; // add, ignore, error ,AddwithKey
            bool shouldReturnProvider = da.ReturnProviderSpecificTypes;
            DataTableMappingCollection dtMapCollection = da.TableMappings;
            //dtMapCollection[0].
            
            Console.WriteLine("*********DataAdapter**************");
            Console.WriteLine("");
            Console.WriteLine("   acceptChangesDuringFill {0,10}",acceptChangesDuringFill);
            Console.WriteLine("   acceptChangesDuringUpdate {0,10}", acceptChangesDuringUpdate);
            Console.WriteLine("   ContinueUpdateOnError {0,10}", continueUpdateOnError);
            Console.WriteLine("   DeleteCommand {0}", sqlcmdDelete);
            Console.WriteLine("   InsertCommand {0}", sqlcmdInsert);
            Console.WriteLine("   SelectCommand {0}", sqlcmdSelect);
            Console.WriteLine("   UpdateCommand {0}", sqlcmdUpdate);
            Console.WriteLine("   FillLoadOption {0}", loadOption);
            Console.WriteLine("   MissingMappingAction {0}", mapingAction);
            Console.WriteLine("   MissingSchemaAction {0}", schemaAction);
            Console.WriteLine("   ReturnProviderSpecificTypes {0}", shouldReturnProvider);
            Console.WriteLine("   TableMappings {0}", dtMapCollection);

        }
        public static void ADO_DataSet()
        {
            Console.WriteLine("*************  DataSet ***********");
            using (SqlConnection cn = ADO_CreateConnection())
            {
                //   cn.Open();
                SqlDataAdapter da = new SqlDataAdapter();

                
                da.SelectCommand = new SqlCommand("Select * from Aircraft", cn);

                using (var commBuilder = new SqlCommandBuilder(da))
                { 
                    // da.SelectCommand = new SqlCommand("Select * from SqlDataAdapter", cn);
                    DataSet ds = new DataSet(dataSetName: "DS");


                ds.ExtendedProperties["Time"] = DateTime.Now;
                ds.ExtendedProperties["Machine"] = Environment.MachineName;
                ds.ExtendedProperties["Descr"] = "Desciprion";



             //   DataTableMapping tableMapping = da.TableMappings.Add("Table", "Samoloty");
             //   tableMapping.ColumnMappings.Add("Name", "Nazwa");


                int iRerurnedItem = da.Fill(ds, "Aircraft");

                Console.WriteLine($"Fill  return {iRerurnedItem} items");




                Console.WriteLine("Extended properties:");
                foreach (DictionaryEntry de in ds.ExtendedProperties)
                {
                    Console.WriteLine("    Key: {0},   Value: {1}", de.Key, de.Value);
                }

                Console.WriteLine("DataTableCollection:");

                DataTableCollection dtc = ds.Tables;
                foreach (DataTable dt in dtc)
                {
                    Console.WriteLine($"    Table : {dt.TableName}");

                    
                    // Print out the column names.
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                    {
                        Console.Write(dt.Columns[curCol].ColumnName + "\t");
                    }
                    Console.WriteLine("\n----------------------------------");
                    // Print the DataTable.
                    // 1'st way to read the data
                    for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                    {
                       
                        for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                        {
                            if (curCol == 3) continue;
                            Console.Write(dt.Rows[curRow][curCol].ToString().Trim() + "\t");
                        }
                        Console.WriteLine();
                    }
                    //2'nd way
                   DataTableReader dataReader  = dt.CreateDataReader();

                    while(dataReader.Read())
                    {
                        Console.WriteLine(dataReader[1]);
                    }
                    ADO_DataTable(dt);
                }

                DataRelationCollection drc = ds.Relations;
                Console.WriteLine("DataRelationCollection:");

                if (drc.Count == 0)
                {
                    Console.WriteLine("    No relations");
                }
                foreach (DataRelation dr in drc)
                {

                    Console.WriteLine(dr.ChildColumns);
                }

                 


                ds.Tables[0].ExtendedProperties["tabDesc"] = "TablicaDescr";

                ds.WriteXml("D:\\dataSet2.xml");
                ds.WriteXmlSchema("D:\\datasetSchema.xsd");
                ds.CaseSensitive = true; //default false
                                         //   ds.AcceptChanges();


                    var FirstDt = ds.Tables[0];

                    FirstDt.Rows[1][1] = "D";
                 //   ds.AcceptChanges();
                   //FirstDt.AcceptChanges();
                   
                 //   var sqlcmd = commBuilder.GetUpdateCommand();
                 //  da.AcceptChangesDuringUpdate = true;


                    int x  = da.Update(ds, "Aircraft");

               
                da.Update(FirstDt);
             
                //   ds.Clear();
          /*      DataSet ds_changed1 = ds.GetChanges(DataRowState.Added);
                DataSet ds_changed2 = ds.GetChanges(DataRowState.Unchanged);
                bool bHasChanged = ds.HasChanges(); //ds.HasChanges(DataRowState.Added);
                ds.Merge(ds_changed2);
                ds.Prefix = "DAWID";
                ds.Namespace = "STOGwA";
                ds.RemotingFormat = SerializationFormat.Xml;*/
                //   ds.RejectChanges(); //Rolls back all changes
            }
                

            }
        }
        public static void ADO_DataTable(DataTable dt)
        {
            DataColumnCollection columns = dt.Columns;
            DataView dataView = dt.DefaultView;
            bool designing = dt.DesignMode;
            string expression = dt.DisplayExpression;
            dt.ExtendedProperties["author"] = "dawid";
            bool initialized = dt.IsInitialized;
            int size = dt.MinimumCapacity;
            var oredix = dt.Prefix;
            DataColumn[] primKey = dt.PrimaryKey;
            DataRowCollection rows = dt.Rows;
           

            dt.WriteXml("table.xml");
            dt.WriteXmlSchema("table.xsd");

            dt.DataSet.RemotingFormat = SerializationFormat.Binary;
            dt.RemotingFormat = SerializationFormat.Binary;
            using (var fs = new FileStream("Binary.bin", FileMode.Create))
            {
                var format = new BinaryFormatter();
                format.Serialize(fs, dt);


            }
                Ado_Rows(rows);
        }

        private static void Ado_Rows(DataRowCollection rows)
        {
            foreach(  DataRow dr in rows)
            {
               foreach(var item in  dr.ItemArray)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public static void ADO_Disconnected()
        {
            DataAdapter();
            ADO_DataSet();
            ADO_DataColumn();
        }
    }
}
