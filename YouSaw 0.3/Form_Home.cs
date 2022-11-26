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
using WMPLib;

namespace YouSaw_0._3
{
    public partial class Form_Home : Form
    {
        //EasyPanels easy = new EasyPanels();
        EasyPanels.Starts stars;

        public pWMPF pWMPF;
        public Stream stream;

        public Form_Home(pWMPF pWMPF, Stream stream)
        {
            InitializeComponent();

            this.pWMPF = pWMPF;
            this.pWMPF.mute();
            this.openForm(pWMPF);
            this.stream = stream;
            this.panel_list.Controls.Add(this.stream);


            stars = new EasyPanels.Starts();
            this.pStarts.Controls.Add(stars);
            foreach (PictureBox a in stars.Controls)
                a.Click += stars_Click;
        }
        public int menu_horizontal_ = -1;//index of menu videos selected
        public int get_option(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up: // right arrow key
                    if (menu_horizontal_ >= Methods.MenuOptions)
                    {
                        if (stream.getChannel().item_selected >= 0)
                            stream.getChannel().item_selected -= 1;
                        stream.getChannel().changeItem();
                    }
                    return menu_horizontal_;

                case Keys.Down: // right arrow key
                    if (menu_horizontal_ >= Methods.MenuOptions)
                    {
                        if (stream.getChannel().item_selected < stream.getChannel().getItemsCount() - 1)
                            stream.getChannel().item_selected += 1;
                        stream.getChannel().changeItem();
                    }
                    return menu_horizontal_;

                case Keys.Left: // left back
                    menu_horizontal_ -= 1;
                    if (menu_horizontal_ < (int)Methods.MenuOption.isOpen)
                        menu_horizontal_ = (int)Methods.MenuOption.isClose;
                    //if is lower than options like: play, next subtitle, and maximize
                    clearButtons();
                    stream.clearChannelSelected();
                    if (menu_horizontal_ < Methods.MenuOptions)
                        setOptionMenu();
                    else
                        if (menu_horizontal_ >= Methods.MenuOptions)
                        {
                            stream.changeChanel(menu_horizontal_ - Methods.MenuOptions);
                            
                        }
                    return menu_horizontal_;
                case Keys.Right: // next option
                    if (menu_horizontal_ == (int)Methods.MenuOption.isClose)//if menu is close
                        menu_horizontal_ = (int)Methods.MenuOption.isOpen;
                    //add one if menu_vertical options is less than channels and menu_options
                    clearButtons();
                    if (menu_horizontal_ < ((stream.getChannels().Count - 1) + Methods.MenuOptions))
                    {
                        menu_horizontal_ += 1;
                        setOptionMenu();
                    }
                    if (menu_horizontal_ >= Methods.MenuOptions)
                    {
                        stream.changeChanel(menu_horizontal_ - Methods.MenuOptions);
                    }
                        
                    return menu_horizontal_;

                case Keys.Enter:
                    if (menu_horizontal_ < Methods.MenuOptions)
                    {
                        switch (menu_horizontal_)
                        {
                            case 0://play
                                playStop();
                                pictureBox_play.BackColor = Color.White;
                                break;
                            case 1://next
                                nextVideo();
                                pictureBox_next.BackColor = Color.White;
                                break;
                            case 2://subtitle
                                subtitles();
                                pictureBox_subtitle.BackColor = Color.White;
                                break;
                            case 3://expand
                                extend();
                                pictureBox_expand.BackColor = Color.White;
                                break;
                            case 4://full screen
                                maximize();
                                pictureBox_full.BackColor = Color.White;
                                break;
                        }
                    }
                    else
                    {
                        if (stream.getChannel().getItemsCount() > 0)
                            if (stream.getChannel().item_selected > -1 && stream.getChannel().item_selected <= stream.getChannel().getItemsCount() - 1)
                            {
                                setVideo(stream.getChannel().getItemSelected(),0);
                            }
                    }
                    return menu_horizontal_;
                case Keys.Add: // right arrow key
                    return menu_horizontal_;
                case Keys.Subtract: // right arrow key
                    return menu_horizontal_;
                case Keys.Escape: // right arrow key
                    return menu_horizontal_;
                case Keys.F1: // right arrow key
                    return menu_horizontal_;
                case Keys.F2: // right arrow key
                    return menu_horizontal_;
            }
            return menu_horizontal_;
        }
        public void clearButtons()
        {
            //clear bottons
            pictureBox_play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            pictureBox_next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            pictureBox_subtitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            pictureBox_expand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            pictureBox_full.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
        }
        public void setOptionMenu()
        {
            switch (menu_horizontal_)
            {
                case 0://play
                    pictureBox_play.BackColor = Color.White;
                    pictureBox_play.Focus();
                    break;
                case 1://next
                    pictureBox_next.BackColor = Color.White;
                    pictureBox_next.Focus();
                    break;
                case 2://subtitle
                    pictureBox_subtitle.BackColor = Color.White;
                    pictureBox_subtitle.Focus();
                    break;
                case 3://expand
                    pictureBox_expand.BackColor = Color.White;
                    pictureBox_expand.Focus();
                    break;
                case 4://full screen
                    pictureBox_full.BackColor = Color.White;
                    pictureBox_full.Focus();
                    break;
            }
        }
        public void setVideo(Item item, double currentPosition)
        {
            if (item != null)
            {
                //unselect_videos();
                item.isSelected(true);
                pWMPF.playURLfile(item.getUrl());
                pWMPF.setCurrentPosition(currentPosition);
                //pWMPF.mute();

                stars.set(int.Parse(item.label_puntuation.Text.ToString()));
                this.pStarts.Visible = true;

                this.label_name_video.Text = pWMPF.getNameVideo();
                this.label_views.Text = item.label_views.Text + " views";
                this.label_information.Text = item.label_year.Text;
                this.label_information.Text = item.label_description.Text;
            }
        }
        
