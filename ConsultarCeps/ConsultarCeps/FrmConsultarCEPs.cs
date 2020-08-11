using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultarCeps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textCEP.Text))
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(textCEP.Text.Trim());

                        textEstado.Text = endereco.uf;
                        textCidade.Text = endereco.cidade;
                        textBairro.Text = endereco.bairro;
                        textRua.Text = endereco.end;

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } 
            else
            {
                MessageBox.Show("Informe um CEP válido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            textCEP.Text = string.Empty;
            textEstado.Text = string.Empty;
            textBairro.Text = string.Empty;
            textCidade.Text = string.Empty;
            textRua.Text = string.Empty;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
