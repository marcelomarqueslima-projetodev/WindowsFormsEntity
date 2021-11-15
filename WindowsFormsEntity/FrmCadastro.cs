using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
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

        void PopularDataGridView()
        {
            dgvCustomer.AutoGenerateColumns = false;
            using (DBEntities db = new DBEntities())
            {
                dgvCustomer.DataSource = db.Customer.ToList<Customer>();
            }
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
            model.Nome = txtNome.Text.Trim();
            model.Sobrenome = txtSobrenome.Text.Trim();
            model.Cidade = txtCidade.Text.Trim();
            model.Endereco = txtEndereco.Text.Trim();

            using (DBEntities db = new DBEntities())
            {
                db.Customer.Add(model);
                db.SaveChanges();
            }

            Limpa();
            MessageBox.Show("Gravado com sucesso!");
        }

        private void FrmCadastro_Load(object sender, EventArgs e)
        {
            Limpa();
            PopularDataGridView();
        }
    }
}
