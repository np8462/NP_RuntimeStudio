let socket = null;

function ensureSocket()
{
    if(socket != null &&
       socket.readyState === WebSocket.OPEN)
    {
        return;
    }
    socket =
    new WebSocket(
        "ws://127.0.0.1:5050/bridge");
    //socket =
    //    new WebSocket("ws://127.0.0.1:5050");

    socket.onopen =
        function()
        {
            console.log("Runtime Connected");
        };

    socket.onerror =
        function(e)
        {
            console.log("Socket Error", e);
        };

    socket.onclose =
        function()
        {
            console.log("Runtime Closed");

            socket = null;
        };
}

chrome.runtime.onMessage.addListener(
function(message,sender,sendResponse)
{
    ensureSocket();

    if(socket.readyState !== WebSocket.OPEN)
    {
        socket.onopen =
        function()
        {
            socket.send(JSON.stringify(message));
        };
    }
    else
    {
        socket.send(JSON.stringify(message));
    }

    socket.onmessage =
    function(e)
    {
        console.log("HOST RESPONSE",e.data);

        sendResponse(
        {
            status:"ok",
            response:e.data
        });
    };

    return true;
});