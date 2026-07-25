class RuntimeConversationListener
{
    constructor()
    {
        this._observer = null;

        this._timer = null;

        this._lastHash = "";
    }

    //-------------------------------------

    start()
    {
        console.log("RuntimeConversationListener Started");

        this._observer =
            new MutationObserver(
                this.onMutation.bind(this));

        this._observer.observe(
            document.body,
            {
                childList: true,
                subtree: true,
                characterData: true
            });
    }

    //-------------------------------------

    onMutation(mutations)
    {
        clearTimeout(this._timer);

        this._timer =
            setTimeout(
                () =>
                {
                    this.process(mutations);
    },
                400);
}

//-------------------------------------

process(mutations)
{
    for(const mutation of mutations)
    {
        let node =
            mutation.target;

        const conversation =
            this.findConversation(node);

        if(conversation==null)
            continue;

        const text =
            conversation.innerText.trim();

        if(text.length<50)
            continue;

        const hash =
            text.length + "_" +
            text.substring(
                Math.max(
                    0,
                    text.length-60));

        if(hash==this._lastHash)
            return;

        this._lastHash =
            hash;

        console.clear();

        console.log("========== Conversation ==========");

        console.log(conversation);

        console.log("-------------------------------");

        console.log(text);

        console.log("-------------------------------");

        console.log("Length :",text.length);

        return;
    }
}

//-------------------------------------

findConversation(node)
{
    while(node)
    {
        if(node.nodeType!=1)
        {
            node=node.parentNode;
            continue;
        }

        const tag =
            node.tagName;

        if(
            tag=="SCRIPT" ||
            tag=="STYLE" ||
            tag=="SVG" ||
            tag=="PATH")
        {
            return null;
        }

        try
        {
            const txt =
                node.innerText;

            if(
                txt &&
                txt.length>300)
            {
                return node;
            }
        }
        catch
        {

        }

        node =
            node.parentElement;
    }

    return null;
}
}

new RuntimeConversationListener().start();