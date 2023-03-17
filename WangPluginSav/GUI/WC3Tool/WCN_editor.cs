using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace WC3Tool;

public class WCN_editor : Form
{
	public string wcnfilter = "Wonder News file|*.wn3|All Files (*.*)|*.*";

	public byte[] wcnbuffer = new byte[448];

	public static wc3 wcnfile;

	public bool japanese;

	private Graphics GFX;

	private ResourceManager resources = new ResourceManager("WC3Tool.WC3.Image.Cards", Assembly.GetExecutingAssembly());

	private Image bitmap;

	private IContainer components;

	private Button load_wc3_but;

	private Button save_wc3_but;

	private TextBox wc3_path;

	private Label label1;

	private Label label2;

	private Label label3;

	private Label label4;

	private Label label5;

	private Label label6;

	private Label label7;

	private Label label8;

	private TextBox header1;

	private TextBox body5;

	private TextBox body1;

	private TextBox body2;

	private TextBox body3;

	private TextBox body4;

	private TextBox body6;

	private TextBox body7;

	private CheckBox distrocheck;

	private Label label9;

	private ComboBox colorbox;

	private Label label10;

	private Label label11;

	private Label label12;

	private TextBox body8;

	private TextBox body9;

	private TextBox body10;

	private Label regionlab;

	public WCN_editor()
	{
		InitializeComponent();
		regionlab.Text = "";
		GFX = CreateGraphics();
		colorbox.SelectedIndex = 0;
	}

	private void update_wcdata()
	{
		switch (wcnfile.distributable)
		{
		case 0:
			distrocheck.Checked = false;
			break;
		case 1:
			distrocheck.Checked = true;
			break;
		default:
			distrocheck.Checked = false;
			break;
		}
		colorbox.SelectedIndex = wcnfile.cardcolor;
		header1.Text = wcnfile.get_wn_text_2(0);
		body1.Text = wcnfile.get_wn_text_2(1);
		body2.Text = wcnfile.get_wn_text_2(2);
		body3.Text = wcnfile.get_wn_text_2(3);
		body4.Text = wcnfile.get_wn_text_2(4);
		body5.Text = wcnfile.get_wn_text_2(5);
		body6.Text = wcnfile.get_wn_text_2(6);
		body7.Text = wcnfile.get_wn_text_2(7);
		body8.Text = wcnfile.get_wn_text_2(8);
		body9.Text = wcnfile.get_wn_text_2(9);
		body10.Text = wcnfile.get_wn_text_2(10);
	}

	private void set_wcndata()
	{
		wcnfile.clear_wn_text();
		wcnfile.insert_wn_text_2(header1.Text, 0);
		wcnfile.insert_wn_text_2(body1.Text, 1);
		wcnfile.insert_wn_text_2(body2.Text, 2);
		wcnfile.insert_wn_text_2(body3.Text, 3);
		wcnfile.insert_wn_text_2(body4.Text, 4);
		wcnfile.insert_wn_text_2(body5.Text, 5);
		wcnfile.insert_wn_text_2(body6.Text, 6);
		wcnfile.insert_wn_text_2(body7.Text, 7);
		wcnfile.insert_wn_text_2(body8.Text, 8);
		wcnfile.insert_wn_text_2(body9.Text, 9);
		wcnfile.insert_wn_text_2(body10.Text, 10);
	}

	private void Load_WCN(string path)
	{
		int num = FileIO.load_file(ref wcnbuffer, ref path, wcnfilter);
		if (num == 448 || num == 228)
		{
			if (num == 228)
			{
				japanese = true;
				regionlab.Text = "JAP";
				header1.MaxLength = 20;
				body1.MaxLength = 20;
				body2.MaxLength = 20;
				body3.MaxLength = 20;
				body4.MaxLength = 20;
				body5.MaxLength = 20;
				body6.MaxLength = 20;
				body7.MaxLength = 20;
				body8.MaxLength = 20;
				body9.MaxLength = 20;
				body10.MaxLength = 20;
			}
			else
			{
				japanese = false;
				regionlab.Text = "USA/EUR";
				header1.MaxLength = 40;
				body1.MaxLength = 40;
				body2.MaxLength = 40;
				body3.MaxLength = 40;
				body4.MaxLength = 40;
				body5.MaxLength = 40;
				body6.MaxLength = 40;
				body7.MaxLength = 40;
				body8.MaxLength = 40;
				body9.MaxLength = 40;
				body10.MaxLength = 40;
			}
			wc3_path.Text = path;
			wcnfile = new wc3(wcnbuffer);
			update_wcdata();
			save_wc3_but.Enabled = true;
		}
		else
		{
			MessageBox.Show("Invalid file size.");
		}
	}