        #region GETS AND SETS
        public PictureBox get_picture_Box_next()
        {
            return pictureBox_next;
        }
        public PictureBox get_pictureBox_play()
        {
            return pictureBox_play;
        }
        public PictureBox get_pictureBox_subtitle()
        {
            return pictureBox_subtitle;
        }
        public PictureBox get_pictureBox_expand()
        {
            return pictureBox_expand;
        }
        public PictureBox get_pictureBox_full()
        {
            return pictureBox_full;
        }
        public Label get_label_name_video()
        {
            return label_name_video;
        }
        public Label get_label_views()
        {
            return label_views;
        }
        public Label get_label_information()
        {
            return label_information;
        }
        public Panel get_panel_content()
        {
            return panel_content;
        }
        #endregion
        #region CONTROLS
        private void stars_Click(object sender, EventArgs e)
        {
            PictureBox a = (PictureBox)sender;
            if (stream.getChannel().getItemSelected()!=null)
            {
                stream.getChannel().getItemSelected().label_puntuation.Text = a.Tag.ToString();
                stream.getChannel().getItemSelected().saveInformation();
            }
        }
        //Player controls
        private void pictureBox_play_Click(object sender, EventArgs e)
        {
            playStop();
        }
        private void pictureBox_next_Click(object sender, EventArgs e)
        {
            nextVideo();
        }
        private void audio_dual_Click(object sender, EventArgs e)
        {
            audioDual();
        }
        private void pictureBox_subtitle_Click(object sender, EventArgs e)
        {
            subtitles();
        }
        private void pictureBox_expand_Click_1(object sender, EventArgs e)
        {
            extend();
        }
        public void resetButtons()
        {
            pictureBox_play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            pictureBox_next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            pictureBox_subtitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            pictureBox_expand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            pictureBox_full.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
        }
        public void playStop()
        {
            resetButtons();
            if (pWMPF.wmps_is_Playing())
            {
                pWMPF.stop();
            }
            else
            {
                pWMPF.play();
            }
        }
        void nextVideo()
        {
            resetButtons();
            //if (stream.channel.items.Count > 0)
            {
                /*if ((flowLayoutPanelItems.Controls.Count - 1) > menu_vertical_)
                    menu_vertical_++;
                else
                {
                    //cambiar al siguiente channel
                    //si es el ultimo regresar al primero

                    menu_vertical_ = 0;
                }
                change_videos_selected(menu_vertical_);*/
                //EasyPanels.ItemPlayer it = (EasyPanels.ItemPlayer)flowLayoutPanelItems.Controls[menu_vertical_];
                /*this.label_views.Text = it.pictureBox_cover.Tag.ToString().Split('|')[3];
                this.label_information.Text = it.pictureBox_cover.Tag.ToString().Split('|')[2];
                this.label_name_video.Text = it.pictureBox_cover.Tag.ToString().Split('|')[1];

                if (it.fileInfo != null)
                {
                    MessageBox.Show("it's movie! " + it.url);
                    pWMPF.playURLfile(it.fileInfo);
                }
                else {
                   
                    MessageBox.Show("it's serie! " + it.url);
                }*/
            }
        }
        public void audioDual()
        {
            //pWMPF.change_audio();
        }
        public void subtitles()
        {
            resetButtons();
            //pWMPF.set_subtitles();
        }
        public void extend()
        {
            resetButtons();
            if (panel_right.Visible)
                panel_right.Visible = false;
            else
                panel_right.Visible = true;
        }
        public void maximize()
        {
            resetButtons();
            if (Parent.FindForm().WindowState == FormWindowState.Normal)
            {
                Parent.FindForm().WindowState = FormWindowState.Maximized;
            }
            else
                Parent.FindForm().WindowState = FormWindowState.Normal;
        }
        #endregion
        public void openForm(object form)
        {
            Form fh = form as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;

            if (pWMPF.get_panel_menu().Controls.Count > 0)
                pWMPF.get_panel_menu().Controls.RemoveAt(0);
            if (fh.Equals(pWMPF))
            {
                this.panel_content.Controls.Add(fh);
                this.panel_content.Tag = fh;
            }
            else
            {

                pWMPF.get_panel_menu().Controls.Add(fh);
                pWMPF.get_panel_menu().Tag = fh;
                pWMPF.get_panel_menu().Visible = true;
            }

            fh.Show();
        }
    }
}
