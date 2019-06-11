using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace EjemploActualizacionGrilla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static System.Timers.Timer t;
        DataTable dt = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {

            t = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            t.Elapsed += OnTimedEvent;
            t.AutoReset = true;

        }
        int i = 0;
        private  void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (i == 10)
            {
                t.Stop();
            }
                DataRow row;
                row = dt.NewRow();
                row["id"] = i;
                row["ParentItem"] = "ParentItem " + i;
                dt.Rows.Add(row);
                dt.AcceptChanges();
            i++;
               
            
            label1.Text = "The Elapsed event was raised at {0:HH:mm:ss.fff}" + e.SignalTime;
           
        }
        //IEnumerable<int> Iterador() {
        //    for (int i = 0; i < 10; i++)
        //    {
                
        //        yield return i;
        //    }
        //}
        private void Button1_Click(object sender, EventArgs e)
        {
            
            //dt.Rows[0][1] = "ParentItem 2";
            DataColumn column;
            
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ParentItem";
            dt.Columns.Add(column);

            this.dataSet1.Tables.Add(dt);






            DataView dv1 = new DataView(dt);
            DataView dv2 = new DataView(dt);

            //dv1.RowFilter = "ParentItem = 'ParentItem 1'";
            dv2.RowFilter = "ParentItem = 'ParentItem 2'";

            this.dataGridView1.DataSource = dv1;
            this.dataGridView2.DataSource = dv2;
            t.Start();
            t.SynchronizingObject = this;
            //for (int i = 0; i < 10; i++)
            //{
                
               
            //}
            
        }
    }
}
