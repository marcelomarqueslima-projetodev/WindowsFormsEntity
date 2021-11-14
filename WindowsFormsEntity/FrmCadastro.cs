using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsEntity.Data;

namespace WindowsFormsEntity
{
    public partial class FrmCadastro : Form
    {
        Customer model = new Customer();
        public FrmCadastro()
        {
            InitializeComponent();
        }

        void Limpa()
        {
            txtCidade.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtSobrenome.Text = string.Empty;

            btnSalvar.Text = "Salvar";
            btnDeletar.Enabled = false;
            model.CustomerID = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpa();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void FrmCadastro_Load(object sender, EventArgs e)
        {
            Limpa();
        }
    }
}
