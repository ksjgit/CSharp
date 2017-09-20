using System.Drawing;


namespace 원격제어
{
    //메시지를 수신하는 서버에서는 수신한 버퍼의 내용을 분석하는 부분이 필요합니다. 여기에서는 Meta 클래스를 정의하여 분석한 정보를 표현합시다.
    /// <summary>
    /// 원격 제어 이벤트 수신 정보를 변환한 클래스
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// 원격 제어 이벤트 종류 - 가져오기
        /// </summary>
        public MsgType Mt { get; private set; } //메세지 종료

        /// <summary>
        /// 누르거나 뗀 키 - 가져오기
        /// </summary>
        public int Key { get; private set; } //다운, 업 키

        /// <summary>
        /// 마우스 좌표 - 가져오기
        /// </summary>
        public Point Now { get; private set; } //마우스 좌표

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="data">수신한 원격 제어 이벤트 </param>
        public Meta(byte[] data)
        {
            Mt = (MsgType)data[0]; //메세지 종류 설정

            //메시지 종류에 따라 수신한 버퍼를 변환합니다. 
            //키를 누르거나 뗀 이벤트일 때는 수신한 버퍼의 내용을 키로 변환하고 마우스 이동 이벤트일 때는 좌표로 변환하세요.
            switch (Mt)
            {
                case MsgType.MT_KDOWN:
                    MakingKey(data);
                    break;
                case MsgType.MT_KEYUP:
                    MakingKey(data);
                    break;
                case MsgType.MT_M_MOVE:
                    MakingPoint(data);
                    break;
                
            }
        }

        private void MakingKey(byte[] data)
        {
            Key = (data[4] << 24) + (data[3] << 16) + (data[2] << 8) + data[1]; //data를 키로 변환
        }

        private void MakingPoint(byte[] data)
        {
            Point now = new Point(0, 0);

            now.X = (data[4] << 24) + (data[3] << 16) + (data[2] << 8) + data[1];
            now.Y = (data[8] << 24) + (data[7] << 16) + (data[6] << 8) + data[5];
            Now = now;
        }
    }
}
