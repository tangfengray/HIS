using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using YpClass;
using ts_mzys_class;


namespace ts_mzys_blcflr
{
    public partial class Frmblcf_cx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataSet PubDset = new DataSet();
        public bool bok = false;

        public struct Cf
        {
            public long brxxid;
            public long ghxxid;
            public int js;
            public int ksdm;
            public int ysdm;
            public int zxksid;
            public int zyksid;
            /// <summary>
            /// 项目来源
            /// </summary>
            public int xmly;
            /// <summary>
            /// 套餐ID
            /// </summary>
            public long tcid;
            public string fpcode;
            public string tjdxmdm;
            public string cfh;
            /// <summary>
            /// 就诊ID
            /// </summary>
            public long jzid;
        }
        public struct Cell
        {
            public int nrow;
            public int ncol;
        }

        public long Jgbm = 0;
        public Cf Dqcf = new Cf();
        public Cell cell = new Cell();
        public DataTable Tab; //所有未收费的处方明细

        private SystemCfg psItem;

        public Frmblcf_cx(MenuTag menuTag, string chineseName, Form mdiParent, Guid brxxid, Guid jzid)
        {
            InitializeComponent();


            panel_br.Dock = System.Windows.Forms.DockStyle.Fill;
            panelXX.Dock = System.Windows.Forms.DockStyle.Fill;

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

            try
            {
                string ssql = @"
                            select  dbo.fun_getdeptname(jsksdm) 接诊科室,dbo.fun_getempname(jsysdm) 接诊医生,
                             jssj 接诊时间,c.zdmc 诊断,wcsj 结束时间,b.blh 门诊号,jzid,b.ghxxid
                             from vi_yy_brxx a inner join vi_mz_ghxx b on a.brxxid=b.brxxid 
                            inner join mzys_jzjl c on  b.ghxxid=c.ghxxid and c.bscbz=0 and c.bjsbz=1  where a.brxxid='" + brxxid + "'";
                if (jzid != Guid.Empty)
                    ssql = ssql + " and jzid='" + jzid + "'";
                ssql = ssql + " order by 接诊时间";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                listView_hzbr.Items.Clear();
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Name = "接诊科室";
                    item.Text = Convertor.IsNull(tb.Rows[i]["接诊科室"], "");

                    ListViewItem.ListViewSubItem subitem_jzks = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["接诊医生"], ""));
                    subitem_jzks.Name = "接诊医生";
                    item.SubItems.Add(subitem_jzks);

