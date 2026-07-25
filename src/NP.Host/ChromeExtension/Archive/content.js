console.log("CONTENT LOADED");

chrome.runtime.onMessage.addListener(
function(message,sender,sendResponse)
{
    console.log(message);

    if(message.action!="insertCode")
        return;

    let textarea=document.querySelector("textarea");

    console.log(textarea);

    if(!textarea)
    {
        console.log("textarea not found");
        return;
    }

    textarea.focus();

    textarea.value=message.text;

    textarea.dispatchEvent(
        new InputEvent(
            "input",
            {
                bubbles:true
            }));

    console.log("Inserted");
});