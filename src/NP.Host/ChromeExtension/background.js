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
    sendToRuntime(
        message,
        function(result)
        {
            sendResponse(
            {
                Status:"OK",
                Response:result
            });
        });

    return true;
});

function sendToRuntime(message, callback)
{
    ensureSocket();
    socket.onopen =
    function()
    {
        console.log("CONNECTED");
    };

    function sendNow()
    {
        socket.send(JSON.stringify(message));

        socket.onmessage = function(e)
        {
            callback(e.data);
        };
    }

    if(socket.readyState === WebSocket.OPEN)
    {
        sendNow();
    }
    else
    {
        socket.addEventListener(
            "open",
            sendNow,
            { once:true });
    }
}