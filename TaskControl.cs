using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace kanboard_alt_v2
{
    internal class TaskControl
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //public int TaskId { get; private set; }
        public int TaskId {  get; set; }

        private Panel taskPanel;
        private Form1 form;
        //private Form2 form2;

        Font titleFont = new Font("Arial", 10, FontStyle.Bold);
        Font descFont = new Font("Arial", 8, FontStyle.Regular);
        Font numFont = new Font("Arial", 9, FontStyle.Underline);
   

        public TaskControl (Form1 form, string title, string desc, int taskId)
        {
            Title = title;
            Description = desc;
            TaskId = taskId;
            this.form = form;
            CreateTaskPanel();
        }

        private void CreateTaskPanel()
        {
            taskPanel = new Panel();
            taskPanel.Width = 450;
            taskPanel.Height = 200;
            taskPanel.BackColor = Color.Gainsboro;
            

            var taskTitle = new Label();
            taskTitle.Text = Title;
            taskTitle.Dock= DockStyle.Top;
            taskTitle.TextAlign = ContentAlignment.TopLeft;
            taskTitle.Font= titleFont;
            //taskTitle.BackColor = Color.Yellow;


            var taskDesc = new Label();
            taskDesc.Text = Description;
            taskDesc.Dock = DockStyle.Fill;
            taskDesc.TextAlign = ContentAlignment.TopLeft;
            taskDesc.Size = new Size(50, 50);
            taskDesc.Font= descFont;
            //taskDesc.BackColor = Color.Green;

            var taskCount = new Label();
            taskCount.Text = $"Задача #{TaskId}";
            taskCount.Dock = DockStyle.Bottom;
            taskCount.TextAlign = ContentAlignment.TopLeft;
            taskCount.AutoSize = true;
            taskCount.Font = numFont;
            //taskCount.BackColor = Color.Red;

            var removeBtn = new Button();
            removeBtn.Text = "X";
            removeBtn.Font= numFont;
            removeBtn.Location = new Point(370, 0);
            removeBtn.Click += RemoveBtn_Click;

            var leftBtn = new Button();
            leftBtn.Text = "<";
            leftBtn.Font = titleFont;
            leftBtn.Location = new Point(50, 10);
            leftBtn.Dock = DockStyle.Bottom;
            leftBtn.Width = 5;
            leftBtn.BringToFront();

            var rightBtn = new Button();
            rightBtn.Text = ">";
            rightBtn.Font = titleFont;
            rightBtn.Location = new Point(50, 10);
            rightBtn.Dock = DockStyle.Bottom;
            rightBtn.Width = 5;
            rightBtn.BringToFront();

            var dropDown = new ComboBox();
            dropDown.Text = $"#{TaskId}";
            dropDown.Width = 100;
            dropDown.Items.Add("Изменить");
            dropDown.Items.Add("Выполнить");
            dropDown.Location = new Point(270, 0);
            dropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            dropDown.SelectionChangeCommitted += DropDown_SelectionChangeCommitted;


            //добавление элементов на панель
            taskPanel.Controls.Add(taskCount);
            taskPanel.Controls.Add(taskDesc);
            taskPanel.Controls.Add(taskTitle);
            taskPanel.Controls.Add(leftBtn);
            taskPanel.Controls.Add(rightBtn);
            taskTitle.Controls.Add(removeBtn);
            taskTitle.Controls.Add(dropDown);

        }


        //удаление задачи - передача метода
        private void RemoveBtn_Click(object? sender, EventArgs e)
        {
            form.RemovePanel(taskPanel);
        }

        private void DropDown_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            string dropdownValue = c.GetItemText(c.SelectedItem);

            switch (dropdownValue)
            {
                case "Изменить":
                    form.Hide();
                    Form2 f2 = new Form2();
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = form.Location;
                    f2.Size = form.Size;
                    f2.ChangeTaskDetails(Title, Description);
                    f2.ShowDialog();
                    //form.Close();

                    break;

                case "Выполнить":
                    MessageBox.Show("Пока!");
                    break;
            }
        }


        public Panel GetPanel()
        {
            return taskPanel;
        }
    }
}
