using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataHubServicesAddin.LocatorHub;

namespace DataHubServicesAddin.Dialogs
{
    public partial class ConfigureFieldListForm : Form
    {
        private OnlineLocator locator;
        private List<string> allFields;
        private string configuredFields;

        public ConfigureFieldListForm()
        {
            InitializeComponent();
        }

        public ConfigureFieldListForm(OnlineLocator inLocator)
            : this()
        {
            this.locator = inLocator;
            this.locatorNameLabel.Text = inLocator.Name;
            GetAllFields();
            PopulateListBoxes();
            EnableButtons();
        }

        private void GetAllFields()
        {
            try
            {
                LocatorHub.LocatorHub client = LocatorManager.CreateClient(locator);

                FetchRecordResult fieldsResult = client.FetchRecord(
                    locator.GazId, locator.Target, "$$_LOCATORHUB_FETCH_SCHEMA", RecordIdentifierType.Custom, 27700);
                allFields = new List<string>();
                LocatorColumn[] cols = fieldsResult.TableData.C;
                foreach (LocatorColumn col in cols)
                {
                    allFields.Add(col.n);
                }
            }
            catch (Exception exv)
            {
                DataHubExtension.ShowError(exv);
            }
        }

        private void PopulateListBoxes()
        {
            chosenFieldsListBox.Items.Clear();
            string[] chosenFields = this.locator.FieldList();
            foreach (string chosenField in chosenFields)
            {
                if (allFields.Contains(chosenField))
                    chosenFieldsListBox.Items.Add(chosenField);
            }
            availableFieldsListBox.Items.Clear();
            foreach (string field in allFields)
            {
                if (!chosenFields.Contains(field))
                    availableFieldsListBox.Items.Add(field);
            }
        }

        private void EnableButtons()
        {
            butMoveRight.Enabled = (availableFieldsListBox.SelectedIndex >= 0);
            butMoveLeft.Enabled = (chosenFieldsListBox.SelectedIndex >= 0);
            butMoveUp.Enabled = (chosenFieldsListBox.SelectedIndex > 0);
            butMoveDown.Enabled = ((chosenFieldsListBox.SelectedIndex >= 0) && 
                ((1 + chosenFieldsListBox.SelectedIndex) < chosenFieldsListBox.Items.Count));
            butOK.Enabled = (chosenFieldsListBox.Items.Count > 0);
        }

        private void AddToChosen()
        {
            string item = availableFieldsListBox.SelectedItem as string;
            if (item == null) return;
            availableFieldsListBox.Items.Remove(item);
            chosenFieldsListBox.Items.Add(item);
            chosenFieldsListBox.SelectedItem = item;
        }

        private void RemoveFromChosen()
        {
            string item = chosenFieldsListBox.SelectedItem as string;
            if (item == null) return;
            int insertIndex = -1;
            int origIndex = allFields.IndexOf(item);
            for (int i = 0; i < availableFieldsListBox.Items.Count; i++)
            {
                string availItem = availableFieldsListBox.Items[i] as string;
                int itemIndex = allFields.IndexOf(availItem);
                if (itemIndex > origIndex)
                {
                    insertIndex = i;
                    break;
                }
            }
            chosenFieldsListBox.Items.Remove(item);
            if (insertIndex < 0)
            {
                availableFieldsListBox.Items.Add(item);
            }
            else
            {
                availableFieldsListBox.Items.Insert(insertIndex, item);
            }
            availableFieldsListBox.SelectedItem = item;
        }

        private void MoveUp()
        {
            int selIndex = chosenFieldsListBox.SelectedIndex;
            if (selIndex < 1) return;
            string item = chosenFieldsListBox.SelectedItem as string;
            chosenFieldsListBox.Items.RemoveAt(selIndex);
            chosenFieldsListBox.Items.Insert(selIndex - 1, item);
            chosenFieldsListBox.SelectedItem = item;
        }

        private void MoveDown()
        {
            int selIndex = chosenFieldsListBox.SelectedIndex;
            if (selIndex < 0) return;
            if ((1 + selIndex) >= chosenFieldsListBox.Items.Count) return;
            string item = chosenFieldsListBox.SelectedItem as string;
            chosenFieldsListBox.Items.RemoveAt(selIndex);
            chosenFieldsListBox.Items.Insert(selIndex + 1, item);
            chosenFieldsListBox.SelectedItem = item;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            string[] fields = new string[chosenFieldsListBox.Items.Count];
            for (int i = 0; i < fields.Length; i++)
                fields[i] = chosenFieldsListBox.Items[i] as string;
            this.configuredFields = string.Join(",", fields);
            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void butMoveRight_Click(object sender, EventArgs e)
        {
            AddToChosen();
            EnableButtons();
        }

        private void butMoveLeft_Click(object sender, EventArgs e)
        {
            RemoveFromChosen();
            EnableButtons();
        }

        private void butMoveUp_Click(object sender, EventArgs e)
        {
            MoveUp();
            EnableButtons();
        }

        private void butMoveDown_Click(object sender, EventArgs e)
        {
            MoveDown();
            EnableButtons();
        }

        private void availableFieldsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (availableFieldsListBox.SelectedIndex >=0)
                chosenFieldsListBox.ClearSelected();
            EnableButtons();
        }

        private void chosenFieldsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chosenFieldsListBox.SelectedIndex >=0) 
                availableFieldsListBox.ClearSelected();
            EnableButtons();
        }

        /// <summary>
        /// Returns a comma-separated list of configured field names.
        /// </summary>
        public string ConfiguredFields
        {
            get { return configuredFields; }
        }
    }
}
