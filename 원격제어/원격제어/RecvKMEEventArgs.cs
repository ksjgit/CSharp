using System;
using System.Drawing;

namespace 원격제어
{
    /// <summary>
    /// 원격 제어 이벤트 수신하였음을 통보하는 이벤트 인자 클래스
    /// </summary>
    public class RecvKMEEventArgs : EventArgs 
    {
        /// <summary>
        /// 수신한 원격 제어 이벤트를 분석한 개체 - 가져오기
        /// </summary>
        public Meta Meta { get; private set; }
        public int Key { get { return Meta.Key; } }
        public Point Now { get { return Meta.Now; } }
        public MsgType MT { get { return Meta.Mt; } }

        internal RecvKMEEventArgs(Meta meta)
        {
            Meta = meta;
        }
    }

    /// <summary>
    /// 원격 제어 이벤트 정보 수신하였음을 통보하는 이벤트에 관한 대리자
    /// </summary>
    /// <param name="sender">이벤트 통보 개체(게시자)</param>
    /// <param name="e">이벤트 인자</param>
    public delegate void RecvKMEEventHandler(object sender, RecvKMEEventArgs e);
}
