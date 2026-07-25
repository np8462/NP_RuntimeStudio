public class ObjectTypeDefinition
{
    public string Name { get; set; }

    public string Category { get; set; }

    public string Description { get; set; }

    public string TemplateFile { get; set; }

    public string DefaultExtension { get; set; }

    public bool IsSystemType { get; set; }
}

public class ObjectDefinition
{
    public string Name { get; set; }

    public ObjectType Type { get; set; }

    // فقط وقتی Type=Custom
    public string CustomTypeName { get; set; }

    public string Platform { get; set; }

    public string Template { get; set; }

    public string Description { get; set; }
}

public enum ObjectType
{
    Folder,

    Class,
    Interface,
    Enum,
    Struct,

    Form,
    UserControl,

    Service,
    Repository,
    Command,
    Plugin,

    Json,
    Xml,
    Config,

    Html,
    Css,
    JavaScript,

    SqlScript,
    Report,

    ApiController,

    Module,
    Template,
    Workflow,

    Library,
    Project,

    Custom
}