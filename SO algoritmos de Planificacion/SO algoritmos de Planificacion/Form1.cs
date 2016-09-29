using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SO_algoritmos_de_Planificacion
{
    public partial class Form1 : Form
    {
        int nProceso = 0,quantum=0;

        string[] proces = new string[200];
        int[] cpu = new int[200];
        Color[] colorProceso = new Color[200];        

   

        public Form1()
        {
            InitializeComponent();
            colorProceso[0] = Color.AliceBlue;
            colorProceso[1] = Color.AntiqueWhite;
            colorProceso[2] = Color.DarkBlue;
            colorProceso[3] = Color.SaddleBrown;
            colorProceso[4] = Color.DimGray;
            colorProceso[5] = Color.PapayaWhip;
            colorProceso[6] = Color.Green;
            colorProceso[7] = Color.Honeydew;
            colorProceso[8] = Color.Aquamarine;
            colorProceso[9] = Color.PaleGreen;
            colorProceso[10] = Color.Navy;
            colorProceso[11] = Color.Tan;
            colorProceso[12] = Color.Red;
            colorProceso[13] = Color.Pink;
            colorProceso[14] = Color.Violet;
            colorProceso[15] = Color.Snow;
            colorProceso[16] = Color.CadetBlue;
            colorProceso[17] = Color.Khaki;
            colorProceso[18] = Color.CadetBlue;
            colorProceso[19] = Color.DeepSkyBlue;
            colorProceso[20] = Color.MediumPurple;
            colorProceso[21] = Color.MistyRose;
            colorProceso[22] = Color.Azure;
            colorProceso[23] = Color.Silver;
            colorProceso[24] = Color.SeaShell;
            colorProceso[25] = Color.Wheat;          
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtCpu.Text != "")
            {
                ListViewItem proc = new ListViewItem();
                proc.Text = nProceso.ToString();
                proc.SubItems.Add(txtNombre.Text);
                proc.SubItems.Add(txtCpu.Text);

                if (nProceso <= 25)
                {
                    proc.BackColor = colorProceso[nProceso];
                }
                else
                {
                    Random rd = new Random();
                    int valor = rd.Next(0, 25);
                    proc.BackColor = colorProceso[valor];                       
                }

                listProcesos.Items.Add(proc);

                proces[nProceso] = txtNombre.Text;
                cpu[nProceso] = Convert.ToInt32( txtCpu.Text);
                
                nProceso++;                

                txtCpu.Clear();
                txtNombre.Clear();       
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos requeridos");
            }
 
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (btnIniciar.Text == "INICIAR")
            {
                if (cbQuantum.Text != "")
                {
                    if (proces[0] != null)
                    {
                        timerProcesos.Enabled = true;
                        quantum = Convert.ToInt32(cbQuantum.Text);
                        btnIniciar.Text = "PAUSA";
                        cbQuantum.Enabled = false;
                        btnLimpiar.Visible = true;
                    }
                }
                else { MessageBox.Show("Indique el Quantum"); }

            }
            else
            {
                timerProcesos.Enabled = false;
                btnIniciar.Text = "INICIAR";
                cbQuantum.Enabled = true;
                btnLimpiar.Visible = false;          
            }
           
        }

        private void txtCpu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }else if (char.IsControl(e.KeyChar)|| char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cbQuantum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else if (char.IsControl(e.KeyChar) || char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void trbVelocidad_Scroll(object sender, EventArgs e)
        {
            timerProcesos.Interval = trbVelocidad.Value;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            listEjecucion.Items.Clear();
            listProcesos.Items.Clear();
            nProceso = 0;
            quantum = 0;
            cbQuantum.Text = "";
            btnLimpiar.Visible = false;
        }

        private void timerProcesos_Tick(object sender, EventArgs e)
        {
            for(int j = 0; j < nProceso; j++)
            {
                Thread.Sleep(timerProcesos.Interval/10);
                if (cpu[j] > 0)
                {
                    if(cpu[j]<quantum)
                    {
                        for(int s = 1; s <= cpu[j]; s++)
                        {
                            ListViewItem proc = new ListViewItem();
                            proc.Text = proces[j];
                            proc.BackColor = colorProceso[j];
                            listEjecucion.Items.Add(proc);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= quantum; i++)
                        {
                            ListViewItem proc = new ListViewItem();
                            proc.Text = proces[j];
                            proc.BackColor = colorProceso[j];
                            listEjecucion.Items.Add(proc);
                        }
                    }
                   
                    cpu[j] = cpu[j] - quantum;
                }


            }

            
        }



        //---------------------------------
    }//----------------------------------
}
