using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataHubServicesAddin.LocatorHub;

namespace DataHubServicesAddin.Dialogs
{
    public partial class LocatorPopupForm : Form
    {

        #region "Variables"
        
        String _Query;
        String _MatchType;
        bool _UseFuzzy;
        Stack<MatchResult> _MatchCache = new Stack<MatchResult>();
        DataTable _CurrentDataTable;
        string _LocatorId;
        int _SpatialReference = -1;
        
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LocatorPopupForm"/> class.
        /// </summary>
        public LocatorPopupForm(LocatorHub.LocatorHub client)
        {
            InitializeComponent();
            this.Client = client;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        public LocatorHub.LocatorHub Client { get; private set; }

        /// <summary>
        /// Gets the found record.
        /// </summary>
        /// <value>
        /// The found record.
        /// </value>
        public MatchResult FoundRecord
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the fail reason.
        /// </summary>
        /// <value>
        /// The fail reason.
        /// </value>
        public MatchResultCodes FailReason
        {
            get;
            private set;
        }


        /// <summary>
        /// Gets the column lookup.
        /// </summary>
        /// <value>
        /// The column lookup.
        /// </value>
        public Dictionary<String, int> ColumnLookup
        {
            get;
            private set;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Setups the specified in match type.
        /// </summary>
        /// <param name="inMatchType">Type of the in match.</param>
        /// <param name="inQuery">The in query.</param>
        /// <param name="inLocatorId">The in locator id.</param>
        /// <param name="inFuzzy">if set to <c>true</c> [in fuzzy].</param>
        /// <param name="inName">Name of the in.</param>
        /// <param name="spref">The spref.</param>
        public void Setup(string inMatchType, string inQuery, string inLocatorId, bool inFuzzy, string inName, int spref)
        {
            //Setup Values for Selection
            _Query = inQuery;
            _MatchType = inMatchType;
            _UseFuzzy = inFuzzy;
            _SpatialReference = spref;
            this._LocatorId = inLocatorId;
            //set caption
            this.Text = "Select " + inName;

            //Run Match without drill down and no item selected
            RunMatch(inLocatorId, inMatchType, inQuery, inFuzzy, false, -1);
        }

        /// <summary>
        /// Runs the match.
        /// </summary>
        /// <param name="inLocatorId">The in locator id.</param>
        /// <param name="inMatchType">Type of the in match.</param>
        /// <param name="inQuery">The in query.</param>
        /// <param name="inFuzzy">if set to <c>true</c> [in fuzzy].</param>
        /// <param name="indrillDown">if set to <c>true</c> [indrill down].</param>
        /// <param name="inSelectedItem">The in selected item.</param>
        private void RunMatch(string inLocatorId, String inMatchType, String inQuery, bool inFuzzy, bool indrillDown, int inSelectedItem)
        {
            try
            {

                //set RoecordID & CacheID to be empty
                String RecordID = "";
                String CacheID = "";

                //if its a drill down then grab the RecordId and CacheID
                if (indrillDown)
                {
                    RecordID = _MatchCache.Peek().PickListItems[inSelectedItem].RecordId.ToString();
                    CacheID = _MatchCache.Peek().CacheIdentifier;
                }


                //Run First Query and Pop results onto stack
                MatchResult matchResult = this.Client.Match(inLocatorId, inMatchType, inQuery, inFuzzy, RecordID, _SpatialReference, CacheID);

                switch (matchResult.TypeOfResult)
                {
                    case MatchResultCodes.PickList:

                        //Produce a DataTable for the Datagrid to show
                        _CurrentDataTable = ConvertToDataTable(matchResult);

                        //cache query for drilldown
                        _MatchCache.Push(matchResult);
                        break;

                    case MatchResultCodes.SingleMatch:

                        //code for case where show if parent haschildren but Singlerecord is returned
                        if (_MatchCache.Count != 0)
                        {
                            if (_MatchCache.Peek().PickListItems[inSelectedItem].HasChildren)
                            {
                                //show in datgrid as a single record
                                DataTable dataTable = new DataTable();
                                dataTable.Columns.Add("Drill", typeof(Bitmap));
                                dataTable.Columns.Add("Score");
                                dataTable.Columns.Add("Description");

                                DataRow dataRow = dataTable.NewRow();
                                Bitmap bitmap = new Bitmap(GetType().Assembly.GetManifestResourceStream("DataHubServicesAddin.Images.Search.bmp"));
                                dataRow[0] = bitmap;
                                dataRow[1] = matchResult.MatchedRecordScore;
                                dataRow[2] = matchResult.MatchedRecord.R.V[2/*"LOCATOR_DESCRIPTION"*/].Replace("|LOCATOR_SEPARATOR|", ",");
                                dataTable.Rows.Add(dataRow);
                                _CurrentDataTable = dataTable;
                                _MatchCache.Push(matchResult);
                            }
                            else
                            {
                                //set the found item
                                this.FoundRecord = matchResult;
                                BuildColumnLookup();

                                //inform all that the dialog has been closed with OK
                                DialogResult = DialogResult.OK;
                            }

                        }
                        else
                        {
                            //set the found item
                            this.FoundRecord = matchResult;
                            BuildColumnLookup();
                            //inform all that the dialog has been closed with OK
                            DialogResult = DialogResult.OK;
                        }
                        break;

                    default:
                        this.FailReason = matchResult.TypeOfResult;
                        this.DialogResult = DialogResult.Abort;
                        break;

                }
            }
            catch (Exception ex)
            {
                DataHubExtension.ShowError(ex);
            }
        }

        private void BuildColumnLookup()
        {

            this.ColumnLookup = new Dictionary<string, int>();
            //Build a dictionary of Column name to ordinal for easy lookup
            for (int i = 0; i < this.FoundRecord.MatchedRecord.C.Length; i++)
            {
                LocatorColumn locatorColumn = this.FoundRecord.MatchedRecord.C[i];
                this.ColumnLookup.Add(locatorColumn.n, i);
            }
        }

        private DataTable ConvertToDataTable(MatchResult matchResult)
        {
            //Create a new Datatable
            DataTable dataTable = new DataTable();

            try
            {
                //Add Columns
                dataTable.Columns.Add("Drill", typeof(Bitmap));
                dataTable.Columns.Add("Score");
                dataTable.Columns.Add("Description");

                //add a new row for each item in the picklist
                foreach (PickItem pickItem in matchResult.PickListItems)
                {
                    //Create a new DataRow
                    DataRow dataRow = dataTable.NewRow();

                    //Add Data To Row
                    if (pickItem.HasChildren)
                    {

                        Bitmap bitmap = new Bitmap(GetType().Assembly.GetManifestResourceStream("DataHubServicesAddin.Images.Drill.bmp"));
                        dataRow[0] = bitmap;
                    }
                    else
                    {
                        Bitmap bitmap = new Bitmap(GetType().Assembly.GetManifestResourceStream("DataHubServicesAddin.Images.Search.bmp"));
                        dataRow[0] = bitmap;
                    }
                    dataRow[1] = pickItem.Score;
                    dataRow[2] = pickItem.Description;

                    //Add Row to Datatable
                    dataTable.Rows.Add(dataRow);

                }
            }
            catch (Exception ex)
            {
                DataHubExtension.ShowError(ex);
            }

            //return the Datatable - all filled up and ready to bind
            return dataTable;
        }

        #endregion

        #region "Events"

        private void butBack_Click(object sender, EventArgs e)
        {
            //pop the current item off the stack as we are moving back an iteration
            _MatchCache.Pop();

            //Convert the last Cache to a datatable
            _CurrentDataTable = ConvertToDataTable(_MatchCache.Peek());

            //Display datatable in GridView
            DGResults.DataSource = _CurrentDataTable;
            DGResults.Refresh();

            //If there is only one cache then disable the back button as we can go back no further
            if (_MatchCache.Count <= 1)
            {
                butBack.Enabled = false;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void DGResults_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Catch Any singlerecords displayed as picklists
            if (_MatchCache.Count > 0)
            {
                if (_MatchCache.Peek().TypeOfResult == MatchResultCodes.SingleMatch)
                {
                    this.FoundRecord = _MatchCache.Peek();
                    BuildColumnLookup();
                    this.DialogResult = DialogResult.OK;
                    return;
                }
            }

            RunMatch(_LocatorId, _MatchType, _Query, _UseFuzzy, true, DGResults.CurrentRow.Index);
            DGResults.DataSource = _CurrentDataTable;

            DGResults.Refresh();

            //enable the back button as now we are 1 step down the results tree
            butBack.Enabled = true;
        }

        private void LocatorPopupForm_Shown(object sender, EventArgs e)
        {

            //disable back button as nothing to return to
            butBack.Enabled = false;

            //Bing DataTable to DataGridView When Form is shown
            DGResults.DataSource = _CurrentDataTable;

            DGResults.Columns["Drill"].HeaderText = "";

            //Set first to columns to set size and freeze them so that they dont move
            DGResults.Columns[0].Width = 25;
            DGResults.Columns[0].Resizable = DataGridViewTriState.False;
            DGResults.Columns[1].Width = 40;
            DGResults.Columns[1].Resizable = DataGridViewTriState.False;
        }

        #endregion

    }
}