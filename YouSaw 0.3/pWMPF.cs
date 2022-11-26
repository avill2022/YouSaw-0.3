using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.IO;

namespace YouSaw_0._3
{
    public partial class pWMPF : Form
    {
        private string urlfile = "";

        Timer timer_error_message;//timer_error_message
        int current_time_error_message = 0;
        Timer timer_message_window;//timer_message_window
        int current_time_message = 0;
        Timer timer_volumen;//timer_volumen
        int current_time_volumen = 0;
        IWMPControls3 ctl3;
        int volumen = 50;

        public pWMPF()
        {
            InitializeComponent();
            axWMP.uiMode = "none";
            axWMP.stretchToFit = true;
            timer_error_message = new Timer();
            timer_error_message.Interval = 1000;
            timer_error_message.Tick += timer_error_message_Tick;
            timer_message_window = new Timer();
            timer_message_window.Tick += timer_message_window_Tick;
            timer_volumen = new Timer();
            timer_volumen.Tick += timer_volumen_Tick;
            progresBarrVolumen.Maximum = 100;
            panel_menu.Visible = false;
            ctl3 = (IWMPControls3)this.axWMP.Ctlcontrols;
            axWMP.TabIndex = 1;
            //WMP1.settings.setMode("Loop", true);
        }
        public AxWMPLib.AxWindowsMediaPlayer GetAxWMPF()
        {
            return axWMP;
        }

