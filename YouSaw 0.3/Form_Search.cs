using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouSaw_0._3
{
    public partial class Form_Search : Form
    {
        EasyPanels easy = new EasyPanels();
        public Form_Search()
        {
            InitializeComponent();
            flowLayoutPanel.MouseWheel += FlowLayoutPanel_MouseWheel;
        }
        int menu_vertical_ = -1;
        int menu_horizontal = -1;
        public int get_option(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up: // right arrow key
                    menu_horizontal -= 1;
                    if (menu_horizontal < -1)
                        menu_horizontal = -2;
                    //MessageBox.Show("" + menu_horizontal);
                    return menu_vertical_;
                case Keys.Down: // right arrow key
                    if (menu_horizontal == -2)
                        menu_horizontal = -1;

                    if (menu_horizontal < (flowLayoutPanel.Controls.Count - 1))
                    {
                        menu_horizontal += 1;
                        //change_menu_horizontal(menu_horizontal);
                    }
                    //MessageBox.Show("" + menu_horizontal);
                    return menu_vertical_;

                case Keys.Left: // left arrow key
                    //MessageBox.Show("" + menu_vertical_);
                    menu_vertical_ -= 1;
                    if (menu_vertical_ <-1)
                        menu_vertical_ = -2;
                    //MessageBox.Show("" + menu_vertical_);
                    change_menu_horizontal(menu_vertical_);
                    return menu_vertical_;

                case Keys.Right: // right arrow key
                    //MessageBox.Show("" + menu_vertical_);
                    if (menu_vertical_ == -2)
                        menu_vertical_ = -1;

                    if (menu_vertical_ < (flowLayoutPanelChannels.Controls.Count-1))
                    {
                        menu_vertical_ += 1;
                        change_menu_horizontal(menu_vertical_);
                    }
                    //MessageBox.Show("" + menu_vertical_);
                    
                    return menu_vertical_;

                case Keys.Enter:
                    return menu_vertical_;
                case Keys.Add: // right arrow key
                    return menu_vertical_;
                case Keys.Subtract: // right arrow key
                    return menu_vertical_;
                case Keys.Escape: // right arrow key
                    return menu_vertical_;
                case Keys.F1: // right arrow key
                    return menu_vertical_;
                case Keys.F2: // right arrow key
                    return menu_vertical_;
            }
            return menu_vertical_;
        }
        int numer = 2;
        private void FlowLayoutPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.flowLayoutPanel.VerticalScroll.Value >= (this.flowLayoutPanel.VerticalScroll.Maximum- this.flowLayoutPanel.VerticalScroll.Maximum / numer))
                load_channels(option);
        }
        private void flowLayoutPanel_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.flowLayoutPanel.VerticalScroll.Value >= (this.flowLayoutPanel.VerticalScroll.Maximum-this.flowLayoutPanel.VerticalScroll.Maximum / numer))
                load_channels(option);
        }
        public FlowLayoutPanel get_flow_layout_panel()
        {
            return this.flowLayoutPanelChannels;
        }
        List<Channel> channels;
        public void set_channel(List<Channel> channels_)
        {
            channels = channels_;
            this.init_flow_channels();
        }
        private void change_menu_horizontal(int op)
        {
            foreach (Control c in flowLayoutPanelChannels.Controls)
            {
                Button button = (Button)c;
                c.ForeColor = Color.White;
                button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            }
            if(menu_vertical_ >= 0){
                Button b = (Button)flowLayoutPanelChannels.Controls[op];
                b.BackColor = Color.White;
                b.ForeColor = Color.Black;

                option = b.Text.ToString();
                flowLayoutPanel.Controls.Clear();
                scroll_indice = -1;
                load_channels(option);
            }
        }
        public void init_flow_channels() {
            foreach (Channel c in channels)
            {
                //c.Click += button_item;
                flowLayoutPanelChannels.Controls.Add(c);
            }
        }
        int scroll_max = 20;
        int scroll_indice = -1;
        string option="";
        private void button_all(object sender, EventArgs e)
        {
            if (!option.Equals("all"))
            {
                option = "all";
                flowLayoutPanel.Controls.Clear();
                scroll_indice = -1;
                load_channels(option);
            }
        }
        private void button_item(object sender, EventArgs e)
        {
            foreach (Control c in flowLayoutPanelChannels.Controls)
            {
                EasyPanels.ItemChannel button = (EasyPanels.ItemChannel)c;
                button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            }
            if (!option.Equals(((EasyPanels.ItemChannel)sender).Text.ToString()))
            {
                option = ((EasyPanels.ItemChannel)sender).Text.ToString();
                flowLayoutPanel.Controls.Clear();
                scroll_indice = -1;
                load_channels(option);
            }
        }
        public void load_channels(string option_) {
            int sum = 0;
            int cont = 0;
           /* foreach (Channel channel in channels)
                sum+=channel.items.Count;
            if ((scroll_indice) != sum) { 
                foreach (Channel channel in channels)
                    foreach (Item f in channel.items)
                    {
                        if (cont > scroll_indice)
                        {
                            //Panel panel = f.panel.item_panel("n1", f.panel.fileInfo.Name, f.panel.fileInfo.Length.ToString(), f.panel.fileInfo.Attributes.ToString(), new Size(300, 300));
                            //flowLayoutPanel.Controls.Add(panel);
                            if (cont == (scroll_indice + scroll_max))
                            {
                                scroll_indice = cont;

                                return;
                            }
                            else
                                cont++;
                        }
                        else cont++;
                    }
                scroll_indice = cont;
            }*/
        }
    }
}
