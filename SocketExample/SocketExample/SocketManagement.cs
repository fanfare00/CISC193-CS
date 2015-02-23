using System;
using System.Text;
using System.Net;
using System.Net.Sockets;


namespace SocketExample
{
    public class SocketManagement
    {
        private IPAddress _IP;
        private int _PORT;
        private TcpListener _TCP;
        private TcpClient _CLIENT;
        private NetworkStream _STREAM;

        public SocketManagement(String ip, int port)
        {
            _IP = IPAddress.Parse(ip);
            _PORT = port;
        }

        public bool StartAsServer()
        {
            try
            {
                _TCP = new TcpListener(_IP, _PORT);
                _TCP.Start();
                _CLIENT = GetTcpClient();
                _STREAM = _CLIENT.GetStream();
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); return false; }
            return true;
        }

        public TcpClient GetTcpClient()
        {
            return _TCP.AcceptTcpClient();
        }

        public bool StartAsClient()
        {
            try
            {
                _CLIENT = new TcpClient();
                _CLIENT.Connect(_IP, _PORT);
                _STREAM = _CLIENT.GetStream();
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); return false; }
            return true;
        }

        public void sendData(string data)
        {
            //create new byte array
            //networks handle data through bytes rather than strings, ints etc
            //bytes are written to a stream and sent over the network via a 'packet'
            byte[] bytes = new byte[255];

            //turn our data into a sequence of bytes
            bytes = new ASCIIEncoding().GetBytes(data);

            //write the sequence of bytes to the stream connecting the two people
            _STREAM.Write(bytes, 0, bytes.Length);
        }

        public string getData()
        {
            string data;

            byte[] bytes = new byte[255];

            //get the byte sequence from the stream
            _STREAM.Read(bytes, 0, bytes.Length);

            //convert the bytes back to a stream
            data = new ASCIIEncoding().GetString(bytes);

            return data;
        }
    }
}
