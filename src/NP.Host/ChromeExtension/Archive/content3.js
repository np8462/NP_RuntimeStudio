let refreshTimer = null;

const observer = new MutationObserver(() =>
{
    clearTimeout(refreshTimer);

refreshTimer =
    setTimeout(
        printConversationSnapshot,
        300);
});

observer.observe(
    document.body,
    {
        childList: true,
        subtree: true,
        characterData: true
    });

function printConversationSnapshot()
{
    console.clear();

    console.log("====== Conversation Snapshot ======");

    console.log(
        document.body.innerText);
}