namespace QuickStart
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
            myPropertyGrid1.Initialize();
        }
    }
}