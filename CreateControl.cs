
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KahenShiki
{
    public partial class Form1 : Form
    {
        private List<String> MiddleClassifications { get; set; }
        private List<SmallClassification> SmallClassifications { get; set; }

        public Form1() {
            InitializeComponent();

            MiddleClassifications = new List<string>();
            MiddleClassifications.Add("駆逐艦");
            MiddleClassifications.Add("戦艦");
            MiddleClassifications.Add("空母");
            MiddleClassifications.Add("軽空母");
            MiddleClassifications.Add("装甲空母");
            MiddleClassifications.Add("重巡洋艦");
            MiddleClassifications.Add("軽巡洋艦");

            SmallClassifications = new List<SmallClassification>();
            SmallClassifications.Add(new SmallClassification());
        }

        private void Form1_Load(object sender, EventArgs e) {
            System.Action<List<String>> createTabs = (middleClassifications) => {
                foreach (String middleClassification in middleClassifications) {
                    TabPage tabpage = new TabPage(middleClassification);
                    TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                    int elementPanelWidth = (int)(tabControl.Size.Width * 0.8);
                    int margin = (int)((tabControl.Size.Width - elementPanelWidth) * 0.5);
                    tableLayoutPanel.Size = new Size(elementPanelWidth, 50);
                    tableLayoutPanel.Location = new Point(margin, 15);
                    tableLayoutPanel.BackColor = Color.Red;
                    tableLayoutPanel.ColumnCount = 7;
                    tableLayoutPanel.RowCount = 2;
                    tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
                    System.Action createHeader = () => {
                        Label lavel1 = new Label();
                        lavel1.Text = "速さ";
                        lavel1.AutoSize = true;
                        lavel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        tableLayoutPanel.Controls.Add(lavel1, 1, 0);

                        Label lavel2 = new Label();
                        lavel2.Text = "火力";
                        lavel2.AutoSize = true;
                        lavel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        tableLayoutPanel.Controls.Add(lavel2, 2, 0);

                        Label lavel3 = new Label();
                        lavel3.Text = "装甲";
                        lavel3.AutoSize = true;
                        lavel3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        tableLayoutPanel.Controls.Add(lavel3, 3, 0);

                        Label lavel4 = new Label();
                        lavel4.Text = "LV";
                        lavel4.AutoSize = true;
                        lavel4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        tableLayoutPanel.Controls.Add(lavel4, 4, 0);

                        Label lavel5 = new Label();
                        lavel5.Text = "強化値";
                        lavel5.AutoSize = true;
                        lavel5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        tableLayoutPanel.Controls.Add(lavel5, 5, 0);

                        Label lavel6 = new Label();
                        lavel6.Text = "コメント";
                        lavel6.AutoSize = true;
                        lavel6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        tableLayoutPanel.Controls.Add(lavel6, 6, 0);
                    };
                    createHeader();
                    for (int idx = 0; idx < SmallClassifications.Count; idx++) {
                        Label setsumeiLabel = new Label();
                        setsumeiLabel.Text = SmallClassifications[idx].Sentsumei;
                        setsumeiLabel.AutoSize = true;
                        setsumeiLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        tableLayoutPanel.Controls.Add(setsumeiLabel, 0, idx + 1);

                        Label requestedLv4 = new Label();
                        requestedLv4.Text = SmallClassifications[idx].RequestedLv4.ToString();
                        requestedLv4.AutoSize = true;
                        requestedLv4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        tableLayoutPanel.Controls.Add(requestedLv4, 1, idx + 1);

                        Label requestedLv3 = new Label();
                        requestedLv3.Text = SmallClassifications[idx].RequestedLv3.ToString();
                        requestedLv3.AutoSize = true;
                        requestedLv3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        tableLayoutPanel.Controls.Add(requestedLv3, 2, idx + 1);

                        Label requestedLv2 = new Label();
                        requestedLv2.Text = SmallClassifications[idx].RequestedLv2.ToString();
                        requestedLv2.AutoSize = true;
                        requestedLv2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        tableLayoutPanel.Controls.Add(requestedLv2, 3, idx + 1);

                        Label level = new Label();
                        level.Text = SmallClassifications[idx].Level.ToString();
                        level.AutoSize = true;
                        level.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        tableLayoutPanel.Controls.Add(level, 4, idx + 1);

                        Label oldLevel = new Label();
                        oldLevel.Text = SmallClassifications[idx].OldLevel.ToString();
                        oldLevel.AutoSize = true;
                        oldLevel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        tableLayoutPanel.Controls.Add(oldLevel, 5, idx + 1);

                        Label note = new Label();
                        note.Text = SmallClassifications[idx].Note;
                        note.AutoSize = true;
                        note.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        tableLayoutPanel.Controls.Add(note, 6, idx + 1);
                    }
                    tableLayoutPanel.AutoSize = true;
                    tabpage.Controls.Add(tableLayoutPanel);
                    tabControl.TabPages.Add(tabpage);
                }
            };
            createTabs(MiddleClassifications);
        }
    }
}
// HACK: Styleの設定
// tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
// tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
// tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
// tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
// For Add New Row (Loop this code for add multiple rows)
//panel.RowCount = panel.RowCount + 1;
//panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
//panel.Controls.Add(new Label() { Text = "Street, City, State" }, 1, panel.RowCount - 1);
//panel.Controls.Add(new Label() { Text = "888888888888" }, 2, panel.RowCount - 1);
//panel.Controls.Add(new Label() { Text = "xxxxxxx@gmail.com" }, 3, panel.RowCount - 1);
