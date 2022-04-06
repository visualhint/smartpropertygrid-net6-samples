using VisualHint.SmartPropertyGrid;
using VisualHint.SmartPropertyGrid.FluentApi;

namespace PropertyGridShowRoom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                // When you have a license file, add it to your project as an embedded resource and call this:
                VisualHint.SmartPropertyGrid.PropertyGrid.LocateLicenseInThisAssembly();
            }
            catch
            {
                throw;
            }

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myPropertyGrid1.LazyLoading = true;

            metaPropertyGrid1.Populate(myPropertyGrid1);

            // Instead of creating the properties manually, we will fill the grid with SelectedObject and rely on the fluent API to configure the properties
            //myPropertyGrid1.Populate();
            FluentSelectedObjectConfigurator.CreateConfiguration(config => config.AddConfigurationProfile<TargetClassProfile>()).Build(myPropertyGrid1);
            myPropertyGrid1.SelectedObject = new TargetClass();

            myPropertyGrid1.HyperLinkPropertyClicked += new
                VisualHint.SmartPropertyGrid.PropertyGrid.HyperLinkPropertyClickedEventHandler(MyPropertyGrid1_HyperLinkPropertyClicked);

            // Comment out for a filter textbox
/*            ToolStripLabel lbl = new ToolStripLabel("Filter:");
            ToolStripTextBox txt = new ToolStripTextBox("filter");
            txt.Name = "spg_filterTextbox";
            txt.BorderStyle = BorderStyle.None;
            myPropertyGrid1.Toolbar.Items.Add(lbl);
            myPropertyGrid1.Toolbar.Items.Add(txt);
            txt.TextChanged += new EventHandler(txt_TextChanged);
            myPropertyGrid1.DisplayModeChanged += new VisualHint.SmartPropertyGrid.PropertyGrid.DisplayModeChangedEventHandler(myPropertyGrid1_DisplayModeChanged);*/
        }

        // Comment out for a filter textbox
/*        void myPropertyGrid1_DisplayModeChanged(object sender, EventArgs e)
        {
            // Comment out for a filter textbox
            string filter = ((ToolStripTextBox)myPropertyGrid1.Toolbar.Items["spg_filterTextbox"]).Text;
            if ((filter.Length > 0) && !_insideFilterProperties)
                FilterProperties(filter);
        }

        private bool _insideFilterProperties = false;

        void FilterProperties(string filter)
        {
            _insideFilterProperties = true;

            PropertyEnumerator selectedEnum = myPropertyGrid1.SelectedPropertyEnumerator;

            myPropertyGrid1.BeginUpdate();

            VisualHint.SmartPropertyGrid.PropertyGrid.DisplayModes dispMode = myPropertyGrid1.DisplayMode;
            myPropertyGrid1.DisplayMode = VisualHint.SmartPropertyGrid.PropertyGrid.DisplayModes.Categorized;

            PropertyEnumerator propEnum = myPropertyGrid1.FirstProperty;
            while (propEnum != propEnum.RightBound)
            {
                if ((propEnum.Property.Value != null) || (propEnum.Property is PropertyHyperLink))
                {
                    if (propEnum.Property.DisplayName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        PropertyEnumerator parentEnum = propEnum.GetDeepEnumerator();
                        while (parentEnum != parentEnum.RightBound)
                        {
                            if (!parentEnum.Property.Visible)
                                myPropertyGrid1.ShowProperty(parentEnum, true);
                            parentEnum.MoveParent();
                        }
                    }
                    else
                    {
                        myPropertyGrid1.ShowProperty(propEnum, false);
                        PropertyEnumerator parentEnum = propEnum.GetDeepEnumerator();
                        parentEnum.MoveParent();
                        while (parentEnum != parentEnum.RightBound)
                        {
                            if (parentEnum.Property.Visible && !myPropertyGrid1.HasOneVisibleChild(parentEnum))
                                myPropertyGrid1.ShowProperty(parentEnum, false);
                            parentEnum.MoveParent();
                        }
                    }
                }

                propEnum.MoveNext();
            }

            if ((selectedEnum.Property != null) && selectedEnum.Property.Visible && !selectedEnum.Property.Selected)
                myPropertyGrid1.SelectProperty(selectedEnum);

            myPropertyGrid1.DisplayMode = dispMode;
            myPropertyGrid1.EndUpdate();

            _insideFilterProperties = false;
        }

        void txt_TextChanged(object sender, EventArgs e)
        {
            ToolStripTextBox txt = (ToolStripTextBox)sender;
            FilterProperties(txt.Text);
        }*/

        void MyPropertyGrid1_HyperLinkPropertyClicked(object sender, PropertyHyperLinkClickedEventArgs e)
        {
            if (metaPropertyGrid1.Enabled)
            {
                metaPropertyGrid1.DisableMode = VisualHint.SmartPropertyGrid.PropertyGrid.DisableModes.Simple;
                metaPropertyGrid1.Enabled = false;
                e.PropertyEnum.Property.DisplayName = "Enable left grid";
            }
            else
            {
                metaPropertyGrid1.Enabled = true;
                e.PropertyEnum.Property.DisplayName = "Disable left grid";
            }
        }
    }
}