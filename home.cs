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
        //NUMBER OF OPTIONS IN THE VIDEO_PLAYER
        int num_menus_options = 5;//PLAY, NEXT, SUBTITLE ...

        int scroll_indice = -1;
        int numer = 2;//items que se agregan en el escroll

        List<Channel> channels;
        private Item itemSelected = null;
        Channel channel;//chanel selected
        public pWMPF pWMPF;


        public Form_Home(pWMPF pWMPF)
        {
            InitializeComponent();
            this.flowLayoutPanelItems.MouseWheel += FlowLayoutPanel_MouseWheel;
            this.pWMPF = pWMPF;
            this.pWMPF.mute();
            this.openForm(pWMPF);

            stars = new EasyPanels.Starts();
            this.pStarts.Controls.Add(stars);

            foreach (PictureBox a in stars.Controls)
            {
                a.Click += stars_Click;
            }
        }
        int menu_horizontal_ = -1;//index of menu videos selected
        public int get_option(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up: // right arrow key
                    if (menu_horizontal_ >= num_menus_options)
                    {
                        if (channel.item_selected >= 0)
                            channel.item_selected -= 1;
                        change_video_selected(channel.item_selected);
                    }
                    return menu_horizontal_;

                case Keys.Down: // right arrow key
                    if (menu_horizontal_ >= num_menus_options)
                    {
                        if (channel.item_selected < flowLayoutPanelItems.Controls.Count - 1)
                            channel.item_selected += 1;
                        change_video_selected(channel.item_selected);
                    }
                    return menu_horizontal_;

                case Keys.Left: // left back
                    menu_horizontal_ -= 1;
                    if (menu_horizontal_ < (int)Methods.MenuOption.isOpen)
                        menu_horizontal_ = (int)Methods.MenuOption.isClose;

                    change_menu_channels(menu_horizontal_);
                    return menu_horizontal_;

                case Keys.Right: // next option
                    if (menu_horizontal_ == (int)Methods.MenuOption.isClose)//if menu is close
                        menu_horizontal_ = (int)Methods.MenuOption.isOpen;
                    //add one if menu_vertical options is less than channels and menu_options
                    if (menu_horizontal_ < ((flowLayoutPanelChannels.Controls.Count - 1) + num_menus_options))
                    {
                        menu_horizontal_ += 1;
                        change_menu_channels(menu_horizontal_);
                    }
                    return menu_horizontal_;

                case Keys.Enter:
                    if (menu_horizontal_ < num_menus_options)
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
                        if (flowLayoutPanelItems.Controls.Count > 0)
                            if (channel.item_selected > -1 && channel.item_selected <= flowLayoutPanelItems.Controls.Count - 1)
                            {
                                //Item it = (Item)flowLayoutPanelItems.Controls[channel.item_selected];
                                Item it = channel.items[channel.item_selected];
                                MessageBox.Show("Video Selected " + it.label_title.Text +"channel selected "+ channel.index_channel);
                                setVideo(it);
                            }
                            else {
                                //set the playing now
                                MessageBox.Show(channel.index_channel + "");
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
        public void setVideo(Item item)
        {
            if (item != null)
            {
                itemSelected = item;
                unselect_videos();
                itemSelected.isSelected(true);
                pWMPF.playURLfile(itemSelected.getUrl());
                pWMPF.mute();

                stars.set(int.Parse(itemSelected.label_puntuation.Text.ToString()));
                this.pStarts.Visible = true;

                this.label_name_video.Text = pWMPF.getNameVideo();
                this.label_views.Text = itemSelected.label_views.Text + " views";
                this.label_information.Text = itemSelected.label_year.Text;
                this.label_information.Text = itemSelected.label_description.Text;
            }
            else
                itemSelected = null;
        }
        private void Video_Click(object sender, EventArgs e)
        {
            Item item;
            string name = ((System.Windows.Forms.Control)sender).Name.ToString();
            if (name.Equals("picture_box_cover"))
            {
                PictureBox pictureBox = (PictureBox)((System.Windows.Forms.Control)sender);
                item = pictureBox.Parent as Item;
            }
            else
            {
                Label label = (Label)((System.Windows.Forms.Control)sender);
                Panel p = label.Parent as Panel;
                item = p.Parent as Item;
            }
            setVideo(item);
        }
        public void unselect_videos()
        {
            foreach (Control item in flowLayoutPanelItems.Controls)
            {
                Item it = (Item)item;
                it.isSelected(false);
            }
        }
        #region channels manager
        public void set_channels_list(List<Channel> channels_)
        {
            channels = channels_;
            init_flow_channels();
        }
        public void init_flow_channels()
        {
            foreach (Channel c in channels)
                c.Click -= Channel_Click;

            flowLayoutPanelChannels.Controls.Clear();
            foreach (Channel c in channels)
            {
                c.Click -= Channel_Click;
                c.Click += Channel_Click; 
                flowLayoutPanelChannels.Controls.Add(c);
            }
        }
        private void Channel_Click(object sender, EventArgs e)
        {
            channel = (Channel)sender;
            menu_horizontal_ = num_menus_options + channel.index_channel;
            change_menu_channels(menu_horizontal_);
        }
        private void change_menu_channels(int op)
        {
            //clear channels selected
            foreach (Control c in flowLayoutPanelChannels.Controls)
            {
                Channel button = (Channel)c;
                button.isSelected(false);
            }
            //clear bottons
            pictureBox_play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            pictureBox_next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            pictureBox_subtitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            pictureBox_expand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            pictureBox_full.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            //if is lower than options like: play, next subtitle, and maximize
            if (op < num_menus_options)
            {
                switch (op)
                {
                    case 0://play
                        pictureBox_play.BackColor = Color.White;
                        break;
                    case 1://next
                        pictureBox_next.BackColor = Color.White;
                        break;
                    case 2://subtitle
                        pictureBox_subtitle.BackColor = Color.White;
                        break;
                    case 3://expand
                        pictureBox_expand.BackColor = Color.White;
                        break;
                    case 4://full screen
                        pictureBox_full.BackColor = Color.White;
                        break;
                }
            }
            else
            {
                //menu channels
                if (op >= num_menus_options)
                {
                    channel = (Channel)flowLayoutPanelChannels.Controls[op - num_menus_options];
                    channel.isSelected(true);

                    flowLayoutPanelItems.Controls.Clear();
                    scroll_indice = -1;
                    //LOAD ALL VIDEOS
                    load_videos_from_channel(channel);
                    if (channel.item_selected >= 0 && channel.item_selected < flowLayoutPanelItems.Controls.Count)
                        this.flowLayoutPanelItems.VerticalScroll.Value = (this.flowLayoutPanelItems.VerticalScroll.Maximum / flowLayoutPanelItems.Controls.Count) * channel.item_selected;
                }
            }
        }
        #endregion
        public void load_videos_from_channel(Channel channel)
        {
            int cont = 0;
            foreach (Item f in channel.items)
            {
                if (cont > scroll_indice)
                {
                    f.label_title.Click -= Video_Click;
                    f.picture_box_cover.Click -= Video_Click;
                    f.label_title.Click += Video_Click;
                    f.picture_box_cover.Click += Video_Click;
                    flowLayoutPanelItems.Controls.Add(f);
                    if (cont == (scroll_indice + channel.item_selected + Methods.scroll_max))//scroll max how many items are loaded
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
        }
        //if is selected channels then we can change items
        public void change_video_selected(int index)
        {
            //change color of all items then selected the item that is playing now
            unselect_videos();
            //if menu horzotal is between 0 and flowLayoutPanel count
            if (index >= 0 && index < flowLayoutPanelItems.Controls.Count)
            {
                if (this.flowLayoutPanelItems.VerticalScroll.Value >= (this.flowLayoutPanelItems.VerticalScroll.Maximum - this.flowLayoutPanelItems.VerticalScroll.Maximum / numer))
                    load_videos_from_channel(((Channel)flowLayoutPanelChannels.Controls[menu_horizontal_ - num_menus_options]));
                this.flowLayoutPanelItems.VerticalScroll.Value = (this.flowLayoutPanelItems.VerticalScroll.Maximum / flowLayoutPanelItems.Controls.Count) * index;
                Item it = (Item)flowLayoutPanelItems.Controls[index];
                it.isSelected(true);
            }
        }
        private void FlowLayoutPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.flowLayoutPanelItems.VerticalScroll.Value >= (this.flowLayoutPanelItems.VerticalScroll.Maximum - this.flowLayoutPanelItems.VerticalScroll.Maximum / numer))
                load_videos_from_channel(((Channel)flowLayoutPanelChannels.Controls[menu_horizontal_ - num_menus_options]));
        }
        private void flowLayoutPanel_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.flowLayoutPanelItems.VerticalScroll.Value >= (this.flowLayoutPanelItems.VerticalScroll.Maximum - this.flowLayoutPanelItems.VerticalScroll.Maximum / numer))
                load_videos_from_channel(((Channel)flowLayoutPanelChannels.Controls[menu_horizontal_ - num_menus_options]));
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
        public FlowLayoutPanel get_flowLayoutPanel_category()
        {
            return flowLayoutPanelChannels;
        }
        public FlowLayoutPanel get_flowLayoutPanel_list()
        {
            return flowLayoutPanelItems;
        }
        #endregion
        #region CONTROLS
        private void stars_Click(object sender, EventArgs e)
        {
            PictureBox a = (PictureBox)sender;
            if (itemSelected!=null)
            {
                itemSelected.label_puntuation.Text = a.Tag.ToString();
                itemSelected.saveInformation();
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
            if (flowLayoutPanelItems.Controls.Count > 0)
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
