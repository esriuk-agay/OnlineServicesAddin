using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Desktop.AddIns;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.GISClient;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Display;
using System.Drawing;
using System.Text.RegularExpressions;
using DataHubServicesAddin.Dialogs;
using DataHubServicesAddin.LocatorHub;
using System.Windows.Forms;

namespace DataHubServicesAddin
{
    public class DataHubExtension : Extension
    {

        #region Delegates

        //private IActiveViewEvents_Event ActiveViewEvents;
        private IActiveViewEvents_AfterDrawEventHandler AfterDrawEventHandler;
        private IActiveViewEvents_Event activeViewEvents;
        #endregion

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="DataHubExtension"/> class.
        /// </summary>
        public DataHubExtension()
        {
            s_extension = this;
        }
        private const string LOCATOR_ELEMENT_NAME = "LocatorElement";


        /// <summary>
        /// Static Factory Reference
        /// </summary>
        internal static DataHubExtension Current
        {
            get
            {
                // Extension loads just in time, call FindExtension to load it.
                if (s_extension == null)
                {
                    UID extID = new UIDClass();

                    extID.Value = DataHubServicesAddin.ThisAddIn.IDs.DataHubExtension;
                    ArcMap.Application.FindExtensionByCLSID(extID);
                }
                return s_extension;
            }
        }
        static DataHubExtension s_extension = null;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [callout added].
        /// </summary>
        /// <value><c>true</c> if [callout added]; otherwise, <c>false</c>.</value>
        private bool CalloutAdded { get; set; }

        public IEnvelope CurrentEnvelope { get; set; }

        #endregion

        #region Startup and ShutDown


        /// <summary>
        /// Startup
        /// </summary>
        protected override void OnStartup()
        {
            AfterDrawEventHandler = new IActiveViewEvents_AfterDrawEventHandler(activeViewEvents_AfterDraw);
        }


        /// <summary>
        /// Shutdown
        /// </summary>
        protected override void OnShutdown()
        {
        }

        #endregion

        #region Utility Methods



