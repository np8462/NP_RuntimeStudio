class ConversationListener {

    constructor() {

        this._lastText = "";

        this._timer = null;

        this._observer = null;
    }

    start() {

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

        console.log("ConversationListener started.");
    }

    //----------------------------------------

    onMutation() {

        const articles =
            document.querySelectorAll("article");

        if (articles.length === 0)
            return;

        const last =
            articles[articles.length - 1];

        const text =
            last.innerText.trim();

        if (text === "")
            return;

        if (text !== this._lastText)
        {
            this._lastText = text;

            console.log("Assistant Updated");

            console.log(text);

            clearTimeout(this._timer);

            this._timer =
                setTimeout(
                    this.onFinished.bind(this),
                    800);
        }
    }

    //----------------------------------------

    onFinished() {

        console.log("Assistant Finished");

        console.log(this._lastText);

        alert("آخرین پاسخ AI آماده شد.");
    }
}

new ConversationListener().start();