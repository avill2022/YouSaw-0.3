using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouSaw_0._3
{
    public class EasyPanels
    {
        public string DISK = "F";
        //Color Primario
        private Color primary = System.Drawing.Color.FromArgb(31, 31, 31);
        //Color Secundario
        private Color secondary = Color.FromArgb(214, 119, 10);
        //Color terseario
        private Color back_color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));

        //font color
        private Color fontColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        //Font titulo
        System.Drawing.Font font_ = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public EasyPanels() { 
        
        }
        public Panel item_panel(string tag, string title,string subtitle1,string subtitle2, Size size)
        {
            Panel panel_item = new Panel();
            Panel panel_titles = new Panel();
            PictureBox pictureBox_img = new PictureBox();
            Label label_subtitle = new Label();
            Label label_title1 = new Label();
            Label label_title = new Label();

            // 
            // panel_item
            // 
            panel_item.Controls.Add(panel_titles);
            panel_item.Controls.Add(pictureBox_img);
            //panel_item.Location = new System.Drawing.Point(415, 202);
            panel_item.Name = "panel_item";
            panel_item.Size = size;
            panel_item.TabIndex = 6;
            // 
            // panel12
            // 
            panel_titles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            panel_titles.Controls.Add(label_subtitle);
            panel_titles.Controls.Add(label_title1);
            panel_titles.Controls.Add(label_title);
            panel_titles.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel_titles.Location = new System.Drawing.Point(0, 104);
            panel_titles.Name = subtitle2;
            panel_titles.Size = new System.Drawing.Size(200, 89);
            panel_titles.TabIndex = 1;
            // 
            // label_subtitle
            // 
            label_subtitle.ForeColor = System.Drawing.Color.Silver;
            label_subtitle.Location = new System.Drawing.Point(4, 65);
            label_subtitle.Name = "label_subtitle";
            label_subtitle.Size = new System.Drawing.Size(193, 24);
            label_subtitle.TabIndex = 2;
            label_subtitle.Text = subtitle2;
            // 
            // label_title1
            // 
            label_title1.ForeColor = System.Drawing.Color.Silver;
            label_title1.Location = new System.Drawing.Point(4, 47);
            label_title1.Name = "label_title1";
            label_title1.Size = new System.Drawing.Size(196, 18);
            label_title1.TabIndex = 1;
            label_title1.Text = subtitle1;
            // 
            // label_title
            // 
            label_title.Dock = System.Windows.Forms.DockStyle.Top;
            label_title.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_title.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label_title.Location = new System.Drawing.Point(0, 0);
            label_title.Name = "label_title";
            label_title.Size = new System.Drawing.Size(200, 49);
            label_title.TabIndex = 0;
            label_title.Text = title;
            // 
            // pictureBox_img
            // 
            pictureBox_img.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            pictureBox_img.Dock = System.Windows.Forms.DockStyle.Fill;
            //image_set(pictureBox_img, @"_img\portada.jpg");
            pictureBox_img.Location = new System.Drawing.Point(0, 0);
            pictureBox_img.Name = "pictureBox_img";
            //pictureBox_img.Size = new System.Drawing.Size(200, 193);
            pictureBox_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox_img.TabIndex = 0;
            pictureBox_img.TabStop = false;

            panel_item.Controls.Add(panel_titles);
            return panel_item;
        }
        public Panel item_small_panel(string tag, string title, string subtitle1, string duration, string visitas)
        {
            Panel panel4 = new System.Windows.Forms.Panel();
            Label label_duration = new System.Windows.Forms.Label();
            Panel panel5 = new System.Windows.Forms.Panel();
            Label label_info_2 = new System.Windows.Forms.Label();
            Label label_info = new System.Windows.Forms.Label();
            Label label_name = new System.Windows.Forms.Label();
            PictureBox pictureBox_cover = new System.Windows.Forms.PictureBox();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox_cover)).BeginInit();

            // 
            // panel4
            // 
            panel4.Controls.Add(label_duration);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(pictureBox_cover);
            panel4.Location = new System.Drawing.Point(12, 12);
            panel4.Name = "panel4";
            panel4.Tag = tag;
            panel4.Size = new System.Drawing.Size(334, 110);
            panel4.TabIndex = 1;
            panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            // 
            // label_duration
            // 
            label_duration.AutoSize = true;
            label_duration.ForeColor = System.Drawing.SystemColors.ButtonFace;
            label_duration.Location = new System.Drawing.Point(110, 90);
            label_duration.Name = "label_duration";
            label_duration.Size = new System.Drawing.Size(43, 13);
            label_duration.TabIndex = 0;
            label_duration.Text =duration;
            // 
            // panel5
            // 
            panel5.Controls.Add(label_info_2);
            panel5.Controls.Add(label_info);
            panel5.Controls.Add(label_name);
            panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            panel5.Location = new System.Drawing.Point(159, 0);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(175, 110);
            panel5.TabIndex = 1;
            // 
            // label_info_2
            // 
            label_info_2.Dock = System.Windows.Forms.DockStyle.Top;
            label_info_2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_info_2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            label_info_2.Location = new System.Drawing.Point(0, 90);
            label_info_2.Name = "label_info_2";
            label_info_2.Size = new System.Drawing.Size(175, 19);
            label_info_2.TabIndex = 3;
            label_info_2.Text = visitas;
            // 
            // label_info
            // 
            label_info.Dock = System.Windows.Forms.DockStyle.Top;
            label_info.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_info.ForeColor = System.Drawing.SystemColors.ControlDark;
            label_info.Location = new System.Drawing.Point(0, 49);
            label_info.Name = "label_info";
            label_info.Size = new System.Drawing.Size(175, 41);
            label_info.TabIndex = 2;
            label_info.Text = subtitle1;
            // 
            // label_name
            // 
            label_name.Dock = System.Windows.Forms.DockStyle.Top;
            label_name.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label_name.Location = new System.Drawing.Point(0, 0);
            label_name.Name = "label_name";
            label_name.Size = new System.Drawing.Size(175, 49);
            label_name.TabIndex = 1;
            label_name.Text = title;
            // 
            // pictureBox_cover
            // 
            pictureBox_cover.Dock = System.Windows.Forms.DockStyle.Left;
            pictureBox_cover.Location = new System.Drawing.Point(0, 0);
            pictureBox_cover.Name = "pictureBox_cover";
            pictureBox_cover.Size = new System.Drawing.Size(159, 110);
            pictureBox_cover.TabIndex = 0;
            pictureBox_cover.TabStop = false;

            return panel4;
        }
        public void image_set(PictureBox panelImagen,string image)
        {
            if (image != null)
            {
                try
                {
                    try
                    {
                        try
                        {
                            //System.IO.FileStream fs = new System.IO.FileStream(image, FileMode.Open);
                            // panelImagen.Image = Image.FromStream(fs);@"_channels\" + channel.getIdChannel() + ".png"
                            panelImagen.Image = Image.FromFile(image);
                        }
                        catch (System.OutOfMemoryException e)
                        {
                            Console.WriteLine(e);

                            panelImagen.Image = Image.FromFile(@"_img\portada.jpg");

                        }
                    }
                    catch (System.IO.DirectoryNotFoundException)
                    {

                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                    panelImagen.Image = Image.FromFile(@"_img\portada.jpg");
                }
            }
            else
            {
                panelImagen.Image = Image.FromFile(@"_img\portada.jpg");
            }
        }
        public class Starts : FlowLayoutPanel
        {
            List<PictureBox> estrella_colection = new List<PictureBox>();
            public Starts()
            {
                for (int i = 0; i < 5; i++)
                {
                    estrella_colection.Add(estrella(i));
                    this.Controls.Add(estrella_colection[i]);
                }

                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "flowLayoutPanel1";
                this.Size = new System.Drawing.Size(123, 27);
                this.TabIndex = 41;
            }
            public void set(int n)
            {
                foreach (PictureBox p in estrella_colection)
                {
                    if (n > 0)
                        p.Image = Image.FromFile(start_selected);
                    else
                        p.Image = Image.FromFile(start_unselected);
                    n -= 1;
                }
            }
            public string start_unselected = @"image\star_26px.png";
            public string start_selected = @"image\star_select_24px.png";
            public PictureBox estrella(int i)
            {
                // 
                // p1
                // 
                System.Windows.Forms.PictureBox star = new PictureBox();
                star.Size = new Size(18, 19);
                //star.Location = new Point(0 + i * 20, 0);
                star.Location = new System.Drawing.Point(3, 3);
                star.Image = Image.FromFile(start_unselected);
                star.SizeMode = PictureBoxSizeMode.Zoom;
                star.Tag = i + 1;
                star.Name = i.ToString();
                star.TabIndex = i;
                star.TabStop = false;
                star.MouseClick += Star_MouseClick; ;
                return star;
            }
            public void setpuntuacion(int puntuacion)
            {
                PictureBox p = null;
                foreach (Control c in this.Controls)
                {
                    try
                    {
                        p = (PictureBox)c;
                        this.Tag = puntuacion.ToString();
                        p.Image = Image.FromFile(start_unselected);
                    }
                    catch (System.IO.FileNotFoundException)
                    {

                    }
                }
                for (int i = 0; i < puntuacion; i++)
                {
                    try
                    {
                        this.Tag = puntuacion.ToString();
                        p = (PictureBox)this.Controls[i];
                        p.Image = Image.FromFile(start_selected);
                    }
                    catch (System.IO.FileNotFoundException)
                    {

                    }
                }
                this.Name = puntuacion.ToString();
            }
            private void Star_MouseClick(object sender, MouseEventArgs e)
            {
                setpuntuacion(int.Parse(((System.Windows.Forms.Control)sender).Tag.ToString()));
            }
        }
        public class ItemChannel: Button
        {
            private Color back_color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            System.Drawing.Font font_ = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            public int index_channel = 0;
            public ItemChannel(string title, int index_channel)
            {
                this.index_channel = index_channel;
                item_button(title, index_channel.ToString());
            }
            public void isSelected(bool isSelected)
            {
                if (isSelected)
                {
                    this.BackColor = Color.White;
                    this.ForeColor = Color.Black;
                }
                else {
                    this.ForeColor = Color.White;
                    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                }
            }
            public void item_button(string title, string tag)
            {
                //Button item_button = new Button();
                this.BackColor = back_color;
                this.FlatAppearance.BorderSize = 0;
                this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.Font = font_;
                this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.Location = new System.Drawing.Point(3, 3);
                this.Name = title;
                this.Size = new System.Drawing.Size(68, 28);
                this.TabIndex = 6;
                this.Text = title;
                this.Tag = tag;
                this.UseVisualStyleBackColor = false;
                //item_button.Click += new System.EventHandler(item_button_Click);
                //return item_button;
            }
        }
        public class ItemVideo : Panel
        {
            public Label label_title = new System.Windows.Forms.Label();
            public Label label_duration = new System.Windows.Forms.Label();
            public Label label_views = new System.Windows.Forms.Label();
            public Panel panel_content = new System.Windows.Forms.Panel();
            public Label label_year = new System.Windows.Forms.Label();
            public Label label_description = new System.Windows.Forms.Label();
            public Label label_puntuation = new System.Windows.Forms.Label();
            public PictureBox picture_box_cover = new System.Windows.Forms.PictureBox();
            public FileInfo fileInfo;
            public int index_item = -1;
            public ItemVideo(FileInfo fileInfo,int index_item)
            {
                this.label_description.Text = " ";
                this.label_year.Text = " ";
                this.label_puntuation.Text = "0";

                this.index_item = index_item;
                this.fileInfo = fileInfo;
                panel_content.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(picture_box_cover)).BeginInit();
                // 
                // this_panel
                // 
                this.SuspendLayout();
                this.Controls.Add(label_duration);
                this.Controls.Add(panel_content);
                this.Controls.Add(picture_box_cover);
                this.Location = new System.Drawing.Point(12, 12);
                this.Name = "this_panel";
                this.Size = new System.Drawing.Size(334, 110);
                this.TabIndex = 1;
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                // 
                // label_duration
                // 
                label_duration.AutoSize = true;
                label_duration.ForeColor = System.Drawing.SystemColors.ButtonFace;
                label_duration.Location = new System.Drawing.Point(110, 90);
                label_duration.Name = "label_duration";
                label_duration.Size = new System.Drawing.Size(43, 13);
                label_duration.TabIndex = 0;
                label_duration.Text = Methods.getDurationString(fileInfo.FullName);
                // 
                // panel_content
                // 
                panel_content.Controls.Add(label_views);
                panel_content.Controls.Add(label_year);
                panel_content.Controls.Add(label_title);
                panel_content.Dock = System.Windows.Forms.DockStyle.Fill;
                panel_content.Location = new System.Drawing.Point(159, 0);
                panel_content.Name = "panel_content";
                panel_content.Size = new System.Drawing.Size(175, 110);
                panel_content.TabIndex = 1;
                // 
                // label_views
                // 
                label_views.Dock = System.Windows.Forms.DockStyle.Top;
                label_views.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label_views.ForeColor = System.Drawing.SystemColors.AppWorkspace;
                label_views.Location = new System.Drawing.Point(0, 90);
                label_views.Name = "label_views";
                label_views.Size = new System.Drawing.Size(175, 19);
                label_views.TabIndex = 3;
                label_views.Text =""+ Methods.getViews(fileInfo.FullName);
                // 
                // label_year
                // 
                label_year.Dock = System.Windows.Forms.DockStyle.Top;
                label_year.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label_year.ForeColor = System.Drawing.SystemColors.ControlDark;
                label_year.Location = new System.Drawing.Point(0, 49);
                label_year.Name = "label_year";
                label_year.Size = new System.Drawing.Size(175, 41);
                label_year.TabIndex = 2;
                // 
                // label_title
                // 
                label_title.Dock = System.Windows.Forms.DockStyle.Top;
                label_title.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label_title.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
                label_title.Location = new System.Drawing.Point(0, 0);
                label_title.Name = "label_title";
                label_title.Size = new System.Drawing.Size(175, 49);
                label_title.TabIndex = 1;
                label_title.Text = fileInfo.Name;
                // 
                // picture_box_cover
                // 
                picture_box_cover.Dock = System.Windows.Forms.DockStyle.Left;
                picture_box_cover.Location = new System.Drawing.Point(0, 0);
                picture_box_cover.Size = new System.Drawing.Size(159, 110);
                picture_box_cover.TabIndex = 0;
                picture_box_cover.Name = "picture_box_cover";
                picture_box_cover.TabStop = false;
                setImagen(fileInfo.FullName, picture_box_cover);
            }
            public ItemVideo(string url, string title, string duration, int index_item)
            {
                this.label_description.Text = " ";
                this.label_year.Text = " ";
                this.label_puntuation.Text = "0";

                this.index_item = index_item;
                panel_content.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(picture_box_cover)).BeginInit();
                // 
                // panel_this
                // 
                this.SuspendLayout();
                this.Controls.Add(label_duration);
                this.Controls.Add(panel_content);
                this.Controls.Add(picture_box_cover);
                this.Name = "panel_this";
                this.Location = new System.Drawing.Point(12, 12);
                this.Size = new System.Drawing.Size(334, 110);
                this.TabIndex = 1;
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                // 
                // label_duration
                // 
                label_duration.AutoSize = true;
                label_duration.ForeColor = System.Drawing.SystemColors.ButtonFace;
                label_duration.Location = new System.Drawing.Point(110, 90);
                label_duration.Name = "label_duration";
                label_duration.Size = new System.Drawing.Size(43, 13);
                label_duration.TabIndex = 0;
                label_duration.Text = duration;
                // 
                // panel_content
                // 
                panel_content.Controls.Add(label_views);
                panel_content.Controls.Add(label_year);
                panel_content.Controls.Add(label_title);
                panel_content.Dock = System.Windows.Forms.DockStyle.Fill;
                panel_content.Location = new System.Drawing.Point(159, 0);
                panel_content.Name = "panel_content";
                panel_content.Size = new System.Drawing.Size(175, 110);
                panel_content.TabIndex = 1;
                // 
                // label_views
                // 
                label_views.Dock = System.Windows.Forms.DockStyle.Top;
                label_views.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label_views.ForeColor = System.Drawing.SystemColors.AppWorkspace;
                label_views.Location = new System.Drawing.Point(0, 90);
                label_views.Name = "label_views";
                label_views.Size = new System.Drawing.Size(175, 19);
                label_views.TabIndex = 3;
                label_views.Text = Methods.getViews(url + "\\" + title + ".txt").ToString();
                // 
                // label_year
                // 
                label_year.Dock = System.Windows.Forms.DockStyle.Top;
                label_year.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label_year.ForeColor = System.Drawing.SystemColors.ControlDark;
                label_year.Location = new System.Drawing.Point(0, 49);
                label_year.Name = "label_year";
                label_year.Size = new System.Drawing.Size(175, 41);
                label_year.TabIndex = 2;
                // 
                // label_title
                // 
                label_title.Dock = System.Windows.Forms.DockStyle.Top;
                label_title.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label_title.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
                label_title.Location = new System.Drawing.Point(0, 0);
                label_title.Name = "label_title";
                label_title.Size = new System.Drawing.Size(175, 49);
                label_title.TabIndex = 1;
                label_title.Text = title;
                // 
                // picture_box_cover
                // 
                picture_box_cover.Dock = System.Windows.Forms.DockStyle.Left;
                picture_box_cover.Location = new System.Drawing.Point(0, 0);
                picture_box_cover.Size = new System.Drawing.Size(159, 110);
                picture_box_cover.TabIndex = 0;
                picture_box_cover.Name = "picture_box_cover";
                picture_box_cover.TabStop = false;
                setImagen(url, picture_box_cover);
            }
            public void setImagen(string url, PictureBox img)
            {
                try
                {
                    if (!Methods.IsDirectory(url))
                    {
                        var files = Directory.GetFiles(url.Remove(url.Length - url.Split('\\')[url.Split('\\').Length - 1].Length), "*.*", SearchOption.TopDirectoryOnly)
                            .Where(s => s.EndsWith(".jpeg") || s.EndsWith(".jpg") || s.EndsWith(".png"));
                        foreach (string file in files)
                        try
                        {
                            img.Image = Image.FromFile(file);
                            break;
                        }
                        catch (System.OutOfMemoryException e)
                        {
                            Console.WriteLine(e);
                            img.Image = Image.FromFile(@"image\portada.jpg");
                        }
                    }
                    else
                    {
                        var files = Directory.GetFiles(url, "*.*", SearchOption.TopDirectoryOnly)
                            .Where(s => s.EndsWith(".jpeg") || s.EndsWith(".jpg") || s.EndsWith(".png"));
                        foreach (string file in files)
                            try
                            {
                                img.Image = Image.FromFile(file);
                                break;
                            }
                            catch (System.OutOfMemoryException e)
                            {
                                Console.WriteLine(e);
                                img.Image = Image.FromFile(@"image\portada.jpg");
                            }
                    }
                }
                catch (System.IO.DirectoryNotFoundException)
                {
                    img.Image = Image.FromFile(@"image\cover.jpg");
                }
                catch (System.IO.IOException)
                {
                    img.Image = Image.FromFile(@"image\cover.jpg");
                }
                catch (Exception)
                {
                    Console.WriteLine("Easy panels itemVideo setImage");
                }
            }
            public void isSelected(bool isSelect)
            {
                if (isSelect)
                {
                    this.BackColor = Color.White;
                    label_duration.ForeColor = Color.Black;
                    label_views.ForeColor = Color.Black;
                    label_year.ForeColor = Color.Black;
                    label_title.ForeColor = Color.Black;
                }
                else
                {
                    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                    label_duration.ForeColor = System.Drawing.SystemColors.ButtonFace;
                    label_views.ForeColor = System.Drawing.SystemColors.AppWorkspace;
                    label_year.ForeColor = System.Drawing.SystemColors.ControlDark;
                    label_title.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
                }
            }
        }
        
    }
}