        /// <summary>
        /// Converts a LocatorHub Point to an ArcGIS Point
        /// </summary>
        /// <param name="point"></param>
        /// <param name="spatialReference"></param>
        /// <param name="mapSpatialReference"></param>
        /// <returns></returns>
        private ESRI.ArcGIS.Geometry.Point CreatePoint(Double x, Double y, int spatialReference, ISpatialReference mapSpatialReference)
        {
            ESRI.ArcGIS.Geometry.Point returnedPoint = null;

            try
            {
                
                returnedPoint = new PointClass();
                returnedPoint.PutCoords(x, y);
                returnedPoint = ConvertToCoordinateSystem<PointClass>(returnedPoint as PointClass, spatialReference, mapSpatialReference);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            return returnedPoint;
        }


        /// <summary>
        /// Adds a Call Out
        /// </summary>
        /// <param name="point"></param>
        /// <param name="LocatorDescription"></param>
        private void AddCallout(ESRI.ArcGIS.Geometry.Point point, String LocatorDescription)
        {
            try
            {
                IMxDocument mxDocument = ArcMap.Application.Document as IMxDocument;
                try
                {
                    //Register if not already registered
                    IActiveViewEvents_Event check = mxDocument.ActiveView as IActiveViewEvents_Event;
                    if (check != this.activeViewEvents)
                    {
                        this.activeViewEvents = mxDocument.ActiveView as IActiveViewEvents_Event;
                        activeViewEvents.AfterDraw -= AfterDrawEventHandler;
                        activeViewEvents.AfterDraw += AfterDrawEventHandler;
                    }
                }
                catch (Exception)
                {
                }

                IMap map = mxDocument.FocusMap;
                IActiveView activeView = mxDocument.ActiveView;
                this.CurrentEnvelope = activeView.Extent;
                IFormattedTextSymbol formattedTextSymbol = new TextSymbolClass();
                ICallout callout = new BalloonCalloutClass();

                (callout as IBalloonCallout).Style = esriBalloonCalloutStyle.esriBCSRoundedRectangle;
                formattedTextSymbol.Background = callout as ITextBackground;
                callout.AnchorPoint = point;

                ITextElement textElement = new TextElementClass();
                string CalloutText = LocatorDescription.Replace("|LOCATOR_SEPARATOR|", System.Environment.NewLine);
                textElement.Text = CalloutText;
                IElement textElementAsElement = textElement as IElement;
                IPoint textPoint = (point as IClone).Clone() as IPoint;
                textPoint.PutCoords(point.X - (activeView.Extent.Width / 30), point.Y + (activeView.Extent.Width / 30));
                textElementAsElement.Geometry = textPoint;

                //Apply the properties
                textElement.Symbol = formattedTextSymbol;
                (textElement as IElementProperties).Name = LOCATOR_ELEMENT_NAME;

                //Add the Element to the view
                IGraphicsContainer graphicsContainer = map as IGraphicsContainer;
                graphicsContainer.AddElement(textElement as IElement, 0);
                textElementAsElement.Activate(activeView.ScreenDisplay);

                activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                this.CalloutAdded = true;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

        }


        /// <summary>
        /// Adds a point
        /// </summary>
        /// <param name="x">The X Coordinate</param>
        /// <param name="y">The y Coordinate</param>
        /// <param name="coordinateSystem">The coordinate system.</param>
        /// <param name="description">The description.</param>
        /// <param name="minX">The extent min X.</param>
        /// <param name="minY">The extent min Y.</param>
        /// <param name="maxX">The extent max X.</param>
        /// <param name="maxY">The extent max Y.</param>
        private void AddPoint(Double x, Double y, int coordinateSystem,  String description, Double minX, Double minY, Double maxX, Double maxY)
        {
            try
            {
                //get mapdocument
                IMxDocument mxDocument = ArcMap.Application.Document as IMxDocument;
                //get map
                IMap map = mxDocument.FocusMap;
                //get the active view
                IActiveView activeView = mxDocument.ActiveView;

                //get the point from the matched record
                ESRI.ArcGIS.Geometry.Point point = CreatePoint(x,y, coordinateSystem, map.SpatialReference);

                //create a simple marker and set attributes
                ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
                simpleMarkerSymbol.Size = 10;
                simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSDiamond;
                IRgbColor color = new RgbColorClass();
                color.Red = Color.Blue.R;
                color.Green = Color.Blue.G;
                color.Blue = Color.Blue.B;
                simpleMarkerSymbol.Color = color;

                //Create the Grapthics Element
                IMarkerElement markerElement = new MarkerElementClass();
                markerElement.Symbol = simpleMarkerSymbol as IMarkerSymbol;
                IElement markerElementAsElement = markerElement as IElement;
                markerElementAsElement.Geometry = point;
                IElementProperties markerElementAsElementProperties = markerElement as IElementProperties;
                markerElementAsElementProperties.Name = LOCATOR_ELEMENT_NAME;

                //Add the Element to the view
                IGraphicsContainer graphicsContainer = map as IGraphicsContainer;
                graphicsContainer.AddElement(markerElementAsElement as IElement, 0);
                markerElementAsElement.Activate(activeView.ScreenDisplay);
                activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

                //Add the callout box
                AddCallout(point, description);

                //move to location
                MoveToLocation(point, map,coordinateSystem, minX,minY,maxX,maxY);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

        }


        /// <summary>
        /// Moves to a Location
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="map">The map.</param>
        /// <param name="minX">The min X.</param>
        /// <param name="minY">The min Y.</param>
        /// <param name="maxX">The max X.</param>
        /// <param name="maxY">The max Y.</param>
        private void MoveToLocation(IPoint point, IMap map, int coordinateSystem ,Double minX, Double minY, Double maxX, Double maxY)
        {
            try
            {
                if (DataHubConfiguration.Current.UsePan)
                {
                    PanTo(point);
                }
                else
                {
                    //Check envelope is not of size 0x0
                    if (!(maxX == minX) && !(maxY == minY))
                    {
                        IEnvelope envelope = (IEnvelope)new ESRI.ArcGIS.Geometry.EnvelopeClass();
                        envelope.SpatialReference = map.SpatialReference;
                        envelope.PutCoords(minX, minY, maxX, maxY);
                        envelope = this.ConvertToCoordinateSystem<EnvelopeClass>(envelope as EnvelopeClass, coordinateSystem, map.SpatialReference);
                        ZoomTo(envelope);
                    }
                    else
                    {
                        PanTo(point);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }


        /// <summary>
        /// Zooms to a Location
        /// </summary>
        /// <param name="envelope"></param>
        private void ZoomTo(IEnvelope envelope)
        {
            try
            {
                IMxDocument mxDocument = null;
                ESRI.ArcGIS.Carto.IActiveView activeView = null;

                mxDocument = ArcMap.Application.Document as IMxDocument;
                activeView = (ESRI.ArcGIS.Carto.IActiveView)mxDocument.FocusMap;
                activeView.Extent = (IEnvelope)envelope;
                activeView.Refresh();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }


        /// <summary>
        /// Pans to a Location
        /// </summary>
        /// <param name="point"></param>
        private void PanTo(IPoint point)
        {
            try
            {
                IMxDocument mxDocument = null;
                ESRI.ArcGIS.Carto.IActiveView activeView = null;
                IEnvelope envelope = null;

                mxDocument = ArcMap.Application.Document as IMxDocument;
                activeView = (ESRI.ArcGIS.Carto.IActiveView)mxDocument.FocusMap;
                envelope = activeView.Extent.Envelope;
                envelope.CenterAt(point.Envelope.LowerLeft);
                activeView.Extent = envelope;
                activeView.Refresh();
                return;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }


        #region ConvertToCoordinateSystem
        /// <summary>
        /// Transforms an Point to a different coordinate system.
        /// </summary>
        /// <param name="inPoint">The Point to be Converted</param>
        /// <param name="inDataCoordinateSystem">The Coordinate System the point is currently in</param>
        /// <param name="inReturnCoordinateSystem">The coordinate System the point is to be returned into</param>
        /// <returns>A transformed point or null.</returns>
        public T ConvertToCoordinateSystem<T>(T inputGeometry, int inDataCoordinateSystem, ISpatialReference destSpatialReference) where T : IGeometry2
        {
            // Create source spatial reference

            ISpatialReferenceFactory2 spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            ISpatialReference sourceSpatialReference = spatialReferenceFactory.CreateSpatialReference(inDataCoordinateSystem);

            if (destSpatialReference == null) return inputGeometry;

            //cast T as IGeometry2 and project this. 
            IGeometry2 geometry = inputGeometry as IGeometry2;

            if ((inDataCoordinateSystem == 27700) && (destSpatialReference.FactoryCode == 4326))
            {
                IGeoTransformation geoTransformation = spatialReferenceFactory.CreateGeoTransformation(1196) as IGeoTransformation;
                geometry.ProjectEx(destSpatialReference as ISpatialReference, esriTransformDirection.esriTransformForward, geoTransformation, false, 0, 0);
            }
            else if ((inDataCoordinateSystem == 4326) && (destSpatialReference.FactoryCode == 27700))
            {
                IGeoTransformation geoTransformation = spatialReferenceFactory.CreateGeoTransformation(1196) as IGeoTransformation;
                geometry.ProjectEx(destSpatialReference as ISpatialReference, esriTransformDirection.esriTransformReverse, geoTransformation, false, 0, 0);
            }
            else if ((inDataCoordinateSystem == 27700) && (destSpatialReference.FactoryCode == 102113))
            {
                IGeoTransformation geoTransformation = spatialReferenceFactory.CreateGeoTransformation(1196) as IGeoTransformation;
                IGeoTransformation pGeoTrans_B = spatialReferenceFactory.CreateGeoTransformation(108100) as IGeoTransformation; // ' WGS84 Maj Aux Sphere to WGS84
                ICompositeGeoTransformation pGeoTransComposite = new CompositeGeoTransformationClass() as ICompositeGeoTransformation;
                pGeoTransComposite.Add(esriTransformDirection.esriTransformForward, geoTransformation); // National Grid to Wgs84
                pGeoTransComposite.Add(esriTransformDirection.esriTransformReverse, pGeoTrans_B);   // reversed sphere to wgs84
                geometry.ProjectEx(destSpatialReference, esriTransformDirection.esriTransformForward, pGeoTransComposite, false, 0, 0);
            }
            else if ((inDataCoordinateSystem == 102113) && (destSpatialReference.FactoryCode == 27700))
            {
                IGeoTransformation geoTransformation = spatialReferenceFactory.CreateGeoTransformation(1196) as IGeoTransformation;
                IGeoTransformation pGeoTrans_B = spatialReferenceFactory.CreateGeoTransformation(108100) as IGeoTransformation; // ' WGS84 Maj Aux Sphere to WGS84
                ICompositeGeoTransformation pGeoTransComposite = new CompositeGeoTransformationClass() as ICompositeGeoTransformation;
                pGeoTransComposite.Add(esriTransformDirection.esriTransformForward, pGeoTrans_B);   // sphere to wgs84
                pGeoTransComposite.Add(esriTransformDirection.esriTransformReverse, geoTransformation); // National Grid to Wgs84
                geometry.ProjectEx(destSpatialReference, esriTransformDirection.esriTransformForward, pGeoTransComposite, false, 0, 0);
            }
            else if ((inDataCoordinateSystem == 27700) && (destSpatialReference.FactoryCode == 102100))
            {
                IGeoTransformation geoTransformation = spatialReferenceFactory.CreateGeoTransformation(1196) as IGeoTransformation;
                IGeoTransformation pGeoTrans_B = spatialReferenceFactory.CreateGeoTransformation(108100) as IGeoTransformation; // ' WGS84 Maj Aux Sphere to WGS84
                ICompositeGeoTransformation pGeoTransComposite = new CompositeGeoTransformationClass();
                pGeoTransComposite.Add(esriTransformDirection.esriTransformForward, geoTransformation); // National Grid to Wgs84
                pGeoTransComposite.Add(esriTransformDirection.esriTransformReverse, pGeoTrans_B);   // reversed sphere to wgs84
                geometry.ProjectEx(destSpatialReference, esriTransformDirection.esriTransformForward, pGeoTransComposite, false, 0, 0);
            }
            else if ((inDataCoordinateSystem == 102100) && (destSpatialReference.FactoryCode == 27700))
            {
                IGeoTransformation geoTransformation = spatialReferenceFactory.CreateGeoTransformation(1196) as IGeoTransformation;
                IGeoTransformation pGeoTrans_B = spatialReferenceFactory.CreateGeoTransformation(108100) as IGeoTransformation; // ' WGS84 Maj Aux Sphere to WGS84
                ICompositeGeoTransformation pGeoTransComposite = new CompositeGeoTransformationClass();
                pGeoTransComposite.Add(esriTransformDirection.esriTransformForward, pGeoTrans_B);   // sphere to wgs84
                pGeoTransComposite.Add(esriTransformDirection.esriTransformReverse, geoTransformation); // National Grid to Wgs84
                geometry.ProjectEx(destSpatialReference, esriTransformDirection.esriTransformForward, pGeoTransComposite, false, 0, 0);
            }

            else if ((inDataCoordinateSystem == 27700) && (destSpatialReference.FactoryCode == 3857))
            {
                IGeoTransformation geoTransformation = spatialReferenceFactory.CreateGeoTransformation(1196) as IGeoTransformation;
                IGeoTransformation pGeoTrans_B = spatialReferenceFactory.CreateGeoTransformation(108100) as IGeoTransformation; // ' WGS84 Maj Aux Sphere to WGS84
                ICompositeGeoTransformation pGeoTransComposite = new CompositeGeoTransformationClass();
                pGeoTransComposite.Add(esriTransformDirection.esriTransformForward, geoTransformation); // National Grid to Wgs84
                pGeoTransComposite.Add(esriTransformDirection.esriTransformReverse, pGeoTrans_B);   // reversed sphere to wgs84
                geometry.ProjectEx(destSpatialReference, esriTransformDirection.esriTransformForward, pGeoTransComposite, false, 0, 0);
            }
            else if ((inDataCoordinateSystem == 3857) && (destSpatialReference.FactoryCode == 27700))
            {
                IGeoTransformation geoTransformation = spatialReferenceFactory.CreateGeoTransformation(1196) as IGeoTransformation;
                IGeoTransformation pGeoTrans_B = spatialReferenceFactory.CreateGeoTransformation(108100) as IGeoTransformation; // ' WGS84 Maj Aux Sphere to WGS84
                ICompositeGeoTransformation pGeoTransComposite = new CompositeGeoTransformationClass();
                pGeoTransComposite.Add(esriTransformDirection.esriTransformForward, pGeoTrans_B);   // sphere to wgs84
                pGeoTransComposite.Add(esriTransformDirection.esriTransformReverse, geoTransformation); // National Grid to Wgs84
                geometry.ProjectEx(destSpatialReference, esriTransformDirection.esriTransformForward, pGeoTransComposite, false, 0, 0);
            }
            else
            {
                geometry.Project(destSpatialReference as ISpatialReference);
            }

            return inputGeometry;
        }
        #endregion

        #endregion

        #region Operations


        /// <summary>
        /// Run LocatorHub Search
        /// </summary>
        internal void RunSearch()
        {
            try
            {
                if (LocatorCombo.Current.SelectedIndex == -1) return;
                //Get locator
                OnlineLocator onlineLocator = DataHubConfiguration.Current.Locators[LocatorCombo.Current.SelectedIndex];
                
                //Get Query String
                String Query = LocatorSearchQuery.Current.TextValue;

                //Get use Fuzzy
                bool UseFuzzy = DataHubConfiguration.Current.UseFuzzy;

                //create popup form
                LocatorHub.LocatorHub client = LocatorManager.CreateClient(onlineLocator);
                LocatorPopupForm locatorPopupForm = new LocatorPopupForm(client);

                int factcode = -1;
                try
                {
                    IMxDocument mxDocument = ArcMap.Application.Document as IMxDocument;
                    //get map
                    IMap map = mxDocument.FocusMap;
                    factcode = map.SpatialReference.FactoryCode;
                }
                catch (Exception)
                {
                  factcode = -1;
                }

                //Setup form
                locatorPopupForm.Setup(onlineLocator.Target, Query, onlineLocator.GazId, UseFuzzy, LocatorCombo.Current.TextValue, factcode);

                //Show popup if multiple records
                if (locatorPopupForm.FoundRecord == null && locatorPopupForm.FailReason == MatchResultCodes.PickList)
                {
                    //Show Dialog
                    locatorPopupForm.ShowDialog();
                }

                if (locatorPopupForm.DialogResult == DialogResult.OK)
                {
                    //get the matchresult from the popupform
                     MatchResult matchResult = locatorPopupForm.FoundRecord;
                    ClearGraphics();

                    string[] values = matchResult.MatchedRecord.R.V;
                    string[] point = values[locatorPopupForm.ColumnLookup["LOCATOR_POINT"]].Split(new string[] {","},  StringSplitOptions.RemoveEmptyEntries);
                    string description = values[locatorPopupForm.ColumnLookup["LOCATOR_DESCRIPTION"]];
                    string[] extent = values[locatorPopupForm.ColumnLookup["LOCATOR_ENVELOPE"]].Split(new string[] {","},  StringSplitOptions.RemoveEmptyEntries);
                    AddPoint(point[0].ToDouble(),point[1].ToDouble(), matchResult.ReturnedCoordinateSystem, description, extent[0].ToDouble(), extent[1].ToDouble(), extent[2].ToDouble(), extent[3].ToDouble());

                }
                else if (locatorPopupForm.DialogResult == DialogResult.Abort)
                {
                    switch (locatorPopupForm.FailReason)
                    {
                        case MatchResultCodes.NoMatchNoResult:
                            MessageBox.Show("No Match. There were no matches for the specified query.", "Query");
                            break;
                        case MatchResultCodes.NoMatchTooVague:
                            MessageBox.Show("Query too vague. There were too many possible matches for the specified query.", "Query");
                            break;
                    }

                }

                locatorPopupForm = null;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Clear Graphics
        /// </summary>
        internal void ClearGraphics()
        {
            try
            {
                IMxDocument mxDocument = ArcMap.Application.Document as IMxDocument;
                IActiveView activeView = mxDocument.ActiveView;
                IGraphicsContainer graphicsContainer = activeView.GraphicsContainer;

                //Pre fresh the Graphics Container
                activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

                //Loop thro the Elements Clearing the Locator Graphics
                graphicsContainer.Reset();
                for (IElement element = graphicsContainer.Next(); element != null; element = graphicsContainer.Next())
                {
                    IElementProperties elementProperties = element as IElementProperties;
                    if (elementProperties.Name == LOCATOR_ELEMENT_NAME)
                    {
                        graphicsContainer.DeleteElement(element);
                    }
                }
                this.CalloutAdded = false;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }


        /// <summary>
        /// Add AGS Map Layer
        /// </summary>
        /// <param name="inUserName"></param>
        /// <param name="inPassword"></param>
        /// <param name="inName"></param>
        /// <param name="inMapUrl"></param>
        internal void AddAGSLayer(string inUserName, string inPassword, string inName, string inMapUrl)
        {

            IAGSServerConnectionName2 agsServerConnectionName = (IAGSServerConnectionName2)new AGSServerConnectionName();

            // http://localhost/ArcGIS/rest/services/Map1/MapServer
            // Convert to http://localhost/ArcGis/Services
            // and http://localgsot/ArcGIS/Map1/MapServer

            string servicecatalog = inMapUrl.Substring(0, inMapUrl.IndexOf("/REST/SERVICES", StringComparison.CurrentCultureIgnoreCase)) + "/Services";
            string mapserviceurl = ReplaceEx(inMapUrl, "/REST/", "/", StringComparison.InvariantCultureIgnoreCase);
            string mapservice = "";
            Regex rMapServerRest = new Regex("^(?i:.*/REST/SERVICES/(?<mapname>.*)/MAPSERVER.*)$");
            Match m = rMapServerRest.Match(inMapUrl);
            if (m.Success)
            {
                mapservice = m.Groups["mapname"].Value;
            }


            //Create a property set of connection details
            IPropertySet props = new PropertySet();
            props.SetProperty("url", servicecatalog);
            if (inUserName != null)
            {
                props.SetProperty("user", inUserName);
                props.SetProperty("password", inPassword);
                props.SetProperty("hideuserproperty", false);
                props.SetProperty("anonymous", false);
            }
            IAGSServerObjectName2 agsServerObjectName = (IAGSServerObjectName2)new AGSServerObjectName();

            IAGSServerConnectionFactory AGSConnectionFactory = new AGSServerConnectionFactory();

            IAGSServerConnection AGSConnection = AGSConnectionFactory.Open(props, 0);
            IAGSEnumServerObjectName enumSOName = null;



            enumSOName = AGSConnection.ServerObjectNames;
            IAGSServerObjectName SOName = null;
            SOName = enumSOName.Next();
            while (SOName != null)
            {
                System.Diagnostics.Debug.WriteLine(SOName.Name + ": " + SOName.Type);
                if (SOName.Name.Equals(mapservice, StringComparison.InvariantCultureIgnoreCase) && SOName.Type == "MapServer")
                {

                    //create the layer object
                    IMapServerGroupLayer mapServerLayer = new MapServerLayerClass();
                    IName mapServerConnectionName = (IName)SOName;
                    IDataLayer dataLayer = (IDataLayer)mapServerLayer;
                    //try to connect
                    try
                    {
                        dataLayer.Connect(mapServerConnectionName);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Could not connect to URL", ex);
                    }

                    //create the layer name
                    ILayer layer;

                    layer = (ILayer)mapServerLayer;
                    layer.Visible = true;
                    layer.Name = inName;

                    //return the layer
                    ArcMap.Document.AddLayer(layer);
                    break;
                }
                SOName = enumSOName.Next();
            }
        }


        /// <summary>
        /// Implements fast string replacing algorithm for CS
        /// </summary>
        private static string ReplaceEx(string original, string pattern, string replacement, StringComparison comparisonType)
        {
            if (original == null)
            {
                return null;
            }

            if (String.IsNullOrEmpty(pattern))
            {
                return original;
            }

            int lenPattern = pattern.Length;
            int idxPattern = -1;
            int idxLast = 0;

            StringBuilder result = new StringBuilder();

            while (true)
            {
                idxPattern = original.IndexOf(pattern, idxPattern + 1, comparisonType);

                if (idxPattern < 0)
                {
                    result.Append(original, idxLast, original.Length - idxLast);

                    break;
                }

                result.Append(original, idxLast, idxPattern - idxLast);
                result.Append(replacement);

                idxLast = idxPattern + lenPattern;
            }

            return result.ToString();
        }
        #endregion

        #region Generic Error Handler


        /// <summary>
        /// Show Error Dialog
        /// </summary>
        /// <param name="ex"></param>
        internal static void ShowError(Exception ex)
        {
            try
            {
                ErrorForm errorForm = new ErrorForm(ex);
                errorForm.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Events


        /// <summary>
        /// Actives the view events_ after draw.
        /// </summary>
        /// <param name="display">The display.</param>
        /// <param name="drapwPhase">The drapw phase.</param>
        /// <remarks>Fixes an issue where as you zoom in the tail on the callout gets longer.</remarks>
        private void activeViewEvents_AfterDraw(IDisplay display, esriViewDrawPhase drapwPhase)
        {
            IMxDocument mxDocument = (IMxDocument)ArcMap.Application.Document;
            if (this.CalloutAdded)
            {
                if (this.CurrentEnvelope != null)
                {
                    if (this.CurrentEnvelope.Width != mxDocument.ActiveView.Extent.Width || this.CurrentEnvelope.Height != mxDocument.ActiveView.Extent.Height)
                    {
                        IGraphicsContainer graphicsContainer = (IGraphicsContainer)mxDocument.FocusMap;
                        graphicsContainer.Reset();
                        IElement graphic = graphicsContainer.Next();
                        while (graphic != null)
                        {
                            IElementProperties properties = graphic as IElementProperties;
                            if (properties != null)
                            {
                                if (properties.Name == DataHubExtension.LOCATOR_ELEMENT_NAME)
                                {
                                    ITextElement textElement = graphic as ITextElement;
                                    IFormattedTextSymbol formattedTextSymbol = textElement.Symbol as IFormattedTextSymbol;
                                    IBalloonCallout balloonCallout = formattedTextSymbol.Background as IBalloonCallout;
                                    IPoint newPoint = new PointClass();
                                    newPoint.PutCoords(balloonCallout.AnchorPoint.X - (mxDocument.ActiveView.Extent.Width / 30), balloonCallout.AnchorPoint.Y + (mxDocument.ActiveView.Extent.Width / 30));
                                    graphic.Geometry = newPoint;
                                    break;
                                }
                            }
                            graphic = graphicsContainer.Next();
                        }
                    }
                }
            }

            this.CurrentEnvelope = mxDocument.ActiveView.Extent;
        }

        #endregion
    }
}
