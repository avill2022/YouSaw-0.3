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
    public partial class Form1 : Form
    {
        pWMPF pWMPF = null;
        Form_Home form_Home = null;
        Form_Search search = null;
        Timer timer_playing_now_time_elapsed = new Timer();
        Timer timer_play = new Timer();
        int form_modo=0;
        Stream stream;
        int interval = 0;
        private int menu_horizontal_ = 1;

        public Form1()
        {
            InitializeComponent();
            pWMPF = new pWMPF();
            stream = new Stream();

            form_Home = new Form_Home(pWMPF, stream);
            form_Home.get_pictureBox_full().Click += on_Click;

            search = new Form_Search();

            stream.form_Search = search;
            stream.form_Home = form_Home;
           
            openForm(form_Home);

            pWMPF.GetAxWMPF().PlayStateChange += Form1_PlayStateChange;
            timer_playing_now_time_elapsed.Tick += timer_playing_now_time_elapsed_Tick;
            timer_play.Interval = 1000;
            timer_play.Tick += Timer_play_Tick;
        }

        private void Form1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (pWMPF.wmps_is_Playing())
            {
                //channels[iteratorChannel].duracion = (int)_pWMPF.wmps_duration();
                if (pWMPF.getAudioLanguageCount() == 2)
                {
                    pWMPF.setDualVisible(true);
                    //this.DUAL.Visible = true;
                    //this.DUAL.Text = "DUAL: " + _pWMPF.getAudioLanguageIndex();
                }
                else
                {
                    pWMPF.setDualVisible(false);
                    //this.DUAL.Visible = false;
                }
                //if (playing_now_time_elapsed > channels[iteratorChannel].duracion && channels[iteratorChannel]._id_channel != 0)
                {
                    /*channels.Remove(chan_);
                    interval = getTimetoint();
                    timer_play.Start();*/
                }
                timer_playing_now_time_elapsed.Start();
                /*pWMPF.set_channel_name(channels[iteratorChannel]._channel_name);
                pWMPF.set_channel_number(channels[iteratorChannel]._number);
                pWMPF.set_video_name(channels[iteratorChannel].playing_now_name());
                lnameVideo.Text = channels[iteratorChannel]._channel_name;
                linfoVideo.Text = channels[iteratorChannel].playing_now_name();*/
            }
            if (pWMPF.wmps_is_ended())
            {
                timer_playing_now_time_elapsed.Stop();
                timer_play.Stop();
                interval = Methods.timeNow();
                
            }
            if (pWMPF.wmps_is_stopped() && timer_playing_now_time_elapsed.Tag == null)
            {
                //MessageBox.Show("stop");
                if (stream.getChannel() != null){
                    timer_playing_now_time_elapsed.Stop();
                    //MessageBox.Show("stop");
                    /*this.getSlider().Value = 0;
                    this.get_label_transcurrin_time().Text = "00:00:00";
                    string s = channels[iteratorChannel].playing_now_name();
                    int duracion = channels[iteratorChannel].duracion;
                    channels[iteratorChannel].video_calculate();*/
                    //MessageBox.Show("Se calculo un nuevo video.\n Anterior:"+s+","+ duracion + ".\n Nuevo:" + channels[iteratorChannel].playing_now_name()+","+ channels[iteratorChannel].Duration());
                    timer_play.Start();
                }
                else
                {
                    //channels.Remove(chan_);
                    //set_channel();
                    //timer_play.Start();
                }
            }
        }
        int ended = 0;
        private void timer_playing_now_time_elapsed_Tick(object sender, EventArgs e)
        {
           /* this.bstranscurringtimelDurationVideo.MaximumValue = (int)pWMPF.get_wmps().currentMedia.duration;
            if (pWMPF.wmps_current_position() < bstranscurringtimelDurationVideo.MaximumValue)
                this.getSlider().Value = pWMPF.wmps_current_position();
            else
                this.getSlider().Value = 0;
            this.ldurationvideo.Text = Convert.ToString(TimeSpan.FromSeconds(bstranscurringtimelDurationVideo.MaximumValue));
            this.get_label_transcurrin_time().Text = Convert.ToString(TimeSpan.FromSeconds(pWMPF.wmps_current_position()));
            this.lTime_now.Text = Convert.ToString(TimeSpan.FromSeconds(get_time_now()));*/
        }
        
        private void Timer_play_Tick(object sender, EventArgs e)
        {
            if ((interval + 5) < Methods.timeNow())
            {
                stream.setChannel();
                timer_play.Stop();
            }
        }

        
        private bool menu_horizontal(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up: // right arrow key
                    menu_vertical_ = 7;
                    option_menu = 1; menu_horizontal_ = 1;
                    change_button_horizontal(0);
                    change_button_vertical(menu_vertical_);
                    return true;
                case Keys.Down: // right arrow key
                    menu_vertical_ = 1;
                    option_menu = 1; menu_horizontal_ = 1;
                    change_button_horizontal(0);
                    change_button_vertical(menu_vertical_);
                    return true;
                case Keys.Enter:
                    if (menu_horizontal_ == 7)
                        exit();
                    switch (menu_horizontal_) { 
                        case 1://search
                          break;
                        case 2://load
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5://tv mode
                            break;
                        case 6://maximize
                            change_WindowState();
                            break;
                        case 7:
                            exit();
                            break;
                    }
                    break;
                case Keys.Left: // left arrow key
                    menu_horizontal_ -= 1;
                    if (menu_horizontal_==0)
                        menu_horizontal_=7;
                    change_button_horizontal(menu_horizontal_);
                    return true;
                case Keys.Right: // right arrow key
                    menu_horizontal_ += 1;
                    if (menu_horizontal_ == 8)
                        menu_horizontal_ = 1;
                    change_button_horizontal(menu_horizontal_);
                    return true;
                case Keys.Add: // right arrow key

                    return true;
                case Keys.Subtract: // right arrow key

                    return true;
                case Keys.Escape: // right arrow key
                    this.exit();
                    return true;
                case Keys.F1: // right arrow key

                    return true;
                case Keys.F2: // right arrow key

                    return true;
            }
            return false;
        }
        private void change_button_horizontal(int op) {
            textBoxSearch.BorderStyle = BorderStyle.None;
            pictureBox1.BackColor = Color.FromArgb(28, 28, 28);
            pictureBox2.BackColor = Color.FromArgb(28, 28, 28);
            pictureBox3.BackColor = Color.FromArgb(28, 28, 28);
            pictureBox_tvmode.BackColor = Color.FromArgb(28, 28, 28);
            pictureBox_full.BackColor = Color.FromArgb(28, 28, 28);
            pictureBox_exit.BackColor = Color.FromArgb(28, 28, 28);
            switch (op)
            {
                case 0:
                    break;
                case 1:
                    textBoxSearch.BorderStyle = BorderStyle.Fixed3D;
                    textBoxSearch.Focus();
                    break;
                case 2:
                    pictureBox1.BackColor = Color.White;
                    pictureBox1.Focus();
                    break;
                case 3:
                    pictureBox2.BackColor = Color.White;
                    pictureBox2.Focus();
                    break;
                case 4:
                    pictureBox3.BackColor = Color.White;
                    pictureBox3.Focus();
                    break;
                case 5:
                    pictureBox_tvmode.BackColor = Color.White;
                    pictureBox_tvmode.Focus();
                    break;
                case 6:
                    pictureBox_full.BackColor = Color.White;
                    pictureBox_full.Focus();
                    break;
                case 7:
                    pictureBox_exit.BackColor = Color.White;
                    pictureBox_exit.Focus();
                    break;
                default:
                    option_menu = 2;
                    break;
            }
        }
        private int menu_vertical_ = 1;
        private int option_menu = 1;
        private bool menu_vertical(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up: // right arrow key
                    if (change_menu_form(keyData) < 0)
                    {
                        menu_vertical_ -= 1;
                        if (menu_vertical_ == 0)
                            option_menu = 2;
                        change_button_vertical(menu_vertical_);
                    }
                    return true;
                case Keys.Down: // right arrow key
                    if (change_menu_form(keyData) < 0)
                    {
                        menu_vertical_ += 1;
                        if (menu_vertical_ == 8)
                            option_menu = 2;
                        change_button_vertical(menu_vertical_);
                    }
                    return true;
                case Keys.Left: // left arrow key
                    if (change_menu_form(keyData) == -2)
                        change_estate_menu();
                    else { 
                    
                    }
                    return true;
                case Keys.Right: // right arrow key
                    if (change_menu_form(keyData) < 0)
                    {

                    }
                    return true;
                case Keys.Enter:
                    if (change_menu_form(keyData) < 0)
                    {

                    }
                    break;

                case Keys.Add: // right arrow key

                    return true;
                case Keys.Subtract: // right arrow key

                    return true;
                case Keys.Escape: // right arrow key
                    this.exit();
                    return true;
                case Keys.F1: // right arrow key

                    return true;
                case Keys.F2: // right arrow key

                    return true;
            }
            return false;
        }
        public void change_button_vertical(int op) {
            button_home.BackColor = Color.FromArgb(28,28,28);button_home.ForeColor = Color.White;
            button_now.BackColor = Color.FromArgb(28, 28, 28); button_now.ForeColor = Color.White;
            button_video.BackColor = Color.FromArgb(28, 28, 28); button_video.ForeColor = Color.White;
            button_music.BackColor = Color.FromArgb(28, 28, 28); button_music.ForeColor = Color.White;
            button_history.BackColor = Color.FromArgb(28, 28, 28); button_history.ForeColor = Color.White;
            button_whatch.BackColor = Color.FromArgb(28, 28, 28); button_whatch.ForeColor = Color.White;
            button_liked.BackColor = Color.FromArgb(28, 28, 28); button_liked.ForeColor = Color.White;
            switch (op) {
                case 0:
                    option_menu = 2;
                    menu_horizontal_ = 1;
                    change_button_horizontal(menu_horizontal_);
                    break;
                case 1:
                    openForm(form_Home);
                    form_Home.openForm(pWMPF);
                    //form_Home.init_flow_channels();
                    button_home.ForeColor = Color.FromArgb(28, 28, 28); button_home.BackColor = Color.White;
                    button_home.Focus();
                    break;
                case 2:
                    openForm(pWMPF);
                    button_now.ForeColor = Color.FromArgb(28, 28, 28); button_now.BackColor = Color.White;
                    button_now.Focus();
                    break;
                case 3:
                    //openForm(search);
                    //search.init_flow_channels();
                    //button_video.ForeColor = Color.FromArgb(28, 28, 28); button_video.BackColor = Color.White;
                    button_video.Focus();
                    break;
                case 4:
                    //openForm(search);
                    //button_music.ForeColor = Color.FromArgb(28, 28, 28); button_music.BackColor = Color.White;
                    button_music.Focus();
                    break;
                case 5:
                    //button_history.ForeColor= Color.FromArgb(28, 28, 28); button_history.BackColor  = Color.White;
                    button_whatch.Focus();
                    break;
                case 6:
                    //button_whatch.ForeColor = Color.FromArgb(28, 28, 28); button_whatch.BackColor = Color.White;
                    button_whatch.Focus();
                    break;
                case 7:
                    //button_liked.ForeColor = Color.FromArgb(28, 28, 28); button_liked.BackColor = Color.White;
                    button_liked.Focus();
                    break;
                default:
                    //option_menu = 2;
                    //change_button_horizontal(menu_horizontal_);
                    break;
            }
        }
        private int change_menu_form(Keys keyData) {
            switch (menu_vertical_)
            {
                case 0:
                    break;
                case 1:
                    return form_Home.get_option(keyData);
                case 2:
                    return pWMPF.get_option(keyData);
                case 3:
                    return search.get_option(keyData);
                case 4:
                    return search.get_option(keyData);
                case 5:
                    return -1;
                case 6:
                    return -1;
                case 7:
                    return -1;
                default:
                    return -1;
            }
            return -1;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (option_menu) {
                case 1:
                    menu_vertical(keyData);
                    return false;
                case 2:
                    menu_horizontal(keyData);//menu top
                    return false;
            }
            /*switch (keyData)
            {
                case Keys.Up: // right arrow key

                    return true;
                case Keys.Down: // right arrow key

                    return true;

                case Keys.Enter:

                    break;
                case Keys.Left: // left arrow key

                    return true;
                case Keys.Right: // right arrow key

                    return true;
                case Keys.Add: // right arrow key
                    pWMPF.volumeUp();
                    return true;
                case Keys.Subtract: // right arrow key
                    pWMPF.volumeDown();
                    return true;
                case Keys.Escape: // right arrow key
                    this.exit();
                    return true;
                case Keys.F1: // right arrow key

                    return true;
                case Keys.F2: // right arrow key

                    return true;
            }*/
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void openForm(object form)
        {
            Form fh = form as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            if (form_modo == 0)
            {
                if (this.contentPanel.Controls.Count > 0)
                    this.contentPanel.Controls.RemoveAt(0);
                this.contentPanel.Controls.Add(fh);
                this.contentPanel.Tag = fh;
                pWMPF.get_panel_menu().Visible = false;
            }
            else
            {
                if (pWMPF.get_panel_menu().Controls.Count > 0)
                    pWMPF.get_panel_menu().Controls.RemoveAt(0);
                if (fh.Equals(pWMPF))
                {
                    this.contentPanel.Controls.Add(fh);
                    this.contentPanel.Tag = fh;
                }
                else
                {

                    pWMPF.get_panel_menu().Controls.Add(fh);
                    pWMPF.get_panel_menu().Tag = fh;
                    pWMPF.get_panel_menu().Visible = true;
                }
            }
            fh.Show();
        }
        #region buttons menu
        private void textBoxSearch_MouseHover(object sender, EventArgs e)
        {
            this.search_button.Visible = true;
        }
        private void textBoxSearch_MouseLeave(object sender, EventArgs e)
        {
            this.search_button.Visible = false;
        }
        private void change_estate_menu() {
            if (flowLayoutPanel_menu.Width == 200)
            {
                flowLayoutPanel_menu.Width = 32;
                label_whatch.Visible = false;
            }
            else
            {
                flowLayoutPanel_menu.Width = 200;
                label_whatch.Visible = true;
            }
        }
        private void exit() {
            timer_playing_now_time_elapsed.Stop();
            timer_playing_now_time_elapsed.Tag = "exit";
            pWMPF.stop();
            this.Close();
        }
        private void on_Click(object sender, EventArgs e)
        {
            switch (((System.Windows.Forms.Control)sender).Name)
            {
                case "pictureBox_exit":
                    exit();
                    break;
                case "pictureBox_full":
                    change_button_vertical(menu_vertical_); change_WindowState();
                    break;
                case "pictureBox_tvmode":
                    menu_vertical_ = 0;
                    change_button_vertical(menu_vertical_);
                    break;
                case "pictureBox3":
                    menu_vertical_ = 0;
                    change_button_vertical(menu_vertical_);
                    break;
                case "pictureBox2":
                    menu_vertical_ = 0;
                    change_button_vertical(menu_vertical_);
                    break;
                case "pictureBox1":
                    menu_vertical_ = 0;
                    change_button_vertical(menu_vertical_);
                    break;
                //
                case "button_search":
                    break;
                case "button_menu":
                    change_estate_menu();
                    break;
                //
                case "button_home":
                    menu_vertical_ = 1;
                    change_button_vertical(menu_vertical_);
                    break;
                case "button_now":
                    menu_vertical_ = 2;
                    change_button_vertical(menu_vertical_);
                    break;
                case "button_video":
                    menu_vertical_ = 3;
                    change_button_vertical(menu_vertical_);
                    break;
                case "button_music":
                    menu_vertical_ = 4;
                    change_button_vertical(menu_vertical_);
                    break;
                case "button_history":
                    menu_vertical_ = 5;
                    change_button_vertical(menu_vertical_);
                    break;
                case "button_whatch":
                    menu_vertical_ = 6;
                    change_button_vertical(menu_vertical_);
                    break;
                case "button_liked":
                    menu_vertical_ = 7;
                    change_button_vertical(menu_vertical_);
                    break;
            }
        }
        private void change_WindowState() {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
                this.WindowState = FormWindowState.Normal;
        }
        public bool mouse_down = false;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_down = true;
            mosex = e.X;
            mousey = e.Y;
        }
        int mosex;
        int mousey;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_down)
            {

                this.SetDesktopLocation(MousePosition.X - mosex, MousePosition.Y - mousey);
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down = false;
        }
        #endregion
    }
}
