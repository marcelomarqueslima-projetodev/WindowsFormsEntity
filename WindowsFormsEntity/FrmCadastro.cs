using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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

        private void FrmCadastro_Load(object sender, EventArgs e)
        {
            Limpa();
            PopularDataGridView();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpa();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            model.Nome = txtNome.Text.Trim();
            model.Sobrenome = txtSobrenome.Text.Trim();
            model.Cidade = txtCidade.Text.Trim();
            model.Endereco = txtEndereco.Text.Trim();

            using (DBEntities db = new DBEntities())
            {
                if (model.CustomerID == 0)
                {
                    db.Customer.Add(model);
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                }   
                db.SaveChanges();
            }

            Limpa();
            PopularDataGridView();
            MessageBox.Show("Gravado com sucesso!");
        }

        void PopularDataGridView()
        {
            dgvCustomer.AutoGenerateColumns = false;
            using (DBEntities db = new DBEntities())
            {
                dgvCustomer.DataSource = db.Customer.ToList<Customer>();
            }
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.CurrentRow.Index != -1)
            {
                model.CustomerID = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["CustomerID"].Value);
                using (DBEntities db = new DBEntities())
                {
                    model = db.Customer.Where(x => x.CustomerID == model.CustomerID).FirstOrDefault();
                    txtCidade.Text = model.Cidade;
                    txtEndereco.Text = model.Endereco;
                    txtNome.Text = model.Nome;
                    txtSobrenome.Text = model.Sobrenome;
                }
                btnSalvar.Text = "Atualizar";
                btnDeletar.Enabled = true;
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente deletar?", "EF CRUD", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                model.CustomerID = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["CustomerID"].Value);
                using (DBEntities db = new DBEntities())
                {
                    model = db.Customer.Where(x => x.CustomerID == model.CustomerID).FirstOrDefault();
                    var entry = db.Entry(model);
                    if (entry.State == EntityState.Deleted)
                    {
                        db.Customer.Attach(model);
                    }
                    db.Customer.Remove(model);
                    db.SaveChanges();
                    Limpa();
                    PopularDataGridView();
                    MessageBox.Show("Registro Deletado com sucesso!");
                }
            }
        }
    }
}
