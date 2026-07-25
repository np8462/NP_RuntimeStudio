console.log("CONTENT LOADED");

chrome.runtime.onMessage.addListener(

function(request)
{
    if(request.action!="SendSelection")
        return;

    SelectionService.sendSelection();
});

class SelectionService
{
    static getSelectedText()
    {
        return window
            .getSelection()
            .toString();
    }

    static sendSelection()
    {
        const text =
            this.getSelectedText();

        if(text.length==0)
            return;

        ChromeBridge.send(
            BridgeAction.InsertCode,
            {
                Content:text
            });
    }
}

//chrome.runtime.onMessage.addListener(
//function (request, sender, sendResponse) {
//    console.log("REQUEST RECEIVED");

//    sendResponse(
//    {
//        Text: "TEST OK"
//    });

//    return true;
//});