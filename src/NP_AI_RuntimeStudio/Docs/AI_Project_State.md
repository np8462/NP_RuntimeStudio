
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------


NP_AI_RuntimeStudio

Version: 0.0.7

Session Date:
2026-06-07

Status:
VS2012 AddIn Integration + AI IDE Foundation

# =========================================

COMPLETED TODAY

Visual Studio AddIn Runtime Fix

Problem:

NP.Storage inside VS2012 AddIn mode was resolving paths to:

C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\Runtime

which caused:

Access Denied

during ChatHistory save operations.

Solution:

StoragePaths completely refactored.

New architecture:

HostType

* WinForms
* VisualStudioAddIn

Storage paths now resolve differently depending on runtime host.

Result:

NP.Extension successfully stores data outside Visual Studio protected folders.

# =========================================

StoragePaths Refactor

Implemented:

StoragePaths

Host detection

RuntimeFolder

ProjectsFolder

ProjectFolder

ChatsFolder

Current AddIn storage target:

Documents\NP_RuntimeStudio\Runtime

Result:

ChatRepository now works correctly inside VS2012 AddIn environment.

# =========================================

VS2012 Integration

Successful:

AddIn loads correctly.

AddIn menu item appears.

Custom command execution confirmed.

Ask AI context-menu prototype tested.

Result:

VS2012 can now invoke RuntimeStudio commands.

# =========================================

AI IDE FOUNDATION

New Architecture Defined

NP.Core

AiContext

NP.AI

Providers
Parsers
Services

NP.Storage

Projects
Chats
Attachments

NP.UI

AiRequestForm
CodeEditorForm
AiPreviewForm

NP.Extension

Connect
VsSelectionService
VsDocumentService
VsContextMenuService

Goal:

Keep VS integration isolated from AI logic.

# =========================================

CONTEXT MENU DESIGN

Defined:

Right Click

↓

Ask AI...

Future:

Right Click

NP Runtime Studio

* Ask AI
* Explain Code
* Refactor Code
* Generate Unit Test
* Generate Interface
* Generate XML Docs

Architecture validated.

# =========================================

CODE SELECTION PIPELINE

Planned Flow

VS2012

↓

Selected Code

↓

AiContext

↓

AiRequestForm

↓

AIRequest

↓

AIResponse

↓

Preview

↓

Apply To Editor

This becomes the foundation of AI-assisted refactoring.

# =========================================

IMPORTANT DISCOVERY

Ask AI command is already being invoked.

Issue:

Test Form created through AddIn did not display correctly.

Likely causes:

* Owner window handling
* STA/UI thread ownership
* Form startup positioning
* VS2012 host context

Needs investigation next session.

# =========================================

CURRENT MILESTONE

RuntimeStudio is no longer only a Chat Client.

RuntimeStudio can now communicate with:

* AI Providers
* Project Storage
* Visual Studio 2012

Project status:

AI Assisted IDE Prototype

Foundation Completed.

# =========================================

NEXT SESSION START POINT

Priority 1

AiRequestForm

* Create dedicated UI
* Display selected code
* Display project information
* Enter AI instruction

Priority 2

AiContext

* Create model
* Pass selected code
* Pass file metadata
* Pass project metadata

Priority 3

VsSelectionService

* Get selected code
* Get active document
* Get file path

Priority 4

Attach Code To AIRequest

Selected code

↓

AI prompt

↓

Provider

↓

AIResponse

Priority 5

Preview Window

AIResponse

↓

Preview

↓

Apply

↓

Replace Selection

# =========================================

LONG TERM VISION

VS2012

↓

Right Click

↓

Ask AI

↓

AI Refactor

↓

Preview

↓

Apply

↓

Save

↓

Project Update

NP_AI_RuntimeStudio

evolving toward

AI Assisted IDE

Version 0.0.7 Milestone Reached Successfully.


-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------



NP_AI_RuntimeStudio

Version: 0.0.4

Last Session:
2026-05-30

Status:
AI Integration (First Online Connection Tested)

Completed

- IntelliSense Engine refactored.

- SuggestionCatalog created and replaces CommandCatalog.

- Commands centralized in SuggestionCatalog.

- ObjectTypes centralized in SuggestionCatalog.

- IntelliSense multi-stage filtering implemented.

- /createtype command working.

- ObjectType suggestions working:
  
  - Class (*.cs)
  - Form (*.cs)
  - Interface (*.cs)
  - Enum (*.cs)
  - Struct (*.cs)
  - Repository (*.cs)
  - Service (*.cs)
  - Module (*.cs)
  - Library (*.cs)
  - Project
  - Custom

