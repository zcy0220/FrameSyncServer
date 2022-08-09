/**
 * 简易帧同步服务器（UDP)
 * 客户端连接数达到最大值，给所有客户端下发 战斗开始协议
 * 接受到所有客户端发送的资源加载完成消息，给所有客户端下发 帧同步开始协议
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace UDPServer
{
    public class UDPSocketServer
    {
        /// <summary>
        /// 同步Socket
        /// </summary>
        private Socket _socket;
        /// <summary>
        /// 连接的最大客户端数量
        /// </summary>
        private int _maxClient;
        /// <summary>
        /// 是否运行
        /// </summary>
        private bool _isRunning;
        /// <summary>
        /// IP地址
        /// </summary>
        private IPAddress _address;
        /// <summary>
        /// 端口
        /// </summary>
        private int _port;
        /// <summary>
        /// 客户端会话列表
        /// </summary>
        private List<UDPSocketState> _clients;
        /// <summary>
        /// 数据接受缓冲区
        /// </summary>
        private byte[] _recvBuffer;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="address">监听的IP地址</param>
        /// <param name="port">监听的端口</param>
        /// <param name="maxClient">连接的最大客户端数量</param>
        public UDPSocketServer(IPAddress address, int port, int maxClient)
        {
            _address = address;
            _port = port;
            _maxClient = maxClient;
            _socket = new Socket(address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="port"></param>
        /// <param name="maxClient"></param>
        public UDPSocketServer(int port, int maxClient) : this(IPAddress.Any, port, maxClient) { }

        /// <summary>
        /// 启动服务器
        /// </summary>
        public void Start()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                _socket.Bind(new IPEndPoint(_address, _port));
                new Thread(ReceiveData).Start();
            }
        }

        /// <summary>
        /// 停止服务器
        /// </summary>
        public void Stop()
        {
            if (_isRunning)
            {
                _isRunning = true;
                _socket.Close();

            }
        }

        /// <summary>
        /// 接受数据
        /// </summary>
        private void ReceiveData()
        {
            EndPoint remote = null;
            while (true)
            {
                try
                {
                    var len =_socket.ReceiveFrom(_recvBuffer, ref remote);
                    if (len < 0)
                    {
                        var a = 1;
                    }
                }
                catch(Exception)
                {
                }
            }
        }
    }
}
