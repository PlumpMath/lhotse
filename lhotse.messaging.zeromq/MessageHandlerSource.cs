﻿namespace lhotse.messaging.zeromq
{
    public class MessageHandlerSource : IMessageHandlerFactory<TextRequest, TextResponse, TextProgressInfo>
    {
        public static MessageHandlerUri AddressUri = new MessageHandlerUri("tcp://127.0.0.1:5000");
        public static string Topic = "Status";
        public static MessageHandlerUri StatusUri = new MessageHandlerUri("tcp://127.0.0.1:5001");
        public static MessageHandlerSource Factory = new MessageHandlerSource();

        private IRPCClient<TextRequest, TextResponse, TextProgressInfo> _client;
        private IRPCServer<TextRequest, TextResponse, TextProgressInfo> _server;

        public IRPCClient<TextRequest, TextResponse, TextProgressInfo> Client => _client ?? (_client = new LazyPirateClient(AddressUri, StatusUri, Topic));
        public IRPCServer<TextRequest, TextResponse, TextProgressInfo> Server => _server ?? (_server = new LazyPirateServer(AddressUri, StatusUri, Topic));

        private MessageHandlerSource() { }
    }
}
