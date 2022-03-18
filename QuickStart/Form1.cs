namespace QuickStart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // TODO: when not using the trial, uncomment the following line and don't forget to add your spg.vhlicense file as an embedded resource if you have purchased the product
            // VisualHint.SmartPropertyGrid.PropertyGrid.LocateLicenseInThisAssembly();

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myPropertyGrid1.Initialize();
        }
    }
}