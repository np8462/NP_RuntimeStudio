class RuntimeMessage
{
    constructor()
    {
        this.node = null;

        this.text = "";

        this.html = "";

        this.timestamp = new Date();

        this.hash = "";

        this.isProposal = false;
    }
}

class RuntimeConversationListener
{
    constructor()
    {
        this._observer = null;

        this._timer = null;

        this._lastHash = "";
    }

    start()
    {
        console.log("RuntimeConversationListener Started");

        this._observer =
            new MutationObserver(
                this.onMutation.bind(this));

        this._observer.observe(
            document.body,
            {
                childList:true,
                subtree:true,
                characterData:true
            });
    }

    onMutation(mutations)
    {
        clearTimeout(this._timer);

        this._timer =
            setTimeout(
                ()=>
                {
                    this.process(mutations);
    },
                300);
}

process(mutations)
{
    for(const mutation of mutations)
    {
        let node =
            mutation.target;

        const message =
            this.findMessage(node);

        if(message==null)
            continue;

        RuntimeBridge.receive(message);

        return;
    }
}

//--------------------------------

findMessage(node)
{
    while(node)
    {
        if(node.nodeType!=1)
        {
            node=node.parentNode;
            continue;
        }

        try
        {
            if(
                node.classList &&
                node.classList.contains("markdown"))
            {
                const msg =
                    new RuntimeMessage();

                msg.node=node;

                msg.text=
                    node.innerText.trim();

                msg.html=
                    node.innerHTML;

                msg.hash=
                    msg.text.length+
                    "_" +
                    msg.text.substring(
                        Math.max(
                            0,
                            msg.text.length-40));

                if(msg.hash==
                    this._lastHash)
                    return null;

                this._lastHash=
                    msg.hash;

                return msg;
            }
        }
        catch
        {

        }

        node=node.parentElement;
    }

    return null;
}
}

class RuntimeProposalExtractor
{
    static extract(message)
    {
        const start =
            "[[[RuntimeProposal]]]";

        const end =
            "[[[/RuntimeProposal]]]";

        const i =
            message.text.indexOf(start);

        if(i<0)
            return null;

        const j =
            message.text.indexOf(end);

        if(j<0)
            return null;

        message.isProposal=true;

        return message.text.substring(
            i+start.length,
            j).trim();
    }
}

class RuntimeBridge
{
    static receive(message)
    {
        console.clear();

        console.log("========== Runtime Message ==========");

        console.log(message);

        const proposal =
            RuntimeProposalExtractor.extract(message);

        if(proposal)
        {
            console.log("");

            console.log("Proposal Found");

            console.log("----------------");

            console.log(proposal);
        }
    }
}

new RuntimeConversationListener().start();