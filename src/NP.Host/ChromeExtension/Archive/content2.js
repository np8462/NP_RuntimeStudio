alert("content2.js loaded");

console.log("content2.js loaded");

console.log("Runtime DOM Listener Started");

const observer = new MutationObserver(function (mutations)
{
    mutations.forEach(function (mutation)
    {
        console.log("----------");

        console.log("Type:", mutation.type);

        console.log("Target:", mutation.target);

        console.log("Added:", mutation.addedNodes.length);

        console.log("Removed:", mutation.removedNodes.length);

     

        mutation.addedNodes.forEach(function(node)
        {
            if (node.nodeType === Node.ELEMENT_NODE)
            {
                console.log("Added Element:", node.tagName);

                console.log("Content:", node.textContent);

                console.log("Node:", node.Node);

                console.log("Tag:", node.tagName);

                console.log("Parent:", node.parentElement);

                console.log("Article:", node.closest("article"));
            
                console.log(document.querySelectorAll("article"));
               
                document.querySelectorAll("article")
                        .forEach((a,i)=>
                        {
                            console.log(
                                "ARTICLE",
                                i);

                console.dir(a);

                console.log(a.innerText);
            });
            }
        });
    });
});

observer.observe(document.body,
{
    childList: true,
    subtree: true,
    characterData: true
});