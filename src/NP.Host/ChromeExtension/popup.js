
document
.getElementById("btnSend")
.onclick =
function()
{
    ChromeBridge.send(
        "InsertCode",
        {
            ToolName:"ChromeBridge",

            Action:"InsertCode",

            Content:
                SelectionService.getSelectedText(),

            Url:
                location.href,

            PageTitle:
                document.title
        });
    //ChromeBridge.send(
    //    "SendFile",
    //    {
    //        FileName: "Customer.cs",

    //        Content: code
    //    });
    //ChromeBridge.send(
    //    "InsertCode",
    //    {
    //        Content: selectedText
    //    });
};

//document.getElementById("btnSend").onclick =
//async function ()
//{
//    chrome.tabs.sendMessage(
//        (await chrome.tabs.query(
//    {
//        active:true,
//    currentWindow:true
//}))[0].id,
//{
//    action:"SendSelection"
//});
//}

//document.getElementById("btnSend").onclick = async function ()
//{
//    alert("Popup Click");

//    const packet =
//    {
//        id: Date.now().toString(),

//        source:"Chrome",

//        target:"Runtime",

//        type:"ChromeCommand",

//        Action:"InsertCode",

//        payload:
//        {
//            ToolName:"ChromeBridge",

//            Action:"InsertCode",

//            Content:"test..."
//        }
//    };

//     chrome.runtime.sendMessage(packet);

//    console.log("Message Sent");
//}