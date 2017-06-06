using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace RentOfWagons
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBoxWagons.DisplayMember = "Number";
            comboBoxWagons.FormatString = "D8";
            comboBoxWagons.DataSource = UnitOfWork.Instance.OperationRepository.GetAllWagons();

        }

        private void buttonAddOperation_Click(object sender, EventArgs e)
        {
            AddNewOperation addForm = new AddNewOperation(comboBoxWagons.SelectedItem as Wagon);
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK && dataGridViewOperations.DataSource != null)
            {
                initDataGridViewOperations();
            }
        }

        private void buttonShowOperations_Click(object sender, EventArgs e)
        {
            initDataGridViewOperations();
        }

        private void comboBoxWagons_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewOperations.DataSource = null;
            dataGridViewOperations.Rows.Clear();
        }

        private void initDataGridViewOperations()
        {
            List<viewOperationModel> operations = new List<viewOperationModel>();
            operations.AddRange(UnitOfWork.Instance.OperationRepository.GetAllOperationsByWagon(comboBoxWagons.SelectedItem as Wagon)
                .Select(x => new viewOperationModel(x)));
            dataGridViewOperations.DataSource = operations;
        }

        private void buttonDeleteOperation_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewOperations.SelectedRows.Count != 0)
                {
                    int index = dataGridViewOperations.SelectedRows[0].Index;
                    dataGridViewOperations.MultiSelect = true;
                    dataGridViewOperations.Rows[index].Selected = true;
                    int selectedOperationID = (dataGridViewOperations.Rows[index].DataBoundItem as viewOperationModel).OperationID;
                    Operation selectedOperation = UnitOfWork.Instance.OperationRepository.GetById(selectedOperationID);

                    //нельзя удалять операции, которые вступили в силу вчера или раньше 
                    if (selectedOperation.StartDate < DateTime.Today)
                    {
                        throw new Exception("The operation, which is already in force cannot be deleted!");
                    }

                    List<Operation> childOperations = UnitOfWork.Instance.OperationRepository.GetChildOperations(selectedOperation);

                    //если есть дочерние операции будет предложено каскадное удаление
                    if (childOperations.Count > 0)
                    {
                        List<DataGridViewRow> rows = dataGridViewOperations.Rows
                            .Cast<DataGridViewRow>()
                            .Where(x => childOperations.Select(y => y.OperationID)
                                        .Contains((x.DataBoundItem as viewOperationModel).OperationID))
                            .ToList();

                        rows.ForEach(x => x.Selected = true);

                        DialogResult sureMsg = MessageBox.Show(string.Format("This operation has {0} child operations, which will be deleted too. Are you sure that you want to delete all these operations?", childOperations.Count), "Delete?", MessageBoxButtons.OKCancel);
                        if (sureMsg == DialogResult.OK)
                        {
                            childOperations.Select(x => x.OperationID)
                                .ToList()
                                .ForEach(x => UnitOfWork.Instance.OperationRepository.Delete(x));
                            UnitOfWork.Instance.OperationRepository.Delete(selectedOperationID);
                            initDataGridViewOperations();
                        }
                    }
                    else //если нет дочерних операций, тогда удаляется только выбранная операция
                    {
                        DialogResult sureMsg = MessageBox.Show("Are you sure that you want to delete this operation?", "Delete?", MessageBoxButtons.OKCancel);
                        if (sureMsg == DialogResult.OK)
                        {
                            UnitOfWork.Instance.OperationRepository.Delete(selectedOperationID);
                            initDataGridViewOperations();
                        }
                    }
                }
                else
                {
                    throw new Exception("Select the operation!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataGridViewOperations.MultiSelect = false;
            }
        }

        private void buttonUpdateOperation_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewOperations.SelectedRows.Count != 0)
                {
                    int index = dataGridViewOperations.SelectedRows[0].Index;
                    int selectedOperationID = (dataGridViewOperations.Rows[index].DataBoundItem as viewOperationModel).OperationID;
                    Operation selectedOperation = UnitOfWork.Instance.OperationRepository.GetById(selectedOperationID);

                    //если выбрана операция продажи
                    if (selectedOperation.RentLevel == 0)
                    {
                        //нельзя редактировать операцию продажи, если владелец вступил во владение вчера или раньше
                        if (selectedOperation.StartDate < DateTime.Today)
                        {
                            throw new Exception("The sale, which is already in force cannot be updated!");
                        }

                        UpdateSale updateForm = new UpdateSale(selectedOperation);
                        updateForm.ShowDialog();
                        if (updateForm.DialogResult == DialogResult.OK)
                        {
                            initDataGridViewOperations();
                        }
                    }
                    else //выбрана операция аренды
                    {
                        //нельзя редактировать операцию аренды, если срок аренды уже истек
                        if (selectedOperation.EndDate < DateTime.Today)
                        {
                            throw new Exception("The rent operation, which is already expired cannot be updated!");
                        }

                        UpdateRent updateForm = new UpdateRent(selectedOperation);
                        updateForm.ShowDialog();
                        if (updateForm.DialogResult == DialogResult.OK)
                        {
                            initDataGridViewOperations();
                        }
                    }
                }
                else
                {
                    throw new Exception("Select the operation!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