                    ListViewItem.ListViewSubItem subitem_jzsj = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["接诊时间"], ""));
                    subitem_jzsj.Name = "接诊时间";
                    item.SubItems.Add(subitem_jzsj);

                    ListViewItem.ListViewSubItem subitem_jz = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["诊断"], ""));
                    subitem_jz.Name = "诊断";
                    item.SubItems.Add(subitem_jz);

                    ListViewItem.ListViewSubItem subitem_wcsj = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["结束时间"], ""));
                    subitem_wcsj.Name = "结束时间";
                    item.SubItems.Add(subitem_wcsj);

                    ListViewItem.ListViewSubItem subitem_blh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["门诊号"], ""));
                    subitem_blh.Name = "门诊号";
                    item.SubItems.Add(subitem_blh);

                    ListViewItem.ListViewSubItem subitem_jzid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["jzid"], ""));
                    subitem_jzid.Name = "jzid";
                    item.SubItems.Add(subitem_jzid);

                    ListViewItem.ListViewSubItem subitem_ghxxid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["ghxxid"], ""));
                    subitem_ghxxid.Name = "ghxxid";
                    item.SubItems.Add(subitem_ghxxid);

                    listView_hzbr.Items.Add(item);
                }


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Frmhjsf_Load(object sender, EventArgs e)
        {
            Jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;

            if (listView_hzbr.Items.Count > 0)
                listView_hzbr.Items[0].Selected = true;
        }

        //窗体键盘事件
        private void Frmhjsf_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F8)
            {
                //butsf_Click(sender, e);
            }

        }


        //添加处方
        private void AddPresc(DataTable tb)
        {

            decimal sumje = 0;
            DataTable tbmx = tb.Clone();

            string[] GroupbyField ={ "HJID" };
            string[] ComputeField ={ "金额" };
            string[] CField ={ "sum" };
            TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
            xcset.TsDataTable = tb;
            DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "序号<>'小计'");
            bool b_ks = false;
            for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            {

                DataRow[] rows = tb.Select("HJID='" + tbcf.Rows[i]["hjid"].ToString().Trim() + "'");
                for (int j = 0; j <= rows.Length - 1; j++)
                {
                    DataRow row = tb.NewRow();
                    row = rows[j];
                    row["序号"] = j + 1;
                    row["开嘱时间"] = ' ' + Convert.ToDateTime(rows[j]["划价日期"]).ToString("MM-dd HH:mm");
                    //if (row["自备药"].ToString() == "1") row["医嘱内容"] = row["医嘱内容"] + " 【自备】";
                    //if (row["处方分组序号"].ToString() == "1") { b_ks = true; row["医嘱内容"] = "┌" + row["医嘱内容"].ToString(); }
                    //if (row["处方分组序号"].ToString() == "0" && b_ks == true) {row["医嘱内容"] = "│" + row["医嘱内容"].ToString(); }
                    //if (row["处方分组序号"].ToString() == "-1" && b_ks == true) { b_ks = false; row["医嘱内容"] = "└" + row["医嘱内容"].ToString(); }
                    //if (row["皮试标志"].ToString() == "0" && row["项目来源"].ToString()=="1") row["医嘱内容"] = row["医嘱内容"] + " 【皮试】";
                    //if (row["皮试标志"].ToString() == "1") row["医嘱内容"] = row["医嘱内容"] + " (-)";
                    //if (row["皮试标志"].ToString() == "2") row["医嘱内容"] = row["医嘱内容"] + " (+)";
                    //if (row["皮试标志"].ToString() == "3") row["医嘱内容"] = row["医嘱内容"] + " 【免试】";
                    if (row["自备药"].ToString() == "1") row["医嘱内容"] = row["医嘱内容"] + " 【自备】";
                    if (row["处方分组序号"].ToString() == "1") { b_ks = true; row["医嘱内容"] = "┌" + row["医嘱内容"].ToString(); }
                    if (row["处方分组序号"].ToString() == "2" && b_ks == true) { row["医嘱内容"] = "│" + row["医嘱内容"].ToString(); }
                    if (row["处方分组序号"].ToString() == "-1" && b_ks == true) { b_ks = false; row["医嘱内容"] = "└" + row["医嘱内容"].ToString(); }
                    if (row["皮试标志"].ToString() == "0" && row["项目来源"].ToString() == "1") row["医嘱内容"] = row["医嘱内容"] + " 【皮试】";
                    if (row["皮试标志"].ToString() == "1") row["医嘱内容"] = row["医嘱内容"] + " 【-】";
                    if (row["皮试标志"].ToString() == "2") row["医嘱内容"] = row["医嘱内容"] + " 【+】";
                    if (row["皮试标志"].ToString() == "3") row["医嘱内容"] = row["医嘱内容"] + " 【免试】";
                    if (row["皮试标志"].ToString() == "9") row["医嘱内容"] = row["医嘱内容"] + " 【皮试液】";
                    row["选择"] = false;
                    tbmx.ImportRow(row);



                }
                DataRow sumrow = tbmx.NewRow();
                sumrow["序号"] = "小计";
                sumrow["收费"] = false;
                decimal je = Math.Round(Convert.ToDecimal(tbcf.Rows[i]["金额"]), 2);
                sumrow["金额"] = je.ToString("0.00");
                sumje = sumje + je;
                sumrow["hjid"] = tbcf.Rows[i]["hjid"];
                tbmx.Rows.Add(sumrow);
            }
            tbmx.AcceptChanges();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = tbmx;
            dataGridView1.CurrentCell = null;


        }

        //改变行颜色
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dgv in dataGridView1.Rows)
                {
                    if (Convert.ToInt64(Convertor.IsNull(dgv.Cells["项目id"].Value, "0")) > 0 || (new Guid(Convertor.IsNull(dgv.Cells["hjid"].Value, Guid.Empty.ToString())) != Guid.Empty && Convertor.IsNull(dgv.Cells["序号"].Value, "0") != "小计"))
                    {
                        //dgv.DefaultCellStyle.BackColor = Color.Azure ;
                        dgv.Cells["开嘱时间"].Style.BackColor = Color.Wheat;
                        dgv.Cells["医嘱内容"].Style.BackColor = Color.Wheat;
                        dgv.Cells["剂量"].Style.BackColor = Color.Wheat;
                        dgv.Cells["剂量单位"].Style.BackColor = Color.Wheat;
                        dgv.Cells["频次"].Style.BackColor = Color.Wheat;
                        dgv.Cells["用法"].Style.BackColor = Color.Wheat;
                        dgv.Cells["天数"].Style.BackColor = Color.Wheat;
                        dgv.Cells["嘱托"].Style.BackColor = Color.Wheat;
                        dgv.Cells["开嘱医生"].Style.BackColor = Color.Wheat;
                        dgv.Cells["执行科室"].Style.BackColor = Color.Wheat;
                    }

                    if (Convert.ToString(Convertor.IsNull(dgv.Cells["序号"].Value, "0")) == "小计")
                    {
                        dgv.DefaultCellStyle.ForeColor = Color.Red;
                        dgv.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    }

                    if (Convert.ToInt64(Convertor.IsNull(dgv.Cells["项目id"].Value, "0")) > 0)
                    {
                        if (Convert.ToBoolean(dgv.Cells["收费"].Value) == true)
                        {
                            dgv.DefaultCellStyle.ForeColor = Color.DimGray;
                            dgv.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        }
                    }


                    ////Convert.ToInt64(Convertor.IsNull(dgv.Cells["hjmxid"].Value, "0")) > 0 &&
                    try
                    {
                        if (dgv.Cells["修改"].Value is DBNull)
                        { }
                        else
                        {
                            if (Convert.ToBoolean(dgv.Cells["修改"].Value) == true)
                                dgv.DefaultCellStyle.ForeColor = Color.Blue;
                        }
                    }
                    catch (System.Exception err)
                    {
                        int iii = 0;
                    }
                }


            }
            catch (System.Exception err)
            {
            }
        }


        private void Add_Yj_record(Guid jzid)
        {
            string ssql = "select * from YJ_MZSQ where jzid='" + jzid + "' and bscbz=0 ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            listView_yj.Items.Clear();
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                ListViewItem item = new ListViewItem(Convertor.IsNull(tb.Rows[i]["sqrq"], ""));
                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["sqnr"], ""));
                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["je"], ""));
                if (tb.Rows[i]["bsfbz"].ToString() == "1")
                    item.SubItems.Add("√");
                if (tb.Rows[i]["bqxsfbz"].ToString() == "1")
                    item.SubItems.Add("已退");
                if (tb.Rows[i]["bsfbz"].ToString() == "1" && tb.Rows[i]["bqxsfbz"].ToString() == "0")
                    item.SubItems.Add("");
                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["bbmc"], ""));
                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["bsjc"], ""));
                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["lczd"], ""));
                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["zysx"], ""));
                item.SubItems.Add(Fun.SeekDeptName(Convert.ToInt32(tb.Rows[i]["zxks"]), InstanceForm.BDatabase));
                item.SubItems.Add(Fun.SeekEmpName(Convert.ToInt32(tb.Rows[i]["sqr"]), InstanceForm.BDatabase));
                item.SubItems.Add(Convertor.IsNull(tb.Rows[i]["BJSSJ"], ""));

                ListViewItem.ListViewSubItem subitem_yjsqid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["yjsqid"], ""));
                subitem_yjsqid.Name = "yjsqid";
                item.SubItems.Add(subitem_yjsqid);

                ListViewItem.ListViewSubItem subitem_hjid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["yzid"], ""));
                subitem_hjid.Name = "yzid";
                item.SubItems.Add(subitem_hjid);

                ListViewItem.ListViewSubItem subitem_yzxmid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["yzxmid"], ""));
                subitem_yzxmid.Name = "yzxmid";
                item.SubItems.Add(subitem_yzxmid);

                ListViewItem.ListViewSubItem subitem_djlx = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["djlx"], ""));
                subitem_djlx.Name = "djlx";
                item.SubItems.Add(subitem_djlx);


                ListViewItem.ListViewSubItem subitem_ghxxid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["ghxxid"], ""));
                subitem_ghxxid.Name = "ghxxid";
                item.SubItems.Add(subitem_ghxxid);

                listView_yj.Items.Add(item);
            }
        }


        #region 其他方法
        private void Language_Off(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            control.ImeMode = ImeMode.Close;
            Fun.SetInputLanguageOff();
        }

        private void Language_On(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            control.ImeMode = ImeMode.On;
            Fun.SetInputLanguageOff();
        }

        #endregion

        private void listView_hzbr_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listView_hzbr.SelectedIndices.Count == 0) return;
                ListViewItem item = (ListViewItem)listView_hzbr.SelectedItems[0];
                string jzid = Convertor.IsNull(item.SubItems["jzid"].Text, Guid.Empty.ToString());
                string ghxxid = item.SubItems["ghxxid"].Text;
                string zdmc = item.SubItems["诊断"].Text;
                Tab = null;
                Tab = mzys.Select_cf(0, new Guid(ghxxid), 0, 0, Guid.Empty, new Guid(jzid), 0, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);

                AddPresc(Tab);
                Add_Yj_record(new Guid(jzid));

                string ssql = @"select  dbo.fun_zy_age(csrq,3,getdate()) nl,dbo.FUN_ZY_SEEKSEXNAME(xb) xb,* from vi_yy_brxx a  inner join vi_mz_ghxx b 
                    on a.brxxid=b.brxxid where b.ghxxid='" + ghxxid + "'";
                DataTable tbbr = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbbr.Rows.Count > 0)
                {
                    lbltitle.Text = "  病人姓名:" + tbbr.Rows[0]["brxm"].ToString();
                    lbltitle.Text = lbltitle.Text + "  性别:" + tbbr.Rows[0]["xb"].ToString();
                    lbltitle.Text = lbltitle.Text + "  年龄:" + tbbr.Rows[0]["nl"].ToString();
                    lbltitle.Text = lbltitle.Text + "  门诊号:" + tbbr.Rows[0]["blh"].ToString();
                    lbltitle.Text = lbltitle.Text + "  诊断:" + zdmc;
                }
                else
                    lbltitle.Text = "";



                //2011-09-04
                ssql = "select * from MZYS_DZYZ where jzid='" + jzid + "'";
                DataTable tbdzyz = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbdzyz.Rows.Count == 0) return;

                txt_zs.Text = "";
                txt_xbs.Text = "";
                txt_jws.Text = "";
                txt_tgjc.Text = "";
                txt_fzjc.Text = "";
                txt_cz.Text = "";
                txt_blxx.Text = "";

                txt_zs.Text = Convertor.IsNull(tbdzyz.Rows[0]["zs"], "");
                txt_xbs.Text = Convertor.IsNull(tbdzyz.Rows[0]["xbs"], "");
                txt_jws.Text = Convertor.IsNull(tbdzyz.Rows[0]["jws"], "");
                txt_tgjc.Text = Convertor.IsNull(tbdzyz.Rows[0]["tgjc"], "");
                txt_fzjc.Text = Convertor.IsNull(tbdzyz.Rows[0]["fzjc"], "");
                txt_cz.Text = Convertor.IsNull(tbdzyz.Rows[0]["cz"], "");

                string bz = "";
                bz = "就诊时间;" + Convert.ToDateTime(tbdzyz.Rows[0]["djsj"]).ToShortDateString() + "\r\n";
                bz = bz + "诊断;" + zdmc + "\r\n";
                bz = bz + "主诉;" + txt_zs.Text + "\r\n";
                bz = bz + "现病史;" + txt_xbs.Text + "\r\n";
                bz = bz + "既往史;" + txt_jws.Text + "\r\n";
                bz = bz + "体格检查;" + txt_tgjc.Text + "\r\n";
                bz = bz + "辅助检查;" + txt_fzjc.Text + "\r\n";
                bz = bz + "处置;" + txt_cz.Text + "\r\n";
                txt_blxx.Text = bz;


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnucwmb_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            try
            {

                if (dataGridView1.CurrentCell == null) return;
                int nrow = dataGridView1.CurrentCell.RowIndex;
                if (tb.Rows.Count == 0) return;
                Guid _hjID = new Guid(Convertor.IsNull(tb.Rows[nrow]["hjid"], Guid.Empty.ToString()));

                //分组处方
                string[] GroupbyField1 ={ "HJID", "执行科室ID" };
                string[] ComputeField1 ={ "金额" };
                string[] CField1 ={ "sum" };
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb;
                DataTable tbcf1 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "hjid='" + _hjID + "' and 项目id>0");
                if (tbcf1.Rows.Count == 0) { return; }

                string[] GroupbyField ={ "HJID", "执行科室ID", "项目来源", "剂数" };
                string[] ComputeField ={ "金额" };
                string[] CField ={ "sum" };
                TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                xcset.TsDataTable = tb;
                DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "hjid='" + _hjID + "' and 项目id>0");
                if (tbcf.Rows.Count == 0) { return; }

                if (tbcf1.Rows.Count != tbcf.Rows.Count)
                {
                    MessageBox.Show("请检查处方的数据是否正确,可能存在同一张处方有不同的执行科室或不同的医生或不同的开单科室的情况", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //返回变量
                int _err_code = -1;
                string _err_text = "";
                //时间
                string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                Guid _Mbid = Guid.Empty;
                string _mbmc = "";
                string _pym = "";
                string _wbm = "";
                string _bz = "";
                int _mbjb = 2;
                int _ksdm = 0;
                int _ysdm = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                int _zxks = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[0]["执行科室ID"], "0"));
                string _djsj = _sDate;
                int _djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                string fid = "";
                Guid _NewMbid = Guid.Empty;
                int _xmly = Convert.ToInt32(tbcf.Rows[0]["项目来源"]);
                int _js = Convert.ToInt32(tbcf.Rows[0]["剂数"]);


                DlgInputBox Inputbox = new DlgInputBox("", "请输入模板名称", "保存模板");
                Inputbox.NumCtrl = false;
                Inputbox.ShowDialog();
                if (!DlgInputBox.DlgResult) return;
                //Add By Zj 2012-03-15
                frmmbwh frmmbwh = new frmmbwh(_menuTag, _mbjb);
                frmmbwh.Text = "选择模板所属分类.";
                frmmbwh.panel1.Visible = false;
                frmmbwh.btnselect.Visible = true;
                frmmbwh.ShowDialog();
                if (frmmbwh.fid == "")
                    return;
                else
                    fid = frmmbwh.fid;
                _mbmc = DlgInputBox.DlgValue.ToString();
                if (_mbmc.Trim() == "") return;


                InstanceForm.BDatabase.BeginTransaction();

                //查找当前处方
                DataRow[] rows = tb.Select("HJID='" + _hjID + "' and 执行科室ID=" + _zxks + "  and 项目id>0 ");

                jc_mb.SaveMb(_Mbid, TrasenFrame.Forms.FrmMdiMain.Jgbm, _mbmc, _pym, _wbm, _bz, _mbjb, _ksdm, _ysdm, _zxks, _djsj, _djy, fid, out _NewMbid, out _err_code, out _err_text, InstanceForm.BDatabase);
                if ((_NewMbid == Guid.Empty && _Mbid == Guid.Empty) || _err_code != 0) throw new Exception(_err_text);

                if (rows == null) throw new Exception("没有找到行，请刷新数据");
                if (rows.Length == 0 && _Mbid != Guid.Empty) throw new Exception("没有需要保存的行");
                //插处方明细表
                for (int j = 0; j <= rows.Length - 1; j++)
                {

                    #region 保存明细
                    Guid _NewMbmxid = Guid.Empty;
                    Guid _mbmxid = Guid.Empty;
                    string _pm = Convertor.IsNull(rows[j]["医嘱内容"], "");
                    decimal _dj = Convert.ToDecimal(Convertor.IsNull(rows[j]["单价"], "0"));
                    decimal _sl = Convert.ToDecimal(Convertor.IsNull(rows[j]["数量"], "0"));
                    decimal _je = Convert.ToDecimal(Convertor.IsNull(rows[j]["金额"], "0"));
                    long _xmid = Convert.ToInt64(Convertor.IsNull(rows[j]["yzid"], "0"));
                    int _bzby = Convert.ToInt32(Convertor.IsNull(rows[j]["自备药"], "0"));
                    decimal _yl = Convert.ToDecimal(Convertor.IsNull(rows[j]["剂量"], "0"));
                    string _yldw = Convertor.IsNull(rows[j]["剂量单位"], "");
                    int _yldwid = Convert.ToInt32(Convertor.IsNull(rows[j]["剂量单位id"], "0"));
                    int _dwlx = Convert.ToInt32(Convertor.IsNull(rows[j]["dwlx"], "0"));
                    int _yfid = Convert.ToInt32(Convertor.IsNull(rows[j]["用法id"], "0"));
                    int _pcid = Convert.ToInt32(Convertor.IsNull(rows[j]["频次id"], "0"));
                    decimal _ts = Convert.ToDecimal(Convertor.IsNull(rows[j]["天数"], "0"));
                    string _zt = Convert.ToString(Convertor.IsNull(rows[j]["嘱托"], ""));
                    int _fzxh = Convert.ToInt32(Convertor.IsNull(rows[j]["处方分组序号"], "0"));
                    int _pxxh = Convert.ToInt32(Convertor.IsNull(rows[j]["排序序号"], "0"));
                    int _cjid = 0;
                    if (_xmly == 1)
                    {
                        _cjid = Convert.ToInt32(Convertor.IsNull(rows[j]["项目ID"], "0"));
                        Ypcj cj = new Ypcj(_cjid, InstanceForm.BDatabase);
                        _xmid = cj.GGID;
                    }
                    if ((_sl == 0 || _js == 0 || _je == 0) && _bzby == 0) throw new Exception(_pm + " 没有数量或金额");
                    jc_mb.SaveMbmx(_mbmxid, _NewMbid, _xmid, _xmly, _yl, _yldw, _yldwid, _dwlx, _yfid, _pcid, _zt,
                        _ts, _fzxh, _pxxh, _bzby, _cjid, _js, out  _NewMbmxid, out _err_code, out _err_text, _hjID, _zxks, InstanceForm.BDatabase);
                    if ((_NewMbmxid == Guid.Empty && _mbmxid == Guid.Empty) || _err_code != 0) throw new Exception(_err_text);

                    #endregion 保存明细

                }
                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("保存成功");


            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void listView_hzbr_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

        private void listView_hzbr_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView_hzbr_DoubleClick(sender, e);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentCell == null) return;
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            int nrow = this.dataGridView1.CurrentCell.RowIndex;
            int ncol = this.dataGridView1.CurrentCell.ColumnIndex;
            if (dataGridView1.Columns[ncol].Name == "选择")
            {
                DataRow[] rows1 = tb.Select("hjid='" + tb.Rows[nrow]["hjid"] + "' and 分方状态='" + tb.Rows[nrow]["分方状态"] + "'");
                int b = Convert.ToInt16(Convertor.IsNull(tb.Rows[nrow]["选择"], "0"));
                if (b == 1)
                {
                    for (int i = 0; i <= rows1.Length - 1; i++)
                    {
                        rows1[i]["选择"] = false;//if (rows1[i]["序号"].ToString().Trim() != "小计") 
                    }
                }
                else
                    for (int i = 0; i <= rows1.Length - 1; i++)
                        rows1[i]["选择"] = true;//if (rows1[i]["序号"].ToString().Trim() != "小计") 
            }
        }

        private void butok_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.DataSource == null)
                    return;

                DataTable tab = (DataTable)dataGridView1.DataSource;
                DataRow[] rows = tab.Select("选择=true", "");//"hjid,排序序号
                Tab = tab.Clone();
                for (int i = 0; i <= rows.Length - 1; i++)
                    Tab.ImportRow(rows[i]);
                bok = true;
                this.Close();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 查看PACS结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Guid hjmxid = new Guid();
                if (dataGridView1.CurrentRow == null)
                    return;
                if (dataGridView1.CurrentRow.Cells["HJMXID"].Value.ToString() == "" && dataGridView1.CurrentRow.Cells["HJMXID"].Value.ToString() != Guid.Empty.ToString())
                {
                    string ssql = "select top 1 HJMXID from  VI_MZ_HJB_MX where HJID='" + dataGridView1.CurrentRow.Cells["HJID"].Value.ToString() + "' and YZID=" + dataGridView1.CurrentRow.Cells["YZID"].Value.ToString();
                    DataRow dr = InstanceForm.BDatabase.GetDataRow(ssql);
                    if (dr != null)
                    {
                        hjmxid = new Guid(dr["HJMXID"].ToString());
                    }

                }
                if (Convert.ToString(Convertor.IsNull(dataGridView1.CurrentRow.Cells["HJMXID"].Value, Guid.Empty.ToString())) == Guid.Empty.ToString() && hjmxid == Guid.Empty)
                {
                    MessageBox.Show("请保存以后再查看结果!或者选中该条检验项目再点击右键查看!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (hjmxid == Guid.Empty)
                    hjmxid = new Guid(dataGridView1.CurrentRow.Cells["HJMXID"].Value.ToString());
                ReadPacsInfo(hjmxid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查看PACS结果出错!" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 查看Pasc结果
        /// </summary>
        /// <param name="id"></param>
        public void ReadPacsInfo(Guid id)
        {
            string pacsName = "";
            try
            {
                pacsName = ApiFunction.GetIniString("PACS", "PACS类型", Constant.ApplicationDirectory + "\\pacs.ini");
                ts_pacs_interface.Ipacs pacs = ts_pacs_interface.PacsFactory.Pacs(pacsName);
                pacs.ShowPacsInfo(id.ToString(), ts_pacs_interface.PatientSource.门诊);

                //GetPacsInfo(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到有效的记录，请重新查证！\n" + ex.Message + pacsName, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

































    }
}