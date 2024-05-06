using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace kanboard_alt_v2
{
    public partial class Form1 : Form
    {

        int taskId;


        public Form1()
        {
            InitializeComponent();


            textBox1.Text = "заголовок";
            textBox2.Text = "короткое описание";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ControlsAdd(Control control)
        {
            flowLayoutPanel1.Controls.Add(control);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var taskControl = new TaskControl
                (this,textBox1.Text,
                textBox2.Text,
                ++taskId);

            AddTaskControl(taskControl);
            //Form2 frm = new Form2();
            //frm.Show();
        }

        private void AddTaskControl(TaskControl taskControl)
        {
            Panel panel = taskControl.GetPanel();
            flowLayoutPanel1.Controls.Add(panel);
          

        }

        //удаление задачи - метод
        public void RemovePanel(Control control)
        {
            flowLayoutPanel1.Controls.Remove(control);
        }
        
    }
}
