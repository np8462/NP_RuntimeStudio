console.log("POPUP LOADED");

function getSelectedCode()
{
    return document
        .getElementById("selectedCode")
        .value;
}

function sendBridgeAction(action, callback)
{
    chrome.runtime.sendMessage(
    {
        type:"tool_request",

        payload:
        {
            ToolName:"bridge",
            Action:action
        }
    },
    callback);
}

document.getElementById("receiveBtn").onclick =
function ()
{
    sendBridgeAction(
        "receive",
        function(response)
        {
            if(!response)
                return;

            if(response.status!="ok")
                return;

            let context =
                JSON.parse(response.response);

            document.getElementById("project").innerText =
                context.ProjectName;

            document.getElementById("file").innerText =
                context.FileName;

            document.getElementById("selectedCode").value =
                context.SelectedCode;
        });
};

document.getElementById("copyBtn").onclick =
async function ()
{
    let code =
        getSelectedCode();

    if(code.length==0)
    {
        showMessage("Nothing to copy");
        return;
    }

    await navigator.clipboard.writeText(code);

    showMessage("Copied");
};

document.getElementById("tempBtn").onclick =
function ()
{
    let code =
        getSelectedCode();

    if(code.length==0)
    {
        showMessage("Nothing");
        return;
    }

    let blob =
        new Blob(
        [code],
        {
            type:"text/plain"
        });

    let url =
        URL.createObjectURL(blob);

    let a =
        document.createElement("a");

    a.href =
        url;

    a.download =
        document.getElementById("file").innerText;

    a.click();

    URL.revokeObjectURL(url);

    showMessage("File Saved");
};

document.getElementById("sendAiBtn").onclick =
function ()
{
    chrome.tabs.query(
    {
        url:"https://chatgpt.com/*"
    },
    function(tabs)
    {
        console.log(tabs);

        if(tabs.length==0)
        {
            showMessage("ChatGPT not opened");
            return;
        }

        chrome.tabs.sendMessage(
            tabs[0].id,
            {
                action:"insertCode",
                text:getSelectedCode()
            });

        showMessage("Sent");
    });
};

document.getElementById("sendFileBtn").onclick =
async function ()
{
    let picker =
        document.getElementById("filePicker");

    if (picker.files.length == 0)
    {
        showMessage("Select File");
        return;
    }

    let file =
        picker.files[0];

    let text =
        await file.text();

    chrome.runtime.sendMessage(
    {
        type: "tool_request",

        payload:
        {
            ToolName: "bridge",

            Action: "sendFile",

            FileName: file.name,

            Content: text
        }
    });

    showMessage("File Sent");
};

function showMessage(text)
{
    let div =
        document.getElementById("status");

    div.innerText = text;

    div.style.display = "block";

    setTimeout(function ()
    {
        div.style.display = "none";
    },2000);
}