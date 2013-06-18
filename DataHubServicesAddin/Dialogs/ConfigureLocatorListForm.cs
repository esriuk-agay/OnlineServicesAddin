using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Linq;
using DataHubServicesAddin.LocatorHub;

namespace DataHubServicesAddin.Dialogs
{
    /// <summary>
    /// Form for displaying a list of locators
    /// </summary>
    internal partial class ConfigureLocatorListForm : Form
    {

        private List<Target> _Targets;
        private BindingList<OnlineLocator> _Locators = new BindingList<OnlineLocator>();

        /// <summary>
        /// Initializes a new instance of the <see cref="frmLocatorCollection"/> class.
        /// </summary>
        /// <param name="inLocators">The in locators.</param>
        public ConfigureLocatorListForm()
        {
            InitializeComponent();
        }

        public ConfigureLocatorListForm(List<OnlineLocator> locators)
            : this()
        {
            this._Locators = new BindingList<OnlineLocator>(locators);
            lstLocators.DataSource = _Locators;
            lstLocators.DisplayMember = "Name";
            lstLocators.ValueMember = "Name";
            lstLocators.Refresh();
            ConfigureUI();
        }

        internal List<OnlineLocator> ConfiguredLocators { get; private set; }

        /// <summary>
        /// Class used to hold an id and a description
        /// </summary>
        private class Target
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TargetAndName"/> class.
            /// </summary>
            /// <param name="inId">The in id.</param>
            /// <param name="inDescription">The in description.</param>
            public Target(string targetId, string targetDescription)
            {
                this.Id = targetId;
                this.Description = targetDescription;
            }


            /// <summary>
            /// Gets the id.
            /// </summary>
            /// <value>
            /// The id.
            /// </value>
            public string Id
            {
                get;
                private set;
            }


            /// <summary>
            /// Gets the description.
            /// </summary>
            /// <value>
            /// The description.
            /// </value>
            public string Description
            {
                get;
                private set;
            }
        }


        /// <summary>
        /// Configures the UI.
        /// </summary>
        public void ConfigureUI()
        {
            //try
            //{
            //    if (lstLocators.SelectedItem != null) butRemoveLocator.Enabled = true; else butRemoveLocator.Enabled = false;
            //    butMoveLocatorDown.Enabled = ((butRemoveLocator.Enabled == true) && (lstLocators.SelectedIndex < _Locators.Count - 1));
            //    butMoveLocatorUp.Enabled = ((butRemoveLocator.Enabled == true) && (lstLocators.SelectedIndex >= 1));
            //}
            //catch (Exception) { }

        }