- Space key can accept selected IntelliSense item.

- Enter key can accept selected IntelliSense item.

- DoubleClick selection working.

AI System

Created:

- IAiProvider
- OpenAiProvider
- AiSettings
- AskAiAsync()

MessageType Updates

Added:

- AIRequest
- AIResponse

Current Flow

User
-> AIRequest

OpenAI
-> AIResponse

First Online Test

Success:

- TLS connection established.
- HTTPS connection established.
- OpenAI endpoint reachable.
- JSON response received.
- Response stored in ChatHistory.json.
- Assistant message created successfully.

Current Error

Received:

Incorrect API key provided: ''

Reason:

- ApiKey is empty.
- Network connection is working.
- SSL/TLS issue solved.

Pending Tasks

1. Improve AskAiAsync()

Current:

AI errors are stored as AIResponse.

Required:

If OpenAI returns error:
MessageType.Error

Else:
MessageType.AIResponse

2. Response Parsing

Current:

Entire JSON response stored in Content.

Required:

Extract final AI text only.

3. RichTextBox Colors

Implement color mapping:

Comment      -> Black
Command      -> Purple
Planning     -> DarkBlue
Meta         -> Gray
Memory       -> DarkCyan
Debug        -> Orange
AIRequest    -> Blue
AIResponse   -> DarkGreen
Error        -> Red

4. History Storage Improvement

Current:

Type stored as integer.

Example:

"Type": 7

Future:

Store readable name.

Example:

"TypeName": "AIResponse"

or

"Type": "AIResponse"

5. CreateProvider()

Move provider creation into centralized method.

6. AI Settings File

Planned:

Runtime/Settings/AiSettings.json

Future Content:

{
"Provider": "OpenAI",
"ApiKey": "",
"Model": "gpt-5"
}

Architecture Notes

Current AI pipeline:

ChatStudioForm
->
AskAiAsync
->
IAiProvider
->
OpenAiProvider
->
OpenAI API
->
AIResponse/Error

Important Notes

- TLS problem resolved.
- OpenAI communication confirmed.
- No valid API key configured yet.
- AIRequest concept validated.
- AIResponse should be generated only by system.
- Future ComboBox may hide AIResponse from user selection.

Next Session Start Point

Continue from:

AskAiAsync Error Handling
RichTextBox Color System
Response Parsing
History TypeName Storage
AI Settings File


-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------


NP_AI_RuntimeStudio

Version: 0.0.3

Date: 2026-05-30

Completed

- Solution created:
  
  - NP.Host
  - NP.Core

- Chat UI created:
  
  - ChatStudioForm
  - Message Input
  - Message History
  - Message Type ComboBox

- MessageType system implemented:
  
  - Comment
  - Command
  - Meta
  - Planning
  - Memory
  - Debug
  - AIResponse
  - Generation
  - Execution
  - RuntimeEvent
  - System
  - Error

- JSON storage selected instead of SQLite for current phase.

- ChatHistory.json storage working.

- MessageClassifier implemented.

- MessageValidator implemented.

- CommandParser implemented.

- CommandExecutor implemented.

- Runtime folder creation command tested successfully.

- IntelliSense popup implemented.

- Command suggestions implemented.

- ComboBox (cmbMsgType) added and synchronized with command workflow.

Architecture Decisions

- SQLite postponed to a future phase.
- JSON remains current persistence layer.
- All runtime operations should use try/catch.
- Errors should be shown using MessageBox.Show(ex.Message).
- AI_Project_State.md will be used as project memory.

Object System

Created:

- ObjectTypeDefinition
- ObjectDefinition

Current ObjectType strategy:

- System types remain Enum based.
- Custom object types will be supported later.
- ObjectType enum contains:
  - Class
  - Form
  - Interface
  - Service
  - Repository
  - Html
  - Css
  - JavaScript
  - Json
  - Xml
  - Module
  - Workflow
  - Project
  - Library
  - Custom

Custom types will later be loaded from:

Workspace/ObjectTypes/

Next Tasks

1. Improve IntelliSense hierarchy:
   
   - Commands
   - Object Types
   - Templates

2. Implement:
   
   - /createtype
   - /createfile
   - /writefile
   - /readfile
   - /listfiles

3. Add ObjectTypeCatalog.

4. Add template selection system.

5. Add ProjectState command.

Notes

- NP_Runtime.db belongs to previous SQLite experiments.
- Current runtime uses JSON only.
- Do not remove ObjectDefinition classes; they will be used in future template/code generation phases.