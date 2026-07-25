class ChromeBridge
{
    static send(action, payload)
    {
        const packet =
        {
            id: Date.now().toString(),

            sessionId: "",

            source: "Chrome",

            target: "Runtime",

            type: "Chrome",

            Action: action,

            payload: payload
        };

        chrome.runtime.sendMessage(packet);
    }
}