using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BouncingQubits
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> entangled = new Dictionary<string, string>();

        static int cQ = 0;
        public Form1()
        {
            InitializeComponent();
          
        }
       
        public void Form1_Load(object sender, EventArgs e)
        {
            LoadQ(50, new List<string>());
            timer1.Start();
        

        }
       

        public void timer1_Tick(object sender, EventArgs e)
        {
            this.Focus();
            Random rand = new Random(DateTime.Now.Millisecond);
            List<string> colQs = new List<string>();
            List<string> addQs = new List<string>();
            List<string> removeQs = new List<string>();
     
       foreach(QTextBox c in Controls)
            { int xx;
                int yy;
              
                if (rand.Next(200) > 190) { c.DX = rand.Next(-5, 5); }
                if (rand.Next(200) > 190) { c.DY = rand.Next(-5, 5); }
              
                  xx = c.Location.X + c.DX;
                  yy  = c.Location.Y + c.DY;
             
               

                foreach (QTextBox qc in Controls)
                {
                    if (c.Name != qc.Name)
                    {
                        if (xx + 20 > qc.Location.X
                      && xx < qc.Location.X + 20
                     && yy + 20 > qc.Location.Y
                        && yy < qc.Location.Y + 20)
                        {
                            c.DX = -c.DX;
                            c.DY = -c.DY;
                            xx += c.DX;
                            yy += c.DY;
                            string col = c.Name + "-" + qc.Name;
                            colQs.Add(col);
                       
                        }
                    }//name

                }// foreach qc
                if (xx > 500) {c.DX = -c.DX; xx = 495; }
                if (yy > 500) { c.DY = -c.DY;yy = 495; }
                if (xx < 50) { c.DX = -c.DX;xx = 55; }
                if (yy < 50) {c.DY = -c.DY;yy = 55; }
                c.Location = new Point(xx, yy);
                if ( (c.BackColor != Color.Green)&&(c.BackColor!=Color.Orange) &&(c.BackColor!= Color.Purple)  ) { c.BackColor = Color.White;c.Refresh(); }
                
            }//foreach c
            if (colQs.Count > 0)
            {
                foreach (string col in colQs)
                {
                    var names = col.Split('-');
                    QTextBox b1 = Controls[names[0]] as QTextBox;
                    QTextBox b2 = Controls[names[1]] as QTextBox;
                    
                 
                    rand = new Random(DateTime.Now.Millisecond);
                    var qVal1 = Convert.ToInt16(b1.Text);
                    var qVal2 = Convert.ToInt16(b2.Text);
                    var bq1 = rand.Next(100);
                    var bq2 = rand.Next(100);
                    var bqSt1 = 0;
                    var bqSt2 = 0;
                    if (b1.entan != -1)
                    {
                        bqSt1 = b1.entan;
                        b1.entan = -1;
                       
                    }
                    else
                    {
                        if (bq1 < qVal1)
                        { bqSt1 = 1;

                        }
                    }

                    if (b2.entan != -1)
                    {
                        bqSt2 = b2.entan;
                        b2.entan = -1;
                    }
                    else
                    {

                        if (bq2 < qVal2)
                        {
                            bqSt2 = 1;

                        }
                    }
                    if (entangled.Count > 0)
                    {
                        List<string> remLis = new List<string>();
                      foreach (KeyValuePair<string, string> en in entangled)
                      {
                            QTextBox bqv = Controls[en.Value] as QTextBox;
                            QTextBox bqk = Controls[en.Key] as QTextBox;
                            bqv.BackColor = Color.Green;
                            bqk.BackColor = Color.Green;
                            bqk.Refresh();
                            bqv.Refresh();
                            if (en.Key == b1.Name)// || en.Value==b1.Name) 
                           {
                                bqk.BackColor = Color.White;
                                bqv.BackColor =(bqSt1 == 1) ? Color.Orange : Color.Purple;
                                bqv.Refresh();
                                bqk.Refresh();

                                 bqv.entan = bqSt1;
                                remLis.Add(en.Key);
                           
                         }//if b1
                            if (en.Value == b1.Name)// || en.Value==b1.Name) 
                            {
                                bqv.BackColor = Color.White;
                                bqk.BackColor = (bqSt1 == 1) ? Color.Orange : Color.Purple;
                                bqv.Refresh();
                                bqk.Refresh();
                                bqk.entan = bqSt1;
                                remLis.Add(en.Key);

                            }//if b1
                            if (en.Key == b2.Name)// || en.Value == b2.Name)
                        {
                                bqv.BackColor = (bqSt2 == 1) ? Color.Orange : Color.Purple;
                                bqk.BackColor = Color.White;
                                bqv.Refresh();
                                bqk.Refresh();
                                bqv.entan = bqSt2;
                                remLis.Add(en.Key);
                            }//if b2
                            if (en.Value == b2.Name)// || en.Value == b2.Name)
                            {
                                bqv.BackColor = Color.White;
                                bqk.BackColor = (bqSt2 == 1) ? Color.Orange : Color.Purple ;
                                bqv.Refresh();
                                bqk.Refresh();
                                bqk.entan = bqSt2;
                                remLis.Add(en.Key);
                            }//if b2

                        }//FOREACH
                        if (remLis.Count > 0)
                        {
                            foreach(string rm in remLis)
                            {
                                QTextBox bq = Controls[rm] as QTextBox;
                          
                                entangled.Remove(rm);
                            }
                        }


                    }//COUNT>0

                    b1.BackColor = (bqSt1 == 1) ? Color.Red : Color.Blue;
                    b2.BackColor = (bqSt2 == 1) ? Color.Red : Color.Blue;
                        b1.Refresh();
                        b2.Refresh();

                    if ((bqSt1 == 1) && (bqSt2 == 1))
                    {
                       qVal1 += 10;
                        qVal2 += 10;
                      
                      
                    }
                    if ((bqSt1 == 1) && (bqSt2 == 0))
                    {
                        qVal1 -= 5;
                        qVal2 += 5;
                    }
                    if ((bqSt1 == 0) && (bqSt2 == 1))
                    {
                        qVal1 += 5;
                       qVal2 -= 5;
                    }
                    if ((bqSt1 == 0) && (bqSt2 == 0))
                    {
                        qVal1 -= 10;
                        qVal2 -= 10;
                    }
                    if (qVal1 >= 100)
                    {
                        qVal1 = 50;
                        addQs.Add(b1.Name);
                    }
                    if (qVal2 >= 100)
                    {
                        qVal2 = 50;
                        addQs.Add(b2.Name);
                    }
                    b1.Text = qVal1.ToString();
                    b2.Text = qVal2.ToString();
                    if (qVal1 <= 0)
                    {
                        removeQs.Add(b1.Name);
                    }
                    if (qVal2 <= 0)
                    {
                        removeQs.Add(b2.Name);
                    }
             
                }

            }//collQ.Count>0
            foreach(string n in removeQs)
            {
                Controls.Remove( Controls[n] );
            }
            LoadQ(addQs.Count, addQs);
            colQs.Clear();
            removeQs.Clear();
            addQs.Clear();

           

            this.Text = ("Q Count " + Controls.Count + " Entangle Count " + entangled.Count);
        }

     public void LoadQ(int cc, List<string> entQ)
        {
           
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int a = 0; a < cc; a++)
            {
                
                int xx = rand.Next(100, 500);
                int yy = rand.Next(100, 500);
                bool make = true;
                if  (Controls.Count > 0 )
                {

               
                do
                {
                    foreach (Control c in Controls)
                    {

                        if (xx + 20 > c.Location.X
                            && xx < c.Location.X + 20
                             && yy + 20 > c.Location.Y
                            && yy < c.Location.Y + 20)
                        {
                            make = false;
                            xx = rand.Next(100, 500);
                            yy = rand.Next(100, 500);


                            break;
                        }
                            else
                            {
                                make = true;
                            }
                      
                    }
                } while (make == false);
                }



                var picture = new QTextBox
                {
                    Name = "Q" + cQ,
                    Size = new Size(20, 20),
                    Location = new Point(xx, yy),
                    Text = "50",
                    DX = rand.Next(-5, 5),
                    DY = rand.Next(-5, 5),
                    Enabled = false,
                    entan = -1,
                };
           
                if (Controls.Count < 100)
                {
                    cQ++;
                    Controls.Add(picture);
                    if (entQ.Count > 0)
                    {
                        entangled.Add(entQ[0], picture.Name);
                        entQ.Remove(entQ[0]);
                    }
                }
                
            }
        }

    
    }//form1 class

    public partial class QTextBox: TextBox
    {
        public int DX;
        public int DY;
        public int entan;

    }
   
 



}