	private void Load_wc3_butClick(object sender, EventArgs e)
	{
		Load_WCN(null);
	}

	private void Save_wc3_butClick(object sender, EventArgs e)
	{
		int distro = 0;
		if (distrocheck.Checked)
		{
			distro = 1;
		}
		wcnfile.set_wcn_color_distro(colorbox.SelectedIndex, distro);
		set_wcndata();
		wcnfile.fix_wcn_checksum();
		FileIO.save_data(wcnfile.Data, wcnfilter);
	}

	private void WCN_editorLoad(object sender, EventArgs e)
	{
	}

	private void drawCard()
	{
		bitmap = (Image)resources.GetObject("News_" + colorbox.SelectedIndex);
		GFX.DrawImage(bitmap, 500, 166, 260, 140);
		GFX.DrawImage(bitmap, 500, 140, 260, 140);
		GFX.DrawString(header1.Text, new Font("Calibri", 8f), Brushes.Black, 507f, 144f);
		GFX.DrawString(body1.Text, new Font("Calibri", 8f), Brushes.Black, 507f, 161f);
		GFX.DrawString(body2.Text, new Font("Calibri", 8f), Brushes.Black, 507f, 175f);
		GFX.DrawString(body3.Text, new Font("Calibri", 8f), Brushes.Black, 507f, 189f);
		GFX.DrawString(body4.Text, new Font("Calibri", 8f), Brushes.Black, 507f, 203f);
		GFX.DrawString(body5.Text, new Font("Calibri", 8f), Brushes.Black, 507f, 217f);
		GFX.DrawString(body6.Text, new Font("Calibri", 8f), Brushes.Black, 507f, 231f);
		GFX.DrawString(body7.Text, new Font("Calibri", 8f), Brushes.Black, 507f, 245f);
		GFX.DrawString(body8.Text, new Font("Calibri", 8f), Brushes.Black, 507f, 259f);
		GFX.DrawString(body9.Text, new Font("Calibri", 8f), Brushes.Black, 507f, 273f);
		GFX.DrawString(body10.Text, new Font("Calibri", 8f), Brushes.Black, 507f, 287f);
	}

	private void ColorboxSelectedIndexChanged(object sender, EventArgs e)
	{
		drawCard();
	}

	private void Header1TextChanged(object sender, EventArgs e)
	{
		drawCard();
	}

	private void Body1TextChanged(object sender, EventArgs e)
	{
		drawCard();
	}

	private void Body2TextChanged(object sender, EventArgs e)
	{
		drawCard();
	}

	private void Body3TextChanged(object sender, EventArgs e)
	{
		drawCard();
	}

	private void Body4TextChanged(object sender, EventArgs e)
	{
		drawCard();
	}

	private void Body5TextChanged(object sender, EventArgs e)
	{
		drawCard();
	}

	private void Body6TextChanged(object sender, EventArgs e)
	{
		drawCard();
	}

	private void Body7TextChanged(object sender, EventArgs e)
	{
		drawCard();
	}

	private void Body8TextChanged(object sender, EventArgs e)
	{
		drawCard();
	}

	private void Body9TextChanged(object sender, EventArgs e)
	{
		drawCard();
	}

	private void Body10TextChanged(object sender, EventArgs e)
	{
		drawCard();
	}

	private void WCN_editorDragEnter(object sender, DragEventArgs e)
	{
		e.Effect = DragDropEffects.All;
	}

