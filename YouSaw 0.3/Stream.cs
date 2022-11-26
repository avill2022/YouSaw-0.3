using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouSaw_0._3
{
    public class Stream :Panel
    {
        public Form1 form1 = null;
        public Form_Home form_Home = null;
        public Form_Search form_Search = null;


        

        //private Item itemSelected = null;
        public Channel channel;//chanel selected
        public int idChannel = 0;

        public FlowLayoutPanel flowLayoutPanelChannels = new FlowLayoutPanel();
        private Panel panelContent=new Panel();
        

        public void InitializeComponent()
        {
            // 
            // panel_list
            // 
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.flowLayoutPanelChannels);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "this";
            this.Size = new System.Drawing.Size(340, 376);
            this.TabIndex = 1;
            // 
            // flowLayoutPanelChannels
            // 
            this.flowLayoutPanelChannels.AutoScroll = true;
            this.flowLayoutPanelChannels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            //this.flowLayoutPanelChannels.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelChannels.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelChannels.Name = "flowLayoutPanelChannels";
            this.flowLayoutPanelChannels.Size = new System.Drawing.Size(340, 50);
            this.flowLayoutPanelChannels.TabIndex = 1;
            this.flowLayoutPanelChannels.WrapContents = false;
            // 
            // flowLayoutPanelItems
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.AutoScroll = true;
            this.panelContent.Location = new System.Drawing.Point(0, 55);
            this.panelContent.Name = "flowLayoutPanelItems";
            this.panelContent.BackColor = System.Drawing.Color.Aqua;
            this.panelContent.Size = new System.Drawing.Size(340, 340);
            this.panelContent.TabIndex = 2;
        }
        public Stream()
        {
            InitializeComponent();
            sann_folder();
        }
        #region directorios
        public int sann_folder()
        {
            try
            {
                string[] directories = Directory.GetDirectories(".\\");
                foreach (string d in directories)
                {
                    sann_folder(d);
                }
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(" Error en de ubicacion " + "" + e);
            }
            return 0;
        }
        public int sann_folder(string root)
        {
            try
            {
                string[] directories_ = Directory.GetDirectories(root);
                foreach (string directory in directories_)
                {
                    if (directory.Contains(".\\movies"))
                        getChannel(directory, directory.Split('\\')[directory.Split('\\').Length - 1]).add_movies(directory);
                    else
                    if (directory.Contains(".\\series"))
                        getChannel(directory, directory.Split('\\')[directory.Split('\\').Length - 1]).add_series(directory);
                    //if (directory.Contains(".\\music"))
                }
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(" Error en de ubicacion " + "" + e);
            }
            return 0;
        }
        public Channel getChannel(string path, string name_channel)
        {
            foreach (Channel c in this.flowLayoutPanelChannels.Controls)
            {
                if (c.Name.Equals(name_channel))
                {
                    return c;
                }
            }
            Channel channel = new Channel(path, name_channel, this.flowLayoutPanelChannels.Controls.Count);
            channel.Click += Channel_Click;
            flowLayoutPanelChannels.Controls.Add(channel);
            return channel;
        }
        #endregion


        public void clearChannelSelected()
        {
            //clear channels selected
            foreach (Channel c in this.flowLayoutPanelChannels.Controls)
                c.isSelected(false);
        }
        public Channel getChannel()
        {
            
            if (this.flowLayoutPanelChannels.Controls.Count != 0)
                if (this.flowLayoutPanelChannels.Controls.Count > idChannel)
                    //this.flowLayoutPanelChannels.Controls[idChannel].Focus();
                    return (Channel)this.flowLayoutPanelChannels.Controls[idChannel];
            return null;
        }
        public ControlCollection getChannels()
        {
            return this.flowLayoutPanelChannels.Controls;
        }
        public void changeChanel(int ch,bool scroll = true)
        {
            idChannel = ch;
            clearChannelSelected();
            channel = getChannel();
            if (channel != null)
            {
                panelContent.Controls.Clear();
                panelContent.Controls.Add(channel.getFlowItems());
                channel.Focus();
                if (scroll) {

                    if (idChannel >= getChannels().Count - 1)
                    {
                        this.flowLayoutPanelChannels.HorizontalScroll.Value = this.flowLayoutPanelChannels.HorizontalScroll.Maximum;
                        //MessageBox.Show(idChannel + " " + getChannels().Count);
                    }
                    /*if (idChannel == 0)
                        this.flowLayoutPanelChannels.HorizontalScroll.Value = 0;
                    else
                        this.flowLayoutPanelChannels.HorizontalScroll.Value = (this.flowLayoutPanelChannels.HorizontalScroll.Maximum / flowLayoutPanelChannels.Controls.Count) * idChannel;
                */}
                channel.isSelected(true);
                setChannel();
                
                //setChannel();

                // scroll_indice = -1;

                //

                //if (channel.item_selected >= 0 && channel.item_selected < flowLayoutPanelItems.Controls.Count)
                //    this.flowLayoutPanelItems.VerticalScroll.Value = (this.flowLayoutPanelItems.VerticalScroll.Maximum / flowLayoutPanelItems.Controls.Count) * channel.item_selected;
            }
        }
        public void setChannel()
        {
            if (getChannel() != null && getChannel().getItemsCount() > 0)
            {
                if (getChannel().getItemPlayingNow() == null)
                {
                    getChannel().calculateItem();
                    getChannel().timeStart = Methods.timeNow();
                    form_Home.setVideo(getChannel().getItemPlayingNow(), getChannel().playing_now_time_elapsed());
                    getChannel().unselect_videos();
                    //MessageBox.Show("Video Calculado: time now: " + Methods.getTimeLabel(getChannel().timeStart) + "\n end: " + Methods.getTimeLabel(getChannel().getItemPlayingNow().getDuration() + getChannel().timeStart));
                }

                if ((getChannel().getItemPlayingNow().getDuration() + getChannel().timeStart) <= Methods.timeNow())
                {
                    calculateVideoChannel();
                }
                //getChannel().getItemPlayingNow().isSelected(true)   
            }
        }
        public void calculateVideoChannel()
        {
            getChannel().calculateItem();
            double dif = getChannel().timeStart + getChannel().getDurationPlayingNow() - Methods.timeNow();
            if (dif < 15)
            {
                getChannel().timeStart = Methods.timeNow();
            }
            else
            {
                if (dif < (getChannel().getDurationPlayingNow() / 3))
                {
                    getChannel().timeStart = Methods.timeNow() + Methods.getRandom(15, (int)(getChannel().getDurationPlayingNow() / 3));
                }
                else
                {
                    getChannel().timeStart = Methods.timeNow() + Methods.getRandom(15, (int)(getChannel().getDurationPlayingNow() / 2));
                }
            }
            //MessageBox.Show("Calculado calculateVideoChannel");
            form_Home.setVideo(getChannel().getItemPlayingNow(), getChannel().playing_now_time_elapsed());
            getChannel().unselect_videos();
        }

        private void Channel_Click(object sender, EventArgs e)
        {
            channel = (Channel)sender;
            form_Home.menu_horizontal_ = channel.index_channel+ Methods.MenuOptions;
            changeChanel(channel.index_channel,false);
        }
       
    }
}
