using System;
using System.Drawing;
using System.Windows.Forms;

namespace DOGPlatform
{
    public class Track:System.Windows.Forms.Panel
    {
        public delegate void TrackClick(Track track);
        public TrackClick TrackClicked;
        public Track()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Track
            // 
            this.AutoScroll = true;
            this.Name = "Track";
            this.Click += new System.EventHandler(this.Track_Click);
            this.ResumeLayout(false);

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void Track_Click(object sender, EventArgs e)
        {
            if (TrackClicked != null)
                TrackClicked(this);
        }

   

        

   


    }
}
