class ChatDomExplorer
{
    constructor()
    {
        this.nodes = [];
    }

    scan()
    {
        this.nodes = [];

        const all =
            document.querySelectorAll("*");

        all.forEach(node =>
        {
            if (!node.innerText)
                return;

            const text =
                node.innerText.trim();

        if (text.length < 30)
            return;

        this.nodes.push(
        {
            tag: node.tagName,

            className: node.className,

            id: node.id,

            textLength: text.length,

            text: text.substring(0,120),

            node: node
        });
    });
}

print()
{
    console.clear();

    console.log("========== DOM ==========");

    this.nodes
        .sort((a,b)=>b.textLength-a.textLength);

    this.nodes
        .slice(0,20)
        .forEach(n =>
        {
            console.log("----------------");

    console.log("Tag :", n.tag);

    console.log("Class :", n.className);

    console.log("Id :", n.id);

    console.log("Length :", n.textLength);

    console.log(n.text);
});
}
}

const explorer =
    new ChatDomExplorer();

explorer.scan();

explorer.print();