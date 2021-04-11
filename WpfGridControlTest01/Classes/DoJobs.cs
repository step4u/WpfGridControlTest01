using System;

namespace WpfGridControlTest01.Classes
{
    public class DoJobs
    {
        public delegate void JobFinishedEventHandler(object sender, EventArgs e);
        public event JobFinishedEventHandler OnJobFinished;

        private byte[] _packet;

        public byte[] Packet {
            get { return _packet; }
            set { _packet = value; }
        }

        public DoJobs(byte[] packet)
        {
            _packet = packet;
        }

        public void Send()
        {
            if (OnJobFinished != null)
                OnJobFinished(this, new JobFinishedEventArgs() {
                    ErrCode = "9999",
                    Message = "Job finished successfully."
                });
        }

        public void Send(byte[] packet)
        {
            _packet = packet;

            if (OnJobFinished != null)
                OnJobFinished(this, new JobFinishedEventArgs()
                {
                    ErrCode = "9999",
                    Message = "Job finished successfully."
                });
        }
    }
}
