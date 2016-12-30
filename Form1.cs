using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ViewAtlas
{
	public partial class Form1 : Form
	{
		// 画像ファイルとみなす拡張子.
		private string[] imageExtention = {".png", ".bmp"};

		private struct ImageInfo
		{
			public string filename;
			public int sizeX;
			public int sizeY;
			public string format;
			public string magFilter;
			public string minFilter;
			public string repeat;
		}
		private struct TexRegion
		{
			public string image;
			public string region;
			public int x, y, w, h;
		}

		private string basedir;
		List<ImageInfo> imageInfos = new List<ImageInfo>();
		List<TexRegion> regions = new List<TexRegion>();
		Dictionary<string, TexRegion> dicRegions = new Dictionary<string, TexRegion>();
		Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();

		private bool listboxLocked = false;

		public Form1()
		{
			InitializeComponent();

			pictureBox1.BackColor = button1.BackColor;

		}

		//!< @brief Atlas解析
		private bool parseAtlas(string filepath)
		{
			// 現在の画像ファイル.
			string currentImage = "";

			using (StreamReader sr = new StreamReader(filepath, System.Text.Encoding.GetEncoding("shift_jis")))
			{
				string line;
				while(sr.Peek() != -1)
				{
					line = sr.ReadLine();
					// 何もないならスキップ.
					if(line.Length==0)
					{
						continue;
					}
					else
					{
						// 画像の拡張子が見えたら
						bool contain = false;
						foreach(var ext in imageExtention)
						{
							if(line.Contains(ext))
							{
								contain = true;
								break;
							}
						}
						if(contain) {
							ImageInfo imageInfo = new ImageInfo();
							currentImage = line.Trim(' ');
							analyzeHeader(sr, currentImage, ref imageInfo);
							imageInfos.Add(imageInfo);
						}
						// それ以外ならRegionデータ
						else
						{
							TexRegion region = new TexRegion();
							analyzeRegion(sr, currentImage, line.Trim(' '), ref region);
							regions.Add(region);
						}
					}
					
				}
			}
			return true;
		}

		//!< @brief ヘッダ解析
		private void analyzeHeader(StreamReader sr, string imageFile, ref ImageInfo info)
		{
			string[] words;

			// 画像情報
			info.filename = string.Copy(imageFile);
			// サイズ
			words = sr.ReadLine().Trim(' ').Split(':');
			words = words[1].Split(',');
			info.sizeX = int.Parse(words[0]);
			info.sizeY = int.Parse(words[1]);
			// フォーマット
			words = sr.ReadLine().Trim(' ').Split(':');
			info.format = string.Copy(words[1]);
			// フィルター
			words = sr.ReadLine().Trim(' ').Split(':');
			words = words[1].Split(',');
			info.minFilter = string.Copy(words[0]);
			info.magFilter = string.Copy(words[1]);
			// リピート
			words = sr.ReadLine().Trim(' ').Split(':');
			info.repeat = string.Copy(words[1]);
		}

		//!< @brief TextureRegion解析
		private void analyzeRegion(StreamReader sr, string image, string regionname, ref TexRegion region)
		{
			string[] words;

			// 画像ファイル名
			region.image = string.Copy(image);
			// region
			region.region = string.Copy(regionname);
			// rotate
			sr.ReadLine();  // skip
			// xy
			words = sr.ReadLine().Trim(' ').Split(':');
			words = words[1].Split(',');
			region.x = int.Parse(words[0]);
			region.y = int.Parse(words[1]);
			// size
			words = sr.ReadLine().Trim(' ').Split(':');
			words = words[1].Split(',');
			region.w = int.Parse(words[0]);
			region.h = int.Parse(words[1]);
			// orig
			sr.ReadLine(); // skip
			// offset
			sr.ReadLine(); // skip
			// index
			sr.ReadLine(); // skip
		}

		private void updateRegion(string regtionName)
		{
			if(dicRegions.ContainsKey(regtionName))
			{
				TexRegion region = dicRegions[regtionName];

				Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);//region.w, region.h);

				using(Graphics g = Graphics.FromImage(canvas))
				{
					// 表示位置を中心になるよう計算.
					int drawX = pictureBox1.Width/2 - region.w/2;
					int drawY = pictureBox1.Height/2 - region.h/2;

					Rectangle srcRect = new Rectangle(region.x, region.y, region.w, region.h);
					Rectangle dstRect = new Rectangle(drawX, drawY, srcRect.Width, srcRect.Height);
					g.DrawImage(bitmaps[region.image], dstRect, srcRect, GraphicsUnit.Pixel);
				}
				pictureBox1.Image = canvas;
			}
		}

		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			if (fileNames.Length == 1)
			{
				string filepath = fileNames[0];
				string ext = System.IO.Path.GetExtension(filepath);
				if (ext == ".atlas")
				{
					basedir = System.IO.Path.GetDirectoryName(filepath) + "\\";
					textBox2.Text = filepath;
					textBox2.SelectionStart = textBox2.Text.Length;
					textBox2.Focus();
					textBox2.ScrollToCaret();

					// Clear
					listBox1.Items.Clear();
					regions.Clear();
					dicRegions.Clear();
					
					// 解析
					parseAtlas(filepath);

					foreach(var region in regions)
					{
						// リストボックス登録
						listBox1.Items.Add(region.region);
						// 辞書登録
						dicRegions.Add(region.region, region);
						// 画像読み込み
						if(!bitmaps.ContainsKey(region.image))
						{
							bitmaps[region.image] = new Bitmap(basedir + region.image);
						}
					}
				}
			}
		}

		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				if(((Object[])e.Data.GetData(DataFormats.FileDrop, false)).Length == 1)
				{
					e.Effect = DragDropEffects.Copy;
				}
			}
		}

		//!< @brief リストボックス選択時
		private void listBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			updateRegion((string)listBox1.SelectedItem);
		}

		//!< @brief 検索テキストボックス
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			TextBox tb = (TextBox)sender;

			listBox1.Items.Clear();
			foreach(var region in regions)
			{
				if(region.region.Contains(tb.Text))
				{
					// リストボックス登録
					listBox1.Items.Add(region.region);
				}
			}
		}

		//!< @brief 背景色変更
		private void button1_Click(object sender, EventArgs e)
		{
			// 別にカラーピッカーである必要ない気がするのでオプション扱い
			if((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
			{
				ColorDialog cd = new ColorDialog();
				cd.Color = button1.BackColor;
				if (cd.ShowDialog() == DialogResult.OK)
				{
					pictureBox1.BackColor = cd.Color;
					button1.BackColor = cd.Color;
				}
			}
			else { 
				// 白黒入れ替え.
				Color newcolor = (pictureBox1.BackColor == Color.White) ? Color.Black : Color.White;
				pictureBox1.BackColor = newcolor;
				button1.BackColor = newcolor;
			}
		}

		private void textBoxSearch_Click(object sender, EventArgs e)
		{
			TextBox tb = (TextBox)sender;

			tb.SelectAll();
		}

		private void listBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if(listboxLocked)
			{
				return;
			}

			int index = listBox1.IndexFromPoint( e.X, e.Y );
			if ( index == ListBox.NoMatches  )
			{
				return;
			}
			listBox1.SelectedIndex = index;
			updateRegion((string)listBox1.SelectedItem);
		}

		private void listBox1_MouseLeave(object sender, EventArgs e)
		{
		}

		private void listBox1_Click(object sender, EventArgs e)
		{
			listboxLocked = true;
		}

		private void Form1_Click(object sender, EventArgs e)
		{
			listboxLocked = false;

		}
	}
}