	private void WCN_editorDragDrop(object sender, DragEventArgs e)
	{
		string[] array = (string[])e.Data.GetData(DataFormats.FileDrop, autoConvert: false);
		Load_WCN(array[0]);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.load_wc3_but = new System.Windows.Forms.Button();
		this.save_wc3_but = new System.Windows.Forms.Button();
		this.wc3_path = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.header1 = new System.Windows.Forms.TextBox();
		this.body5 = new System.Windows.Forms.TextBox();
		this.body1 = new System.Windows.Forms.TextBox();
		this.body2 = new System.Windows.Forms.TextBox();
		this.body3 = new System.Windows.Forms.TextBox();
		this.body4 = new System.Windows.Forms.TextBox();
		this.body6 = new System.Windows.Forms.TextBox();
		this.body7 = new System.Windows.Forms.TextBox();
		this.distrocheck = new System.Windows.Forms.CheckBox();
		this.colorbox = new System.Windows.Forms.ComboBox();
		this.label10 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.label12 = new System.Windows.Forms.Label();
		this.body8 = new System.Windows.Forms.TextBox();
		this.body9 = new System.Windows.Forms.TextBox();
		this.body10 = new System.Windows.Forms.TextBox();
		this.regionlab = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.load_wc3_but.Location = new System.Drawing.Point(49, 11);
		this.load_wc3_but.Name = "load_wc3_but";
		this.load_wc3_but.Size = new System.Drawing.Size(75, 23);
		this.load_wc3_but.TabIndex = 0;
		this.load_wc3_but.Text = "Load WN3";
		this.load_wc3_but.UseVisualStyleBackColor = true;
		this.load_wc3_but.Click += new System.EventHandler(Load_wc3_butClick);
		this.save_wc3_but.Enabled = false;
		this.save_wc3_but.Location = new System.Drawing.Point(130, 11);
		this.save_wc3_but.Name = "save_wc3_but";
		this.save_wc3_but.Size = new System.Drawing.Size(75, 23);
		this.save_wc3_but.TabIndex = 1;
		this.save_wc3_but.Text = "Save WN3";
		this.save_wc3_but.UseVisualStyleBackColor = true;
		this.save_wc3_but.Click += new System.EventHandler(Save_wc3_butClick);
		this.wc3_path.Location = new System.Drawing.Point(221, 13);
		this.wc3_path.Name = "wc3_path";
		this.wc3_path.ReadOnly = true;
		this.wc3_path.Size = new System.Drawing.Size(560, 20);
		this.wc3_path.TabIndex = 2;
		this.label1.Location = new System.Drawing.Point(49, 102);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(100, 23);
		this.label1.TabIndex = 3;
		this.label1.Text = "Header";
		this.label2.Location = new System.Drawing.Point(49, 217);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(100, 23);
		this.label2.TabIndex = 4;
		this.label2.Text = "Body 5";
		this.label3.Location = new System.Drawing.Point(49, 125);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(100, 23);
		this.label3.TabIndex = 5;
		this.label3.Text = "Body 1";
		this.label4.Location = new System.Drawing.Point(49, 148);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(100, 23);
		this.label4.TabIndex = 6;
		this.label4.Text = "Body 2";
		this.label5.Location = new System.Drawing.Point(49, 171);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(100, 23);
		this.label5.TabIndex = 7;
		this.label5.Text = "Body 3";
		this.label6.Location = new System.Drawing.Point(49, 194);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(100, 23);
		this.label6.TabIndex = 8;
		this.label6.Text = "Body 4";
		this.label7.Location = new System.Drawing.Point(49, 240);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(100, 23);
		this.label7.TabIndex = 9;
		this.label7.Text = "Body 6";
		this.label8.Location = new System.Drawing.Point(49, 263);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(100, 23);
		this.label8.TabIndex = 10;
		this.label8.Text = "Body 7";
		this.header1.Location = new System.Drawing.Point(114, 99);
		this.header1.MaxLength = 40;
		this.header1.Name = "header1";
		this.header1.Size = new System.Drawing.Size(379, 20);
		this.header1.TabIndex = 11;
		this.header1.TextChanged += new System.EventHandler(Header1TextChanged);
		this.body5.Location = new System.Drawing.Point(114, 214);
		this.body5.MaxLength = 40;
		this.body5.Name = "body5";
		this.body5.Size = new System.Drawing.Size(379, 20);
		this.body5.TabIndex = 16;
		this.body5.TextChanged += new System.EventHandler(Body5TextChanged);
		this.body1.Location = new System.Drawing.Point(114, 122);
		this.body1.MaxLength = 40;
		this.body1.Name = "body1";
		this.body1.Size = new System.Drawing.Size(379, 20);
		this.body1.TabIndex = 12;
		this.body1.TextChanged += new System.EventHandler(Body1TextChanged);
		this.body2.Location = new System.Drawing.Point(114, 145);
		this.body2.MaxLength = 40;
		this.body2.Name = "body2";
		this.body2.Size = new System.Drawing.Size(379, 20);
		this.body2.TabIndex = 13;
		this.body2.TextChanged += new System.EventHandler(Body2TextChanged);
		this.body3.Location = new System.Drawing.Point(114, 168);
		this.body3.MaxLength = 40;
		this.body3.Name = "body3";
		this.body3.Size = new System.Drawing.Size(379, 20);
		this.body3.TabIndex = 14;
		this.body3.TextChanged += new System.EventHandler(Body3TextChanged);
		this.body4.Location = new System.Drawing.Point(114, 191);
		this.body4.MaxLength = 40;
		this.body4.Name = "body4";
		this.body4.Size = new System.Drawing.Size(379, 20);
		this.body4.TabIndex = 15;
		this.body4.TextChanged += new System.EventHandler(Body4TextChanged);
		this.body6.Location = new System.Drawing.Point(114, 237);
		this.body6.MaxLength = 40;
		this.body6.Name = "body6";
		this.body6.Size = new System.Drawing.Size(379, 20);
		this.body6.TabIndex = 17;
		this.body6.TextChanged += new System.EventHandler(Body6TextChanged);
		this.body7.Location = new System.Drawing.Point(114, 260);
		this.body7.MaxLength = 40;
		this.body7.Name = "body7";
		this.body7.Size = new System.Drawing.Size(379, 20);
		this.body7.TabIndex = 18;
		this.body7.TextChanged += new System.EventHandler(Body7TextChanged);
		this.distrocheck.Location = new System.Drawing.Point(364, 69);
		this.distrocheck.Name = "distrocheck";
		this.distrocheck.Size = new System.Drawing.Size(85, 24);
		this.distrocheck.TabIndex = 22;
		this.distrocheck.Text = "Distributable";
		this.distrocheck.UseVisualStyleBackColor = true;
		this.colorbox.FormattingEnabled = true;
		this.colorbox.Items.AddRange(new object[8] { "Yellow (0x00)", "Crystal (0x01)", "Red (0x02)", "Green (0x03)", "Blue (0x04)", "Brown (0x05)", "Gold (0x06)", "Silver (0x07)" });
		this.colorbox.Location = new System.Drawing.Point(115, 58);
		this.colorbox.Name = "colorbox";
		this.colorbox.Size = new System.Drawing.Size(243, 21);
		this.colorbox.TabIndex = 25;
		this.colorbox.SelectedIndexChanged += new System.EventHandler(ColorboxSelectedIndexChanged);
		this.label10.Location = new System.Drawing.Point(46, 60);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(63, 19);
		this.label10.TabIndex = 26;
		this.label10.Text = "Color";
		this.label9.Location = new System.Drawing.Point(49, 286);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(100, 23);
		this.label9.TabIndex = 27;
		this.label9.Text = "Body 8";
		this.label11.Location = new System.Drawing.Point(49, 309);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(100, 23);
		this.label11.TabIndex = 28;
		this.label11.Text = "Body 9";
		this.label12.Location = new System.Drawing.Point(49, 332);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(100, 23);
		this.label12.TabIndex = 29;
		this.label12.Text = "Body 10";
		this.body8.Location = new System.Drawing.Point(114, 283);
		this.body8.MaxLength = 40;
		this.body8.Name = "body8";
		this.body8.Size = new System.Drawing.Size(379, 20);
		this.body8.TabIndex = 19;
		this.body8.TextChanged += new System.EventHandler(Body8TextChanged);
		this.body9.Location = new System.Drawing.Point(114, 306);
		this.body9.MaxLength = 40;
		this.body9.Name = "body9";
		this.body9.Size = new System.Drawing.Size(379, 20);
		this.body9.TabIndex = 20;
		this.body9.TextChanged += new System.EventHandler(Body9TextChanged);
		this.body10.Location = new System.Drawing.Point(114, 329);
		this.body10.MaxLength = 40;
		this.body10.Name = "body10";
		this.body10.Size = new System.Drawing.Size(379, 20);
		this.body10.TabIndex = 21;
		this.body10.TextChanged += new System.EventHandler(Body10TextChanged);
		this.regionlab.Location = new System.Drawing.Point(364, 50);
		this.regionlab.Name = "regionlab";
		this.regionlab.Size = new System.Drawing.Size(100, 16);
		this.regionlab.TabIndex = 30;
		this.regionlab.Text = "USA/EUR";
		this.AllowDrop = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(820, 373);
		base.Controls.Add(this.regionlab);
		base.Controls.Add(this.body10);
		base.Controls.Add(this.body9);
		base.Controls.Add(this.body8);
		base.Controls.Add(this.label12);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.colorbox);
		base.Controls.Add(this.distrocheck);
		base.Controls.Add(this.body7);
		base.Controls.Add(this.body6);
		base.Controls.Add(this.body4);
		base.Controls.Add(this.body3);
		base.Controls.Add(this.body2);
		base.Controls.Add(this.body1);
		base.Controls.Add(this.body5);
		base.Controls.Add(this.header1);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.wc3_path);
		base.Controls.Add(this.save_wc3_but);
		base.Controls.Add(this.load_wc3_but);
		base.Name = "WCN_editor";
		this.Text = "WN3 Editor";
		base.Load += new System.EventHandler(WCN_editorLoad);
		base.DragDrop += new System.Windows.Forms.DragEventHandler(WCN_editorDragDrop);
		base.DragEnter += new System.Windows.Forms.DragEventHandler(WCN_editorDragEnter);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