        int menu_vertical_ = -1;
        public int get_option(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up: // right arrow key
                    return menu_vertical_;
                case Keys.Down: // right arrow key
                    return menu_vertical_;

                case Keys.Left: // left arrow key
                    menu_vertical_ -= 1;
                    if (menu_vertical_ < 0)
                        menu_vertical_ = -1;
                    MessageBox.Show("" + menu_vertical_);
                    return menu_vertical_;

                case Keys.Right: // right arrow key
                    menu_vertical_ += 1;
                    MessageBox.Show("" + menu_vertical_);
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
        public void play()
        {
            if(video!=null)
            playURLfile(this.video);
        }
        FileInfo video;
        public void playURLfile(FileInfo f)
        {
            try
            {
                video= f;
                urlfile = f.FullName.Replace('?', '\'');
                axWMP.URL = urlfile;
                axWMP.stretchToFit = true;
                axWMP.settings.volume = volumen;
                lnombrechannel.Text = video.Directory.Name;
                lname_video.Text = video.Name;
            }
            catch (Exception e)
            {
                message_error("Error: " + e.Message);
            }
        }
        public void stop()
        {
            try
            {
                timer_error_message.Stop();
                timer_message_window.Stop();
                timer_volumen.Stop();
                axWMP.Ctlcontrols.stop();
            }
            catch (System.Runtime.InteropServices.InvalidComObjectException icomobj)
            {
                label1.Text = icomobj.ToString();
            }

        }
        public void mute()
        {
            if (axWMP.settings.mute)
                axWMP.settings.mute = false;
            else
                axWMP.settings.mute = true;
            show_volumen();
        }
        public void show_volumen()
        {
            progresBarrVolumen.Value = volumen;
            axWMP.settings.volume = volumen;
            timer_volumen.Start();
            pvolumen.Visible = true;
            if (volumen == 0)
            {
                pvolumen.Visible = false;
                panel_mute.Visible = true;
            }
            else
            {
                pvolumen.Visible = true;
                panel_mute.Visible = false;
            }
        }
        public void volumeUp()
        {
            current_time_volumen = int.Parse(TimeSpan.Parse(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second).TotalSeconds.ToString());
            if (volumen < 100)
                volumen += 10;
            show_volumen();
        }
        public void volumeDown()
        {
            current_time_volumen = int.Parse(TimeSpan.Parse(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second).TotalSeconds.ToString());
            if (volumen > 0)
                volumen -= 10;
            show_volumen();
        }
        private void message_error(string message)
        {
            current_time_error_message = int.Parse(TimeSpan.Parse(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second).TotalSeconds.ToString());
            if (message.Equals(""))
            {
                p_error.Visible = false;
            }
            else
            {
                p_error.Visible = true;
                p_error.Text = p_error.Text + "\n" + message;
            }
            timer_error_message.Start();
        }
        public string getNameVideo()
        {
            return lname_video.Text;
        }
        public void show_message()
        {
            if (video != null)
            {
                pError.Visible = false;
                pchannel.Visible = true;
                current_time_message = int.Parse(TimeSpan.Parse(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second).TotalSeconds.ToString());
                timer_message_window.Start();
                timer_error_message.Stop();
                dual_visible();

            }
        }
        public void setCurrentPosition(double current)
        {
            if (current <= 0)
                axWMP.Ctlcontrols.currentPosition = 0;
            else
                axWMP.Ctlcontrols.currentPosition = current;
        }
        public void setDualVisible(bool r)
        {
            if (r)
                DUAL.Visible = true;
            else
                DUAL.Visible = false;
        }
        public int getAudioLanguageIndex()
        {
            if (this.wmps_is_Playing())
            {
                return ctl3.currentAudioLanguageIndex;
            }
            return 1;
        }

        public bool change_language()
        {
            if (this.wmps_is_Playing())
            {
                if (ctl3.audioLanguageCount == 2)
                {
                    if (ctl3.currentAudioLanguageIndex == 1)
                        ctl3.currentAudioLanguageIndex = 2;
                    else
                        ctl3.currentAudioLanguageIndex = 1;
                    return true;
                }
            }
            return false;
        }
        private void dual_visible()
        {
            if (this.wmps_is_Playing())
            {
                if (ctl3.audioLanguageCount >= 2)
                    DUAL.Visible = true;
                else
                    DUAL.Visible = false;
            }
        }
        public int getAudioLanguageCount()
        {
            if (this.wmps_is_Playing())
            {
                return ctl3.audioLanguageCount;
            }
            return 1;
        }
        public int get_audio_language_index()
        {
            if (this.wmps_is_Playing())
            {
                return ctl3.currentAudioLanguageIndex;
            }
            return 1;
        }
        public bool wmps_is_Playing()
        {
            if (axWMP.playState == WMPLib.WMPPlayState.wmppsPlaying)
                return true;
            else
                return false;
        }
        public bool wmps_is_ended()
        {
            if (axWMP.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
                return true;
            else
                return false;
        }
        public bool wmps_is_stopped()
        {
            if (axWMP.playState == WMPLib.WMPPlayState.wmppsStopped)
                return true;
            else
                return false;
        }
        public int wmps_current_position()
        {
            try
            {
                return (int)axWMP.Ctlcontrols.currentPosition;
            }
            catch (System.Runtime.InteropServices.InvalidComObjectException)
            {

                return 0;
            }
        }
        public String wmps_durationString()
        {
            if (axWMP.URL != "")
                return axWMP.currentMedia.durationString;
            else
                return "";
        }
        public double wmps_duration()
        {
            if (axWMP.URL != "")
                return axWMP.currentMedia.duration;
            else
                return 0;
        }
        private void timer_message_window_Tick(object sender, EventArgs e)
        {
            if ((current_time_message + 10) < int.Parse(TimeSpan.Parse(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second).TotalSeconds.ToString()))
            {
                pchannel.Visible = false;
                timer_message_window.Stop();
                message_error("");
            }
        }
        private void timer_error_message_Tick(object sender, EventArgs e)
        {
            if ((current_time_error_message + 5) < int.Parse(TimeSpan.Parse(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second).TotalSeconds.ToString()))
            {
                if (!this.wmps_is_Playing())
                {
                    pError.Show();
                }
                else
                    pError.Hide();
                timer_error_message.Stop();
            }
        }
        private void timer_volumen_Tick(object sender, EventArgs e)
        {
            if ((current_time_volumen + 1) < int.Parse(TimeSpan.Parse(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second).TotalSeconds.ToString()))
            {
                pvolumen.Visible = false;
                timer_volumen.Stop();
            }
        }

        public Panel get_panel_menu()
        {
            return panel_menu;
        }

    }
}
