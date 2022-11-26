using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace YouSaw_0._3
{
    public class Channel: EasyPanels.ItemChannel
    {
        DirectoryInfo directory_nfo;
        //public List<Item> items = new List<Item>();
        private FlowLayoutPanel flowLayoutPanelItems = new FlowLayoutPanel();
        public int item_selected = -1;//item selected
        private int itemPlaying = -1;
        private int itemIndex = -1;//set an index to each one item
        public string path;
        public double timeStart = 0;//time of the channel
        public Channel(string path, string title, int index_channel) :base(title, index_channel)
        {
            InitializeComponent();
            this.path = path+"\\"+ title + ".txt";
            this.index_channel = index_channel;
            this.item_button(title, index_channel.ToString());
            setInformationChannel();
        }
        public void InitializeComponent()
        {
            // 
            // flowLayoutPanelItems
            // 
            /*this.flowLayoutPanelItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelItems.AutoScroll = true;
            //this.flowLayoutPanelItems.Location = new System.Drawing.Point(0, 34);
            this.flowLayoutPanelItems.Name = "flowLayoutPanelItems";
            this.flowLayoutPanelItems.Size = new System.Drawing.Size(366, 340);
            this.flowLayoutPanelItems.TabIndex = 3;
            this.flowLayoutPanelItems.BackColor = System.Drawing.Color.Bisque;
            this.flowLayoutPanelItems.MouseWheel += FlowLayoutPanel_MouseWheel;
            this.flowLayoutPanelItems.Scroll += flowLayoutPanel_Scroll;*/


            this.flowLayoutPanelItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelItems.AutoScroll = true;
            this.flowLayoutPanelItems.Location = new System.Drawing.Point(0, 34);
            this.flowLayoutPanelItems.Name = "flowLayoutPanelItems";
            //this.flowLayoutPanelItems.Size = new System.Drawing.Size(340, 376);
            this.flowLayoutPanelItems.TabIndex = 3;
            this.flowLayoutPanelItems.BackColor = System.Drawing.Color.Bisque;
            this.flowLayoutPanelItems.MouseWheel += FlowLayoutPanel_MouseWheel;
            this.flowLayoutPanelItems.Scroll += flowLayoutPanel_Scroll;
        }
        private void FlowLayoutPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            //if (this.flowLayoutPanelItems.VerticalScroll.Value >= (this.flowLayoutPanelItems.VerticalScroll.Maximum - this.flowLayoutPanelItems.VerticalScroll.Maximum / numer))
            //    load_videos_from_channel(((Channel)flowLayoutPanelChannels.Controls[menu_horizontal_ - num_menus_options]));
        }
        private void flowLayoutPanel_Scroll(object sender, ScrollEventArgs e)
        {
            //if (this.flowLayoutPanelItems.VerticalScroll.Value >= (this.flowLayoutPanelItems.VerticalScroll.Maximum - this.flowLayoutPanelItems.VerticalScroll.Maximum / numer))
            //    load_videos_from_channel(((Channel)flowLayoutPanelChannels.Controls[menu_horizontal_ - num_menus_options]));
        }

        public Item calculateItem()
        {
            itemPlaying++;
            if (itemPlaying > getItemsCount() - 1)
                itemPlaying = 0;
            return (Item)getItems()[itemPlaying];
            //si existe un anterior y es una serie
            //serie.episode_index++;
            //si random(3) reproducir la misma serie
            //si no itemplaying ++



            /*if (itemPlaying == -1)
            {
                itemPlaying++;
                if (itemPlaying > getItemsCount() - 1)
                    itemPlaying = 0;
                return (Item)getItems()[itemPlaying];
            }
            else {
                if (((Item)getItems()[itemPlaying]).fileInfo == null)
                {
                    //it was serie

                }
                else { 
                    //it was movie

                }
            }*/
        }
        public double playing_now_time_elapsed()
        {
            return Methods.timeNow() - timeStart;
        }
        public void setInformationChannel()
        {
            if (File.Exists(this.path))
            {
                using (var readtext = new StreamReader(path))
                {
                    string readText = readtext.ReadLine();
                    item_selected = int.Parse(readText);
                }
            }
            else
            {
                using (var writetext = new StreamWriter(path))
                {
                    writetext.WriteLine("" + item_selected);
                }
            }
        }
        public ControlCollection getItems()
        {
            return flowLayoutPanelItems.Controls;
        }
        public int getItemsCount() 
        {
            return flowLayoutPanelItems.Controls.Count;
        }
        public FlowLayoutPanel getFlowItems()
        {
            return this.flowLayoutPanelItems;
        }
        public void changeItem()
        {
            //change color of all items then selected the item that is playing now
            unselect_videos();
            //if menu horzotal is between 0 and flowLayoutPanel count
            if (item_selected >= 0 && item_selected < getItemsCount())
            {
                if (this.flowLayoutPanelItems.VerticalScroll.Value >= (this.flowLayoutPanelItems.VerticalScroll.Maximum - this.flowLayoutPanelItems.VerticalScroll.Maximum / numer))
                     loadItems();
                 this.flowLayoutPanelItems.VerticalScroll.Value = (this.flowLayoutPanelItems.VerticalScroll.Maximum / flowLayoutPanelItems.Controls.Count) * item_selected;
                Item it = (Item)flowLayoutPanelItems.Controls[item_selected];
                it.Focus();
                it.isSelected(true);
            }
        }
        public void unselect_videos()
        {
            foreach (Item it in getItems())
            {
                it.isSelected(false);
            }
        }
        int scroll_indice = -1;
        int numer = 2;//items que se agregan en el escroll
        public void loadItems()
        {
            int cont = 0;
            foreach (Item f in getItems())
            {
                if (cont > scroll_indice)
                {
                    f.label_title.Click -= Video_Click;
                    f.picture_box_cover.Click -= Video_Click;
                    f.label_title.Click += Video_Click;
                    f.picture_box_cover.Click += Video_Click;
                    flowLayoutPanelItems.Controls.Add(f);
                    if (cont == (scroll_indice + item_selected + Methods.scroll_max))//scroll max how many items are loaded
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
        private void Video_Click(object sender, EventArgs e)
        {
            Item item;
            string name = ((System.Windows.Forms.Control)sender).Name.ToString();
            if (name.Equals("picture_box_cover"))
            {
                PictureBox pictureBox = (PictureBox)((System.Windows.Forms.Control)sender);
                item = pictureBox.Parent as Item;
                item.Focus();
                item_selected = item.index_item;
            }
            else
            {
                Label label = (Label)((System.Windows.Forms.Control)sender);
                Panel p = label.Parent as Panel;
                item = p.Parent as Item;
                item.Focus();
                item_selected = item.index_item;
            }
            
            //this.Parent;
            //this.form_Home.setVideo(item, 0);
        }
        public Item getItemSelected()
        {
            if (item_selected == -1)
                return null;
            else
                return (Item)getItems()[item_selected];
        }
        public Item getItemPlayingNow()
        {
            if (itemPlaying == -1)
                return null;
            else
                return (Item)getItems()[itemPlaying];
        }public double getDurationPlayingNow()
        {
            if (itemPlaying == -1)
                return 0;
            else
                return Methods.getDuration(((Item)getItems()[itemPlaying]).getUrlPlaying().FullName);
        }
        public int add_series(string root)
        {
            try
            {
                string[] directories_ = Directory.GetDirectories(root);
                foreach (string directory in directories_)
                {
                    flowLayoutPanelItems.Controls.Add(new Item(directory,"","",++itemIndex));
                }
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(" Error en de ubicacion " + "" + e);
            }
           
            return 0;
        }
        public void add_movies(string directory)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(directory))
                {
                    add_movies(d);
                }
                get_files(directory);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(" Error en de ubicacion " + "" + e);
            }
        }
        private void get_files(string directory)
        {
            directory_nfo = new DirectoryInfo(@directory);
            FileInfo[] Files = directory_nfo.GetFiles();

            foreach (FileInfo file in Files)
            {
                string extencion = file.Extension;
                if (Methods.videos_extention.Contains(extencion))
                {
                    flowLayoutPanelItems.Controls.Add(new Item(file,++itemIndex));
                }
            }
            return;
        }
        public void reorder_items()
        {
            /*flowLayoutPanelItems.Controls.Sort(
                delegate (Item p1, Item p2)
                {
                    return p1.label_views.Text.CompareTo(p2.label_views.Text);
                }
            );*/
        }
    }
    public class Item: EasyPanels.ItemVideo
    {
        public Serie serie;
        public string pathFile;
        public Item(FileInfo file, int index_item) : base(file,index_item)
        {
            pathFile = this.fileInfo.FullName.Remove(this.fileInfo.FullName.Length - this.fileInfo.FullName.Split('.')[this.fileInfo.FullName.Split('.').Length - 1].Length) + "txt";
            setInformationFile(pathFile);
        }
        public Item(string url, string title, string duration, int index_item) :base(url, title, duration,index_item)
        {
            serie = new Serie(url);
            this.label_title.Text = serie.name;
            this.label_duration.Text = "Seasons:" + serie.seasons.Count.ToString();
            pathFile = url + "\\" + serie.name + ".txt";
            setInformationFile(pathFile);
        }
        public FileInfo getUrl()
        {
            if (this.fileInfo != null)
            {
                return fileInfo;
            }
            else {
                saveInformationItem(pathFile);
                
                return serie.getUrl();
            }
        }
        public FileInfo getUrlPlaying()
        {
            if (this.fileInfo != null)
            {
                return fileInfo;
            }
            else
            {
                return serie.getUrlPlaying();
            }
        }
        public double getDuration()
        {
            if(this.fileInfo != null)
            {
                return Methods.getDuration(fileInfo.FullName);
            }
            else
            {
                return Methods.getDuration(serie.getUrlPlaying().FullName);
            }
        }
        public void save_views()
        {
            if(this.fileInfo == null)
            {
                

            }
            else
            {
                int i = int.Parse(this.label_views.Text) + 1;
                this.label_views.Text = i.ToString();
            }
            saveInformation();
        }
        private void saveInformationItem(string path)
        {
            using (var writetext = new StreamWriter(path))
            {
                if (this.fileInfo == null)
                    writetext.WriteLine(this.label_views.Text + "-" + this.label_puntuation.Text + "-" + this.label_year.Text + "-" + this.serie.season_index+"-"+this.serie.episode_index+"-"+ this.label_description.Text);
                else
                    writetext.WriteLine(this.label_views.Text + "-" + this.label_puntuation.Text + "-" + this.label_year.Text + "-" + this.label_description.Text);
            }
        }
        private void setInformationFile(string path)
        {
            if (File.Exists(path))
            using (var readtext = new StreamReader(path))
            {
                    string readText = readtext.ReadLine();
                    this.label_views.Text = readText.Split('-')[0];
                    this.label_puntuation.Text = readText.Split('-')[1];
                    this.label_year.Text = readText.Split('-')[2];

                    if (this.fileInfo == null) {
                        this.serie.season_index = int.Parse(readText.Split('-')[3]);
                        this.serie.episode_index = int.Parse(readText.Split('-')[4]);
                        
                        this.label_description.Text = readText.Split('-')[5];
                    }
                    else
                    {
                        this.label_description.Text = readText.Split('-')[3];
                    }
            }
        }

        public void saveInformation()
        {
            if (File.Exists(pathFile))
            {
                //setInformationFile(pathFile);
            }
            else
            {
                saveInformationItem(pathFile);
            }
        }
    }
    public class Serie
    {
        public string name;
        public string root;
        public int season_index=0;
        public int episode_index=-1;
        public List<Season> seasons = new List<Season>();
        public FileInfo playingNow;
        public Serie(string root)
        {
            this.root = root;
            this.name = root.Split('\\')[root.Split('\\').Length - 1];
            add_seasons(root);
        }
        public FileInfo getUrl()
        {
            //MessageBox.Show(" - "+this.episode_index +">"+(seasons[season_index].files.Count - 1));
            episode_index++;
            if (episode_index > seasons[season_index].files.Count-1) {
                episode_index = 0;
                season_index++;
                if (season_index > seasons.Count-1)
                {
                    episode_index=0;
                    season_index = 0;
                }
            }
            playingNow = seasons[season_index].files[episode_index].file;
            return playingNow;
        }
        public FileInfo getUrlPlaying()
        {
            playingNow = seasons[season_index].files[episode_index].file;
            return playingNow;
        }
        public void add_seasons(string root)
        {
            try
            {
                string[] directories_ = Directory.GetDirectories(root);
                foreach (string directory in directories_)
                {
                    seasons.Add(new Season(directory));
                }
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(" Error en de ubicacion " + "" + e);
            }
        }
        public class Season
        {
            public List<Video> files = new List<Video>();
            private DirectoryInfo directory_nfo;
            public string name;
            public Season(string root)
            {
                this.name = root.Split('\\')[root.Split('\\').Length - 1];
                addEpisodes(root);
            }
            public void addEpisodes(string directory)
            {
                try
                {
                    foreach (string d in Directory.GetDirectories(directory))
                    {
                        addEpisodes(d);
                    }
                    get_files(directory);
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(" Error en de ubicacion " + "" + e);
                }
            }
            private void get_files(string directory)
            {
                directory_nfo = new DirectoryInfo(@directory);
                FileInfo[] Files = directory_nfo.GetFiles();
                foreach (FileInfo file in Files)
                {
                    string extencion = file.Extension;
                    if (Methods.videos_extention.Contains(extencion))
                    {
                        files.Add(new Video(file));
                    }
                }
                return;
            }
        }
    }
    public class Video 
    {
        public FileInfo file;
        public Video(FileInfo file)
        {
            this.file = file;
            setDuration();
        }
        public void setSubtitles() { }
        public void setDuration()
        {
            //this.label_duration.Text = Methods.getDurationString(url);
        }
        public void setViews() { }
        
    }
}