        /// <summary>
        /// Handles the Click event of the butAddLocator control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void butAddLocator_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigureLocatorForm configureLocatorForm = new ConfigureLocatorForm();
                List<string> names = new List<string>();
                foreach (OnlineLocator loc in _Locators)
                {
                    names.Add(loc.Name);
                }
                configureLocatorForm.LocatorNamesAlreadyInUse = names;
                if (configureLocatorForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        OnlineLocator newloc =  configureLocatorForm.ConfiguredLocator;
                        LocatorHub.LocatorHub client = LocatorManager.CreateClient(newloc);
                        LocatorCapabilities locatorCapabilities = client.Capabilities(newloc.GazId);
                        newloc.Target = locatorCapabilities.TargetElements[0].TargetElementIdentity;
                        _Locators.Add(newloc);
                        lstLocators.Refresh();
                        lstLocators.SelectedItem = newloc;
                        lstLocators.Refresh();
                        this.lstLocators_SelectedIndexChanged(this, null);
                    }
                    catch (Exception)
                    {

                    }

                }
            }
            catch (Exception exv)
            {
                DataHubExtension.ShowError(exv);
            }
            

        }

        /// <summary>
        /// Handles the Click event of the butRemoveLocator control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void butRemoveLocator_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstLocators.SelectedItem != null)
                    _Locators.Remove(lstLocators.SelectedItem as OnlineLocator);
                    lstLocators.Refresh();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the lstLocators control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lstLocators_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (lstLocators.SelectedItem != null)
                {
                    OnlineLocator current = lstLocators.SelectedItem as OnlineLocator;
                    LocatorHub.LocatorHub client = LocatorManager.CreateClient(current);

                    LocatorCapabilities locatorCapabilities = client.Capabilities(current.GazId);

                    List<Target> targets = new List<Target>();
                    foreach(TargetElementDefinition targetElementDefinition in locatorCapabilities.TargetElements)
                    {
                        targets.Add(new Target(targetElementDefinition.TargetElementIdentity, targetElementDefinition.TargetElementName));
                    }

                    this._Targets = targets;

                    cboTarget.DisplayMember = "Description";
                    cboTarget.ValueMember = "Id";
                    this.cboTarget.DataSource = _Targets;
                    cboTarget.SelectedValue = _Targets[0].Id;
                    cboTarget.Refresh();


                    ConfigureUI();
                }
            }
            catch (Exception)
            {
            }

                

        }

        /// <summary>
        /// Handles the Click event of the butEditLocatorDefinition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void butEditLocatorDefinition_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstLocators.SelectedItem == null) return;
                
                OnlineLocator currentItem = lstLocators.SelectedItem as OnlineLocator;
                if (currentItem == null) return;

                ConfigureLocatorForm configureLocatorForm = new ConfigureLocatorForm(currentItem);
                List<string> names = new List<string>();
                foreach (OnlineLocator loc in _Locators)
                {
                    names.Add(loc.Name);
                }

                names.Remove(currentItem.Name);
                configureLocatorForm.LocatorNamesAlreadyInUse = names;
                if (configureLocatorForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this._Locators.ResetBindings();
                        lstLocators.Refresh();
                    }
                    catch (Exception)
                    {

                    }

                }
            }
            catch (Exception exv)
            {
                DataHubExtension.ShowError(exv);
            }

            try
            {
                
                //using (ConfigureLocatorDialog cd = new ConfigureLocatorDialog())
                //{
                //    LocatorConfig loc = (LocatorConfig)lstLocators.SelectedItem;
                //    List<string> names = new List<string>();
                //    foreach (LocatorConfig tloc in _Locators)
                //    {
                //        names.Add(tloc.Name);
                //    }
                //    names.Remove(loc.Name);
                //    cd.ConfiguredLocator = loc;
                //    cd.LocatorNamesAlreadyInUse = names;
                //    if (cd.ShowDialog() == DialogResult.OK)
                //    {
                //        try
                //        {
                //            _Locators.ResetBindings();
                //            lstLocators.Refresh();
                //        }
                //        finally
                //        {

                //        }

                //    }
                //}
            }
            catch (Exception ex)
            {
                DataHubExtension.ShowError(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the butOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
           
                this.ConfiguredLocators = this._Locators.ToList();

                this.Close();
            }
            catch (Exception exv)
            {
                DataHubExtension.ShowError(exv);
            }
        }

        /// <summary>
        /// Handles the Click event of the butCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
               
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception)
            {
            }
        }



        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboTarget control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstLocators.SelectedItem == null) return;
                if (cboTarget.SelectedItem == null) return;
                OnlineLocator onlineLocator = lstLocators.SelectedItem as OnlineLocator;
                Target target = cboTarget.SelectedItem as Target;
                onlineLocator.Target = target.Id;
                ConfigureUI();
            }
            catch (Exception ex)
            {
                DataHubExtension.ShowError(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the butMoveLocatorUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void butMoveLocatorUp_Click(object sender, EventArgs e)
        {
            try
            {
                int currentindex = lstLocators.SelectedIndex;
                OnlineLocator onlineLocator = _Locators[currentindex];
                _Locators.RemoveAt(currentindex);
                _Locators.Insert(currentindex - 1, onlineLocator);
                _Locators.ResetBindings();
                lstLocators.Refresh();
                lstLocators.SelectedIndex = currentindex - 1;
            }
            catch (Exception ex)
            {
                DataHubExtension.ShowError(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the butMoveLocatorDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void butMoveLocatorDown_Click(object sender, EventArgs e)
        {
            try
            {
                int currentindex = lstLocators.SelectedIndex;
                OnlineLocator onlineLocator = _Locators[currentindex];
                _Locators.RemoveAt(currentindex);
                _Locators.Insert(currentindex + 1, onlineLocator);
                _Locators.ResetBindings();
                lstLocators.Refresh();
                lstLocators.SelectedIndex = currentindex + 1;
            }
            catch (Exception ex)
            {
                DataHubExtension.ShowError(ex);
            }
        }

    }
}
