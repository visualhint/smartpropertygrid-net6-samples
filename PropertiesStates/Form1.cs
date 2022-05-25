using static VisualHint.SmartPropertyGrid.PropertyGrid;

namespace PropertiesStates
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

            propertyGrid1.SelectedObject = new TargetClass();
        }

        private object? _propertiesStates;

        private void button1_Click(object sender, EventArgs e)
        {
            // Before setting a new target to the grid, save the expanded/collapsed states of the properties
            // None does not mean "none at all". It means none of the additional states that the grid can handle. Expanded state is always saved by default
            _propertiesStates = propertyGrid1.SavePropertiesStates(PropertyStateFlags.None);

            // Select a completely different target
            propertyGrid1.SelectedObject = new OtherTargetClass();

            // Since the button stole the focus, revert it to the grid
            propertyGrid1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Calling SelectedObject and then RestorePropertiesStates would create a quick visual annoyance, so let's freeze display update
            propertyGrid1.BeginUpdate();

            // Select the target that was first in the grid
            propertyGrid1.SelectedObject = new TargetClass(); // Could be also the initial reference instead of a new one

            // Restore the way properties were expanded/collapsed (and check that PropertyExpandedAttribute on Size property is overriden by the saved state)
            propertyGrid1.RestorePropertiesStates(_propertiesStates);

            // Redraw the grid
            propertyGrid1.EndUpdate();

            // Since the button stole the focus, revert it to the grid
            propertyGrid1.Focus();
        }
    }
}
