public class AiContext
{
    public string ProjectName
    {
        get;
        set;
    }

    public string FileName
    {
        get;
        set;
    }

    public string FilePath
    {
        get;
        set;
    }

    public string SelectedCode
    {
        get;
        set;
    }

    public string UserPrompt
    {
        get;
        set;
    }

    // Hidden Context
    public AttachmentInfo SourceAttachment
    {
        get;
        set;
    }

    // User Attachment
    public AttachmentInfo UserAttachment
    {
        get;
        set;
    }

    public bool HasAttachment
    {
        get { return SourceAttachment != null; }
    }
}