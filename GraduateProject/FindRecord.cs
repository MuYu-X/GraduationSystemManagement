using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GraduateProject
{
    public partial class FindRecord : Form
    {

        public EventHandler<FindRecordWindowEventArgs> OnFindClick = null;
        public enum FindOptions { None, MatchCase, MatchWholeWord, MatchCaseAndWholeWord }
        public int CurrentIndex = -1;
        private AutoResetEvent resetEvent = new AutoResetEvent(false);

        public FindRecord()
        {
            
            
            InitializeComponent();
        }
       
   
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FindRecord_Load(object sender, EventArgs e)
        {

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void FindRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;

        }
      
        private void btFindNext_Click(object sender, EventArgs e)
        {

            if (this.tbFindTxt.Text.Trim().Length > 0)
            {
               
                FindOptions options = FindOptions.None;
                if (this.chbMatchCase.Checked && chbMatchWholeWord.Checked)
                {
                    options = FindOptions.MatchCaseAndWholeWord;

                }
                else if (this.chbMatchCase.Checked && !chbMatchWholeWord.Checked)
                {
                    options = FindOptions.MatchCase;
                }
                else if (!this.chbMatchCase.Checked && chbMatchWholeWord.Checked)
                {
                    options = FindOptions.MatchWholeWord;
                }
                else
                {
                    options = FindOptions.None;
                }
                OnFindClick(this, new FindRecordWindowEventArgs(this.tbFindTxt.Text, CurrentIndex, options));



            }

        }
        public new void Show()
        {
            base.Show();
            this.tbFindTxt.SelectAll();
        }

      
    }
    public class FindRecordWindowEventArgs:EventArgs
    {
        private string sFindTxt;

        private int iIndex = 0;

        private FindRecord.FindOptions findOptions;

        public string FindTxt
        {
            get
            {
                return this.sFindTxt;
            }
        }
        public int Index
        {
            get
            {
                return this.iIndex;
            }
        }
        public FindRecord.FindOptions _FindOptions
        {
            get
            {
                return this.findOptions;
            }
        }

        public string Findtxt { get; internal set; }

        public FindRecordWindowEventArgs(string _findtxt,int _index,FindRecord.FindOptions _findOptions)
        {
            this.sFindTxt = _findtxt;
            this.iIndex = _index;
            this.findOptions = _findOptions;
        }
   
        
    }



  
}
